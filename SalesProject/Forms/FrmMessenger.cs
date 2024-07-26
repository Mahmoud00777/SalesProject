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
    public partial class FrmMessenger : Form
    {
        public FrmMessenger()
        {
            InitializeComponent();
        }

        DataSet dsMessenger = new DataSet();
        DataTable dtMessages = new DataTable();

        int crClick = -1;
        int crTimer = -1;
        int lastRowId, recevierId, usersCount;
        bool swTimerClick, showAllChat;
        private void FrmMessenger_FormClosing(object sender, FormClosingEventArgs e)
        {
            VariablesClass.mainActive = true;
        }
        private void FrmMessenger_Load(object sender, EventArgs e)
        {
            FunctionsClass.userTrafficRegister(this.Name, true);
            getData();

            usersCount = dsMessenger.Tables[0].Rows.Count;
        }
        private void getData()
        {
            try
            {
                dsMessenger.Clear();
                SQLConClass.sqlQuery = "SELECT TblUserTraffices.*,userName,UserPic FROM TblUserTraffices,TblUsers where TblUsers.Id=TblUserTraffices.userId AND TblUsers.Del=0 AND TblUsers.Id<> " + VariablesClass.userId + " AND DATEDIFF(DD,DateEntry,GETDATE())<=90 AND TblUserTraffices.Id IN(SELECT MAX(Id) FROM TblUserTraffices GROUP BY userId) ORDER BY userId ";
                SQLConClass.sqlQuery += " SELECT SenderId,COUNT(Id) AS MsgCo FROM TblMessages WHERE ReadDate IS NULL AND ReceiverId=" + VariablesClass.userId + " GROUP BY SenderId";
                ConClass.da = new SqlDataAdapter(SQLConClass.sqlQuery, ConClass.con);
                ConClass.da.Fill(dsMessenger);
                fillDGVUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("فشل في الإتصال بقاعدة البيانات" + ex.Message, "خطأ إتصال", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void fillDGVUsers()
        {
            dgvUsers.Rows.Clear();
            for (int i = 0; i <= dsMessenger.Tables[0].Rows.Count - 1; i++)
            {
                dgvUsers.Rows.Add();
                dgvUsers.Rows[i].Cells[0].Value = dsMessenger.Tables[0].Rows[i][1]; // UserId
                if ((bool)dsMessenger.Tables[0].Rows[i][5] == true) // Connected
                {
                    dgvUsers.Rows[i].Cells[1].Style.BackColor = Color.Lime;
                    dgvUsers.Rows[i].Cells[1].Style.SelectionBackColor = Color.Lime;
                    dgvUsers.Rows[i].Cells[4].Value = dsMessenger.Tables[0].Rows[i][3]; // توقيت الدخول
                }
                else
                {
                    dgvUsers.Rows[i].Cells[1].Style.BackColor = Color.FromArgb(160, 160, 160);
                    dgvUsers.Rows[i].Cells[1].Style.SelectionBackColor = Color.FromArgb(160, 160, 160);
                    dgvUsers.Rows[i].Cells[5].Value = dsMessenger.Tables[0].Rows[i][4];// توقيت الخروج
                }
                if (!(dsMessenger.Tables[0].Rows[i][8] is DBNull)) // UserPic
                {
                    dgvUsers.Rows[i].Cells[2].Value = FunctionsClass.byteToImage((byte[])dsMessenger.Tables[0].Rows[i][8]);
                }
                else
                {
                    dgvUsers.Rows[i].Cells[2].Value = Resources.user;
                }

                dgvUsers.Rows[i].Cells[3].Value = dsMessenger.Tables[0].Rows[i][7]; // UserName

                //--------------Array Of DataRows--------------------------------------
                //DataRow[] dr1 = dsMessenger.Tables[1].Select(" SenderId=" + dgvUsers.Rows[i].Cells[0].Value);
                //if (dr1.Length > 0)
                //    dgvUsers.Rows[i].Cells[6].Value = dr1[0]["MsgCo"];
                //------------DataRow----------------------------------------------
                //DataRow dr = dsMessenger.Tables[1].Select(" SenderId=" + dgvUsers.Rows[i].Cells[0].Value).FirstOrDefault();
                //if (!(dr == null))
                //{
                //    dgvUsers.Rows[i].Cells[6].Value = dr["MsgCo"];
                //}
                //-----------------------------------------------------------------
                //foreach (DataRow r in dsMessenger.Tables[1].Rows)
                //{
                //    if (r["SenderId"] == dgvUsers.Rows[i].Cells[0].Value)
                //    {
                //        dgvUsers.Rows[i].Cells[6].Value = r["MsgCo"];
                //    }
                //}
                //-----------------------------------------------------------------


                dgvUsers.Rows[i].Cells[6].Value = dsMessenger.Tables[1].Compute("sum(MsgCo)", "SenderId=" + dgvUsers.Rows[i].Cells[0].Value); // اي دالة رياضية لا يهم لانه صف واحد max , min , avg , sum

            }

            //lbLTotalMsgCount.Text = 0.ToString();
            //foreach (DataRow r in dsMessenger.Tables[1].Rows)
            //    lbLTotalMsgCount.Text = lbLTotalMsgCount.Text + r["MsgCo"];


            lbLTotalMsgCount.Text = dsMessenger.Tables[1].Compute("Sum(MsgCo)", "MsgCo>0").ToString();  // أي فلتر او شرط فقط ليشمل جميع الحقول

            //lbLTotalMsgCount.Text = Convert.ToString(dsMessenger.Tables[1].Compute("Sum(MsgCo)", "SenderId IN(46,48)"));

            dgvUsers.ClearSelection();
        }
        private void picSend_Click(object sender, EventArgs e)
        {
            if (recevierId == 0)
            {
                lblUserName.Text = "يرجى تحديد مستخدم من القائمة";
                return;
            }

            if (txtMessage.Text.Trim() == string.Empty)
                return;

            string rejectedText = "تمت رؤيته";
            if (txtMessage.Text.Contains(rejectedText))
            {
                MessageBox.Show("عذرا لا يمكن ارسال النص: (" + rejectedText + ") ضمن المحادثة");
                txtMessage.Focus();
                txtMessage.Select(txtMessage.Text.IndexOf(rejectedText), rejectedText.Length);
                return;
            }

            try
            {
                ConClass.cmd = new SqlCommand("InsertMessage", ConClass.con);
                ConClass.cmd.CommandType = CommandType.StoredProcedure;
                var param = new SqlParameter[3];
                param[0] = new SqlParameter("@userId", VariablesClass.userId);
                param[1] = new SqlParameter("@ReceiverId", recevierId);
                param[2] = new SqlParameter("@txtMessage", txtMessage.Text.Trim());
                ConClass.cmd.Parameters.AddRange(param);
                ConClass.con.Open();
                ConClass.cmd.ExecuteNonQuery();
                ConClass.con.Close();
                txtMessage.Text = "";

                showAllChat = false;
                crTimer = crClick;
                swTimerClick = true;
                dgvUsers.Rows[crClick].Selected = true;
                dgvUsers_Click(sender, e);
                dgvUsers.FirstDisplayedScrollingRowIndex = crClick;
            }

            catch (Exception ex)
            {
                ConClass.con.Close();
                MessageBox.Show("فشل في الإتصال بقاعدة البيانات" + ex.Message, "خطأ إتصال", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            crTimer = crClick; //  تخزين رقم الصف الحالي الخاص بالمستخدم الذي عملنا له كلك بالماوس 
            getData();

            if (usersCount != dsMessenger.Tables[0].Rows.Count) // في حال اضافة أو حذف مستخدم  في لنظام
            {
                picRefresh_Click(sender, e);
                usersCount = dsMessenger.Tables[0].Rows.Count;
                return;
            }

            if (crTimer != -1) // في حال المحادثة مفتوحة مع أي مستخدم
            {
                swTimerClick = true;// Id متغير يبين ان الكلك سيتم عن طريق التايمر لتحديث المحادثة وجلب الرسائل الجديدة بعد اخر رسالة تم تخزين 
                dgvUsers.Rows[crTimer].Selected = true;
                dgvUsers_Click(sender, e);
                dgvUsers.FirstDisplayedScrollingRowIndex = crTimer;
            }
        }
        private void dgvUsers_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsers.CurrentRow == null) return;
                if (dgvUsers.CurrentRow.Index == dgvUsers.Rows.Count
                    | dgvUsers.Rows[dgvUsers.CurrentRow.Index].Cells[0].Value == null)
                    //| dgvUsers.Rows[dgvUsers.CurrentRow.Index].Selected == false) هذا الشرط يتعارض مع عمل كل التايمر
                    return;
            }
            catch
            {
                return;
            }

            if (crClick != dgvUsers.CurrentRow.Index & swTimerClick == false)  // عند عمل كلك على مستخدم مختلف يدويا بالماوس 
            {
                txtChat.Text = ""; // عند تحديد مستخدم جديد غير السابق يتم مسح المحادثة السابقة وتسفير رقم اخر صف
                lastRowId = 0;
            }

            if (swTimerClick == false) //في حال الكلك كان يدوي بالماوس
            {
                crClick = dgvUsers.CurrentRow.Index;
                lblUserName.Text = dgvUsers.Rows[crClick].Cells[3].Value.ToString();
                picUser.Image = (Image)dgvUsers.Rows[crClick].Cells[2].Value;

                showAllChat = false; //دائما false  // متغير لعرض المحادثة بالكامل  لن يكون فعال الا عند الضغط على صورة تحميل المحادثة بالكامل
                txtChat.Visible = false;
            }
            else if (swTimerClick == true) // التأكد ان الكلك تم عن طريق التايمر فقط لتخزين الصف الحالي أي آخر مستخدم كان عليه كلك  
            {
                crClick = crTimer;
                swTimerClick = false;
            }

            recevierId = (int)dgvUsers.Rows[crClick].Cells[0].Value;//المستخدم الذي عملنا له كلك حتى يتم جلب محادثتي معه Id تخزين 

            try
            {
                SQLConClass.sqlQuery = "Select * FROM TblMessages WHERE (SenderId=" + VariablesClass.userId + " And ReceiverId=" + recevierId + ") Or (SenderId=" + recevierId + " And ReceiverId=" + VariablesClass.userId + " ) ";

                ConClass.da = new SqlDataAdapter(SQLConClass.sqlQuery, ConClass.con);
                dtMessages.Clear();
                ConClass.da.Fill(dtMessages);
                if (dtMessages.Rows.Count != 0)
                {
                    int startRowNum;
                    if (dtMessages.Rows.Count > 30 & showAllChat == false) // في حال showAllChat=true لن يتم جلب اخر 30 صف وسيتم تحميل المحادثة من الصف صفر من أول صف
                    {
                        startRowNum = dtMessages.Rows.Count - 30;   // 100-30=70
                    }
                    else
                    {
                        startRowNum = 0;
                    }

                    if (txtChat.Text == "")
                    {
                        txtChat.Text = Environment.NewLine;
                    }

                    for (int i = startRowNum; i <= dtMessages.Rows.Count - 1; i++)   // for ( i = 70 ; i <= 100 -1 ; i++ )تحميل آخر 30 رسالة في المحادثة
                    {
                        if ((int)dtMessages.Rows[i][0] > lastRowId) // في البداية lastRowId=0
                        {
                            if ((int)dtMessages.Rows[i][1] == VariablesClass.userId) // تحديد هل الرسالة في هذا الصف مرسلة او مستقبلة
                            {
                                txtChat.Text += VariablesClass.userName + Environment.NewLine 
                                    + dtMessages.Rows[i][4].ToString()  + Environment.NewLine;
                                if (!(dtMessages.Rows[i][5] is DBNull)) // كل صف يتم اضافته من قبلي انا المرسل يتم تحديده هل هو مقروء او لا من قبل الطرف الثاني
                                {
                                    txtChat.Text += "تمت رؤيته " + dtMessages.Rows[i][5].ToString() + " " + Environment.NewLine;
                                }
                            }
                            else
                            {
                                txtChat.Text += dgvUsers.Rows[crClick].Cells[3].Value.ToString()
                                                + Environment.NewLine + dtMessages.Rows[i][4].ToString() + Environment.NewLine;
                            }

                            if (!(dgvUsers.Rows[crClick].Cells[6].Value is DBNull))// حتى لا ينفذها الا مرة واحدة DBNull // تحديث جميع الرسائل المقروءة مرة واحدة
                            {
                                SQLConClass.sqlQuery = "UPDATE TblMessages Set ReadDate='" + DateTime.Now.ToString() + "' WHERE ReadDate IS NULL AND ReceiverId=" + VariablesClass.userId + " AND SenderId=" + recevierId;
                                ConClass.cmd = new SqlCommand(SQLConClass.sqlQuery, ConClass.con);
                                ConClass.con.Open();
                                ConClass.cmd.ExecuteNonQuery();
                                ConClass.con.Close();
                                if (!(dgvUsers.Rows[crClick].Cells[6].Value == null))
                                {
                                    lbLTotalMsgCount.Text = (Convert.ToInt32(lbLTotalMsgCount.Text) - Convert.ToInt32(dgvUsers.Rows[crClick].Cells[6].Value)).ToString(); // يقوم بطرح اجمالي الرسائل المقروءة من الإشعار الذي يوجد فيه اجمالي عدد الرسائل
                                }

                                dgvUsers.Rows[crClick].Cells[6].Value = null;  // مسح عداد الرسائل غير المقروءة
                            }

                            txtChat.Text += Environment.NewLine;
                            txtChat.Select(txtChat.TextLength, 0);
                            txtChat.ScrollToCaret();
                            setFontColor();
                        }
                    } // الى هنا لا يزال مربع نص المحادثة مخفي لا يتم اظهاره الا بعد تحميل المحادثة 30 صف 
                    txtChat.Visible = true; // اظهار المحادثة بعد تحميل جميع الصفوف الثلاثين الأخيرات
                    lastRowId = (int)dtMessages.Rows[dtMessages.Rows.Count - 1][0]; //آخر سطر تم تحميله في المحادثة حتى لا نعيد تحميلها من جديد عند استقبال رسالة جديدة حالياً Id تخزين
                }

                txtMessage.Focus();
            }
            catch (Exception ex)
            {
                ConClass.con.Close();
                MessageBox.Show("فشل في الإتصال بقاعدة البيانات" + ex.Message, "خطأ إتصال", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void setFontColor()
        {
            txtChat.SelectAll();
            txtChat.SelectionFont = new Font("Times New Roman", 11, FontStyle.Regular);
            txtChat.SelectionColor = Color.Black;
            // txtChat.SelectionAlignment = HorizontalAlignment.Right;
            int Position = 0;
            Position = txtChat.Find(VariablesClass.userName, Position, RichTextBoxFinds.MatchCase);
            while (Position >= 0)
            {
                txtChat.SelectionFont = new Font("Times New Roman", 12, FontStyle.Bold);
                txtChat.SelectionColor = Color.Blue;
                //txtChat.SelectionAlignment = HorizontalAlignment.Right;
                Position = txtChat.Find(VariablesClass.userName, Position + 1, RichTextBoxFinds.MatchCase);
            }

            Position = 0;
            Position = txtChat.Find(dgvUsers.Rows[crClick].Cells[3].Value.ToString(), Position, RichTextBoxFinds.MatchCase);
            while (Position >= 0)
            {
                txtChat.SelectionFont = new Font("Times New Roman", 12, FontStyle.Bold);
                txtChat.SelectionColor = Color.Green;
                //txtChat.SelectionAlignment = HorizontalAlignment.Right;
                Position = txtChat.Find(dgvUsers.Rows[crClick].Cells[3].Value.ToString(), Position + 1, RichTextBoxFinds.MatchCase); ;
            }

            Position = 0;
            Position = txtChat.Find("تمت رؤيته", Position, RichTextBoxFinds.MatchCase);
            while (Position >= 0)
            {
                txtChat.Select(Position, 32);
                txtChat.SelectionFont = new Font("Times New Roman", 7, FontStyle.Regular);
                txtChat.SelectionColor = Color.Gray;
                txtChat.SelectionAlignment = HorizontalAlignment.Left;
                Position = txtChat.Find("تمت رؤيته", Position + 1, RichTextBoxFinds.MatchCase);
            }
        }
        private void picRefresh_Click(object sender, EventArgs e)
        {
            getData();

            txtChat.Text = "";
            txtMessage.Text = "";
            lblUserName.Text = "";
            picUser.Image = null;
            recevierId = 0;
            
            crClick = -1;
            crTimer = -1;
            lastRowId = 0;
            swTimerClick = false;
            showAllChat = false;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtMessage.Multiline = !checkBox1.Checked;

            //if (checkBox1.Checked == true)
            //{
            //    txtMessage.Multiline = false;
            //}
            //else
            //{
            //    txtMessage.Multiline = true;
            //}
        }
        private void lblMsg_Click(object sender, EventArgs e)
        {
            txtMessage.Focus();

        }
        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            if (txtMessage.Text.Trim() == "")
            {
                lblMsg.Visible = true;
                txtMessage.Select(0, 0);
            }
            else
            {
                lblMsg.Visible = false;
            }
        }
        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (e.KeyCode == Keys.Enter)
                    picSend_Click(sender, e);
            }
        }
        private void picSetChat_Click(object sender, EventArgs e)
        {
            if (recevierId == 0)
            {
                lblUserName.Text = "يرجى تحديد مستخدم من القائمة";
                return;
            }


            lblUserName.Text = "جاري تحميل المحادثة ...";
            showAllChat = true; // متغير لعرض المحادثة بالكامل
            lastRowId = 0;
            txtChat.Text = "";
            txtChat.Visible = false;
        }
        private void picDelete_Click(object sender, EventArgs e)
        {
            if (recevierId == 0)
            {
                lblUserName.Text = "يرجى تحديد مستخدم من القائمة";
                return;
            }

            if (MessageBox.Show("هل انت متأكد تريد حذف المحادثة بالكامل", "حذف بيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SQLConClass.sqlQuery = "DELETE FROM TblMessages WHERE (SenderId=" + VariablesClass.userId + " And ReceiverId=" + recevierId + ") Or (SenderId=" + recevierId + " And ReceiverId=" + VariablesClass.userId + " )";
                    ConClass.cmd = new SqlCommand(SQLConClass.sqlQuery, ConClass.con);
                    ConClass.con.Open();
                    ConClass.cmd.ExecuteNonQuery();
                    ConClass.con.Close();
                    picRefresh_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("فشل في الإتصال بقاعدة البيانات" + ex.Message, "خطأ إتصال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void picDelete_MouseEnter(object sender, EventArgs e)
        {
            PicResize(picDelete, true);

        }
        private void picDelete_MouseLeave(object sender, EventArgs e)
        {
            PicResize(picDelete, false);

        }
        private void picNew_MouseEnter(object sender, EventArgs e)
        {
            PicResize(picRefresh, true);

        }
        private void picNew_MouseLeave(object sender, EventArgs e)
        {
            PicResize(picRefresh, false);

        }
        private void picSetChat_MouseEnter(object sender, EventArgs e)
        {
            PicResize(picSetChat, true);

        }
        private void picSetChat_MouseLeave(object sender, EventArgs e)
        {
            PicResize(picSetChat, false);

        }
        private void picSend_MouseEnter(object sender, EventArgs e)
        {
            PicResize(picSend, true);

        }
        private void picSend_MouseLeave(object sender, EventArgs e)
        {
            PicResize(picSend, false);
        }
        void PicResize(PictureBox Pic, bool Move)
        {
            if (Move == true)
            {
                Pic.SetBounds(Pic.Left - 5, Pic.Top - 5, Pic.Width + 10, Pic.Height + 10);
            }
            else
            {
                Pic.SetBounds(Pic.Left + 5, Pic.Top + 5, Pic.Width - 10, Pic.Height - 10);
            }

        }
        private void lbLTotalMsgCount_TextChanged(object sender, EventArgs e)
        {
            if (lbLTotalMsgCount.Text == string.Empty | lbLTotalMsgCount.Text == "0")
            {
                lbLTotalMsgCount.Visible = false;
            }
            else
            {
                lbLTotalMsgCount.Visible = true;
            }
            FrmMain frmMain = Application.OpenForms.OfType<FrmMain>().FirstOrDefault();
            frmMain.lbLTotalMsgCount.Text = lbLTotalMsgCount.Text;
        }
    }
}
