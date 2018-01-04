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
    public partial class frmScreenTrustGroup : DevExpress.XtraEditors.XtraForm
    {
        public frmScreenTrustGroup()
        {
            InitializeComponent();
        }

        private void frmScreenTrustGroup_Load(object sender, EventArgs e)
        {
            getInformationStrustGroup();

        }

        private void getInformationStrustGroup()
        {

            DataSet ds = new DataSet();


            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();

            try
            {
                ds = ws.selectInformationAtTrustGroup();
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
                dtgResult.Columns[0].AppearanceHeader.Options.UseFont = Font.Bold;
                dtgResult.Columns[0].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[0].Caption = "STT";
                dtgResult.Columns[0].Width = 30;

                dtgResult.Columns[1].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[1].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                dtgResult.Columns[1].Caption = "Biển số xe";
                dtgResult.Columns[1].Width = 80;
                

                dtgResult.Columns[2].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[2].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[2].Caption = "Điểm giao hàng 1";
                dtgResult.Columns[2].Width = 120;
                


                dtgResult.Columns[3].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[3].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[3].Caption = "Thời gian đi";
                dtgResult.Columns[3].Width = 140;
                dtgResult.Columns[3].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
                

                dtgResult.Columns[4].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[4].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[4].Caption = "Điểm giao hàng 2";
                dtgResult.Columns[4].Width = 120;
                

                dtgResult.Columns[5].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                dtgResult.Columns[5].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                dtgResult.Columns[5].Caption = "Thời gian đến";
                dtgResult.Columns[5].Width = 140;
                dtgResult.Columns[5].DisplayFormat.FormatString = "dd/MM/yyyy hh:mm:ss";
                

            }
            else
            {
                gridControlMain.DataSource = null;
            }
        }
    }
}