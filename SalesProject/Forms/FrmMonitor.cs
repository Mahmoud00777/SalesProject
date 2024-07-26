using SalesProject.Classes;
using SalesProject.Properties;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SalesProject.Forms
{
    public partial class FrmMonitor : Form
    {
        public FrmMonitor()
        {
            InitializeComponent();
        }

        DataSet dsMonitor = new DataSet();
        DataTable dtNetworkMonitor = new DataTable(), dtUser = new DataTable();
        int sequence;
        ResizeControls r = new ResizeControls();
        private void FrmMonitor_Resize(object sender, EventArgs e)
        {
            r.ResizeControl();
        }
        private void FrmMonitor_HandleCreated(object sender, EventArgs e)
        {
            r.Container = this;
        }
        private void FrmMonitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            FunctionsClass.userTrafficRegister(this.Name, false);
            VariablesClass.mainActive = true;
            timer1.Enabled = false;

          
        }
        //------------------------------------------------------------------
        private void FrmMonitor_Load(object sender, EventArgs e)
        {
            FunctionsClass.userTrafficRegister(this.Name, true);
            lblTitle.Text = "حركة المستخدمين خلال (24) ساعة";
            timer1.Enabled = true;
           
            
            getData();
            fillDGVInvoiceMonitor();
            fillDGVUserTrafficMonitor();
            fillDGVNetworkMonitor();
            fillCmbUser();



            setFormSize();

            dgvInvoiceMonitor.DefaultCellStyle.Font = new Font("Times New Roman", 11, FontStyle.Regular);
            dgvUserTraficMonitor.DefaultCellStyle.Font = new Font("Times New Roman", 11, FontStyle.Regular);
            dgvNetworkMonitor.DefaultCellStyle.Font = new Font("Times New Roman", 11, FontStyle.Regular);
        }
        void setFormSize()
        {
            this.Size = Settings.Default.FrmMainSize - new Size(0, 55);
            this.Location = Settings.Default.FrmMainLocation;
            this.Top += 30;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            getData();
            fillDGVInvoiceMonitor();
            fillDGVNetworkMonitor();
            fillDGVUserTrafficMonitor();
        }
        void getData()
        {
            try
            {
                // ----------------------------الفواتير--------------------------------
                long InvoDateDays;
                InvoDateDays = Convert.ToInt64(dtpInvoDateFrom.Value.Date.Subtract(dtpInvoDateTo.Value.Date).Days);

                if (InvoDateDays > 1 | InvoDateDays < 0)
                {
                    timer1.Enabled = false;
                    MessageBox.Show("لا يمكن ان يكون تاريخ العرض اكبر من يوم واحد", "مراقبة فواتير المبيعات", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtpInvoDateFrom.Value = DateTime.Now;
                    dtpInvoDateTo.Value = DateTime.Now;
                    timer1.Enabled = true;
                    return;

                }

                DateTime InvoDateInvoTimeFrom = Convert.ToDateTime(dtpInvoDateFrom.Value.Date + dtpInvoTimeFrom.Value.TimeOfDay);
                DateTime InvoDateInvoTimeTo = Convert.ToDateTime(dtpInvoDateTo.Value.Date + dtpInvoTimeTo.Value.TimeOfDay);

                // حركة الفواتير
                SQLConClass.sqlQuery = "SELECT TblEvents.*,TblUsers.userName FROM TblEvents,TblUsers where TblUsers.Id=TblEvents.userId AND"
                    + " EventDate BETWEEN '" + InvoDateInvoTimeFrom + "'AND '" + InvoDateInvoTimeTo.ToString() + "'";


                // ----------------------------------الشبكة------------------------------
                DateTime TrafficDateTimeFrom = Convert.ToDateTime(dtpTrafficDateFrom.Value.Date + dtpTrafficTimeFrom.Value.TimeOfDay);
                DateTime TrafficDateTimeTo = Convert.ToDateTime(dtpTrafficDateTo.Value.Date + dtpTrafficTimeTo.Value.TimeOfDay);



                dsMonitor.Clear();
                if (cmbUserName.SelectedIndex == -1)
                {
                    // حركة كل المستخدمين خلال التاريخ المحدد
                    SQLConClass.sqlQuery += " SELECT TblUserTraffices.*,TblUsers.userName FROM TblUserTraffices,TblUsers " +
                                            "where TblUsers.Id=TblUserTraffices.userId AND DateEntry BETWEEN '" + TrafficDateTimeFrom.ToString() + "'AND '" + TrafficDateTimeTo.ToString() + "' order by Id desc";
                }
                else
                {
                    // حركة المستخدم المحدد من الكومبو خلال التاريخ المحدد
                    SQLConClass.sqlQuery += " SELECT TblUserTraffices.*,TblUsers.userName FROM TblUserTraffices,TblUsers " +
                                            "where TblUsers.Id=TblUserTraffices.userId AND DateEntry BETWEEN '" + TrafficDateTimeFrom.ToString() + "'AND '" + TrafficDateTimeTo.ToString() + "' AND TblUsers.Id=" + cmbUserName.SelectedValue + "  order by Id desc";
                }

                // تحميل كل المستخدمين الذين استخدمو المنظومة خلال 90 يوم في شاشة مراقبة الشبكة
                SQLConClass.sqlQuery += " SELECT TblUserTraffices.*,TblUsers.userName FROM TblUserTraffices,TblUsers " +
                                        "where TblUsers.Id=TblUserTraffices.userId AND DATEDIFF(DD,DateEntry,GETDATE())<=90 ";

                // تحميل أسماء المستخدمين في الكومبو
                SQLConClass.sqlQuery += " SELECT Id, UserName FROM TblUsers WHERE Del='FALSE'";

                ConClass.da = new SqlDataAdapter(SQLConClass.sqlQuery, ConClass.con);
                ConClass.da.Fill(dsMonitor);

                // -------حركة جميع المستخدمين في النظام خلال 90 يوم
                dtNetworkMonitor = dsMonitor.Tables[2].Clone();
                // -------------------------------------------------------------------
                DataTable dTDistinctUserID = dsMonitor.Tables[2].DefaultView.ToTable(true, "UserId");   // تنسخ العمود المحدد فقط 
                foreach (DataRow Row in dTDistinctUserID.Rows)
                {
                    DataTable dt = dsMonitor.Tables[2].Select(" UserId=" + Row["userId"], " DateEntry DESC").Take(1).CopyToDataTable();
                    dtNetworkMonitor.ImportRow(dt.Rows[0]);
                }
                dsMonitor.Tables[2].Clear();
            }
            // ------------------------------------------------------------------
            catch (Exception ex)
            {
                MessageBox.Show("فشل في الإتصال بقاعدة البيانات" + ex.Message, "خطأ إتصال", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //DataRow[] drDistinctUserID = dtUserTrafficMonitor.Select(" userId=" + Row.ItemArray["userId"], " DateEntry DESC").Take(1).ToArray;
        }
        void fillCmbUser()
        {
            dtUser.Clear();
            dtUser = dsMonitor.Tables[3].Copy();
            cmbUserName.DataSource = dtUser;
            cmbUserName.DisplayMember = "userName";
            cmbUserName.ValueMember = "Id";
            cmbUserName.SelectedIndex = -1;
        }
        void fillDGVUserTrafficMonitor()
        {
            dgvUserTraficMonitor.Rows.Clear();
            sequence = 0;
            for (int i = 0; i <= dsMonitor.Tables[1].Rows.Count - 1; i++)
            {
                if ((int)dsMonitor.Tables[1].Rows[i][1] != 1 | VariablesClass.userId == 1)
                {
                    dgvUserTraficMonitor.Rows.Add();

                    dgvUserTraficMonitor.Rows[sequence].Cells[0].Value = sequence + 1;
                    dgvUserTraficMonitor.Rows[sequence].Cells[1].Value = dsMonitor.Tables[1].Rows[i][7];
                    dgvUserTraficMonitor.Rows[sequence].Cells[2].Value = dsMonitor.Tables[1].Rows[i][1];
                    dgvUserTraficMonitor.Rows[sequence].Cells[3].Value = dsMonitor.Tables[1].Rows[i][3];
                    dgvUserTraficMonitor.Rows[sequence].Cells[4].Value = dsMonitor.Tables[1].Rows[i][4].ToString(); // بدون اضافتها سايعطي خطأ عند الضغط على ترتيب الاعمدة


                    if (dsMonitor.Tables[1].Rows[i][4] is DBNull)
                    {
                        dgvUserTraficMonitor.Rows[sequence].Cells[5].Value = Convert.ToInt64(DateTime.Now.Subtract(Convert.ToDateTime(dsMonitor.Tables[1].Rows[i][3])).Minutes).ToString();
                    }
                    else
                    {
                        dgvUserTraficMonitor.Rows[sequence].Cells[5].Value = Convert.ToInt64(Convert.ToDateTime(dsMonitor.Tables[1].Rows[i][4]).Subtract(Convert.ToDateTime(dsMonitor.Tables[1].Rows[i][3])).Minutes).ToString();
                    }

                    dgvUserTraficMonitor.Rows[sequence].Cells[6].Value = dsMonitor.Tables[1].Rows[i][2];
                    sequence++;
                }

            }

            dgvUserTraficMonitor.ClearSelection();
            //if (dgvUserTraficMonitor.RowCount != 0)
            //    dgvUserTraficMonitor.FirstDisplayedScrollingRowIndex = dgvUserTraficMonitor.RowCount - 1;
        }
        private void dgvUserTraficMonitor_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == dgvUserTraficMonitor.Rows.Count)
            {
                return;
            }

            if (e.ColumnIndex == 5)
            {
                if (dgvUserTraficMonitor.Rows[e.RowIndex].Cells[5].Value.ToString() == "0")
                {
                    dgvUserTraficMonitor.Rows[e.RowIndex].Cells[5].Value = "أقل من دقيقة";
                }
            }

            if (e.ColumnIndex == 6)
            {
                switch (dgvUserTraficMonitor.Rows[e.RowIndex].Cells[6].Value.ToString())
                {

                    case "FrmMain":
                        {
                            dgvUserTraficMonitor.Rows[e.RowIndex].Cells[6].Value = "الشاشة الرئيسية";
                            break;
                        }
                    case "FrmUsers":
                        {
                            dgvUserTraficMonitor.Rows[e.RowIndex].Cells[6].Value = "إدارة المستخدمين";
                            break;
                        }
                    case "FrmCharts":
                        {
                            dgvUserTraficMonitor.Rows[e.RowIndex].Cells[6].Value = "الإحصائيات";
                            break;
                        }
                    case "FrmCustomers":
                        {
                            dgvUserTraficMonitor.Rows[e.RowIndex].Cells[6].Value = "إدارة الزبائن";
                            break;
                        }
                    case "FrmDelElements":
                        {
                            dgvUserTraficMonitor.Rows[e.RowIndex].Cells[6].Value = "إدارة البيانات المحذوفة";
                            break;
                        }
                    case "FrmInvoice":
                        {
                            dgvUserTraficMonitor.Rows[e.RowIndex].Cells[6].Value = "فواتير المبيعات";
                            break;
                        }
                    case "FrmInvoReports":
                        {
                            dgvUserTraficMonitor.Rows[e.RowIndex].Cells[6].Value = "التقارير";
                            break;
                        }
                    case "FrmItems":
                        {
                            dgvUserTraficMonitor.Rows[e.RowIndex].Cells[6].Value = "إدارة الأصناف";
                            break;
                        }
                    case "FrmSettings":
                        {
                            dgvUserTraficMonitor.Rows[e.RowIndex].Cells[6].Value = "إدارة إعددات الإتصال والنسخ الإحتياطي";
                            break;
                        }
                    case "FrmStore":
                        {
                            dgvUserTraficMonitor.Rows[e.RowIndex].Cells[6].Value = "المخزن";
                            break;
                        }
                    case "FrmMonitor":
                        {
                            dgvUserTraficMonitor.Rows[e.RowIndex].Cells[6].Value = "مراقبة النظام وحركة المستخدمين";
                            break;
                        }
                    case "FrmUpdateInvo":
                        {
                            dgvUserTraficMonitor.Rows[e.RowIndex].Cells[6].Value = "تعديل فاتورة مبيعات";
                            break;
                        }
                    case "FrmMessenger":
                        {
                            dgvUserTraficMonitor.Rows[e.RowIndex].Cells[6].Value = "المراسلات الداخلية";
                            break;
                        }
                    case "FrmChangePassword":
                        {
                            dgvUserTraficMonitor.Rows[e.RowIndex].Cells[6].Value = "تغيير كلمة المرور";
                            break;
                        }
                    case "FrmInventory":
                        {
                            dgvUserTraficMonitor.Rows[e.RowIndex].Cells[6].Value = "الجرد السنوي";
                            break;
                        }

                }
            }
        }
        private void btnUserTrafficMonitorShow_Click(object sender, EventArgs e)
        {
            getData();
            fillDGVUserTrafficMonitor();
            DateTime TrafficDateTimeFrom = Convert.ToDateTime(dtpTrafficDateFrom.Value.Date + dtpTrafficTimeFrom.Value.TimeOfDay);
            DateTime TrafficDateTimeTo = Convert.ToDateTime(dtpTrafficDateTo.Value.Date + dtpTrafficTimeTo.Value.TimeOfDay);

            lblTitle.Text = "حركة المستخدمين خلال (" + Convert.ToInt64(TrafficDateTimeTo.Subtract(TrafficDateTimeFrom).Hours).ToString() + ") ساعة";

        }
        private void btnUserTrafficMonitorNew_Click(object sender, EventArgs e)
        {
            dtpTrafficDateFrom.Value = DateTime.Now; // DateAdd(DateInterval.Day, -1, Now)
            dtpTrafficDateTo.Value = DateTime.Now;
            dtpTrafficTimeFrom.Value = Convert.ToDateTime(dtpTrafficDateFrom.Value.Date.ToShortDateString() + " 12:00:00 AM");
            dtpTrafficTimeTo.Value = Convert.ToDateTime(dtpTrafficDateTo.Value.Date.ToShortDateString() + " 11:59:59 AM");

            getData();
            fillDGVUserTrafficMonitor();
        }
        private void btnDelUserTrafficMonitor_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت متأكد تريد حذف جميع سجلات مراقبة حركة المستخدمين" + Environment.NewLine + Environment.NewLine + "سيتم حذف جميع رسائل الماسنجر لجميع المستخدمين", "حذف بيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SQLConClass.sqlQuery = "DELETE FROM TblUserTraffices DELETE FROM TblMessages";
                    ConClass.cmd = new SqlCommand(SQLConClass.sqlQuery, ConClass.con);
                    ConClass.con.Open();
                    ConClass.cmd.ExecuteNonQuery();
                    ConClass.con.Close();
                    MessageBox.Show("تمت عملية الحذف بنجاح", "تأكيد حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmMain frmMain = new FrmMain();
                    frmMain.lbLTotalMsgCount.Text = "";
                    btnUserTrafficMonitorNew.PerformClick();
                }
                catch (Exception ex)
                {
                    ConClass.con.Close();
                    MessageBox.Show("فشل في الإتصال بقاعدة البيانات" + ex.Message, "خطأ إتصال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void chkSelectUser_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectUser.Checked)
            {
                cmbUserName.Enabled = true;
                cmbUserName.Text = "";
                cmbUserName.BackColor = Color.White;
            }
            else
            {
                cmbUserName.Enabled = false;
                cmbUserName.SelectedIndex = -1;
                cmbUserName.BackColor = Color.FromArgb(128, 128, 255);
                getData();
                fillDGVUserTrafficMonitor();
            }
        }
        private void cmbUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkSelectUser.Checked)
            {
                getData();
                fillDGVInvoiceMonitor();
                fillDGVUserTrafficMonitor();
                fillDGVNetworkMonitor();
            }
        }
        private void checkAutoRefrech_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAutoRefrech.Checked == true)
            {
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
            }
        }
        //----------------------------------------------------------------------------
        void fillDGVNetworkMonitor()
        {
            dgvNetworkMonitor.Rows.Clear();
            sequence = 0;
            for (int i = 0; i <= dtNetworkMonitor.Rows.Count - 1; i++)
            {
                if ((int)dtNetworkMonitor.Rows[i][1] != 1 | VariablesClass.userId == 1)
                {
                    dgvNetworkMonitor.Rows.Add();

                    dgvNetworkMonitor.Rows[sequence].Cells[0].Value = sequence + 1;
                    dgvNetworkMonitor.Rows[sequence].Cells[1].Value = dtNetworkMonitor.Rows[i][7];
                    dgvNetworkMonitor.Rows[sequence].Cells[2].Value = dtNetworkMonitor.Rows[i][1];
                    dgvNetworkMonitor.Rows[sequence].Cells[4].Value = dtNetworkMonitor.Rows[i][4];
                    if (dtNetworkMonitor.Rows[i][4] is DBNull)
                    {
                        dgvNetworkMonitor.Rows[sequence].Cells[5].Value = Convert.ToInt64(Convert.ToDateTime(DateTime.Now).Subtract(Convert.ToDateTime(dtNetworkMonitor.Rows[i][3])).Minutes).ToString();
                    }
                    else
                    {
                        dgvNetworkMonitor.Rows[sequence].Cells[5].Value = Convert.ToInt64(Convert.ToDateTime(dtNetworkMonitor.Rows[i][4]).Subtract(Convert.ToDateTime(dtNetworkMonitor.Rows[i][3])).Minutes).ToString();
                    }

                    if ((bool)dtNetworkMonitor.Rows[i][5] == true)
                    {
                        dgvNetworkMonitor.Rows[sequence].Cells[7].Value = "متصل";
                        dgvNetworkMonitor.Rows[sequence].Cells[6].Value = dtNetworkMonitor.Rows[i][2];
                        dgvNetworkMonitor.Rows[sequence].Cells[3].Value = dtNetworkMonitor.Rows[i][3];
                    }
                    else
                    {
                        dgvNetworkMonitor.Rows[sequence].Cells[7].Value = "غير متصل";
                        dgvNetworkMonitor.Rows[sequence].Cells[6].Value = "";
                        dgvNetworkMonitor.Rows[sequence].Cells[3].Value = "";
                        dgvNetworkMonitor.Rows[sequence].Cells[5].Value = "";
                    }
                    sequence ++;
                }
            }
            dgvNetworkMonitor.ClearSelection();
        }
        private void dgvNetworkMonitor_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == dgvNetworkMonitor.Rows.Count)
            {
                return;
            }

            if (e.ColumnIndex == 5)
            {
                if (dgvNetworkMonitor.Rows[e.RowIndex].Cells[5].Value.ToString() == "0")
                {
                    dgvNetworkMonitor.Rows[e.RowIndex].Cells[5].Value = "أقل من دقيقة";
                }
            }

            if (e.ColumnIndex == 7)
            {
                if (dgvNetworkMonitor.Rows[e.RowIndex].Cells[7].Value.ToString() == "متصل")
                {
                    e.CellStyle.BackColor = Color.Lime;
                    e.CellStyle.SelectionBackColor = Color.Lime;
                    e.CellStyle.SelectionForeColor = Color.Blue;
                }
                else
                {
                    e.CellStyle.BackColor = Color.FromArgb(192, 192, 255);
                    e.CellStyle.SelectionBackColor = Color.FromArgb(192, 192, 255);
                    e.CellStyle.SelectionForeColor = Color.Black;
                }
            }


            if (e.ColumnIndex == 6)
            {
                switch (dgvNetworkMonitor.Rows[e.RowIndex].Cells[6].Value.ToString())
                {

                    case "FrmMain":
                        {
                            dgvNetworkMonitor.Rows[e.RowIndex].Cells[6].Value = "الشاشة الرئيسية";
                            break;
                        }
                    case "FrmUsers":
                        {
                            dgvNetworkMonitor.Rows[e.RowIndex].Cells[6].Value = "إدارة المستخدمين";
                            break;
                        }
                    case "FrmCharts":
                        {
                            dgvNetworkMonitor.Rows[e.RowIndex].Cells[6].Value = "الإحصائيات";
                            break;
                        }
                    case "FrmCustomers":
                        {
                            dgvNetworkMonitor.Rows[e.RowIndex].Cells[6].Value = "إدارة الزبائن";
                            break;
                        }
                    case "FrmDelElements":
                        {
                            dgvNetworkMonitor.Rows[e.RowIndex].Cells[6].Value = "إدارة البيانات المحذوفة";
                            break;
                        }
                    case "FrmInvoices":
                        {
                            dgvNetworkMonitor.Rows[e.RowIndex].Cells[6].Value = "فواتير المبيعات";
                            break;
                        }
                    case "FrmInvoReports":
                        {
                            dgvNetworkMonitor.Rows[e.RowIndex].Cells[6].Value = "التقارير";
                            break;
                        }
                    case "FrmItems":
                        {
                            dgvNetworkMonitor.Rows[e.RowIndex].Cells[6].Value = "إدارة الأصناف";
                            break;
                        }
                    case "FrmSettings":
                        {
                            dgvNetworkMonitor.Rows[e.RowIndex].Cells[6].Value = "إدارة إعددات الإتصال والنسخ الإحتياطي";
                            break;
                        }
                    case "FrmStore":
                        {
                            dgvNetworkMonitor.Rows[e.RowIndex].Cells[6].Value = "المخزن";
                            break;
                        }
                    case "FrmMonitor":
                        {
                            dgvNetworkMonitor.Rows[e.RowIndex].Cells[6].Value = "مراقبة النظام وحركة المستخدمين";
                            break;
                        }
                    case "FrmUpdateInvo":
                        {
                            dgvNetworkMonitor.Rows[e.RowIndex].Cells[6].Value = "تعديل فاتورة مبيعات";
                            break;
                        }
                    case "FrmMessenger":
                        {
                            dgvNetworkMonitor.Rows[e.RowIndex].Cells[6].Value = "المراسلات الداخلية";
                            break;
                        }
                    case "FrmChangePassword":
                        {
                            dgvUserTraficMonitor.Rows[e.RowIndex].Cells[6].Value = "تغيير كلمة المرور";
                            break;
                        }
                    case "FrmInventory":
                        {
                            dgvUserTraficMonitor.Rows[e.RowIndex].Cells[6].Value = "الجرد السنوي";
                            break;
                        }
                }
            }
        }
        //----------------------------------------------------------------------------
        void fillDGVInvoiceMonitor()
        {
            dgvInvoiceMonitor.Rows.Clear();
            for (int i = 0; i <= dsMonitor.Tables[0].Rows.Count - 1; i++)
            {
                dgvInvoiceMonitor.Rows.Add();

                dgvInvoiceMonitor.Rows[i].Cells[0].Value = i + 1;
                dgvInvoiceMonitor.Rows[i].Cells[1].Value = dsMonitor.Tables[0].Rows[i][1];
                dgvInvoiceMonitor.Rows[i].Cells[2].Value = dsMonitor.Tables[0].Rows[i][2];
                dgvInvoiceMonitor.Rows[i].Cells[3].Value = dsMonitor.Tables[0].Rows[i][7];
                dgvInvoiceMonitor.Rows[i].Cells[4].Value = dsMonitor.Tables[0].Rows[i][6];
            }
            dgvInvoiceMonitor.ClearSelection();
            //if (dgvInvoiceMonitor.RowCount != 0)
            //    dgvInvoiceMonitor.FirstDisplayedScrollingRowIndex = dgvInvoiceMonitor.RowCount - 1;
        }
        private void btnInvoMonitorNew_Click(object sender, EventArgs e)
        {
            dtpInvoDateFrom.Value = DateTime.Now; DateTime.Now.AddDays(Convert.ToInt32(-1));
            dtpInvoDateTo.Value = DateTime.Now;
            dtpInvoTimeFrom.Value = Convert.ToDateTime(dtpInvoDateFrom.Value.Date.ToShortDateString() + " 12:00:00 AM");
            dtpInvoTimeTo.Value = Convert.ToDateTime(dtpInvoDateTo.Value.Date.ToShortDateString() + " 11:59:59 PM");

            getData();
            fillDGVInvoiceMonitor();
        }
        private void btnInvoMonitorShow_Click(object sender, EventArgs e)
        {
            getData();
            fillDGVInvoiceMonitor();
        }
        private void btnDelInvoMonitor_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انت متأكد تريد حذف جميع سجلات مراقبة فواتير المبيعات", "حذف بيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                try
                {
                    SQLConClass.sqlQuery = "DELETE FROM TblEvents";
                    ConClass.cmd = new SqlCommand(SQLConClass.sqlQuery, ConClass.con);
                    ConClass.con.Open();
                    ConClass.cmd.ExecuteNonQuery();
                    ConClass.con.Close();
                    MessageBox.Show("تمت عملية الحذف بنجاح", "تأكيد حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnInvoMonitorNew.PerformClick();
                }
                catch (Exception ex)
                {
                    ConClass.con.Close();
                    MessageBox.Show("فشل في الإتصال بقاعدة البيانات" + ex.Message, "خطأ إتصال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
