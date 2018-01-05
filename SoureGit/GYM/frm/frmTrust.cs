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


namespace GYM.frm
{
    public partial class frmTrust : DevExpress.XtraEditors.XtraForm
    {
        public string strMode="";
        public string strCode = "";
        public frmTrust()
        {
            InitializeComponent();
        }

        private void frmTrust_Load(object sender, EventArgs e)
        {
            /*
             * Dungnv   : 13.10.2017
             * Purpose  : Load thong tin
             */

            try
            {
                //load Combobox 
                ClsCommonProcess.loadComboBoxEdit(cmbType, "TYPE", "TRUST");
                ClsCommonProcess.loadComboBoxEdit(cmbGroupTrust, "GROUPTRUST", "TRUST");

                switch (strMode)
                {
                    case ClsParameter.MODE_VIEW:
                        loadTrust(Int32.Parse(strCode));
                        bttSave.Visible = false;
                        bttNext.Visible = false;
                        disableControl(true);
                       
                        break;
                    case ClsParameter.MODE_UPDATE:
                        loadTrust(Int32.Parse(strCode));
                        break;
                    default:
                        break;
                }

            }
            catch(Exception ex) 
            { 

   
            }
           
        }

        private void bttSave_Click(object sender, EventArgs e)
        {
            /*
             * Dungnv : 18/10/2017
             */

            bool bConfirm = false;
            if (checkValidate() == false)
            {
                return;
            }


            TrustObject obj = new TrustObject();
            int Id = 0;
            Decimal dec = 0;
            int OutIn = 0;

            Int32.TryParse(this.strCode, out Id);


            obj.TrustID = Id;
            
            obj.Color = txtColor.Text;
            obj.CreateBy = ClsParameter.STRUCT_INFOLOGIN.UserId;
           
            obj.ExpireDate = DateTime.Parse(dateExpireDate.Text);
            obj.GroupTrust = ((ComboboxItem)cmbGroupTrust.SelectedItem).Value.ToString();
            obj.TrustName = txtTrustName.Text;
            obj.Type = ((ComboboxItem)cmbType.SelectedItem).Value.ToString();
            obj.VehicleNumber = txtVehicleNumber.Text;
            
            Decimal.TryParse(txtTotal.Text, out dec);
            obj.Total = dec;

            Int32.TryParse(txtSeatingNumber.Text, out OutIn);
            obj.SeatingNumber = OutIn;

            Int32.TryParse(txtCapicity.Text, out OutIn);
            obj.Total = dec;



            if (dateOfPurchase.Text.Trim() != String.Empty)
            {
                 obj.DateOfPurchase = Convert.ToDateTime(dateOfPurchase.Text.Trim());
            }
            else
            {
                obj.DateOfPurchase = Convert.ToDateTime("01/01/1900");
            }


            if (dateExpireDate.Text.Trim() != String.Empty)
            {
                obj.ExpireDate = Convert.ToDateTime(dateExpireDate.Text.Trim());
            }
            else
            {
                obj.ExpireDate = Convert.ToDateTime("01/01/1900");
            }



            bConfirm = ClsCommonProcess.confirmYesNo(ClsParameter.MSG_QUESTION_SAVE);
            if (bConfirm == true)
            {

                WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();
                    
                switch (strMode)
                {
                    case ClsParameter.MODE_UPDATE:
                    case ClsParameter.MODE_ADD:
                        if (ws.insertUpdateTrust(obj))
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

        private bool checkValidate()
        {
            /*
             * Dungnv : 31.10.2017
             */

            return true;
        }

        private void bttExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void loadTrust(int Id)
        {
            /*
             * Dungnv : 05/11/2017
             * Purpose: Load thong tin Trust 
             */
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();
            TrustObject obj = new TrustObject();
            try
            {
                obj = ws.selectTrust(Id);

                if(obj!=null)
                {
                    txtCapicity.Text = obj.Capicity.ToString();
                    txtColor.Text = obj.Color;
                    txtSeatingNumber.Text = obj.SeatingNumber.ToString();
                    txtTotal.Text = ClsCommonProcess.formartNumber(obj.Total.ToString());
                    txtTrustName.Text = obj.TrustName;
                    txtVehicleNumber.Text = obj.VehicleNumber;
                    ClsCommonProcess.selectedComboboxDexEx(cmbType, obj.Type);
                    ClsCommonProcess.selectedComboboxDexEx(cmbGroupTrust, obj.GroupTrust);

                }
            }
            catch(Exception ex)
            {

            }
        }

        private void disableControl(bool bFalse)
        {
            txtCapicity.ReadOnly = bFalse;
            txtColor.ReadOnly = bFalse;
            txtSeatingNumber.ReadOnly = bFalse;
            txtTotal.ReadOnly = bFalse;
            txtTrustName.ReadOnly = bFalse;
            txtVehicleNumber.ReadOnly = bFalse;
            dateExpireDate.ReadOnly = bFalse;
            dateOfPurchase.ReadOnly = bFalse;
            cmbGroupTrust.ReadOnly = bFalse;
            cmbType.ReadOnly = bFalse;

        }
    }
}