using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FaceRecognition;

namespace HotelManagement
{
    public partial class FaceRecognition : Form
    {

        FaceRec faceRec = new FaceRec();
        MYDB mydb = new MYDB();
        account account = new account();
        public FaceRecognition(string employID)
        {
            InitializeComponent();
            textBox1.Text = employID;
        }
        public DataTable getData(SqlCommand cmd)
        {
            cmd.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
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
        int id;
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
        private void button1_Click(object sender, EventArgs e)
        {
            faceRec.openCamera(pictureBox1, pictureBox2);
        }
       

        private void btn_Detect_Click(object sender, EventArgs e)
        {
            faceRec.Save_IMAGE(textBox1.Text);
            MessageBox.Show("Successful");
            faceRec.isTrained = true;
        }


        public static PictureBox pic;
        private void btn_Save_Click(object sender, EventArgs e)
        {
            string fileName = textBox1.Text + ".jpg";
            string imagePath = Path.Combine(".", "Image", fileName);

            // Load the image into a PictureBox
            using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                //pic.Image = Image.FromStream(fs);
                OnImageCaptured(Image.FromStream(fs));
            }

            // Check if the PictureBox has an image loaded
            
            
            this.Close();
            // Kiểm tra xem có dữ liệu nhân viên không
            // Your code to check for employee data goes here
        }
        public delegate void ImageCapturedHandler(Image image);
        public event ImageCapturedHandler ImageCaptured;

        // Gọi event này khi ảnh khuôn mặt đã được nhận diện và cần cập nhật vào form gốc
        protected void OnImageCaptured(Image image)
        {
            ImageCaptured?.Invoke(image);
        }



        private void FaceRecognition_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
