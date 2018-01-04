using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress;
using DevExpress.XtraExport;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Parameters;
using GYM.Reports;
using GYM.ServiceReferenceDuyTan;
using System.Data;
using System.Drawing;
using System.Collections;
namespace GYM.Common
{
    class ClsCommonReport
    {
        public static XtraReport getReportInstance(string reportName)
        {

            if (reportName.Trim().Equals("RPT001"))
            {
                return new RPT001();
            }
            else if (reportName.Trim().Equals("RPT002"))
            {
                return new RPT002();
            }
            else if (reportName.Trim().Equals("RPT003"))
            {
                return new RPT003();
            }
            else if (reportName.Trim().Equals("RPT004"))
            {
                return new RPT004();
            }
            else if (reportName.Trim().Equals("RPT005"))
            {
                return new RPT005();
            }
            else if (reportName.Trim().Equals("RPT006"))
            {
                return new RPT006();
            }
            else if (reportName.Trim().Equals("RPT007"))
            {
                return new RPT007();
            }
            else if (reportName.Trim().Equals("RPT008"))
            {
                return new RPT008();
            }
            else if (reportName.Trim().Equals("RPT009"))
            {
                return new RPT009();
            }
            else if (reportName.Trim().Equals("EMP01"))
            {
                return new EMP01();
            }
            else
            {
                return new XtraReport();
            }
           

           

            //return new XtraReport();
        }

        public static void viewReport(ReportObjects reportObject, string reportName)
        {
            XtraReport report = ClsCommonReport.getReportInstance(reportName);

            /*
             * Dungnv   :23/11/2015
             * Purpose  : Set value general Parameter
             */
            

            /* Dungnv : 06/03/2015
             * Khong su dung tham so cho Thong tin Cong Ty , thay bang SubReport
             */
            /*
            ParameterCollection paraCollect = new ParameterCollection();
            paraCollect = report.Parameters;
            int iCount = 0;
            iCount = paraCollect.Count;
            for (int i = 0; i < iCount; i++)
            {
                if (paraCollect[i].Name.Equals("para_CompanyName"))
                {
                    report.Parameters["para_CompanyName"].Value = ClsParameter.STRUCT_INFOLOGIN.CompanyName;
                    report.Parameters["para_CompanyName"].Visible = false;
                }
                else if (paraCollect[i].Name.Equals("para_Address"))
                {
                    report.Parameters["para_Address"].Value = ClsParameter.STRUCT_INFOLOGIN.Address;
                    report.Parameters["para_Address"].Visible = false;
                }
                else if (paraCollect[i].Name.Equals("para_Telephone"))
                {
                    report.Parameters["para_Telephone"].Value = ClsParameter.STRUCT_INFOLOGIN.Tel;
                    report.Parameters["para_Telephone"].Visible = false;
                }
                else if (paraCollect[i].Name.Equals("para_Fax"))
                {
                    report.Parameters["para_Fax"].Value = ClsParameter.STRUCT_INFOLOGIN.Tel;
                    report.Parameters["para_Fax"].Visible = false;
                }
                else if (paraCollect[i].Name.Equals("para_Tax"))
                {
                    report.Parameters["para_Tax"].Value = ClsParameter.STRUCT_INFOLOGIN.Tax;
                    report.Parameters["para_Tax"].Visible = false;
                }
                
            }
            */


            //Xu ly report co Parameter nhung khong dung @ duoc 
            ParameterCollection paraCollect = new ParameterCollection();
            ArrayList arrPara = new ArrayList();
            paraCollect = report.Parameters;
            int iCount = 0;
            iCount = paraCollect.Count;

            string strName ="";

            if(reportObject.arrLst !=null)
            {
                arrPara = new ArrayList(reportObject.arrLst.ToArray());
                for (int j = 0; j < arrPara.Count; j++)
                {
                    ReportParaObject rptObj = new ReportParaObject();
                    rptObj = (ReportParaObject)arrPara[j];
                    strName = rptObj.PARA_NAME.Substring(1, rptObj.PARA_NAME.Length - 1);

                    for (int i = 0; i < iCount; i++)
                    {
                        if (paraCollect[i].Name.Trim() == strName)
                        {
                            //report.Parameters["FRDATE"].Value = "01/01/2016";
                            //report.Parameters["FRDATE"].Visible = false;

                            if (report.Parameters[i].Type == typeof(System.DateTime))
                            {
                                report.Parameters[i].Value = ClsCommonProcess.convertStringToDate(rptObj.PARA_VALUE);
                            }
                            else
                            {
                                report.Parameters[i].Value = rptObj.PARA_VALUE;
                            }

                            report.Parameters[i].Visible = false;

                        }

                    }

                }
            }

            

            


            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();

            //Lay thong tin Cong ty 
            DataSet dsInfo = new DataSet();

            
            dsInfo = ws.get_info_company();
            if (dsInfo != null)
            {
                buildSubreportInfoCompany(report, dsInfo.Tables[0]);
            }
          

            //Lay dataSource 
            DataSet ds = new DataSet();

            ds = ws.selectReportDatas(reportObject, reportName);

            if (ds != null)
            {
                switch (reportName.Trim())
                {
                    case "IN001":
                        report.DataSource = ds.Tables[1];
                        buildSubreportIN000(report, ds.Tables[0]);
                        break;
                    case "CF003":
                        //Danh sach giao dich cua Khach hang 
                        report.DataSource = ds.Tables[1];
                        buildSubreportCustomer(report, ds.Tables[0]);
                        break;
                
                    default:
                        report.DataSource = ds.Tables[0];
                        break;
                }


            }




            ReportPrintTool tool = new ReportPrintTool(report);
            tool.ShowPreview();
            //report.ShowPreview();
        }

        public static void buildCompanyInfo(XtraReport report)
        {
            ReportHeaderBand reportHeaderBand = (ReportHeaderBand)report.Bands.GetBandByType(typeof(ReportHeaderBand));
            if (reportHeaderBand != null)
            {

                XRPanel xrPanel = (XRPanel)reportHeaderBand.FindControl("xrInfoPanel", true);
                if (xrPanel != null)
                {
                    XRTable xrTable = new XRTable();
                    xrPanel.Controls.Add(xrTable);
                    xrTable.BeginInit();

                    //Company Name
                    XRTableRow companyNameRow = new XRTableRow();
                    companyNameRow.Height = 30;
                    companyNameRow.Font = new Font(ClsParameter.FONT_FAMILY_NAME, 15, FontStyle.Bold);
                    companyNameRow.ForeColor = Color.Maroon;
                    xrTable.Rows.Add(companyNameRow);
                    XRTableCell companyNameCell = new XRTableCell();
                    companyNameCell.Text = ClsParameter.STRUCT_INFOLOGIN.CompanyName;
                    companyNameRow.Cells.Add(companyNameCell);

                    //Address
                    XRTableRow addressRow = new XRTableRow();
                    addressRow.Height = 30;
                    addressRow.Font = new Font(ClsParameter.FONT_FAMILY_NAME, 11, FontStyle.Bold);
                    addressRow.ForeColor = Color.Maroon;
                    xrTable.Rows.Add(addressRow);
                    XRTableCell addressCell = new XRTableCell();
                    addressCell.Text = ClsParameter.STRUCT_INFOLOGIN.Address;
                    addressRow.Cells.Add(addressCell);

                    //Tel
                    XRTableRow telRow = new XRTableRow();
                    telRow.Height = 30;
                    telRow.Font = new Font(ClsParameter.FONT_FAMILY_NAME, 11, FontStyle.Bold);
                    telRow.ForeColor = Color.Maroon;
                    xrTable.Rows.Add(telRow);
                    XRTableCell telCell = new XRTableCell();
                    telCell.Text = "DT: " + ClsParameter.STRUCT_INFOLOGIN.Tel;
                    telRow.Cells.Add(telCell);

                    //Fax
                    XRTableRow faxRow = new XRTableRow();
                    faxRow.Height = 30;
                    faxRow.Font = new Font(ClsParameter.FONT_FAMILY_NAME, 11, FontStyle.Bold);
                    faxRow.ForeColor = Color.Maroon;
                    xrTable.Rows.Add(faxRow);
                    XRTableCell faxCell = new XRTableCell();
                    faxCell.Text = "Fax: " + ClsParameter.STRUCT_INFOLOGIN.Fax;
                    faxRow.Cells.Add(faxCell);

                    //Tax
                    XRTableRow taxRow = new XRTableRow();
                    taxRow.Height = 30;
                    taxRow.Font = new Font(ClsParameter.FONT_FAMILY_NAME, 11, FontStyle.Bold);
                    taxRow.ForeColor = Color.Maroon;
                    xrTable.Rows.Add(taxRow);
                    XRTableCell taxCell = new XRTableCell();
                    taxCell.ForeColor = Color.Maroon;
                    taxCell.Text = "MST: " + ClsParameter.STRUCT_INFOLOGIN.Tax;
                    taxRow.Cells.Add(taxCell);

                    xrTable.EndInit();
                }
            }
        }
        public static void buildSubreportIN000(XtraReport report, DataTable dt)
        {
            /*
             * Dungnv   :   06/03/2015
             * Purpose  :   Build Subreport
             */

            ReportHeaderBand reportHeaderBand = (ReportHeaderBand)report.Bands.GetBandByType(typeof(ReportHeaderBand));
            if (reportHeaderBand != null)
            {

                XRSubreport subReport = (XRSubreport)reportHeaderBand.FindControl("SubReportIN000", true);
                if (subReport != null)
                {
                    subReport.ReportSource.DataSource = dt;
                }

            }
        }

        public static void buildSubreportInfoCompany(XtraReport report, DataTable dt)
        {
            /*
             * Dungnv   :   06/03/2015
             * Purpose  :   Build Subreport
             */

            ReportHeaderBand reportHeaderBand = (ReportHeaderBand)report.Bands.GetBandByType(typeof(ReportHeaderBand));
            if (reportHeaderBand != null)
            {

                XRSubreport subReport = (XRSubreport)reportHeaderBand.FindControl("SubReport_InfoCompany", true);
                if (subReport != null)
                {
                    subReport.ReportSource.DataSource = dt;
                }

            }
        }

        public static void buildSubreportCustomer(XtraReport report, DataTable dt)
        {
            /*
             * Dungnv   :   06/03/2015
             * Purpose  :   Build Subreport
             */

            ReportHeaderBand reportHeaderBand = (ReportHeaderBand)report.Bands.GetBandByType(typeof(ReportHeaderBand));
            if (reportHeaderBand != null)
            {

                XRSubreport subReport = (XRSubreport)reportHeaderBand.FindControl("SubReport_CF000", true);
                if (subReport != null)
                {
                    subReport.ReportSource.DataSource = dt;
                }

            }
        }
    }
}
