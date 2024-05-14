using FaceRecognition;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace HotelManagement
{
    public partial class AI_checkin : Form
    {
        public AI_checkin()
        {
            InitializeComponent();
        }
        public static int tmp;
        face face = new face();
        MYDB mydb= new MYDB();
        string employID = Login_Form.infoLogin.Trim();
        private void btn_Detect_Click(object sender, EventArgs e)
        {
            face.openCamera(pictureBox1, pictureBox2);
            //face.Save_IMAGE(textBox1.Text);
            //MessageBox.Show("Successful");
            face.isTrained = true;

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
        private void btn_Open_Click(object sender, EventArgs e)
        {

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {

        }
        private bool CanCheckIn(string shift, DateTime currentTime)
        {
            //MessageBox.Show(currentTime.ToString());
            //MessageBox.Show(currentTime.Hour.ToString());
            switch (shift.Trim())
            {
                case "Sang":
                    return currentTime.Hour >= 6 && currentTime.Hour < 14;
                case "Chieu":
                    return currentTime.Hour >= 14 && currentTime.Hour < 22;
                case "Toi":
                    // For the night shift, we need to account for the fact that it spans two days
                    if (currentTime.Hour >= 22 || currentTime.Hour <= 6)
                    {
                        // Nếu currentTime từ 0h đến 6h, kiểm tra ca tối của ngày hôm trước
                        return true;
                    }
                    return false;
                default:
                    return false; // Invalid shift name
            }
        }

      
        private void AI_checkin_Load(object sender, EventArgs e)
        {
            
            datetimeCheckOut.Value = DateTime.Now;
            SqlCommand cmd = new SqlCommand("Select * from std where username = @userid");
            cmd.Parameters.Add("@userid", SqlDbType.NVarChar).Value = employID;
            DataTable dt = getData(cmd);
            textBox1.Text = dt.Rows[0]["id"].ToString().Trim() + " " + dt.Rows[0]["fname"].ToString().Trim() + dt.Rows[0]["lname"].ToString().Trim();
            //MessageBox.Show(Login_Form.infoLogin);
            DateTime time = DateTime.Now;
           // bool x = CheckPreviousNightShift(DateTime.Now);
            if (dt.Rows[0]["position"].ToString().Trim() == "Labourer")
            {
                lb_welcome.Text = "Welcome HR:  " + dt.Rows[0]["position"].ToString().Trim() + " " + dt.Rows[0]["fname"].ToString().Trim() + " " + dt.Rows[0]["lname"].ToString().Trim();
                string ideployy = dt.Rows[0]["id"].ToString().Trim();
                DateTime dateTime = DateTime.Now;

                string dayOfWeekName = dateTime.ToString("dddd");

                SqlCommand sql = new SqlCommand($"SELECT [{dayOfWeekName}], [shift] FROM chia_ca", mydb.getConnection);
                DataTable data = getData(sql);
                DateTime currentTime = DateTime.Now;
                DateTime previousDay = currentTime.Date.AddDays(-1);
                string previousDayName = previousDay.ToString("dddd");
                bool hasShift = false; // Biến cờ để kiểm tra ca làm việc
                if ((currentTime.Hour > 22 && currentTime.Hour <=24 || currentTime.Hour >= 0 && currentTime.Hour <= 6))
                {
                    // Nếu có, kiểm tra ca tối của ngày hôm trước
                    SqlCommand sqlPreviousDay = new SqlCommand($"SELECT [{previousDayName}], [shift] FROM chia_ca WHERE [shift] = 'Toi'", mydb.getConnection);
                    DataTable dataPreviousDay = getData(sqlPreviousDay);
                    
                    foreach (DataRow row in dataPreviousDay.Rows)
                    {
                        string[] employeeIds = row[previousDayName].ToString().Trim().Split(',');
                        List<string> employeeIdList = new List<string>(employeeIds);
                            
                        if (employeeIdList.Contains(ideployy))
                        {
                            MessageBox.Show($"Employee ID {ideployy} scheduled to work the night shift yesterday.");
                            btt_checkintime.Visible = true;
                            btt_checkouttime.Visible = true;
                            hasShift = true;
                            // Thoát khỏi vòng lặp nếu tìm thấy ID khớp và ca làm việc phù hợp
                            return;
                        }
                        else
                        {
                            MessageBox.Show("You don't have a shift yesterday.");
                            btt_checkintime.Visible = false;
                            btt_checkouttime.Visible = false;
                        }
                    } 
                }
            
                foreach (DataRow row in data.Rows)
                {
                    string[] employeeIds = row[dayOfWeekName].ToString().Trim().Split(',');
                    List<string> employeeIdList = new List<string>(employeeIds);

                    if (employeeIdList.Contains(ideployy))
                    {
                        //MessageBox.Show("Hello");
                        MessageBox.Show(ideployy);

                        string shift = row["shift"].ToString().Trim();
                        //MessageBox.Show(shift);

                        if (CanCheckIn(shift, DateTime.Now))
                        {
                            MessageBox.Show($"Employee ID {ideployy} scheduled to work the {shift} shift today.");
                            btt_checkintime.Visible = true;
                            btt_checkouttime.Visible = true;
                            hasShift = true;
                            break; // Thoát khỏi vòng lặp nếu tìm thấy ID khớp và ca làm việc phù hợp
                        }
                        else
                        {
                            MessageBox.Show($"The employee {ideployy} schedule to work the shift{shift}. Please checkin later");
                            btt_checkintime.Visible = false;
                            btt_checkouttime.Visible = false;
                            hasShift = true;
                            break;
                        }
                    }
                }

                if (!hasShift) // Nếu sau khi duyệt hết mà không có ca làm
                {
                    MessageBox.Show("You don't have a shift today.");
                    btt_checkintime.Visible = false;
                    btt_checkouttime.Visible = false;
                }
            }
            else
            {
                lb_welcome.Text = "Welcome HR:  " + dt.Rows[0]["position"].ToString().Trim() + " " + dt.Rows[0]["fname"].ToString().Trim() + " " + dt.Rows[0]["lname"].ToString().Trim();
                string ideployy = dt.Rows[0]["id"].ToString().Trim();
                DateTime dateTime = DateTime.Now;

                string dayOfWeekName = dateTime.ToString("dddd");

                SqlCommand sql = new SqlCommand($"SELECT [{dayOfWeekName}], [shift] FROM chia_ca_ManagerRecept", mydb.getConnection);
                DataTable data = getData(sql);

                bool hasShift = false; // Biến cờ để kiểm tra ca làm việc

                foreach (DataRow row in data.Rows)
                {
                    string[] employeeIds = row[dayOfWeekName].ToString().Trim().Split(',');
                    List<string> employeeIdList = new List<string>(employeeIds);

                    if (employeeIdList.Contains(ideployy))
                    {
                        //MessageBox.Show("Hello");
                        MessageBox.Show(ideployy);

                        string shift = row["shift"].ToString().Trim();
                        //MessageBox.Show(shift);

                        if (CanCheckIn(shift, DateTime.Now))
                        {
                            MessageBox.Show($"Employee ID {ideployy} scheduled to work the {shift} shift today.");
                            btt_checkintime.Visible = true;
                            btt_checkouttime.Visible = true;
                            hasShift = true;
                            break; // Thoát khỏi vòng lặp nếu tìm thấy ID khớp và ca làm việc phù hợp
                        }
                        else
                        {
                            MessageBox.Show($"The employee {ideployy} schedule to work the shift {shift}. Please checkin later");
                            btt_checkintime.Visible = false;
                            btt_checkouttime.Visible = false;
                            hasShift = true;
                            break;
                        }
                    }
                }

                if (!hasShift) // Nếu sau khi duyệt hết mà không có ca làm
                {
                    MessageBox.Show("You don't have a shift today..");
                    btt_checkintime.Visible = false;
                    btt_checkouttime.Visible = false;
                }
            }
        }

        private void btt_checkintime_Click(object sender, EventArgs e)
        {
            tmp = 0;
            face.openCamera(pictureBox1, pictureBox2);
            //face.Save_IMAGE(textBox1.Text);
            //MessageBox.Show("Successful");
            face.isTrained = true;
        }

        private void btt_checkouttime_Click(object sender, EventArgs e)
        {
            tmp = 1;
            face.openCamera(pictureBox1, pictureBox2);
            //face.Save_IMAGE(textBox1.Text);
            //MessageBox.Show("Successful");
            face.isTrained = true;
        }
    }
}
