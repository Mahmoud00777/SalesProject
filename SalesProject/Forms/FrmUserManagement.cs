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
    public partial class FrmUserManagement : Form
    {
        public string currentMessage;
        private int currentUserID, cr;
        private bool swbtn;
        private DataSet dsUser = new DataSet();
        private DataTable dtUser = new DataTable(), dtDelUser = new DataTable(), dtOp = new DataTable(), dtPerm = new DataTable();
        public FrmUserManagement()
        {
            InitializeComponent();
        }

        private void FrmUserManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            FunctionsClass.userTrafficRegister(this.Name, false);
            VariablesClass.mainActive = true;
        }

        private void FrmUserManagement_Load(object sender, EventArgs e)
        {
            FunctionsClass.userTrafficRegister(this.Name, true);

            label1.Parent = picUser;
            label1.Top = 140;
            label1.Left = 30;

            getData();
            distributeData();
            fillUserDGV(dtUser);
            cmbOperation.DataSource = dsUser.Tables[1];
            cmbOperation.DisplayMember = "OperationName";
            cmbOperation.ValueMember = "Id";
            cmbOperation.SelectedIndex = -1;
        }
        private void getData()
        {
            try
            {
                dsUser.Clear();
                //ConClass.ConClass.sqlQuery = "SELECT * FROM TblUsers SELECT * FROM TblOperations SELECT * FROM TblPermissions";
                ConClass.sqlQuery = "SELECT * FROM TblUsers ";
                ConClass.sqlQuery += "SELECT * FROM TblOperations ";
                ConClass.sqlQuery += "SELECT * FROM TblPermissions";
                ConClass.da = new SqlDataAdapter(ConClass.sqlQuery, ConClass.con);
                ConClass.da.Fill(dsUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show("فشل في الإتصال بقاعدة البيانات" + ex.Message, "خطأ إتصال", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void distributeData()
        {
            // ----------------LoadEnabledUser-------------------------
            dtUser = dsUser.Tables[0].Clone(); // Copy Design of table
                                               // ----نفس السطر السابق-------
                                               //dtUser = dsUser.Tables[0].Copy();
                                               //dtUser.Clear();
                                               // ---------------------------
            DataRow[] itemRows = dsUser.Tables[0].Select("Del='FALSE'");
            if (itemRows.Length > 0)
            {
                dtUser = itemRows.CopyToDataTable();
            }
            //foreach (DataRow DR in dsUser.Tables[0].Select("Del='FALSE'"))
            //    dtUser.ImportRow(DR);
            // ----------------LoadDeletedUser-------------------------

            dtDelUser = dsUser.Tables[0].Clone();

            itemRows = dsUser.Tables[0].Select("Del='TRUE'");
            if (itemRows.Length > 0)
            {
                dtDelUser = itemRows.CopyToDataTable();
            }

            //foreach (var DR in dsUser.Tables[0].Select("Del='TRUE'"))
            //    dtDelUser.ImportRow(DR);
            // -----------------------------------------


            setImg();
        }
        private void setImg()
        {
            if (picUser.Image == null)
            {
                picUser.BackgroundImage = Properties.Resources.user;
            }
            else
            {
                picUser.BackgroundImage = null;
            }
            cmbOperation.SelectedIndex = -1;
        }
        private void fillUserDGV(DataTable DT)
        {
            dgvUser.Rows.Clear();
            for (int i = 0; i <= DT.Rows.Count - 1; i++)
            {

                dgvUser.Rows.Add();

                dgvUser.Rows[i].Cells[0].Value = i + 1;
                dgvUser.Rows[i].Cells[1].Value = DT.Rows[i][1];
                dgvUser.Rows[i].Cells[2].Value = DT.Rows[i][3];
                dgvUser.Rows[i].Cells[3].Value = DT.Rows[i][0];
                dgvUser.Rows[i].Cells[4].Value = DT.Rows[i][1];
                if ((bool)DT.Rows[i][8] == false)
                {
                    dgvUser.Rows[i].Cells[4].Value = "فعال";
                }
                else
                {
                    dgvUser.Rows[i].Cells[4].Value = "موقوف";
                    dgvUser.Rows[i].Cells[4].Style.BackColor = Color.Red;
                    dgvUser.Rows[i].Cells[4].Style.SelectionBackColor = Color.Red;
                    dgvUser.Rows[i].Cells[4].Style.ForeColor = Color.White;
                    dgvUser.Rows[i].Cells[4].Style.SelectionForeColor = Color.White;
                }

                DataRow[] PermissionRows = dsUser.Tables[2].Select(" userId=" + DT.Rows[i][0].ToString() + "AND (InsertP=0 OR UpdateP=0 OR DeleteP=0 OR PrintP=0)");
                if (PermissionRows.Length == 0)
                {
                    dgvUser.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                }

                // ---------------------نفس الطريقة السابقة-----------------------
                //DataRow[] PermissionRows1 = dsUser.Tables[2].Select(" userId=" + DT.Rows[i][0].ToString() + "AND (InsertP=1 and UpdateP=1 and DeleteP=1 and PrintP=1)");
                //if (PermissionRows1.Length == 8)
                //{
                //    dgvUser.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                //}
                // --------------------------------------------
                if (!(DT.Rows[i][6] is DBNull == true))
                {
                    dgvUser.Rows[i].Cells[5].Value = FunctionsClass.byteToImage((byte[])DT.Rows[i][6]);
                }

            }
            dgvUser.ClearSelection();
        }

        private void picUser_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                openFileDialog1.Filter = "(Image Files)|*.jpg;*.png;*.bmp;*.gif;*.ico|Jpg, | *.jpg|Png, | *.png|Bmp, | *.bmp|Gif, | *.gif|Ico | *.ico";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    picUser.Image = Image.FromFile(openFileDialog1.FileName);
                    picUser.BackgroundImage = null;
                }
            }
        }

        private void cmsDeletePicture_Click(object sender, EventArgs e)
        {
            picUser.Image = null;
            picUser.BackgroundImage = Properties.Resources.user;
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            txtUserPassword.Text = "0000";

        }
        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectAll.Checked == true)
            {
                foreach (CheckBox C in grpPermissions.Controls)
                {
                    if (C.Name != "chkSelectAll")
                    {
                        C.Checked = true;
                        C.Enabled = false;
                    }
                }
            }
            else
            {
                foreach (CheckBox C in grpPermissions.Controls)
                {
                    if (C.Name != "chkSelectAll")
                    {
                        C.Checked = false;
                        C.Enabled = true;
                    }
                }
            }
            CheckSingleOperation(); // حتى يمنع اختيار عملية بشكل منفصل Enabled=False
        }

        private void CheckSingleOperation()
        {
            if (cmbOperation.SelectedValue == null)
            {
                return;
            }
            if ((int)cmbOperation.SelectedValue == 4 | (int)cmbOperation.SelectedValue == 5 | (int)cmbOperation.SelectedValue == 6 | (int)cmbOperation.SelectedValue == 7 | (int)cmbOperation.SelectedValue == 8)
            {
                foreach (CheckBox C in grpPermissions.Controls)
                {
                    if (C.Name == "chkSelectAll")
                    {
                        C.Text = "منح الصلاحية";
                    }
                    else
                    {
                        C.Enabled = false;
                    }
                }
            }
            else if ((int)cmbOperation.SelectedValue == 3)
            {
                chkPrint.Enabled = false;
            }
        }
        private void chkAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAdmin.Checked == true)
            {
                cmbOperation.Enabled = false;
                chkSelectAll.Checked = true;
            }
            else
            {
                cmbOperation.Enabled = true;
                chkSelectAll.Checked = false;
            }
            cmbOperation.SelectedIndex = -1;
        }

        private void chkShowDelUser_CheckedChanged(object sender, EventArgs e)
        {
            getData();
            distributeData();
            if (chkShowDelUser.Checked == true)
            {
                fillUserDGV(dtDelUser);
                btnDelete.Text = "استرجاع";
                btnDelete.ImageIndex = 5;
                btnDelete.BackColor = Color.FromArgb(128, 255, 128);
                lblMessage.BackColor = Color.FromArgb(255, 128, 128);
                lblMessage.ImageIndex = 8;
                lblMessage.Text = "قائمة المستخدمين الغير مفعلين في المنظومة";
            }
            else
            {
                fillUserDGV(dtUser);
                btnDelete.Text = "حذف";
                btnDelete.ImageIndex = 1;
                btnDelete.BackColor = DefaultBackColor;
                lblMessage.BackColor = Color.FromArgb(128, 128, 255);
                lblMessage.ImageIndex = 7;
                lblMessage.Text = "قائمة المستخدمين المسجلين في المنظومة";
            }
        }



        private void dgvUser_Click(object sender, EventArgs e)
        {
            if  (FunctionsClass.checkDGVError(dgvUser)==true )
                  { return; }


            if ((int)dgvUser.Rows[dgvUser.CurrentRow.Index].Cells[3].Value == 1 & VariablesClass.userId != 1)
            {
                return;
            }

            cr = dgvUser.CurrentRow.Index; // int cr  
            btnNew_Click(sender, e);

            currentUserID = Convert.ToInt32(dgvUser.Rows[cr].Cells[3].Value);  // int currentUserID ;

            displayData();
        }
        private void displayData()
        {
            DataRow[] foundRows = dsUser.Tables[0].Select("Id=" + currentUserID);
            if (foundRows.Length > 0)
            {
                txtUserName.Text = foundRows[0][1].ToString();
                txtUserPassword.Text = foundRows[0][2].ToString();
                txtUserJob.Text = foundRows[0][3].ToString();
                txtUserEmail.Text = foundRows[0][4].ToString();
                if (foundRows[0][5].ToString().Length == 9)
                {
                    txtUserPhone.Text = "0" + foundRows[0][5].ToString();
                }
                else if (foundRows[0][5].ToString().Length == 12)
                {
                    txtUserPhone.Text = "00" + foundRows[0][5];
                }

                if (foundRows[0][6] is DBNull)
                {
                    picUser.Image = null;
                    picUser.BackgroundImage = Properties.Resources.user;
                }
                else
                {
                    picUser.Image = FunctionsClass.byteToImage((byte[])foundRows[0][6]);
                    picUser.BackgroundImage = null;
                }
                dgvUser.Rows[cr].Selected = true; // لأن btnNew_Click تحتوي أمر   ClearSelection 


                if ((bool)foundRows[0][8] == false)
                {
                    btnLockedOut.Text = "إيقاف";
                    btnLockedOut.ImageIndex = 10;
                }
                else
                {
                    btnLockedOut.Text = "تفعيل";
                    btnLockedOut.ImageIndex = 11;
                }
            }

            // إذا كان المستخدم يملك كل الصلاحيات يتم تفعيل (CheckAdmin)
            DataRow[] PermissionRows = dsUser.Tables[2].Select(" userId=" + currentUserID + "AND (InsertP=0 OR UpdateP=0 OR DeleteP=0 OR PrintP=0)");
            if (PermissionRows.Length == 0)
            {
                chkAdmin.Checked = true;
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            FunctionsClass.clear(grpUserInfo);
            if (chkAdmin.Checked == true)
            {
                chkAdmin.Checked = false;
            }
            else
            {
                chkAdmin_CheckedChanged(sender, e);
            }

            chkSelectAll.Text = "تحديد الكل";

            currentUserID = 0;
            dgvUser.ClearSelection();

            getData();
            distributeData();

            if (chkShowDelUser.Checked == true)
            {
                fillUserDGV(dtDelUser);
            }
            else
            {
                fillUserDGV(dtUser);
            }
        }
        private void chkInsert_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInsert.Checked & chkUpdate.Checked & chkDelete.Checked & chkPrint.Checked)
            {
                chkSelectAll.Checked = true;
            }
        }
        private void cmbOperation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //MessageBox.Show("SelectionChangeCommitted" + Environment.NewLine + cmbOperation.SelectedValue.ToString());

            foreach (CheckBox C in grpPermissions.Controls)
            {
                C.Checked = false;
                C.Enabled = true;
            }
            chkSelectAll.Text = "تحديد الكل";


            if (currentUserID == 0)
            {
                MessageBox.Show("الرجاء تحديد مستخدم من القائمة", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbOperation.SelectedIndex = -1;
                return;
            }
            DataRow[] PermissionRows = dsUser.Tables[2].Select("OperationID=" + cmbOperation.SelectedValue + " AND userId=" + currentUserID);

            CheckSingleOperation();

            chkInsert.Checked = (bool)PermissionRows[0][3];
            chkUpdate.Checked = (bool)PermissionRows[0][4];
            chkDelete.Checked = (bool)PermissionRows[0][5];
            chkPrint.Checked = (bool)PermissionRows[0][6];
        }
        // -------------------------------------------------------------
        private void btnSavePermission_Click(object sender, EventArgs e)
        {
            int selectedOperation = Convert.ToInt32(cmbOperation.SelectedValue);
            try
            {
                if (chkAdmin.Checked == true)
                {
                    ConClass.sqlQuery = " UPDATE TblPermissions SET InsertP=1,UpdateP=1,DeleteP=1,PrintP=1 WHERE USERID=" + currentUserID;

                    ConClass.cmd = new SqlCommand(ConClass.sqlQuery, ConClass.con);
                    ConClass.con.Open();
                    if (ConClass.cmd.ExecuteNonQuery() != 0)
                    {
                        getData();
                        distributeData();
                        currentMessage = "تم الحفظ بنجاج";
                        timer1.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("خطأ حفظ بيانات", "خطأ إتصال بقواعد البيانات", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    ConClass.con.Close();
                }

                else
                {
                    if (cmbOperation.SelectedIndex == -1)
                    {
                        MessageBox.Show("الرجاء تحديد العملية من القائمة", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    ConClass.sqlQuery = "UPDATE TblPermissions Set InsertP='" + chkInsert.Checked + "',UpdateP='" + chkUpdate.Checked + "',DeleteP='" + chkDelete.Checked + "',PrintP='" + chkPrint.Checked + "' WHERE userId=" + currentUserID + " AND OperationID=" + cmbOperation.SelectedValue;
                    ConClass.cmd = new SqlCommand(ConClass.sqlQuery, ConClass.con);
                    ConClass.con.Open();
                    if (ConClass.cmd.ExecuteNonQuery() != 0)
                    {
                        getData();
                        distributeData();
                        currentMessage = "تم الحفظ بنجاج";
                        timer1.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("خطأ حفظ بيانات", "خطأ إتصال بقواعد البيانات", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    ConClass.con.Close();
                }
            }
            catch (Exception ex)
            {
                ConClass.con.Close();
                MessageBox.Show("فشل في الإتصال بقاعدة البيانات" + ex.Message, "خطأ إتصال", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cmbOperation.SelectedValue = selectedOperation;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int tagVal = 0;
            if (timer1.Tag == null)
            {
                tagVal = 0;
            }
            else
            {
                tagVal = Convert.ToInt32((timer1.Tag.ToString()));
            }

            tagVal = tagVal + 1;

            timer1.Tag = tagVal;
            if (tagVal <= 20)
            {
                lblMessage.BackColor = Color.FromArgb(128, 255, 128);
                lblMessage.ImageIndex = 6;
                lblMessage.Text = currentMessage;
            }
            else
            {
                timer1.Tag = 0;
                timer1.Enabled = false;
                lblMessage.BackColor = Color.FromArgb(128, 128, 255);
                lblMessage.ImageIndex = 7;
                lblMessage.Text = "قائمة المستخدمين المسجلين في المنظومة";
            }
        }



        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (currentUserID != 0)
            {
                return;
            }


            if (txtUserName.Text == "" | txtUserJob.Text == "" | txtUserEmail.Text == "" | txtUserPhone.Text == "")
            {
                MessageBox.Show("الرجاء ملئ جميع الحقول", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // الجزء الأول شحن الأوامر--------------------------------
                ConClass.cmd = new SqlCommand("InsertUser", ConClass.con);
                ConClass.cmd.CommandType = CommandType.StoredProcedure;

                // إضافة الباراميترات------------------------------------
                var param = new SqlParameter[5];
                param[0] = new SqlParameter("@userName", txtUserName.Text);
                param[1] = new SqlParameter("@userJob", txtUserJob.Text);
                param[2] = new SqlParameter("@UserEmail", txtUserEmail.Text);
                param[3] = new SqlParameter("@UserPhone", txtUserPhone.Text);
                if (picUser.Image == null)
                {
                    param[4] = new SqlParameter("@UserPic", SqlDbType.Image);
                    param[4].Value = DBNull.Value;
                }
                else
                {
                    param[4] = new SqlParameter("@UserPic", FunctionsClass.imageToByte(picUser));
                }
                ConClass.cmd.Parameters.AddRange(param);
                ConClass.cmd.Parameters.Add("@MaxUserID", SqlDbType.Int)
               .Direction = ParameterDirection.Output;

                ConClass.cmd.Parameters.Add("@saveState", SqlDbType.Int)
                    .Direction = ParameterDirection.Output;


                ConClass.da = new SqlDataAdapter(ConClass.cmd);
      

       
                dsUser.Clear();
                // الجزء الثابت للتنفيذ----------------------------------
                ConClass.con.Open();
                ConClass.cmd.ExecuteNonQuery();
                ConClass.con.Close();
                // --------------------------------------------------------
                distributeData();
                fillUserDGV(dtUser);
                int id = Convert.ToInt32(ConClass.cmd.Parameters["@MaxUserID"].Value.ToString());
                int saveState = Convert.ToInt32(ConClass.cmd.Parameters["@saveState"].Value.ToString());

                if (saveState == 1)
                {
                    currentMessage = " تم اضافة المستخدم:   " + txtUserName.Text + "    بنجاح   " + "وتسجيله بالرقم:   " + id;
                    timer1.Enabled = true;
                    FunctionsClass.clear(grpUserInfo);
                    chkShowDelUser.Checked = false;
                }
                else if (saveState == 2)
                {
                    MessageBox.Show("لم يتم الحفظ اسم المستخدم محفوظ مسبقاً ", "خطأ في الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (saveState == 0)
                {
                    MessageBox.Show("لم يتم حفظ بيانات المستخدم ", "خطأ في الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            catch (Exception ex)
            {
                ConClass.con.Close();
                MessageBox.Show("فشل في الإتصال بقاعدة البيانات" + ex.Message, "خطأ إتصال", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentUserID == 0 | currentUserID == 1 | currentUserID == VariablesClass.userId)
            {
                return;
            }
            if (btnDelete.Text == "حذف")
            {
                if (DialogResult.Yes == MessageBox.Show(" هل تريد بالتأكيد حذف " + txtUserName.Text, "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    try
                    {
                        ConClass.cmd = new SqlCommand("DeleteUser", ConClass.con);
                        ConClass.cmd.CommandType = CommandType.StoredProcedure;
                        var param = new SqlParameter();
                        param = new SqlParameter("@Id", currentUserID);
                        ConClass.cmd.Parameters.Add(param);

                        ConClass.cmd.Parameters.Add("@saveState", SqlDbType.Int)
                          .Direction = ParameterDirection.Output;
          

                        ConClass.con.Open();
                        ConClass.cmd.ExecuteNonQuery();
                        ConClass.con.Close();
                        int saveState = Convert.ToInt32(ConClass.cmd.Parameters["@saveState"].Value.ToString());
                        if (saveState == 3)
                        {
                            MessageBox.Show("تم إخفاء البيانات فقط ولم يتم الحذف نهائياً لأن هذا المستخدم حرر فواتير مبيعات ", "تأكيد حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnNew.PerformClick();
                        }
                        else if (saveState == 1)
                        {
                            MessageBox.Show("تم الحذف بنجاح", "تأكيد حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnNew.PerformClick();
                        }

                        else if (saveState == 0)
                        {
                            MessageBox.Show("لم يتم الحذف", "فشل حذف", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    catch (Exception ex)
                    {
                        ConClass.con.Close();
                        MessageBox.Show("فشل في الإتصال بقاعدة البيانات" + ex.Message, "خطأ إتصال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else if (btnDelete.Text == "استرجاع")
            {
                try
                {
                    ConClass.sqlQuery = "UPDATE TblUsers SET Del='FALSE' WHERE Id=" + currentUserID;
                    ConClass.cmd = new SqlCommand(ConClass.sqlQuery, ConClass.con);
                    ConClass.con.Open();
                    if (ConClass.cmd.ExecuteNonQuery() != 0)
                    {
                        currentMessage = "تم تفعيل المستخدم بنجاج";
                        timer1.Enabled = true;
                        btnNew.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("خطأ حفظ بيانات", "فشل حفظ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    ConClass.con.Close();
                }
                catch (Exception ex)
                {
                    ConClass.con.Close();
                    MessageBox.Show("فشل في الإتصال بقاعدة البيانات" + ex.Message, "خطأ إتصال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            {
                if (currentUserID == 0 | currentUserID == 1 & VariablesClass.userId != 1 | chkShowDelUser.Checked == true)
                {
                    return;
                }

                try
                {
                    // الجزء الأول شحن الأوامر---------------------------------
                    ConClass.cmd = new SqlCommand("UpdateUser", ConClass.con);
                    ConClass.cmd.CommandType = CommandType.StoredProcedure;

                    // إضافة الباراميترات------------------------------------
                    var param = new SqlParameter[7];
                    param[0] = new SqlParameter("@userId", currentUserID);
                    param[1] = new SqlParameter("@userName", txtUserName.Text);
                    param[2] = new SqlParameter("@UserPassword", txtUserPassword.Text);
                    param[3] = new SqlParameter("@userJob", txtUserJob.Text);
                    param[4] = new SqlParameter("@UserEmail", txtUserEmail.Text);
                    param[5] = new SqlParameter("@UserPhone", txtUserPhone.Text);
                    if (picUser.Image == null)
                    {
                        param[6] = new SqlParameter("@UserPic", SqlDbType.Image);
                        param[6].Value = DBNull.Value;
                    }
                    else
                    {
                        param[6] = new SqlParameter("@UserPic", FunctionsClass.imageToByte(picUser));
                    }
                    ConClass.cmd.Parameters.AddRange(param);


                    ConClass.cmd.Parameters.Add("@saveState", SqlDbType.Int)
                        .Direction = ParameterDirection.Output;

                    ConClass.da = new SqlDataAdapter(ConClass.cmd);
                    dsUser.Clear();
                    ConClass.con.Open();
                    ConClass.da.Fill(dsUser);
                    ConClass.con.Close();
                    distributeData();
                    fillUserDGV(dtUser);
                    setImg();
                    int saveState = Convert.ToInt32(ConClass.cmd.Parameters["@saveState"].Value.ToString());

                    if (saveState == 1)
                    {
                        currentMessage = " تم تعديل بيانات المستخدم:   " + txtUserName.Text + "    بنجــــاح   ";
                        timer1.Enabled = true;
                    }

                    else if (saveState == 2)
                    {
                        MessageBox.Show("لم يتم الحفظ اسم المستخدم مسجل مسبقاً ", "خطأ في الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else if (saveState == 0)
                    {
                        MessageBox.Show("لم يتم حفظ بيانات المستخدم ", "خطأ في الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                catch (Exception ex)
                {
                    ConClass.con.Close();
                    MessageBox.Show("فشل في الإتصال بقاعدة البيانات" + ex.Message, "خطأ إتصال", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }

        private void btnLockedOut_Click(object sender, EventArgs e)
        {
            if (currentUserID == 0 | currentUserID == 1 | currentUserID == VariablesClass.userId)
            {
                return;
            }
            try
            {
                if (btnLockedOut.Text == "إيقاف")
                {
                    ConClass.sqlQuery = "UPDATE TblUsers SET LockedOut='TRUE' WHERE Id=" + currentUserID;
                    ConClass.cmd = new SqlCommand(ConClass.sqlQuery, ConClass.con);
                    ConClass.con.Open();
                    if (ConClass.cmd.ExecuteNonQuery() != 0)
                    {
                        currentMessage = "تم إيقاف المستخدم ";
                        timer1.Enabled = true;
                        btnNew.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("خطأ حفظ بيانات", "فشل حفظ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    ConClass.con.Close();
                }
                else
                {
                    ConClass.sqlQuery = "UPDATE TblUsers SET LockedOut='FALSE' WHERE Id=" + currentUserID;
                    ConClass.cmd = new SqlCommand(ConClass.sqlQuery, ConClass.con);
                    ConClass.con.Open();
                    if (ConClass.cmd.ExecuteNonQuery() != 0)
                    {
                        currentMessage = "تم تفعيل المستخدم ";
                        timer1.Enabled = true;
                        btnNew.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("خطأ حفظ بيانات", "فشل حفظ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    ConClass.con.Close();
                }
            }
            catch (Exception ex)
            {
                ConClass.con.Close();
                MessageBox.Show("فشل في الإتصال بقاعدة البيانات" + ex.Message, "خطأ إتصال", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
