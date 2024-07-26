using SalesProject.Classes;
using SalesProject.Properties;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SalesProject.Forms
{
    public partial class FrmUsers : Form
    {
        public FrmUsers()
        {
            InitializeComponent();
        }

        public string currentMessage;
        int currentUserID, cr;
        DataSet dsUsers = new DataSet();
        DataTable dtUsers = new DataTable(), dtDelUsers = new DataTable();
        
        ResizeControls r = new ResizeControls();

        private void FrmUsers_Resize(object sender, EventArgs e)
        {
            r.ResizeControl();
        }
        private void FrmUsers_HandleCreated(object sender, EventArgs e)
        {
            r.Container = this;
        }
        private void FrmUsers_FormClosing(object sender, FormClosingEventArgs e)
        {
           FunctionsClass.userTrafficRegister(this.Name, false);
            VariablesClass.mainActive = true;
        }
        //--------------------------------------------------------------------------
        private void FrmUsers_Load(object sender, EventArgs e)
        {
           FunctionsClass.userTrafficRegister(this.Name, true);

            label1.Parent = picUser;
            label1.Top = 140;
            label1.Left = 30;

            getData();
            distributeData();
            fillDgvUsers(dtUsers);
            cmbOperation.DataSource = dsUsers.Tables[1];
            cmbOperation.DisplayMember = "OperationName";
            cmbOperation.ValueMember = "Id";
            cmbOperation.SelectedIndex = -1;

            setFormSize();
            dgvUsers.ColumnHeadersDefaultCellStyle.Font = new Font("Hacen Saudi Arabia", 10, FontStyle.Regular);

        }
        void setFormSize()
        {
            this.Size = Settings.Default.FrmMainSize - new Size(0, 55);
            this.Location = Settings.Default.FrmMainLocation;
            this.Top += 30;
        }
        void getData()
        {
            try
            {
                dsUsers.Clear();
                //ConClass.SQLConClass.sqlQuery = "SELECT * FROM TblUsers SELECT * FROM TblOperations SELECT * FROM TblPermissions";
                SQLConClass.sqlQuery = "SELECT * FROM TblUsers " +
                                       "SELECT * FROM TblOperations " +
                                       "SELECT * FROM TblPermissions";
                ConClass.da = new SqlDataAdapter(SQLConClass.sqlQuery, ConClass.con);
                ConClass.da.Fill(dsUsers);
            }
            catch (Exception ex)
            {
                MessageBox.Show("فشل في الإتصال بقاعدة البيانات" + ex.Message, "خطأ إتصال", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void distributeData()
        {
            // ----------------LoadEnabledUser-------------------------
            dtUsers = dsUsers.Tables[0].Clone(); // Copy Design of table
                                                 // ----نفس السطر السابق-------
                                                 //dtUsers = dsUsers.Tables[0].Copy();
                                                 //dtUsers.Clear();
                                                 // ---------------------------
            DataRow[] itemRows = dsUsers.Tables[0].Select("Del='FALSE'");
            if (itemRows.Length > 0)
            {
                dtUsers = itemRows.CopyToDataTable();
            }

            //foreach (DataRow DR in dsUsers.Tables[0].Select("Del='FALSE'"))
            //    dtUsers.ImportRow(DR);


            // ----------------LoadDeletedUser-------------------------

            dtDelUsers = dsUsers.Tables[0].Clone();

            itemRows = dsUsers.Tables[0].Select("Del='TRUE'");
            if (itemRows.Length > 0)
            {
                dtDelUsers = itemRows.CopyToDataTable();
            }

            //foreach (var DR in dsUsers.Tables[0].Select("Del='TRUE'"))
            //    dtDelUsers.ImportRow(DR);
            // -----------------------------------------


            setImg();
        }
        void setImg()
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
        private void fillDgvUsers(DataTable dt)
        {
            dgvUsers.Rows.Clear();
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {

                dgvUsers.Rows.Add();
                dgvUsers.Rows[i].Cells[0].Value = dt.Rows[i][0];
                dgvUsers.Rows[i].Cells[1].Value = i + 1;
                dgvUsers.Rows[i].Cells[2].Value = dt.Rows[i][1];
                dgvUsers.Rows[i].Cells[3].Value = dt.Rows[i][3];
                dgvUsers.Rows[i].Cells[4].Value = dt.Rows[i][0];
                
                if ((bool)dt.Rows[i][8] == false)
                {
                    dgvUsers.Rows[i].Cells[5].Value = "فعال";
                }
                else
                {
                    dgvUsers.Rows[i].Cells[5].Value = "موقوف";
                    dgvUsers.Rows[i].Cells[5].Style.BackColor = Color.Red;
                    dgvUsers.Rows[i].Cells[5].Style.SelectionBackColor = Color.Red;
                    dgvUsers.Rows[i].Cells[5].Style.ForeColor = Color.White;
                    dgvUsers.Rows[i].Cells[5].Style.SelectionForeColor = Color.White;
                }

                DataRow[] PermissionRows = dsUsers.Tables[2].Select(" UserId=" + dt.Rows[i][0].ToString() + "AND (InsertP=0 OR UpdateP=0 OR DeleteP=0 OR PrintP=0)");
                if (PermissionRows.Length == 0)
                {
                    dgvUsers.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                }

                // ---------------------نفس الطريقة السابقة-----------------------
                //DataRow[] PermissionRows1 = dsUsers.Tables[2].Select(" userId=" + dt.Rows[i][0].ToString() + "AND (InsertP=1 and UpdateP=1 and DeleteP=1 and PrintP=1)");
                //if (PermissionRows1.Length == 8)
                //{
                //    dgvUsers.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                //}
                // --------------------------------------------
                if (!(dt.Rows[i][6] is DBNull))
                {
                    dgvUsers.Rows[i].Cells[6].Value = FunctionsClass.byteToImage((byte[])dt.Rows[i][6]);
                }

            }
            dgvUsers.ClearSelection();
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
                    C.Checked = false;
                    C.Enabled = true;
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

            if ((int)cmbOperation.SelectedValue == 1 
                | (int)cmbOperation.SelectedValue == 2 
                | (int)cmbOperation.SelectedValue == 3 
                | (int)cmbOperation.SelectedValue == 4 
                | (int)cmbOperation.SelectedValue == 5)
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
            else if ((int)cmbOperation.SelectedValue == 6)
            {
                chkPrint.Enabled = false;
            }
        }
        private void chkAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAdmin.Checked == true)
            {
                cmbOperation.Enabled = false;
                grpPermissions.Enabled = false;
                chkSelectAll.Checked = true;
            }
            else
            {
                cmbOperation.Enabled = true;
                grpPermissions.Enabled = true;
                chkSelectAll.Checked = false;
                chkSelectAll_CheckedChanged(sender, e);
                chkSelectAll.Text = "تحديد الكل";
            }

            cmbOperation.SelectedIndex = -1;
        }

        private void chkShowDelUser_CheckedChanged(object sender, EventArgs e)
        {
            btnNew.PerformClick();
            if (chkShowDelUser.Checked == true)
            {
                btnDelete.Text = "استرجاع";
                btnDelete.ImageIndex = 5;
                btnDelete.BackColor = Color.FromArgb(128, 255, 128);
                lblMessage.BackColor = Color.FromArgb(255, 128, 128);
                lblMessage.ImageIndex = 8;
                lblMessage.Text = "قائمة المستخدمين الغير مفعلين في المنظومة";
            }
            else
            {
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
            if (FunctionsClass.checkDgvError(dgvUsers) == true)
            {
                return;
            }


            if ((int)dgvUsers.Rows[dgvUsers.CurrentRow.Index].Cells[0].Value == 1 & VariablesClass.userId != 1)
            {
                return;
            }

            cr = dgvUsers.CurrentRow.Index; // int cr  
            btnNew_Click(sender, e);

            currentUserID = Convert.ToInt32(dgvUsers.Rows[cr].Cells[0].Value);  // int currentUserID ;

            displayData();
        }
        private void displayData()
        {
            DataRow[] drUser = dsUsers.Tables[0].Select("Id=" + currentUserID);
            if (drUser.Length > 0)
            {
                txtUserName.Text = drUser[0][1].ToString();
                txtUserPassword.Text = drUser[0][2].ToString();
                txtUserJob.Text = drUser[0][3].ToString();
                txtUserEmail.Text = drUser[0][4].ToString();
                txtUserPhone.Text = drUser[0][5].ToString();

                if (drUser[0][6] is DBNull)
                {
                    picUser.Image = null;
                    picUser.BackgroundImage = Properties.Resources.user;
                }
                else
                {
                    picUser.Image = FunctionsClass.byteToImage((byte[])drUser[0][6]);
                    picUser.BackgroundImage = null;
                }
                dgvUsers.Rows[cr].Selected = true;// ClearSelection تحتوي أمر btnNew_Click لأن 


                if ((bool)drUser[0][8] == false)
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
            DataRow[] PermissionRows = dsUsers.Tables[2].Select(" UserId=" + currentUserID + "AND (InsertP=0 or UpdateP=0 or DeleteP=0 or PrintP=0)");
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

            currentUserID = 0;
            dgvUsers.ClearSelection();

            getData();
            distributeData();

            if (chkShowDelUser.Checked == true)
            {
                fillDgvUsers(dtDelUsers);
            }
            else
            {
                fillDgvUsers(dtUsers);
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
            DataRow[] PermissionRows = dsUsers.Tables[2].Select("OperationID=" + cmbOperation.SelectedValue + " AND userId=" + currentUserID);

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
                    SQLConClass.sqlQuery = " UPDATE TblPermissions SET " +
                        "InsertP=1,UpdateP=1,DeleteP=1,PrintP=1 WHERE USERID=" + currentUserID;

                    ConClass.cmd = new SqlCommand(SQLConClass.sqlQuery, ConClass.con);
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
                    SQLConClass.sqlQuery = "UPDATE TblPermissions Set " +
                        "InsertP='" + chkInsert.Checked + "',UpdateP='" + chkUpdate.Checked + "',DeleteP='" + chkDelete.Checked + "',PrintP='" + chkPrint.Checked + "' " +
                        "WHERE UserId=" + currentUserID + " AND OperationID=" + cmbOperation.SelectedValue;
                    ConClass.cmd = new SqlCommand(SQLConClass.sqlQuery, ConClass.con);
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
            int tagVal;

            if (timer1.Tag == null)
            {
                tagVal = 0;
            }
            else
            {
                tagVal = Convert.ToInt32(timer1.Tag.ToString());
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
                ConClass.cmd = new SqlCommand("UserInsert", ConClass.con);
                ConClass.cmd.CommandType = CommandType.StoredProcedure;

                // إضافة الباراميترات------------------------------------
                var param = new SqlParameter[5];
                param[0] = new SqlParameter("@userName", txtUserName.Text);
                param[1] = new SqlParameter("@userJob", txtUserJob.Text);
                param[2] = new SqlParameter("@UserEmail", txtUserEmail.Text);
                param[3] = new SqlParameter("@UserPhone", txtUserPhone.Text);
                if (picUser.Image == null)
                {
                    param[4] = new SqlParameter("@UserPic", SqlDbType.VarBinary);
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

                dsUsers.Clear();

                // الجزء الثابت للتنفيذ----------------------------------
                ConClass.con.Open();
                ConClass.da = new SqlDataAdapter(ConClass.cmd);
                ConClass.da.Fill(dsUsers);
                ConClass.con.Close();
                // --------------------------------------------------------
                distributeData();
                fillDgvUsers(dtUsers);
                int id = (int)ConClass.cmd.Parameters["@MaxUserID"].Value;
                int saveState = (int)ConClass.cmd.Parameters["@saveState"].Value;

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
                        ConClass.cmd = new SqlCommand("UserDelete", ConClass.con);
                        ConClass.cmd.CommandType = CommandType.StoredProcedure;
                        var param = new SqlParameter();
                        param = new SqlParameter("@Id", currentUserID);
                        ConClass.cmd.Parameters.Add(param);

                        ConClass.cmd.Parameters.Add("@saveState", SqlDbType.Int)
                          .Direction = ParameterDirection.Output;


                        ConClass.con.Open();
                        ConClass.cmd.ExecuteNonQuery();
                        ConClass.con.Close();

                        int saveState = Convert.ToInt32(ConClass.cmd.Parameters["@saveState"].Value);
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
                    SQLConClass.sqlQuery = "UPDATE TblUsers SET Del='FALSE' WHERE Id=" + currentUserID;
                    ConClass.cmd = new SqlCommand(SQLConClass.sqlQuery, ConClass.con);
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

        private void cmbOperation_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                    ConClass.cmd = new SqlCommand("UserUpdate", ConClass.con);
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

                    dsUsers.Clear();
                    ConClass.con.Open();
                    ConClass.da = new SqlDataAdapter(ConClass.cmd);
                    ConClass.da.Fill(dsUsers);
                    ConClass.con.Close();
                    distributeData();
                    fillDgvUsers(dtUsers);
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
                    SQLConClass.sqlQuery = "UPDATE TblUsers SET LockedOut='TRUE' WHERE Id=" + currentUserID;
                    ConClass.cmd = new SqlCommand(SQLConClass.sqlQuery, ConClass.con);
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
                else if (btnLockedOut.Text == "تفعيل")
                {
                    SQLConClass.sqlQuery = "UPDATE TblUsers SET LockedOut='FALSE' WHERE Id=" + currentUserID;
                    ConClass.cmd = new SqlCommand(SQLConClass.sqlQuery, ConClass.con);
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
