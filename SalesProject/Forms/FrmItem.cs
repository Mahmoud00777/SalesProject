using SalesProject.Classes;
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
    public partial class FrmItem : Form
    {
        private DataSet ds = new DataSet();
        private DataTable dtCategoryLst = new DataTable();
        private int itemId;
        private ResizeControls r = new ResizeControls();
        public FrmItem()
        {
            InitializeComponent();
        }

        private void FrmItem_Load(object sender, EventArgs e)
        {
            getFillData();
        }

        private void FrmItem_Resize(object sender, EventArgs e)
        {
            r.ResizeControl();
            if (itemId == 0)
            {
                lstCategory.SelectedIndex = -1;
                lstItem.DataSource = null;
                txtUpdateCategory.Clear();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearItem();
            txtUpdateCategory.Text = string.Empty;
            txtAddCategory.Clear();
            lstCategory.DataSource = null;
            lstItem.DataSource = null;
            getFillData();
        }
        private void clearItem()
        {
            FunctionsClass.clear(grpItem);
            //txtDescribe.Text = "";
            itemId = 0;
        }
        public void getFillData()
        {
            var sqlCon = new SQLConClass();
            ConClass.sqlQuery = "SELECT Id,[Num],[Name],categoryId FROM TblItems WHERE Del='FALSE' ORDER BY [Name] SELECT Id,Category FROM TblCategories WHERE Del='FALSE' ORDER BY Category SELECT * FROM TblCountries ORDER BY Country SELECT * FROM TblUnits ORDER BY Unit";
            ds = sqlCon.SelectData(ConClass.sqlQuery, 0, null);
            //if (FunctionsClass.FunctionsClass.dsHasTables((ds)) { }

            if (ds.Tables.Count == 4)
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
            txtNum.Focus();
        }
        // -------------------------------------------------------------
        private void picItem_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var OFD = new OpenFileDialog();
                OFD.Filter = "(Image Files)|*.jpg;*.png;*.bmp;*.gif;*.ico|Jpg, | *.jpg|Png, | *.png|Bmp, | *.bmp|Gif, | *.gif|Ico | *.ico";
                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    picItem.Image = Image.FromFile(OFD.FileName);
                }
            }
        }


        private void cmsDeletePicture_Click(object sender, EventArgs e)
        {
            picItem.Image = null;

        }
        private void btnCountry_Click(object sender, EventArgs e)
        {
            FrmCountry frmCountry = Application.OpenForms.OfType<FrmCountry>().FirstOrDefault();
            if (frmCountry == null)
            {
                frmCountry = new FrmCountry();
            }
            frmCountry.ShowDialog();
            getCountry();
        }
        private void getCountry()
        {
            ConClass.sqlQuery = "SELECT * FROM TblCountries ORDER BY Country";
            var sqlCon = new SQLConClass();
            var dsCountry = new DataSet();
            dsCountry = sqlCon.SelectData(ConClass.sqlQuery, 0, null);
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
            FrmUnit frmUnit = Application.OpenForms.OfType<FrmUnit>().FirstOrDefault();
            if (frmUnit == null)
            {
                frmUnit = new FrmUnit();
            }
            frmUnit.ShowDialog();
            getUnit();
        }

        private void getUnit()
        {
            ConClass.sqlQuery = "SELECT * FROM TblUnits ORDER BY Unit";
            var sqlCon = new SQLConClass();
            var DSUnit = new DataSet();
            DSUnit = sqlCon.SelectData(ConClass.sqlQuery, 0, null);
            if (FunctionsClass.dsHasTables(DSUnit))
            {
                cmbUnit.DataSource = DSUnit.Tables[0];
                cmbUnit.DisplayMember = "Unit";
                cmbUnit.ValueMember = "Id";
                cmbUnit.SelectedIndex = -1;
            }
        }
        // ----------------------------Category------------------------------

        private void btnDelCategory_Click(object sender, EventArgs e)
        {
            cmsDelCategory_Click(sender, e);
        }
        private void cmsDelCategory_Click(object sender, EventArgs e)
        {
            if (lstCategory.SelectedValue == null)
            {
                return;
            }
            if (MessageBox.Show("هل أنت متأكد تريد حذف المجموعة", "تأكيد حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var sqlCon = new SQLConClass();
                SqlParameter[] param = new SqlParameter[] { 
                    new SqlParameter("@Id", lstCategory.SelectedValue) };

                switch (sqlCon.CMDExecute("DeleteCategory", 1, param))
                {
                    case 3:
                        {
                            MessageBox.Show("تم إخفاءالمجموعة لأنها تحتوي أصناف " + Environment.NewLine + "تم إخفاء جميع الأصناف التي ضمن تصنيف هذه المجموعة" + Environment.NewLine + "من خلال نافذة إدارة البيانات المحذوفة يمكنك إسترجاع المجموعة والأصناف المحذوفة", "ارسال بيانات الى سلة المحذوفات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                }
            }
            btnRefresh.PerformClick();
        }

        private void txtAddCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnAddCategory_Click(sender, e);
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            if (txtAddCategory.Text.Trim() == string.Empty)
                return;

            var sqlCon = new SQLConClass();
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Category", txtAddCategory.Text.Trim()) };
            ConClass.sqlQuery = "IF NOT EXISTS(select Category from TblCategories where Category=@Category)  INSERT INTO TblCategories(Category)VALUES(@Category)";
            sqlCon.CMDExecute(ConClass.sqlQuery, 0, param);

            btnRefresh.PerformClick();
            txtAddCategory.Focus();
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            if (lstCategory.SelectedValue == null | txtUpdateCategory.Text.Trim() == "" | txtUpdateCategory.Text.Length < 3)
            {
                return;
            }

            var sqlCon = new SQLConClass();
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Id", lstCategory.SelectedValue), new SqlParameter("@Category", txtUpdateCategory.Text.Trim()) };
            ConClass.sqlQuery = "IF NOT EXISTS(select  Category from TblCategories where Category= @Category AND Id<>@Id) UPDATE TblCategories Set Category=@Category WHERE Id=@Id";
            sqlCon.CMDExecute(ConClass.sqlQuery, 0, param);

            btnRefresh.PerformClick();
        }

        private void lstCategory_Click(object sender, EventArgs e)
        {
            if (lstCategory.SelectedValue == null)
                return;
            clearItem();
            txtUpdateCategory.Text = lstCategory.Text;
            lstItem.DataSource = null;

            DataRow[] itemRows = ds.Tables[0].Select("categoryId=" + lstCategory.SelectedValue, "Name ASC");
            if (itemRows.Length > 0)
            {

                var dtItem = new DataTable();
                dtItem = itemRows.CopyToDataTable();

                lstItem.DataSource = itemRows.CopyToDataTable();
                lstItem.DisplayMember = "Name";
                lstItem.ValueMember = "Id";
            }
            lstItem.ClearSelected();
        }
        //----------------------------------------------------------

        private void lstItem_Click(object sender, EventArgs e)
        {
            if (lstItem.SelectedValue == null)
                return;

            var dsItem = new DataSet();
            var sqlCon = new SQLConClass();
            ConClass.sqlQuery = "SELECT * FROM TblItems WHERE Id=" + lstItem.SelectedValue;
            dsItem = sqlCon.SelectData(ConClass.sqlQuery, 0, null);
            if (FunctionsClass.dshasTablesAndData(dsItem))
            {
                {
                    var Row = dsItem.Tables[0].Rows[0];

                    itemId = Convert.ToInt32( Row.ItemArray[0]);
                    txtNum.Text = Row.ItemArray[1].ToString();
                    cmbName.Text = Row.ItemArray[2].ToString();
                    txtDescribe.Text = Row.ItemArray[3].ToString(); ;
                    cmbCategory.SelectedValue = Row.ItemArray[4];
                    cmbCountry.SelectedValue = Row.ItemArray[5];
                    cmbUnit.SelectedValue = Row.ItemArray[6];
                    if (Row.ItemArray[7] is DBNull)
                    {
                        picItem.Image = null;
                    }
                    else
                    {
                        picItem.Image = FunctionsClass.byteToImage((byte[])Row.ItemArray[7]);
                    }
                    txtStoreQuantity.Text = Row.ItemArray[8].ToString();
                    txtLowQuantity.Text = Row.ItemArray[9].ToString();
                    txtPurchasePrice.Text = Row.ItemArray[10].ToString();
                    txtSalePrice.Text = Row.ItemArray[11].ToString();
                }
                txtNum.SelectAll();
                txtNum.Focus();
            }
        }

        private void lstItem_DoubleClick(object sender, EventArgs e)
        {
            if (lstItem.SelectedValue == null)
                return;
            FrmMain frmMain = Application.OpenForms.OfType<FrmMain>().FirstOrDefault();
            if (frmMain == null)
            {
                frmMain = new FrmMain();
            }
            frmMain.btnInvoice.PerformClick();
            FrmInvoice frmInvoice = Application.OpenForms.OfType<FrmInvoice>().FirstOrDefault();
            if (frmInvoice == null)
            {
                frmInvoice = new FrmInvoice();
            }
            frmInvoice.txtItemNum.Text = txtNum.Text;
            frmInvoice.txtItemNum.Focus();
            SendKeys.Send("{ENTER}");
        }
        // -----------------------------------------------------------
        private void txtNum_TextChanged(object sender, EventArgs e)
        {
            if (txtNum.Text.Trim() == string.Empty )
            {
                lblBarcode.Text = string.Empty;
            }
            else
            {
                lblBarcode.Text = string.Format(txtNum.Text, "*000000*");
            }
        }

        private void txtNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbName.Focus();
        }

        private void txtNum_Click(object sender, EventArgs e)
        {
            txtNum.SelectAll();

        }

        private void btnFindItemNum_Click(object sender, EventArgs e)
        {
            if (txtNum.Text.Trim() == string.Empty)
                return;

            DataRow[] itemRows = ds.Tables[0].Select("Num=" + txtNum.Text.Trim());
            if (itemRows.Length > 0)
            {
                itemId = Convert.ToInt32( itemRows[0][0]);
                cmbName.SelectedValue = itemId;
                cmbName_SelectionChangeCommitted(sender, e);
                txtNum.SelectAll();
                txtNum.Focus();
            }
            else
            {
                FunctionsClass.msgTool("رقم الصنف عير موجود", 0);
                btnRefresh.PerformClick();
            }
        }
        // -------------------------------------------------------
        private void cmbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbName_SelectionChangeCommitted(sender, e);
        }

        private void cmbName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbName.SelectedValue == null)
            {
                MessageBox.Show("اسم الصنف عير موجود", "بحث", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbName.Text = "";
                return;
            }

            DataRow[] itemRows = ds.Tables[0].Select("Id=" + cmbName.SelectedValue);

            lstCategory.SelectedValue = itemRows[0][3];
            lstCategory_Click(sender, e);
            lstItem.SelectedValue = itemRows[0][0];
            lstItem_Click(sender, e);
        }
        //--------------------------------------------------------

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (itemId == 0)
                return;

            if (MessageBox.Show("هل أنت متأكد تريد حذف هذا الصنف", "تأكيد حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var sqlCon = new SQLConClass();
                SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Id", itemId) };

                switch (sqlCon.CMDExecute("DeleteItem", 1, param))
                {
                    case 3:
                        {
                            FunctionsClass.msgTool("تم إخفاءالصنف فقط ولم يتم الحذف نهائي  ", 2);
                            break;
                        }
                }
                btnRefresh.PerformClick();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (FunctionsClass.checkEmptyInput(grpItem) == true) // cmbName.Tag=1
            {
                MessageBox.Show("الرجاء إدخال كافة بيانات الصنف", "ادخال بيانات", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cmbName.Text == "")
            {
                MessageBox.Show("الرجاء ادخال اسم الصنف", "ادخال بيانات", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            // ------------------------------------------------------------------
            DataRow[] perm = ConClass.dtUserPermission.Select("OperationID=2");
            if ((bool)perm[0][3] == false & itemId == 0)
            {
                MessageBox.Show("ليس لديك صلاحية الإضافة", "ادخال بيانات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if ((bool)perm[0][4] == false & itemId != 0)
            {
                MessageBox.Show("ليس لديك صلاحية التعديل", "ادخال بيانات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // ------------------------------------------------------------------
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@Id", itemId),
                new SqlParameter("@Num", txtNum.Text),
                new SqlParameter("@Name", cmbName.Text),
                new SqlParameter("@Describe", txtDescribe.Text),
                new SqlParameter("@categoryId", cmbCategory.SelectedValue),
                new SqlParameter("@CountryID", cmbCountry.SelectedValue),
                new SqlParameter("@UnitID", cmbUnit.SelectedValue),
                new SqlParameter("@StoreQuantity", txtStoreQuantity.Text),
                new SqlParameter("@LowQuantity", txtLowQuantity.Text),
                new SqlParameter("@PurchasePrice", txtPurchasePrice.Text),
                new SqlParameter("@SalePrice", txtSalePrice.Text),
                new SqlParameter("@Pic", FunctionsClass.imageToByte(picItem))
            };
            param[11].SqlDbType = SqlDbType.VarBinary;

            var sqlCon = new SQLConClass();
            var dsItem = new DataSet();
            dsItem = sqlCon.CMDExecuteData("SaveItem", param);
            if (FunctionsClass.dsHasTables(dsItem))
            {
                if ((int)dsItem.Tables[0].Rows[0][0] != 0) // في حالة اضافة رقم او اسم صنف موجود
                {
                    btnRefresh.PerformClick();
                    cmbName.SelectedValue = dsItem.Tables[0].Rows[0][0];
                    cmbName_SelectionChangeCommitted(sender, e);
                }
                else
                {
                    FunctionsClass.msgTool("لم يتم الحفظ، اسم او رقم الصنف موجود مسبقاً", 0);
                }

            }
        }


        private void FrmItem_HandleCreated(object sender, EventArgs e)
        {
            r.Container = this;

        }
        private void FrmItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            FunctionsClass.userTrafficRegister(this.Name, false);

        }


    }
}
