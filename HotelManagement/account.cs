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
using static OpenTK.Graphics.OpenGL.GL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HotelManagement
{
    public partial class account : Form
    {
        public account()
        {
            InitializeComponent();
        }
       MYDB db = new MYDB();
        private bool CheckID(int usn)
        {
           
            db.openConnection();
            SqlCommand cmd = new SqlCommand("Select * from std where id= @id", db.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = usn;
            var result = cmd.ExecuteReader();
            if (result.HasRows)
            {
                db.closeConnection();
                return false;
            }
            db.closeConnection();
            return true;
        }
        private bool CheckUserExist(string usn)
        {
           
            db.openConnection();
            SqlCommand cmd = new SqlCommand("Select * from std where username = @username", db.getConnection);
            cmd.Parameters.Add("@username", SqlDbType.NChar).Value = usn;
            var result = cmd.ExecuteReader();
            if (result.HasRows)
            {
                db.closeConnection();
                return false;
            }
            db.closeConnection();
            return true;
        }

        private bool checkInfor()
        {
            if (txt_id.Text.Trim() == "" || txt_fname.Text.Trim() == "" || txt_lname.Text.Trim() == "")
            {
                return false;
            }
            return true;
        }

        private void btt_create_Click(object sender, EventArgs e)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (Bitmap tempImage = new Bitmap(pictureBox1.Image))
                {
                    tempImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Hoặc định dạng khác tùy thuộc vào nhu cầu
                }
                byte[] imageBytes = ms.ToArray();
                // Sử dụng imageBytes cho việc lưu trữ hoặc xử lý tiếp theo

                DateTime bdate = guna2DateTimePicker1.Value.Date;
                string gender = "Male";
                if (System.Text.RegularExpressions.Regex.IsMatch(txt_fname.Text, @"\d") || System.Text.RegularExpressions.Regex.IsMatch(txt_lname.Text, @"\d"))
                {
                    MessageBox.Show("Name must not contain numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate the phone - it should not contain letters
                if (System.Text.RegularExpressions.Regex.IsMatch(txt_phone.Text, @"[a-zA-Z]"))
                {
                    MessageBox.Show("Phone must not contain letters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate the birth date - the user must be at least 18 years old
                
                DateTime today = DateTime.Today;
                int age = today.Year - bdate.Year;
                if (bdate > today.AddYears(-age)) age--;

                if (age < 18)
                {
                    MessageBox.Show("You must be at least 18 years old.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (RadioButtonFemale.Checked)
                {
                    gender = "Female";
                }
                if(imageBytes == null)
                {
                    MessageBox.Show("You must add picture.", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                SqlCommand cmd = new SqlCommand("UPDATE login_queue SET id = @id, fname = @fname, lname = @lname, bdate = @bdate,gender = @gender, phone = @phone, address = @address, picture = @picture WHERE username = @username", db.getConnection);
                cmd.Parameters.Add("@id", SqlDbType.NChar).Value = txt_id.Text;
                cmd.Parameters.Add("@fname", SqlDbType.NChar).Value = txt_fname.Text;
                cmd.Parameters.Add("@lname", SqlDbType.NChar).Value = txt_lname.Text;
                cmd.Parameters.Add("@phone", SqlDbType.NChar).Value = txt_phone.Text;
                cmd.Parameters.Add("@address", SqlDbType.NChar).Value = txt_address.Text;
                cmd.Parameters.Add("@bdate", SqlDbType.Date).Value = bdate;
                cmd.Parameters.Add("@picture", SqlDbType.Image).Value = imageBytes;
                cmd.Parameters.Add("@username", SqlDbType.NChar).Value = CreateAccount.username;
                cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = gender;
                if (checkInfor())
                {
                    db.openConnection();

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Account successfully updated. Please wait for Admin approval.", "Update Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Clear the form fields
                    }
                    else
                    {
                        MessageBox.Show("Update error", "Update Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    db.closeConnection();
                }
                else
                {
                    MessageBox.Show("Please do not leave information blank", "Update Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public void UpdatePictureBox(Image image)
        {
            pictureBox1.Image = image;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FaceRecognition faceRecognition = new FaceRecognition(txt_id.Text.Trim()+" "+ txt_fname.Text.Trim() +txt_lname.Text.Trim());
            faceRecognition.ImageCaptured += UpdatePictureBox;
            faceRecognition.Show();
        }
        MYDB mydb = new MYDB();
        public DataTable getdata(SqlCommand cmd)
        {
            //mydb.openConnection();
            cmd.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }
        private void account_Load(object sender, EventArgs e)
        {
            
        }

        private void txt_id_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            string numberString;
            string pos = CreateAccount.pos;
            if(pos.Trim() == "Manager")
            {
                numberString = "QL";
            }
            else if(pos.Trim() == "Labourer")
            {
                numberString = "LC";
            }
            else if (pos.Trim() == "Receptionist")
            {

                numberString = "LT";
            }
            else if ((pos.Trim() == "Admin"))
            {
                numberString = "AD";

            }
            else
            {
                numberString = "Guest";
            }
            Random random = new Random();
            for (int i = 0; i < 3; i++)
            {
                numberString += random.Next(10).ToString();
            }
            txt_id.Text = numberString;
        }
    }

}
