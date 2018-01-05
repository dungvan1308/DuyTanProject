using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections;
using System.Management;
using System.Security.Cryptography;
using System.Data;
using DevExpress;
using GYM.frm;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils.Win;
using GYM.ServiceReferenceDuyTan;
using DevExpress.XtraEditors.Repository;
using GYM.Common;

namespace GYM.Common
{
    public class ClsCommonProcess
    {
        //Dungnv : 18/10/2014
        //Dọc số 
        private static string[] ChuSo = new string[10] { " không", " một", " hai", " ba", " bốn", " năm", " sáu", " bẩy", " tám", " chín" };
        private static string[] Tien = new string[6] { "", " nghìn", " triệu", " tỷ", " nghìn tỷ", " triệu tỷ" };


        //Khai bao su dung thu vien ham API 
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
        private static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

        #region Mã Hóa Dữ Liệu
        public static string EncryptData(string Data)
        {
            try
            {
                byte[] PP = Encoding.Unicode.GetBytes("NhanVanBookstore");
                byte[] DataByte = Encoding.Unicode.GetBytes(Data);
                HashAlgorithm HashPassword = HashAlgorithm.Create("MD5");
                byte[] V = new byte[0x10];
                RijndaelManaged EncryptData = new RijndaelManaged();
                EncryptData.Key = HashPassword.ComputeHash(PP);
                ICryptoTransform encryptor = EncryptData.CreateEncryptor(EncryptData.Key, V);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write);
                cs.Write(DataByte, 0, DataByte.Length);
                cs.FlushFinalBlock();
                byte[] Result = ms.ToArray();
                ms.Close();
                cs.Close();
                EncryptData.Clear();
                return Convert.ToBase64String(Result);
            }
            catch
            {
                return "";
            }
        }
        public static string DecryptData(string Data)
        {
            try
            {
                byte[] PP = Encoding.Unicode.GetBytes("KaraokeManagement");
                byte[] DataEncryptedByte = Convert.FromBase64String(Data);
                HashAlgorithm HashPassword = HashAlgorithm.Create("MD5");
                byte[] V = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                RijndaelManaged Decrypt = new RijndaelManaged();
                Decrypt.Key = HashPassword.ComputeHash(PP);
                ICryptoTransform decryptor = Decrypt.CreateDecryptor(Decrypt.Key, V);
                MemoryStream ms = new MemoryStream(DataEncryptedByte);
                CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
                byte[] Result = new byte[DataEncryptedByte.Length];
                cs.Read(Result, 0, Result.Length);
                ms.Close();
                cs.Close();
                return Encoding.Unicode.GetString(Result).Replace("\0", "");
            }
            catch
            {
                return "";
            }
        }
        #endregion

        public static bool isDate(string strDate)
        {
            /*
             * Dungnv : 05/03/2011
             * Check Validate Date Type 
             */
            DateTime dt = new DateTime();
            try
            {
                dt = DateTime.Parse(strDate);
                return true;
            }
            catch (FormatException e)
            {
                //Format Date invalid    
                return false;
            }

        }

        public static DateTime convertStringToDate(string date)
        {
            try
            {
                
                return DateTime.Parse(date);
            }
            catch (Exception e)
            {
                return DateTime.Parse("01/01/1970");
            }
        }
        public static string formartNumber(string strNumber)
        {
            string str = "";
            try
            {
                str = String.Format("{0:0,0}", Decimal.Parse(strNumber));
            }
            catch (Exception ex)
            {
                str = "0";
            }

            return str;
        }
        public static string convertDateTimeToString(DateTime dateTime)
        {
            return dateTime.ToString(ClsParameter.SYSTEM_DATE_FORMAT);
        }

        public static string convertDateTimeToString(DateTime dateTime, string dateFormat)
        {
            return dateTime.ToString(dateFormat);
        }

        public static bool isCorrectPhoneNumber(string phoneNumber)
        {
            if (phoneNumber == "")
            {
                return true;
            }
            try
            {
                long number = 0;
                bool isCorrect = long.TryParse(phoneNumber, out number);
                if (isCorrect && phoneNumber.Length <= 12)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {

            }
            return false;
        }

        public static bool isCorrectEmail(string email)
        {
            if (email == String.Empty)
            {
                return true;
            }
            try
            {

            }
            catch (Exception e)
            {

            }
            return true;
        }
        public static bool isNumber(string strNum)
        {
            /*
             * @author  :   Dungnv
             * @date    :   20/03/2011
             * @intput  :   strNum : kiểu dữ liệu là số cần kiểm tra
             * @output  :   true : Kiểu số, False ko phải kiểu số
             */
            int iNum = 0;
            try
            {
                iNum = int.Parse(strNum);
                return true;
            }
            catch (FormatException ex)
            {
                //Dinh dang khong dung 
                return false;
            }
        }
        public static bool isFloat(string strNum)
        {
            /*
             * @author  :   Dungnv
             * @date    :   20/03/2011
             * @intput  :   strNum : kiểu dữ liệu là số cần kiểm tra
             * @output  :   true : Kiểu số, False ko phải kiểu số
             */
            float iNum = 0;
            try
            {
                iNum = float.Parse(strNum);
                return true;
            }
            catch (FormatException ex)
            {
                //Dinh dang khong dung 
                return false;
            }
        }
        public static bool isDouble(string strNum)
        {
            /*
             * @author  :   Dungnv
             * @date    :   20/03/2011
             * @intput  :   strNum : kiểu dữ liệu là số cần kiểm tra
             * @output  :   true : Kiểu số, False ko phải kiểu số
             */
            Double iNum = 0;
            try
            {
                iNum = Double.Parse(strNum);
                return true;
            }
            catch (FormatException ex)
            {
                //Dinh dang khong dung 
                return false;
            }
        }
        #region convert byte[] to image và ngược lại
        public static byte[] GetArrayFromFile(string filename)
        {
            /*
             * @author      :   datnguyen
             * @date        :   26/3/2011
             * @purpose     :   convert image file to byte stream
             * */

            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Read);
            byte[] matriz = new byte[fs.Length];
            fs.Read(matriz, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();

            return matriz;
        }

        public static void GetFileFromArray(byte[] matriz, string FileName)
        {
            /*
             * @author      :   datnguyen
             * @date        :   26/3/2011
             * @purpose     :   convert byte stream to Image
             * */

            FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
            fs.Write(matriz, 0, matriz.Length);
            fs.Flush();
            fs.Close();
        }
        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            //Chuyen kieu Image sang kieu Byte de luu vao database 
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        #endregion

        public static void msgError(string strMsg)
        {
            /*
             * @author  :   Dungnv
             * @date    :   18/10/2014
             * @intput  :   strMsg : Câu Thông Báo
             * @output  :   Câu thông báo 
             */

            frmFail frm = new frmFail();
            frm.labMsg.Text = strMsg;
            frm.ShowDialog();
            //frm.Show();
        }
        public static void msg(string strMsg)
        {
            /*
             * @author  :   Dungnv
             * @date    :   18/10/2014
             * @intput  :   strMsg : Câu Thông Báo
             * @output  :   Câu thông báo 
             */

            frmSuccess frm = new frmSuccess();
            frm.labMsg.Text = strMsg;
            frm.ShowDialog();
        }
        #region Xử lý Search Control
        public static bool confirmYesNo(string strMsg)
        {
            /*
             * Dungnv   : 02/05/2014 
             * Purpose  : Hoi confirm before process 
             */
            bool bConfirm = false;
            frmYesNo frmConfirm = new frmYesNo();
            frmConfirm.labMsg.Text = strMsg;
            frmConfirm.ShowDialog();
            bConfirm = frmConfirm.isYes;
            return bConfirm;
        }

        #region SearchLookUpEdit 
        public static void lookUpUser(SearchLookUpEdit lookupUserName)
        {
            /*
             * Dungnv   :   20/10/2014
             * Purpose  :   Load danh sach user
             */
            DataSet ds = new DataSet();
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();


            lookupUserName.Properties.DisplayMember = "USERNAME";
            lookupUserName.Properties.ValueMember = "USERNAME";

            //Add butt Delete
            EditorButton delteButton = new EditorButton();
            delteButton = new EditorButton(ButtonPredefines.Delete);
            lookupUserName.Properties.Buttons.Add(delteButton);

            //lookupUserName.Text = " Nhập người dùng ";


            try
            {
                ds = ws.lookUpUser();

                //Clear Column 
                lookupUserName.Properties.View.Columns.Clear();
                lookupUserName.Properties.View.Columns.AddVisible("USERNAME", "Tên đăng nhập");
                lookupUserName.Properties.View.Columns.AddVisible("FULLNAME", "Họ tên ");

                lookupUserName.Properties.View.Columns[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                lookupUserName.Properties.View.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            catch (Exception ex)
            {
                ds = null;
            }

            if (ds != null)
            {
                if (ds.Tables[0] != null)
                {
                    lookupUserName.Properties.DataSource = ds.Tables[0];

                }
            }
        }
        public static void lookUpGroupUser(SearchLookUpEdit lookGroupUser)
        {
            /*
             * Dungnv   :   20/10/2014
             * Purpose  :   Load danh sach GroupUser 
             */
            DataSet ds = new DataSet();
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();


            lookGroupUser.Properties.DisplayMember = "GROUPNAME";
            lookGroupUser.Properties.ValueMember = "GROUPID";

            //Add butt Delete
            EditorButton delteButton = new EditorButton();
            delteButton = new EditorButton(ButtonPredefines.Delete);
            lookGroupUser.Properties.Buttons.Add(delteButton);

            //lookupUserName.Text = " Nhập người dùng ";


            try
            {
                ds = ws.lookUpGroupUser();

                //Clear Column 
                lookGroupUser.Properties.View.Columns.Clear();
                lookGroupUser.Properties.View.Columns.AddVisible("GROUPID", "Mã nhóm người dùng");
                lookGroupUser.Properties.View.Columns.AddVisible("GROUPNAME", "Tên nhóm người dùng");

                lookGroupUser.Properties.View.Columns[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                lookGroupUser.Properties.View.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            catch (Exception ex)
            {
                ds = null;
            }

            if (ds != null)
            {
                if (ds.Tables[0] != null)
                {
                    lookGroupUser.Properties.DataSource = ds.Tables[0];

                }
            }
        }
        public static void lookUpCountry(SearchLookUpEdit lookUpCountry)
        {
            /*
             * Dungnv   :   20/10/2014
             * Purpose  :   Load danh sach City 
             */
            DataSet ds = new DataSet();
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();


            lookUpCountry.Properties.DisplayMember = "CountryName";
            lookUpCountry.Properties.ValueMember = "CountryID";

            //Add butt Delete
            EditorButton delteButton = new EditorButton();
            delteButton = new EditorButton(ButtonPredefines.Delete);
            lookUpCountry.Properties.Buttons.Clear();
            lookUpCountry.Properties.Buttons.Add(delteButton);

            //lookupUserName.Text = " Nhập người dùng ";


            try
            {
                ds = ws.SelectCountriesDynamic("", "");

                //Clear Column 
                lookUpCountry.Properties.View.Columns.Clear();
                lookUpCountry.Properties.View.Columns.AddVisible("CountryID", "Mã quốc gia");
                lookUpCountry.Properties.View.Columns.AddVisible("CountryName", "Quốc Gia");

                lookUpCountry.Properties.View.Columns[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                lookUpCountry.Properties.View.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            catch (Exception ex)
            {
                ds = null;
            }

            if (ds != null)
            {
                if (ds.Tables[0] != null)
                {
                    lookUpCountry.Properties.DataSource = ds.Tables[0];

                }
            }
        }
        public static void lookUpCity(SearchLookUpEdit lookUpCiTy)
        {
            /*
             * Dungnv   :   20/10/2014
             * Purpose  :   Load danh sach City 
             */
            DataSet ds = new DataSet();
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();


            lookUpCiTy.Properties.DisplayMember = "CityName";
            lookUpCiTy.Properties.ValueMember = "CityId";

            //Add butt Delete
            EditorButton delteButton = new EditorButton();
            delteButton = new EditorButton(ButtonPredefines.Delete);
            lookUpCiTy.Properties.Buttons.Clear();
            lookUpCiTy.Properties.Buttons.Add(delteButton);

            //lookupUserName.Text = " Nhập người dùng ";


            try
            {
                ds = ws.SelectCiTyDynamic("", "");

                //Clear Column 
                lookUpCiTy.Properties.View.Columns.Clear();
                lookUpCiTy.Properties.View.Columns.AddVisible("CityId", "Mã tỉnh");
                lookUpCiTy.Properties.View.Columns.AddVisible("CityName", "Tỉnh - Thành phố");

                lookUpCiTy.Properties.View.Columns[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                lookUpCiTy.Properties.View.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            catch (Exception ex)
            {
                ds = null;
            }

            if (ds != null)
            {
                if (ds.Tables[0] != null)
                {
                    lookUpCiTy.Properties.DataSource = ds.Tables[0];
                    lookUpCiTy.Text = "Chọn thành phố ";

                }
            }
        }
        public static void lookUpDistrict(SearchLookUpEdit lookUpDistrict,string strCityId)
        {
            /*
             * Dungnv   :   20/10/2014
             * Purpose  :   Load danh sach City 
             */
            DataSet ds = new DataSet();
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();


            lookUpDistrict.Properties.DisplayMember = "DistrictName";
            lookUpDistrict.Properties.ValueMember = "DistrictId";

            //Add butt Delete
            EditorButton delteButton = new EditorButton();
            delteButton = new EditorButton(ButtonPredefines.Delete);
            lookUpDistrict.Properties.Buttons.Clear();
            lookUpDistrict.Properties.Buttons.Add(delteButton);

            //lookupUserName.Text = " Nhập người dùng ";


            try
            {
                ds = ws.SelectDistrictDynamic(" CityId like '%" + strCityId + "%'","");

                //Clear Column 
                lookUpDistrict.Properties.View.Columns.Clear();
                lookUpDistrict.Properties.View.Columns.AddVisible("DistrictId", "Mã Quận / Huyện");
                lookUpDistrict.Properties.View.Columns.AddVisible("DistrictName", "Quận / Huyện");

                lookUpDistrict.Properties.View.Columns[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                lookUpDistrict.Properties.View.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            catch (Exception ex)
            {
                ds = null;
            }

            if (ds != null)
            {
                if (ds.Tables[0] != null)
                {
                    lookUpDistrict.Properties.DataSource = ds.Tables[0];

                }
            }
        }
        public static void lookUpWard(SearchLookUpEdit lookUpWard, string strCityId, string strDistrictId)
        {
            /*
             * Dungnv   :   20/10/2014
             * Purpose  :   Load danh sach City 
             */
            DataSet ds = new DataSet();
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();


            lookUpWard.Properties.DisplayMember = "WardName";
            lookUpWard.Properties.ValueMember = "WardId";

            //Add butt Delete
            EditorButton delteButton = new EditorButton();
            delteButton = new EditorButton(ButtonPredefines.Delete);
            lookUpWard.Properties.Buttons.Clear();
            lookUpWard.Properties.Buttons.Add(delteButton);

            //lookupUserName.Text = " Nhập người dùng ";


            try
            {
                ds = ws.SelectWardDynamic(" CityId like '%" + strCityId + "%' and DistrictId like '%" + strDistrictId + "%' ", "");

                //Clear Column 
                lookUpWard.Properties.View.Columns.Clear();
                lookUpWard.Properties.View.Columns.AddVisible("WardId", "Mã Phường");
                lookUpWard.Properties.View.Columns.AddVisible("WardName", "Phường ");

                lookUpWard.Properties.View.Columns[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                lookUpWard.Properties.View.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            catch (Exception ex)
            {
                ds = null;
            }

            if (ds != null)
            {
                if (ds.Tables[0] != null)
                {
                    lookUpWard.Properties.DataSource = ds.Tables[0];

                }
            }
        }
   
        public static void lookUpEmp(SearchLookUpEdit lookUpEmp)
        {
            /*
            *  Dungnv  :   23/11/2015
            *  Purpose :   List Khach Hang
            */
            DataSet ds = new DataSet();
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();


            lookUpEmp.Properties.DisplayMember = "EmployeeName";
            lookUpEmp.Properties.ValueMember = "EmployeeId";


            //Add butt Delete
            EditorButton delteButton = new EditorButton();
            delteButton = new EditorButton(ButtonPredefines.Delete);
            lookUpEmp.Properties.Buttons.Add(delteButton);
             
            try
            {
                ds = ws.selectAllEmployee("", "");
                //Clear Column 
                lookUpEmp.Properties.View.Columns.Clear();
                lookUpEmp.Properties.View.Columns.AddVisible("EmployeeId", "Mã nhân viên");
                lookUpEmp.Properties.View.Columns.AddVisible("EmployeeName", "Tên nhân viên");



                lookUpEmp.Properties.View.Columns[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                lookUpEmp.Properties.View.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            catch (Exception ex)
            {
                ds = null;
            }

            if (ds != null)
            {
                if (ds.Tables[0] != null)
                {
                    lookUpEmp.Properties.DataSource = ds.Tables[0];

                }
            }

        }

        public static void lookUpDriver(SearchLookUpEdit lookUpEmp)
        {
            /*
            *  Dungnv  :   23/11/2015
            *  Purpose :   List Khach Hang
            */
            DataSet ds = new DataSet();
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();


            lookUpEmp.Properties.DisplayMember = "EmployeeName";
            lookUpEmp.Properties.ValueMember = "EmployeeId";


            //Add butt Delete
            EditorButton delteButton = new EditorButton();
            delteButton = new EditorButton(ButtonPredefines.Delete);
            lookUpEmp.Properties.Buttons.Add(delteButton);

            try
            {
                ds = ws.selectAllEmployee(" A.Type='03' ", "");
                //Clear Column 
                lookUpEmp.Properties.View.Columns.Clear();
                lookUpEmp.Properties.View.Columns.AddVisible("EmployeeId", "Mã tài xế");
                lookUpEmp.Properties.View.Columns.AddVisible("EmployeeName", "Tên tài xế");



                lookUpEmp.Properties.View.Columns[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                lookUpEmp.Properties.View.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            catch (Exception ex)
            {
                ds = null;
            }

            if (ds != null)
            {
                if (ds.Tables[0] != null)
                {
                    lookUpEmp.Properties.DataSource = ds.Tables[0];

                }
            }

        }
        public static void lookUpTecher(SearchLookUpEdit lookUpTecher)
        {
            /*
            *  Dungnv  :   23/11/2015
            *  Purpose :   List Huan luyen  vien
            */
            DataSet ds = new DataSet();
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();


            lookUpTecher.Properties.DisplayMember = "EMPLOYEENAME";
            lookUpTecher.Properties.ValueMember = "EMPLOYEEID";


            //Add butt Delete
            EditorButton delteButton = new EditorButton();
            delteButton = new EditorButton(ButtonPredefines.Delete);
            lookUpTecher.Properties.Buttons.Add(delteButton);

            try
            {
                ds = ws.selectAllEmployee("A.POSITION = '04'", "");
                //Clear Column 
                lookUpTecher.Properties.View.Columns.Clear();
                lookUpTecher.Properties.View.Columns.AddVisible("EMPLOYEEID", "Mã huấn luyện viên");
                lookUpTecher.Properties.View.Columns.AddVisible("EMPLOYEENAME", "Tên huấn luyện viên");



                lookUpTecher.Properties.View.Columns[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                lookUpTecher.Properties.View.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            catch (Exception ex)
            {
                ds = null;
            }

            if (ds != null)
            {
                if (ds.Tables[0] != null)
                {
                    lookUpTecher.Properties.DataSource = ds.Tables[0];

                }
            }

        }
   
   
        public static void lookUpResoure(SearchLookUpEdit lookUpResoure)
        {
            /*
            *  NamHP  :   06/05/2016
            *  Purpose :   List Khach Hang
            */
            DataSet ds = new DataSet();
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();

            lookUpResoure.Properties.DisplayMember = "ResoureName";
            lookUpResoure.Properties.ValueMember = "ResourceID";

            //Add butt Delete
            EditorButton delteButton = new EditorButton();
            delteButton = new EditorButton(ButtonPredefines.Delete);
            lookUpResoure.Properties.Buttons.Add(delteButton);

            try
            {
                ds = ws.SelectResouresDynamic("", "");
                //Clear Column 
                lookUpResoure.Properties.View.Columns.Clear();
                lookUpResoure.Properties.View.Columns.AddVisible("ResourceID", "Mã ");
                lookUpResoure.Properties.View.Columns.AddVisible("ResoureName", "Tên");
                lookUpResoure.Properties.View.Columns.AddVisible("ResourceType", "Kiểu");

                lookUpResoure.Properties.View.Columns[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                lookUpResoure.Properties.View.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                lookUpResoure.Properties.View.Columns[2].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            catch (Exception ex)
            {
                ds = null;
            }

            if (ds != null)
            {
                if (ds.Tables[0] != null)
                {
                    lookUpResoure.Properties.DataSource = ds.Tables[0];

                }
            }
        }

        public static void lookUpPlace(SearchLookUpEdit lookupPlace)
        {
            /*
             * Dungnv   :   20/10/2014
             * Purpose  :   Load danh sach user
             */
            DataSet ds = new DataSet();
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();


            lookupPlace.Properties.DisplayMember = "PlaceName";
            lookupPlace.Properties.ValueMember = "PlaceID";

            //Add butt Delete
            EditorButton delteButton = new EditorButton();
            delteButton = new EditorButton(ButtonPredefines.Delete);
            lookupPlace.Properties.Buttons.Add(delteButton);

            //lookupUserName.Text = " Nhập người dùng ";


            try
            {
                ds = ws.selectAllPlace("","");

                //Clear Column 
                lookupPlace.Properties.View.Columns.Clear();
                lookupPlace.Properties.View.Columns.AddVisible("PlaceName", "Địa điểm");
                lookupPlace.Properties.View.Columns.AddVisible("Address", "Địa Chỉ ");

                lookupPlace.Properties.View.Columns[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                lookupPlace.Properties.View.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            catch (Exception ex)
            {
                ds = null;
            }

            if (ds != null)
            {
                if (ds.Tables[0] != null)
                {
                    lookupPlace.Properties.DataSource = ds.Tables[0];

                }
            }
        }

        public static void lookUpTrust(SearchLookUpEdit lookupTrust)
        {
            /*
             * Dungnv   :   20/10/2014
             * Purpose  :   Load danh sach user
             */
            DataSet ds = new DataSet();
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();


            lookupTrust.Properties.DisplayMember = "TrustName";
            lookupTrust.Properties.ValueMember = "VehicleNumber";

            //Add butt Delete
            EditorButton delteButton = new EditorButton();
            delteButton = new EditorButton(ButtonPredefines.Delete);
            lookupTrust.Properties.Buttons.Add(delteButton);

            //lookupUserName.Text = " Nhập người dùng ";


            try
            {
                ds = ws.selectAllTrust("", "");

                //Clear Column 
                lookupTrust.Properties.View.Columns.Clear();
                lookupTrust.Properties.View.Columns.AddVisible("TrustName", "Tên xe");
                lookupTrust.Properties.View.Columns.AddVisible("VehicleNumber", "Bảng số ");

                lookupTrust.Properties.View.Columns[0].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                lookupTrust.Properties.View.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
            catch (Exception ex)
            {
                ds = null;
            }

            if (ds != null)
            {
                if (ds.Tables[0] != null)
                {
                    lookupTrust.Properties.DataSource = ds.Tables[0];

                }
            }
        }
        #endregion 

        #region Commbobox - ComboEdit 
        public static void loadComboboxTab(string strTable, DevExpress.XtraTab.XtraTabPage tab)
        {
            /*
             * Dungnv   : 27/10/2014
             * Purpose  : Load Combobox 
             */
            ArrayList arrComboEmp = new ArrayList();
            ClsCommonDB objDB = new ClsCommonDB();
            int iCount = 0;

            arrComboEmp = objDB.getArrAllCode("", strTable);
            iCount = arrComboEmp.Count;

            if (iCount > 0)
            {
                foreach (Control ctrParent in tab.Controls)
                {
                    foreach (Control ctr in ctrParent.Controls)
                    {
                        if (ctr is System.Windows.Forms.ComboBox)
                        {
                            if (ctr.Tag != null)
                            {
                                //Clear iteam 
                                ((System.Windows.Forms.ComboBox)ctr).Items.Clear();
                                string strTag = ctr.Tag.ToString().Trim();
                                if (strTag != "")
                                {
                                    //Duyet mang du lieu 
                                    for (int i = 0; i < iCount; i++)
                                    {
                                        ClsParameter.STRUCTINFO objStruct = new ClsParameter.STRUCTINFO();
                                        objStruct = (ClsParameter.STRUCTINFO)arrComboEmp[i];
                                        if (strTag == objStruct.NAME.Trim())
                                        {
                                            ComboboxItem item = new ComboboxItem();
                                            item.Value = objStruct.KEY.Trim(); ;
                                            item.Text = objStruct.VALUE.Trim();

                                            ((System.Windows.Forms.ComboBox)(ctr)).Items.Add(item);
                                        }
                                    }
                                    ((System.Windows.Forms.ComboBox)(ctr)).SelectedIndex = 0;
                                }
                            }
                        }
                    }


                }
            }
        }
        public static void loadComboboxDevExTab(string strTable, DevExpress.XtraTab.XtraTabPage tab)
        {
            /*
             * Dungnv   : 27/10/2014
             * Purpose  : Load Combobox 
             */
            ArrayList arrComboEmp = new ArrayList();
            ClsCommonDB objDB = new ClsCommonDB();
            int iCount = 0;

            arrComboEmp = objDB.getArrAllCode("", strTable);
            iCount = arrComboEmp.Count;

            if (iCount > 0)
            {
                foreach (Control ctrParent in tab.Controls)
                {
                    //foreach (Control ctrChild in ctrParent.Controls)
                    foreach (Control ctr in ctrParent.Controls)
                    {
                        //foreach (Control ctr in ctrChild.Controls)
                        //{
                            //Qua 3 cap do duyet vi design Tab->Panel->GroupBox 

                            if (ctr is DevExpress.XtraEditors.ComboBoxEdit)
                            {
                                if (ctr.Tag != null)
                                {
                                    //Clear iteam 
                                    ((DevExpress.XtraEditors.ComboBoxEdit)ctr).Properties.Items.Clear();

                                    //Khong cho Edit text
                                    ((DevExpress.XtraEditors.ComboBoxEdit)ctr).Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

                                    string strTag = ctr.Tag.ToString().Trim().ToUpper();
                                    if (strTag != "")
                                    {
                                        //Duyet mang du lieu 
                                        for (int i = 0; i < iCount; i++)
                                        {
                                            ClsParameter.STRUCTINFO objStruct = new ClsParameter.STRUCTINFO();
                                            objStruct = (ClsParameter.STRUCTINFO)arrComboEmp[i];
                                            if (strTag == objStruct.NAME.Trim().ToUpper())
                                            {
                                                ComboboxItem item = new ComboboxItem();
                                                item.Value = objStruct.KEY.Trim(); ;
                                                item.Text = objStruct.VALUE.Trim();

                                                ((DevExpress.XtraEditors.ComboBoxEdit)(ctr)).Properties.Items.Add(item);
                                            }
                                        }
                                        ((DevExpress.XtraEditors.ComboBoxEdit)(ctr)).SelectedIndex = 0;
                                    }
                                }
                            }
                        //}
                    }


                }
            }
        }
        public static void loadComboboxNonTab(string strTable, DevExpress.XtraEditors.XtraForm frm)
        {
            /*
             * Dungnv   : 05/06/2014
             * Purpose  : Load Combobox 
             */
            ArrayList arrComboEmp = new ArrayList();
            ClsCommonDB objDB = new ClsCommonDB();
            int iCount = 0;



            try
            {
                arrComboEmp = objDB.getArrAllCode("", strTable);
                iCount = arrComboEmp.Count;

                if (iCount > 0)
                {
                    foreach (Control ctrParent in frm.Controls)
                    {
                        //MessageBox.Show(ctrParent.Name.ToString());
                        foreach (Control ctr in ctrParent.Controls)
                        {
                            //if (ctr is System.Windows.Forms.ComboBox)
                            if (ctr is DevExpress.XtraEditors.ComboBoxEdit)
                            {
                                if (ctr.Tag != null)
                                {
                                    //Clear iteam 
                                    //((System.Windows.Forms.ComboBox)ctr).Items.Clear();                                    
                                    ((DevExpress.XtraEditors.ComboBoxEdit)ctr).Properties.Items.Clear();
                                    ((DevExpress.XtraEditors.ComboBoxEdit)ctr).Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

                                    string strTag = ctr.Tag.ToString().Trim();
                                    if (strTag != "")
                                    {
                                        //Duyet mang du lieu 
                                        for (int i = 0; i < iCount; i++)
                                        {
                                            ClsParameter.STRUCTINFO objStruct = new ClsParameter.STRUCTINFO();
                                            objStruct = (ClsParameter.STRUCTINFO)arrComboEmp[i];
                                            if (strTag == objStruct.NAME.Trim())
                                            {
                                                ComboboxItem item = new ComboboxItem();
                                                item.Value = objStruct.KEY.Trim(); ;
                                                item.Text = objStruct.VALUE.Trim();

                                                //((System.Windows.Forms.ComboBox)(ctr)).Items.Add(item);
                                                ((DevExpress.XtraEditors.ComboBoxEdit)(ctr)).Properties.Items.Add(item);
                                            }
                                        }
                                        //((System.Windows.Forms.ComboBox)(ctr)).SelectedIndex = 0;
                                        ((DevExpress.XtraEditors.ComboBoxEdit)(ctr)).SelectedIndex = 0;
                                    }
                                }
                            }
                        }


                    }
                }
            }
            catch (Exception ex)
            {
            }


        }
        public static void changeButtonSearchClear(object sender, EventArgs e, ImageList imgLst)
        {
            /*
             *  Dungnv  :   23/10/2014
             *  Purpode :   Thay đổi capture , add icon 
             */

            try
            {
                IPopupControl popupControl = sender as IPopupControl;
                LayoutControl layoutControl = popupControl.PopupWindow.Controls[2].Controls[0] as LayoutControl;
                SimpleButton clearButton = ((LayoutControlItem)layoutControl.Items.FindByName("lciClear")).Control as SimpleButton;
                SimpleButton findButton = ((LayoutControlItem)layoutControl.Items.FindByName("lciButtonFind")).Control as SimpleButton;

                clearButton.Text = "Thoát";
                clearButton.ImageList = imgLst;
                clearButton.ImageIndex = 0;

                findButton.Text = "Tìm";
                findButton.ImageList = imgLst;
                findButton.ImageIndex = 1;
            }
            catch (Exception ex)
            {
                return;
            }


        }
        public static void selectedCombobox(System.Windows.Forms.ComboBox cmb, string strValue)
        {
            /*
             * Dungnv    : 06/12/2014
             * Purpose   : Gan gia tri cho combobox 
             */
            try
            {
                foreach (ComboboxItem cmbItem in cmb.Items)
                {
                    if (cmbItem.Value.ToString().Trim() == strValue.Trim())
                    {
                        cmb.SelectedItem = cmbItem;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }
        public static void selectedComboboxDexEx(DevExpress.XtraEditors.ComboBoxEdit cmb, string strValue)
        {
            /*
             * Dungnv    : 06/12/2014
             * Purpose   : Gan gia tri cho combobox 
             */
            try
            {
                foreach (ComboboxItem cmbItem in cmb.Properties.Items)
                {
                    if (cmbItem.Value.ToString().Trim() == strValue.Trim())
                    {
                        cmb.SelectedItem = cmbItem;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }

        public static void loadCombobox(System.Windows.Forms.ComboBox cmb, string strFieldName, string strTableName)
        {
            /*
             * Dungnv   :   22/12/2014
             * Purpose  :   Load ComboBoxEdit 
             */

            ArrayList arrComboEmp = new ArrayList();
            ClsCommonDB objDB = new ClsCommonDB();
            int iCount = 0;

            try
            {
                arrComboEmp = objDB.getArrAllCode(strFieldName, strTableName);
                iCount = arrComboEmp.Count;

                if (iCount > 0)
                {
                    //Duyet mang du lieu 
                    for (int i = 0; i < iCount; i++)
                    {
                        ClsParameter.STRUCTINFO objStruct = new ClsParameter.STRUCTINFO();
                        objStruct = (ClsParameter.STRUCTINFO)arrComboEmp[i];

                        ComboboxItem item = new ComboboxItem();
                        item.Value = objStruct.KEY.Trim(); ;
                        item.Text = objStruct.VALUE.Trim();
                        cmb.Items.Add(item);
                    }
                    cmb.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
            }

        }

        public static void loadComboBoxEdit(DevExpress.XtraEditors.ComboBoxEdit cmb, string strFieldName, string strTableName)
        {
            /*
             * Dungnv   :   22/12/2014
             * Purpose  :   Load Combobox 
             */

            ArrayList arrComboEmp = new ArrayList();
            ClsCommonDB objDB = new ClsCommonDB();
            int iCount = 0;

            //Khong cho edit text 
            cmb.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cmb.Properties.Items.Clear();


            try
            {
                arrComboEmp = objDB.getArrAllCode(strFieldName, strTableName);
                iCount = arrComboEmp.Count;

                if (iCount > 0)
                {
                    //Duyet mang du lieu 
                    for (int i = 0; i < iCount; i++)
                    {
                        ClsParameter.STRUCTINFO objStruct = new ClsParameter.STRUCTINFO();
                        objStruct = (ClsParameter.STRUCTINFO)arrComboEmp[i];

                        ComboboxItem item = new ComboboxItem();
                        item.Value = objStruct.KEY.Trim(); ;
                        item.Text = objStruct.VALUE.Trim();
                        cmb.Properties.Items.Add(item);

                    }
                    cmb.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
            }

        }

        public static void loadComboBoxEditSearch(DevExpress.XtraEditors.ComboBoxEdit cmb, string strFieldName, string strTableName)
        {
            /*
             * Dungnv   :   22/12/2014
             * Purpose  :   Load Combobox 
             */

            ArrayList arrComboEmp = new ArrayList();
            ClsCommonDB objDB = new ClsCommonDB();
            int iCount = 0;

            //Khong cho edit text 
            cmb.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            cmb.Properties.Items.Clear();


            try
            {
                arrComboEmp = objDB.getArrAllCode(strFieldName, strTableName);
                iCount = arrComboEmp.Count;

                if (iCount > 0)
                {
                    ComboboxItem itemSearch = new ComboboxItem();
                    itemSearch.Value = "00" ;
                    itemSearch.Text = "Tất cả";
                    cmb.Properties.Items.Add(itemSearch);


                    //Duyet mang du lieu 
                    for (int i = 0; i < iCount; i++)
                    {
                        ClsParameter.STRUCTINFO objStruct = new ClsParameter.STRUCTINFO();
                        objStruct = (ClsParameter.STRUCTINFO)arrComboEmp[i];

                        ComboboxItem item = new ComboboxItem();
                        item.Value = objStruct.KEY.Trim(); ;
                        item.Text = objStruct.VALUE.Trim();
                        cmb.Properties.Items.Add(item);

                    }
                    cmb.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
            }

        }

        #endregion 
        public static void textBox_keyPress(object sender, KeyPressEventArgs e)
        {
            /*
            * Dungnv : Check khong cho nhap chu 
            */

            int i = e.KeyChar;
            if ((i >= 48 && i <= 57) || i == 8)
            {
            }
            else
            {
                e.Handled = true;
            }
        }
        public static Boolean isEmpty(string s)
        {
            if (s == null || s == "")
                return true;
            return false;
        }


        public static string getParaMeter(string strFieldName, string strTableName){
            ClsCommonDB objDB = new ClsCommonDB();
            ArrayList arr = new ArrayList();
            try
            {
                arr = objDB.getArrAllCode(strFieldName, strTableName);
                if (arr.Count > 0)
                    return ((ClsParameter.STRUCTINFO)arr[0]).KEY.ToString();
                else
                    return "";
            } catch (Exception ex) {
                return "";
            }
        }
        #endregion 
    }

    public class ComboboxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}

