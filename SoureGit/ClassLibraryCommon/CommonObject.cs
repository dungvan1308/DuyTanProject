using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections;
using System.Management;
using System.Security.Cryptography;
using System.Data;

namespace ClassLibraryCommon
{
    public static class CommonObject
    {
        
        #region  Doc thong tin He thong phan cung
        public static string getCpuId_Serial()
        {
            /*
             * @author  :   Dungnv 
             * @date    :   09/04/2011
             * @purpose :   Lay thong tin CPU
             */

           string  strCpuId_Serial = String.Empty;
            try
            {
                ManagementClass manClass = new ManagementClass("Win32_Processor");
                ManagementObjectCollection manObjs = manClass.GetInstances();
                ManagementObjectCollection.ManagementObjectEnumerator manObjsEnum = manObjs.GetEnumerator();
                if (manObjsEnum.MoveNext())
                {
                    strCpuId_Serial = "$@%@FB0X999X" + manObjsEnum.Current.Properties["ProcessorId"].Value.ToString().Trim();
                }

                manClass = new ManagementClass("Win32_BaseBoard");
                manObjs = manClass.GetInstances();
                manObjsEnum = manObjs.GetEnumerator();
                string strMain = "";
                if (manObjsEnum.MoveNext())
                {
                    strMain = manObjsEnum.Current.Properties["SerialNumber"].Value.ToString().Trim();
                }

                strCpuId_Serial = strCpuId_Serial + "@@***&&BF0001" + strMain;


            }
            catch
            {
                // should out to log 
                strCpuId_Serial = String.Empty;
               

            }
            return strCpuId_Serial;
        }
        #endregion


        #region Mã Hóa Dữ Liệu
        public static string EncryptData(string Data)
        {
            try
            {
                byte[] PP = Encoding.Unicode.GetBytes("GYM");
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
                byte[] PP = Encoding.Unicode.GetBytes("GYM");
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
    
    }
}
