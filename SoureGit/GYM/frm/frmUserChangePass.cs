using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GYM.Common;
using GYM.ServiceReferenceDuyTan;


namespace GYM.frm
{
    public partial class frmUserChangePass : DevExpress.XtraEditors.XtraForm
    {
        public frmUserChangePass()
        {
            InitializeComponent();
        }

        private void frmUserChangePass_Load(object sender, EventArgs e)
        {
            /*
             * dungnv   :   11/11/2015
             */
            txtUserName.Text = ClsParameter.STRUCT_INFOLOGIN.UserName;
        }

        private void bttSave_Click(object sender, EventArgs e)
        {
            /*
             * Dungnv 
             */

            bool bConfirm = false;
            bConfirm = ClsCommonProcess.confirmYesNo(ClsParameter.MSG_QUESTION_SAVE);

            if (bConfirm == false)
            {
                //Khong dong y 
                return;
            }

            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();
            UserObject objUser = new UserObject();
            UserObject outUser = new UserObject();

            try
            {
                objUser.USERNAME = txtUserName.Text.Trim();
                objUser.PASSWORD = ClsCommonProcess.EncryptData(txtOldPass.Text.Trim());
                //Check mat khau co dung ko 
                if (ws.loginUser(out outUser, objUser) == false)
                {
                    ClsCommonProcess.msgError(ClsParameter.MSG_USERS_PASS_OLD_INVALID);
                    return;
                }


                if (txtUserName.Text.Trim() == "")
                {
                    ClsCommonProcess.msgError(ClsParameter.MSG_USERS_USERNAME_EMPTY);
                    return;
                }

                if (txtOldPass.Text.Trim() == "")
                {
                    ClsCommonProcess.msgError(ClsParameter.MSG_USERS_PASS_EMPTY);
                    return;
                }

                if (txtNewPass.Text.Trim() == "")
                {
                    ClsCommonProcess.msgError(ClsParameter.MSG_USERS_NEW_PASS_EMPTY);
                    return;
                }

                if (txtNewPass.Text.Trim() != txtRetypePass.Text.Trim())
                {
                    ClsCommonProcess.msgError(ClsParameter.MSG_USERS_PASS_NOT_SAME);
                    return;
                }



                objUser.USERNAME = txtUserName.Text.Trim();
                objUser.MODIFIEDBY = ClsParameter.STRUCT_INFOLOGIN.UserId;
                objUser.PASSWORD = ClsCommonProcess.EncryptData(txtNewPass.Text.Trim());


                if (ws.resetPass(objUser))
                {
                    ClsCommonProcess.msg(ClsParameter.MSG_USER_CHANGE_PASS_SUCESSS);
                    bttSave.Enabled = false;
                    return;
                }
                else
                {
                    ClsCommonProcess.msgError(ClsParameter.MSG_USER_CHANGE_PASS_FAIL);
                    return;
                }
            }
            catch (Exception ex)
            {
                ClsCommonProcess.msgError(ClsParameter.MSG_USERS_RESET_PASS_FAIL);
                return;
            }
        }

        private void bttExit_Click(object sender, EventArgs e)
        {
            /*
             * Dungnv : 11/11/2015
             */
            this.Close();
        }
    }
}