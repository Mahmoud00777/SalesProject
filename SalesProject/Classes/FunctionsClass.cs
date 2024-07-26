using SalesProject.Classes;
using SalesProject.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesProject
{
    class FunctionsClass
    {
        public static bool dsHasTables(DataSet ds)
        {
            if (ds == null)
                return false;

            if (ds.Tables.Count > 0)
                return true;
            else
                return false;
        }
        public static bool checkDgvError(DataGridView dgv)
        {
            try
            {
                if (dgv.CurrentRow == null) return true;
                if (dgv.CurrentRow.Index == dgv.Rows.Count
                    | dgv.Rows[dgv.CurrentRow.Index].Cells[0].Value == null
                    | dgv.Rows[dgv.CurrentRow.Index].Selected == false)
                    return true;
            }
            catch
            {
                return true;
            }
            return false;
        }
        public static void msgTool(string msg, int style)
        {
            FrmMain frmMain = Application.OpenForms.OfType<FrmMain>().FirstOrDefault();
            if (frmMain != null)
            {
                if (style == 1)//succesfull
                    frmMain.statusStrip1.BackColor = Color.FromArgb(128, 255, 128);
                else if (style == 2)//warning
                    frmMain.statusStrip1.BackColor = Color.FromArgb(255, 255, 128);
                else if (style == 0)// Error
                    frmMain.statusStrip1.BackColor = Color.FromArgb(255, 128, 128);

                frmMain.tslMessage.Visible = true;
                frmMain.tslMessage.Text = msg;

                frmMain.timer1.Tag = 1;
            }
        }
        public static void barMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                VariablesClass.sw = true;
                VariablesClass.pos = e.Location;
            }
        }
        public static void barMouseMove(Form f, MouseEventArgs e)
        {
            if (VariablesClass.sw == true)
                f.Location = new Point(f.Location.X + (e.X - VariablesClass.pos.X), f.Location.Y + (e.Y - VariablesClass.pos.Y));
        }
        public static void barMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                VariablesClass.sw = false;
        }
        public static bool isPositiveIntNum(KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) | (Keys)e.KeyChar == Keys.Back)
                return true;
            else
                return false;
        }
        public static bool isPositiveRealNum(TextBox sender, KeyPressEventArgs e)
        {
            if (char.IsNumber((char)e.KeyChar)
                | (Keys)e.KeyChar == Keys.Back
                | ((Keys)e.KeyChar == (Keys)46 & sender.Text.IndexOf(".") == -1 & sender.Text.Length != 0))
                return true;
            else
                return false;

        }
        public static bool isRealNum(TextBox sender, KeyPressEventArgs e)
        {
            if (char.IsNumber((char)e.KeyChar)
                | (Keys)e.KeyChar == Keys.Back
                | ((Keys)e.KeyChar == (Keys)46 & sender.Text.IndexOf(".") == -1 & sender.Text.Length != 0)
                | ((Keys)e.KeyChar == (Keys)45 & sender.Text.Length == 0))
                return true;
            else
                return false;

        }
        public static Image byteToImage(byte[] img)
        {
            var ms = new MemoryStream(img);
            return Image.FromStream(ms);
        }
        public static void clear(GroupBox g) // tag=1 for exception
        {
            ComboBox cmb;
            PictureBox p;

            foreach (Control c in g.Controls)
            {
                int tagVal = 0;

                if (c is TextBox)
                {
                    if (c.Tag != null)
                        int.TryParse(c.Tag.ToString(), out tagVal);
                    if (tagVal != 1)
                        c.Text = "";
                }

                else if (c is ComboBox)
                {
                    cmb = (ComboBox)c;
                    if (cmb.Tag != null)
                        int.TryParse(cmb.Tag.ToString(), out tagVal);
                    if (tagVal != 1)
                        cmb.SelectedIndex = -1;
                }
                else if (c is PictureBox)
                {
                    p = (PictureBox)c;
                    if (p.Tag != null)
                        int.TryParse(p.Tag.ToString(), out tagVal);
                    if (tagVal != 1)
                        p.Image = null;
                }
            }
        }
        public static DataTable columnHeaderMouseClick(DataGridView dgv, DataTable dt)
        {
            if (dgv.SortOrder.ToString() == "Ascending")
                dt.DefaultView.Sort = dgv.SortedColumn.Name + " ASC";
            else if (dgv.SortOrder.ToString() == "Descending")
                dt.DefaultView.Sort = dgv.SortedColumn.Name + " DESC";

            dgv.ClearSelection();
            return dt.DefaultView.ToTable();
        }
        public static bool dshasTablesAndData(DataSet ds)
        {
            if (ds == null)
                return false;

            if (ds.Tables.Count > 0)
            {
                foreach (DataTable dt in ds.Tables)
                {
                    if (dt.Rows.Count == 0)
                        return false;
                }
            }
            else
            {
                return false;
            }
            return true;
        }
        public static bool checkEmptyInput(GroupBox g) // tag=2 for exception
        {
            ComboBox cmb = default;

            foreach (Control c in g.Controls)
            {
                int tagVal = 0;
                if (c is TextBox)
                {
                    if (c.Tag != null)
                        int.TryParse(c.Tag.ToString(), out tagVal);

                    if (c.Text.Trim() == "" & tagVal != 2)
                        return true;
                }

                else if (c is ComboBox)
                {
                    cmb = (ComboBox)c;

                    if (cmb.Tag != null)
                        int.TryParse(cmb.Tag.ToString(), out tagVal);

                    if (cmb.SelectedIndex == -1 & tagVal != 2)
                        return true;
                }
            }
            return false;
        }
        public static byte[] imageToByte(PictureBox pic)
        {
            var ms = new MemoryStream();
            if (!(pic.Image == null))
                pic.Image.Save(ms, ImageFormat.Png);
            return ms.ToArray();
        }
        public static void setPermissions()
        {
            FrmMain frmMain = Application.OpenForms.OfType<FrmMain>().FirstOrDefault(); //using System.Linq;
            FrmInvoices frmInvoices = Application.OpenForms.OfType<FrmInvoices>().FirstOrDefault();
            FrmInvoReports frmInvoReports = Application.OpenForms.OfType<FrmInvoReports>().FirstOrDefault();
            FrmUpdateInvo frmUpdateInvo = Application.OpenForms.OfType<FrmUpdateInvo>().FirstOrDefault();
            FrmStore frmStore = Application.OpenForms.OfType<FrmStore>().FirstOrDefault();
            FrmItems frmItem = Application.OpenForms.OfType<FrmItems>().FirstOrDefault();
            FrmCustomers frmCustomer = Application.OpenForms.OfType<FrmCustomers>().FirstOrDefault();


            DataRow[] perm;

            // '---1----إعدادات النظام والنسخ الإحتياطي-------
            {
                perm = VariablesClass.dtUserPermissions.Select("OperationID=1");
                if ((bool)perm[0]["InsertP"] == false)
                {
                    frmMain.tsmSettings.Enabled = false;
                }
                else
                {
                    frmMain.tsmSettings.Enabled = true;
                }

            }
            // '----2-----إدارة المستخدمين---------------------
            {
                perm = VariablesClass.dtUserPermissions.Select("OperationID=2");
                if ((bool)perm[0]["InsertP"] == false)
                {
                    frmMain.tsmUserControl.Enabled = false;
                }
                else
                {
                    frmMain.tsmUserControl.Enabled = true;
                }
            }
            // '-----3----مراقبة النظام-----------------------
            {
                perm = VariablesClass.dtUserPermissions.Select("OperationID=3");
                if ((bool)perm[0]["InsertP"] == false)
                {
                    frmMain.tsmMonitor.Enabled = false;
                }
                else
                {
                    frmMain.tsmMonitor.Enabled = true;
                }
            }
            // '----4-----إدارة البيانات المحذوفة--------------
            {
                perm = VariablesClass.dtUserPermissions.Select("OperationID=4");
                if ((bool)perm[0]["InsertP"] == false)
                {
                    frmMain.tsmDeletedElements.Enabled = false;
                }
                else
                {
                    frmMain.tsmDeletedElements.Enabled = true;
                }
            }
            // '-----5---- إدارة التقارير والاحصائيات----------
            {
                perm = VariablesClass.dtUserPermissions.Select("OperationID=5");
                if ((bool)perm[0][3] == false)
                {
                    frmMain.btnChart.Enabled = false;
                }
                else
                {
                    frmMain.btnChart.Enabled = true;
                }
            }
            // '----6-----إدارة الزبائن------------------
            {
                perm = VariablesClass.dtUserPermissions.Select("OperationID=6");
                if ((bool)perm[0][3] == false & (bool)perm[0][4] == false & (bool)perm[0][5] == false)
                {
                    frmMain.btnCustomer.Enabled = false;
                }
                else
                {
                    frmMain.btnCustomer.Enabled = true;
                }

                if ((bool)perm[0]["DeleteP"] == false)
                {
                    if (frmCustomer != null)
                    {
                        frmCustomer.btnDelete.Enabled = false;
                    }
                }
                else
                {
                    if (frmCustomer != null)
                    {
                        frmCustomer.btnDelete.Enabled = true;
                    }
                }
            }
            // ----7-----إدارة الأصناف--------------------
            {
                perm = VariablesClass.dtUserPermissions.Select("OperationID=7");

                if ((bool)perm[0]["DeleteP"] == false)
                {
                    if (frmItem != null)
                    {
                        frmItem.btnDelete.Enabled = false;
                    }
                }
                else
                {
                    if (frmItem != null)
                    {
                        frmItem.btnDelete.Enabled = true;
                    }
                }
                if ((bool)perm[0]["PrintP"] == false)
                {
                    if (frmStore != null)
                    {
                        frmStore.picPrint.Enabled = false;
                    }
                }
                else
                {
                    if (frmStore != null)
                    {
                        frmStore.picPrint.Enabled = true;
                    }
                }

            }
            // ----8-----فواتير المبيعات-----------------
            {
                perm = VariablesClass.dtUserPermissions.Select("OperationID=8");

                frmMain.btnInvoice.Enabled = true;

                if ((bool)perm[0]["InsertP"] == false)
                {
                    if (frmInvoices != null)
                    {
                        frmInvoices.btnSave.Enabled = false;
                    }
                }
                else
                {
                    if (frmInvoices != null)
                    {
                        frmInvoices.btnSave.Enabled = true;
                    }
                }
                if ((bool)perm[0]["UpdateP"] == false)
                {
                    if (frmUpdateInvo != null)
                    {
                        frmUpdateInvo.btnSave.Enabled = false;
                    }
                }
                else
                {
                    if (frmUpdateInvo != null)
                    {
                        frmUpdateInvo.btnSave.Enabled = true;
                    }
                }
                if ((bool)perm[0]["DeleteP"] == false)
                {
                    if (frmInvoReports != null)
                    {
                        frmInvoReports.btnDelInvo.Enabled = false;
                    }
                }
                else
                {
                    if (frmInvoReports != null)
                    {
                        frmInvoReports.btnDelInvo.Enabled = true;
                    }
                }
                if ((bool)perm[0]["PrintP"] == false)
                {
                    if (frmInvoices != null)
                    {
                        frmInvoices.btnPrint.Enabled = false;
                    }
                    if (frmInvoReports != null)
                    {
                        frmInvoReports.btnPrintSearch.Enabled = false;
                    }
                }
                else
                {
                    if (frmInvoices != null)
                    {
                        frmInvoices.btnPrint.Enabled = true;
                    }
                    if (frmInvoReports != null)
                    {
                        frmInvoReports.btnPrintSearch.Enabled = true;
                    }
                }
            }
        }
        public static void userTrafficRegister(string Frm, bool Entry)
        {
            if (VariablesClass.userId == 0)
            {
                return;
            }

            try
            {
                ConClass.cmd = new SqlCommand("userTrafficRegister", ConClass.con);
                ConClass.cmd.CommandType = CommandType.StoredProcedure;
                var param = new SqlParameter[3];

                param[0] = new SqlParameter("@userId", VariablesClass.userId);
                param[1] = new SqlParameter("@FormName", Frm);
                param[2] = new SqlParameter("@Entry", Entry);
                ConClass.cmd.Parameters.AddRange(param);

                ConClass.con.Open();
                ConClass.cmd.ExecuteNonQuery();
                ConClass.con.Close();
            }

            // ملاحظة : يوجد Trigger يعمل على جدول مراقبة حركة المستخدمين ويقوم تلقائيا بحذف اي حركة قديمة قبل 180 يوم

            catch (Exception ex)
            {
                ConClass.con.Close();
                MessageBox.Show("خطأ في تحديث بيانت حركة المستخدم" + Environment.NewLine + ex.Message, "خطأ إتصال بقواعد البيانات", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }










    }
}
