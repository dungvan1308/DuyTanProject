using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GYM.Common;
using GYM.ServiceReferenceDuyTan;
using System.Globalization;
using DevExpress.XtraEditors.Repository;


namespace GYM.frm
{
    public partial class frmJourney : DevExpress.XtraEditors.XtraForm
    {
        public string strMode = "";
        public frmJourney()
        {
            InitializeComponent();
            
        }

        private void frmJourney_Load(object sender, EventArgs e)
        {
            /*
             * Dungnv : 18/12/2017
             */

            //Load thong tin LookUp
            ClsCommonProcess.lookUpPlace(searchLookUpDeliveryPlace1);
            ClsCommonProcess.lookUpPlace(searchLookUpDeliveryPlace2);
            ClsCommonProcess.lookUpPlace(searchLookUpDeliveryPlace3);
            ClsCommonProcess.lookUpTrust(searchLookUpTrust);
            ClsCommonProcess.lookUpEmp(searchLookUpEmp1);
            ClsCommonProcess.lookUpEmp(searchLookUpEmp2);
            ClsCommonProcess.lookUpDriver(lookUpDriver);

            getlistCurrentJourney();
           
            
        }

        private void searchLookUpDeliveryPlace1_Click(object sender, EventArgs e)
        {
            try
            {
                ClsCommonProcess.changeButtonSearchClear(sender, e, imgLst);

            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void searchLookUpDeliveryPlace2_Click(object sender, EventArgs e)
        {
            try
            {
                ClsCommonProcess.changeButtonSearchClear(sender, e, imgLst);

            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void searchLookUpDeliveryPlace3_Click(object sender, EventArgs e)
        {
            try
            {
                ClsCommonProcess.changeButtonSearchClear(sender, e, imgLst);

            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void searchLookUpTrust_Click(object sender, EventArgs e)
        {
            try
            {
                ClsCommonProcess.changeButtonSearchClear(sender, e, imgLst);

            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void lookUpDriver_Click(object sender, EventArgs e)
        {
            try
            {
                ClsCommonProcess.changeButtonSearchClear(sender, e, imgLst);

            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void searchLookUpEmp1_Click(object sender, EventArgs e)
        {
            try
            {
                ClsCommonProcess.changeButtonSearchClear(sender, e, imgLst);

            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void searchLookUpEmp2_Click(object sender, EventArgs e)
        {
            try
            {
                ClsCommonProcess.changeButtonSearchClear(sender, e, imgLst);

            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void bttSave_Click(object sender, EventArgs e)
        {
            /*
             * Dungnv : 19/12/2017
             */

            bool bConfirm = false;
            if (checkValidate() == false)
            {
                return;
            }

            //Set information 
            JourneyObject obj = new JourneyObject();
            setObj(ref obj);


            bConfirm = ClsCommonProcess.confirmYesNo(ClsParameter.MSG_QUESTION_SAVE);
            if (bConfirm == true)
            {

                WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();

                switch (strMode)
                {
                    case ClsParameter.MODE_UPDATE:
                    case ClsParameter.MODE_ADD:
                        if (ws.insertUpdateJourney(obj))
                        {

                            if (strMode == ClsParameter.MODE_ADD)
                            {
                                ClsCommonProcess.msg(ClsParameter.MSG_ADD_SUCCESSFULL);
                                bttSave.Enabled = false;
                            }
                            else
                            {
                                ClsCommonProcess.msg(ClsParameter.MSG_UPDATE_SUCCESSFULL);
                                this.Close();
                            }

                            getlistCurrentJourney();
                            return;

                        }
                        else
                        {
                            ClsCommonProcess.msgError(ClsParameter.MSG_ADD_FAIL);
                            return;
                        }
                    default:
                        break;
                }
            }
        }

        private bool checkValidate()
        {
            /*
             * Dungnv : 31.10.2017
             */

            return true;
        }
        private void setObj(ref JourneyObject obj)
        {
            /*
             * Dungnv : 19.12.2017
             * Purpose: Set value 
             */

           // obj.ArrivalTime1 = timeEdit1.
            //DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt")
            int iOut =0;

            
            obj.ArrivalTimePlan1 = DateTime.Parse(ArrivalTimePlan1.Text);
            //obj.ArrivalTimePlan2 = DateTime.ParseExact(ArrivalTimePlan2.Text, "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            obj.ArrivalTimePlan2 = DateTime.Parse(ArrivalTimePlan2.Text);

            obj.ArrivalTimePlan3 = DateTime.Parse(ArrivalTimePlan3.Text);
            obj.StartGoHomePlan = DateTime.Parse(StartTimePlan2.Text); // Thoi gian di ve cung chi la thoi gian 
            

            obj.StartTimePlan1 = DateTime.Parse(StartTimePlan1.Text);
            obj.StartTimePlan2 = DateTime.Parse(StartTimePlan2.Text);
            obj.StartTimePlan3 = DateTime.Parse(StartTimePlan3.Text);


            obj.ArrivalTime1 = DateTime.Parse("01/01/2000");
            obj.ArrivalTime2 = DateTime.Parse("01/01/2000");
            obj.ArrivalTime3 = DateTime.Parse("01/01/2000");
            obj.StartGoHome = DateTime.Parse("01/01/2000"); ;
            obj.StartGoHomePlan = DateTime.Parse("01/01/2000"); ;
            obj.StartTime1 = DateTime.Parse("01/01/2000"); ;
            obj.StartTime2 = DateTime.Parse("01/01/2000");
            obj.StartTime3 = DateTime.Parse("01/01/2000"); 
            obj.TimeGoHome = DateTime.Parse("01/01/2000");



            if (searchLookUpDeliveryPlace1.EditValue!=null)
            {
                Int32.TryParse(searchLookUpDeliveryPlace1.EditValue.ToString(), out iOut);
                obj.DeliveryPlace1 = iOut;
            }
            else
            {
                obj.DeliveryPlace1 = -1;
            }

            if (searchLookUpDeliveryPlace2.EditValue!=null)
            {
                Int32.TryParse(searchLookUpDeliveryPlace2.EditValue.ToString(), out iOut);
                obj.DeliveryPlace2 = iOut;
            }
            else
            {
                obj.DeliveryPlace2 = -1;
            }

           
            if(searchLookUpDeliveryPlace3!=null)
            {
                Int32.TryParse(searchLookUpDeliveryPlace3.EditValue.ToString(), out iOut);
                obj.DeliveryPlace3 = iOut;
            }
            else
            {
                obj.DeliveryPlace3 = -1;
            }


            if(searchLookUpEmp1.EditValue!=null)
            {
                Int32.TryParse(searchLookUpEmp1.EditValue.ToString(), out iOut);
                obj.Employee1 = iOut;
            }
            else
            {
                obj.Employee1 = -1;
            }

            
            if(searchLookUpEmp2.EditValue!=null)
            {
                Int32.TryParse(searchLookUpEmp2.EditValue.ToString(), out iOut);
                obj.Employee2 = iOut;
            }
            else
            {

                obj.Employee2 = -1;
            }
            

            obj.CreateBy = ClsParameter.STRUCT_INFOLOGIN.UserId;
            



 
        }
        private void loadObj(JourneyObject obj)
        {
            /*
             * Dungnv : Load du lieu
             */
 
            try
            {
                if(obj!=null)
                {
                    searchLookUpDeliveryPlace1.EditValue = obj.DeliveryPlace1;
                    searchLookUpDeliveryPlace2.EditValue = obj.DeliveryPlace2;
                    searchLookUpDeliveryPlace3.EditValue = obj.DeliveryPlace3;

                    searchLookUpEmp1.EditValue = obj.Employee1;
                    searchLookUpEmp2.EditValue = obj.Employee2;
                    


                }
            }
            catch(Exception ex)
            {

            }
        }

        
        //private void InitGridControl()
        //{
        //    /*
        //     *  Dungnv  :   25/11/2017
        //     *  Purpose :   Khoi tao luoi GridControl 
        //     */

        //    try
        //    {
        //        DataTable dt = new DataTable();

        //        dt.Columns.Add(new DataColumn("g_STT", Type.GetType("System.String")));
        //        dt.Columns.Add(new DataColumn("g_JourneyDate", Type.GetType("System.DateTime")));
        //        dt.Columns.Add(new DataColumn("g_VehicleNumber", Type.GetType("System.String")));
        //        dt.Columns.Add(new DataColumn("g_DriverName", Type.GetType("System.String")));
        //        dt.Columns.Add(new DataColumn("g_Employee1", Type.GetType("System.String")));
        //        dt.Columns.Add(new DataColumn("g_Employee2", Type.GetType("System.String")));
        //        dt.Columns.Add(new DataColumn("g_StartPlace", Type.GetType("System.String")));
        //        dt.Columns.Add(new DataColumn("g_StartTime1", Type.GetType("System.String")));
        //        dt.Columns.Add(new DataColumn("g_DeliveryPlace1", Type.GetType("System.String")));
        //        dt.Columns.Add(new DataColumn("g_ArrivalTimePlan1", Type.GetType("System.DateTime")));
        //        dt.Columns.Add(new DataColumn("g_StartTime2", Type.GetType("System.String")));
        //        dt.Columns.Add(new DataColumn("g_DeliveryPlace2", Type.GetType("System.String")));
        //        dt.Columns.Add(new DataColumn("g_ArrivalTimePlan2", Type.GetType("System.DateTime")));
        //        dt.Columns.Add(new DataColumn("g_StartTime3", Type.GetType("System.DateTime")));
        //        dt.Columns.Add(new DataColumn("g_DeliveryPlace3", Type.GetType("System.String")));
        //        dt.Columns.Add(new DataColumn("g_ArrivalTimePlan3", Type.GetType("System.DateTime")));

        //        dt.Columns.Add(new DataColumn("g_TimeGoHome", Type.GetType("System.DateTime")));
        //        dt.Columns.Add(new DataColumn("g_Status", Type.GetType("System.String")));

        //        dt.Columns.Add(new DataColumn("g_Gate", Type.GetType("System.String")));

        //        dt.Columns.Add(new DataColumn("g_Start", Type.GetType("System.String")));

        //        dt.Columns["g_STT"].Caption = "STT";
        //        dt.Columns["g_JourneyDate"].Caption = "Ngày hành trình";
        //        dt.Columns["g_VehicleNumber"].Caption = "Số xe";
        //        dt.Columns["g_DriverName"].Caption = "Tài xế";
        //        dt.Columns["g_Employee1"].Caption = "Giao hàng 1";
        //        dt.Columns["g_Employee2"].Caption = "Giao hàng 2";
        //        dt.Columns["g_StartPlace"].Caption = "Điểm xuất phát";
        //        dt.Columns["g_StartTime1"].Caption = "Thời gian đi";
        //        dt.Columns["g_DeliveryPlace1"].Caption = "Điểm giao hàng 1";

        //        dt.Columns["g_ArrivalTimePlan1"].Caption = "Thời gian KH 1";
        //        dt.Columns["g_StartTime2"].Caption = "Thời gian đi 2";
        //        dt.Columns["g_DeliveryPlace2"].Caption = "Điểm giao hàng 2";
        //        dt.Columns["g_ArrivalTimePlan2"].Caption = "Thời gian KH 2";
        //        dt.Columns["g_StartTime3"].Caption = "Thời gian đi 3";
        //        dt.Columns["g_DeliveryPlace3"].Caption = "Điểm giao hàng 3";
        //        dt.Columns["g_ArrivalTimePlan3"].Caption = "Thời gian KH 3";

        //        dt.Columns["g_TimeGoHome"].Caption = "Thời gian về";
        //        dt.Columns["g_Status"].Caption = "Trạng thái giao hàng ";
        //        dt.Columns["g_Gate"].Caption = "Cổng";
        //        dt.Columns["g_Start"].Caption = "Bắt đầu";



        //        gridControlMain.DataSource = dt;

        //        dtgResult.PopulateColumns();
        //        RepositoryItemButtonEdit ritem = new RepositoryItemButtonEdit();
        //        ritem.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
        //        ritem.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;
        //        //ritem.Buttons[0].Image = Resources.Cancel.ToBitmap();
        //        gridControlMain.RepositoryItems.Add(ritem);
        //        //ritem.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(deleteRow);

                
        //        dtgResult.Columns["g_Start"].ColumnEdit = ritem;


        //        dtgResult.Columns["g_JourneyDate"].Width = 100;
        //        dtgResult.Columns["g_JourneyDate"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        //        dtgResult.Columns["g_JourneyDate"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

        //        dtgResult.Columns["g_VehicleNumber"].Width = 100;
        //        dtgResult.Columns["g_VehicleNumber"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        //        dtgResult.Columns["g_VehicleNumber"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;


        //        dtgResult.Columns["g_Start"].Width = 80;
        //        dtgResult.Columns["g_Start"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                
 

        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //}


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
                dtgResult.Columns[14].DisplayFormat.FormatString="dd/MM/yyyy hh:mm:ss";

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

        private void dtgResult_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            /*
           * Dungnv   :   26.12.2017
           * Purpose  :   Change color for row 
           */
            int iRow = 0;
            string strValue = "";
            try
            {
                if (e.RowHandle >= 0)
                {
                    iRow = e.RowHandle;
                    strValue = dtgResult.GetRowCellValue(iRow, "STATUS").ToString().Trim();

                    switch (strValue)
                    {
                        case "0":
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Blue;
                            break;
                        case "1":
                            e.Appearance.BackColor = Color.LightBlue;
                            e.Appearance.ForeColor = Color.Green;
                            break;
                        case "2":
                              e.Appearance.BackColor = Color.GreenYellow;
                            e.Appearance.ForeColor = Color.HotPink;
                            break;
                        default:
                            e.Appearance.BackColor = Color.Violet;
                            e.Appearance.ForeColor = Color.Red;
                            break;
                    }

                    
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void bttNext_Click(object sender, EventArgs e)
        {
            bttSave.Enabled = true;
        }

        
    }
}