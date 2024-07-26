using SalesProject.Classes;
using SalesProject.Reports;
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
    public partial class FrmInvoice : Form
    {
        private bool selectAllText;
        private string swText;
        private int cr = -1;
        private DataSet ds = new DataSet(), dsItem = new DataSet(), dsStore = new DataSet(), dsPrint = new DataSet();
        private ResizeControls r = new ResizeControls();
        public FrmInvoice()
        {
            InitializeComponent();
        }
        private void FrmInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                btnSave.PerformClick();
            if (e.KeyCode == Keys.F2)
                btnPrint.PerformClick();
            if (e.KeyCode == Keys.F5)
                btnNew.PerformClick();
        }

        private void FrmInvoice_Load(object sender, EventArgs e)
        {
            getData();
            dgvItems.ColumnHeadersDefaultCellStyle.Font = new Font("Hacen Saudi Arabia", 10, FontStyle.Regular);
            dtpDate.CustomFormat = Properties.Settings.Default.DateFormat;
        }

        public void getData()
        {
            var sqlCon = new SQLConClass();
            ds = sqlCon.SelectData("SELECT Id,[Num],[Name] FROM TblItems WHERE Del=0 ORDER BY [Name] SELECT Id,[Name] FROM TblCustomers WHERE Del=0 ORDER BY [Name]", 0, default);
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
            dtpDate.Value = DateTime.Now;
            dsItem.Clear();
            dsStore.Clear();
            getData();
        }
        private void txtItemNum_TextChanged(object sender, EventArgs e)
        {
            if (txtItemNum.Text.Trim() == String.Empty)
                clearItem();
        }
        private void clearItem()
        {
            dgvItems.ClearSelection();
            cr = -1;
            FunctionsClass.clear(grpItem);
            txtInvoiceQuantity.Clear();
        }
        private void txtItemNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtItemNum.Text.Trim() == String.Empty )
            {
                return;
            }

            if (e.KeyCode == Keys.Enter)
            {
                // جلب بيانات الصنف من الجدول
                var sqlCon = new SQLConClass();
                ConClass.sqlQuery = "SELECT TblItems.Id,Num,[Name],Describe,SalePrice,StoreQuantity,Pic,Category,Country,Unit FROM TblItems,TblCategories,TblCountries,TblUnits WHERE TblItems.categoryId=TblCategories.Id and TblItems.CountryID=TblCountries.Id and TblItems.UnitID=TblUnits.Id and TblItems.Del=0 and TblItems.[Num]=@Num";
                SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Num", txtItemNum.Text.Trim()) };

                dsItem = sqlCon.SelectData(ConClass.sqlQuery, 0, param);


                if (!FunctionsClass.dshasTablesAndData(dsItem))
                {
                    MessageBox.Show("رقم الصنف غير موجود", "بحث", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtItemNum.SelectAll();
                    txtItemNum.Focus();
                    return;
                }

                // اختبار كمية الصنف في المخزن
                if (Convert.ToInt32( dsItem.Tables[0].Rows[0][5]) <= 0)
                {
                    MessageBox.Show("هذا الصنف نفذ من المخزن الكمية = 0", "نفاذ كمية", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    clearItem();
                    return;
                }
                else
                {
                    txtStoreQuantity.Text = dsItem.Tables[0].Rows[0][5].ToString();
                } // 10

                // ----------------------------------------------------------------------------------
                // البحث عن الصنف هل موجود في DGV مسبقا
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
                            txtStoreQuantity.Text = 0.ToString();
                            MessageBox.Show("هذا الصنف نفذ من المخزن الكمية = 0", "نفاذ كمية", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        txtItemNum.Focus();
                        txtItemNum.SelectAll();
                        return;
                    }
                }

                // ******************************************************************---------------------
                // اضافة صف جديد بكمية مبدئية 1 
                {
                    var row = dsItem.Tables[0].Rows[0];
                    dgvItems.Rows.Add(row.ItemArray[0], dgvItems.Rows.Count + 1, row.ItemArray[1], row.ItemArray[2] + "-" + row.ItemArray[3], 1, row.ItemArray[4], Convert.ToDouble(row.ItemArray[4]) * 1, row.ItemArray[5], row.ItemArray[6], row.ItemArray[3], row.ItemArray[7], row.ItemArray[8], row.ItemArray[9]);
                }

                cr = dgvItems.Rows.Count - 1;
                dgvItems.Rows[cr].Selected = true;
                dgvItems.FirstDisplayedScrollingRowIndex = cr;
                displayData();
                total(); // حساب إجمالي الفاتورة

                txtItemNum.SelectAll();
                txtItemNum.Focus();

            }
        }

        private void displayData()
        {
            {
            
                txtItemNum.Text = dgvItems.Rows[cr].Cells[2].Value.ToString();
                cmbItemName.Text = dgvItems.Rows[cr].Cells[3].Value.ToString().Substring(0, dgvItems.Rows[cr].Cells[3].Value.ToString().IndexOf("-"));
                txtItemDescribe.Text = dgvItems.Rows[cr].Cells[9].Value.ToString(); ;
                txtItemCategory.Text = dgvItems.Rows[cr].Cells[10].Value.ToString(); ;
                txtItemCountry.Text = dgvItems.Rows[cr].Cells[11].Value.ToString(); ;
                txtItemUnit.Text = dgvItems.Rows[cr].Cells[12].Value.ToString(); ;
                txtItemPrice.Text = dgvItems.Rows[cr].Cells[5].Value.ToString(); ;
                txtStoreQuantity.Text = (Convert.ToInt32(dgvItems.Rows[cr].Cells[7].Value) - Convert.ToInt32(dgvItems.Rows[cr].Cells[4].Value)).ToString();
                if (!(dgvItems.Rows[cr].Cells[8].Value is DBNull))
                {
                    picItem.Image = FunctionsClass.byteToImage((byte[])dgvItems.Rows[cr].Cells[8].Value);
                }
                else
                {
                    picItem.Image = null;
                }
                txtInvoiceQuantity.Text = dgvItems.Rows[cr].Cells[4].Value.ToString();
            }
        }
        private void dgvItems_Click(object sender, EventArgs e)
        {
            if (FunctionsClass.checkDGVError(dgvItems) == true)
                return;

            cr = dgvItems.CurrentRow.Index;
            displayData();
            txtInvoiceQuantity.Focus();
            txtInvoiceQuantity.SelectAll();
        }

        private void total()
        {
            double total = 0;
            txtTotal.Text = total.ToString();

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                total = total + Convert.ToDouble(row.Cells[6].Value);
            }
            txtTotal.Text = String.Format(total.ToString(), "0.000");
            discount();
        }

        private void discount()
        {
            if (txtTotal.Text.Trim() == String.Empty)
            {
                txtNet.Text = String.Empty;
                return;
            }

            double percent;
            double discount;
            bool result;
            result = double.TryParse(txtdiscount.Text, out discount);
            if (result == false)
            {
                discount = 0;
            }
            if (chkDiscount.Checked == true)
            {
                percent = discount;
            }
            else
            {
                percent = discount / Convert.ToDouble(txtTotal.Text) * 100;
            }




            if (percent > Properties.Settings.Default.DiscountPercent)
            {
                MessageBox.Show("لقد تجاوزت نسبة التخفيض المحددة من المسؤول", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtdiscount.Text = String.Empty;
                txtdiscount.Focus();
            }
            else
            {
                double discountVal = Convert.ToDouble(txtTotal.Text) * percent / 100;
                txtNet.Text = String.Format((Convert.ToDouble(txtTotal.Text) - discountVal).ToString(), "0.000");
            }
        }
        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            if (txtTotal.Text == String.Empty)
                txtNet.Text = String.Empty;
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

        //-------------------------------------------------------------------------
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            FrmMain frmMain = Application.OpenForms.OfType<FrmMain>().FirstOrDefault();
            if (frmMain == null)
            {
                frmMain = new FrmMain();
            }
            frmMain.btnItem.PerformClick();
        }

        private void cmbItemName_TextChanged(object sender, EventArgs e)
        {
            if (cmbItemName.Text.Trim() == String.Empty)
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

        //-------------------------------------------------------------------------
        private void txtNet_TextChanged(object sender, EventArgs e)
        {
            if (txtNet.Text != "")
            {
                lblNet.Text = MdlNumbers.NoToTxt(Convert.ToDouble(txtNet.Text), "دينار", "درهم", true).ToString();
            }
            else
            {
                lblNet.Text = "";
            }
        }
        private void txtInvoNum_TextChanged(object sender, EventArgs e)
        {
            if (txtInvoNum.Text.Trim() == "")
            {
                lblBarcode.Text = "";
            }
            else
            {
                lblBarcode.Text = String.Format(txtInvoNum.Text, "*000000*");
            }
        }
        //------------------------------------------------------------------------
        private void btnUpdateQuantity_Click(object sender, EventArgs e)
        {
            if (cr != -1 & Convert.ToInt64(txtInvoiceQuantity.Text) > 0)
            {
                if (Convert.ToInt32(dgvItems.Rows[cr].Cells[7].Value) >= Convert.ToInt32(txtInvoiceQuantity.Text))
                {
                    dgvItems.Rows[cr].Cells[4].Value = Convert.ToInt64(txtInvoiceQuantity.Text);
                    setNewQuantity();
                }
                else
                {
                    MessageBox.Show("الكمية المطلوبة أكبر من الكمية الموجودة في المخزن", "نفاذ كمية", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtInvoiceQuantity.SelectAll();
                    txtInvoiceQuantity.Focus();
                }
            }
        }
        private void setNewQuantity()
        {
            txtStoreQuantity.Text = (Convert.ToInt32(dgvItems.Rows[cr].Cells[7].Value) - Convert.ToInt32(dgvItems.Rows[cr].Cells[4].Value)).ToString();
            dgvItems.Rows[cr].Cells[6].Value = (Convert.ToDouble(dgvItems.Rows[cr].Cells[4].Value) * Convert.ToDouble(dgvItems.Rows[cr].Cells[5].Value)).ToString();
            txtInvoiceQuantity.Focus();
            txtInvoiceQuantity.SelectAll();
            total();
        }
        private void btnAddQuantity_Click(object sender, EventArgs e)
        {
            if (cr != -1 & Convert.ToInt32(txtInvoiceQuantity.Text) > 0)
            {
                if (Convert.ToDouble(dgvItems.Rows[cr].Cells[7].Value) >= Convert.ToDouble(dgvItems.Rows[cr].Cells[4].Value) + Convert.ToDouble(txtInvoiceQuantity.Text))
                {
                    dgvItems.Rows[cr].Cells[4].Value = Convert.ToDouble(dgvItems.Rows[cr].Cells[4].Value) + Convert.ToDouble(txtInvoiceQuantity.Text);
                    setNewQuantity();
                }
                else
                {
                    MessageBox.Show("الكمية المطلوبة أكبر من الكمية الموجودة في المخزن", "نفاذ كمية", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtInvoiceQuantity.SelectAll();
                    txtInvoiceQuantity.Focus();
                }
            }
        }
        private void btnSubtractQuantity_Click(object sender, EventArgs e)
        {
            if (cr != -1 & Convert.ToInt32(txtInvoiceQuantity.Text) > 0)
            {
                if (Convert.ToDouble(txtInvoiceQuantity.Text) >= Convert.ToDouble(dgvItems.Rows[cr].Cells[4].Value))
                {
                    dgvItems.Rows.Remove(dgvItems.Rows[cr]);
                    txtInvoiceQuantity.Text = String.Empty ;
                    FunctionsClass.clear(grpItem);
                    cr = -1;
                    sequence();
                }
                else
                {
                    dgvItems.Rows[cr].Cells[4].Value = Convert.ToDouble(dgvItems.Rows[cr].Cells[4].Value) - Convert.ToDouble(txtInvoiceQuantity.Text);
                    setNewQuantity();
                }
                total();
            }
        }

        private void sequence()
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
        private void txtItemNum_Click(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void txtItemNum_Enter(object sender, EventArgs e)
        {
            swText = ((TextBox)sender).Name;
            selectAllText = true;
        }
        private void b1_Click(object sender, EventArgs e)
        {
            TouchScreenButton(((Button)sender).Text);
        }
        private void TouchScreenButton(string Number)
        {
            if (swText == "txtItemNum")
            {
                if (selectAllText == true)
                {
                    txtItemNum.Text = Number;
                    selectAllText = false;
                }
                else
                {
                    txtItemNum.Text += Number;
                }
            }
            else if (swText == "txtInvoiceQuantity")
            {
                if (selectAllText == true)
                {
                    txtInvoiceQuantity.Text = Number;
                    selectAllText = false;
                }
                else
                {
                    txtInvoiceQuantity.Text += Number;
                }
            }
            else if (swText == "txtDiscount")
            {
                if (selectAllText == true)
                {
                    txtdiscount.Text = Number;
                    selectAllText = false;
                }
                else
                {
                    txtdiscount.Text += Number;
                }
            }
        }
        private void bEnter_Click(object sender, EventArgs e)
        {
            if (swText == "txtItemNum")
            {
                txtItemNum.Focus();
                SendKeys.Send("{ENTER}");
            }
        }

        private void bC_Click(object sender, EventArgs e)
        {
            if (swText == "txtItemNum")
            {
                txtItemNum.Text = "";
            }
            else if (swText == "txtInvoiceQuantity")
            {
                txtInvoiceQuantity.Text = "";
            }
            else if (swText == "txtDiscount")
            {
                txtdiscount.Text = "";
            }
        }
        //--------------------------------------------------------------------
        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            if (cmbCustomerName.SelectedValue != null | cmbCustomerName.Text == "")
            {
                return;
            }
            FrmCustomer frmCustomer = Application.OpenForms.OfType<FrmCustomer>().FirstOrDefault();
            if (frmCustomer == null)
            {
                frmCustomer = new FrmCustomer();
            }
            frmCustomer.btnRefresh_Click(sender, e);
            frmCustomer.cmbCustomerName.Text = cmbCustomerName.Text;
            frmCustomer.btnSaveCustomer_Click(sender, e); // Public
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtInvoNum.Text != String.Empty)
            {
                FunctionsClass.msgTool("تم حفظ الفاتورة مسبقاً", 2);
                return;
            }

            if (dgvItems.Rows.Count == 0)
            {
                FunctionsClass.msgTool("لا يمكن حفظ فاتورة فارغة", 2);
                return;
            }



            if (cmbCustomerName.Text == String.Empty)
            {
                MessageBox.Show("الرجاء اختيار اسم العميل", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            if (cmbCustomerName.SelectedIndex == -1 & cmbCustomerName.Text != String.Empty)
            {
                if (MessageBox.Show("اسم العميل غير محفوظ هل تريد حفظه في المنظومة ؟", "ادخال بيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btnSaveCustomer_Click(sender, e);
                }
                else
                {
                    return;
                }
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

            var sqlCon = new SQLConClass();
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@InvoDate", dateAndTime),
                new SqlParameter("@InvoDiscount", Convert.ToInt64(txtTotal.Text) - Convert.ToInt64(txtNet.Text)),
                new SqlParameter("@CustomerID", cmbCustomerName.SelectedValue),
                new SqlParameter("@userId", VariablesClass.userId),
                new SqlParameter("@Content", dt) };
            dsStore = sqlCon.CMDExecuteData("InsertInvoice", param);

            switch (VariablesClass.Save)
            {
                case 1:
                    {
                        txtInvoNum.Text = String.Format(dsStore.Tables[0].Rows[0][0].ToString(), "000000");
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
        private void picClose_Click(object sender, EventArgs e)
        {
            pnlStoreShortage.Visible = false;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {


            //var sqlCon = new SQLConClass();
            //ConClass.sqlQuery = "SELECT * FROM InvoView where InvoNum=@InvoNum";
            //SqlParameter[] param = new SqlParameter[] {
            //    new SqlParameter("@InvoNum", txtInvoNum.Text) };
            //dsPrint = sqlCon.SelectData(ConClass.sqlQuery, 0, param);
            //if (FunctionsClass.dshasTablesAndData(dsPrint))


            var f = new FrmPrint();
            var c = new CRPrintInvo();
            if (FunctionsClass.dshasTablesAndData(dsStore) & VariablesClass.Save == 1)
            {
                c.SetDataSource(dsStore.Tables[1]);
                c.SetParameterValue("Company", Properties.Settings.Default.Company);
                f.crystalReportViewer1.ReportSource = c;

                f.crystalReportViewer1.Refresh();
                f.Text = "طباعة الفاتورة ";
                f.crystalReportViewer1.Zoom(100);
                f.WindowState = FormWindowState.Maximized;
                f.Show();
            }
            else
            {
                FunctionsClass.msgTool("يرجى حفظ الفاتورة قبل الطباعة", 2);
            }
            // ---------------------------
            //f.crystalReportViewer1.PrintReport();
            //f.crystalReportViewer1.PrintMode = CrystalDecisions.Windows.Forms.PrintMode.PrintToPrinter;
            //f.crystalReportViewer1.ShowPrintButton = false;
            //c.SetDatabaseLogon(Properties.Settings.Default.SQLLogin, Properties.Settings.Default.SQLPassword, Properties.Settings.Default.Server, Properties.Settings.Default.Database);




        }

        private void FrmInvoice_Resize(object sender, EventArgs e)
        {
            r.ResizeControl();
        }

        private void FrmInvoice_HandleCreated(object sender, EventArgs e)
        {
            r.Container = this;
        }
        private void FrmInvoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            FunctionsClass.userTrafficRegister(this.Name, false);

        }
    }
}
