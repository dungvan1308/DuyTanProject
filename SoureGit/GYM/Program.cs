using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using GYM.frm;
namespace GYM
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

            /*
            frmCardRegister frm1 = new frmCardRegister();
            Application.Run(frm1);
            */

            frmLogin frm = new frmLogin();
            Application.Run(frm);
            if (frm.LogonSuccessful == true)
            {
                frmMain main = new frmMain();
                //frm.Close();
                Application.Run(main);
            }
            
            
        }
    }
}