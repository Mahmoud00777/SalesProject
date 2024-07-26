using Microsoft.Win32;
using SalesProject.Classes;
using SalesProject.Properties;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesProject.Forms
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
        }
        ResizeControls r = new ResizeControls();
        bool testCon = true;

        //SqlConnection ConTest;
        //var a = Directory.GetLogicalDrives();
        //cmbDrives.DataSource = a;

        private void FrmSettings_HandleCreated(object sender, EventArgs e)
        {
            r.Container = this;
        }
        private void FrmSettings_Resize(object sender, EventArgs e)
        {
            r.ResizeControl();
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            setFormSize();
        }
        void setFormSize()
        {
            this.Size = Settings.Default.FrmMainSize - new Size(0, 55);
            this.Location = Settings.Default.FrmMainLocation;
            this.Top += 30;
        }
    }
}
