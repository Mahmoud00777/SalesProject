using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using SalesProject.Classes;
using SalesProject.Properties;

namespace SalesProject.Forms
{
    public partial class FrmInvoReports : Form
    {
        public FrmInvoReports()
        {
            InitializeComponent();
        }

        DataSet dsInvoReports = new DataSet(), dsCustomers = new DataSet();
        int cr;
        ResizeControls r = new ResizeControls();
        private void FrmInvoReports_Resize(object sender, EventArgs e)
        {
            r.ResizeControl();
        }
        private void FrmInvoReports_HandleCreated(object sender, EventArgs e)
        {
            r.Container = this;
        }
        private void FrmInvoReports_FormClosing(object sender, FormClosingEventArgs e)
        {
           

        }
        private void FrmInvoReports_Load(object sender, EventArgs e)
        {
            getCustomers();
            txtInvoNum.Select();

            dtpDateFrom.CustomFormat = Settings.Default.DateFormat;
            dtpDateTo.CustomFormat = Settings.Default.DateFormat;
            dgvInvoReports.ColumnHeadersDefaultCellStyle.Font = new Font("Hacen Saudi Arabia", 10, FontStyle.Regular);
            progressBar1.Visible = false;
        }
        void getCustomers()
        {
            SQLConClass sqlCon = new SQLConClass();
            dsCustomers = sqlCon.selectData("SELECT Id,Name FROM TblCustomers WHERE Del=0 ORDER BY Name", 0, null);
            if (FunctionsClass.dsHasTables(dsCustomers))
            {
                cmbName.DataSource = dsCustomers.Tables[0];
                cmbName.DisplayMember = "Name";
                cmbName.ValueMember = "Id";
                cmbName.SelectedIndex = -1;
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FunctionsClass.clear(grpSearch);
            dsInvoReports.Clear();
            cr = -1;
            VariablesClass.updateInvoiceId = 0;   // public static int updateInvoiceId 
            txtTotal.Clear();
            progressBar1.Value = 0;
            chkInvoNum.Checked = true;
            getCustomers();
            txtInvoNum.Select();
        }
        private void chkInvoNum_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInvoNum.Checked)
            {
                chkName.Checked = false;
                chkDate.Checked = false;
                cmbName.Enabled = false;
                txtInvoNum.Enabled = true;
                txtInvoNum.Focus();
            }
            else
                txtInvoNum.Enabled = false;
        }
        private void chkName_CheckedChanged(object sender, EventArgs e)
        {
            if (chkName.Checked)
            {
                chkInvoNum.Checked = false;
                txtInvoNum.Text = "";
                txtInvoNum.Enabled = false;
                cmbName.Enabled = true;
                cmbName.Focus();
            }
            else
            {
                cmbName.SelectedValue = -1;
                cmbName.Enabled = false;
            }
        }
        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDate.Checked)
            {
                chkInvoNum.Checked = false;
                grpDate.Enabled = true;
            }
            else
                grpDate.Enabled = false;
        }
        private void txtInvoNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(sender, e);
        }
        public void btnSearch_Click(object sender, EventArgs e)
        {
            VariablesClass.updateInvoiceId = 0;
            SQLConClass sqlCon = new SQLConClass();

            if (chkInvoNum.Checked == true) // Num
            {
                if (txtInvoNum.Text.Trim() == "")
                {
                    txtInvoNum.Focus();
                    FunctionsClass.msgTool("الرجاء ادخال رقم الفاتورة", 0);
                    return;
                }

                SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@Num", Convert.ToInt32(txtInvoNum.Text.Trim()))
                };

                dsInvoReports = sqlCon.selectData("FindInvoNum", 1, param);
            }

            else if (chkName.Checked == true & chkDate.Checked == false) // Name
            {
                if (cmbName.SelectedValue == null)
                {
                    MessageBox.Show("الرجاء اختيار اسم العميل من القائمة", "ادخال بيانات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@CustomerID", cmbName.SelectedValue)
                };

                dsInvoReports = sqlCon.selectData("FindInvoCustomer", 1, param);
            }
            else if (chkName.Checked == false & chkDate.Checked == true) // Date
            {
                DateTime dateTimeFrom = Convert.ToDateTime(dtpDateFrom.Value.Date + dtpTimeFrom.Value.TimeOfDay);
                DateTime dateTimeTo = Convert.ToDateTime(dtpDateTo.Value.Date + dtpTimeTo.Value.TimeOfDay);


                SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@FromDate", dateTimeFrom),
                    new SqlParameter("@ToDate", dateTimeTo)
                };

                dsInvoReports = sqlCon.selectData("FindInvoDate", 1, param);
            }
            else if (chkName.Checked == true & chkDate.Checked == true) // Name+Date
            {
                if (cmbName.SelectedValue == null)
                {
                    MessageBox.Show("الرجاء اختيار اسم من القائمة", "ادخال بيانات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DateTime dateTimeFrom = Convert.ToDateTime(dtpDateFrom.Value.Date + dtpTimeFrom.Value.TimeOfDay);
                DateTime dateTimeTo = Convert.ToDateTime(dtpDateTo.Value.Date + dtpTimeTo.Value.TimeOfDay);

                SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@FromDate", dateTimeFrom),
                    new SqlParameter("@ToDate", dateTimeTo),
                    new SqlParameter("@CustomerId", cmbName.SelectedValue)
                };


                //dsInvoReports = sqlCon.selectData("FindInvoDateCustomerView", 1, param);
                dsInvoReports = sqlCon.selectData("SELECT ROW_NUMBER() OVER (ORDER BY Id) AS ت ,* from InvoReportView where CustomerID=@CustomerID AND  InvoDate BETWEEN  @FromDate AND @ToDate", 0, param);
            }

            if (!FunctionsClass.dsHasTables(dsInvoReports))
                return;

            dgvInvoReports.DataSource = dsInvoReports.Tables[0];

            if (dsInvoReports.Tables[0].Rows.Count == 0)
            {
                FunctionsClass.msgTool("لا توجد نتائج لهذا البحث", 0);
                txtTotal.Clear();
                return;
            }

            if (dgvInvoReports.Columns.Count == 8)
                dgvInvoReports.Columns[7].Visible = false;

            total();
            dgvInvoReports.ClearSelection();
        }
        void total()
        {
            double total = 0;
            txtTotal.Text = total.ToString();

            foreach (DataGridViewRow row in dgvInvoReports.Rows)
                total = total + Convert.ToDouble(row.Cells[4].Value);

            txtTotal.Text = total.ToString("0.000");
        }
        private void dgvInvoReport_Click(object sender, EventArgs e)
        {
            if (FunctionsClass.checkDgvError(dgvInvoReports) == true)
                return;

            cr = dgvInvoReports.CurrentRow.Index;
            VariablesClass.updateInvoiceId = Convert.ToInt32(dgvInvoReports.Rows[cr].Cells[0].Value);
        }
        private void btnDelInvo_Click(object sender, EventArgs e)
        {
            if (VariablesClass.updateInvoiceId == 0)
            {
                MessageBox.Show("الرجاء تحديد فاتورة من القائمة", "حذف بيانات", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show("هل أنت متأكد تريد حذف الفاتورة رقم:    " + dgvInvoReports.Rows[cr].Cells[2].Value, "تأكيد حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                SQLConClass sqlCon = new SQLConClass();
                SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@Id", VariablesClass.updateInvoiceId)
                };

                if (sqlCon.cmdExecute("UPDATE TblInvoices SET Del=1 WHERE Id=@Id", 0, param) > 0)
                {
                    MessageBox.Show("تم حذف الفاتورة لإسترجاعها من شاشة إدارة البيانات المحذوفة", "حذف فاتورة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // dgvInvoReports.Rows.Remove(dgvInvoReports.Rows[cr]);

                    DataRow row = dsInvoReports.Tables[0].Rows[cr];
                    dsInvoReports.Tables[0].Rows.Remove(row);

                    VariablesClass.updateInvoiceId = 0; cr = -1;
                    total();
                    sequence();
                }
            }
        }
        void sequence()
        {
            dgvInvoReports.Tag = 1;
            foreach (DataGridViewRow row in dgvInvoReports.Rows)
            {
                row.Cells[1].Value = dgvInvoReports.Tag;
                dgvInvoReports.Tag = Convert.ToInt32(dgvInvoReports.Tag) + 1;
            }
        }
        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            if (txtTotal.Text != string.Empty)
                lblTotInvoReport.Text = NumbersClass.NoToTxt(Convert.ToDouble(txtTotal.Text), "دينار", "درهم", true);
            else
                lblTotInvoReport.Text = string.Empty;
        }
        //----------------------------------------------
        private void dgvInvoReport_DoubleClick(object sender, EventArgs e)
        {
            btnOpenInvoice_Click(sender, e);
        }
        private void btnOpenInvoice_Click(object sender, EventArgs e)
        {
            if (VariablesClass.updateInvoiceId != 0)
            {
                FrmUpdateInvo frmUpdateInvo = new FrmUpdateInvo();
                frmUpdateInvo.ShowDialog();
            }

        }
        private void btnPrintSearch_Click(object sender, EventArgs e)
        {

            if (!FunctionsClass.dshasTablesAndData(dsInvoReports))
            {
                FunctionsClass.msgTool("لا توجد بيانات في القائمة للطباعة", 0);
                return;
            }

            //FrmPrint f = new FrmPrint();
            //CRInvoReport c = new CRInvoReport();

            //c.SetDataSource(dsInvoReports.Tables[0]);
            //f.crystalReportViewer1.ReportSource = c;
            //c.SetParameterValue(0, Settings.Default.Company);
            //c.SetParameterValue(1, VariablesClass.userName);
            //f.crystalReportViewer1.Refresh();
            //f.Text = "طباعة القائمة ";
            //f.crystalReportViewer1.Zoom(100);
            //f.WindowState = FormWindowState.Maximized;
            //f.Show();
        }
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            //if (dgvInvoReports.Rows.Count == 0)
            //{
            //    FunctionsClass.msgTool("لا يمكن تصدير تقرير فارغ", 2);
            //    return;
            //}

            //// يجب أن نضيف هذاالريفرينس حتى يقبل المكتبة التي فوق
            //// References->Add References->Extensions->Microsoft.Office.Interop.Excel


            //progressBar1.Maximum = dgvInvoReports.RowCount;
            //progressBar1.Value = 0;
            //// ---------------مجموعة تعريفات لتكوين الملفات-------------------------------------
            //////var App = new Microsoft.Office.Interop.Excel.Application();
            //////Microsoft.Office.Interop.Excel.Workbook WorkBook;
            //////Microsoft.Office.Interop.Excel.Worksheet WorkSheet;
            ////object MisValue = Missing.Value;
            ////WorkBook = App.Workbooks.Add(MisValue);
            ////WorkSheet = WorkBook.Sheets["sheet1"];
            //// ----------------------------------------------------

            //SaveFileDialog sfd = new SaveFileDialog();
            //sfd.Filter = "Excel Files | *.xlsx";
            //if (sfd.ShowDialog() == DialogResult.OK)
            //{
            //    progressBar1.Visible = true;
            //    WorkBook.SaveAs(sfd.FileName);

            //    foreach (DataGridViewColumn column in dgvInvoReports.Columns) // تكوين الهيدر أو الأعمدة
            //    {
            //        if (column.Index != 0)
            //            WorkSheet.Cells[1, column.Index].Value = column.HeaderText;
            //    }

            //    for (int i = 0; i <= dgvInvoReports.Rows.Count - 1; i++) // تصدير الصفوف
            //    {
            //        int columnIndex = 1;
            //        while (columnIndex != dgvInvoReports.Columns.Count)
            //        {
            //            // يبدأ بالعمود رقم اثنان أي العمود الثاني لأن العمود 1 محجوز والعد يبدأ من 1 وليس من الصفر
            //            WorkSheet.Cells[i + 2, columnIndex].Value = dgvInvoReports.Rows[i].Cells[columnIndex].Value.ToString(); // يبدأ بالخلية رقم 1 لأن رقم 0 هي المعرف Id
            //            columnIndex++;
            //        }
            //        progressBar1.Value = i;
            //    }
            //    WorkSheet.Cells[dgvInvoReports.Rows.Count + 4, 4].Value = "الإجمالي";// عدد الصفوف و الهيدر لانه يعتبره صف لهذا تكون 3+1
            //    WorkSheet.Cells[dgvInvoReports.Rows.Count + 5, 4].Value = Convert.ToDouble(txtTotal.Text); // الإجمالي

            //    progressBar1.Value = dgvInvoReports.RowCount;
            //    WorkBook.Save();
            //    WorkBook.Close();
            //    App.Quit();
            //    MessageBox.Show("تم تصدير البيانات الى ملف أكسل بنجاح", "تصدير بيانات", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    progressBar1.Visible = false;

            //}
            // لو كانت DGV فارغة يكوّن الهيدر فقط
        }











    }
}
