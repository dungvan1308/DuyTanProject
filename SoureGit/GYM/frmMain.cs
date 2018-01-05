using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GYM.Common;
using GYM.frm;
using GYM.ServiceReferenceDuyTan;
using System.Collections;


namespace GYM
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            /*
             * Dungnv   : 11/11/2015
             * Purpose  : Xử lý sự kiện load form 
             */

            //Show thông tin user đăng nhập 
            barItem_UserLogin.Caption = ClsParameter.STRUCT_INFOLOGIN.UserId.ToString() + " : " + ClsParameter.STRUCT_INFOLOGIN.UserName.ToString();
            
            //Doi voi user admin - quan tri cho  toan quyen he thong 
            if (ClsParameter.STRUCT_INFOLOGIN.UserId == "00000")
            {
                
            }
            else
            {
                authorizeMenu();

                //Default luon enable 
                showMenuDefault();
            }

           
        }

        private void showMenuDefault()
        {
            /*
             * Dungnv   :   22/06/2016
             * Purpose  :   Show default
             */

            foreach (DevExpress.XtraBars.BarItem item in barManager.Manager.Items)
            {

                if (item.Name == "barSubItem_System" || item.Name == "barBttItem_ChangePass" || item.Name == "barBttItem_Exit"
                    || item.Name=="barSubItem_Manage")
                {
                    item.Links[0].Visible = true;
                }

                //if (item.Tag != null)
                //{
                //    if (item.Tag.ToString() == menuId)
                //    {
                //        item.Links[0].Visible = showStatus;
                //        //item.Enabled = showStatus;
                //        return;
                //    }
                //}
            }
        }

        private void navBarItem_GroupUser_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            /*
             *  Dungnv  :   10/11/2015
             *  Purpose :   Quản lý nhóm người dùng
             */

            frmManageCommon frmManage = new frmManageCommon();
            frmManage.strModule = ClsParameter.MODULE_GROUPUSER;
            frmManage.Text = ClsParameter.TITLE_GROUPUSER;
            frmManage.ShowDialog();
  
        }

       
        private void barBttItem_ChangePass_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*
             * Dungnv   :   11/11/2015
             * Purpose  :   Doi lai Pass
             */
            frmUserChangePass frm = new frmUserChangePass();
            frm.ShowDialog();
        }

        private void navBarItem_User_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            /*
             *  Dungnv  :   11/11/2015
             *  Purpose :   Quan ly Chung User 
             */
            manage_User();
        }

        private void manage_User()
        {
            /*
             *  Dungnv  :   11/11/2015
             *  Purpose :   Quan ly Chung User 
             */
            frmManageCommon frmManage = new frmManageCommon();
            frmManage.strModule = ClsParameter.MODULE_USER;
            frmManage.Text = ClsParameter.TITLE_USER;
            frmManage.ShowDialog();

        }

        private void navBarItem_Authorise_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            /*
             * Dungnv :     16/11/2015
             * Purpse :     Phan quyen 
             */
 
            frmAuthoriseMenu frm = new frmAuthoriseMenu();
            frm.strMode = ClsParameter.MODE_ADD;
            frm.ShowDialog();
        }

        private void navBarItem_SetPass_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            /*
             * Dungnv   : 22/10/2014
             * Purpose  : Thiet lap mat khau 
             */
            frmUserResetPass frm = new frmUserResetPass();
            frm.ShowDialog();
        }

        private void navBarItem_Employee_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            /*
            *  Dungnv  :   04/11/2014
            *  Purpose :   Quan ly Employee 
            */
            manage_Emploee();
        }

        private void manage_Emploee()
        {
            /*
            *  Dungnv  :   04/11/2014
            *  Purpose :   Quan ly Employee 
            */
            frmManageCommon frm = new frmManageCommon();
            frm.strModule = ClsParameter.MODULE_EMP;
            frm.Text = ClsParameter.TITLE_EMP;
            frm.ShowDialog();
        }

        private void navBarItem_Customer_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            /*
            * Dungnv   :   30/10/2014
            * Purpose  :   Quan lay khach hang 
            */
            frmManageCommon fmanage = new frmManageCommon();
            fmanage.strModule = ClsParameter.MODULE_CUST;
            fmanage.ShowDialog();
        }

        private void authorizeMenu()
        {
            /*
             * Dungnv   :
             * Purpose  :   Phân quyền menu
             */
 
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();
            UserObject userObj = ws.selectUser(ClsParameter.STRUCT_INFOLOGIN.UserId);
            if (userObj != null)
            {
                MenuObjectList menuList = ws.selectAllMenuItem();
                AuthorizeMenuObjectList authorizedMenuObjectList = ws.getAuthorizeMenus(userObj.GROUPID);
                if (menuList != null && authorizedMenuObjectList != null && authorizedMenuObjectList.menuIdList.Length > 0)
                {
                    ArrayList menuObjects = new ArrayList(menuList.list);
                    ArrayList authorizedMenuIDs = new ArrayList(authorizedMenuObjectList.menuIdList);
                    for (int i = 0; i < menuObjects.Count; i++)
                    {
                        MenuObject menuObject = (MenuObject)menuObjects[i];
                        if (!authorizedMenuIDs.Contains(menuObject.MENUID))
                        {
                            //if (!showSystemMenuItem(menuObject.MENUID, false))
                            //{
                            //    showMenuItem(menuObject.MENUID, false);
                            //}

                            //Show menu 
                            showSystemMenuItem(menuObject.MENUID, false);

                            //
                            showNavBarControlItem(menuObject.MENUID, false);

                        }
                    }
                }
            }
        }

        private void  showSystemMenuItem(string menuId, bool showStatus)
        {
            /*
             *  Dungnv  :   18/11/2015
             *  Purpose :   Xu ly phan quyen menu 
             */
  
            try
            {
                foreach (DevExpress.XtraBars.BarItem item in barManager.Manager.Items)
                {
                    if (item.Tag != null)
                    {
                        if (item.Tag.ToString() == menuId)
                        {
                            item.Links[0].Visible = showStatus;
                            //item.Enabled = showStatus;
                            return;
                        }
                    }

                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }

        private void showNavBarControlItem(string menuId, bool showStatus)
        {
            /*
             * Dungnv   :   22/06/2016
             * Purpose  :   Phan quyen doi voi navBarControl
             */

            try
            {
                for (int i = 0; i < navBarControl.Groups.Count; i++)
                {
                    if (navBarControl.Groups[i].Tag.ToString() == menuId)
                    {
                        navBarControl.Groups[i].Visible = showStatus;
                    }
                    else
                    {
                        for (int j = 0; j < navBarControl.Groups[i].ItemLinks.Count; j++)
                        {
                            if (navBarControl.Groups[i].ItemLinks[j].Item.Tag.ToString() == menuId)
                            {
                                navBarControl.Groups[i].ItemLinks[j].Visible = showStatus;
                                //navBarControl.Groups[i].ItemLinks[j].Item.Visible = showStatus;
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
            
        }

        private void barBttItem_Report_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*
             * Dungnv   :   23/11/2015
             * Purpose  :   Xu ly bao cao
             */
            frmReport frm = new frmReport();
            frm.ShowDialog();
        }

      

        private void navBarItem_Customer_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            /*
             * Dungnv   :   05/05/2016
             * Purpose  :   Quan ly thong tin Khach Hang
             */

            manage_Customer();
             

        }

        private void manage_Customer()
        {
            /*
             * Dungnv   :   05/05/2016
             * Purpose  :   Quan ly thong tin Khach Hang
             */

            frmManageCommon frm = new frmManageCommon();
            frm.strModule = ClsParameter.MODULE_CUST;
            frm.ShowDialog();
        }

      

        private void navBarItem_Contract_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            /*
             * Quan ly hop dong
             */

            manage_Contract();
        }

        private void manage_Contract()
        {
            /*
             * Quan ly hop dong
             */

            frmManageCommon frm = new frmManageCommon();
            frm.strModule = ClsParameter.MODULE_CONTRACT;
            frm.Text = ClsParameter.TITLE_CONTRACT;
            frm.ShowDialog();
        }

    
       

        private void navBarItem_Product_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            /*
             * Dungnv   :   15/05/2015
             * Purpose  :   Quan ly Product
             */

            manage_Product();
        }

        private void manage_Product()
        {
            /*
             * Dungnv   :   15/05/2015
             * Purpose  :   Quan ly Product
             */

            frmManageCommon frm = new frmManageCommon();
            frm.strModule = ClsParameter.MODULE_PROGRAME;
            frm.Text = ClsParameter.TITLE_PROGRAME;
            frm.ShowDialog();
        }

        private void nvBarItem_LoginLog_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            /*
             * Dungnv   :   20/05/2016
             * Purpose  :   Hiện thị danh sách người dùng đang truy cập hệ thống
             */

            frmAuditLog frm = new frmAuditLog();
            frm.ShowDialog();
        }

        private void barBttItem_Exit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*
             * Dungnv   :    26/05/2015
             * Purpose  :    Thoat , cap nhap vao Login 
             */
           
            logOut();
        }

        private void logOut()
        {
            /*
             * Dungnv   :   26/05/2016
             * Purpose  :   
             */
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();
            string strUserId = "";
            strUserId = ClsParameter.STRUCT_INFOLOGIN.UserId.Trim();
            bool bResult = false;
            bResult = ws.logOut(strUserId);
            Application.Exit();
            this.Dispose();
            this.Close();
           
            


        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            /*
             * Dungnv : 25/05/2016
             * Purpose:
             */

            logOut();
        }

      

        private void barBttItem_User_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*
             * Dungnv   : 08/06/2016
             */
            manage_User();
              
        }

        private void barbttItem_Employee_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*
             * Dungnv   :   08/06/2016
             */
            manage_Emploee();
        }

        private void barbttItem_Customer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*
             * Dungnv   :   08/06/2016
             */
            manage_Customer();
        }

        private void barbttItem_Product_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*
             * Dungnv   :   08/06/2016
             */
            manage_Product();
        }

        private void barbttItem_Contract_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*
             * Dungnv   :   08/06/2016
             */
            manage_Contract();
        }

        private void barBttItem_Restore_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*
             * Dungnv   :   08/06/2016
             * Purpose  :   Backup and restore database
             */
            frmBackupRestore frm = new frmBackupRestore();
            frm.ShowDialog();

        }

        private void barBttItem_Backup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            /*
             * Dungnv   :   11/06/2016
             * Purpose  :   Backup and Restore database
             */
            
            frmBackupAndRestore frm = new frmBackupAndRestore();
            frm.ShowDialog();

        }

        private void navBarItemRegJourney_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            /*
             * Dungnv : 12/10/2017
             */
            frmManageCommon frm = new frmManageCommon();
            frm.strModule = ClsParameter.MODULE_JOURNEY;
            frm.Show();
        }

        private void navBarItem_Place_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            /*
            * Dungnv : 12/10/2017
            */
            frmManageCommon frm = new frmManageCommon();
            frm.strModule = ClsParameter.MODULE_PLACE;
            frm.ShowDialog();
        }

        private void navBarItem_TeamTruck_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            /*
            * Dungnv : 12/10/2017
            */
            frmManageCommon frm = new frmManageCommon();
            frm.strModule = ClsParameter.MODULE_TRUST;
            frm.ShowDialog();
        }

        private void navBarItemAll_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmScreenStore frm = new frmScreenStore();
            frm.ShowDialog();
        }

        private void navBarItem_Stock_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            /*
             * Dungnv   :   26/11/2017
             * Purpose  :   Hien thi danh sach xe tai kho
             */

            frmScreenTrustStore frm = new frmScreenTrustStore();
            frm.ShowDialog();
        }

        private void navBarItemTeam_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            /*
             * Dungnv   :   29/12/2017
             * Purpose  :   Hiển thị thông tin tại đội xe
             */
            frmScreenTrustGroup frm = new frmScreenTrustGroup();
            frm.ShowDialog();
        }

       
      
    }
}