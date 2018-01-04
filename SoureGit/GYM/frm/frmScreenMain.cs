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
                dtgResult.Columns[8].Caption = "Thời gian đi";
                dtgResult.Columns[8].Width = 140;
                dtgResult.Columns[8].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";

                dtgResult.Columns[9].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[9].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[9].Caption = "Điểm giao hàng 1";
                dtgResult.Columns[9].Width = 100;

                dtgResult.Columns[10].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[10].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[10].Caption = "Thời gian đến KH 1";
                dtgResult.Columns[10].Width = 140;

                dtgResult.Columns[11].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[11].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[11].Caption = "Thời gian đi 2";
                dtgResult.Columns[11].Width = 140;
                dtgResult.Columns[11].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";

                dtgResult.Columns[12].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[12].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[12].Caption = "Điểm giao hàng 2";
                dtgResult.Columns[12].Width = 100;

                dtgResult.Columns[13].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[13].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[13].Caption = "Thời gian đến KH 2";
                dtgResult.Columns[13].Width = 140;
                dtgResult.Columns[13].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";

                dtgResult.Columns[14].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[14].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[14].Caption = "Thời gian đi 3";
                dtgResult.Columns[14].Width = 140;
                dtgResult.Columns[14].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";

                dtgResult.Columns[15].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[15].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[15].Caption = "Điểm giao hàng 3";
                dtgResult.Columns[15].Width = 120;

                dtgResult.Columns[16].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[16].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[16].Caption = "Thời gian đến KH 3";
                dtgResult.Columns[16].Width = 140;
                dtgResult.Columns[16].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";


                dtgResult.Columns[17].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[17].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[17].Caption = "Thời gian về";
                dtgResult.Columns[17].Width = 140;
                dtgResult.Columns[17].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";


                dtgResult.Columns[18].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[18].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[18].Caption = "Trạng thái giao hàng";
                dtgResult.Columns[18].Width = 120;

                dtgResult.Columns[19].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[19].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[19].Caption = "Cổng ";
                dtgResult.Columns[19].Width = 120;



            }
            else
            {
                gridControlMain.DataSource = null;
            }
        }
    }
}