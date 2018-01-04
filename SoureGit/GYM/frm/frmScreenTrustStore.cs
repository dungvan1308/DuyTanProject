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
    public partial class frmScreenTrustStore : DevExpress.XtraEditors.XtraForm
    {
        public frmScreenTrustStore()
        {
            InitializeComponent();
        }

        private void frmScreenTrustStore_Load(object sender, EventArgs e)
        {
            
            //Hiện thị danh sách xe tại kho 
            getInformationStrustStore();

        }

        private void getInformationStrustStore()
        {

            DataSet ds = new DataSet();


            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();

            try
            {
                ds = ws.selectInformationAtTrustStore();
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

                dtgResult.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[1].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                dtgResult.Columns[1].Caption = "Tài Xế";
                dtgResult.Columns[1].Width = 120;

                dtgResult.Columns[2].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[2].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[2].Caption = "Điện thoại";
                dtgResult.Columns[2].Width = 80;


                dtgResult.Columns[3].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[3].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[3].Caption = "Bảng số xe";
                dtgResult.Columns[3].Width = 120;


                dtgResult.Columns[4].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[4].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[4].Caption = "Thời gian đến";
                dtgResult.Columns[4].Width = 140;
                dtgResult.Columns[4].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";

                dtgResult.Columns[5].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[5].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[5].Caption = "Vị trí tiếp theo";
                dtgResult.Columns[5].Width = 100;

                dtgResult.Columns[6].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[6].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[6].Caption = "Thời gian xuất phát";
                dtgResult.Columns[6].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
                dtgResult.Columns[6].Width = 140;

                dtgResult.Columns[7].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[7].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[7].Caption = "Ghi chú";
                dtgResult.Columns[7].Width = 140;
                


            }
            else
            {
                gridControlMain.DataSource = null;
            }
        }
    }
}