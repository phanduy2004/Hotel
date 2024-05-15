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

namespace HotelManagement
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private Form currentFormChild;
        MYDB mydb = new MYDB();
        string employID = Login_Form.infoLogin.Trim();
        string pos = Login_Form.position_id.Trim();
        private void OpenChildForm(Form childForm)
        {
            if(currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_above.Controls.Add(childForm);
            panel_above.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }
        private void button2_Click(object sender, EventArgs e) => OpenChildForm(new AddRoomForm() );
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public DataTable getData(SqlCommand cmd)
        {
            cmd.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from std where username = @userid");
            cmd.Parameters.Add("@userid", SqlDbType.NVarChar).Value = employID;
            DataTable dt = getData(cmd);
            label3.Text = dt.Rows[0]["fname"].ToString().Trim() + " " + dt.Rows[0]["lname"].ToString().Trim();
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            if (pos == "Labourer")
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = true;
                button8.Enabled = false;
                button9.Enabled = false;
                button10.Enabled = false;

            }
            else if (pos == "Manager")
            {
                button6.Enabled = false;
            }
            else if(pos == "Receptionist")
            {
                button6.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
                button10.Enabled = true;
            }
                
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AddEmployee());
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_above_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new bookingRoom());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new CheckIn());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Customer());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Discount());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenChildForm(new AddSevice());
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

            // Đây là mã giả định bạn đã có một form đăng nhập để quay trở lại
            this.Hide(); // Ẩn form hiện tại
            Login_Form loginForm = new Login_Form();
            loginForm.Show(); // Hiển thị form đăng nhập
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OpenChildForm(new StoreManagent());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new AssigmentForQLvaNV());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form1());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Admin());
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new info_nhanvien());
        }
    }
}
