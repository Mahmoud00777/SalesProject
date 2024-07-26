using SalesProject.Classes;
using SalesProject.Properties;
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

namespace SalesProject.Forms
{
    public partial class FrmResetCon : Form
    {
        public FrmResetCon()
        {
            InitializeComponent();
        }

        private void FrmResetCon_Load(object sender, EventArgs e)
        {
            txtServer.Text = Settings.Default.Server;
            txtDatabase.Text = Settings.Default.Database;
            txtSQLUser.Text = Settings.Default.SQLLogin;
            txtSQLPassword.Text = Settings.Default.SQLPassword;
        }

        private void btnApplay_Click(object sender, EventArgs e)
        {
            Settings.Default.Server = txtServer.Text;
            Settings.Default.Database = txtDatabase.Text;
            Settings.Default.SQLLogin = txtSQLUser.Text;
            Settings.Default.SQLPassword = txtSQLPassword.Text;
            Settings.Default.Save();
            Environment.Exit(0);
        }

    }
}
