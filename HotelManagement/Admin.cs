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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        MYDB mydb=new MYDB();
        private void datagridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            


        }
        void refresh()
        {

        }
        void refesh()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM login_queue");
            datagridview.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            datagridview.RowTemplate.Height = 80;
            datagridview.DataSource = getdata(command);

        }
        private bool deleteStudent(string user)
        {
            SqlCommand command = new SqlCommand("DELETE FROM login_queue WHERE username = @user", mydb.getConnection);
            command.Parameters.Add("@user", SqlDbType.NChar).Value = user;
            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            { mydb.closeConnection(); return true; }
            else
            {
                mydb.closeConnection();
                return false;
            }

        }
        public DataTable getdata(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        private void btt_create_Click(object sender, EventArgs e)
        {
            if (datagridview.SelectedRows.Count > 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow selectedRow = datagridview.SelectedRows[0];

                // Tạo SqlCommand
                using (SqlCommand cmd = new SqlCommand("INSERT INTO std (id, fname, lname, position, gender, bdate, username, password, phone, address, picture, email) VALUES (@id, @fname, @lname, @position, @gender, @bdate, @username, @password, @phone, @address, @picture, @email)", mydb.getConnection))
                {
                    // Thêm các tham số
                    cmd.Parameters.Add("@id", SqlDbType.NChar).Value = selectedRow.Cells[0].Value.ToString();
                    cmd.Parameters.Add("@fname", SqlDbType.NChar).Value = selectedRow.Cells[1].Value.ToString();
                    cmd.Parameters.Add("@lname", SqlDbType.NChar).Value = selectedRow.Cells[2].Value.ToString();
                    cmd.Parameters.Add("@position", SqlDbType.Char).Value = selectedRow.Cells[3].Value.ToString();
                    cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = selectedRow.Cells[4].Value.ToString();
                    cmd.Parameters.Add("@bdate", SqlDbType.Date).Value = Convert.ToDateTime(selectedRow.Cells[5].Value.ToString());
                    cmd.Parameters.Add("@username", SqlDbType.Char).Value = selectedRow.Cells[6].Value.ToString();
                    cmd.Parameters.Add("@password", SqlDbType.Char).Value = selectedRow.Cells[7].Value.ToString();
                    cmd.Parameters.Add("@phone", SqlDbType.NChar).Value = selectedRow.Cells[8].Value.ToString();
                    cmd.Parameters.Add("@address", SqlDbType.NChar).Value = selectedRow.Cells[9].Value.ToString();
                    cmd.Parameters.Add("@email", SqlDbType.Char).Value = selectedRow.Cells[11].Value.ToString();

                    byte[] pic;
                    if (selectedRow.Cells[10].Value != DBNull.Value)
                    {
                        pic = (byte[])selectedRow.Cells[10].Value;
                        cmd.Parameters.Add("@picture", SqlDbType.Image).Value = pic;
                    }
                    else
                    {
                        // Nếu giá trị hình ảnh là null, xóa hình ảnh hiển thị trên PictureBox
                        MessageBox.Show("Picture is Null");
                        return; // Exit the method as there's no need to proceed further
                    }

                    // Thực thi câu lệnh
                    try
                    {
                        mydb.openConnection();
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Data Inserted");
                            deleteStudent(selectedRow.Cells[6].Value.ToString());
                            refesh();
                        }
                        else
                        {
                            MessageBox.Show("Data Not Inserted");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        mydb.closeConnection();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row in the DataGridView.");
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (datagridview.SelectedRows.Count > 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow selectedRow = datagridview.SelectedRows[0];
                deleteStudent(selectedRow.Cells[6].Value.ToString());
                refesh();
            }
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from login_queue");
            datagridview.DataSource = getdata(cmd);
        }
    }
}
