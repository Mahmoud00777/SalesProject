using SalesProject.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesProject.Forms
{
    public partial class FrmDelElement : Form
    {
        private DataSet dsElement = new DataSet();
        private int id;
        public FrmDelElement()
        {
            InitializeComponent();
        }

        private void FrmDelElement_Load(object sender, EventArgs e)
        {
            FunctionsClass.userTrafficRegister(this.Name, true);



            radInvoice.Checked = true;
            dgvDelElements.ColumnHeadersDefaultCellStyle.Font = new Font("Hacen Saudi Arabia", 10);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtFilter.Text = "";
            txtFilter.Focus();
            dgvDelElements.ClearSelection();
            id = 0;
        }

        private void radInvoice_CheckedChanged(object sender, EventArgs e)
        {
            if (radInvoice.Checked == true)
            {
                var sqlCon = new SQLConClass();
                ConClass.sqlQuery = "SELECT TblInvoices.id, ROW_NUMBER() OVER (ORDER BY (SELECT 1)) AS ت ,CONVERT(NVARCHAR,TblInvoices.InvoNum,50) InvoNum,TblInvoices.InvoDate 'التاريخ',TblCustomers.Name ,TblUsers.userName 'اسم البائع' FROM TblInvoices,TblCustomers,TblUsers WHERE TblInvoices.CustomerID=TblCustomers.id And  TblInvoices.userId=TblUsers.id And TblInvoices.Del='TRUE'";
                dsElement = sqlCon.SelectData(ConClass.sqlQuery, 0, default);
                if (FunctionsClass.dsHasTables(dsElement))
                {
                        dgvDelElements.DataSource = dsElement.Tables[0];
                        dgvDelElements.Columns[0].Visible = false;
                        dgvDelElements.Columns[1].Width = 30;
                        dgvDelElements.Columns[2].Width = 100;
                        dgvDelElements.Columns[2].HeaderText = "رقم الفاتورة";
                        dgvDelElements.Columns[4].HeaderText = "اسم العميل";

                }
                lblFind.Text = "اكتب اسم العميل أو رقم الفاتورة للبحث";
                btnRefresh.PerformClick();
            }
        }

        private void radCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (radCustomer.Checked == true)
            {
                var sqlCon = new SQLConClass();
                ConClass.sqlQuery = "SELECT id, ROW_NUMBER() OVER (ORDER BY (SELECT 1)) AS ت ,CONVERT(NVARCHAR,id,50) CostumerID,Name,Company 'الشركة',Phone 'رقم الهاتف',Address 'العنوان' FROM TblCustomers WHERE Del=1";
                dsElement = sqlCon.SelectData(ConClass.sqlQuery, 0, default);
                if (FunctionsClass.dsHasTables(dsElement))
                {
                        dgvDelElements.DataSource = dsElement.Tables[0];
                        dgvDelElements.Columns[0].Visible = false;
                        dgvDelElements.Columns[1].Width = 30;
                        dgvDelElements.Columns[2].HeaderText = "رقم التسجيل";
                        dgvDelElements.Columns[3].Width = 200;
                        dgvDelElements.Columns[3].HeaderText = "اسم العميل";
                }
                lblFind.Text = "اكتب اسم العميل أو رقم التسجيل للبحث";
                btnRefresh.PerformClick();
            }
        }

        private void radItem_CheckedChanged(object sender, EventArgs e)
        {
            if (radItem.Checked == true)
            {
                var sqlCon = new SQLConClass();
                ConClass.sqlQuery = "SELECT TblItems.id, ROW_NUMBER() OVER (ORDER BY (SELECT 1)) AS ت ,CONVERT(NVARCHAR,[Num],50) 'الرقم' ,[Name]+' - '+Describe 'البيان',Country 'بلد الصنع',Pic ,SalePrice 'سعر البيع',PurchasePrice 'سعر الشراء' FROM TblItems,TblCountries WHERE TblCountries.id=TblItems.CountryID AND TblItems.Del='TRUE'";
                dsElement = sqlCon.SelectData(ConClass.sqlQuery, 0, default);
                if (dsElement.Tables.Count > 0)
                {

                        dgvDelElements.DataSource = dsElement.Tables[0];
                        dgvDelElements.Columns[0].Visible = false;
                        dgvDelElements.Columns[1].Width = 30;
                        dgvDelElements.Columns[3].Width = 200;
                        dgvDelElements.Columns[5].HeaderText = "الصورة";

                        // ------------هذا الكود---------------------------
                        ((DataGridViewImageColumn)dgvDelElements.Columns["Pic"]).ImageLayout = DataGridViewImageCellLayout.Zoom;

                        // ------------او هذا الكود-----------------------
                        //foreach (DataGridViewImageColumn IC in dgvDelElements.Columns)
                        //{

                        //    IC.ImageLayout = DataGridViewImageCellLayout.Zoom;
                        //}


                }
                lblFind.Text = "اكتب اسم أو رقم الصنف للبحث";
                btnRefresh.PerformClick();
            }
        }

        private void radCategory_CheckedChanged(object sender, EventArgs e)
        {
            if (radCategory.Checked == true)
            {
                var sqlCon = new SQLConClass();
                ConClass.sqlQuery = "SELECT id,ROW_NUMBER() OVER (ORDER BY (SELECT 1)) AS ت ,Category FROM TblCategories WHERE Del=1";
                dsElement = sqlCon.SelectData(ConClass.sqlQuery, 0, default);
                if (dsElement.Tables.Count == 1)
                {
                        dgvDelElements.DataSource = dsElement.Tables[0];
                        dgvDelElements.Columns[0].Visible = false;
                        dgvDelElements.Columns[2].Width = 450;
                        dgvDelElements.Columns[2].HeaderText = "اسم المجموعة";
                }
                lblFind.Text = "اكتب اسم المجموعة للبحث";
                btnRefresh.PerformClick();
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (radInvoice.Checked == true)
            {
                dsElement.Tables[0].DefaultView.RowFilter = " Name Like '%" + txtFilter.Text.Trim() + "%' OR InvoNum Like '%" + txtFilter.Text.Trim() + "%'";
            }
            else if (radCustomer.Checked == true)
            {
                dsElement.Tables[0].DefaultView.RowFilter = " Name Like '%" + txtFilter.Text.Trim() + "%' OR CostumerID Like '%" + txtFilter.Text.Trim() + "%'";
            }
            else if (radItem.Checked == true)
            {
                dsElement.Tables[0].DefaultView.RowFilter = " البيان Like '%" + txtFilter.Text.Trim() + "%' OR الرقم Like '%" + txtFilter.Text.Trim() + "%'";
            }
            else if (radCategory.Checked == true)
            {
                dsElement.Tables[0].DefaultView.RowFilter = " Category Like '%" + txtFilter.Text.Trim() + "%'";
            }
            dgvDelElements.ClearSelection();

            //dsElement.Tables[0].DefaultView.RowFilter = " Grade>=50";
        }

        private void dgvDelElements_Click(object sender, EventArgs e)
        {
            if (FunctionsClass.checkDGVError(dgvDelElements))
                return;
            id = Convert.ToInt32(dgvDelElements.Rows[dgvDelElements.CurrentRow.Index].Cells[0].Value);
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (id == 0)
            {
                MessageBox.Show("الرجاء تحديد عنصر من القائمة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("هل انت متأكد تريد استرجاع العنصر المحدد", "استرجاع بيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var sqlCon = new SQLConClass();
                if (radInvoice.Checked == true)
                {
                    ConClass.sqlQuery = "UPDATE TblInvoices SET Del=0 WHERE id=" + id;
                    sqlCon.CMDExecute(ConClass.sqlQuery, 0, default);
                    radInvoice_CheckedChanged(sender, e);
                }
                else if (radCustomer.Checked == true)
                {
                    ConClass.sqlQuery = "UPDATE TblCustomers SET Del=0 WHERE id=" + id;
                    sqlCon.CMDExecute(ConClass.sqlQuery, 0, default);
                    radCustomer_CheckedChanged(sender, e);
                    FrmCustomer frmCustomer = Application.OpenForms.OfType<FrmCustomer>().FirstOrDefault();
                    if (frmCustomer == null)
                    {
                        frmCustomer = new FrmCustomer();
                    }
                    frmCustomer.getData(); // Public In Form Customer
                }
                else if (radItem.Checked == true)
                {
                    ConClass.sqlQuery = " UPDATE TblItems SET Del='FALSE' WHERE id=" + id + " AND categoryId IN(SELECT id FROM TblCategories WHERE Del='FALSE')";
                    if (sqlCon.CMDExecute(ConClass.sqlQuery, 0, default) == 0)
                        FunctionsClass.msgTool("لم يتم الحفظ، يجب استرجاع مجموعة الصنف ", 0);
                    radItem_CheckedChanged(sender, e);
                    FrmItem frmItem = Application.OpenForms.OfType<FrmItem>().FirstOrDefault();
                    if (frmItem == null)
                    {
                        frmItem = new FrmItem();
                    }
                    frmItem.getFillData();
                }
                else if (radCategory.Checked == true)
                {

                    if (MessageBox.Show("هل تريد استرجاع جميع الأصناف التي تتبع هذه المجموعة", "استرجاع بيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ConClass.sqlQuery = "UPDATE TblCategories SET Del='FALSE' WHERE id=" + id + " UPDATE TblItems SET Del='FALSE' WHERE categoryId=" + id;
                    }
                    else
                    {
                        ConClass.sqlQuery = "UPDATE TblCategories Set Del='FALSE' WHERE id=" + id;
                    }
                    sqlCon.CMDExecute(ConClass.sqlQuery, 0, default);
                    radCategory_CheckedChanged(sender, e);
                    FrmItem frmItem = Application.OpenForms.OfType<FrmItem>().FirstOrDefault();
                    if (frmItem == null)
                    {
                        frmItem = new FrmItem();
                    }
                    frmItem.getFillData();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmDelElement_FormClosing(object sender, FormClosingEventArgs e)
        {
            FunctionsClass.userTrafficRegister(this.Name, false);
            VariablesClass.mainActive = true;
        }
    }
}
