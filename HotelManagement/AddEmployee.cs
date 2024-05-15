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

namespace HotelManagement
{
    public partial class AddEmployee : Form
    {
        public AddEmployee()
        {
            InitializeComponent();
            cbb_pos.Items.Add("Receptionist");
            cbb_pos.Items.Add("Labourer");
            cbb_pos.Items.Add("Manager");
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        Employee employy = new Employee();
        private void AddEmployee_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyKhachSanDataSet8.std' table. You can move, or remove it, as needed.
            //this.stdTableAdapter.Fill(this.quanLyKhachSanDataSet8.std);
           
            refresh();
            
        }

        private void btt_Add_Click(object sender, EventArgs e)
        {
           
        }
        public bool ContainsDigit(string input)
        {
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }
        bool verif()
        {
            if ((txt_Fname.Text.Trim() == "")
                        || (txt_Lname.Text.Trim() == "")
                        || (txt_Address.Text.Trim() == "")
                        || (txt_Phone.Text.Trim() == "")
                        || (pic_Employee.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private void btt_UploadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                pic_Employee.Image = Image.FromFile(opf.FileName);
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        void refresh()
        {
            SqlCommand cmd = new SqlCommand("Select * from std");
            employeeTable.DataSource = employy.getEmployee(cmd);
        }
        private void updateButton_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            string id = txt_EmployeeID.Text;
            string fname = txt_Fname.Text;
            string lname = txt_Lname.Text;
            string pos = cbb_pos.Text;
            DateTime bdate = DateTimePicker1.Value;
            string phone = txt_Phone.Text;
            string adrs = txt_Address.Text;
            string gender = RadioButtonFemale.Checked ? "Female" : "Male";

            MemoryStream pic = new MemoryStream();
            int born_year = bdate.Year;
            int this_year = DateTime.Now.Year;

            // Check if age is between 18 and 100 years
            if ((this_year - born_year) <18 || (this_year - born_year) > 100)
            {
                MessageBox.Show("The Employee's Age Must Be Between 18 and 100 Years", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Check if ID is a number
            // Check if phone is a number
            else if (!int.TryParse(phone, out _))
            {
                MessageBox.Show("The Phone Number Must Be Numeric", "Phone Number Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Check if names contain digits
            else if (ContainsDigit(fname) || ContainsDigit(lname))
            {
                MessageBox.Show("The Name Must Not Contain Numbers", "Name Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Additional verification if needed
            else if (verif())
            {
                pic_Employee.Image.Save(pic, pic_Employee.Image.RawFormat);
                // Use TryParse for safer conversion
                if (employee.updateEmployee(id, fname, lname, pos, gender, bdate, phone, adrs, pic))
                {
                    MessageBox.Show("Employee Updated Successfully", "Update Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refresh();
                }
                else
                {
                    MessageBox.Show("Error Updating Employee", "Update Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Update Employee", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // Helper method to check if a string contains any digit
       


        private void addButton_Click(object sender, EventArgs e)
        {
            
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            txt_EmployeeID.Text = "";
            txt_Fname.Text = "";
            txt_Lname.Text = "";
            //label_course.Text = DataGridView2.CurrentRow.Cells[9].Value.ToString();
            DateTimePicker1.Value = DateTime.Now;
            RadioButtonFemale.Checked = false;
            RadioButtonMale.Checked = false;
            txt_Phone.Text = "";
            txt_Address.Text = "";
            //txt_Email.Text = DemployeeTable2.CurrentRow.Cells[8].Value.ToString();
            pic_Employee.Image = null;
        }

        private void employeeTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_EmployeeID.Text = employeeTable.CurrentRow.Cells[0].Value.ToString();
            txt_Fname.Text = employeeTable.CurrentRow.Cells[1].Value.ToString();
            txt_Lname.Text = employeeTable.CurrentRow.Cells[2].Value.ToString();

            //MessageBox.Show(employeeTable.CurrentRow.Cells[3].Value.ToString());
            cbb_pos.Text = employeeTable.CurrentRow.Cells[3].Value.ToString().Trim();
            //label_course.Text = DataGridView2.CurrentRow.Cells[9].Value.ToString();
            DateTime dateValue;
            if (DateTime.TryParse(employeeTable.CurrentRow.Cells[5].Value.ToString(), out dateValue))
            {
                DateTimePicker1.Value = dateValue;
            }
            else
            {
                // Xử lý nếu giá trị không hợp lệ
                // Ví dụ: Hiển thị một giá trị mặc định hoặc báo lỗi
                DateTimePicker1.Value = DateTime.Now; // Giá trị mặc định
            }

            if (employeeTable.CurrentRow.Cells[4].Value.ToString().Trim() == "Female")
            {
                RadioButtonFemale.Checked = true;
                RadioButtonMale.Checked = false;
            }
            else
            {
                RadioButtonMale.Checked = true;
                RadioButtonFemale.Checked = false;
            }

            txt_Phone.Text = employeeTable.CurrentRow.Cells[6].Value.ToString();
            txt_Address.Text = employeeTable.CurrentRow.Cells[7].Value.ToString();
            txt_email.Text = employeeTable.CurrentRow.Cells[9].Value.ToString();

            byte[] pic;
            if (employeeTable.CurrentRow.Cells[7].Value != DBNull.Value)
            {
                try
                {
                    if (employeeTable.CurrentRow.Cells[8].Value != DBNull.Value)
                    {
                        pic = (byte[])employeeTable.CurrentRow.Cells[8].Value;
                        MemoryStream picture = new MemoryStream(pic);
                        pic_Employee.Image = Image.FromStream(picture);
                    }
                    else
                    {
                        pic_Employee.Image = null;
                    }
                }
                catch (InvalidCastException)
                {
                    MessageBox.Show("The data in the cell cannot be converted to a byte array.");
                    pic_Employee.Image = null;
                }
            }
            else
            {
                // Nếu giá trị hình ảnh là null, xóa hình ảnh hiển thị trên PictureBox
                pic_Employee.Image = null;
            }
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            string numberString = "";
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                numberString += random.Next(10).ToString();
            }
            txt_EmployeeID.Text = numberString;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if(txt_EmployeeID ==  null)
            {
                MessageBox.Show("No data");
                return;
            }
            else
            {
                int id = Convert.ToInt32(txt_EmployeeID.Text);
                employy.deleteEmployee(id);
                MessageBox.Show("deleted succesfull");
                refresh();
            }
            
        }

        private void employeeTable_Click(object sender, EventArgs e)
        {
            txt_EmployeeID.Text = employeeTable.CurrentRow.Cells[0].Value.ToString();
            txt_Fname.Text = employeeTable.CurrentRow.Cells[1].Value.ToString();
            txt_Lname.Text = employeeTable.CurrentRow.Cells[2].Value.ToString();

            //MessageBox.Show(employeeTable.CurrentRow.Cells[3].Value.ToString());
            cbb_pos.Text = employeeTable.CurrentRow.Cells[3].Value.ToString().Trim();
            //label_course.Text = DataGridView2.CurrentRow.Cells[9].Value.ToString();
            DateTime dateValue;
            if (DateTime.TryParse(employeeTable.CurrentRow.Cells[5].Value.ToString(), out dateValue))
            {
                DateTimePicker1.Value = dateValue;
            }
            else
            {
                // Xử lý nếu giá trị không hợp lệ
                // Ví dụ: Hiển thị một giá trị mặc định hoặc báo lỗi
                DateTimePicker1.Value = DateTime.Now; // Giá trị mặc định
            }

            if (employeeTable.CurrentRow.Cells[4].Value.ToString().Trim() == "Female")
            {
                RadioButtonFemale.Checked = true;
                RadioButtonMale.Checked = false;
            }
            else
            {
                RadioButtonMale.Checked = true;
                RadioButtonFemale.Checked = false;
            }

            txt_Phone.Text = employeeTable.CurrentRow.Cells[6].Value.ToString();
            txt_Address.Text = employeeTable.CurrentRow.Cells[7].Value.ToString();
            txt_email.Text = employeeTable.CurrentRow.Cells[9].Value.ToString();

            byte[] pic;
            if (employeeTable.CurrentRow.Cells[7].Value != DBNull.Value)
            {
                try
                {
                    if (employeeTable.CurrentRow.Cells[8].Value != DBNull.Value)
                    {
                        pic = (byte[])employeeTable.CurrentRow.Cells[8].Value;
                        MemoryStream picture = new MemoryStream(pic);
                        pic_Employee.Image = Image.FromStream(picture);
                    }
                    else
                    {
                        pic_Employee.Image = null;
                    }
                }
                catch (InvalidCastException)
                {
                    MessageBox.Show("The data in the cell cannot be converted to a byte array.");
                    pic_Employee.Image = null;
                }
            }
            else
            {
                // Nếu giá trị hình ảnh là null, xóa hình ảnh hiển thị trên PictureBox
                pic_Employee.Image = null;
            }
        }
    }
}
