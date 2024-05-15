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
    public partial class info_nhanvien : Form
    {
        public info_nhanvien()
        {
            InitializeComponent();
        }
        MYDB mydb=new MYDB();
        public DataTable getData(SqlCommand cmd)
        {
            cmd.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
        private void info_nhanvien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyKhachSanDataSet20.timekeeping' table. You can move, or remove it, as needed.
           // this.timekeepingTableAdapter.Fill(this.quanLyKhachSanDataSet20.timekeeping);
            SqlCommand sqlCommand = new SqlCommand("select * from std where username = @id");
            sqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = Login_Form.infoLogin;
            DataTable dt = getData(sqlCommand);
            lb_id.Text =        "Employee's ID:  "+ dt.Rows[0]["id"].ToString();
            lb_name.Text =      "Name:           " + dt.Rows[0]["fname"].ToString().Trim() + " " + dt.Rows[0]["lname"].ToString().Trim();
            lb_phone.Text =     "Phone:          " + dt.Rows[0]["phone"].ToString();
            lb_address.Text =   "Address:        " + dt.Rows[0]["address"].ToString();
            lb_sex.Text =       "Sex:            " + dt.Rows[0]["gender"].ToString();
            lb_email.Text =     "Email:          " + dt.Rows[0]["email"].ToString();
            lb_bdate.Text =     "BirthDate:      " + DateTime.Parse(dt.Rows[0]["bdate"].ToString()).ToString("dd/MM/yyyy");
            lb_pos.Text =       "Position:       " + dt.Rows[0]["position"].ToString();
            SqlCommand cmd = new SqlCommand("select * from timekeeping where employee_id = @id");
            cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = dt.Rows[0]["id"].ToString();
            guestTable.DataSource = getData(cmd);
        }
    }
}
