using SalesProject.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SalesProject.Forms
{
    public partial class FrmItems : Form
    {
        public FrmItems()
        {
            InitializeComponent();
        }

        DataSet ds = new DataSet();
        DataTable dtCategoryLst = new DataTable();
        int itemId;
        ResizeControls r = new ResizeControls();
        private void FrmItems_Resize(object sender, EventArgs e)
        {
            r.ResizeControl();
            if (itemId == 0)
            {
                lstCategory.SelectedIndex = -1;
                lstItem.DataSource = null;
                txtUpdateCategory.Clear();
            }

        }
        private void FrmItems_HandleCreated(object sender, EventArgs e)
        {
            r.Container = this;

        }
        private void FrmItems_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void FrmItems_Load(object sender, EventArgs e)
        {
            getData();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearItem();
            clearCategories();
            getData();
        }
        void clearItem()
        {
            FunctionsClass.clear(grpItem);// tag=1 for exception
            itemId = 0;
        }
        void clearCategories()
        {
            txtUpdateCategory.Text = string.Empty;
            txtAddCategory.Clear();
            lstCategory.DataSource = null;
            lstItem.DataSource = null;
        }
        public void getData()
        {
            SQLConClass sqlCon = new SQLConClass();
            SQLConClass.sqlQuery = "SELECT Id,[Num],[Name],categoryId FROM TblItems WHERE Del='FALSE' ORDER BY [Name] SELECT Id,Category FROM TblCategories WHERE Del='FALSE' ORDER BY Category SELECT * FROM TblCountries ORDER BY Country SELECT * FROM TblUnits ORDER BY Unit";
            ds = sqlCon.selectData(SQLConClass.sqlQuery, 0, null);
            //if (FunctionsClass.dsHasTables((ds)) { }

            if (ds.Tables.Count == 4)
                fillData();
            else
                this.Close();

            txtNum.Focus();
        }
        void fillData()
        {
            cmbName.DataSource = ds.Tables[0];
            cmbName.DisplayMember = "Name";
            cmbName.ValueMember = "Id";
            cmbName.SelectedIndex = -1;

            cmbCategory.DataSource = ds.Tables[1];
            cmbCategory.DisplayMember = "Category";
            cmbCategory.ValueMember = "Id";
            cmbCategory.SelectedIndex = -1;

            dtCategoryLst = ds.Tables[1].Copy();

            lstCategory.DataSource = dtCategoryLst; // ds.Tables[1].Copy()
            lstCategory.DisplayMember = "Category";
            lstCategory.ValueMember = "Id";
            lstCategory.SelectedIndex = -1;

            cmbCountry.DataSource = ds.Tables[2];
            cmbCountry.DisplayMember = "Country";
            cmbCountry.ValueMember = "Id";
            cmbCountry.SelectedIndex = -1;

            cmbUnit.DataSource = ds.Tables[3];
            cmbUnit.DisplayMember = "Unit";
            cmbUnit.ValueMember = "Id";
            cmbUnit.SelectedIndex = -1;
        }
        private void picItem_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var ofd = new OpenFileDialog();
                ofd.Filter = "(Image Files)|*.jpg;*.png;*.bmp;*.gif;*.ico|Jpg, | *.jpg|Png, | *.png|Bmp, | *.bmp|Gif, | *.gif|Ico | *.ico";
                if (ofd.ShowDialog() == DialogResult.OK)
                    picItem.Image = Image.FromFile(ofd.FileName);
            }
        }
        private void cmsDelCategory_Click(object sender, EventArgs e)
        {
            btnDelCategory.PerformClick();
        }
        private void cmsDeletePicture_Click(object sender, EventArgs e)
        {
            picItem.Image = null;
        }
        private void btnCountry_Click(object sender, EventArgs e)
        {
            FrmCountries frmCountries = Application.OpenForms.OfType<FrmCountries>().FirstOrDefault();
            if (frmCountries == null)
                frmCountries = new FrmCountries();

            frmCountries.ShowDialog();
            getFillCountries();
        }
        void getFillCountries()
        {
            SQLConClass.sqlQuery = "SELECT * FROM TblCountries ORDER BY Country";
            SQLConClass sqlCon = new SQLConClass();
            DataSet dsCountry = new DataSet();
            dsCountry = sqlCon.selectData(SQLConClass.sqlQuery, 0, null);
            if (FunctionsClass.dsHasTables(dsCountry))
            {
                cmbCountry.DataSource = dsCountry.Tables[0];
                cmbCountry.DisplayMember = "Country";
                cmbCountry.ValueMember = "Id";
                cmbCountry.SelectedIndex = -1;
            }
        }
        private void btnUnit_Click(object sender, EventArgs e)
        {
            FrmUnits frmUnits = Application.OpenForms.OfType<FrmUnits>().FirstOrDefault();
            if (frmUnits == null)
                frmUnits = new FrmUnits();
            frmUnits.ShowDialog();
            getUnits();
        }
        void getUnits()
        {
            SQLConClass.sqlQuery = "SELECT * FROM TblUnits ORDER BY Unit";
            SQLConClass sqlCon = new SQLConClass();
            DataSet DSUnit = new DataSet();
            DSUnit = sqlCon.selectData(SQLConClass.sqlQuery, 0, null);
            if (FunctionsClass.dsHasTables(DSUnit))
            {
                cmbUnit.DataSource = DSUnit.Tables[0];
                cmbUnit.DisplayMember = "Unit";
                cmbUnit.ValueMember = "Id";
                cmbUnit.SelectedIndex = -1;
            }
        }
        private void btnDelCategory_Click(object sender, EventArgs e)
        {
            if (lstCategory.SelectedValue == null)
                return;

            if (MessageBox.Show("هل أنت متأكد تريد حذف المجموعة", "تأكيد حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SQLConClass sqlCon = new SQLConClass();
                SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@Id", lstCategory.SelectedValue) };

                if (sqlCon.cmdExecute("DeleteCategory", 1, param) == 3)
                    MessageBox.Show("تم إخفاءالمجموعة لأنها تحتوي أصناف " + Environment.NewLine + "تم إخفاء جميع الأصناف التي ضمن تصنيف هذه المجموعة" + Environment.NewLine + "من خلال نافذة إدارة البيانات المحذوفة يمكنك إسترجاع المجموعة والأصناف المحذوفة", "ارسال بيانات الى سلة المحذوفات", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            btnRefresh.PerformClick();

        }
        private void txtAddCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAddCategory.PerformClick();
        }
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (txtAddCategory.Text.Trim() == string.Empty)
                return;

            SQLConClass sqlCon = new SQLConClass();
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Category", txtAddCategory.Text.Trim()) };
            SQLConClass.sqlQuery = "IF NOT EXISTS(select Category from TblCategories where Category=@Category) INSERT INTO TblCategories(Category)VALUES(@Category)";
            sqlCon.cmdExecute(SQLConClass.sqlQuery, 0, param);

            btnRefresh.PerformClick();
            txtAddCategory.Focus();
        }
        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            if (lstCategory.SelectedValue == null | txtUpdateCategory.Text.Trim() == "" | txtUpdateCategory.Text.Length < 3)
                return;

            SQLConClass sqlCon = new SQLConClass();
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@Id", lstCategory.SelectedValue),
                new SqlParameter("@Category", txtUpdateCategory.Text.Trim()) };

            SQLConClass.sqlQuery = "IF NOT EXISTS(select * from TblCategories where Category= @Category AND Id<>@Id) UPDATE TblCategories Set Category=@Category WHERE Id=@Id";
            sqlCon.cmdExecute(SQLConClass.sqlQuery, 0, param);

            btnRefresh.PerformClick();
        }
        private void lstCategory_Click(object sender, EventArgs e)
        {
            if (lstCategory.SelectedValue == null)
                return;

            clearItem();
            lstItem.DataSource = null;
            txtUpdateCategory.Text = lstCategory.Text;

            DataRow[] itemRows = ds.Tables[0].Select("categoryId=" + lstCategory.SelectedValue, "Name ASC");
            if (itemRows.Length > 0)
            {
                //DataTable dtItems = new DataTable();
                //dtItems = itemRows.CopyToDataTable();

                lstItem.DataSource = itemRows.CopyToDataTable();
                lstItem.DisplayMember = "Name";
                lstItem.ValueMember = "Id";
            }
            lstItem.ClearSelected();
        }
        private void lstItem_Click(object sender, EventArgs e)
        {
            if (lstItem.SelectedValue == null)
                return;

            SQLConClass sqlCon = new SQLConClass();
            SQLConClass.sqlQuery = "SELECT * FROM TblItems WHERE Id=" + lstItem.SelectedValue;
            DataSet dsItem = sqlCon.selectData(SQLConClass.sqlQuery, 0, null);
            if (FunctionsClass.dshasTablesAndData(dsItem))
            {
                DataRow row = dsItem.Tables[0].Rows[0];

                itemId = (int)row[0];
                txtNum.Text = row[1].ToString();
                cmbName.Text = row[2].ToString();
                txtDescribe.Text = row[3].ToString(); ;
                cmbCategory.SelectedValue = row[4];
                cmbCountry.SelectedValue = row[5];
                cmbUnit.SelectedValue = row[6];
                if (row[7] is DBNull)
                    picItem.Image = null;
                else
                    picItem.Image = FunctionsClass.byteToImage((byte[])row[7]);
                txtStoreQuantity.Text = row[8].ToString();
                txtLowQuantity.Text = row[9].ToString();
                txtPurchasePrice.Text = row[10].ToString();
                txtSalePrice.Text = row[11].ToString();

                txtNum.SelectAll();
                txtNum.Focus();
            }
        }
        private void lstItem_DoubleClick(object sender, EventArgs e)
        {
            if (lstItem.SelectedValue == null)
                return;

            FrmMain frmMain = Application.OpenForms.OfType<FrmMain>().FirstOrDefault();
            if (frmMain != null)
                frmMain.btnInvoice.PerformClick();

            FrmInvoices frmInvoice = Application.OpenForms.OfType<FrmInvoices>().FirstOrDefault();
            if (frmInvoice == null)
                frmInvoice = new FrmInvoices();

            frmInvoice.txtItemNum.Text = txtNum.Text;
            frmInvoice.txtItemNum.Focus();
            SendKeys.Send("{ENTER}");
        }
        private void txtNum_TextChanged(object sender, EventArgs e)
        {
            if (txtNum.Text == string.Empty)
                lblBarcode.Text = string.Empty;
            else
                lblBarcode.Text = "*" + txtNum.Text + "*";
        }
        private void txtNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter & txtNum.Text != "")
            {
                refreshData();

                DataRow[] itemRows = ds.Tables[0].Select("Num=" + txtNum.Text);
                if (itemRows.Length > 0)
                    btnFindItemNum.PerformClick();
                else
                    cmbName.Focus();
            }
        }
        private void txtNum_Click(object sender, EventArgs e)
        {
            txtNum.SelectAll();

        }
        private void cmbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter & cmbName.Text != "")
                cmbName_SelectionChangeCommitted(sender, e);
        }
        private void cmbName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbName.SelectedValue == null)
            {
                MessageBox.Show("الصنف عير موجود", "بحث", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbName.Text = "";
                return;
            }

            DataRow[] itemRows = ds.Tables[0].Select("Id=" + cmbName.SelectedValue);

            lstCategory.SelectedValue = itemRows[0][3];
            lstCategory_Click(sender, e);
            lstItem.SelectedValue = itemRows[0][0];
            lstItem_Click(sender, e);
        }
        private void btnFindItemNum_Click(object sender, EventArgs e)
        {
            if (txtNum.Text.Trim() == string.Empty)
                return;

            refreshData();

            DataRow[] itemRows = ds.Tables[0].Select("Num=" + txtNum.Text.Trim());
            if (itemRows.Length > 0)
            {
                cmbName.SelectedValue = (int)itemRows[0][0];
                cmbName_SelectionChangeCommitted(sender, e);

                txtNum.SelectAll();
                txtNum.Focus();
            }
            else
                FunctionsClass.msgTool("الصنف عير موجود", 0);
        }
        void refreshData()
        {
            clearItem();
            clearCategories();
            getData();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (itemId == 0)
                return;

            if (MessageBox.Show("هل أنت متأكد تريد حذف هذا الصنف", "تأكيد حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SQLConClass sqlCon = new SQLConClass();
                SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Id", itemId) };

                if (sqlCon.cmdExecute("DeleteItem", 1, param) == 3)
                    FunctionsClass.msgTool("تم إخفاءالصنف فقط ولم يتم الحذف نهائي  ", 2);

                btnRefresh.PerformClick();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (FunctionsClass.checkEmptyInput(grpItem) == true) // cmbName.Tag=2
            {
                MessageBox.Show("الرجاء إدخال كافة بيانات الصنف", "ادخال بيانات", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cmbName.Text.Trim() == string.Empty)  // cmbName.Tag=2
            {
                MessageBox.Show("الرجاء إدخال اسم الصنف", "ادخال بيانات", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //**************************************************************************************
            DataRow[] perm = VariablesClass.dtUserPermissions.Select("OperationID=2");
            if ((bool)perm[0]["InsertP"] == false & itemId == 0)
            {
                MessageBox.Show("ليس لديك صلاحية الإضافة", "ادخال بيانات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if ((bool)perm[0]["UpdateP"] == false & itemId != 0)
            {
                MessageBox.Show("ليس لديك صلاحية التعديل", "ادخال بيانات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //***************************************************************************************


            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@Id", itemId),
                new SqlParameter("@Num", txtNum.Text.Trim()),
                new SqlParameter("@Name", cmbName.Text.Trim()),
                new SqlParameter("@Describe", txtDescribe.Text.Trim()),
                new SqlParameter("@categoryId", cmbCategory.SelectedValue),
                new SqlParameter("@CountryID", cmbCountry.SelectedValue),
                new SqlParameter("@UnitID", cmbUnit.SelectedValue),
                new SqlParameter("@StoreQuantity", txtStoreQuantity.Text),
                new SqlParameter("@LowQuantity", txtLowQuantity.Text),
                new SqlParameter("@PurchasePrice", txtPurchasePrice.Text),
                new SqlParameter("@SalePrice", txtSalePrice.Text),
                new SqlParameter("@Pic", (picItem.Image==null)? null: FunctionsClass.imageToByte(picItem))};

            SQLConClass sqlCon = new SQLConClass();
            ds = sqlCon.cmdExecuteData("SaveItem", param);

            if (ds.Tables.Count == 5)
            {
                clearItem();
                clearCategories();
                fillData();
                cmbName.SelectedValue = ds.Tables[4].Rows[0][0];
                cmbName_SelectionChangeCommitted(sender, e);
            }
        }

        private void cmbName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
