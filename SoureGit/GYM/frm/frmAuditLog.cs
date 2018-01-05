using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GYM.ServiceReferenceDuyTan;

namespace GYM.frm
{
    public partial class frmAuditLog : DevExpress.XtraEditors.XtraForm
    {
        public frmAuditLog()
        {
            InitializeComponent();
        }

        private void frmAuditLog_Load(object sender, EventArgs e)
        {
            /*
             * Dungnv   :   21/05/2016
             * Purpose  :   Khoi tao cac thong so dau vao 
             */
           // searchLogIn();
        }
        private void searchLogIn()
        {
            /*
             * Dungnv   :   20/05/2016
             * Purpose  :   Hiển thị danh sách user đang đăng nhập hệ thống
             */
 
            DataSet ds = new DataSet();


            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();

            try
            {
                ds = ws.SelectCurrentLogin();
            }
            catch (Exception ex)
            {
                ds = null;

            }

            //Binding Gridview 
            gridControlMain.DataSource = null;
            dtgResult.Columns.Clear();
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

                dtgResult.Columns[1].Caption = "Mã người dùng";
                dtgResult.Columns[1].Width = 80;

                dtgResult.Columns[2].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[2].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                dtgResult.Columns[2].Caption = "Thời gian truy cập";
                dtgResult.Columns[2].Width = 200;


            }
            else
            {
                gridControlMain.DataSource = null;
            }
        }

        private void bttClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bttSearch_Click(object sender, EventArgs e)
        {
            /*
             * Dungnv : 26/05/2016
             * Purpose: Lay danh sach User login 
             */


            listLoginAll();



        }

        private void listLoginAll()
        {
            /*
             * Dungnv   :   20/05/2016
             * Purpose  :   Hiển thị danh sách user đang đăng nhập hệ thống tu ngay den ngay 
             */

            DataSet ds = new DataSet();


            DateTime frDate = new DateTime();
            DateTime toDate = new DateTime();
            frDate = dtFrdate.DateTime;
            toDate = dtTodate.DateTime;

            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();

            try
            {
                ds = ws.listUserLogIn(frDate,toDate);
            }
            catch (Exception ex)
            {
                ds = null;

            }

            //Binding Gridview 
            gridControlMain.DataSource = null;
            dtgResult.Columns.Clear();

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

                dtgResult.Columns[1].Caption = "Mã người dùng";
                dtgResult.Columns[1].Width = 80;

                dtgResult.Columns[2].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[2].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                dtgResult.Columns[2].Caption = "Thời gian truy cập";
                dtgResult.Columns[2].Width = 180;

                dtgResult.Columns[3].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[3].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                dtgResult.Columns[3].Caption = "Thời gian thoát ứng dụng";
                dtgResult.Columns[3].Width = 180;


            }
            else
            {
                gridControlMain.DataSource = null;
            }
        }

        private void chkNow_CheckedChanged(object sender, EventArgs e)
        {
            /*
             * Dungnv   :   26/05/2016
             * Purpose  :   Xu ly check Current Date
             */

            if (chkNow.Checked == true)
            {
                searchLogIn();
                dtTodate.ReadOnly = true;
                dtFrdate.ReadOnly = true;
                bttSearch.Enabled = false;
            }
            else
            {
                dtTodate.ReadOnly = false;
                dtFrdate.ReadOnly = false;
                bttSearch.Enabled = true;
                gridControlMain.DataSource = null;
                dtgResult.Columns.Clear();
            }
        }

    }
}