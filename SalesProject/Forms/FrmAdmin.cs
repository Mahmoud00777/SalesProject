using SalesProject.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesProject.Forms
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }
        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            txtAdmin.Select();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtAdmin.Text == Settings.Default.AdminName & txtPassword.Text == Settings.Default.AdminPassword)
            {
                this.Hide();
                FrmResetCon frmResetCon = new FrmResetCon();
                frmResetCon.ShowDialog();
            }
            else
            {
                MessageBox.Show("بيانات الدخول خاطئة ", "خطأ دخول", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }


        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            txtAdmin.PasswordChar = '\0';
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            txtAdmin.PasswordChar = Convert.ToChar('*');
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = '\0';
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = Convert.ToChar('*');
        }
    }
}
