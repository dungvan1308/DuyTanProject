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
    public partial class frmGroupUser : DevExpress.XtraEditors.XtraForm
    {
        public string strMode = "";
        public string strCode = "";

        public frmGroupUser()
        {
            InitializeComponent();
        }

        private void bttSave_Click(object sender, EventArgs e)
        {
            /*
             * Dungnv : 18/10/2014
             * Lưu thông tin Group User
             */


            //Xac nhan co luu thong tin hay khong
            bool bConfirm = false;
            bConfirm = ClsCommonProcess.confirmYesNo(ClsParameter.MSG_QUESTION_SAVE);

            if (bConfirm == false)
            {
                return;
            }


            if (txtGroupName.Text == "")
            {
                ClsCommonProcess.msgError(ClsParameter.MSG_GROUPNAME_EMPTY);
                txtGroupName.Focus();
                return;
            }

            GroupUserObject objGroup = new GroupUserObject();
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();
            GroupUserObject objGroupTemp = ws.selectGroupUserByName(txtGroupName.Text.Trim().Replace("'", ""));
            if (strMode == ClsParameter.MODE_ADD)
            {
                if (objGroupTemp != null)
                {
                    ClsCommonProcess.msgError(ClsParameter.MSG_GROUP_USER_NAME_EXIST);
                    txtGroupName.Focus();
                    return;
                }
            }
            else if (strMode == ClsParameter.MODE_UPDATE)
            {
                if (objGroupTemp != null && objGroupTemp.GROUPID != txtGroupId.Text.Trim())
                {
                    ClsCommonProcess.msgError(ClsParameter.MSG_GROUP_USER_NAME_EXIST);
                    txtGroupName.Focus();
                    return;

                }
            }

            string strGroupId = "";
            objGroup.GROUPNAME = txtGroupName.Text.Trim().Replace("'", "");
            objGroup.NOTE = txtNote.Text.Trim().Replace("'", "");
            objGroup.CREATEBY = ClsParameter.STRUCT_INFOLOGIN.UserId;
            objGroup.MODIFIEDBY = ClsParameter.STRUCT_INFOLOGIN.UserId;
            objGroup.GROUPID = txtGroupId.Text.Trim();

            try
            {
                switch (strMode)
                {
                    case ClsParameter.MODE_ADD:
                        if (ws.insertGroupUser(out strGroupId, objGroup))
                        {
                            txtGroupId.Text = strGroupId;
                            ClsCommonProcess.msg(ClsParameter.MSG_ADD_SUCCESSFULL);
                            bttSave.Enabled = false;
                            return;
                        }
                        else
                        {
                            ClsCommonProcess.msgError(ClsParameter.MSG_ADD_FAIL);
                            return;
                        }

                        break;
                    case ClsParameter.MODE_UPDATE:
                        if (ws.updateGroupUser(objGroup))
                        {

                            ClsCommonProcess.msg(ClsParameter.MSG_UPDATE_SUCCESSFULL);
                            bttSave.Enabled = false;
                            this.Close();
                            return;
                        }
                        else
                        {
                            ClsCommonProcess.msgError(ClsParameter.MSG_UPDATE_SUCCESSFULL);
                            return;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                ClsCommonProcess.msgError(ClsParameter.MSG_DATA_ERROR);
                return;
            }
        }

        private void bttNext_Click(object sender, EventArgs e)
        {
            /*
             * Dungnv   : 11/11/2015
             * Purpose  : Them moi tiep tuc 
             */
            txtGroupId.Text = "";
            txtGroupName.Text = "";
            txtNote.Text = "";
            bttSave.Enabled = true;
        }

        private void frmGroupUser_Load(object sender, EventArgs e)
        {
            /*
             * Dungnv   : 11/11/2015
             * Purpose  : Load thong tin 
             */
            switch (strMode)
            {
                case ClsParameter.MODE_ADD:
                    break;
                case ClsParameter.MODE_UPDATE:
                    loadGroupUser(this.strCode);
                    bttNext.Visible = false;
                    break;
                case ClsParameter.MODE_VIEW:
                    loadGroupUser(this.strCode);
                    txtGroupId.ReadOnly = true;
                    txtGroupName.ReadOnly = true;
                    txtNote.ReadOnly = true;

                    bttNext.Visible = false;
                    bttSave.Visible = false;
                    break;

            }
        }

        private void loadGroupUser(string strCode)
        {
            /*
             * Dungnv   : 18/10/2014
             * Purpose  : Load thong tin  Group User 
             */

            GroupUserObject objGroupUser = new GroupUserObject();
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();

            try
            {
                objGroupUser = ws.selectGroupUser(strCode);
                if (objGroupUser != null)
                {
                    txtGroupId.Text = objGroupUser.GROUPID;
                    txtGroupName.Text = objGroupUser.GROUPNAME;
                    txtNote.Text = objGroupUser.NOTE;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void bttExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}