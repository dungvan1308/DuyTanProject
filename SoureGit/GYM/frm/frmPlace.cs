using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using GYM.Common;
using System.IO;
using System.Collections;
using GYM.ServiceReferenceDuyTan;

namespace GYM.frm
{
    public partial class frmPlace : DevExpress.XtraEditors.XtraForm
    {

        public string strMode = "";
        public string strCode = "0";
        public frmPlace()
        {
            InitializeComponent();
        }

        private void frmPlace_Load(object sender, EventArgs e)
        {
            /*
             * Dungnv : 10.11.2017
             */
 
            

            try
            {
                //Load city 
                ClsCommonProcess.lookUpCity(lookUpCity);

                switch (strMode)
                {
                    case ClsParameter.MODE_VIEW:
                        loadPlace(Int32.Parse(strCode));
                        bttSave.Visible = false;
                        bttNext.Visible = false;
                        disableControl(true);

                        break;
                    case ClsParameter.MODE_UPDATE:
                        loadPlace(Int32.Parse(strCode));
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {


            }


        }

        private void lookUpCity_Leave(object sender, EventArgs e)
        {
        

        }

        private void lookUpCity_Click(object sender, EventArgs e)
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

        private void lookUpDistrict_Click(object sender, EventArgs e)
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

        private void lookUpCity_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            /*
         * Dungnv : 10.11.2017
         */

            //Load quan huyen 
            string strCity = "";
            strCity = lookUpCity.EditValue.ToString();
            //Load quan huyen 
            ClsCommonProcess.lookUpDistrict(lookUpDistrict, strCity);
        }

        private void bttExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool checkValidate()
        {
            /*
             * Dungnv : 31.10.2017
             */

            return true;
        }

        private void bttSave_Click(object sender, EventArgs e)
        {
            /*
             * Dungnv : 10.11.2017
             */
 
            bool bConfirm = false;
            if (checkValidate() == false)
            {
                return;
            }


            PlaceObject obj = new PlaceObject();
            Double dbNum = 0;
            int outInt =0;

            try
            {

                 Int32.TryParse(this.strCode, out outInt);
                 obj.PlaceID = outInt;
                obj.Address = txtAddress.Text;
                
                obj.CreateBy = ClsParameter.STRUCT_INFOLOGIN.UserId;
                obj.OfDuyTan = checkEditOfDuyTan.Checked;
                obj.DistanceDuyTan = Double.Parse(txtDistanceDuyTan.Text);

                if(lookUpDistrict.EditValue !=null)
                {
                    obj.DistrictID = lookUpDistrict.EditValue.ToString();
                }
                else
                {
                    obj.DistrictID = "";
                }

                if (lookUpCity.EditValue != null)
                {
                    obj.CityID = lookUpCity.EditValue.ToString();
                }
                else
                {
                    obj.CityID = "";
                }

            

                Double.TryParse(txtGpsX.Text, out dbNum);
                obj.GpsX = dbNum;

                Double.TryParse(txtGpsY.Text, out dbNum);
                obj.GpsY = dbNum;

                obj.ModifyBy = ClsParameter.STRUCT_INFOLOGIN.UserId;
                obj.Name = txtPlaceName.Text;

                obj.TimeDuyTan = Double.Parse(txtTimeDuyTan.Text);


                bConfirm = ClsCommonProcess.confirmYesNo(ClsParameter.MSG_QUESTION_SAVE);
                if (bConfirm == true)
                {

                    WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();

                    switch (strMode)
                    {
                        case ClsParameter.MODE_UPDATE:
                        case ClsParameter.MODE_ADD:
                            if (ws.insertUpdatePlace(obj))
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
            catch(Exception ex)
            {

            }

            





        }

        private void loadPlace(int Id)
        {
            /*
             * Dungnv : 05/11/2017
             * Purpose: Load thong tin Trust 
             */
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();
            PlaceObject obj = new PlaceObject();
            try
            {
                obj = ws.selectPlace(Id);

                if (obj != null)
                {
                    txtAddress.Text = obj.Address;
                    txtDistanceDuyTan.Text = obj.DistanceDuyTan.ToString();
                    txtGpsX.Text = obj.GpsX.ToString();
                    txtGpsY.Text = obj.GpsY.ToString();
                    txtPlaceName.Text = obj.Name;
                    txtTimeDuyTan.Text = obj.TimeDuyTan.ToString();
                    lookUpCity.EditValue = obj.CityID;
                    checkEditOfDuyTan.EditValue = obj.OfDuyTan;



                    //Load quan huyen 
                    ClsCommonProcess.lookUpDistrict(lookUpDistrict, obj.CityID);
                    lookUpDistrict.EditValue = obj.DistrictID;

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void disableControl(bool bFalse)
        {

            txtAddress.Properties.ReadOnly = bFalse;
            txtDistanceDuyTan.Properties.ReadOnly = bFalse;
            txtGpsX.Properties.ReadOnly = bFalse;
            txtGpsY.Properties.ReadOnly = bFalse;
            txtPlaceName.Properties.ReadOnly = bFalse;
            txtTimeDuyTan.Properties.ReadOnly = bFalse;
            lookUpDistrict.Properties.ReadOnly = bFalse;
            lookUpCity.Properties.ReadOnly = bFalse;
        }
    }
}