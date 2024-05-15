using Emgu.Util.TypeEnum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string pos = Login_Form.position_id.Trim();
        private Form currentFormChild;
        private void OpenChildForm1(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            //childForm.Dock = DockStyle.Fill;
            panel_above1.Controls.Add(childForm);
            panel_above1.Tag = childForm;
            childForm.Dock = DockStyle.Fill;
            childForm.BringToFront();
            childForm.Show();
            
        }

        private void btt_forLaubour_Click(object sender, EventArgs e)
        {
            OpenChildForm1(new assigmentForlaubor());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm1(new AssigmentForQLvaNV());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            btt_forLaubour.Enabled = true;
            btt_chamcong.Enabled = true;
            if (pos == "Labourer")
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                

            }
            else if (pos == "Manager")
            {
                
            }
            else if (pos == "Receptionist")
            {
      
            }
            else
            {
                btt_chamcong.Enabled = false;
            }
        }

        private void btt_chamcong_Click(object sender, EventArgs e)
        {
            OpenChildForm1(new AI_checkin());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm1(new DataTimeKeeping());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm1(new RevenueReport());
        }
    }
}
