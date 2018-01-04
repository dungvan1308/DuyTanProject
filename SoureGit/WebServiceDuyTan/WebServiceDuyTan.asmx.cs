using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using ClassLibraryObjects;
using WebServiceDuyTan.DbObjects;
using System.IO;
using System.Collections;

namespace WebServiceDuyTan
{
    /// <summary>
    /// Summary description for WebServiceGym
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceDuyTan : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }


        #region Xử lý User
        [WebMethod(Description = "Login Users")]
        public bool loginUser(UserObject users, out UserObject outUser)
        {
            /*
             * Dungnv : 14/10/2014
             */
            bool bCheck = false;
            UserDB objUserDb = new UserDB();
            //Out object must assigned
            outUser = null;
            try
            {
                bCheck = objUserDb.loginUser(users, out outUser);
            }
            catch (Exception ex)
            {
                bCheck = false;
            }

            return bCheck;

        }

        [WebMethod(Description = "Insert User")]
        public bool insertUser(UserObject users, out string strOutUserId)
        {
            /*
             *  Dungnv  :   21/10/2014
             *  Purpose :   Insert User
             *  input   :   UserObject
             */
            bool bCheck = false;
            UserDB objDb = new UserDB();
            strOutUserId = "";
            try
            {
                bCheck = objDb.insertUser(users, out strOutUserId);

            }
            catch (Exception ex)
            {
                bCheck = false;
                strOutUserId = "";
            }
            return bCheck;

        }
        [WebMethod(Description = "Login Users")]
        public bool updateUser(UserObject users)
        {
            /*
             * Dungnv   : 22/10/2014
             * Purpose  : Update Thong tin User
             */
            bool bCheck = false;
            UserDB objDb = new UserDB();
            try
            {
                bCheck = objDb.updateUser(users);
            }
            catch (Exception ex)
            {
                bCheck = false;
            }
            return bCheck;
        }

        [WebMethod(Description = "Reset Pass ")]
        public bool resetPass(UserObject users)
        {
            /*
             * Dungnv   : 21/10/2014
             * Purpose  : Reset pass cua user
             */
            bool bCheck = false;
            UserDB objDb = new UserDB();
            try
            {
                bCheck = objDb.resetPass(users);
            }
            catch (Exception ex)
            {
                bCheck = false;
            }

            return bCheck;
        }

        [WebMethod(Description = " Get Object User ")]
        public UserObject selectUser(string strUserId)
        {
            /*
             * Dungnv   :   21/10/2014
             * Purpose  :   Lay thong user
             * input    :   UserId
             */
            UserObject objUser = new UserObject();
            UserDB objDb = new UserDB();
            try
            {
                objUser = objDb.selectUser(strUserId);
            }
            catch (Exception ex)
            {
                objUser = null;
            }
            return objUser;
        }

        [WebMethod(Description = " Get Object User by username")]
        public UserObject selectUserByUserName(string strUserName)
        {
            /*
             * Dungnv   :   21/10/2014
             * Purpose  :   Lay thong user
             * input    :   UserId
             */
            UserObject objUser = new UserObject();
            UserDB objDb = new UserDB();
            try
            {
                objUser = objDb.selectUserByUserName(strUserName);
            }
            catch (Exception ex)
            {
                objUser = null;
            }
            return objUser;
        }

        [WebMethod(Description = " Get list User")]
        public DataSet selectAllUser(string strCondition, string strOrderby)
        {
            /*
             * Dungnv   :   21/10/2014
             * Purpose  :   Lay danh sach User
             */
            DataSet ds = new DataSet();
            UserDB objDb = new UserDB();
            try
            {
                ds = objDb.selectUserDymanic(strCondition, strOrderby);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            return ds;
        }

        [WebMethod(Description = "lock and unlock user")]
        public bool lookUnlokUser(UserObject users)
        {
            /*
             * Dungnv   :   21/10/2014
             * Purpose  :   Lock or Unlock User
             * input    :   UserObject
             */
            bool bCheck = false;
            UserDB objDb = new UserDB();
            try
            {
                bCheck = objDb.lock_unlock_User(users);
            }
            catch (Exception ex)
            {
                bCheck = false;
            }
            return bCheck;
        }

        [WebMethod(Description = "Look up User")]
        public DataSet lookUpUser()
        {
            /*
             * Dungnv : 20/10/2014
             * Lay danh sach User
             */
            DataSet ds = new DataSet();
            UserDB objDb = new UserDB();
            try
            {
                ds = objDb.lookUpUser();
            }
            catch (Exception ex)
            {
                ds = null;
            }

            return ds;
        }

        [WebMethod(Description = "Delete User")]
        public bool deleteUser(string strUserId, out string strResult)
        {
            /*
             *  Dungnv  :   23/10/2014
             *  Xoa User
             */
            bool bResult = false;
            UserDB objDb = new UserDB();
            strResult = "";
            try
            {
                bResult = objDb.deleteUser(strUserId, out strResult);
            }
            catch (Exception ex)
            {
                bResult = false;
            }

            return bResult;
        }

        [WebMethod(Description = "Delete User")]
        public bool logOut(string strUserId)
        {
            UserDB obj = new UserDB();
            try
            {
                return obj.logOut(strUserId);
            }
            catch(Exception ex)
            {
                return false;
            }
        }


        [WebMethod(Description = "check LienceKey")]
        public bool checkLienceKey()
        {
            /*
             * Dungnv   :   03/06/2016
             */
            UserDB objDb = new UserDB();
            try
            {
                return objDb.checkLienceKey();
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Xử lý nhóm người dùng GroupUser
        [WebMethod(Description = "Insert Group User")]
        public bool insertGroupUser(GroupUserObject groupUser, out string strOutGroupId)
        {
            /*
             * Dungnv   :   18/10/2014
             * Purpose  :   Them moi nhom nguoi dung 
             * Output   :   Ma nguoi dung 
             */
            bool bResutl = false;
            GroupUserDB objGroupDb = new GroupUserDB();
            strOutGroupId = "";
            try
            {
                bResutl = objGroupDb.insertGroupUseṛ(groupUser, out strOutGroupId);
            }
            catch (Exception ex)
            {
                bResutl = false;
            }

            return bResutl;
        }

        [WebMethod(Description = "Select GroupUser Dynamic")]
        public DataSet selectGroupUserDymanic(string strCondition, string strOrderBy)
        {
            /*
             * Dungnv   : 14/10/2014
             * Purpose  : Lay Thong Tin  
             */
            GroupUserDB objGroup = new GroupUserDB();
            DataSet ds = new DataSet();
            try
            {
                ds = objGroup.selectGroupUserDymanic(strCondition, strOrderBy);
            }
            catch (Exception ex)
            {
                ds = null;
            }

            return ds;

        }

        [WebMethod(Description = "Select Group User")]
        public GroupUserObject selectGroupUser(string strGroupUserID)
        {
            /*
             * Dungnv   : 14/10/2014
             * Purpose  : Lay Thong Tin nhóm người dùng 
             */
            GroupUserDB objDb = new GroupUserDB();
            GroupUserObject objGroup = new GroupUserObject();
            try
            {
                objGroup = objDb.selectGroupUser(strGroupUserID);
            }
            catch (Exception ex)
            {
                objGroup = null;
            }

            return objGroup;
        }

        [WebMethod(Description = "Select Group User By Name")]
        public GroupUserObject selectGroupUserByName(string strGroupName)
        {
            /*
             * Dungnv   : 14/10/2014
             * Purpose  : Lay Thong Tin nhóm người dùng 
             */
            GroupUserDB objDb = new GroupUserDB();
            GroupUserObject objGroup = new GroupUserObject();
            try
            {
                objGroup = objDb.selectGroupUserByName(strGroupName);
            }
            catch (Exception ex)
            {
                objGroup = null;
            }

            return objGroup;
        }

        [WebMethod(Description = "update GroupUser")]
        public bool updateGroupUser(GroupUserObject groupUsers)
        {
            /*
             * Dungnv   : 14/10/2014
             * Purpose  : Dungnv 
             */
            bool bResult = false;
            GroupUserDB objDb = new GroupUserDB();
            try
            {
                bResult = objDb.updateGroupUser(groupUsers);
            }
            catch (Exception ex)
            {
                bResult = false;
            }
            return bResult;
        }

        [WebMethod(Description = "Delete GroupUser ")]
        public bool deleteGroupUser(string strGroupUserId, out string strResult)
        {
            /*
             * Dungnv : 15/10/2014
             * Purpose: Xoa Group User 
             */
            bool bResult = false;
            GroupUserDB objDB = new GroupUserDB();
            strResult = "";
            try
            {
                bResult = objDB.deleteGroupUser(strGroupUserId, out strResult);
            }
            catch (Exception ex)
            {
                bResult = false;
            }

            return bResult;

        }

        [WebMethod(Description = "Select all group User ")]
        public DataSet lookUpGroupUser()
        {
            /*
             * Dungnv   :   22/10/2014
             * Purpose  :   Lay all group User (load LockupEdit)
             */
            DataSet ds = new DataSet();
            GroupUserDB objDB = new GroupUserDB();
            try
            {
                ds = objDB.lookUpGroupUser();
            }
            catch (Exception ex)
            {
                ds = null;
            }

            return ds;

        }
        #endregion

        #region Nhân viên
        [WebMethod(Description = "Select  Employee ")]
        public EmployeeObject selectEmployee(int Id)
        {
            EmployeeObject obj = new EmployeeObject();
            EmployeeDB objDb = new EmployeeDB();
            try
            {
                obj = objDb.selectEmployee(Id);
            }
            catch (Exception ex)
            {
                obj = null;
            }
            return obj;
        }

        [WebMethod(Description = " Get list Employee")]
        public DataSet selectAllEmployee(string strCondition, string strOrderby)
        {
            /*
             * Dungnv   :   21/10/2014
             * Purpose  :   Lay danh sach nhân viên
             */
            DataSet ds = new DataSet();
            EmployeeDB objDb = new EmployeeDB();
            try
            {
                ds = objDb.selectEmployeeDymanic(strCondition, strOrderby);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            return ds;
        }

        [WebMethod(Description = "Delete Employee")]
        public bool deleteEmployee(string strEmployeeId, out string strResult)
        {
            bool bResult = false;
            EmployeeDB objDb = new EmployeeDB();
            strResult = "";
            try
            {
                bResult = objDb.deleteEmployee(strEmployeeId, out strResult);
            }
            catch (Exception ex)
            {
                bResult = false;
            }

            return bResult;
        }

        [WebMethod(Description = "Insert Update Employee ")]
        public bool insertUpdateEmployee(EmployeeObject objEmp, out string strEmployeeId)
        {
            /*
             *  Dungnv  :   24/10/2014
             *  Purpose :   Insert Update
             */
            bool bCheck = false;
            EmployeeDB objEmployee = new EmployeeDB();
            strEmployeeId = "";
            try
            {
                bCheck = objEmployee.insertUpdateEmployee(objEmp);

            }
            catch (Exception ex)
            {
                bCheck = false;
                strEmployeeId = "";
            }
            return bCheck;
        }

      

   
        #endregion 

        #region Menu and Authorise Menu
        [WebMethod(Description = "get All Menu Items")]
        public MenuObjectList selectAllMenuItem()
        {
            MenuDB menuDB = new MenuDB();
            MenuObjectList objLst = new MenuObjectList();
            try
            {
                objLst = menuDB.selectAllMenuItem();
            }
            catch (Exception ex)
            {
                objLst = null;
            }
            return objLst;
        }

        [WebMethod(Description = "Update AuthorizeMenu")]
        public bool updateAuthorizeMenu(AuthorizeMenuObjectList authorizeMenuList)
        {
            MenuDB menuDB = new MenuDB();
            return menuDB.updateAuthorizeMenu(authorizeMenuList);
        }

        [WebMethod(Description = "get Authorize Menu items")]
        public AuthorizeMenuObjectList getAuthorizeMenus(string userGroupId)
        {
            MenuDB menuDB = new MenuDB();
            return menuDB.getAuthorizeMenus(userGroupId);
        }

        [WebMethod(Description = "select Menu Object")]
        public MenuObject selectMenuObject()
        {
            MenuObject obj = new MenuObject();
            return obj;
        }

        [WebMethod(Description = "check Authorize Manage")]
        public void checkAuthorizeManage(string strModule, string strGroupID,ref bool bAdd,ref bool bDel,ref bool bUpd, ref bool bVie)
        {
            /*
             * Dungnv   :   22/06/2016
             * Purpose  :   check Authorize form manage commond
             */
            MenuDB obj = new MenuDB();
            obj.checkAuthorizeManage(strModule, strGroupID, ref bAdd, ref bDel, ref bUpd, ref bVie);
        }

        #endregion

        #region Report
        [WebMethod(Description = "select List Report ")]
        public DataSet selectListReport(string strModule)
        {
            /*
             * Dungnv    :   01/01/2014
             * Purpose   :   Lay danh sach Report 
             */

            CommomDB obj = new CommomDB();
            DataSet ds = new DataSet();
            try
            {
                ds = obj.selectListReport(strModule);
            }
            catch (Exception ex)
            {
                ds = null;
            }

            return ds;

        }

        [WebMethod(Description = "ExcecProcedure to Array ")]
        public ReportObjects ExecProcedureToArr(string strProcedureName)
        {
            /*
             * Dungnv   :   02/01/2014
             * Purpose  :   Lay danh sach tham so tu Procudure 
             */

            CommomDB obj = new CommomDB();
            ReportObjects objReport = new ReportObjects();
            try
            {
                objReport = obj.ExecProcedureToArr(strProcedureName);
            }
            catch (Exception ex)
            {
                objReport = null;
            }

            return objReport;

        }

        [WebMethod(Description = "Select Report Para ")]
        public ReportParaObject selectReportPara()
        {
            ReportParaObject obj = new ReportParaObject();
            return obj;
        }

        [WebMethod(Description = "Select Report Data")]
        public DataSet selectReportDatas(ReportObjects reportObjects, string procedureName)
        {
            ReportDB reportDB = new ReportDB();
            return reportDB.selectReportDatas(reportObjects, procedureName);
        }

        [WebMethod(Description = "get info company ")]
        public DataSet get_info_company()
        {
            CommomDB objDb = new CommomDB();
            return objDb.get_info_company();
        }



        [WebMethod(Description = "select Salary Object")]
        public SalaryObject selectSalaryObject()
        {
            SalaryObject obj = new SalaryObject();
            return obj;
        }

        
      
        #endregion 

        #region Xử lý chung
        [WebMethod(Description = "Select AllCode")]
        public DataSet SelecAllCodeDynamic(string strFieldName, string strTableName)
        {
            /*
             *  Dungnv  :   Lay thong tin bang AllCode 
             */

            CommomDB objDB = new CommomDB();
            DataSet ds = new DataSet();
            try
            {
                ds = objDB.SelecAllCodeDynamic(strFieldName, strTableName);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            return ds;

        }
        [WebMethod(Description = "Select City")]
        public DataSet SelectCiTyDynamic(string strCondition, string strOrderBy)
        {
            /*
             *  Dungnv  :   26/10/2014
             *  Purpose :   Lay thong tin City 
             */
            CommomDB objDB = new CommomDB();
            DataSet ds = new DataSet();
            try
            {
                ds = objDB.SelectCiTyDynamic(strCondition, strOrderBy);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            return ds;
        }

        [WebMethod(Description = "Select District ")]
        public DataSet SelectDistrictDynamic(string strCondition, string strOrderBy)
        {
            /*
             *  Dungnv  :   26/10/2014
             *  Purpose :   Lay thong tin City 
             */
            CommomDB objDB = new CommomDB();
            DataSet ds = new DataSet();
            try
            {
                ds = objDB.SelectDistrictDynamic(strCondition, strOrderBy);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            return ds;
        }

        [WebMethod(Description = "Select Ward ")]
        public DataSet SelectWardDynamic(string strCondition, string strOrderBy)
        {
            /*
             *  Dungnv  :   26/10/2014
             *  Purpose :   Lay thong tin City 
             */
            CommomDB objDB = new CommomDB();
            DataSet ds = new DataSet();
            try
            {
                ds = objDB.SelectWardDynamic(strCondition, strOrderBy);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            return ds;
        }

        [WebMethod(Description = "Select Countries ")]
        public DataSet SelectCountriesDynamic(string strCondition, string strOrderBy)
        {
            /*
             *  Dungnv  :   26/10/2014
             *  Purpose :   Lay thong tin City 
             */
            CommomDB objDB = new CommomDB();
            DataSet ds = new DataSet();
            try
            {
                ds = objDB.SelectCountriesDynamic(strCondition, strOrderBy);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            return ds;
        }

        [WebMethod(Description = "Select Measurement ")]
        public DataSet SelectMeasurement(string RowId)
        {
            /*
             *  NamHP  :   09/05/2016
             *  Purpose :  Lay thong tin Measurement 
             */
            CommomDB objDB = new CommomDB();
            DataSet ds = new DataSet();
            try
            {
                ds = objDB.SelectMeasurement(RowId);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            return ds;
        }

        [WebMethod(Description = "Select Measurements ")]
        public DataSet SelectMeasurementsDynamic(string strCondition, string strOrderBy)
        {
            /*
             *  NamHP  :   09/05/2016
             *  Purpose :  Lay thong tin Measurement 
             */
            CommomDB objDB = new CommomDB();
            DataSet ds = new DataSet();
            try
            {
                ds = objDB.SelectMeasurementsDynamic(strCondition, strOrderBy);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            return ds;
        }

        [WebMethod(Description = "Select Reservation ")]
        public DataSet SelectReservation(string RowId)
        {
            /*
             *  NamHP  :   09/05/2016
             *  Purpose :  Lay thong tin Reservation 
             */
            CommomDB objDB = new CommomDB();
            DataSet ds = new DataSet();
            try
            {
                ds = objDB.SelectReservation(RowId);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            return ds;
        }

        [WebMethod(Description = "Select Reservation ")]
        public DataSet SelectReservationsDynamic(string strCondition, string strOrderBy)
        {
            /*
             *  NamHP  :   09/05/2016
             *  Purpose :  Lay thong tin Reservation 
             */
            CommomDB objDB = new CommomDB();
            DataSet ds = new DataSet();
            try
            {
                ds = objDB.SelectReservationsDynamic(strCondition, strOrderBy);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            return ds;
        }

        [WebMethod(Description = "Select Resoure ")]
        public DataSet SelectResoure(string RowId)
        {
            /*
             *  NamHP  :   09/05/2016
             *  Purpose :  Lay thong tin Resoure 
             */
            CommomDB objDB = new CommomDB();
            DataSet ds = new DataSet();
            try
            {
                ds = objDB.SelectResoure(RowId);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            return ds;
        }

        [WebMethod(Description = "Select Resoure ")]
        public DataSet SelectResouresDynamic(string strCondition, string strOrderBy)
        {
            /*
             *  NamHP  :   09/05/2016
             *  Purpose :  Lay thong tin Resoure 
             */
            CommomDB objDB = new CommomDB();
            DataSet ds = new DataSet();
            try
            {
                ds = objDB.SelectResouresDynamic(strCondition, strOrderBy);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            return ds;
        }

        [WebMethod(Description = "Select By sql ")]
        public DataSet SelectBySql(string strSql)
        {
            /*
             *  Dungnv  :   30/10/2014
             *  Purpose :   Lay DataSet by Sql
             */
            DataSet ds = new DataSet();
            CommomDB objDb = new CommomDB();
            ds = null;
            try
            {
                ds = objDb.SelectBySql(strSql);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            return ds;
        }

        [WebMethod(Description = "Select Current Login ")]
        public DataSet SelectCurrentLogin()
        {
            /*
             * Dungnv   :   20/05/2016
             * Purpose  :   Lay danh sach Cac Userlogin 
             */
            CommomDB objDb = new CommomDB();
            try
            {
                return objDb.SelectCurrentLogin();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [WebMethod(Description = "Select list LoginAll ")]
        public DataSet listUserLogIn(DateTime frdate, DateTime todate)
        {
            /*
             * Dungnv   :   20/05/2016
             * Purpose  :   Lay danh sach Cac Userlogin 
             */
            CommomDB objDb = new CommomDB();
            try
            {
                return objDb.listUserLogIn(frdate,todate);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
      

        #endregion 


        #region backup and restore 
        
        [WebMethod(Description = "getListFileBk")]
        public string[] getListFileBk()
        {
            CommomDB obj = new CommomDB();
            try
            {
                return obj.getListFileBk();
            }
            catch
            {
                return null;
            }
        }

   [WebMethod(Description = "get List File Info")]
        
   public ArrayList getListFileInfo()
   {
       /*
        * Dungnv    :   11/06/2016
        * Purpose   :   Lay danh sach file 
        */
 
       CommomDB obj = new CommomDB();
       try
       {
           return obj.getListFileInfo();
       }
       catch
       {
           return null;
       }
   }

   [WebMethod(Description = "select FileObject")]
    public FileObject selectFileObject()
   {
       FileObject obj = new FileObject();
       return obj;
   }

   [WebMethod(Description = "backupData")]
   public   bool  backupData ()
   {
        /*
         * Dungnv   :   11/06/2016
         * Purpose  :   Backup du lieu
         */
 
       CommomDB objDb = new CommomDB();
        try
        {
            return objDb.backupData();
        }
        catch(Exception ex)
        {
            return false;
        }
   }

    [WebMethod(Description = "restoreData")]
   public bool restoreData(string strFileName)
   {
        /*
         * Dungnv   :   11/06/2016
         * Purpose  :   Backup du lieu
         */
 
       CommomDB objDb = new CommomDB();
        try
        {
            return objDb.restoreData(strFileName);
        }
        catch(Exception ex)
        {
            return false;
        }
   }

        

        #endregion 




        #region Trust 

        [WebMethod(Description = "insertUpdate Trust")]
        public bool insertUpdateTrust(TrustObject obj)
    {
            bool bCheck = false;
            TrustDB objDB = new TrustDB();
         
            try
            {
                bCheck = objDB.insertUpdateTrust(obj);

            }
            catch (Exception ex)
            {
                bCheck = false;
                
            }
            return bCheck;
    }

        [WebMethod(Description = " Get list Trust")]
        public DataSet selectAllTrust(string strCondition, string strOrderby)
        {
            /*
             * Dungnv   :   05.11.2017
             * Purpose  :   Lay danh sach xe 
             */
            DataSet ds = new DataSet();
            TrustDB objDb = new TrustDB();
            try
            {
                ds = objDb.selectTrustsDynamic(strCondition, strOrderby);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            return ds;
        }


        [WebMethod(Description = " Get Trust")]
        public TrustObject selectTrust(int Id)
        {
            /*
             * Dungnv   :   05.11.2017
             * Purpose  :   Get Trust 
             */
            TrustObject obj = new TrustObject();
            TrustDB objDb = new TrustDB();
            try
            {
                obj = objDb.selectTrust(Id);
            }
            catch (Exception ex)
            {
                obj = null;
            }
            return obj;
        }

        [WebMethod(Description = "Delete Trust")]
        public bool deleteTrust(int iTrust, out string strResult)
        {
            bool bResult = false;
            TrustDB objDb = new TrustDB();
            strResult = "";
            try
            {
                bResult = objDb.deleteTrust(iTrust, out strResult);
            }
            catch (Exception ex)
            {
                bResult = false;
            }

            return bResult;
        }


        #endregion 
        #region Place
        [WebMethod(Description = "insertUpdate Place")]
        public bool insertUpdatePlace(PlaceObject obj)
        {
            bool bCheck = false;
            PlaceDB objDB = new PlaceDB();

            try
            {
                bCheck = objDB.insertUpdatePlace(obj);

            }
            catch (Exception ex)
            {
                bCheck = false;

            }
            return bCheck;
        }

        

        
        [WebMethod(Description = " Get list Palce")]
        public DataSet selectAllPlace(string strCondition, string strOrderby)
        {
            /*
             * Dungnv   :   05.11.2017
             * Purpose  :   Lay danh sach xe 
             */
            DataSet ds = new DataSet();
            PlaceDB objDb = new PlaceDB();
            try
            {
                ds = objDb.selectPlacesDynamic(strCondition, strOrderby);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            return ds;
        }

         [WebMethod(Description = " select Place")]
        public PlaceObject selectPlace(int Id)
        {
            /*
             * Dungnv   :   05.11.2017
             * Purpose  :   Get Trust 
             */
            PlaceObject obj = new PlaceObject();
            PlaceDB objDb = new PlaceDB();
            try
            {
                obj = objDb.selectPlace(Id);
            }
            catch (Exception ex)
            {
                obj = null;
            }
            return obj;
        }
         [WebMethod(Description = "Delete Place")]
         public bool deletePlace(int iPlaceId, out string strResult)
         {
             bool bResult = false;
             PlaceDB objDb = new PlaceDB();
             strResult = "";
             try
             {
                 bResult = objDb.deletePlace(iPlaceId, out strResult);
             }
             catch (Exception ex)
             {
                 bResult = false;
             }

             return bResult;
         }

        #endregion 

        #region Journey 
         [WebMethod(Description = "insertUpdate Journey")]
         public bool insertUpdateJourney(JourneyObject obj)
         {
             bool bCheck = false;
             JourneyDB objDB = new JourneyDB();

             try
             {
                 bCheck = objDB.insertUpdateJourney(obj);

             }
             catch (Exception ex)
             {
                 bCheck = false;

             }
             return bCheck;
         }

         [WebMethod(Description = " Select Journey")]
         public JourneyObject selectJourney(int iID)
         {
             /*
              * Dungnv   :   05.11.2017
              * Purpose  :   Lay danh sach xe 
              */
             JourneyObject obj = new JourneyObject();
             JourneyDB objDb = new JourneyDB();
             try
             {
                 obj = objDb.selectJourney(iID);
             }
             catch (Exception ex)
             {
                 obj = null;
             }
             return obj;
         }

         [WebMethod(Description = "Delete Journey")]
         public bool deleteJourney(int iJourney, out string strResult)
         {
             bool bResult = false;
             JourneyDB objDb = new JourneyDB();
             strResult = "";
             try
             {
                 bResult = objDb.deleteJourney(iJourney, out strResult);
             }
             catch (Exception ex)
             {
                 bResult = false;
             }

             return bResult;
         }

         [WebMethod(Description = " Get list Journey")]
         public DataSet selectAllJourney(string strCondition, string strOrderby)
         {
             /*
              * Dungnv   :   05.11.2017
              * Purpose  :   Lay danh sach xe 
              */
             DataSet ds = new DataSet();
             JourneyDB objDb = new JourneyDB();
             try
             {
                 ds = objDb.selectJourneyDynamic(strCondition, strOrderby);
             }
             catch (Exception ex)
             {
                 ds = null;
             }
             return ds;
         }

         [WebMethod(Description = " Get Current Journey")]
         public DataSet selectAllCurrentJourney()
         {
             /*
              * Dungnv   :   05.11.2017
              * Purpose  :   Lay danh sach xe 
              */
             DataSet ds = new DataSet();
             JourneyDB objDb = new JourneyDB();
             try
             {
                 ds = objDb.selectAllCurrentJourney();
             }
             catch (Exception ex)
             {
                 ds = null;
             }
             return ds;
         }


         [WebMethod(Description = " Get selectInformationAtTrustStore")]
         public DataSet selectInformationAtTrustStore()
         {
             /*
              * Dungnv   :   05.11.2017
              * Purpose  :   Lay thong tin xe tai kho
              */
             DataSet ds = new DataSet();
             JourneyDB objDb = new JourneyDB();
             try
             {
                 ds = objDb.selectInformationAtTrustStore();
             }
             catch (Exception ex)
             {
                 ds = null;
             }
             return ds;
         }

         [WebMethod(Description = " Get selectInformationAtTrustStore")]
         public DataSet selectInformationAtTrustGroup()
         {
             /*
              * Dungnv   :   05.11.2017
              * Purpose  :   Lay thong tin đội xe
              */
             DataSet ds = new DataSet();
             JourneyDB objDb = new JourneyDB();
             try
             {
                 ds = objDb.selectInformationAtTrustGroup();
             }
             catch (Exception ex)
             {
                 ds = null;
             }
             return ds;
         }

        
        #endregion 
    }
}
