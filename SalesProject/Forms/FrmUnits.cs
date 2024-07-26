using SalesProject.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SalesProject.Forms
{
    public partial class FrmUnits : Form
    {
        public FrmUnits()
        {
            InitializeComponent();
        }

        DataSet dsUnit = new DataSet();
        int unitID, cr = -1;
        private void FrmUnits_Load(object sender, EventArgs e)
        {
            getFillData();
            setDgvHeader();
        }
        void getFillData()
        {
            SQLConClass.sqlQuery = "SELECT Id , ROW_NUMBER() OVER (ORDER BY (SELECT 1)) ت , Unit  FROM TblUnits ORDER BY Unit";
            SQLConClass sqlCon = new SQLConClass();
            dsUnit = sqlCon.selectData(SQLConClass.sqlQuery, 0, null);

            if (FunctionsClass.dsHasTables(dsUnit))
            {
                dgvUnits.DataSource = dsUnit.Tables[0];
                dgvUnits.ClearSelection();
            }
            else
                this.Close();
        }
        void setDgvHeader()
        {
            if (!FunctionsClass.dsHasTables(dsUnit))
                return;

            dgvUnits.Columns[0].Visible = false;
            dgvUnits.Columns[1].Width = 50;
            dgvUnits.Columns[2].HeaderText = "الوحدة";
        }
        private void dgvUnits_Click(object sender, EventArgs e)
        {
            if (FunctionsClass.checkDgvError((DataGridView)sender))
                return;
            cr = dgvUnits.CurrentRow.Index;
            displayData();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void txtUnit_TextChanged(object sender, EventArgs e)
        {
            if (unitID == 0)
            {
                dsUnit.Tables[0].DefaultView.RowFilter = " Unit like '%" + txtUnit.Text.Trim() + "%'";
            }
        }
        void displayData()
        {
            unitID = (int)dgvUnits.Rows[cr].Cells[0].Value;
            txtUnit.Text = dgvUnits.Rows[cr].Cells[2].Value.ToString();
            txtUnit.Focus();
        }
        void saveUnit()
        {
            if (txtUnit.Text == "")
                return;

            SQLConClass sqlCon = new SQLConClass();
            SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Unit", txtUnit.Text.Trim())
                                                      , new SqlParameter("@Id", unitID) };
            sqlCon.cmdExecute("SaveUnits", 1, param);

            getFillData();
            SelectItem();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (unitID != 0)
                btnRefresh.PerformClick();

            saveUnit();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (unitID == 0)
                return;
            saveUnit();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearData();
            getFillData();
        }
        void SelectItem()
        {
            DataRow[] itemRows = dsUnit.Tables[0].Select("Unit='" + txtUnit.Text.Trim() + "'");
            if (itemRows.Length > 0)
            {
                cr = Convert.ToInt32(itemRows[0][1]) - 1;
                dgvUnits.Rows[cr].Selected = true;
                dgvUnits.FirstDisplayedScrollingRowIndex = cr;
                displayData();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (unitID == 0)
            {
                MessageBox.Show("الرجاء تحديد عنصر من القائمة", "حذف بيانات", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (MessageBox.Show("هل تريد حذف بلد الصنع" + Environment.NewLine + Environment.NewLine + txtUnit.Text.Trim(), "حذف بيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {



                SQLConClass sqlCon = new SQLConClass();
                SqlParameter[] param = new SqlParameter[] { new SqlParameter("@Id", unitID) };

                VariablesClass.Save = sqlCon.cmdExecute("DeleteUnit", 1, param);

                if (VariablesClass.Save == 1)
                {
                    FunctionsClass.msgTool("تم الحذف بنجـــاح", 1);
                }
                else if (VariablesClass.Save == 2)
                {
                    FunctionsClass.msgTool("لم يتم الحذف، بلد الصنع مستخدم", 0);
                }


                //switch (VariablesClass.Save)
                //{
                //    case 1: // if
                //        {
                //            FunctionsClass.msgTool("تم الحفظ بنجاح", 1);
                //            break;
                //        }
                //    case 2:  // else if
                //        {
                //            FunctionsClass.msgTool("لم يتم الحفظ، تكرار في البيانات", 0);
                //            break;
                //        }
                //}

                btnRefresh.PerformClick();
            }

        }
        void clearData()
        {
            cr = -1;
            unitID = 0;
            txtUnit.Clear();
            dgvUnits.ClearSelection();
            txtUnit.Focus();
        }
    }
}
