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
    public partial class frmUserResetPass : DevExpress.XtraEditors.XtraForm
    {
        public frmUserResetPass()
        {
            InitializeComponent();
        }

        private void frmUserResetPass_Load(object sender, EventArgs e)
        {
            /*
            * Dungnv   : 11/11/2015
            * Purpose  : Load thong tin 
            */

            //Load list User 
            ClsCommonProcess.lookUpUser(lookupUserName);
        }

        private void bttSave_Click(object sender, EventArgs e)
        {
            /*
             * Dungnv   :   23/10/2014
             * Purpose  :   Set Pass
             */

            bool bConfirm = false;
            bConfirm = ClsCommonProcess.confirmYesNo(ClsParameter.MSG_QUESTION_SAVE);

            if (bConfirm == false)
            {
                //Khong dong y 
                return;
            }

            if (lookupUserName.Text.Trim() == "")
            {
                ClsCommonProcess.msgError(ClsParameter.MSG_USERS_USERNAME_EMPTY);
                return;
            }

            if (txtPass.Text.Trim() == "")
            {
                ClsCommonProcess.msgError(ClsParameter.MSG_USERS_PASS_EMPTY);
                return;
            }

            if (txtPass.Text.Trim() != txtRetypePass.Text.Trim())
            {
                ClsCommonProcess.msgError(ClsParameter.MSG_USERS_PASS_NOT_SAME);
                return;
            }



            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();
            UserObject objUser = new UserObject();
            objUser.USERNAME = lookupUserName.EditValue.ToString();
            objUser.MODIFIEDBY = ClsParameter.STRUCT_INFOLOGIN.UserId;
            objUser.PASSWORD = ClsCommonProcess.EncryptData(txtPass.Text.Trim());


            try
            {
                if (ws.resetPass(objUser))
                {
                    ClsCommonProcess.msg(ClsParameter.MSG_USERS_RESET_PASS_SUCCESS);
                    bttSave.Enabled = false;
                    return;
                }
                else
                {
                    ClsCommonProcess.msgError(ClsParameter.MSG_USERS_RESET_PASS_FAIL);
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
            this.Close();
        }

        private void lookupUserName_Click(object sender, EventArgs e)
        {
            try
            {
                ClsCommonProcess.changeButtonSearchClear(sender, e, imgLst);
                bttSave.Enabled = true;
                txtPass.Text = "";
                txtRetypePass.Text = "";
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}