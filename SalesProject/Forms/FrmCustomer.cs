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
    public partial class FrmCustomer : Form
    {
        private DataSet dsCustomer = new DataSet();
        private int customerId;
        private ResizeControls r = new ResizeControls();

        private int pageSize;
        private int pageNum = 1;
        private int pagesCount;
        private int rowsCount;
        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void FrmCustomer_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                numericUpDown1.Value = Settings.Default.PageSize;
                getData();
                setDgvHeader();
            }
            else
            {
                dsCustomer.Clear();
            }
        }
        public void getData()
        {
            txtPageNum.Text = pageNum.ToString();
            pageSize = Settings.Default.PageSize;
            var sqlCon = new SQLConClass();
            ConClass.sqlQuery = "SELECT Id, ROW_NUMBER() OVER (ORDER BY (SELECT 1)) AS ت ,[Name] , Company ,CONVERT(NVARCHAR,Phone,100) ,Email,[Address],Id,Del FROM TblCustomers WHERE Del=0 ";
            ConClass.sqlQuery += " ORDER BY [Name] OFFSET " + pageSize * (pageNum - 1) + " ROWS FETCH NEXT " + pageSize + " ROWS ONLY";
            ConClass.sqlQuery += " SELECT COUNT(Id) FROM TblCustomers WHERE Del=0";
            dsCustomer = sqlCon.SelectData(ConClass.sqlQuery,0,  default);
            if (FunctionsClass.dsHasTables(dsCustomer) == true)
            {
                fillData();
                rowsCount = (int)dsCustomer.Tables[1].Rows[0][0];
                getPagesCount();
            }
        }
        // ------------------Pagination-------------------------------------------
        private void getPagesCount()
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
                pagesCount = rowsCount / pageSize + 1;
            }

            lblPagesCount.Text = pagesCount.ToString();
            txtPageNum.Text = pageNum.ToString();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            checkPageSize();

            if (pageNum < pagesCount)
            {
                pageNum += 1;
            }
            getData();
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
            getData();
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            pageNum = 1;
            getData();
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            checkPageSize();

            pageNum = pagesCount;
            getData();
        }


        private void checkPageSize()
        {
            if (pageSize != Settings.Default.PageSize)
            {
                pageNum = 1;
                getData(); // عند تغيير حجم الصفحة يجب معرفة عدد الصفحات الجديد pagesCount
            }
        }
        private void txtPageNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                checkPageSize();

                if (Convert.ToInt32(txtPageNum.Text) > Convert.ToInt32(lblPagesCount.Text))
                {
                    pageNum = Convert.ToInt32(lblPagesCount.Text);
                }
                else if (Convert.ToInt32(txtPageNum.Text) <= 0)
                {
                    pageNum = 1;
                }
                else
                {
                    pageNum = Convert.ToInt32(txtPageNum.Text);
                }
                getData();
            }
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value != 0 & Settings.Default.PageSize != numericUpDown1.Value)
            {
                Settings.Default.PageSize =(int) numericUpDown1.Value;
                Settings.Default.Save();
            }
        }
        private void setDgvHeader()
        {
            if (!FunctionsClass.dsHasTables(dsCustomer))
                return;
            {
                var withBlock = dgvCustomer;
                withBlock.ColumnHeadersDefaultCellStyle.Font = new Font("Hacen Saudi Arabia", 10);
                withBlock.Columns[0].Visible = false;
                withBlock.Columns[1].Width = 25;
                withBlock.Columns[2].HeaderText = "الاسم";
                withBlock.Columns[3].HeaderText = "الشركة";
                withBlock.Columns[4].HeaderText = "رقم الهاتف";
                withBlock.Columns[5].Visible = false;
                withBlock.Columns[6].HeaderText = "العنوان";
                withBlock.Columns[7].HeaderText = "رقم التسجيل";
                withBlock.Columns[8].Visible = false;
            }
        }
        private void fillData()
        {
            cmbCustomerName.DataSource = dsCustomer.Tables[0];
            cmbCustomerName.DisplayMember = "Name";
            cmbCustomerName.ValueMember = "Id";
            cmbCustomerName.SelectedIndex = -1;


            dgvCustomer.DataSource = dsCustomer.Tables[0];
            clearData();
        }
        private void clearData()
        {
            FunctionsClass.clear(groupBox1);
            customerId = 0;
            dgvCustomer.ClearSelection();
            cmbCustomerName.Focus();
        }

        public void btnRefresh_Click(object sender, EventArgs e)
        {
            getData();
        }
        //---------------------------------------------------------

        private void cmbCustomerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbCustomerName_SelectionChangeCommitted(sender, e);
        }

        private void cmbCustomerName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbCustomerName.SelectedValue == default)
            {
                MessageBox.Show("اسم العميل غير موجود", "بحث", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearData();
                return;
            }
            customerId = Convert.ToInt32(cmbCustomerName.SelectedValue);
            displayData();
        }
        private void displayData()
        {
            if (customerId == 0)
                return; // Extra code 
            DataRow[] itemRows = dsCustomer.Tables[0].Select("Id=" + customerId);
            if (itemRows.Length > 0)
            {
                txtID.Text = customerId.ToString(); // itemRows[0][0]
                cmbCustomerName.SelectedValue = customerId; // لاننا سنستدعي الدالة من DGV_Click-BtnSave
                txtCompany.Text = itemRows[0][3].ToString();

                if (itemRows[0][4].ToString() == "0")
                {
                    txtPhone.Text = "";
                }
                else
                {
                    txtPhone.Text = itemRows[0][4].ToString();
                }

                txtEmail.Text = itemRows[0][5].ToString();
                txtAddress.Text = itemRows[0][6].ToString();
            }
        }
        // -------------------------------------------------

        private void dgvCustomer_Click(object sender, EventArgs e)
        {
            if (FunctionsClass.checkDGVError(dgvCustomer))
                return;

            customerId = (int)dgvCustomer.Rows[dgvCustomer.CurrentRow.Index].Cells[0].Value;
            displayData();

            // An other way
            //cmbCustomerName.SelectedValue = (int)dgvCustomer.Rows[dgvCustomer.CurrentRow.Index].Cells[0].Value;
            //cmbCustomerName_SelectionChangeCommitted(sender, e);
        }

        private void dgvCustomer_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == dsCustomer.Tables[0].Rows.Count)
                return; // Extra code 

            if (e.ColumnIndex == 4)
            {
                if (dgvCustomer.Rows[e.RowIndex].Cells[4].Value.ToString() == "0")
                {
                    dgvCustomer.Rows[e.RowIndex].Cells[4].Value = "";
                }
                else if (dgvCustomer.Rows[e.RowIndex].Cells[4].Value.ToString().Length == 9)
                {
                    dgvCustomer.Rows[e.RowIndex].Cells[4].Value = "0" + dgvCustomer.Rows[e.RowIndex].Cells[4].Value;
                }
                else if (dgvCustomer.Rows[e.RowIndex].Cells[4].Value.ToString().Length == 12)
                {
                    dgvCustomer.Rows[e.RowIndex].Cells[4].Value = "00" + dgvCustomer.Rows[e.RowIndex].Cells[4].Value;
                }
            }
        }
        //-------------------------------------------------

        public void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            if (cmbCustomerName.Text.Trim() == "")
            {
                MessageBox.Show("الرجاء إدخال اسم العميل", "ادخال بيانات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cmbCustomerName.SelectedValue != null)
            {
                customerId = (int)cmbCustomerName.SelectedValue;
            }
            // ------------------------------------------------------------------
            DataRow[] perm = ConClass.dtUserPermission.Select("OperationID=3");
            if ((bool)perm[0][3] == false & customerId == 0)
            {
                MessageBox.Show("ليس لديك صلاحية الإضافة", "ادخال بيانات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if ((bool)perm[0][4] == false & customerId != 0)
            {
                MessageBox.Show("ليس لديك صلاحية التعديل", "ادخال بيانات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // ------------------------------------------------------------------

            var sqlCon = new SQLConClass();
            SqlParameter[] param = new SqlParameter[]
            { new SqlParameter("@Id", customerId),
                new SqlParameter("@Name", cmbCustomerName.Text.Trim()),
                new SqlParameter("@Company", txtCompany.Text.Trim()),
                new SqlParameter("@Phone", txtPhone.Text.Trim()),
                new SqlParameter("@Email", txtEmail.Text.Trim()),
                new SqlParameter("@Address", txtAddress.Text.Trim()) };

            dsCustomer = sqlCon.CMDExecuteData("SaveCustomer", param);
            if (FunctionsClass.dsHasTables(dsCustomer))
            {
                fillData();

                customerId = Convert.ToInt32(dsCustomer.Tables[1].Rows[0][0]);
                displayData();
                FrmInvoice frmInvoice = new FrmInvoice();
                frmInvoice.getData();  // Public VOID getData()
                frmInvoice.cmbCustomerName.SelectedValue = customerId;

                FrmUpdateInvo frmUpdateInvo = new FrmUpdateInvo();
                frmUpdateInvo.getCustomer();
                frmUpdateInvo.cmbCustomerName.SelectedValue = customerId;

                switch (VariablesClass.Save)
                {
                    case 2:
                        {
                            FunctionsClass.msgTool("لم يتم الحفظ، اسم العميل مسجل مسبقاً", 0);
                            break;
                        }
                }

            }





            //try
            //{
            //    ConClass.cmd = new SqlCommand("SaveCustomer", ConClass.con);
            //    ConClass.cmd.CommandType = CommandType.StoredProcedure;
            //    var param = new SqlParameter[6];
            //    param[0] = new SqlParameter("@Id", customerId);
            //    param[1] = new SqlParameter("@Name", cmbCustomerName.Text.Trim());
            //    param[2] = new SqlParameter("@Company", txtCompany.Text.Trim());
            //    param[3] = new SqlParameter("@Phone", txtPhone.Text.Trim());
            //    param[4] = new SqlParameter("@Email", txtEmail.Text.Trim());
            //    param[5] = new SqlParameter("@Address", txtAddress.Text.Trim());

            //    ConClass.cmd.Parameters.AddRange(param);
            //    ConClass.cmd.Parameters.Add("@SaveState", SqlDbType.Int).Direction = ParameterDirection.Output;


            //    ConClass.da = new SqlDataAdapter(ConClass.cmd);
            //    dsCustomer.clear();
            //    ConClass.con.Open();
            //    ConClass.da.Fill(dsCustomer);
            //    ConClass.con.Close();

            //    int SaveState = Convert.ToInt32(ConClass.cmd.Parameters["@SaveState"].Value.ToString());
            //    if (SaveState == 1)
            //    {
            //        FunctionsClass.msgTool("تم الحفظ بنجاح", 1);
            //        btnNew_Click(sender, e);
            //    }
            //    else if (SaveState == 2)
            //    {
            //        FunctionsClass.msgTool("لم يتم الحفظ الاسم موجود مسبقاً", 0);
            //    }
            //    else if (SaveState == 0)
            //    {
            //        MessageBox.Show("خطأ في تنفيذ العملية", "فشل الحفظ ");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ConClass.con.Close();
            //    MessageBox.Show("خطأ في الإتصال بقواعد البيانات" + Environment.NewLine + ex.Message, "خطأ إتصال ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

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
                var sqlCon = new SQLConClass();
                SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Id", customerId) };
                dsCustomer = sqlCon.CMDExecuteData("DeleteCustomer", param);
                if (FunctionsClass.dsHasTables(dsCustomer))
                {
                    fillData();
                    FrmInvoice frmInvoice = new FrmInvoice();
                    frmInvoice.getData();
                    if (VariablesClass.Save == 3)
                        MessageBox.Show("لم يتم الحذف، تم اخفاءالعميل لديه سجل في المبيعات " + Environment.NewLine + " بامكانك استعادة العميل من شاشة ادارة البيانات المحذوفة", "اخفاء بيانات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        //-------------------------------------------------

        private void FrmCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            FunctionsClass.userTrafficRegister(this.Name, false);
        }



        private void FrmCustomer_Resize(object sender, EventArgs e)
        {
            r.ResizeControl();
        }
        private void FrmCustomer_HandleCreated(object sender, EventArgs e)
        {
            r.Container = this;
        }

    }
}
