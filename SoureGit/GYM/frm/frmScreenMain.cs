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
using System.Globalization;
using DevExpress.XtraEditors.Repository;

namespace GYM.frm
{
    public partial class frmScreenStore : DevExpress.XtraEditors.XtraForm
    {
        public frmScreenStore()
        {
            InitializeComponent();
        }

        private void frmScreenMain_Load(object sender, EventArgs e)
        {
            /*
             * Dungnv:
             * Date : 26.12.2017
             * Purpose : Hiển thị thông tin hành trình/
             */
            getlistCurrentJourney();
        }

        private void getlistCurrentJourney()
        {

            DataSet ds = new DataSet();


            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();

            try
            {
                ds = ws.selectAllCurrentJourney();
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

                dtgResult.Columns[5].Visible = false;

                dtgResult.Columns[6].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[6].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[6].Caption = "Giao hàng 1";
                dtgResult.Columns[6].Width = 120;


                dtgResult.Columns[7].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[7].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[7].Caption = "Giao hàng 2";
                dtgResult.Columns[7].Width = 120;

                dtgResult.Columns[8].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[8].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[8].Caption = "Điểm xuất phát 1";
                dtgResult.Columns[8].Width = 120;


                dtgResult.Columns[9].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[9].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[9].Caption = "Giờ Xuất Phát 1";
                dtgResult.Columns[9].Width = 140;
                dtgResult.Columns[9].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";

                dtgResult.Columns[10].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[10].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[10].Caption = "Điểm giao hàng 1";
                dtgResult.Columns[10].Width = 100;

                dtgResult.Columns[11].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[11].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[11].Caption = "Giờ đến Kế Hoạch 1";
                dtgResult.Columns[11].Width = 140;

                dtgResult.Columns[12].Visible = false;
                dtgResult.Columns[12].Caption = "Giờ đến thực tế 1,";


                dtgResult.Columns[13].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[13].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[13].Caption = "Giờ xuất phát 2";
                dtgResult.Columns[13].Width = 140;
                dtgResult.Columns[13].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";

                dtgResult.Columns[14].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[14].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[14].Caption = "Điểm giao hàng 2";
                dtgResult.Columns[14].Width = 100;

                dtgResult.Columns[15].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[15].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[15].Caption = "Giờ đến Kế Hoạch 2";
                dtgResult.Columns[15].Width = 140;
                dtgResult.Columns[15].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";

                dtgResult.Columns[16].Visible = false;
                dtgResult.Columns[16].Caption = "Giờ đến thực tế 2,";

                dtgResult.Columns[17].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[17].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[17].Caption = "Giờ xuất phát 3";
                dtgResult.Columns[17].Width = 140;
                dtgResult.Columns[17].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";

                dtgResult.Columns[18].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[18].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[18].Caption = "Điểm giao hàng 3";
                dtgResult.Columns[18].Width = 120;

                dtgResult.Columns[19].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[19].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[19].Caption = "Giờ đến Kế Hoạch 3";
                dtgResult.Columns[19].Width = 140;
                dtgResult.Columns[19].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";

             

                dtgResult.Columns[20].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[20].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[20].Caption = "Giờ đến thực tế cuối cùng";
                dtgResult.Columns[20].Width = 140;
                dtgResult.Columns[20].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";


                dtgResult.Columns[21].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[21].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[21].Caption = "Trạng thái giao hàng";
                dtgResult.Columns[21].Width = 120;

                /*
                dtgResult.Columns[22].Caption = "Trạng Thái Khởi Hành"; // Trang thai xe
                dtgResult.Columns[22].Visible = false;
                */

                dtgResult.Columns[22].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[22].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[22].Caption = "Trạng Thái Khởi Hành";
                dtgResult.Columns[22].Width = 120;


                dtgResult.Columns[23].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[23].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[23].Caption = "Cổng Giao hàng";
                dtgResult.Columns[23].Width = 120;

                dtgResult.Columns[24].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[24].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[24].Caption = "Ghi Chú ";
                dtgResult.Columns[24].Width = 120;

                

                dtgResult.Columns[25].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[25].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[25].Caption = "Trạng thái hành trình";
                dtgResult.Columns[25].Width = 120;

            }
            else
            {
                gridControlMain.DataSource = null;
            }
        }
    }
}