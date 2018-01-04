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
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public bool LogonSuccessful = false;
        

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            /*
             * Dungnv   :   03/06/2016
             * Purpose  :   Check Lience Key
             */
            
            /*
            if(checkLience()==false)
            {
                this.Close();

            }
             */

            
        }

        private void bttExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void bttLogin_Click(object sender, EventArgs e)
        {
            /*
             * Dungnv   :   05/11/2015
             */

            
                acept_click();
            
            
        }

        private void acept_click()
        {
            /*
             * Dungnv : 18/10/2014
             * Purpose: Xu ly dang nhap 
             */
            string strUserName = "";
            string strPass = "";
            string strUserId = "";
            strUserName = txtUserName.Text.Trim();
            strPass = txtPass.Text.Trim();

            UserObject objUser = new UserObject();
            UserObject outUser = new UserObject();

            objUser.USERNAME = strUserName;
            strPass = ClsCommonProcess.EncryptData(strPass);
            objUser.PASSWORD = strPass;


            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();


            try
            {
                if (ws.loginUser(out outUser, objUser))
                {
                    this.LogonSuccessful = true;
                    ClsParameter.STRUCT_INFOLOGIN.UserName = outUser.USERNAME;
                    ClsParameter.STRUCT_INFOLOGIN.UserId = outUser.USERID;
                    ClsParameter.STRUCT_INFOLOGIN.FullName = outUser.FULLNAME;
                    ClsParameter.STRUCT_INFOLOGIN.GroupId = outUser.GROUPID;

                    ClsParameter.STRUCT_INFOLOGIN.CompanyName = ResourceHelper.GetCompanyInfo("CompanyName").ToString();
                    ClsParameter.STRUCT_INFOLOGIN.Address = ResourceHelper.GetCompanyInfo("Address").ToString();
                    ClsParameter.STRUCT_INFOLOGIN.Tax = ResourceHelper.GetCompanyInfo("Tax").ToString();
                    ClsParameter.STRUCT_INFOLOGIN.Tel = ResourceHelper.GetCompanyInfo("Tel").ToString();
                    ClsParameter.STRUCT_INFOLOGIN.Fax = ResourceHelper.GetCompanyInfo("Fax").ToString();

                    this.Close();
                }
                else
                {
                    ClsCommonProcess.msgError(ClsParameter.MSG_LOGIN_FAIL);
                }
            }
            catch (Exception ex)
            {
                ClsCommonProcess.msgError(ClsParameter.MSG_LOGIN_FAIL);

            }

        }

        private bool checkLience()
        {
            /*
             * Dungnv   :   03/06/2016
             * Purpose  :   Check lience key 
             */
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();
            if(ws.checkLienceKey()==false)
            {
                frmLience frm = new frmLience();
                frm.ShowDialog();
                return false;
            }

            return true;
        }
    }
}