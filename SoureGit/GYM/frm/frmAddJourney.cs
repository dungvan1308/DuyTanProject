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
    public partial class frmAddJourney : DevExpress.XtraEditors.XtraForm
    {
        public string strMode;
        public frmAddJourney()
        {
            InitializeComponent();
        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

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

                            //getlistCurrentJourney();
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
            int iOut = 0;


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



            if (searchLookUpDeliveryPlace1.EditValue != null)
            {
                Int32.TryParse(searchLookUpDeliveryPlace1.EditValue.ToString(), out iOut);
                obj.DeliveryPlace1 = iOut;
            }
            else
            {
                obj.DeliveryPlace1 = -1;
            }

            if (searchLookUpDeliveryPlace2.EditValue != null)
            {
                Int32.TryParse(searchLookUpDeliveryPlace2.EditValue.ToString(), out iOut);
                obj.DeliveryPlace2 = iOut;
            }
            else
            {
                obj.DeliveryPlace2 = -1;
            }


            if (searchLookUpDeliveryPlace3 != null)
            {
                Int32.TryParse(searchLookUpDeliveryPlace3.EditValue.ToString(), out iOut);
                obj.DeliveryPlace3 = iOut;
            }
            else
            {
                obj.DeliveryPlace3 = -1;
            }


            if (searchLookUpEmp1.EditValue != null)
            {
                Int32.TryParse(searchLookUpEmp1.EditValue.ToString(), out iOut);
                obj.Employee1 = iOut;
            }
            else
            {
                obj.Employee1 = -1;
            }


            if (searchLookUpEmp2.EditValue != null)
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
                if (obj != null)
                {
                    searchLookUpDeliveryPlace1.EditValue = obj.DeliveryPlace1;
                    searchLookUpDeliveryPlace2.EditValue = obj.DeliveryPlace2;
                    searchLookUpDeliveryPlace3.EditValue = obj.DeliveryPlace3;

                    searchLookUpEmp1.EditValue = obj.Employee1;
                    searchLookUpEmp2.EditValue = obj.Employee2;



                }
            }
            catch (Exception ex)
            {

            }
        }

        private void bbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddJourney_Load(object sender, EventArgs e)
        {
            try
            {
                ClsCommonProcess.lookUpPlace(searchLookUpDeliveryPlace1);
                ClsCommonProcess.lookUpPlace(searchLookUpDeliveryPlace2);
                ClsCommonProcess.lookUpPlace(searchLookUpDeliveryPlace3);
                ClsCommonProcess.lookUpTrust(searchLookUpTrust);
                ClsCommonProcess.lookUpEmp(searchLookUpEmp1);
                ClsCommonProcess.lookUpEmp(searchLookUpEmp2);
                ClsCommonProcess.lookUpDriver(lookUpDriver);
                ClsCommonProcess.lookUpPlace(lookUpStartPlace);

            }
            catch(Exception ex)
            {

            }
            
        }
    }
}