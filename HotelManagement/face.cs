using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDevHtmlRenderer.Adapters;
using HotelManagement;
using System.Data.SqlClient;
using System.Data;
namespace HotelManagement
{
   

    public class face : Form
    {
        MYDB mydb = new MYDB();
        string employID = Login_Form.infoLogin.Trim();
        private double distance = 1E+19;

        private CascadeClassifier CascadeClassifier = new CascadeClassifier(Environment.CurrentDirectory + "/Haarcascade/haarcascade_frontalface_alt.xml");

        private Image<Bgr, byte> Frame = null;

        private Capture camera;

        private Mat mat = new Mat();

        private List<Image<Gray, byte>> trainedFaces = new List<Image<Gray, byte>>();

        private List<int> PersonLabs = new List<int>();

        private bool isEnable_SaveImage = false;

        private string ImageName;

        private PictureBox PictureBox_Frame;

        private PictureBox PictureBox_smallFrame;

        private string setPersonName;

        public bool isTrained = false;

        private List<string> Names = new List<string>();

        private EigenFaceRecognizer eigenFaceRecognizer;

        private IContainer components = null;

        public face()
        {
            InitializeComponent();
            if (!Directory.Exists(Environment.CurrentDirectory + "\\Image"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\Image");
            }
        }

        public void getPersonName(Control control)
        {
            Timer timer = new Timer();
            timer.Tick += timer_getPersonName_Tick;
            timer.Interval = 100;
            timer.Start();
            void timer_getPersonName_Tick(object sender, EventArgs e)
            {
                control.Text = setPersonName;
            }
        }

        public void openCamera(PictureBox pictureBox_Camera, PictureBox pictureBox_Trained)
        {
            PictureBox_Frame = pictureBox_Camera;
            PictureBox_smallFrame = pictureBox_Trained;
            camera = new Capture();
            camera.ImageGrabbed += Camera_ImageGrabbed;
            camera.Start();
        }

        public void Save_IMAGE(string imageName)
        {
            ImageName = imageName;
            isEnable_SaveImage = true;
        }

        private void Camera_ImageGrabbed(object sender, EventArgs e)
        {
            camera.Retrieve(mat);
            Frame = mat.ToImage<Bgr, byte>().Resize(PictureBox_Frame.Width, PictureBox_Frame.Height, Inter.Cubic);
            detectFace();
            PictureBox_Frame.Image = Frame.Bitmap;
        }

        private void detectFace()
        {
            Image<Bgr, byte> image = Frame.Convert<Bgr, byte>();
            Mat mat = new Mat();
            CvInvoke.CvtColor(Frame, mat, ColorConversion.Bgr2Gray);
            CvInvoke.EqualizeHist(mat, mat);
            Rectangle[] array = CascadeClassifier.DetectMultiScale(mat, 1.1, 4);
            if (array.Length != 0)
            {
                Rectangle[] array2 = array;
                foreach (Rectangle rectangle in array2)
                {
                    CvInvoke.Rectangle(Frame, rectangle, new Bgr(Color.LimeGreen).MCvScalar, 2);
                    SaveImage(rectangle);
                    image.ROI = rectangle;
                    trainedIamge();
                    checkName(image, rectangle);
                }
            }
            else
            {
                setPersonName = "";
            }
        }

        private void SaveImage(Rectangle face)
        {
            if (isEnable_SaveImage)
            {
                Image<Bgr, byte> image = Frame.Convert<Bgr, byte>();
                image.ROI = face;
                image.Resize(100, 100, Inter.Cubic).Save(Environment.CurrentDirectory + "\\Image\\" + ImageName + ".jpg");
                isEnable_SaveImage = false;
                trainedIamge();
            }
        }

        private void trainedIamge()
        {
            try
            {
                int num = 0;
                trainedFaces.Clear();
                PersonLabs.Clear();
                Names.Clear();
                string[] files = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Image", "*.jpg", SearchOption.AllDirectories);
                string[] array = files;
                foreach (string text in array)
                {
                    Image<Gray, byte> item = new Image<Gray, byte>(text);
                    trainedFaces.Add(item);
                    PersonLabs.Add(num);
                    Names.Add(text);
                    num++;
                }

                eigenFaceRecognizer = new EigenFaceRecognizer(num, distance);
                eigenFaceRecognizer.Train(trainedFaces.ToArray(), PersonLabs.ToArray());
            }
            catch
            {
            }
        }

        private Dictionary<string, int> personAppearances = new Dictionary<string, int>();
        private const int appearanceThreshold = 60;

        private int consecutiveAppearanceCount = 0;
        private string lastPersonName = "";
        int id;
        private void checkName(Image<Bgr, byte> resultImage, Rectangle face)
        {
            try
            {
                if (isTrained)
                {
                    Image<Gray, byte> image = resultImage.Convert<Gray, byte>().Resize(100, 100, Inter.Cubic);
                    CvInvoke.EqualizeHist(image, image);
                    FaceRecognizer.PredictionResult predictionResult = eigenFaceRecognizer.Predict(image);
                    if (predictionResult.Label != -1 && predictionResult.Distance < distance)
                    {
                        PictureBox_smallFrame.Image = trainedFaces[predictionResult.Label].Bitmap;
                        string name = Names[predictionResult.Label].Replace(Environment.CurrentDirectory + "\\Image\\", "").Replace(".jpg", "");
                        setPersonName = name;
                        CvInvoke.PutText(Frame, name, new Point(face.X - 2, face.Y - 2), FontFace.HersheyPlain, 1.0, new Bgr(Color.LimeGreen).MCvScalar);

                        // Kiểm tra nếu tên hiện tại giống với tên cuối cùng được nhận diện.
                        if (name == lastPersonName)
                        {
                            consecutiveAppearanceCount++;
                        }
                        else
                        {
                            lastPersonName = name;
                            consecutiveAppearanceCount = 1;
                        }

                        // Kiểm tra nếu tên đã xuất hiện liên tiếp 60 lần.
                        if (consecutiveAppearanceCount == 100)
                        {
                            //   MessageBox.Show(name + " đã xuất hiện liên tiếp " + consecutiveAppearanceCount + " lần.");
                            // Thêm mã để xử lý sau khi in ra tên.
                            SqlCommand sqlCommand = new SqlCommand("Select * from std where username = @userid");
                            sqlCommand.Parameters.Add("@userid", SqlDbType.NVarChar).Value = Login_Form.infoLogin.ToString().Trim();
                            DataTable dt = getdata(sqlCommand);
                            string idname = dt.Rows[0]["id"].ToString().Trim() + " " + dt.Rows[0]["fname"].ToString().Trim()+ dt.Rows[0]["lname"].ToString().Trim();
                            int tmp = AI_checkin.tmp;
                            if (name.Trim() == idname.Trim() && tmp == 0)
                            {
                                MessageBox.Show("Da nhan dien duoc" + idname);
                                isTrained = false;
                              
                                

                                // Kiểm tra xem có dữ liệu nhân viên không
                                if (dt.Rows.Count > 0)
                                {
                                    // Tạo ID ngẫu nhiên cho bản ghi check-in
                                    id = int.Parse(getid());

                                    // Lấy thời gian hiện tại
                                    DateTime checkintime = DateTime.Now;
                                    DateTime date = DateTime.Now.Date; // Lấy ngày hiện tại mà không có thời gian

                                    int salary = 0;
                                    string employee_id = dt.Rows[0]["id"].ToString().Trim();
                                    if (dt.Rows[0]["position"].ToString().Trim() == "Labourer")
                                    {
                                        salary = 320000 / 2;
                                    }
                                    else
                                    {
                                        salary = 480000 / 2;
                                    }

                                    // Chèn thông tin check-in vào cơ sở dữ liệu
                                    SqlCommand sql = new SqlCommand("Insert into timekeeping (id,employee_id,fname,lname,checkintime,date,status,salary) values (@id,@employee_id,@fname,@lname, @checkin,@date,@status,@salary)", mydb.getConnection);
                                    sql.Parameters.Add("@id", SqlDbType.Int).Value = id;
                                    sql.Parameters.Add("@checkin", SqlDbType.DateTime).Value = checkintime; // Sử dụng kiểu DateTime để lưu cả ngày và giờ
                                    sql.Parameters.Add("@employee_id", SqlDbType.NVarChar).Value = dt.Rows[0]["id"].ToString().Trim();
                                    sql.Parameters.Add("@fname", SqlDbType.NVarChar).Value = dt.Rows[0]["fname"].ToString().Trim();
                                    sql.Parameters.Add("@lname", SqlDbType.NVarChar).Value = dt.Rows[0]["lname"].ToString().Trim();
                                    sql.Parameters.Add("@date", SqlDbType.Date).Value = DateTime.Now;
                                    sql.Parameters.Add("@status", SqlDbType.NVarChar).Value = "No Check Out";
                                    sql.Parameters.Add("@salary", SqlDbType.Int).Value = salary;

                                    // Mở kết nối và thực thi câu lệnh SQL
                                    mydb.openConnection();
                                    if (dateCheckinExists(date, employee_id) == true)
                                    {
                                        MessageBox.Show("You checked in today.");
                                        mydb.closeConnection();
                                        return;
                                    }
                                    else if (sql.ExecuteNonQuery() > 0)
                                    {
                                        MessageBox.Show("Check-in suscessfull.");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Check-in did't success.");
                                    }
                                    mydb.closeConnection();
                                }
                                else
                                {
                                    MessageBox.Show("Don't Found Employee Infomation.");
                                }
                            }
                            else if (name.Trim() == idname.Trim() && tmp == 1)
                            {
                                
                                // Lấy dữ liệu từ bảng 'timekeeping'
                                SqlCommand sql = new SqlCommand("select * from timekeeping WHERE employee_id = @id AND date = @date ", mydb.getConnection);
                                sql.Parameters.Add("@id", SqlDbType.NVarChar).Value = dt.Rows[0]["id"].ToString().Trim();
                                sql.Parameters.Add("@date", SqlDbType.Date).Value = DateTime.Now.Date;
                                DataTable table = getdata(sql);

                                // Kiểm tra xem có dữ liệu không
                                DateTime checkintime;
                                if (DateTime.TryParse(table.Rows[0]["checkintime"].ToString(), out checkintime))
                                {
                                    MessageBox.Show(checkintime.ToString());
                                }
                                else
                                {
                                    MessageBox.Show("Checkintime Value did't valid or did't exist .");
                                }
                                TimeSpan duration = DateTime.Now - checkintime;
                                double hours = duration.TotalHours;
                                hours = Math.Round(hours, 2);
                                double salary = 0;
                                MessageBox.Show($"Số giờ là: {hours}");

                                double tienphat = 8 - hours;
                                /*if (dt.Rows[0]["position"].ToString().Trim() == "Labourer")
                                {
                                    salary = hours * 40000.0;
                                }
                                else
                                {
                                    salary = hours * 60000.0;
                                }*/
                                //double roundedNumber = Math.Round(hours, 2);
                                string status;

                                if (hours >= 7.5)
                                {
                                    status = "Complete";
                                    if (dt.Rows[0]["position"].ToString().Trim() == "Labourer")
                                    {
                                        salary = hours * 40000.0;
                                    }
                                    else
                                    {
                                        salary = 8 * 60000.0;
                                    }
                                }
                                else
                                {
                                    status = (8 - hours).ToString();
                                    if (dt.Rows[0]["position"].ToString().Trim() == "Labourer")
                                    {
                                        salary = hours * 30000.0 - tienphat * 20000;
                                    }
                                    else
                                    {
                                        salary = hours * 30000.0 - tienphat * 30000;
                                    }
                                }
                                //MessageBox.Show(id.ToString());

                                SqlCommand cmd = new SqlCommand("UPDATE timekeeping SET checkouttime = @time, status = @status, salary = @salary WHERE employee_id = @id AND date = @date", mydb.getConnection);
                                cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = table.Rows[0]["employee_id"].ToString().Trim();
                                cmd.Parameters.Add("@date", SqlDbType.Date).Value = DateTime.Now.Date;
                                cmd.Parameters.Add("@time", SqlDbType.DateTime).Value = DateTime.Now;
                                cmd.Parameters.Add("@status", SqlDbType.NVarChar).Value = status;
                                cmd.Parameters.Add("@salary", SqlDbType.Int).Value = salary;
                                mydb.openConnection();
                                if (dateCheckinExists(DateTime.Now, table.Rows[0]["employee_id"].ToString().Trim()))
                                {

                                    if (cmd.ExecuteNonQuery() == 1)
                                    {
                                        MessageBox.Show("Check out successful. Thank You");
                                        mydb.closeConnection();
                                        return;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Errorhhh");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Error");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Khong nhan dien duoc");
                                return;
                            }
                            isTrained = false;
                            
                        }
                    }
                    else
                    {
                        setPersonName = "Unknown";
                        CvInvoke.PutText(Frame, "Unknown", new Point(face.X - 2, face.Y - 2), FontFace.HersheyPlain, 1.0, new Bgr(Color.OrangeRed).MCvScalar);
                        // Đặt lại số lần xuất hiện liên tiếp vì không nhận diện được khuôn mặt.
                        consecutiveAppearanceCount = 0;
                        lastPersonName = "";
                    }
                    //camera.Stop();

                }
              
            }
            catch
            {
                // Xử lý ngoại lệ ở đây.
            }
            this.Close();
        }
        private bool dateCheckinExists(DateTime day, string id)
        {
            day = day.Date;
            SqlCommand cmd = new SqlCommand("Select * from timekeeping where date = @date and employee_id = @id", mydb.getConnection);
            cmd.Parameters.Add("@date", SqlDbType.Date).Value = day;
            cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                return true; // Course with the given name and ID exists
            }
            else
            {
                return false; // Course with the given name and ID does not exist
            }
        }
        string getid()
        {
            string numberString;
            do
            {
                numberString = "";
                Random random = new Random();
                for (int i = 0; i < 5; i++)
                {
                    numberString += random.Next(10).ToString();
                }

            }
            while (idIdExists(numberString));
            return numberString;
        }
        private bool idIdExists(string id)
        {
            int x = int.Parse(id);
            SqlCommand cmd = new SqlCommand("Select * from timekeeping where id = @id", mydb.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                return true; // Course with the given name and ID exists
            }
            else
            {
                return false; // Course with the given name and ID does not exist
            }
        }
        public DataTable getdata(SqlCommand cmd)
        {
            //mydb.openConnection();
            cmd.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            base.SuspendLayout();
            base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new System.Drawing.Size(800, 450);
            base.Name = "FaceRec";
            this.Text = "FaceRec";
            base.ResumeLayout(false);
        }
    }
}
#if false // Decompilation log
'23' items in cache
------------------
Resolve: 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
Found single assembly: 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
Load from: 'C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2\mscorlib.dll'
------------------
Resolve: 'System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
Found single assembly: 'System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
Load from: 'C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2\System.Windows.Forms.dll'
------------------
Resolve: 'Emgu.CV.World, Version=3.1.0.2282, Culture=neutral, PublicKeyToken=7281126722ab4438'
Found single assembly: 'Emgu.CV.World, Version=3.1.0.2282, Culture=neutral, PublicKeyToken=7281126722ab4438'
Load from: 'C:\Users\22110\source\repos\HotelManagementSystem\packages\EmguCV.3.1.0.1\lib\net30\Emgu.CV.World.dll'
------------------
Resolve: 'System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
Found single assembly: 'System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089'
Load from: 'C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2\System.dll'
------------------
Resolve: 'System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Found single assembly: 'System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a'
Load from: 'C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2\System.Drawing.dll'
#endif


