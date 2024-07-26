using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalesProject.Classes;
using Microsoft.Office.Interop;
using SalesProject.Reports;

namespace SalesProject.Forms
{
    public partial class FrmInvoReport : Form
    {
        public FrmInvoReport()
        {
            InitializeComponent();
        }
        private DataSet dsInvoReport = new DataSet(), dsCustomer = new DataSet();
        private int cr;
        private ResizeControls r = new ResizeControls();

        private void FrmInvoReport_Load(object sender, EventArgs e)
        {
            getCustomer();
            txtInvoNum.Select();

            dtpDateFrom.CustomFormat = Properties.Settings.Default.DateFormat;
            dtpDateTo.CustomFormat = Properties.Settings.Default.DateFormat;
            dgvInvoReport.ColumnHeadersDefaultCellStyle.Font = new Font("Hacen Saudi Arabia", 10, FontStyle.Regular);

        }
        private void getCustomer()
        {
            var sqlCon = new SQLConClass();
            dsCustomer = sqlCon.SelectData("SELECT Id,Name FROM TblCustomers WHERE Del=0 ORDER BY Name", 0, default);
            if (FunctionsClass.dsHasTables(dsCustomer))
            {
                cmbName.DataSource = dsCustomer.Tables[0];
                cmbName.DisplayMember = "Name";
                cmbName.ValueMember = "Id";
                cmbName.SelectedIndex = -1;
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            FunctionsClass.clear(grpSearch);
            dsInvoReport.Clear();
            dgvInvoReport.Rows.Clear();
            cr = -1;
            VariablesClass.updateInvoiceId = 0;   // Public int updateInvoiceId 
            txtTotal.Text = String.Empty;
            progressBar1.Value = 0;
            chkInvoNum.Checked = true;
            FrmInvoReport_Load(sender, e);
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
            {
                txtInvoNum.Enabled = false;
            }
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
            {
                grpDate.Enabled = false;
            }
        }

        private void txtInvoNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        public  void btnSearch_Click(object sender, EventArgs e)
        {
            dgvInvoReport.Rows.Clear();
            VariablesClass.updateInvoiceId = 0;
            progressBar1.Value = 0;
            if (chkInvoNum.Checked == true) // Num
            {
                if (txtInvoNum.Text.Trim() == "")
                {
                    FunctionsClass.msgTool("الرجاء ادخال رقم الفاتورة", 0);
                    return;
                }
                var sqlCon = new SQLConClass();
                SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Num", Convert.ToInt32(txtInvoNum.Text.Trim())) };
                dsInvoReport = sqlCon.SelectData("FindInvoNum", 1, param);
            }

            else if (chkName.Checked == true & chkDate.Checked == false) // Name
            {
                if (cmbName.SelectedValue == null)
                {
                    MessageBox.Show("الرجاء اختيار اسم من القائمة", "ادخال بيانات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var sqlCon = new SQLConClass();
                SqlParameter[] param = new SqlParameter[] { new SqlParameter("@CustomerID", cmbName.SelectedValue) };
                dsInvoReport = sqlCon.SelectData("FindInvoCustomer", 1, param);
            }

            else if (chkName.Checked == false & chkDate.Checked == true) // Date
            {
                var sqlCon = new SQLConClass();
                DateTime dateTimeFrom = Convert.ToDateTime(dtpDateFrom.Value.Date +  dtpTimeFrom.Value.TimeOfDay);
                DateTime dateTimeTo = Convert.ToDateTime(dtpDateTo.Value.Date + dtpTimeTo.Value.TimeOfDay);
                SqlParameter[] param = new SqlParameter[] { new SqlParameter("@FromDate", dateTimeFrom), new SqlParameter("@ToDate", dateTimeTo) };
                dsInvoReport = sqlCon.SelectData("FindInvoDate", 1, param);
            }
            else if (chkName.Checked == true & chkDate.Checked == true) // Name+Date
            {
                if (cmbName.SelectedValue == null)
                {
                    MessageBox.Show("الرجاء اختيار اسم من القائمة", "ادخال بيانات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var sqlCon = new SQLConClass();
                DateTime dateTimeFrom = Convert.ToDateTime(dtpDateFrom.Value.Date + dtpTimeFrom.Value.TimeOfDay);
                DateTime dateTimeTo = Convert.ToDateTime(dtpDateTo.Value.Date + dtpTimeTo.Value.TimeOfDay);
                SqlParameter[] param = new SqlParameter[] { new SqlParameter("@FromDate", dateTimeFrom), new SqlParameter("@ToDate", dateTimeTo), new SqlParameter("@CustomerID", cmbName.SelectedValue) };
                //dsInvoReport = sqlCon.SelectData("FindInvoDateCustomerView", 1, param);
                dsInvoReport = sqlCon.SelectData("SELECT * from InvoReportView where CustomerID=@CustomerID AND  InvoDate BETWEEN  @FromDate AND @ToDate", 0, param);
            }
            fillDGVReport();
            dgvInvoReport.ClearSelection();
        }
        private void fillDGVReport()
        {
            if (!FunctionsClass.dsHasTables(dsInvoReport))
                return;
            if (dsInvoReport.Tables[0].Rows.Count == 0)
            {
                FunctionsClass.msgTool("لا توجد نتائج لهذا البحث", 0);
                txtTotal.Text = "";
                return;
            }
            txtTotal.Text ="0";
            progressBar1.Minimum = 0;
            progressBar1.Maximum = dsInvoReport.Tables[0].Rows.Count;
            for (int i = 0; i <= dsInvoReport.Tables[0].Rows.Count - 1; i++)
            {

                {
                    var row = dsInvoReport.Tables[0].Rows[i];
                    dgvInvoReport.Rows.Add();
                    dgvInvoReport.Rows[i].Cells[0].Value = row.ItemArray[0];
                    dgvInvoReport.Rows[i].Cells[1].Value = i + 1;
                    dgvInvoReport.Rows[i].Cells[2].Value = row.ItemArray[1];
                    dgvInvoReport.Rows[i].Cells[3].Value = row.ItemArray[2];
                    dgvInvoReport.Rows[i].Cells[4].Value = row.ItemArray[3];
                    dgvInvoReport.Rows[i].Cells[5].Value = row.ItemArray[4];
                    dgvInvoReport.Rows[i].Cells[6].Value = row.ItemArray[5];
                    txtTotal.Text = (Convert.ToInt32(txtTotal.Text) + Convert.ToInt32(row.ItemArray[3])).ToString();
                }
                progressBar1.Value += 1;
            }
        }
        private void btnDelInvo_Click(object sender, EventArgs e)
        {
            if (VariablesClass.updateInvoiceId == 0)
            {
                MessageBox.Show("الرجاء تحديد فاتورة من القائمة", "حذف بيانات", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (MessageBox.Show("هل أنت متأكد تريد حذف الفاتورة رقم:    " + dgvInvoReport.Rows[cr].Cells[2].Value, "تأكيد حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                var sqlCon = new SQLConClass();
                SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Id", VariablesClass.updateInvoiceId) };

                if (sqlCon.CMDExecute("UPDATE TblInvoices SET Del=1 WHERE Id=@Id", 0, param) > 0)
                {
                    MessageBox.Show("تم حذف الفاتورة لإسترجاعها من شاشة إدارة البيانات المحذوفة", "حذف فاتورة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvInvoReport.Rows.Remove(dgvInvoReport.Rows[cr]);
                    total();
                    sequence();
                }
            }
        }

        private void sequence()
        {
            dgvInvoReport.Tag = 1;
            foreach (DataGridViewRow row in dgvInvoReport.Rows)
            {
                row.Cells[1].Value = dgvInvoReport.Tag;
                dgvInvoReport.Tag = Convert.ToInt32(dgvInvoReport.Tag) + 1;
            }
        }

        private void total()
        {
            double total = 0;
            txtTotal.Text = total.ToString();

            foreach (DataGridViewRow row in dgvInvoReport.Rows)
            {
                total = total + Convert.ToDouble(row.Cells[6].Value);
            }
            txtTotal.Text = String.Format(total.ToString(), "0.000");

        }



        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            if (txtTotal.Text != String.Empty)
            {
                lblTotInvoReport.Text = MdlNumbers.NoToTxt(Convert.ToDouble(txtTotal.Text), "دينار", "درهم", true);
            }
            else
            {
                lblTotInvoReport.Text = String.Empty;
            }
        }

        //----------------------------------------------
        private void dgvInvoReport_Click(object sender, EventArgs e)
        {
            if (FunctionsClass.checkDGVError(dgvInvoReport) == true)
                return;

            cr = dgvInvoReport.CurrentRow.Index;
            VariablesClass.updateInvoiceId = Convert.ToInt32(dgvInvoReport.Rows[cr].Cells[0].Value);
        }
        private void dgvInvoReport_DoubleClick(object sender, EventArgs e)
        {
            btnOpenInvoice_Click(sender, e);
        }
        private void btnOpenInvoice_Click(object sender, EventArgs e)
        {
            if (VariablesClass.updateInvoiceId != 0)
            {
                FrmUpdateInvo frmUpdateInvo = Application.OpenForms.OfType<FrmUpdateInvo>().FirstOrDefault();
                if (frmUpdateInvo == null)
                {
                    frmUpdateInvo = new FrmUpdateInvo();
                }
                frmUpdateInvo.ShowDialog();
            }

        }

        private void btnPrintSearch_Click(object sender, EventArgs e)
        {
            if (dsInvoReport.Tables.Count == 0)
                return;
            var F = new FrmPrint();
            var C = new CRPrintInvoReport();

            C.SetDataSource(dsInvoReport.Tables[0]);
            F.crystalReportViewer1.ReportSource = C;
            F.crystalReportViewer1.Refresh();
            F.Text = "طباعة القائمة ";
            F.crystalReportViewer1.Zoom(100);
            F.WindowState = FormWindowState.Maximized;
            F.Show();
        }
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvInvoReport.Rows.Count == 0)
            {
                FunctionsClass.msgTool("لا يمكن تصدير تقرير فارغ", 2);
                return;
            }

            // يجب أن نضيف هذاالريفرينس حتى يقبل المكتبة التي فوق
            // References->Add References->Extensions->Microsoft.Office.Interop.Excel


            progressBar1.Maximum = dgvInvoReport.RowCount;
            progressBar1.Value = 0;
            // ---------------مجموعة تعريفات لتكوين الملفات-------------------------------------
            var App = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook WorkBook;
            Microsoft.Office.Interop.Excel.Worksheet WorkSheet;
            object MisValue = Missing.Value;
            WorkBook = App.Workbooks.Add(MisValue);
            WorkSheet = WorkBook.Sheets["sheet1"];
            // ----------------------------------------------------


            var SFD = new SaveFileDialog();
            SFD.Filter = "Excel Files | *.xlsx";
            if (SFD.ShowDialog() == DialogResult.OK)
            {

                WorkBook.SaveAs(SFD.FileName);

                foreach (DataGridViewColumn column in dgvInvoReport.Columns) // تكوين الهيدر أو الأعمدة
                {

                    if (Convert.ToInt32((column.Index)) != 0)
                    {
                        WorkSheet.Cells[1, column.Index].Value = column.HeaderText;
                    }
                }

                for (int i = 0; i <=  dgvInvoReport.Rows.Count - 1; i++) // تصدير الصفوف
                {
                    int columnIndex = 1;
                    while (columnIndex != dgvInvoReport.Columns.Count)
                    {
                        WorkSheet.Cells[i + 2, columnIndex].Value = dgvInvoReport.Rows[i].Cells[columnIndex].Value.ToString();
                        columnIndex += 1;
                    }
                    progressBar1.Value = i;
                }
                WorkSheet.Cells[dgvInvoReport.Rows.Count + 4, 4].Value = "الإجمالي";
                WorkSheet.Cells[dgvInvoReport.Rows.Count + 5, 4].Value = Convert.ToDouble(txtTotal.Text); // الإجمالي

                progressBar1.Value = dgvInvoReport.RowCount;
                WorkBook.Save();
                WorkBook.Close();
                App.Quit();
                MessageBox.Show("تم تصدير البيانات الى ملف أكسل بنجاح", "تصدير بيانات", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // لو كانت DGV فارغة يكوّن الهيدر فقط
        }

        private void FrmInvoReport_Resize(object sender, EventArgs e)
        {
            r.ResizeControl();
        }
        private void FrmInvoReport_HandleCreated(object sender, EventArgs e)
        {
            r.Container = this;
        }


        private void FrmInvoReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            FunctionsClass.userTrafficRegister(this.Name, false);

        }

    }
}
