using SalesProject.Classes;
using SalesProject.Properties;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace SalesProject.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }


        int conMonitorCount = 0;
        string title = "المؤهل المهني لإعداد وتأهيل مبرمج محترف - منظومة إدارة فواتير المبيعات";

        // ------------------Keyboard------------
        [DllImport("kernel32")] static extern bool Wow64DisableWow64FsRedirection(ref long oldvalue);
        [DllImport("kernel32")] static extern bool Wow64EnableWow64FsRedirection(ref long oldvalue);
        string osk = @"C:\Windows\System32\osk.exe"; Process pOSK = null; bool swKeyboard;
        // --------------------------------------

        private void tsmKeyboard_Click(object sender, EventArgs e)
        {
            if (swKeyboard == false)
            {
                swKeyboard = true;
                // An instance is running => Dan wordt pOSK het bestaande proces
                foreach (Process pkiller in Process.GetProcesses())
                    if (string.Compare(pkiller.ProcessName, "osk", true) == 0)
                        pOSK = pkiller;

                // If no instance of OSK is running than create one depending on 32/64 bit
                foreach (Process pkiller in Process.GetProcesses())
                {
                    if (!(string.Compare(pkiller.ProcessName, "osk", true) == 0) & pOSK is null)
                    {

                        long old = new long();
                        if (Environment.Is64BitOperatingSystem)
                        {
                            // 64 Bit
                            if (Wow64DisableWow64FsRedirection(ref old))
                            {
                                pOSK = Process.Start(osk);
                                Wow64EnableWow64FsRedirection(ref old);
                            }
                        }
                        else
                        {
                            // 32 Bit
                            pOSK = Process.Start(osk);
                        }
                        break;
                    }
                }
            }
            else
            {
                swKeyboard = false;
                foreach (Process pkiller in Process.GetProcesses())
                    if (string.Compare(pkiller.ProcessName, "osk", true) == 0 & !(pOSK is null))
                    {

                        // Terminate process
                        pOSK.Kill();
                        break;
                    }

                // Wait untill proces is really terminated
                for (int intStap = 1; intStap <= 10; intStap++)
                    foreach (Process pkiller in Process.GetProcesses())
                        if (string.Compare(pkiller.ProcessName, "osk", true) == 0)
                            Thread.Sleep(1000);
                        else
                        {
                            pOSK = null;
                            break;
                        }
            }
        }
        public void FrmMain_Load(object sender, EventArgs e)
        {
            setFormSize();
            tslDateTime.Text = DateTime.Now.ToString();
            tslUser.Text = VariablesClass.userName + " - " + VariablesClass.userJob;
        }
        void setFormSize()
        {
            if (Settings.Default.FrmMainWindowState == (int)FormWindowState.Maximized)
                this.WindowState = FormWindowState.Maximized;
            else
            {
                this.Size = Settings.Default.FrmMainSize;
                this.Location = Settings.Default.FrmMainLocation;
            }
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();
        }
        private void FrmMain_Resize(object sender, EventArgs e)
        {
            tsmControl.Margin = new Padding(0, 0, (this.Width - (tsmControl.Width + tsmAbout.Width + tsmRestart.Width + tsmKeyboard.Width)) / 2, 0);
            tslMessage.Margin = new Padding(((statusStrip1.Width - tslMessage.Width) / 2) - (tslDateTime.Width + tslUser.Width), 0, 0, 0);
            picLogo.Left = (this.Width - picLogo.Width) / 2;
            lnkSite.Left = (this.Width - lnkSite.Width) / 2;
            lnkFace.Left = (this.Width - lnkFace.Width) / 2;
        }
        private void FrmMain_Activated(object sender, EventArgs e)
        {
            FrmAbout frmAbout = Application.OpenForms.OfType<FrmAbout>().FirstOrDefault();
            if (frmAbout != null)
                frmAbout.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            // -----------------------msgTool----------------------
            if (Convert.ToInt32(timer1.Tag) >= 1)
                timer1.Tag = (int)(timer1.Tag) + 1;

            if (Convert.ToInt32(timer1.Tag) == 5)
            {
                timer1.Tag = 0;
                tslMessage.Visible = false;
                statusStrip1.BackColor = Color.FromArgb(192, 192, 255);
            }

            // --------------------Invoice Date-----------------------------


            tslDateTime.Text = DateTime.Now.ToString();
            tslUser.Text = VariablesClass.userName + " - " + VariablesClass.userJob;

            FrmInvoices frmInvoice = Application.OpenForms.OfType<FrmInvoices>().FirstOrDefault();
            if (frmInvoice != null)
            {
                frmInvoice.dtpTime.Value = DateTime.Now;
                frmInvoice.dtpDate.Value = DateTime.Now;
            }

            FrmUpdateInvo frmUpdateInvo = Application.OpenForms.OfType<FrmUpdateInvo>().FirstOrDefault();
            if (frmUpdateInvo != null)
            {
               frmUpdateInvo.dtpTime.Value = DateTime.Now;
                frmUpdateInvo.dtpDate.Value = DateTime.Now;
            }
            // ------------------Is Main active ?-------------------------------
            if (VariablesClass.mainActive == true)
            {
                foreach (Form f in Application.OpenForms)
                {
                    if (f.Name != "FrmMain" & f.Visible == true)
                    {
                        FunctionsClass.userTrafficRegister(f.Name, true);
                        VariablesClass.mainActive = false;
                        return;
                    }
                }
                FunctionsClass.userTrafficRegister("FrmMain", true);
                VariablesClass.mainActive = false;
            }

            // -------------------User Connect & Network Monitor-----------------------------

            FrmLogin frmLogin = Application.OpenForms.OfType<FrmLogin>().FirstOrDefault();
            if (frmLogin == null) // Login بعد اغلاق 
            {
                conMonitorCount += 1;
                if (conMonitorCount == 15)
                {
                    UserConnectMonitor();
                    conMonitorCount = 0;
                }
            }
            // -----------------------------------------------
        }
        private void UserConnectMonitor()
        {
            if (VariablesClass.userId == 0)
                return;

            try
            {
                ConClass.cmd = new SqlCommand("UserConnectMonitor", ConClass.con);    // يقوم بتسجيل اخر توقيت لاتصال المستخدم بالشبكة هل مازال متصل أو لا وإذا لم يتصل خلال زمن معين يتم فصل الإتصال عنه
                ConClass.cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param;
                param = new SqlParameter("@userId", VariablesClass.userId);
                ConClass.cmd.Parameters.Add(param);

                ConClass.cmd.Parameters.Add("@MsgCount", SqlDbType.Int).Direction = ParameterDirection.Output;
                ConClass.cmd.Parameters.Add("@UserLockedOut", SqlDbType.Int).Direction = ParameterDirection.Output;

                ConClass.con.Open();
                ConClass.cmd.ExecuteNonQuery();
                ConClass.con.Close();


                int UserLockedOut = Convert.ToInt32(ConClass.cmd.Parameters["@UserLockedOut"].Value);
                if (UserLockedOut == 1)
                {
                    MessageBox.Show("تم ايقافك عن العمل على المنظومة من قبل المسؤول", "ايقاف", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    timer1.Enabled = false;
                    Environment.Exit(0);
                    //this.Close();
                }


                // عدد الرسائل الغير مقروءة والتنبيه لها
                int MsgCount = Convert.ToInt32(ConClass.cmd.Parameters["@MsgCount"].Value);
               // FrmMessenger frmMessenger = Application.OpenForms.OfType<FrmMessenger>().FirstOrDefault();
                int count;
                int.TryParse(lbLTotalMsgCount.Text, out count);

                //if (MsgCount != 0 & frmMessenger == null & MsgCount != count)
                //{

                //    System.Media.SoundPlayer player;
                //    player = new System.Media.SoundPlayer(Resources.ns);
                //    player.Play();
                //    //  player.PlayLooping();
                //    lbLTotalMsgCount.Text = MsgCount.ToString();
                //}
                //else if (MsgCount == 0)
                //    lbLTotalMsgCount.Text = "";
            }

            catch (Exception ex)
            {
                ConClass.con.Close();
                timer1.Enabled = false;
                MessageBox.Show("خطأ في تحديث بيانت اتصال المستخدم" + ex.Message, "خطأ إتصال بقواعد البيانات", MessageBoxButtons.OK, MessageBoxIcon.Error);
                timer1.Enabled = true;

                // msgTool("خطأ في تحديث بيانت اتصال المستخدم", 0)
            }

        }
        //-------------------------Controls------------------------------
        private void hideOpenForms()
        {
            foreach (Button b in pnlButtons.Controls)
            {
                if (b.BackColor != Color.FromArgb(192, 192, 255))
                {
                    b.BackColor = Color.FromArgb(192, 192, 255);
                    b.ForeColor = Color.Black;
                    b.Font = new Font("Hacen Saudi Arabia", 10);

                }
            }
            this.Text = title;

            foreach (Form f in Application.OpenForms)
            {

                if (f.Name != "FrmMain")
                {
                    f.Visible = false;
                    FunctionsClass.userTrafficRegister(f.Name, false);
                }
            }

        }
        private void OpenForm(Form f, Button b)
        {
            if (f.Visible == true) // إختبار إذا كان الفورم مفتوح
            {
                hideOpenForms();
                VariablesClass.mainActive = true;  // جزء خاص بمراقبة حركة المستحدمين
            }
            else
            {
                hideOpenForms();
                f.TopLevel = false;
                f.Parent = pnlMain;
                f.BringToFront();
                f.Visible = true;
                f.Size = pnlMain.Size;
                f.Dock = DockStyle.Fill;
                FunctionsClass.userTrafficRegister(f.Name, true); // جزء خاص بمراقبة حركة المستحدمين
                 FunctionsClass.setPermissions(); // جزء خاص بتخصيص الصلاحيات
                this.Text = title + " - " + b.Text;
                b.BackColor = Color.White;
                b.ForeColor = Color.Black;
                b.Font = new Font("Hacen Saudi Arabia", 12, FontStyle.Bold);
            }


        }
        public void getPicUser(Image img)
        {
            picUser.Image = img;
        }
        private void btnInvoices_Click(object sender, EventArgs e)
        {
            FrmInvoices frmInvoice = Application.OpenForms.OfType<FrmInvoices>().FirstOrDefault();
            if (frmInvoice == null)
                frmInvoice = new FrmInvoices();
            OpenForm(frmInvoice, btnInvoice);
            frmInvoice.txtItemNum.SelectAll();
            frmInvoice.txtItemNum.Focus();

        }
        private void btnInvoReports_Click(object sender, EventArgs e)
        {
            FrmInvoReports frmInvoReports = Application.OpenForms.OfType<FrmInvoReports>().FirstOrDefault();
            if (frmInvoReports == null)
                frmInvoReports = new FrmInvoReports();
            OpenForm(frmInvoReports, btnInvoReport);
        }
        private void btnItems_Click(object sender, EventArgs e)
        {
            FrmItems frmItems = Application.OpenForms.OfType<FrmItems>().FirstOrDefault();
            if (frmItems == null)
                frmItems = new FrmItems();
            OpenForm(frmItems, btnItem);
            frmItems.txtNum.SelectAll();
            frmItems.txtNum.Focus();
        }
        private void btnStores_Click(object sender, EventArgs e)
        {
            FrmStore frmStores = Application.OpenForms.OfType<FrmStore>().FirstOrDefault();
            if (frmStores == null)
                frmStores = new FrmStore();
            OpenForm(frmStores, btnStore);
        }
        private void btnCustomers_Click(object sender, EventArgs e)
        {
            FrmCustomers frmCustomers = Application.OpenForms.OfType<FrmCustomers>().FirstOrDefault();
            if (frmCustomers == null)
                frmCustomers = new FrmCustomers();
            OpenForm(frmCustomers, btnCustomer);
        }
        private void btnChart_Click(object sender, EventArgs e)
        {
            FrmCharts frmCharts = Application.OpenForms.OfType<FrmCharts>().FirstOrDefault();
            if(frmCharts == null)
                frmCharts = new FrmCharts();    
            OpenForm(frmCharts, btnChart);   

        }

        //---------------------MenuStrip-----------------------------------
        private void tsmSettings_Click(object sender, EventArgs e)
        {
            FrmSettings frmSettings = new FrmSettings();
            frmSettings.ShowDialog();
        }
        private void tsmUserControl_Click(object sender, EventArgs e)
        {
            FrmUsers frmUsers = new FrmUsers();
            frmUsers.ShowDialog();
        }
        private void tsmMonitor_Click(object sender, EventArgs e)
        {
            FrmMonitor frmMonitor = new FrmMonitor();
            frmMonitor.ShowDialog();
        }
        private void tsmChangePassword_Click(object sender, EventArgs e)
        {
            FrmChangePassword frmChangePassword = new FrmChangePassword();
            frmChangePassword.ShowDialog();

        }
        private void tsmDeletedElements_Click(object sender, EventArgs e)
        {
            FrmDelElements frmDelElements = new FrmDelElements();
            frmDelElements.ShowDialog();
        }
        private void tsmAbout_Click(object sender, EventArgs e)
        {
            FrmAbout frmAbout = new FrmAbout();
            frmAbout.Show();
        }
        private void picMassenger_Click(object sender, EventArgs e)
        {
            FrmMessenger frmMessenger = new FrmMessenger();
            frmMessenger.ShowDialog();
        }
        private void tsmRestart_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل أنت متأكد تريد تسجيل الخروج", "تسجيل خروج", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                closeOpenForms();
                VariablesClass.userId = 0;
                VariablesClass.userName = "";
                VariablesClass.userPassword = "";
                VariablesClass.userJob = "";
                lbLTotalMsgCount.Text = "";
                FrmLogin frmLogin = new FrmLogin();
                frmLogin.ShowDialog();
            }
        }
        private void closeOpenForms()
        {
            foreach (Button b in pnlButtons.Controls)
            {
                b.BackColor = Color.FromArgb(192, 192, 255);
                b.ForeColor = Color.Black;
                b.Font = new Font("Hacen Saudi Arabia", 10);
            }
            this.Text = title;

            for (int i = Application.OpenForms.Count - 1; i >= 1; i -= 1)
            {
                Form f = Application.OpenForms[i];
                if (f.Name != "FrmMain")
                    f.Close();
            }

        }
        //------------------------------------------------------------------
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("هل تريد إغلاق المنظومة", "تأكيد طلب إغلاق", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                if (Settings.Default.AutoBackup == true)
                   // backupDatabase();

                saveFormSize();
            }

            else
                e.Cancel = true;
        }
        void saveFormSize()
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                Settings.Default.FrmMainSize = this.Size;
                Settings.Default.FrmMainLocation = this.Location;
            }

            Settings.Default.FrmMainWindowState = (int)this.WindowState;
            Settings.Default.Save();
        }
        void backupDatabase()
        {
            showBackupInfo();
            deleteBackupDays();
            deleteBackupFiles();
        }
        void showBackupInfo()
        {
            var di = new DirectoryInfo(Settings.Default.AutoBackupPath);
            var fl = di.GetFileSystemInfos().ToList();
            string last = (from file in from file in fl select file orderby file.CreationTime descending select file).FirstOrDefault().FullName;
            var fi = new FileInfo(last);

            notifyIcon1.BalloonTipText += Environment.NewLine + fi.FullName + Environment.NewLine + "(" + fi.Length / 1024L / 1024L + " MBytes) " + Convert.ToString(fi.LastWriteTime);
            notifyIcon1.ShowBalloonTip(1);

            DriveInfo dri =
                new DriveInfo(Path.GetPathRoot(Settings.Default.AutoBackupPath));

            if (dri.AvailableFreeSpace < fi.Length * 3L)
            {
                MessageBox.Show("المساحة المتاحة للنسخ الإحتياطي انتهت سيتم ايقاف النسخ الإحتياطي التلقائي ", "تحذير انخفاض مساحة القرص الصلب", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Settings.Default.AutoBackup = false;
                Settings.Default.Save();
            }
            else if (dri.AvailableFreeSpace < fi.Length * 6L)
            {
                MessageBox.Show("المساحة المتاحة للنسخ الإحتياطي لقواعد البيانات في القرص الصلب على وشك الانتهاء ", "تحذير انخفاض مساحة القرص الصلب", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }
        void deleteBackupDays()
        {
            if (Settings.Default.BackupDays == 0)
                return;

            var di = new DirectoryInfo(Settings.Default.AutoBackupPath);

            foreach (FileInfo file in di.GetFiles("*.bak", SearchOption.TopDirectoryOnly))
            {
                if ((DateTime.Now - file.CreationTime).Days > Settings.Default.BackupDays)
                    file.Delete();
            }
        }
        void deleteBackupFiles()
        {
            if (Settings.Default.BackupFiles == 0)
                return;

            var di = new DirectoryInfo(Settings.Default.AutoBackupPath);

            var fl = di.GetFiles("*.bak", SearchOption.TopDirectoryOnly);  /*var fl = di.GetFileSystemInfos().ToList();*/

            foreach (var ff in from file in from file in fl select file orderby file.CreationTime ascending select file)
            {
                if (di.GetFiles("*.bak", SearchOption.TopDirectoryOnly).Count() > Settings.Default.BackupFiles)
                    ff.Delete();
            }
        }
        //-----------------------------------------------------------------



    }
}
