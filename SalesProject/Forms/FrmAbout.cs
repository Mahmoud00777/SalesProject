using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesProject.Forms
{
    public partial class FrmAbout : Form
    {
        bool sw;
        Point pos;
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void FrmAbout_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                sw = true;
                pos = e.Location;
            }
        }

        private void FrmAbout_MouseMove(object sender, MouseEventArgs e)
        {
            if (sw == true)
            {
                this.Location = new Point(this.Location.X + (e.X - pos.X), this.Location.Y + (e.Y - pos.Y));
            }
        }

        private void FrmAbout_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                sw = false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.facebook.com/%D8%B4%D8%B1%D9%83%D8%A9-%D8%A7%D9%84%D9%85%D8%A8%D8%B1%D9%85%D8%AC-%D8%A7%D9%84%D9%85%D8%AD%D8%AA%D8%B1%D9%81-1447998188843747/?ref=ts&fref=ts");
        }

        private void linkLabel3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                sw = true;
                pos = e.Location;
            }
        }

        private void linkLabel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (sw == true)
            {
                this.Location = new Point(this.Location.X + (e.X - pos.X), this.Location.Y + (e.Y - pos.Y));
            }
        }

        private void linkLabel3_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                sw = false;
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("www.facebook.com/Professional.Programmer.Co");
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            //this.Left = this.Left - 185;
            //this.Top = this.Top + 10;
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
