using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress;
using DevExpress.XtraExport;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Parameters;
using GYM.ServiceReferenceDuyTan;
using GYM.Common;
using System.Collections;

namespace GYM.frm
{
    public partial class frmReportParameters : DevExpress.XtraEditors.XtraForm
    {
        public ArrayList arrPara = new ArrayList();
        public string strReportName = "";

        public frmReportParameters()
        {
            InitializeComponent();
        }

        private void frmReportParameters_Load(object sender, EventArgs e)
        {
            /*
             * Dungnv   :   04/01/2014
             * Purpose  :   Hien thi Control 
             */

            for (int i = 0; i < arrPara.Count; i++)
            {
                ReportParaObject objStruct = new ReportParaObject();
                objStruct = (ReportParaObject)(arrPara[i]);

                //Add label 
                Label labelPara = new Label();
                labelPara.AutoSize = true;
                labelPara.Location = new Point(26, 30 + i * 25);
                labelPara.Name = "Label" + i.ToString();
                labelPara.Text = objStruct.PARA_CONTENT.Trim();
                labelPara.Size = new Size(46, 13);
                labelPara.TabIndex = i;

                grbInfor.Controls.Add(labelPara);

                //Add Maskbox

                switch (objStruct.PARA_TYPE.Trim().ToUpper())
                {
                    case "MASKBOX":
                        MaskedTextBox mskPara = new MaskedTextBox();
                        mskPara.Location = new Point(170, 27 + i * 25);
                        mskPara.Name = objStruct.PARA_NAME.Trim();
                        mskPara.Size = new Size(142, 20);
                        mskPara.TabIndex = i;
                        mskPara.Tag = objStruct.PARA_NAME.Trim();
                        //Dungnv : 22/03/2010
                        if (objStruct.MASK.ToString().Trim() != "")
                        {
                            mskPara.Mask = objStruct.MASK.ToString().Trim();
                        }
                        //End Dungvn : 22/03/2010
                        grbInfor.Controls.Add(mskPara);

                        break;
                    case "TEXTBOX":
                        TextBox txtPara = new TextBox();
                        txtPara.Location = new Point(170, 27 + i * 25);
                        txtPara.Name = objStruct.PARA_NAME.Trim();
                        txtPara.Size = new Size(142, 20);
                        txtPara.TabIndex = i;
                        txtPara.Tag = objStruct.PARA_NAME.Trim();
                        grbInfor.Controls.Add(txtPara);
                        break;
                    case "COMBOBOX":
                        System.Windows.Forms.ComboBox cboPara = new System.Windows.Forms.ComboBox();
                        cboPara.Location = new Point(170, 27 + i * 25);
                        cboPara.Name = objStruct.PARA_NAME.Trim();
                        cboPara.Size = new Size(142, 20);
                        cboPara.TabIndex = i;
                        cboPara.Tag = objStruct.PARA_NAME.Trim();

                        ClsCommonProcess.loadCombobox(cboPara, cboPara.Name, "RPTPARA");
                        grbInfor.Controls.Add(cboPara);
                        break;
                    case "SEARCHLOOKUPEDIT":
                        SearchLookUpEdit searchLookObject = new SearchLookUpEdit();
                        searchLookObject.Location = new Point(170, 27 + i * 25);
                        searchLookObject.Name = objStruct.PARA_NAME.Trim();
                        searchLookObject.Size = new Size(142, 20);
                        searchLookObject.TabIndex = i;
                        searchLookObject.Tag = objStruct.PARA_NAME.Trim();

                        searchLookObject.Click += new System.EventHandler(lookUpObject_Click);
                        grbInfor.Controls.Add(searchLookObject);

                        //Load thong tin 
                        switch (searchLookObject.Name)
                        {
                           
                            case ClsParameter.PARA_EMPLOYEEID:
                                ClsCommonProcess.lookUpEmp(searchLookObject);
                                break;
                         
                        }

                        break;
                    case "DATEEDIT":
                        DateEdit date = new DateEdit();
                        date.Location = new Point(170, 27 + i * 25);
                        date.Name = objStruct.PARA_NAME.Trim();
                        date.Size = new Size(142, 20);
                        date.TabIndex = i;
                        date.Tag = objStruct.PARA_NAME.Trim();
                        grbInfor.Controls.Add(date);
                        break;

                    default: //TEXTBOX 
                        break;
                }

                //Doi groupbox 

                grbInfor.Height = grbInfor.Height + i * 25;
                grpAction.Top = grpAction.Top + i * 25;
                this.Height = this.Height + i * 25;
            }
        }
        private void lookUpObject_Click(object sender, EventArgs e)
        {
            /*
             * Dungnv   :   23/11/2015
             * Purpose  :   Change text 
             */
            ClsCommonProcess.changeButtonSearchClear(sender, e, imgLst);
        }

        private void bttView_Click(object sender, EventArgs e)
        {
            /*
             * Dungnv   :   23/11/2015
             * Purpose  :   Show report
             */
            ClsCommonReport.viewReport(buildParameters(), strReportName);
        }

        private ReportObjects buildParameters()
        {
            ReportObjects reportObjects = new ReportObjects();
            ArrayList reportParameters = new ArrayList();
            for (int i = 0; i < arrPara.Count; i++)
            {
                ReportParaObject objStruct = (ReportParaObject)(arrPara[i]);
                Control[] controls = grbInfor.Controls.Find(objStruct.PARA_NAME.Trim(), true);
                if (controls != null && controls.Length > 0)
                {
                    string value = "";
                    if (controls[0] is TextBox)
                    {
                        value = controls[0].Text;
                    }
                    else if (controls[0] is System.Windows.Forms.ComboBox)
                    {
                        System.Windows.Forms.ComboBox cbbox = (System.Windows.Forms.ComboBox)controls[0];
                        value = ((ComboboxItem)cbbox.SelectedItem).Value.ToString();
                    }
                    else if (controls[0] is MaskedTextBox)
                    {
                        value = controls[0].Text;
                    }
                    else if (controls[0] is SearchLookUpEdit)
                    {
                        SearchLookUpEdit searchLookupEdit = (SearchLookUpEdit)controls[0];
                        try
                        {
                            value = searchLookupEdit.EditValue.ToString();
                        }
                        catch (Exception e)
                        {
                            value = "";
                        }
                    }
                    else if (controls[0] is DateEdit)
                    {
                        DateEdit dateEdit = (DateEdit)controls[0];
                        value = dateEdit.Text.Trim();
                    }

                    ReportParaObject reportParameter = new ReportParaObject();
                    reportParameter.PARA_CONTENT = objStruct.PARA_CONTENT;
                    reportParameter.MASK = objStruct.MASK;
                    reportParameter.PARA_DBTYPE = objStruct.PARA_DBTYPE;
                    reportParameter.PARA_NAME = objStruct.PARA_NAME;
                    reportParameter.PARA_SIZE = objStruct.PARA_SIZE;
                    reportParameter.PARA_TYPE = objStruct.PARA_TYPE;
                    reportParameter.PARA_VALUE = value;
                    reportParameters.Add(reportParameter);

                }
            }
            reportObjects.arrLst = reportParameters.ToArray();
            reportObjects.strReportName = strReportName;
            return reportObjects;
        }

        private void bttExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}