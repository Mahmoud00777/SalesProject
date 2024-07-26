using SalesProject.Classes;
using SalesProject.Properties;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace SalesProject.Forms
{
    public partial class FrmCustomers : Form
    {
        public FrmCustomers()
        {
            InitializeComponent();
        }

        DataSet dsCustomers = new DataSet(); DataSet dsCusomerId = new DataSet();
        DataTable DtCustomers = new DataTable();
        int customerId;
        int pageSize, pageNum = 1, pagesCount, rowsCount, cr = -1;
        ResizeControls r = new ResizeControls();
        private void FrmCustomers_Resize(object sender, EventArgs e)
        {
            r.ResizeControl();
        }
        private void FrmCustomers_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                numericUpDown1.Value = Settings.Default.PageSize;
                getFillData();
                dgvCustomers.ColumnHeadersDefaultCellStyle.Font = new Font("Hacen Saudi Arabia", 10);
            }
            else
            {
                dsCustomers.Clear();
                DtCustomers.Clear();
            }
        }
        private void FrmCustomers_HandleCreated(object sender, EventArgs e)
        {
            r.Container = this;
        }
        private void FrmCustomers_FormClosing(object sender, FormClosingEventArgs e)
        {


        }
        public void getFillData1()
        {
            SQLConClass sqlCon = new SQLConClass();
            SQLConClass.sqlQuery = "SELECT Id,[Name] FROM TblCustomers WHERE Del=0 ORDER BY [Name]";
            SQLConClass.sqlQuery += " SELECT Id, ROW_NUMBER() OVER (ORDER BY [name]) AS ت ,[Name] AS CustomerName , Company ,Phone ,Email,[Address],Id AS Id1,Del FROM TblCustomers WHERE Del=0 ORDER BY [Name] ";
            SQLConClass.sqlQuery += " SELECT COUNT(Id) FROM TblCustomers WHERE Del=0";

            dsCustomers = sqlCon.selectData(SQLConClass.sqlQuery, 0, null);

            if (FunctionsClass.dsHasTables(dsCustomers))
            {
                fillCmbCustomers(dsCustomers.Tables[0]);
                fillDgvCustomer();
                rowsCount = (int)dsCustomers.Tables[2].Rows[0][0];

                // clearData();
            }
        }
        public void getFillData()
        {
            txtPageNum.Text = pageNum.ToString();
            pageSize = Settings.Default.PageSize;

            SQLConClass sqlCon = new SQLConClass();
            SQLConClass.sqlQuery = "SELECT Id,[Name] FROM TblCustomers WHERE Del=0 ORDER BY [Name]";
            SQLConClass.sqlQuery += " SELECT Id, ROW_NUMBER() OVER (ORDER BY [name]) AS ت ,[Name] AS CustomerName , Company ,Phone ,Email,[Address],Id AS Id1,Del FROM TblCustomers WHERE Del=0";
            SQLConClass.sqlQuery += " ORDER BY [Name] OFFSET " + pageSize * (pageNum - 1) + " ROWS FETCH NEXT " + pageSize + " ROWS ONLY";
            SQLConClass.sqlQuery += " SELECT COUNT(Id) FROM TblCustomers WHERE Del=0";

            dsCustomers = sqlCon.selectData(SQLConClass.sqlQuery, 0, null);

            if (FunctionsClass.dsHasTables(dsCustomers))
            {
                fillCmbCustomers(dsCustomers.Tables[0]);
                fillDgvCustomer();
                rowsCount = (int)dsCustomers.Tables[2].Rows[0][0];
                clearData();
                getPagesCount();
            }
        }
        void fillCmbCustomers(DataTable dt)
        {
            cmbCustomerName.DataSource = dt;
            cmbCustomerName.DisplayMember = "Name";
            cmbCustomerName.ValueMember = "Id";
            cmbCustomerName.SelectedIndex = -1;
        }
        void fillDgvCustomer()
        {
            DtCustomers = dsCustomers.Tables[1].Copy();
            dsCustomers.Tables[1].Clear();
            dgvCustomers.DataSource = DtCustomers;
        }
        void clearData()
        {
            FunctionsClass.clear(grpCustomer);
            customerId = 0; //cr = -1;  
            dgvCustomers.ClearSelection();
            cmbCustomerName.Focus();
        }

        //********************pagenation*************************************
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            checkPageSize();

            if (pageNum < pagesCount)
            {
                pageNum += 1;
            }
            getFillData();
        }
        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            checkPageSize();

            if (pageNum > 1)
            {
                pageNum -= 1;
            }
            else
            {
                pageNum = 1;
            }
            getFillData();
        }
        private void btnLastPage_Click(object sender, EventArgs e)
        {
            checkPageSize();

            pageNum = pagesCount;
            getFillData();
        }
        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            pageNum = 1;
            getFillData();
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (Settings.Default.PageSize != numericUpDown1.Value)
            {
                Settings.Default.PageSize = (int)numericUpDown1.Value;
                Settings.Default.Save();
            }
        }
        private void txtPageNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !FunctionsClass.isPositiveIntNum(e);
        }
        void checkPageSize()
        {
            if (pageSize != Settings.Default.PageSize)
            {
                pageNum = 1;
                getFillData(); // عند تغيير حجم الصفحة يجب معرفة عدد الصفحات الجديد pagesCount
            }
        }
        private void txtPageNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtPageNum.Text == string.Empty) return;

            if (e.KeyCode == Keys.Enter)
            {
                checkPageSize();

                if (Convert.ToInt32(txtPageNum.Text) > Convert.ToInt32(lblPagesCount.Text))
                    pageNum = Convert.ToInt32(lblPagesCount.Text);
                else if (Convert.ToInt32(txtPageNum.Text) <= 0)
                    pageNum = 1;
                else
                    pageNum = Convert.ToInt32(txtPageNum.Text);

                getFillData();
            }
        }
        void getPagesCount()
        {
            if (rowsCount == pageSize)
            {
                pagesCount = 1;
            }
            else if (rowsCount % pageSize == 0 & rowsCount != 0)
            {
                pagesCount = rowsCount / pageSize;
            }
            else
            {
                pagesCount = (rowsCount / pageSize) + 1;
            }

            lblPagesCount.Text = pagesCount.ToString();
            txtPageNum.Text = pageNum.ToString();
        }
        //*******************************************************************
        private void dgvCustomers_Click(object sender, EventArgs e)
        {
            if (FunctionsClass.checkDgvError((DataGridView)sender))
                return;

            cr = dgvCustomers.CurrentRow.Index;
            customerId = (int)dgvCustomers.Rows[cr].Cells[0].Value;
            displayData();
        }
        public void btnRefresh_Click(object sender, EventArgs e)
        {
            getFillData();
        }
        private void dgvCustomers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DtCustomers = FunctionsClass.columnHeaderMouseClick((DataGridView)sender,DtCustomers);
            clearData();
        }
        public void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            if (cmbCustomerName.Text.Trim() == "")
            {
                MessageBox.Show("الرجاء إدخال اسم العميل", "ادخال بيانات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ------------------------------------------------------------------
            DataRow[] perm = VariablesClass.dtUserPermissions.Select("OperationID=3");
            if ((bool)perm[0]["InsertP"] == false & customerId == 0)
            {
                MessageBox.Show("ليس لديك صلاحية الإضافة", "ادخال بيانات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if ((bool)perm[0]["UpdateP"] == false & customerId != 0)
            {
                MessageBox.Show("ليس لديك صلاحية التعديل", "ادخال بيانات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // ------------------------------------------------------------------

            SQLConClass sqlCon = new SQLConClass();
            SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@Id", customerId),
                new SqlParameter("@Name", cmbCustomerName.Text.Trim()),
                new SqlParameter("@Company", txtCompany.Text.Trim()),
                new SqlParameter("@Phone", txtPhone.Text.Trim()),
                new SqlParameter("@Email", txtEmail.Text.Trim()),
                new SqlParameter("@Address", txtAddress.Text.Trim()) };

            dsCusomerId = sqlCon.cmdExecuteData("SaveCustomer", param);
            if (FunctionsClass.dsHasTables(dsCusomerId))
            {
                //----------------------select-----------------------
                fillCmbCustomers(dsCusomerId.Tables[0]);
                cmbCustomerName.SelectedValue = (int)dsCusomerId.Tables[1].Rows[0][0];
                cmbCustomerName_SelectionChangeCommitted(sender, e);
                //---------------------------------------------------

                if (VariablesClass.Save == 2)
                {
                    FunctionsClass.msgTool("لم يتم الحفظ، اسم العميل مسجل مسبقاً", 0);
                    return;
                }

                refreshInvoice();
            }

        }
        private void cmbCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbCustomerName_SelectionChangeCommitted(sender, e);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (customerId == 0)
            {
                MessageBox.Show("الرجاء تحديد عميل من القائمة", "حذف بيانات", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (customerId == 1)
            {
                MessageBox.Show("لا يمكن حذف المبيعات اليومية ", "حذف بيانات", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (DialogResult.Yes == MessageBox.Show("هل أنت متأكد تريد حذف هذا العميل", "تأكيد حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                SQLConClass sqlCon = new SQLConClass();
                SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Id", customerId) };

                VariablesClass.Save = sqlCon.cmdExecute("DeleteCustomer", 1, param);

                getFillData();
                refreshInvoice();

                if (VariablesClass.Save == 3)
                    MessageBox.Show("لم يتم الحذف، تم اخفاءالعميل لديه سجل في المبيعات " + Environment.NewLine + " بامكانك استعادة العميل من شاشة ادارة البيانات المحذوفة", "اخفاء بيانات", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
        }
        private void btnAccountStatement_Click(object sender, EventArgs e)
        {
            FrmAccountStatement frmAccountStatement = new FrmAccountStatement();
            frmAccountStatement.ShowDialog();
        }
        private void cmbCustomerName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbCustomerName.SelectedValue == null)
            {
                MessageBox.Show("اسم العميل غير موجود", "بحث", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearData();
                return;
            }
            int selectedCustomerId = Convert.ToInt32(cmbCustomerName.SelectedValue);
            getPageNum(cmbCustomerName.SelectedIndex + 1);
            getFillData();
            customerId = selectedCustomerId;
            displayData();
        }
        void displayData()
        {
            if (customerId == 0)
                return;

            DataRow[] itemRows = DtCustomers.Select("Id=" + customerId);
            if (itemRows.Length > 0)
            {
                txtId.Text = customerId.ToString(); // itemRows[0][0]
                cmbCustomerName.SelectedValue = customerId;
                txtCompany.Text = itemRows[0][3].ToString();
                txtPhone.Text = itemRows[0][4].ToString();
                txtEmail.Text = itemRows[0][5].ToString();
                txtAddress.Text = itemRows[0][6].ToString();

                dgvCustomers.Rows[cr].Selected = true;
                dgvCustomers.FirstDisplayedScrollingRowIndex = cr;
            }

        }
        void getPageNum(int sequence)
        {
            if (sequence < pageSize)
            {
                pageNum = 1;
                cr = sequence - 1;
            }
            else if (sequence % pageSize == 0 & rowsCount != 0)
            {
                pageNum = (sequence / pageSize);
                cr = pageSize - 1;
            }
            else
            {
                pageNum = (sequence / pageSize) + 1;
                cr = (sequence % pageSize) - 1;
            }
        }
        void refreshInvoice()
        {
            FrmInvoices frmInvoice = Application.OpenForms.OfType<FrmInvoices>().FirstOrDefault(); //using System.Linq;
            if (frmInvoice != null)
            {
                frmInvoice.getFillData();  // Public void getFillData()
                frmInvoice.cmbCustomerName.SelectedIndex = -1;
            }

            FrmUpdateInvo frmUpdateInvo = Application.OpenForms.OfType<FrmUpdateInvo>().FirstOrDefault();
            if (frmUpdateInvo != null)
            {
                frmUpdateInvo.getCustomers();
                frmUpdateInvo.cmbCustomerName.SelectedIndex = -1;
            }
        }









    }
}