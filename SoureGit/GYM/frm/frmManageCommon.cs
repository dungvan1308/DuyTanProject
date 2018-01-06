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
using GYM.frm;
using DevExpress.Utils;

namespace GYM.frm
{
    public partial class frmManageCommon : DevExpress.XtraEditors.XtraForm
    {
        public string strModule = "";
        public string strCode = "";

        public frmManageCommon()
        {
            InitializeComponent();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void frmManageCommon_Load(object sender, EventArgs e)
        {

            /*
            * Dungnv   : 18/10/2014
            * Purpose  : Xu ly form quan ly chung 
            */

            try
            {
                switch (strModule)
                {
                    case ClsParameter.MODULE_USER:
                        bttLock.Visible = true;
                        bttUnlock.Visible = true;
                        break;
                    case ClsParameter.MODULE_CONTRACT:
                        cmbStatus.Enabled = true;
                        ClsCommonProcess.loadComboBoxEditSearch(cmbStatus, "STATUS", "CONTRACT");
                        bttUnlock.Visible = false;
                        bttLock.Visible = false;
                        break;
                    default:
                        bttUnlock.Visible = false;
                        bttLock.Visible = false;
                        cmbStatus.Enabled = false;
                        break;
                }

                DoSearch();

                if ((ClsParameter.STRUCT_INFOLOGIN.UserId == "00000") == false)
                {
                    //Doi voi admin thi toan quyen => khong can check 
                    checkAuthorize();
                }

            }
            catch(Exception ex)
            {

            }
           

        }

        #region Nhóm người dùng
        private void searchGroupUser()
        {
            /*
             * Dungnv : 14/10/2014
             * Purpose: Tim kiem thong tin cua Group User
             */
            string strContent = "";
            string strCondition = "";
            string strOrderBy = "";
            strContent = txtContent.Text.Trim();

            strCondition = " ( GROUPID like '%" + strContent + "%' or GROUPNAME like N'%" + strContent + "%' or NOTE like N'%" + strContent + "%' ) ";
            strOrderBy = "GROUPID";
            DataSet ds = new DataSet();


            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();

            try
            {
                ds = ws.selectGroupUserDymanic(strCondition, strOrderBy);
            }
            catch (Exception ex)
            {
                ds = null;

            }

            //Binding Gridview 
            gridControlMain.DataSource = null;
            if (ds != null)
            {
                gridControlMain.DataSource = ds.Tables[0];

                //Chinh Tieu De

                dtgResult.Columns[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[0].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[0].Caption = "STT";
                dtgResult.Columns[0].Width = 30;

                dtgResult.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[1].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                dtgResult.Columns[1].Caption = "Mã";
                dtgResult.Columns[1].Width = 50;

                dtgResult.Columns[2].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[2].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                dtgResult.Columns[2].Caption = "Tên";
                dtgResult.Columns[2].Width = 200;

                dtgResult.Columns[3].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[3].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                dtgResult.Columns[3].Caption = "Ghi Chú";
                dtgResult.Columns[3].Width = 200;

                dtgResult.Columns[4].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[4].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[4].Caption = "Người Tạo";
                dtgResult.Columns[4].Width = 100;
                dtgResult.Columns[4].Visible = false;

                dtgResult.Columns[5].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[5].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[5].Caption = "Ngày tạo";
                dtgResult.Columns[5].Width = 100;

                dtgResult.Columns[6].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[6].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                dtgResult.Columns[6].Caption = "Người sửa";
                dtgResult.Columns[6].Width = 150;
                dtgResult.Columns[6].Visible = false;

                dtgResult.Columns[7].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[7].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[7].Caption = "Ngày Sửa";
                dtgResult.Columns[7].Width = 150;


            }
            else
            {
                gridControlMain.DataSource = null;
            }
        }
        private void deleteGroupUser(string strCode)
        {
            /*
             * Dungnv   : 18/10/2014 
             * Purpose  : Xoa User
             */
            string strResutl = "";
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();
            try
            {
                if (ws.deleteGroupUser(out strResutl, strCode))
                {
                    if (strResutl == "11111")
                    {
                        ClsCommonProcess.msg(ClsParameter.MSG_DELTE_SUCESSFULL);
                        searchGroupUser();
                        return;
                    }
                    else if (strResutl == "00000")
                    {
                        ClsCommonProcess.msgError(ClsParameter.MSG_GROUP_USER_ISUSE);
                        return;
                    }
                    else
                    {
                        ClsCommonProcess.msgError(ClsParameter.MSG_DELETE_FAIL);
                        return;
                    }
                }
                else
                {
                    ClsCommonProcess.msgError(ClsParameter.MSG_DELETE_FAIL);
                    return;
                }
            }
            catch (Exception ex)
            {
                ClsCommonProcess.msgError(ClsParameter.MSG_DELETE_FAIL);
                return;
            }

        }
        #endregion

        #region User
        private void deleteUser(string strCode)
        {
            /*
             * Dungnv   : 18/10/2014 
             * Purpose  : Xoa User
             */
            string strResutl = "";
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();
            try
            {
                if (ws.deleteUser(out strResutl, strCode))
                {
                    if (strResutl == "11111")
                    {
                        ClsCommonProcess.msg(ClsParameter.MSG_DELTE_SUCESSFULL);
                        searchGroupUser();
                        return;
                    }
                    else if (strResutl == "00000")
                    {
                        ClsCommonProcess.msgError(ClsParameter.MSG_USER_ISUSE);
                        return;
                    }
                    else
                    {
                        ClsCommonProcess.msgError(ClsParameter.MSG_DELETE_FAIL);
                        return;
                    }
                }
                else
                {
                    ClsCommonProcess.msgError(ClsParameter.MSG_DELETE_FAIL);
                    return;
                }
            }
            catch (Exception ex)
            {
                ClsCommonProcess.msgError(ClsParameter.MSG_DELETE_FAIL);
                return;
            }

        }
        private void searchUser()
        {
            /*
             *  Dungnv  :   23/10/2014
             *  Purpose :   Lay thong tin User
             */

            string strContent = "";
            string strCondition = "";
            string strOrderBy = "";
            strContent = txtContent.Text.Trim();

            strCondition = " USERID like '%" + strContent + "%' or USERNAME like '%" + strContent + "%' or FULLNAME like '%" + strContent + "%'  ";
            strOrderBy = "USERID";
            DataSet ds = new DataSet();


            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();

            try
            {
                ds = ws.selectAllUser(strCondition, strOrderBy);
            }
            catch (Exception ex)
            {
                ds = null;

            }

            //Binding Gridview 
            gridControlMain.DataSource = null;
            if (ds != null)
            {
                gridControlMain.DataSource = ds.Tables[0];

                //Chinh Tieu De

                dtgResult.Columns[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[0].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[0].Caption = "STT";
                dtgResult.Columns[0].Width = 50;

                dtgResult.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[1].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                dtgResult.Columns[1].Caption = "Mã";
                dtgResult.Columns[1].Width = 80;

                dtgResult.Columns[2].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[2].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                dtgResult.Columns[2].Caption = "Tên đăng nhập";
                dtgResult.Columns[2].Width = 100;

                dtgResult.Columns[3].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[3].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                dtgResult.Columns[3].Caption = "Họ Tên";
                dtgResult.Columns[3].Width = 150;

                dtgResult.Columns[4].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[4].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                dtgResult.Columns[4].Caption = "Mã nhân viên";
                dtgResult.Columns[4].Width = 100;

                dtgResult.Columns[5].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[5].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[5].Caption = "Nhóm người dùng";
                dtgResult.Columns[5].Width = 80;

                dtgResult.Columns[6].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[6].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[6].Caption = "Trạng thái khóa";
                dtgResult.Columns[6].Width = 100;

              
                dtgResult.Columns[7].Visible = false;
                dtgResult.Columns[8].Visible = false;
                dtgResult.Columns[9].Visible = false;
                dtgResult.Columns[10].Visible = false;

             

            }
            else
            {
                gridControlMain.DataSource = null;
            }

        }
        #endregion

        #region xử lý employee
        private void deleteEmp(string strCode)
        {
            string strResutl = "";
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();
            try
            {
                if (ws.deleteEmployee(out strResutl, strCode))
                {
                    if (strResutl == ClsParameter.OBJECT_DELETE_SUCCESSFUL)
                    {
                        ClsCommonProcess.msg(ClsParameter.MSG_DELTE_SUCESSFULL);
                        searchEmployee();
                        return;
                    }
                    else if (strResutl == ClsParameter.OBJECT_DELETE_IN_USE)
                    {
                        ClsCommonProcess.msgError(ClsParameter.MSG_OBJECT_IN_USE);
                        return;
                    }
                    else
                    {
                        ClsCommonProcess.msgError(ClsParameter.MSG_DELETE_FAIL);
                        return;
                    }
                }
                else
                {
                    ClsCommonProcess.msgError(ClsParameter.MSG_DELETE_FAIL);
                    return;
                }
            }
            catch (Exception ex)
            {
                ClsCommonProcess.msgError(ClsParameter.MSG_DELETE_FAIL);
                return;
            }
        }
        private void searchEmployee()
        {
            string strContent = "";
            string strCondition = "";
            string strOrderBy = "";
            strContent = txtContent.Text.Trim();

            strCondition = "EmployeeId like '%" + strContent + "%' or EMPLOYEENAME like '%" + strContent + "%' or BIRTH_PLACE like '%" + strContent + "%' or IDENTITYCARD_PLACEISSUE like '%" + strContent
                            + "%' or GENDER like '%" + strCode + "%' ";
            strOrderBy = "EMPLOYEEID";
            DataSet ds = new DataSet();


            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();

            try
            {
                ds = ws.selectAllEmployee(strCondition, strOrderBy);
            }
            catch (Exception ex)
            {
                ds = null;

            }

            //Binding Gridview 
            gridControlMain.DataSource = null;
            if (ds != null)
            {
                gridControlMain.DataSource = ds.Tables[0];

                //Chinh Tieu De
                dtgResult.Columns[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[0].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[0].Caption = ClsParameter.LIST_COLUMN_NO;
                dtgResult.Columns[0].Width = 50;

                dtgResult.Columns[1].Visible = false;

                dtgResult.Columns[2].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[2].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                dtgResult.Columns[2].Caption = "Họ tên";
                dtgResult.Columns[2].Width = 150;

                dtgResult.Columns[3].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[3].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                dtgResult.Columns[3].Caption = "Ngày sinh";
                dtgResult.Columns[3].Width = 100;

                dtgResult.Columns[4].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[4].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                dtgResult.Columns[4].Caption = "Nơi sinh";
                dtgResult.Columns[4].Width = 100;

                dtgResult.Columns[5].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[5].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                dtgResult.Columns[5].Caption = "CMND";
                dtgResult.Columns[5].Width = 80;

                dtgResult.Columns[6].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[6].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[6].Caption = "Ngày cấp";
                dtgResult.Columns[6].Width = 80;

                dtgResult.Columns[7].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[7].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[7].Caption = "Nơi cấp";
                dtgResult.Columns[7].Width = 120;

                dtgResult.Columns[8].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[8].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[8].Caption = "Giới tính";
                dtgResult.Columns[8].Width = 100;


                dtgResult.Columns[9].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[9].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[9].Caption = "Tình trạng hôn nhân";
                dtgResult.Columns[9].Width = 100;

                dtgResult.Columns[10].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[10].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[10].Caption = "Địa Chỉ";
                dtgResult.Columns[10].Width = 200;

                dtgResult.Columns[11].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[11].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[11].Caption = "Tỉnh / Tp";
                dtgResult.Columns[11].Width = 150;

                dtgResult.Columns[12].Visible = false;

                dtgResult.Columns[13].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[13].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[13].Caption = "Mobile";
                dtgResult.Columns[13].Width = 80;

                dtgResult.Columns[14].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[14].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[14].Caption = "Email";
                dtgResult.Columns[14].Width = 120;


                
                dtgResult.Columns[15].Visible = false;
                dtgResult.Columns[16].Visible = false;
                dtgResult.Columns[17].Visible = false;
                dtgResult.Columns[18].Visible = false;
                dtgResult.Columns[19].Visible = false;
                dtgResult.Columns[20].Visible = false;
                dtgResult.Columns[21].Visible = false;
                dtgResult.Columns[22].Visible = false;
                dtgResult.Columns[23].Visible = false;
                dtgResult.Columns[24].Visible = false;
                dtgResult.Columns[25].Visible = false;

            }
            else
            {
                gridControlMain.DataSource = null;
            }
        }
        #endregion

        #region Xu ly Trust
        private void searchTrust()
        {
            string strContent = "";
            string strCondition = "";
            string strOrderBy = "";
            strContent = txtContent.Text.Trim();

            strCondition = " A.TrustID like '%" + strContent + "%' or A.TrustName like '%" + strContent + "%' or B.DESCRIPTIONS like '%" + strContent + "%' or C.DESCRIPTIONS like '%" + strContent + "%'";
                            
            strOrderBy = "TrustID";
            DataSet ds = new DataSet();


            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();

            try
            {
                ds = ws.selectAllTrust(strCondition, strOrderBy);
            }
            catch (Exception ex)
            {
                ds = null;

            }

            //Binding Gridview 
            gridControlMain.DataSource = null;
            if (ds != null)
            {
                gridControlMain.DataSource = ds.Tables[0];

                //Chinh Tieu De
                dtgResult.Columns[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[0].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[0].Caption = "STT";
                dtgResult.Columns[0].Width = 50;

                dtgResult.Columns[1].Visible = false;

                dtgResult.Columns[2].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[2].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                dtgResult.Columns[2].Caption = "Tên Xe";
                dtgResult.Columns[2].Width = 150;

                dtgResult.Columns[3].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[3].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                dtgResult.Columns[3].Caption = "Bản số";
                dtgResult.Columns[3].Width = 100;

                dtgResult.Columns[4].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[4].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[4].Caption = "Loại xe";
                dtgResult.Columns[4].Width = 100;

                dtgResult.Columns[5].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[5].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[5].Caption = "Ngày mua";
                dtgResult.Columns[5].Width = 100;

                dtgResult.Columns[6].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[6].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[6].Caption = "Giá trị";
                dtgResult.Columns[6].Width = 100;
                dtgResult.Columns[6].DisplayFormat.FormatType = FormatType.Numeric;
                dtgResult.Columns[6].DisplayFormat.FormatString = "#,#";


                dtgResult.Columns[7].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[7].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[7].Caption = "Số chỗ ngồi";
                dtgResult.Columns[7].Width = 100;


                dtgResult.Columns[8].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[8].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[8].Caption = "Màu xe";
                dtgResult.Columns[8].Width = 100;

                dtgResult.Columns[9].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[9].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[9].Caption = "Công suất";
                dtgResult.Columns[9].Width = 100;

                dtgResult.Columns[10].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[10].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[10].Caption = "Ngày hết hạn";
                dtgResult.Columns[10].Width = 100;

                dtgResult.Columns[11].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[11].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[11].Caption = "Nhóm xe";
                dtgResult.Columns[11].Width = 100;

                

            }
            else
            {
                gridControlMain.DataSource = null;
            }
        }
        private void deleteTrust(int iTrustID)
        {
            string strResutl = "";
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();
            try
            {
                if (ws.deleteTrust(out strResutl, iTrustID))
                {
                    if (strResutl == ClsParameter.OBJECT_DELETE_SUCCESSFUL)
                    {
                        ClsCommonProcess.msg(ClsParameter.MSG_DELTE_SUCESSFULL);
                        searchTrust();
                        return;
                    }
                    else if (strResutl == ClsParameter.OBJECT_DELETE_IN_USE)
                    {
                        ClsCommonProcess.msgError(ClsParameter.MSG_OBJECT_IN_USE);
                        return;
                    }
                    else
                    {
                        ClsCommonProcess.msgError(ClsParameter.MSG_DELETE_FAIL);
                        return;
                    }
                }
                else
                {
                    ClsCommonProcess.msgError(ClsParameter.MSG_DELETE_FAIL);
                    return;
                }
            }
            catch (Exception ex)
            {
                ClsCommonProcess.msgError(ClsParameter.MSG_DELETE_FAIL);
                return;
            }
        }
        #endregion 

        #region Xu ly Place
        private void searchPlace()
        {
            string strContent = "";
            string strCondition = "";
            string strOrderBy = "";
            strContent = txtContent.Text.Trim();

            strCondition = " A.PlaceName like '%" + strContent + "%'" ;

            strOrderBy = "PlaceID";
            DataSet ds = new DataSet();


            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();

            try
            {
                ds = ws.selectAllPlace(strCondition, strOrderBy);
            }
            catch (Exception ex)
            {
                ds = null;

            }

            //Binding Gridview 
            gridControlMain.DataSource = null;
            if (ds != null)
            {
                gridControlMain.DataSource = ds.Tables[0];

                //Chinh Tieu De
                dtgResult.Columns[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[0].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[0].Caption = "STT";
                dtgResult.Columns[0].Width = 30;

                dtgResult.Columns[1].Visible = false;

                dtgResult.Columns[2].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[2].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                dtgResult.Columns[2].Caption= "Địa điểm";
                dtgResult.Columns[2].Width = 100;

                dtgResult.Columns[3].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[3].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                dtgResult.Columns[3].Caption = "Địa chỉ";
                dtgResult.Columns[3].Width = 150;

                dtgResult.Columns[4].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[4].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[4].Caption = "Quận Huyện";
                dtgResult.Columns[4].Width = 100;

                dtgResult.Columns[5].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[5].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[5].Caption = "Tỉnh / TP";
                dtgResult.Columns[5].Width = 100;


                dtgResult.Columns[6].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[6].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[6].Caption = "GPS X";
                dtgResult.Columns[6].Width = 50;

                dtgResult.Columns[7].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[7].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[7].Caption = "GPS Y";
                dtgResult.Columns[7].Width = 50;


                dtgResult.Columns[8].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[8].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[8].Caption = "Khoản cách với Duy Tân";
                dtgResult.Columns[8].Width = 120;

                dtgResult.Columns[9].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[9].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[9].Caption = "Thời gian đến Duy Tân";
                dtgResult.Columns[9].Width = 120;


            }
            else
            {
                gridControlMain.DataSource = null;
            }
        }

        private void searchJourney()
        {
            /*
             * Dungnv : 05/01/2017
             */
 
            string strContent = "";
            string strCondition = "";
            string strOrderBy = "";
            strContent = txtContent.Text.Trim();

            strCondition = "VehicleNumber like '%" + strContent + "%' or D.EmployeeName like '%" + strContent + "%' or B.EmployeeName like '%" + strContent + "%' or C.EmployeeName like '%" + strContent
                            + "%' or E.PlaceName like '%" + strContent + "%' or F.PlaceName like '%" + strContent + "%' or H.PlaceName like '%" + strContent + "%' ";
            strOrderBy = "JourneyID";
            DataSet ds = new DataSet();


            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();

            try
            {
                ds = ws.selectAllJourney(strCondition,strContent);
            }
            catch (Exception ex)
            {
                ds = null;

            }

            //Binding Gridview 
            gridControlMain.DataSource = null;
            if (ds != null)
            {
                gridControlMain.DataSource = ds.Tables[0];
                dtgResult.Appearance.HeaderPanel.Font = new System.Drawing.Font(dtgResult.Appearance.HeaderPanel.Font, FontStyle.Bold);

                //Chinh Tieu De
                dtgResult.Columns[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[0].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[0].Caption = "STT";
                dtgResult.Columns[0].Width = 30;

                dtgResult.Columns[1].Visible = false;

                dtgResult.Columns[2].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[2].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                dtgResult.Columns[2].Caption = "Ngày hành trình";
                dtgResult.Columns[2].Width = 80;

                dtgResult.Columns[3].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[3].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                dtgResult.Columns[3].Caption = "Số Xe";
                dtgResult.Columns[3].Width = 80;

                dtgResult.Columns[4].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[4].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[4].Caption = "Tài Xế";
                dtgResult.Columns[4].Width = 120;

                dtgResult.Columns[5].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[5].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[5].Caption = "Giao hàng 1";
                dtgResult.Columns[5].Width = 120;


                dtgResult.Columns[6].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[6].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[6].Caption = "Giao hàng 2";
                dtgResult.Columns[6].Width = 120;

                dtgResult.Columns[7].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[7].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[7].Caption = "Điểm xuất phát";
                dtgResult.Columns[7].Width = 120;


                dtgResult.Columns[8].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[8].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[8].Caption = "Giờ Xuất Phát Kế Hoạch";
                dtgResult.Columns[8].Width = 140;
                dtgResult.Columns[8].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";

                dtgResult.Columns[9].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[9].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[9].Caption = "Điểm giao hàng 1";
                dtgResult.Columns[9].Width = 100;

                dtgResult.Columns[10].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[10].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[10].Caption = "Giờ đến KH 1";
                dtgResult.Columns[10].Width = 140;

                dtgResult.Columns[11].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[11].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[11].Caption = "Giờ đi KH 2";
                dtgResult.Columns[11].Width = 140;
                dtgResult.Columns[11].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";

                dtgResult.Columns[12].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[12].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[12].Caption = "Điểm giao hàng 2";
                dtgResult.Columns[12].Width = 100;

                dtgResult.Columns[13].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[13].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[13].Caption = "Giờ đến KH 2";
                dtgResult.Columns[13].Width = 140;
                dtgResult.Columns[13].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";

                dtgResult.Columns[14].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[14].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[14].Caption = "Giờ đi KH 3";
                dtgResult.Columns[14].Width = 140;
                dtgResult.Columns[14].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";

                dtgResult.Columns[15].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[15].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[15].Caption = "Điểm giao hàng 3";
                dtgResult.Columns[15].Width = 120;

                dtgResult.Columns[16].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[16].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[16].Caption = "Giờ đến KH 3";
                dtgResult.Columns[16].Width = 140;
                dtgResult.Columns[16].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";

                dtgResult.Columns[17].Visible = false;
                dtgResult.Columns[18].Visible = false;
                dtgResult.Columns[19].Visible = false;
            }

                
        }


        private void deletePlace(int iPlaceId)
        {
            string strResutl = "";
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();
            try
            {
                if (ws.deletePlace(out strResutl, iPlaceId))
                {
                    if (strResutl == ClsParameter.OBJECT_DELETE_SUCCESSFUL)
                    {
                        ClsCommonProcess.msg(ClsParameter.MSG_DELTE_SUCESSFULL);
                        searchPlace();
                        return;
                    }
                    else if (strResutl == ClsParameter.OBJECT_DELETE_IN_USE)
                    {
                        ClsCommonProcess.msgError(ClsParameter.MSG_OBJECT_IN_USE);
                        return;
                    }
                    else
                    {
                        ClsCommonProcess.msgError(ClsParameter.MSG_DELETE_FAIL);
                        return;
                    }
                }
                else
                {
                    ClsCommonProcess.msgError(ClsParameter.MSG_DELETE_FAIL);
                    return;
                }
            }
            catch (Exception ex)
            {
                ClsCommonProcess.msgError(ClsParameter.MSG_DELETE_FAIL);
                return;
            }
        }
        #endregion 

        private void DoSearch()
        {
            gridControlMain.DataSource = null;
            switch (strModule)
            {
                case ClsParameter.MODULE_GROUPUSER:
                    searchGroupUser();
                    break;
                case ClsParameter.MODULE_USER:
                    searchUser();
                    break;
                case ClsParameter.MODULE_EMP:
                    searchEmployee();
                    break;
                case ClsParameter.MODULE_TRUST:
                    searchTrust();
                    break;
                case ClsParameter.MODULE_PLACE:
                    searchPlace();
                    break;
                case ClsParameter.MODULE_JOURNEY:
                    searchJourney();
                    break;
                default:
                    break;
            }
        }

        private void bttAdd_Click(object sender, EventArgs e)
        {
            /*
            * Dungnv   : 11/11/2015
            * Purpose  : Them moi 
            */
            switch (strModule)
            {
                case ClsParameter.MODULE_GROUPUSER:
                    //Nhóm người dùng 
                    frmGroupUser fgroupUser = new frmGroupUser();
                    fgroupUser.strMode = ClsParameter.MODE_ADD;
                    fgroupUser.ShowDialog();
                    break;
                case ClsParameter.MODULE_USER:
                    //Người dùng
                    frmUser fuser = new frmUser();
                    fuser.strMode = ClsParameter.MODE_ADD;
                    fuser.ShowDialog();
                    break;
                case ClsParameter.MODULE_EMP:
                    //Nhân viên

                    frmEmployee fEmployee = new frmEmployee();
                    fEmployee.strMode = ClsParameter.MODE_ADD;
                    fEmployee.ShowDialog();
                    break;
                case ClsParameter.MODULE_JOURNEY:
                    //frmJourney frm = new frmJourney();
                    frmAddJourney frm = new frmAddJourney();
                    frm.strMode = ClsParameter.MODE_ADD;
                    frm.ShowDialog();
                    break;
                case ClsParameter.MODULE_PLACE:
                    frmPlace frmPlace = new frmPlace();
                    frmPlace.strMode = ClsParameter.MODE_ADD;
                    frmPlace.ShowDialog();
                    break;
                case ClsParameter.MODULE_TRUST:
                    frmTrust frmTrust = new frmTrust();
                    frmTrust.strMode = ClsParameter.MODE_ADD;
                    frmTrust.ShowDialog();
                    
                    break;
               
                default:
                    break;
            }

            DoSearch();
        }

        private void bttSearch_Click(object sender, EventArgs e)
        {
            /*
             * Dungnv   : 12/11/2015
             * Purpose  : Tìm kiếm thông tin 
             */
            DoSearch();
        }

        private void gridControlMain_DoubleClick(object sender, EventArgs e)
        {
            /*
             * Dungnv   :   12/11/2015
             * Purpose  :   Xu ly Update 
             */

            //DoUpdate();
            DoView();
        }

        private void DoUpdate()
        {
            if (strCode == "")
            {
                ClsCommonProcess.msgError(ClsParameter.MSG_OBJ_NOT_SELECTED);
                return;
            }

            switch (strModule)
            {
                case ClsParameter.MODULE_GROUPUSER:
                    frmGroupUser fgroupUser = new frmGroupUser();
                    fgroupUser.strMode = ClsParameter.MODE_UPDATE;
                    fgroupUser.strCode = this.strCode;
                    fgroupUser.ShowDialog();
                    txtContent.Text = this.strCode;
                    break;
                case ClsParameter.MODULE_USER:
                    frmUser fuser = new frmUser();
                    fuser.strMode = ClsParameter.MODE_UPDATE;
                    fuser.strCode = this.strCode;
                    fuser.ShowDialog();
                    txtContent.Text = this.strCode;
                    break;

                case ClsParameter.MODULE_EMP:
                    frmEmployee fEmployee = new frmEmployee();
                    fEmployee.strMode = ClsParameter.MODE_UPDATE;
                    fEmployee.strCode = this.strCode;
                    fEmployee.ShowDialog();
                    txtContent.Text = this.strCode;
                    break;
                case ClsParameter.MODULE_TRUST:
                    frmTrust fTrust = new frmTrust();
                    fTrust.strMode = ClsParameter.MODE_UPDATE;
                    fTrust.strCode = this.strCode;
                    fTrust.ShowDialog();
                    txtContent.Text = this.strCode;
                    break;
                case ClsParameter.MODULE_PLACE:
                    frmPlace fPlace = new frmPlace();
                    fPlace.strMode = ClsParameter.MODE_UPDATE;
                    fPlace.strCode = this.strCode;
                    fPlace.ShowDialog();
                    break;
                case ClsParameter.MODULE_JOURNEY:
                    frmAddJourney fJourney = new frmAddJourney();
                    fJourney.strMode = ClsParameter.MODE_UPDATE;
                    fJourney.strCode = this.strCode;
                    fJourney.ShowDialog();
                    break;


                default:
                    break;
            }

            DoSearch();
        }

        private void DoView()
        {
            if (strCode == "")
            {
                ClsCommonProcess.msgError(ClsParameter.MSG_OBJ_NOT_SELECTED);
                return;
            }

            switch (strModule)
            {
                case ClsParameter.MODULE_GROUPUSER:
                    frmGroupUser fgroupUser = new frmGroupUser();
                    fgroupUser.strMode = ClsParameter.MODE_VIEW;
                    fgroupUser.strCode = this.strCode;
                    fgroupUser.ShowDialog();
                    txtContent.Text = this.strCode;
                    break;
                case ClsParameter.MODULE_USER:
                    frmUser fuser = new frmUser();
                    fuser.strMode = ClsParameter.MODE_VIEW;
                    fuser.strCode = this.strCode;
                    fuser.ShowDialog();
                    txtContent.Text = this.strCode;
                    break;

                case ClsParameter.MODULE_EMP:
                    frmEmployee fEmployee = new frmEmployee();
                    fEmployee.strMode = ClsParameter.MODE_VIEW;
                    fEmployee.strCode = this.strCode;
                    fEmployee.ShowDialog();
                    txtContent.Text = this.strCode;
                    break;
               
                case ClsParameter.MODULE_JOURNEY:
                    frmAddJourney fJourney = new frmAddJourney();
                    fJourney.strMode = ClsParameter.MODE_VIEW;
                    fJourney.strCode = this.strCode;
                    fJourney.ShowDialog();
                    break;

             
                default:
                    break;
            }

            DoSearch();
        }

        private void dtgResult_Click(object sender, EventArgs e)
        {
            /*
           * Dungnv   : 12/11/2015
           * Purpose  : Lay CodeID cua thong tin quan ly 
           */
            if (dtgResult != null)
            {
                if (dtgResult.RowCount > 0)
                {
                    switch (strModule)
                    {
                        case ClsParameter.MODULE_GROUPUSER:
                            //Nhóm người dùng
                            this.strCode = dtgResult.GetRowCellValue(dtgResult.FocusedRowHandle, "GROUPID").ToString();
                            break;
                        case ClsParameter.MODULE_USER:
                            //Người dùng
                            this.strCode = dtgResult.GetRowCellValue(dtgResult.FocusedRowHandle, "USERID").ToString();
                            break;
                        case ClsParameter.MODULE_CUST:
                            //Khách hàng
                            this.strCode = dtgResult.GetRowCellValue(dtgResult.FocusedRowHandle, "CustID").ToString();
                            break;

                        case ClsParameter.MODULE_EMP:
                            //Bill
                            this.strCode = dtgResult.GetRowCellValue(dtgResult.FocusedRowHandle, "EmployeeId").ToString();
                            break;

                        case ClsParameter.MODULE_TRUST:
                            //Trust 
                            this.strCode = dtgResult.GetRowCellValue(dtgResult.FocusedRowHandle, "TrustID").ToString();
                            break;
                        case ClsParameter.MODULE_PLACE:
                            
                            this.strCode = dtgResult.GetRowCellValue(dtgResult.FocusedRowHandle, "PlaceID").ToString();

                            break;
                        case ClsParameter.MODULE_JOURNEY:

                            this.strCode = dtgResult.GetRowCellValue(dtgResult.FocusedRowHandle, "JourneyID").ToString();

                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void bttUpdate_Click(object sender, EventArgs e)
        {
            /*
             * dungnv   :   12/11/2015
             * Purpose  :   Update 
             */

            DoUpdate();

        }

        private void bttView_Click(object sender, EventArgs e)
        {
            /*
             * Dungnv   :   18/10/2014
             * Purpose  :   View thong tin 
             */
            if (strCode == "")
            {
                ClsCommonProcess.msgError(ClsParameter.MSG_OBJ_NOT_SELECTED);
                return;
            }

            switch (strModule)
            {
                case ClsParameter.MODULE_GROUPUSER:
                    frmGroupUser fgroupUser = new frmGroupUser();
                    fgroupUser.strMode = ClsParameter.MODE_VIEW;
                    fgroupUser.strCode = this.strCode;
                    fgroupUser.ShowDialog();
                    break;
                case ClsParameter.MODULE_USER:
                    frmUser fuser = new frmUser();
                    fuser.strMode = ClsParameter.MODE_VIEW;
                    fuser.strCode = this.strCode;
                    fuser.ShowDialog();
                    break;

                case ClsParameter.MODULE_EMP:
                    frmEmployee fEmployee = new frmEmployee();
                    fEmployee.strMode = ClsParameter.MODE_VIEW;
                    fEmployee.strCode = this.strCode;
                    fEmployee.ShowDialog();
                    txtContent.Text = this.strCode;
                    break;
                case ClsParameter.MODULE_TRUST:
                    frmTrust fTrust = new frmTrust();
                    fTrust.strMode = ClsParameter.MODE_VIEW;
                    fTrust.strCode = this.strCode;
                    fTrust.ShowDialog();
                    break;
                case ClsParameter.MODULE_PLACE:
                    frmPlace fPlace = new frmPlace();
                    fPlace.strMode = ClsParameter.MODE_VIEW;
                    fPlace.strCode = this.strCode;
                    fPlace.ShowDialog();
                    break;
                case ClsParameter.MODULE_JOURNEY:
                    frmAddJourney fJourney = new frmAddJourney();
                    fJourney.strMode = ClsParameter.MODE_VIEW;
                    fJourney.strCode = this.strCode;
                    fJourney.ShowDialog();
                    break;
                
                default:
                    break;
            }
        }

        private void bttDelete_Click(object sender, EventArgs e)
        {
            /*
             * Dungnv   : 18/10/2014
             * Purpose  : Xóa đối tượng , cần check đối tượng có sử dụng không khi xóa (xử lý ở procedure)
             */

            bool bConfirm = false;
            if (strCode == "")
            {
                ClsCommonProcess.msgError(ClsParameter.MSG_OBJ_NOT_SELECTED);
                return;
            }

            bConfirm = ClsCommonProcess.confirmYesNo(ClsParameter.MSG_YESNO_DELETE);
            if (bConfirm == true)
            {
                switch (strModule)
                {
                    case ClsParameter.MODULE_GROUPUSER:
                        deleteGroupUser(strCode);
                        break;
                    case ClsParameter.MODULE_USER:
                        deleteUser(strCode);
                        break;
                    case ClsParameter.MODULE_EMP:
                        deleteEmp(strCode);
                        break;
                    case ClsParameter.MODULE_TRUST:
                        int itrust=0;
                        Int32.TryParse(strCode,out itrust);
                        deleteTrust(itrust);
                        break;
                    case ClsParameter.MODULE_PLACE:
                        int iPlace = 0;
                        Int32.TryParse(strCode, out iPlace);
                        deletePlace(iPlace);
                        break;
                   
                   
                    default:
                        break;

                }

                DoSearch();
            }
        }

        private void bttLock_Click(object sender, EventArgs e)
        {
            bool bConfirm = false;
            bConfirm = ClsCommonProcess.confirmYesNo(ClsParameter.MSG_YESNO_LOCK);

            if (bConfirm == false)
            {
                //Khong dong y 
                return;
            }

            switch (strModule)
            {
                case ClsParameter.MODULE_USER:
                    if (strCode == "")
                    {
                        ClsCommonProcess.msgError(ClsParameter.MSG_USERS_USERNAME_EMPTY);
                        return;
                    }
                    string userName = dtgResult.GetRowCellValue(dtgResult.FocusedRowHandle, "USERNAME").ToString();
                    bool isLock = Boolean.Parse( dtgResult.GetRowCellValue(dtgResult.FocusedRowHandle, "LOCK").ToString());
                    if(isLock==true)
                    {
                        ClsCommonProcess.msg(ClsParameter.MSG_USERS_LOCK_EXIST);
                        return;
                    }
                    doLockUnLockUser(userName, true);
                    break;
                default:
                    break;

            }
        }
        private void doLockUnLockUser(string userId, bool isLock = true)
        {
            UserObject objUser = new UserObject();
            objUser.USERNAME = userId;
            objUser.MODIFIEDBY = ClsParameter.STRUCT_INFOLOGIN.UserId;
            objUser.LOCK = isLock;

            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();
            try
            {
                if (ws.lookUnlokUser(objUser))
                {
                    if (isLock == true)
                    {
                        ClsCommonProcess.msgError(ClsParameter.MSG_LOCK_USER_SUCESSFULL);
                    }
                    else
                    {
                        ClsCommonProcess.msgError(ClsParameter.MSG_UNLOCK_SUCESSFULL);
                    }

                    DoSearch();
                    return;
                }
                else
                {
                    if (isLock == true)
                    {
                        ClsCommonProcess.msgError(ClsParameter.MSG_LOCK_USER_FAIL);
                    }
                    else
                    {
                        ClsCommonProcess.msgError(ClsParameter.MSG_UNLOCK_USER_FAIL);
                    }

                    ClsCommonProcess.msgError(ClsParameter.MSG_UNLOCK_USER_FAIL);
                    return;
                }
            }
            catch (Exception ex)
            {
                ClsCommonProcess.msgError(ClsParameter.MSG_LOCK_USER_FAIL);
                return;
            }
        }

        private void bttUnlock_Click(object sender, EventArgs e)
        {
            bool bConfirm = false;
            bConfirm = ClsCommonProcess.confirmYesNo(ClsParameter.MSG_YESNO_UNLOCK);

            if (bConfirm == false)
            {
                //Khong dong y 
                return;
            }

            switch (strModule)
            {
                case ClsParameter.MODULE_USER:
                    if (strCode == "")
                    {
                        ClsCommonProcess.msgError(ClsParameter.MSG_USERS_USERNAME_EMPTY);
                        return;
                    }
                    string userName = dtgResult.GetRowCellValue(dtgResult.FocusedRowHandle, "USERNAME").ToString();
                    bool isLock = Boolean.Parse( dtgResult.GetRowCellValue(dtgResult.FocusedRowHandle, "LOCK").ToString());
                    if(isLock==false)
                    {
                        ClsCommonProcess.msg(ClsParameter.MSG_USERS_UNLOCK_EXIST);
                        return;
                    }

                    doLockUnLockUser(userName, false);
                    break;
                default:
                    break;

            }
        }

        private void dtgResult_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            /*
            * Dungnv   :   12/06/2016
            * Purpose  :   Format Number
            */

            try
            {
                if (e.Column.FieldName.ToUpper().Trim() == "PRICE" || e.Column.FieldName.ToUpper().Trim() == "PRICEWITHDISCOUNT" || e.Column.FieldName.ToUpper().Trim() == "PAID")
                {
                    string strNum = "";
                    strNum = e.DisplayText;
                    e.DisplayText = ClsCommonProcess.formartNumber(strNum);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void checkAuthorize()
        {
            /*
             *  dungnv  :   22/06/2016
             *  Purpose :   Chedck Authorize
             */
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();
            bool bAdd = false;
            bool bDel = false;
            bool bUpd = false;
            bool bVie = false;

            ws.checkAuthorizeManage(strModule, ClsParameter.STRUCT_INFOLOGIN.GroupId, ref bAdd, ref bDel, ref bUpd, ref bVie);

            //Add 
            if(bAdd==true)
            {
                bttAdd.Enabled = true;
            }
            else
            {
                bttAdd.Enabled = false;
            }

            //Delete
            if(bDel==true)
            {
                bttDelete.Enabled = true;
            }
            else
            {
                bttDelete.Enabled = false;
            }

            //Update 
            if(bUpd==true)
            {
                bttUpdate.Enabled = true;
            }
            else
            {
                bttUpdate.Enabled = false;
            }

            //View 
            if (bVie == true)
            {
                bttView.Enabled = true;
            }
            else
            {
                bttView.Enabled = false;
            }
        }

        private void bttExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void txtContent_KeyDown(object sender, KeyEventArgs e)
    {
            if( e.KeyCode == Keys.Enter)
            {
                DoSearch();
            }
        }

      
    }
}