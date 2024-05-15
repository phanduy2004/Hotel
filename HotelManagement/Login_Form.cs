﻿using Guna.UI2.WinForms;
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
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }
        public static string infoLogin;
        public static string position_id;

        private void pictureBoxMinimize_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBoxMinimize, "Minimize");
        }
        private void pictureBoxClose_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBoxClose, "Close");
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBoxMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBoxShow_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBoxShow, "Show Password");
        }

        private void pictureBoxHide_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBoxHide, "Hide Password");
        }

        private void pictureBoxShow_Click(object sender, EventArgs e)
        {
            pictureBoxShow.Hide();
            Txt_Password.UseSystemPasswordChar = false;
            pictureBoxHide.Show();
        }

        private void pictureBoxHide_Click(object sender, EventArgs e)
        {
            pictureBoxHide.Hide();
            Txt_Password.UseSystemPasswordChar = true;
            pictureBoxShow.Show();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            MYDB db = new MYDB();
   
            //MessageBox.Show(s);
            SqlDataAdapter adapter = new SqlDataAdapter();

            DataTable table = new DataTable();

            SqlCommand command = new SqlCommand("SELECT * FROM std WHERE username = @User AND password = @Pass", db.getConnection);

            command.Parameters.Add("@User", SqlDbType.VarChar).Value = txt_Username.Text;
            command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = Txt_Password.Text;
            adapter.SelectCommand = command;

            adapter.Fill(table);

            if ((table.Rows.Count > 0))
            {
                position_id = table.Rows[0]["position"].ToString();
                infoLogin = txt_Username.Text;
                //MessageBox.Show("Ok, next time will be go to Main Menu of App");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Invalid Username Or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LOGIN_Enter(object sender, EventArgs e)
        {
            //Txt_Password.UseSystemPasswordChar = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void label_Forgetpass_Click(object sender, EventArgs e)
        {
            ForgotAccount account = new ForgotAccount();
            account.Show(this);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            CreateAccount createAccount = new CreateAccount();
            createAccount.Show(this);
        }
    }
}
