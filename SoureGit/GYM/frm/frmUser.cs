using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GYM.ServiceReferenceDuyTan;
using GYM.Common;

namespace GYM.frm
{
    public partial class frmUser : DevExpress.XtraEditors.XtraForm
    {
        public string strMode = "";
        public string strCode = "";

        public frmUser()
        {
            InitializeComponent();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            /*
             * Dungnv   : 11/11/2015 
             * Purpose  : Load thong tin
             */
            txtUserId.Properties.ReadOnly = true;

            if (strMode == ClsParameter.MODE_ADD || strMode == ClsParameter.MODE_VIEW)
            {
                checkLock.Enabled = false;
            }
            else
            {
                checkLock.Enabled = true;
            }
            //bindingComboGroupUser();
            ClsCommonProcess.lookUpGroupUser(lookUpGroupUser);

            //bindingEmployee
            ClsCommonProcess.lookUpEmp(lookUpEmployee);

            //load thong tin khi Update-View 
            switch (strMode)
            {
                case ClsParameter.MODE_VIEW:
                case ClsParameter.MODE_UPDATE:
                    WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();
                    UserObject objUser = new UserObject();
                    try
                    {
                        objUser = ws.selectUser(strCode);
                        txtUserId.Text = objUser.USERID;
                        txtFullName.Text = objUser.FULLNAME;
                        txtUserName.Text = objUser.USERNAME;
                        lookUpGroupUser.EditValue = objUser.GROUPID;
                        lookUpEmployee.EditValue = objUser.EMPLOYEEID;
                        checkLock.Checked = objUser.LOCK;
                    }
                    catch (Exception ex)
                    {
                    }
                    break;
                default:
                    break;
            }

            if (strMode == ClsParameter.MODE_VIEW)
            {
                //txtUserId.Properties.ReadOnly = true;
                //txtUserName.Properties.ReadOnly = true;
                //txtFullName.Properties.ReadOnly = true;
                //lookUpGroupUser.Properties.ReadOnly = true;
                //bttNext.Visible = false;
                //bttSave.Visible = false;
                disableControl();
            }
            else if (strMode == ClsParameter.MODE_UPDATE)
            {
                txtUserId.Properties.ReadOnly = true;
                txtUserName.Properties.ReadOnly = true;
                bttNext.Visible = false;
            }
        }

        private void bttSave_Click(object sender, EventArgs e)
        {
            /*
             * Dungnv   :   22/10/2014
             * Purpose  :   Luu thong tin 
             */

            bool bConfirm = false;
            if (checkValidate() == false)
            {
                return;
            }

            try
            {
                UserObject objuser = new UserObject();
                WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();
                string strUserId = "";
                objuser.USERID = txtUserId.Text.Trim();
                objuser.USERNAME = txtUserName.Text.Trim().Replace("'", "");

                if (lookUpGroupUser.EditValue != null)
                {
                    objuser.GROUPID = lookUpGroupUser.EditValue.ToString().Trim();
                }
                else
                {
                    objuser.GROUPID = "";
                }


                if (lookUpEmployee.EditValue != null)
                {
                    objuser.EMPLOYEEID  = lookUpEmployee.EditValue.ToString().Trim();
                }
                else
                {
                    objuser.EMPLOYEEID = "";
                }


                objuser.CREATEBY = ClsParameter.STRUCT_INFOLOGIN.UserId;
                objuser.FULLNAME = txtFullName.Text.Trim().Replace("'", "");
                objuser.LOCK = checkLock.Checked;


                bConfirm = ClsCommonProcess.confirmYesNo(ClsParameter.MSG_QUESTION_SAVE);
                if (bConfirm == true)
                {
                    switch (strMode)
                    {
                        case ClsParameter.MODE_ADD:
                            if (ws.insertUser(out strUserId, objuser))
                            {
                                if (strUserId == "99999")
                                {
                                    ClsCommonProcess.msgError(ClsParameter.MSG_USERS_EXIST);
                                    txtUserName.Text = "";
                                    txtUserName.Focus();
                                    return;
                                }
                                else
                                {
                                    txtUserId.Text = strUserId;
                                    ClsCommonProcess.msg(ClsParameter.MSG_ADD_SUCCESSFULL);
                                    disableControl();
                                    bttSave.Enabled = false;
                                    return;
                                }

                            }
                            else
                            {
                                ClsCommonProcess.msgError(ClsParameter.MSG_ADD_FAIL);
                                return;
                            }
                            break;
                        case ClsParameter.MODE_UPDATE:
                            if (ws.updateUser(objuser))
                            {
                                ClsCommonProcess.msg(ClsParameter.MSG_UPDATE_SUCCESSFULL);
                                this.Close();
                                return;
                            }
                            else
                            {
                                ClsCommonProcess.msgError(ClsParameter.MSG_UPDATE_FAIL);
                                return;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
            }

           
        }
        private bool checkValidate()
        {
            /*
             * Dungnv : 22/10/2014 
             * Check tin nhap vao
             */

            if (txtUserName.Text.Trim() == "")
            {
                ClsCommonProcess.msgError(ClsParameter.MSG_USERS_USERNAME_EMPTY);
                return false;

            }

            if (txtFullName.Text.Trim() == "")
            {
                ClsCommonProcess.msgError(ClsParameter.MSG_USERS_FULLNAME_EMPTY);
                return false;
            }

            try
            {
                string text = lookUpGroupUser.EditValue.ToString();
                if (text == "" || text == null)
                {
                    ClsCommonProcess.msgError(ClsParameter.MSG_USERS_GROUP_USER_EMPTY);
                    return false;
                }
            }
            catch (Exception ex)
            {
                ClsCommonProcess.msgError(ClsParameter.MSG_USERS_GROUP_USER_EMPTY);
                return false;
            }

            return true;

        }

        private void lookUpGroupUser_Click(object sender, EventArgs e)
        {
            /*
             * Dungnv   :   23/10/2014
             * Purpose  :   Change Text 
             */

            try
            {
                ClsCommonProcess.changeButtonSearchClear(sender, e, imgLst);

            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void bttNext_Click(object sender, EventArgs e)
        {
            /*
             * Dungnv : 21/10/2014
             */
            txtUserId.Text = "";
            txtFullName.Text = "";
            txtFullName.Text = "";
            bttSave.Enabled = true;
        }

        private void bttExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lookUpEmployee_Click(object sender, EventArgs e)
        {
            /*
           * Dungnv   :   23/10/2014
           * Purpose  :   Change Text 
           */

            try
            {
                ClsCommonProcess.changeButtonSearchClear(sender, e, imgLst);

            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void disableControl()
        {
            /*
             *  Dungnv  :   15/05/2016
             *  Purpose :   disable control 
             */
  
            txtUserId.Properties.ReadOnly = true;
            txtUserName.Properties.ReadOnly = true;
            txtFullName.Properties.ReadOnly = true;
            lookUpGroupUser.Properties.ReadOnly = true;
            lookUpEmployee.Properties.ReadOnly = true;
            bttNext.Visible = false;
            bttSave.Visible = false;
        }
    }
}