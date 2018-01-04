using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GYM.Common;
using GYM.ServiceReferenceDuyTan;
using System.Collections;


namespace GYM.frm
{
    public partial class frmReport : DevExpress.XtraEditors.XtraForm
    {
        private string strReportName = "";
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            /*
             * Dungnv   :   23/11/2015
             * Purpose  :   Load thong tin ban dau 
             */
            ClsCommonProcess.loadCombobox(cmbModule, ClsParameter.MODULE, ClsParameter.MODULE_REPORT);
        }

        private void cmbModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
             * Dungnv   :   01/01/2014
             * Purpose  :   Get List Report 
             */

            string strModule = "";
            DataSet ds = new DataSet();
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();
            try
            {
                if (cmbModule.SelectedItem != null)
                {
                    strModule = ((ComboboxItem)cmbModule.SelectedItem).Value.ToString();
                }
                else
                {
                    strModule = "";
                }

                ds = ws.selectListReport(strModule);
                bindingGrid(ds);

            }
            catch (Exception ex)
            {
            }
        }
        private void bindingGrid(DataSet ds)
        {
            /*
             * Dungnv   :   31/12/2014
             * Purpose  :   Load thong tin len Gridview 
             */

            //Binding Gridview 
            gridControlMain.DataSource = null;
            try
            {
                if (ds != null)
                {
                    gridControlMain.DataSource = ds.Tables[0];


                    //Chinh Tieu De
                    for (int i = 0; i < gridViewMain.Columns.Count; i++)
                    {
                        gridViewMain.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gridViewMain.Columns[i].AppearanceHeader.ForeColor = DevExpress.Utils.DXColor.Blue;

                    }

                    gridViewMain.Columns[0].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridViewMain.Columns[0].Caption = ClsParameter.LIST_COLUMN_NO;
                    gridViewMain.Columns[0].Width = 50;



                    gridViewMain.Columns[1].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridViewMain.Columns[1].Caption = ClsParameter.LIST_REPORT_NAME;
                    gridViewMain.Columns[1].Width = 80;


                    gridViewMain.Columns[2].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                    gridViewMain.Columns[2].Caption = ClsParameter.LIST_DESC;
                    gridViewMain.Columns[2].Width = 400;


                }
            }
            catch (Exception ex)
            {
            }

        }

        private void gridControlMain_Click(object sender, EventArgs e)
        {
            /*
             *  Dungnv  :   23/11/2015
             *  Purpose :   Chon report
             */
            try
            {
                strReportName = gridViewMain.GetRowCellValue(gridViewMain.FocusedRowHandle, "RPTNAME").ToString();
            }
            catch (Exception ex)
            {
                strReportName = "";
            }
        }

        private void bttView_Click(object sender, EventArgs e)
        {
            /*
             *  Dungnv  :   23/11/2015
             *  Purpose :   Show report
             */
  
            viewReport();
        }

        private void viewReport()
        {
            if (strReportName == "")
            {
                ClsCommonProcess.msgError(ClsParameter.MSG_REPORT_NOT_SELECTED);
                return;
            }

            //Lay danh sach cac tham so 
            ArrayList arrPara = new ArrayList();
            ReportObjects objReport = new ReportObjects();
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();
            objReport = ws.ExecProcedureToArr(strReportName);
            if (objReport != null)
            {
                arrPara = new ArrayList(objReport.arrLst);
                if (arrPara.Count > 0)
                {
                    frmReportParameters frm = new frmReportParameters();
                    frm.strReportName = strReportName;
                    frm.arrPara = arrPara;
                    frm.ShowDialog();
                }
                else
                {
                    ClsCommonReport.viewReport(new ReportObjects(), strReportName);
                }

            }
        }

        private void bttExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}