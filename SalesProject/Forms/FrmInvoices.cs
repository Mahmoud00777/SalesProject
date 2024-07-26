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
    public partial class FrmInvoices : Form
    {
        public FrmInvoices()
        {
            InitializeComponent();
        }

        bool selectAllText;
        string swText;
        int cr = -1;
        DataSet ds = new DataSet(), dsItem = new DataSet(), dsStore = new DataSet(), dsPrint = new DataSet();
        ResizeControls r = new ResizeControls();

        private void FrmInvoices_Resize(object sender, EventArgs e)
        {
            r.ResizeControl();
        }
        private void FrmInvoices_HandleCreated(object sender, EventArgs e)
        {
            r.Container = this;
        }
        private void FrmInvoices_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void FrmInvoices_Load(object sender, EventArgs e)
        {
            getFillData();
            dgvItems.ColumnHeadersDefaultCellStyle.Font = new Font("Hacen Saudi Arabia", 10, FontStyle.Regular);
            dtpDate.CustomFormat = Settings.Default.DateFormat;
        }
        public void getFillData()
        {
            SQLConClass sqlCon = new SQLConClass();
            ds = sqlCon.selectData("SELECT Id,[Num],[Name] FROM TblItems WHERE Del=0 ORDER BY [Name] SELECT Id,[Name] FROM TblCustomers WHERE Del=0 ORDER BY [Name]", 0, default);
            if (FunctionsClass.dshasTablesAndData(ds))
            {
                cmbItemName.DataSource = ds.Tables[0];
                cmbItemName.DisplayMember = "Name";
                cmbItemName.ValueMember = "Id";
                cmbItemName.SelectedIndex = -1;

                cmbCustomerName.DataSource = ds.Tables[1];
                cmbCustomerName.DisplayMember = "Name";
                cmbCustomerName.ValueMember = "Id";
                cmbCustomerName.SelectedValue = 1; // لا نقوم بتفعيل خاصية Sorted
            }
            else
                this.Close();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            FunctionsClass.clear(grpItem);
            txtItemNum.Clear(); // txtItemNum.Tag = 1;
            FunctionsClass.clear(grpInvoice);
            FunctionsClass.clear(grpQuantity);
            chkDiscount.Checked = false;
            dgvItems.Rows.Clear();
            cr = -1;
            selectAllText = false;
            txtItemNum.Focus();
            dtpDate.Value = DateTime.Now; //timer1
            dsItem.Clear();
            dsStore.Clear();
            getFillData();
        }
        private void txtItemNum_TextChanged(object sender, EventArgs e)
        {
            if (txtItemNum.Text.Trim() == string.Empty)
                clearItem();
        }
        void clearItem()
        {
            dgvItems.ClearSelection(); cr = -1;
            FunctionsClass.clear(grpItem);
            txtInvoiceQuantity.Clear();
        }
        ///---------------------------------------------------------------------------
        private void txtItemNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtItemNum.Text.Trim() == string.Empty)
                return;

            if (e.KeyCode == Keys.Enter)
            {
                // جلب بيانات الصنف من الجدول
                SQLConClass sqlCon = new SQLConClass();
                SQLConClass.sqlQuery = "SELECT TblItems.Id,Num,[Name],Describe,SalePrice,StoreQuantity,Pic,Category,Country,Unit FROM TblItems,TblCategories,TblCountries,TblUnits WHERE TblItems.categoryId=TblCategories.Id and TblItems.CountryId=TblCountries.Id and TblItems.UnitId=TblUnits.Id and TblItems.Del=0 and TblItems.Num=@Num";
                SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Num", txtItemNum.Text.Trim()) };

                dsItem = sqlCon.selectData(SQLConClass.sqlQuery, 0, param);


                if (!FunctionsClass.dshasTablesAndData(dsItem))
                {
                    MessageBox.Show("رقم الصنف غير موجود", "بحث", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtItemNum.SelectAll();
                    txtItemNum.Focus();
                    return;
                }

                // اختبار كمية الصنف في المخزن
                if (Convert.ToInt32(dsItem.Tables[0].Rows[0][5]) <= 0)
                {
                    MessageBox.Show("هذا الصنف نفذ من المخزن الكمية = 0", "نفاذ كمية", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    clearItem();
                    return;
                }
                else
                    txtStoreQuantity.Text = dsItem.Tables[0].Rows[0][5].ToString(); // 10




                // dgv البحث هل الصنف موجود في 
                // ******************************************************************
                foreach (DataGridViewRow row in dgvItems.Rows)
                {
                    if (Convert.ToInt64(txtItemNum.Text.Trim()) == Convert.ToInt64(row.Cells[2].Value))
                    {
                        row.Cells[7].Value = dsItem.Tables[0].Rows[0][5]; // تحديث الكمية في المخزن

                        if (Convert.ToInt32(row.Cells[7].Value) > Convert.ToInt32(row.Cells[4].Value))
                        {
                            row.Cells[4].Value = Convert.ToInt32(row.Cells[4].Value) + 1;
                            row.Cells[6].Value = Convert.ToDouble(row.Cells[4].Value) * Convert.ToDouble(row.Cells[5].Value);
                            txtStoreQuantity.Text = (Convert.ToDouble(row.Cells[7].Value) - Convert.ToDouble(row.Cells[4].Value)).ToString();
                            row.Selected = true;
                            dgvItems.FirstDisplayedScrollingRowIndex = row.Index;
                            cr = row.Index;
                            displayData();
                            total();
                        }
                        else
                        {
                            txtStoreQuantity.Text = "0";
                            MessageBox.Show("هذا الصنف نفذ من المخزن الكمية = 0", "نفاذ كمية", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        txtItemNum.Focus();
                        txtItemNum.SelectAll();
                        return;
                    }
                }
                // ******************************************************************
                // اضافة صف جديد بكمية مبدئية 1 
                {
                    var row = dsItem.Tables[0].Rows[0];

                    dgvItems.Rows.Add(row[0], dgvItems.Rows.Count + 1, row[1], row[2] + "-" + row[3], 1, row[4], Convert.ToDouble(row[4]) * 1, row[5], row[6], row[3], row[7], row[8], row[9]);
                }

                cr = dgvItems.Rows.Count - 1; // آخر صف
                dgvItems.Rows[cr].Selected = true;
                dgvItems.FirstDisplayedScrollingRowIndex = cr;
                displayData();
                total(); // حساب إجمالي الفاتورة

                txtItemNum.SelectAll();
                txtItemNum.Focus();

            }

        }
        private void dgvItems_Click(object sender, EventArgs e)
        {
            if (FunctionsClass.checkDgvError(dgvItems))
                return;

            cr = dgvItems.CurrentRow.Index;
            displayData();
            txtInvoiceQuantity.Focus();
            txtInvoiceQuantity.SelectAll();
        }
        void displayData()
        {
            txtItemNum.Text = dgvItems.Rows[cr].Cells[2].Value.ToString();
            cmbItemName.Text = dgvItems.Rows[cr].Cells[3].Value.ToString().Substring(0, dgvItems.Rows[cr].Cells[3].Value.ToString().IndexOf("-"));
            txtItemDescribe.Text = dgvItems.Rows[cr].Cells[9].Value.ToString();
            txtItemCategory.Text = dgvItems.Rows[cr].Cells[10].Value.ToString();
            txtItemCountry.Text = dgvItems.Rows[cr].Cells[11].Value.ToString();
            txtItemUnit.Text = dgvItems.Rows[cr].Cells[12].Value.ToString();
            txtItemPrice.Text = dgvItems.Rows[cr].Cells[5].Value.ToString();
            txtStoreQuantity.Text = (Convert.ToInt32(dgvItems.Rows[cr].Cells[7].Value) - Convert.ToInt32(dgvItems.Rows[cr].Cells[4].Value)).ToString();
            picItem.Image = (dgvItems.Rows[cr].Cells[8].Value is DBNull) ? null : FunctionsClass.byteToImage((byte[])dgvItems.Rows[cr].Cells[8].Value);

            txtInvoiceQuantity.Text = dgvItems.Rows[cr].Cells[4].Value.ToString();
        }
        void total()
        {
            double total = 0;
            txtTotal.Text = total.ToString();

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                total = total + Convert.ToDouble(row.Cells[6].Value);
            }
            txtTotal.Text = total.ToString("0.000");
            discount();
        }
        void discount()
        {
            if (txtTotal.Text.Trim() == string.Empty)
            {
                txtNet.Clear();
                return;
            }

            double percent;
            double discount;
            double.TryParse(txtdiscount.Text, out discount);


            if (chkDiscount.Checked == true)
                percent = discount;
            else if (Convert.ToDouble(txtTotal.Text) != 0)
                percent = discount / Convert.ToDouble(txtTotal.Text) * 100;
            else
                percent = 0;

            if (percent > Settings.Default.DiscountPercent)
            {
                MessageBox.Show("لقد تجاوزت نسبة التخفيض المحددة من المسؤول", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtdiscount.Clear();
                txtdiscount.Focus();
            }
            else
            {
                double discountVal = Convert.ToDouble(txtTotal.Text) * percent / 100;
                txtNet.Text = (Convert.ToDouble(txtTotal.Text) - discountVal).ToString("0.000");
            }

        }
        private void txtdiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !FunctionsClass.isPositiveRealNum((TextBox)sender, e);
        }
        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            if (txtTotal.Text == string.Empty)
                txtNet.Clear();
        }
        private void chkDiscount_CheckedChanged(object sender, EventArgs e)
        {
            discount();
            txtdiscount.SelectAll();
            txtdiscount.Focus();
        }
        private void txtdiscount_TextChanged(object sender, EventArgs e)
        {
            discount();
        }
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            FrmMain frmMain = Application.OpenForms.OfType<FrmMain>().FirstOrDefault();
            if (frmMain != null)
                frmMain.btnItem.PerformClick();
        }
        private void cmbItemName_TextChanged(object sender, EventArgs e)
        {
            if (cmbItemName.Text.Trim() == string.Empty)
            {
                clearItem();
                txtItemNum.Clear();
            }
        }
        private void cmbItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbItemName_SelectionChangeCommitted(sender, e);
        }
        private void cmbItemName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbItemName.SelectedValue == null)
            {
                MessageBox.Show("اسم الصنف عير موجود", "بحث", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearItem();
                txtItemNum.Clear();
                return;
            }

            DataRow[] itemRows = ds.Tables[0].Select("Id=" + cmbItemName.SelectedValue);
            if (itemRows.Length > 0)
            {
                txtItemNum.Text = itemRows[0][1].ToString();
                txtItemNum.Focus();


                SendKeys.SendWait("{ENTER}");
                return;
            }
        }
        private void txtItemNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !FunctionsClass.isPositiveIntNum(e); // txtInvoiceQuantity
        }
        private void txtNet_TextChanged(object sender, EventArgs e)
        {
            if (txtNet.Text == string.Empty)
            {
                lblNet.Text = string.Empty;
                return;
            }

            double num;
            double.TryParse(txtNet.Text, out num);

            lblNet.Text = NumbersClass.NoToTxt(num, "دينار", "درهم", true).ToString();
        }
        private void txtInvoNum_TextChanged(object sender, EventArgs e)
        {
            if (txtInvoNum.Text.Trim() == "")
                lblBarcode.Text = "";
            else
                lblBarcode.Text = string.Format(txtInvoNum.Text, "*000000*");
        }
        private void btnUpdateQuantity_Click(object sender, EventArgs e)
        {
            int invoiceQuantity;
            int.TryParse(txtInvoiceQuantity.Text, out invoiceQuantity);
            if (cr != -1 & invoiceQuantity > 0)
            {
                getStoreQuantity();

                if (Convert.ToInt32(dgvItems.Rows[cr].Cells[7].Value) >= Convert.ToInt32(txtInvoiceQuantity.Text))
                {
                    dgvItems.Rows[cr].Cells[4].Value = Convert.ToInt32(txtInvoiceQuantity.Text);
                    setNewQuantity();
                }
                else
                    MessageBox.Show("الكمية المطلوبة أكبر من الكمية الموجودة في المخزن", "نفاذ كمية", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                selectAll(txtInvoiceQuantity);
            }

        }
        void getStoreQuantity()
        {
            SQLConClass sqlCon = new SQLConClass();
            dsItem = sqlCon.selectData("SELECT StoreQuantity,SalePrice FROM TblItems WHERE Num=" + dgvItems.Rows[cr].Cells[2].Value.ToString(), 0, default);
            if (FunctionsClass.dshasTablesAndData(dsItem))
            {
                dgvItems.Rows[cr].Cells[7].Value = (int)dsItem.Tables[0].Rows[0][0];
                dgvItems.Rows[cr].Cells[5].Value = (double)dsItem.Tables[0].Rows[0][1];
            }

            if (Convert.ToInt32(dgvItems.Rows[cr].Cells[4].Value) > Convert.ToInt32(dgvItems.Rows[cr].Cells[7].Value))
                dgvItems.Rows[cr].Cells[4].Value = dgvItems.Rows[cr].Cells[7].Value;


            setNewQuantity();
        }
        void setNewQuantity()
        {
            var row = dgvItems.Rows[cr];
            txtStoreQuantity.Text = (Convert.ToInt32(row.Cells[7].Value) - Convert.ToInt32(row.Cells[4].Value)).ToString();
            row.Cells[6].Value = (Convert.ToDouble(row.Cells[4].Value) * Convert.ToDouble(row.Cells[5].Value)).ToString();

            total();
        }
        private void btnAddQuantity_Click(object sender, EventArgs e)
        {
            int invoiceQuantity;
            int.TryParse(txtInvoiceQuantity.Text, out invoiceQuantity);
            if (cr != -1 & invoiceQuantity > 0)
            {
                getStoreQuantity();

                if (Convert.ToInt32(dgvItems.Rows[cr].Cells[7].Value) >= Convert.ToInt32(dgvItems.Rows[cr].Cells[4].Value) + Convert.ToInt32(txtInvoiceQuantity.Text))
                {
                    dgvItems.Rows[cr].Cells[4].Value = Convert.ToDouble(dgvItems.Rows[cr].Cells[4].Value) + Convert.ToDouble(txtInvoiceQuantity.Text);
                    txtInvoiceQuantity.Text = dgvItems.Rows[cr].Cells[4].Value.ToString();
                    setNewQuantity();
                }
                else
                    MessageBox.Show("الكمية المطلوبة أكبر من الكمية الموجودة في المخزن", "نفاذ كمية", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                selectAll(txtInvoiceQuantity);
            }
        }
        private void btnSubtractQuantity_Click(object sender, EventArgs e)
        {
            int invoiceQuantity;
            int.TryParse(txtInvoiceQuantity.Text, out invoiceQuantity);
            if (cr != -1 & invoiceQuantity > 0)
            {
                getStoreQuantity();

                if (Convert.ToInt32(txtInvoiceQuantity.Text) >= Convert.ToInt32(dgvItems.Rows[cr].Cells[4].Value))
                {
                    dgvItems.Rows.Remove(dgvItems.Rows[cr]);
                    FunctionsClass.clear(grpItem);
                    FunctionsClass.clear(grpQuantity);
                    cr = -1;
                    sequence();
                }
                else
                {
                    dgvItems.Rows[cr].Cells[4].Value = Convert.ToInt32(dgvItems.Rows[cr].Cells[4].Value) - Convert.ToInt32(txtInvoiceQuantity.Text);
                    txtInvoiceQuantity.Text = dgvItems.Rows[cr].Cells[4].Value.ToString();

                    setNewQuantity();
                    selectAll(txtInvoiceQuantity);
                }
                total();
            }

        }
        void sequence()
        {
            dgvItems.Tag = 1;
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                row.Cells[1].Value = dgvItems.Tag;
                dgvItems.Tag = Convert.ToInt32(dgvItems.Tag) + 1;
            }
        }
        private void delFromInvo_Click(object sender, EventArgs e)
        {
            if (cr != -1)
            {
                txtInvoiceQuantity.Text = dgvItems.Rows[cr].Cells[4].Value.ToString();
                btnSubtractQuantity.PerformClick();
            }
        }
        //-------------------------TouchScreen--------------------------------------
        Control focusedControl;
        private void txtItemNum_Enter(object sender, EventArgs e)
        {
            focusedControl = (Control)sender;
        }
        private void txtItemNum_Click(object sender, EventArgs e)
        {
            selectAll((TextBox)sender);
        }
        void selectAll(TextBox sender)
        {
            sender.Focus();
            sender.SelectAll();
            selectAllText = true;
        }
        private void b1_Click(object sender, EventArgs e)
        {
            TouchScreenButton(((Button)sender).Text);
        }
        void TouchScreenButton(string number)
        {
            if (focusedControl != null)
            {
                if (selectAllText == true)
                {
                    focusedControl.Text = number;
                    selectAllText = false;
                }
                else
                    focusedControl.Text += number;
            }
        }
        private void bC_Click(object sender, EventArgs e)
        {
            if (focusedControl != null)
                if (selectAllText == true)
                    focusedControl.Text = "";
                else if (focusedControl.Text.Length > 0)
                    focusedControl.Text = focusedControl.Text.Substring(0, focusedControl.Text.Length - 1);
        }
        private void bEnter_Click(object sender, EventArgs e)
        {
            if (focusedControl != null)
                if (focusedControl.Name == "txtItemNum")
                {
                    focusedControl.Focus();
                    SendKeys.Send("{ENTER}");
                }
        }
        //--------------------------------------------------------------------
        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            if (cmbCustomerName.SelectedValue != null | cmbCustomerName.Text == "")
                return;

            FrmCustomers frmCustomer = Application.OpenForms.OfType<FrmCustomers>().FirstOrDefault();
            if (frmCustomer == null)
                frmCustomer = new FrmCustomers();

            frmCustomer.btnRefresh_Click(sender, e);
            frmCustomer.cmbCustomerName.Text = cmbCustomerName.Text;
            frmCustomer.btnSaveCustomer_Click(sender, e); // public
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtInvoNum.Text != string.Empty)
            {
                FunctionsClass.msgTool("تم حفظ الفاتورة مسبقاً", 2);
                return;
            }

            if (dgvItems.Rows.Count == 0)
            {
                FunctionsClass.msgTool("لا يمكن حفظ فاتورة فارغة", 2);
                return;
            }

            if (cmbCustomerName.Text == string.Empty)
            {
                MessageBox.Show("الرجاء اختيار اسم العميل", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbCustomerName.Focus();
                return;
            }

            if (cmbCustomerName.SelectedIndex == -1 & cmbCustomerName.Text != string.Empty)
            {
                if (MessageBox.Show("اسم العميل غير محفوظ هل تريد حفظه في المنظومة ؟", "ادخال بيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btnSaveCustomer_Click(sender, e);
                    return;
                }

                else
                    return;
            }

            var dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] {
                new DataColumn("itemId", typeof(int)),
                new DataColumn("ItemQuantity", typeof(int)),
                new DataColumn("ItemPrice", typeof(double))
            });


            foreach (DataGridViewRow row in dgvItems.Rows)
                dt.Rows.Add(row.Cells[0].Value, row.Cells[4].Value, row.Cells[5].Value);

            DateTime dateAndTime = Convert.ToDateTime(dtpDate.Value.Date + dtpTime.Value.TimeOfDay);

            SQLConClass sqlCon = new SQLConClass();
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@InvoDate", dateAndTime),
                new SqlParameter("@InvoDiscount", Convert.ToDouble(txtTotal.Text) - Convert.ToDouble(txtNet.Text)),
                new SqlParameter("@CustomerId", cmbCustomerName.SelectedValue),
                new SqlParameter("@UserId", VariablesClass.userId),
                new SqlParameter("@Content", dt) };
            dsStore = sqlCon.cmdExecuteData("InsertInvoice", param);

            switch (VariablesClass.Save)
            {
                case 1:
                    {
                        txtInvoNum.Text = Convert.ToInt64(dsStore.Tables[0].Rows[0][0]).ToString("000000");
                        break;
                    }
                case 2:
                    {
                        FunctionsClass.msgTool("لم يتم حفظ الفاتورة أحد الأصناف نفذ من المخزن ", 0);
                        showStore(dsStore);
                        break;
                    }
            }
        }
        private void showStore(DataSet dsStore)
        {
            pnlStoreShortage.Left = (this.Width - pnlStoreShortage.Width) / 2;
            pnlStoreShortage.Top = (this.Height - pnlStoreShortage.Height) / 2;
            pnlStoreShortage.Visible = true;
            dgvStoreShortage.DataSource = dsStore.Tables[0];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FrmReceipt frm = new FrmReceipt();
            frm.ShowDialog();   
        }

        private void lblNet_Click(object sender, EventArgs e)
        {

        }

        private void picClose_Click(object sender, EventArgs e)
        {
            pnlStoreShortage.Visible = false;
        }
        private void FrmInvoices_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                btnSave.PerformClick();
            if (e.KeyCode == Keys.F2)
                btnPrint.PerformClick();
            if (e.KeyCode == Keys.F5)
                btnNew.PerformClick();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            FrmPrint f = new FrmPrint();
           //// CRPrintInvo c = new CRPrintInvo();
           // if (FunctionsClass.dshasTablesAndData(dsStore) & VariablesClass.Save == 1)
           // {
           //     c.SetDataSource(dsStore.Tables[1]);
           //     c.SetParameterValue("Company", Settings.Default.Company);
           //     f.crystalReportViewer1.ReportSource = c;

           //     f.crystalReportViewer1.Refresh();
           //     f.Text = "طباعة الفاتورة ";
           //     f.crystalReportViewer1.Zoom(100);
           //     f.WindowState = FormWindowState.Maximized;
           //     f.Show();
           // }
           // else
           //     FunctionsClass.msgTool("يرجى حفظ الفاتورة قبل الطباعة", 2);
        }
    }













}


