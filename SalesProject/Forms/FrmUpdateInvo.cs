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
    public partial class FrmUpdateInvo : Form
    {
      
        ResizeControls r = new ResizeControls();
        DataSet ds = new DataSet();int cr;
        DataSet dsItem = new DataSet();
        DataSet dsStore = new DataSet();
        bool sw, pos;
        bool selectAllText;

        public FrmUpdateInvo()
        {
            InitializeComponent();
        }
        private void FrmUpdateInvo_Resize(object sender, EventArgs e)
        {
            r.ResizeControl();
        }
        private void FrmUpdateInvo_HandleCreated(object sender, EventArgs e)
        {
            r.Container = this;
        }
        private void FrmUpdateInvo_Load(object sender, EventArgs e)
        {
           // FunctionsClass.userTrafficRegister(this.Name, true);
            FunctionsClass.setPermissions(); // جزء خاص بتخصيص الصلاحيات

            getFillData();
            dgvItems.ColumnHeadersDefaultCellStyle.Font = new Font("Hacen Saudi Arabia", 8, FontStyle.Regular);
            dtpDate.CustomFormat = Settings.Default.DateFormat;
        }
        void getFillData()
        {
            SQLConClass sqlCon = new SQLConClass();
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@Id",VariablesClass.updateInvoiceId ) };
            ds = sqlCon.selectData("FindInvoId", 1, param);

            if (FunctionsClass.dshasTablesAndData(ds))
            {
                {
                    var row = ds.Tables[0].Rows[0];

                    txtInvoNum.Text = Convert.ToInt64(row[1]).ToString("000000");
                    txtTotal.Text = row[4].ToString();
                    txtNet.Text = (Convert.ToDouble(row[4]) - Convert.ToDouble(row[3])).ToString();
                    txtdiscount.Text = row[3].ToString();
                    dtpDate.Value = (DateTime)row[5];
                    dtpTime.Value = (DateTime)row[5];
                    tslUserName.Text = "اسم المستخدم : " + row[6];
                }

                dgvItems.Rows.Clear();
                for (int i = 0; i <= ds.Tables[1].Rows.Count - 1; i++)
                {
                    {
                        var row = ds.Tables[1].Rows[i];
                        dgvItems.Rows.Add();
                        dgvItems.Rows[i].Cells[0].Value = row[0];
                        dgvItems.Rows[i].Cells[1].Value = i + 1;
                        dgvItems.Rows[i].Cells[2].Value = row[1]; // رقم الصنف
                        dgvItems.Rows[i].Cells[3].Value = row[2]; // الاسم والوصف
                        dgvItems.Rows[i].Cells[4].Value = row[3]; // الكمية في الفاتورة
                        dgvItems.Rows[i].Cells[5].Value = row[4]; // السعر في الفاتورة
                        dgvItems.Rows[i].Cells[6].Value = Convert.ToDouble(row[3]) * Convert.ToDouble(row[4]); // االاجمالي
                        dgvItems.Rows[i].Cells[7].Value = Convert.ToInt32(row[3]) + Convert.ToInt32(row[6]); // الكمية في الفاتورة + الكمية الحالية في المخزن
                        dgvItems.Rows[i].Cells[8].Value = row[7]; // الحد الأدنى
                        dgvItems.Rows[i].Cells[9].Value = row[8]; //صورة الصنف
                        dgvItems.Rows[i].Cells[10].Value = row[9]; // المجموعة
                        dgvItems.Rows[i].Cells[11].Value = row[10];// بلد الصنع
                        dgvItems.Rows[i].Cells[12].Value = row[11];// الوحدة

                        dgvItems.Rows[i].Cells[13].Value = row[3]; // تخزين الكمية الاصلية في الفاتورة قبل التعديل
                        dgvItems.Rows[i].Cells[14].Value = row[5]; // السعر الجديد
                    }
                }

                cmbItemName.DataSource = null;
                cmbItemName.DataSource = ds.Tables[2];
                cmbItemName.DisplayMember = "Name";
                cmbItemName.ValueMember = "Id";
                cmbItemName.SelectedIndex = -1;

                cmbCustomerName.DataSource = null;
                cmbCustomerName.DataSource = ds.Tables[3];
                cmbCustomerName.DisplayMember = "Name";
                cmbCustomerName.ValueMember = "Id";
                cmbCustomerName.SelectedValue = ds.Tables[0].Rows[0][2];

                setFormSize();
                txtItemNum.Select();
            }
            else
            {
                this.Close();
                FunctionsClass.msgTool("لايمكن فتح الفاتورة", 0);
            }
        }
        void setFormSize()
        {
            FrmMain frmMain = Application.OpenForms.OfType<FrmMain>().FirstOrDefault();
            if (frmMain != null)
            {
                this.Size = frmMain.Size - new Size(0, 60);
                this.Left = frmMain.Left;
                this.Top = frmMain.Top + 30;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            FunctionsClass.clear(grpQuantity);
        }
        private void txtItemNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtItemNum.Text.Trim() == string.Empty)
                return;

            if (e.KeyCode == Keys.Enter)
            {
                // جلب بيانات الصنف من الجدول
                SQLConClass sqlCon = new SQLConClass();
                SQLConClass.sqlQuery = "SELECT TblItems.Id,Num,[Name]+'-'+Describe AS Item,SalePrice,StoreQuantity,LowQuantity,Pic,Category,Country,Unit FROM TblItems,TblCategories,TblCountries,TblUnits WHERE TblItems.categoryId=TblCategories.Id and TblItems.CountryID=TblCountries.Id and TblItems.UnitID=TblUnits.Id and TblItems.Del=0 and TblItems.[Num]=@Num";
                SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Num", txtItemNum.Text.Trim()) };

                dsItem = sqlCon.selectData(SQLConClass.sqlQuery, 0, param);

                if (!FunctionsClass.dshasTablesAndData(dsItem))
                {
                    clearItem();
                    MessageBox.Show("رقم الصنف غير موجود", "بحث", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    selectAll(txtItemNum);
                    return;
                }

                // اختبار كمية الصنف في المخزن
                if (Convert.ToInt32(dsItem.Tables[0].Rows[0][5]) <= 0)
                {
                    MessageBox.Show("هذا الصنف نفذ من المخزن الكمية = 0", "نفاذ كمية", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    clearItem();
                    selectAll(txtItemNum);
                    return;
                }

                // ----------------------------------------------------------------------------------
                // البحث عن الصنف هل موجود في DGV مسبقا
                foreach (DataGridViewRow row in dgvItems.Rows)
                {
                    if (Convert.ToInt64(txtItemNum.Text.Trim()) == Convert.ToInt64(row.Cells[2].Value))
                    {
                        row.Cells[14].Value = Convert.ToInt32(dsItem.Tables[0].Rows[0][3]); //   تحديث السعر

                        if (checkPriceChange(row.Index))
                        {
                            MessageBox.Show("تم تعديل سعر الصنف! لايمكن تعديل الكميات في الفاتورة", "تعديل بيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        //تحديث الكمية في المخزن
                        row.Cells[7].Value = Convert.ToInt32(dsItem.Tables[0].Rows[0][4]) + Convert.ToInt32(row.Cells[13].Value); //   StoreQuantity + الكمية الاصلية في الغاتورة

                        if (Convert.ToInt32(row.Cells[7].Value) > Convert.ToInt32(row.Cells[4].Value))
                        {
                            row.Visible = true;
                            row.Cells[4].Value = Convert.ToInt32(row.Cells[4].Value) + 1;
                            row.Cells[6].Value = Convert.ToDouble(row.Cells[4].Value) * Convert.ToDouble(row.Cells[5].Value);
                            txtStoreQuantity.Text = (Convert.ToInt32(row.Cells[7].Value) - Convert.ToInt32(row.Cells[4].Value)).ToString();
                            row.Selected = true;
                            dgvItems.FirstDisplayedScrollingRowIndex = row.Index;
                            cr = row.Index;
                            sequence();
                            displayData();
                            total();
                        }
                        else
                            MessageBox.Show("هذا الصنف نفذ من المخزن الكمية = 0", "نفاذ كمية", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        selectAll(txtItemNum);
                        return;
                    }
                }

                // ******************************************************************---------------------
                // اضافة صف جديد بكمية مبدئية 1 
                {
                    var row = dsItem.Tables[0].Rows[0];
                    dgvItems.Rows.Add(row[0], dgvItems.Rows.Count + 1, row[1], row[2], 1, row[3], Convert.ToDouble(row[3]) * 1, row[4], row[5], row[6], row[7], row[8], row[9], 0, row[3]);
                }

                cr = dgvItems.Rows.Count - 1;
                dgvItems.Rows[cr].Selected = true;
                dgvItems.FirstDisplayedScrollingRowIndex = cr;
                displayData();
                total(); // حساب إجمالي الفاتورة

                selectAll(txtItemNum);
            }
        }
        bool checkPriceChange(int crr)
        {
            if (crr < 0)
                return true;

            if (Convert.ToDouble(dgvItems.Rows[crr].Cells[5].Value) != Convert.ToDouble(dgvItems.Rows[crr].Cells[14].Value))
                return true;
            else
                return false;
        }
        void displayData()
        {
            var row = dgvItems.Rows[cr];
            txtItemNum.Text = row.Cells[2].Value.ToString();

            int dash = row.Cells[3].Value.ToString().IndexOf("-");
            if (dash > 0)
            {
                cmbItemName.Text = row.Cells[3].Value.ToString().Substring(0, dash);
                txtItemDescribe.Text = row.Cells[3].Value.ToString().Substring(dash + 1, row.Cells[3].Value.ToString().Length - dash - 1); ;
            }
            txtInvoiceQuantity.Text = row.Cells[4].Value.ToString();
            txtItemPrice.Text = row.Cells[5].Value.ToString();
            txtStoreQuantity.Text = (Convert.ToInt32(row.Cells[7].Value) - Convert.ToInt32(row.Cells[4].Value)).ToString();
            picItem.Image = (row.Cells[9].Value is DBNull) ?
               null : FunctionsClass.byteToImage((byte[])row.Cells[9].Value);
            txtItemCategory.Text = row.Cells[10].Value.ToString();
            txtItemCountry.Text = row.Cells[11].Value.ToString();
            txtItemUnit.Text = row.Cells[12].Value.ToString();
        }
        private void dgvItems_Click(object sender, EventArgs e)
        {
            if (FunctionsClass.checkDgvError(dgvItems) == true)
                return;

            cr = dgvItems.CurrentRow.Index;
            displayData();
            selectAll(txtInvoiceQuantity);
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
                MessageBox.Show("لقد تجاوزت نسبة التخفيض المحددة من المسؤول وهي: " + Environment.NewLine + Settings.Default.DiscountPercent + "%", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            selectAll(txtdiscount);
        }
        private void txtdiscount_TextChanged(object sender, EventArgs e)
        {
            discount();
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
                lblBarcode.Text = "*" + txtInvoNum.Text + "*";
        }
        private void txtStoreQuantity_TextChanged(object sender, EventArgs e)
        {
            if (cr == -1)
            {
                txtStoreQuantity.BackColor = Color.White;
                return;
            }

            if (Convert.ToInt32(txtStoreQuantity.Text) <= Convert.ToInt32(dgvItems.Rows[cr].Cells[8].Value) & txtStoreQuantity.Text != "0")
                txtStoreQuantity.BackColor = Color.Yellow;
            else if (txtStoreQuantity.Text == "0")
                txtStoreQuantity.BackColor = Color.Red;
            else
                txtStoreQuantity.BackColor = Color.White;
        }
        //******************************************************************************
        private void btnUpdateQuantity_Click(object sender, EventArgs e)
        {
            int invoiceQuantity;
            int.TryParse(txtInvoiceQuantity.Text, out invoiceQuantity);
            if (cr != -1 & invoiceQuantity > 0)
            {
                getQuantity();
                if (checkPriceChange(cr))
                {
                    MessageBox.Show("تم تعديل سعر الصنف! لايمكن تعديل الكميات في الفاتورة", "تعديل بيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
        void getQuantity()
        {
            SQLConClass sqlCon = new SQLConClass();
            dsItem = sqlCon.selectData("SELECT StoreQuantity,SalePrice FROM TblItems WHERE Num=" + dgvItems.Rows[cr].Cells[2].Value.ToString(), 0, default);
            if (FunctionsClass.dshasTablesAndData(dsItem))
            {
                dgvItems.Rows[cr].Cells[14].Value = (double)dsItem.Tables[0].Rows[0][1];
                if (Convert.ToDouble(dgvItems.Rows[cr].Cells[5].Value) != Convert.ToDouble(dgvItems.Rows[cr].Cells[14].Value)) // في حال تغيير سعر الصنف لايكمل الاجراء
                    return;

                dgvItems.Rows[cr].Cells[7].Value = (int)dsItem.Tables[0].Rows[0][0] + Convert.ToInt32(dgvItems.Rows[cr].Cells[13].Value); // تحديث الكمية في المخزن

            }

            if (Convert.ToInt32(dgvItems.Rows[cr].Cells[4].Value) > Convert.ToInt32(dgvItems.Rows[cr].Cells[7].Value))
                dgvItems.Rows[cr].Cells[4].Value = dgvItems.Rows[cr].Cells[7].Value;
        }
        void setNewQuantity()
        {
            if (cr == -1)
                return;

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
                getQuantity();
                if (checkPriceChange(cr))
                {
                    MessageBox.Show("تم تعديل سعر الصنف! لايمكن تعديل الكميات في الفاتورة", "تعديل بيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Convert.ToInt32(dgvItems.Rows[cr].Cells[7].Value) >= Convert.ToInt32(dgvItems.Rows[cr].Cells[4].Value) + Convert.ToInt32(txtInvoiceQuantity.Text))
                {
                    dgvItems.Rows[cr].Cells[4].Value = Convert.ToDouble(dgvItems.Rows[cr].Cells[4].Value) + Convert.ToDouble(txtInvoiceQuantity.Text);
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
                getQuantity();
                if (checkPriceChange(cr))
                {
                    MessageBox.Show("تم تعديل سعر الصنف! لايمكن تعديل الكميات في الفاتورة", "تعديل بيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Convert.ToInt32(txtInvoiceQuantity.Text) >= Convert.ToInt32(dgvItems[4, cr].Value))
                {
                    if (Convert.ToInt32(dgvItems[13, cr].Value) != 0) //  صنف موجود من قبل في الفاتورة الأصلية
                    {
                        dgvItems[4, cr].Value = 0;

                        //dgvItems.Rows[cr].Visible = false; // هو هذا فقط لأخفاء الصنف المرجع

                        sequence();
                        setNewQuantity();
                        clearItem();
                    }
                    else if (Convert.ToInt32(dgvItems[13, cr].Value) == 0) // صنف جديد غير موجود في الفاتورة الاصلية
                    {
                        dgvItems.Rows.Remove(dgvItems.Rows[cr]);
                        clearItem();
                        sequence();
                    }
                }
                else
                {
                    dgvItems[4, cr].Value = Convert.ToInt32(dgvItems[4, cr].Value) - Convert.ToInt32(txtInvoiceQuantity.Text);
                    txtInvoiceQuantity.Text = Convert.ToString(dgvItems[4, cr].Value);
                    selectAll(txtInvoiceQuantity);
                    setNewQuantity();
                }
                total();
            }
        }
        void sequence()
        {
            dgvItems.Tag = 1;
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (row.Visible == true)
                {
                    row.Cells[1].Value = dgvItems.Tag;
                    dgvItems.Tag = Convert.ToInt32(dgvItems.Tag) + 1;
                }
            }
        }
        private void delFromInvo_Click(object sender, EventArgs e)
        {
            txtInvoiceQuantity.Text = dgvItems.Rows[cr].Cells[4].Value.ToString();
            btnSubtractQuantity.PerformClick();
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
        public void getCustomers()
        {
            SQLConClass sqlCon = new SQLConClass();
            var dsCustomers = sqlCon.selectData("SELECT Id,Name FROM TblCustomers WHERE Del=0 ORDER BY Name", 0, null);
            if (FunctionsClass.dsHasTables(dsCustomers))
            {
                cmbCustomerName.DataSource = dsCustomers.Tables[0];
                cmbCustomerName.DisplayMember = "Name";
                cmbCustomerName.ValueMember = "Id";
                cmbCustomerName.SelectedIndex = -1;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            dgvItems.Tag = 0;
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (Convert.ToInt32(row.Cells[4].Value) == 0)
                    dgvItems.Tag = (int)dgvItems.Tag + 1;
            }



            if (dgvItems.Rows.Count == (int)dgvItems.Tag)
            {
                MessageBox.Show("لا يمكن حفظ فاتورة فارغة", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cmbCustomerName.Text == string.Empty)
            {
                MessageBox.Show("الرجاء اختيار اسم العميل", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cmbCustomerName.SelectedIndex == -1 & cmbCustomerName.Text != string.Empty)
            {
                if (MessageBox.Show("اسم العميل غير محفوظ هل تريد حفظه في المنظومة ؟", "ادخال بيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    btnSaveCustomer_Click(sender, e); // Public
                else
                    return;
            }

            var dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] {
                new DataColumn("ItemId", typeof(int)),
                new DataColumn("ItemQuantity", typeof(int)),
                new DataColumn("ItemPrice", typeof(double))
            });

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (Convert.ToInt32(row.Cells[4].Value) > 0)
                    dt.Rows.Add(row.Cells[0].Value, row.Cells[4].Value, row.Cells[5].Value);
            }

            DateTime dateAndTime = Convert.ToDateTime(dtpDate.Value.Date + dtpTime.Value.TimeOfDay);


            SQLConClass sqlCon = new SQLConClass();
            
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@InvoID", VariablesClass.updateInvoiceId),
                new SqlParameter("@InvoDate", dateAndTime),
                new SqlParameter("@InvoDiscount", Convert.ToDouble(txtTotal.Text) - Convert.ToDouble(txtNet.Text)),
                new SqlParameter("@CustomerID", cmbCustomerName.SelectedValue),
                new SqlParameter("@userId", VariablesClass.userId),
                new SqlParameter("@Content", dt) };

            dsStore = sqlCon.cmdExecuteData("UpdateInvoice", param);

            switch (VariablesClass.Save)
            {
                case 2:
                    {
                        FunctionsClass.msgTool("لم يتم حفظ الفاتورة أحد الأصناف نفذ من المخزن ", 0);
                        showStore(dsStore);
                        break;
                    }
            }
        }
        void showStore(DataSet dsStore)
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
            //if (FunctionsClass.dshasTablesAndData(dsStore) & VariablesClass.Save == 1)
            //{
            //    var F = new FrmPrint();
            //    //var C = new CRPrintInvo();
            //    C.SetDataSource(dsStore.Tables[0]);
            //    C.SetParameterValue("Company", Settings.Default.Company);
            //    F.crystalReportViewer1.ReportSource = C;
            //    F.crystalReportViewer1.Refresh();
            //    F.Text = "طباعة الفاتورة ";
            //    F.crystalReportViewer1.Zoom(100);
            //    F.WindowState = FormWindowState.Maximized;
            //    F.Show();
            //}
            //else
            //{
            //    FunctionsClass.msgTool("يرجى حفظ الفاتورة قبل الطباعة", 2);
            //}
        }
        //*************************************************************************
        private void pnlStoreShortage_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    sw = true;
            //    pos = e.Location;
            //}
        }
        private void pnlStoreShortage_MouseMove(object sender, MouseEventArgs e)
        {
            //if (sw == true)
            //    this.Location = new Point(this.Location.X + (e.X - pos.X), this.Location.Y + (e.Y - pos.Y));
        }
        private void pnlStoreShortage_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //    sw = false;
        }
        //****************************************************************************
    }
}
