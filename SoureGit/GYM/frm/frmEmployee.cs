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
    public partial class frmEmployee : DevExpress.XtraEditors.XtraForm
    {
        public string strMode = "";
        public string strCode = "";

        public frmEmployee()
        {
            InitializeComponent();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            /*
             * Dungnv   :   04/11/2014
             * Purpose  :   Load thông tin cơ bản 
             */

            try
            {
                ClsCommonProcess.loadComboboxDevExTab("EMPLOYEE",tabPageInfo);
                ClsCommonProcess.lookUpCity(lookUpCity);
                ClsCommonProcess.lookUpCity(lookUpBirthPlace);
                ClsCommonProcess.lookUpCity(lookUpIdentityCardPlace);
                ClsCommonProcess.lookUpUser(lookUpUser);
                ClsCommonProcess.selectedComboboxDexEx(cmbStatus, ClsParameter.STATUS_VALUE_OPEN);
                
                initialize();
            }
            catch (Exception ex)
            {
                return;
            }

            //load thong tin khi Update-View 
            switch (strMode)
            {
                case ClsParameter.MODE_VIEW:
                case ClsParameter.MODE_UPDATE:
                    
                    break;
                default:
                    break;
            }

            if (strMode == ClsParameter.MODE_VIEW)
            {
                txtEmployeeId.Properties.ReadOnly = true;
                txtEmployeeName.Properties.ReadOnly = true;
                dateBirthday.Properties.ReadOnly = true;
                lookUpBirthPlace.Properties.ReadOnly = true;
                cmbStatus.Enabled = false;
                txtIdentityCard.Properties.ReadOnly = true;
                dateIdentityCard.Properties.ReadOnly = true;
                lookUpIdentityCardPlace.Properties.ReadOnly = true;
                cmbGender.Enabled = false;
                txtAddress.Properties.ReadOnly = true;
                lookUpCity.Properties.ReadOnly = true;
                txtPhone.Properties.ReadOnly = true;
                txtMobile.Properties.ReadOnly = true;
                cmbEducation.Enabled = false;
                cmbMaritalStatus.Enabled = false;
                cmbPosition.Enabled = false;
                txtSpecialize.Properties.ReadOnly = true;
                
              
                dateStartWork.Properties.ReadOnly = true;
              
              
                txtEmail.Properties.ReadOnly = true;
                bttNext.Visible = false;
                bttSave.Visible = false;

              

            }
        }
        private void initialize()
        {
            /*
             * Dungnv   :   13/11/2015
             * Purpose  :   Dungnv
             */
 
            txtEmployeeId.Text = "";
            txtEmployeeName.Text = "";
            dateBirthday.Text = "";
            lookUpBirthPlace.Text = "";
            txtIdentityCard.Text = "";
            dateIdentityCard.Text = "";
            lookUpIdentityCardPlace.Text = "";

            txtAddress.Text = "";
            lookUpCity.Text = "";
            txtPhone.Text = "";
            txtMobile.Text = "";
            txtSpecialize.Text = "";
            
            txtEmail.Text = "";
            
            dateStartWork.Text = "";


            ClsCommonProcess.selectedComboboxDexEx(cmbStatus, ClsParameter.STATUS_VALUE_OPEN);
            ClsCommonProcess.selectedComboboxDexEx(cmbLicenseType, "05");
            ClsCommonProcess.selectedComboboxDexEx(cmbPosition, "08");
            ClsCommonProcess.selectedComboboxDexEx(cmbGender, ClsParameter.GENDER_VALUE_MAN);
            ClsCommonProcess.selectedComboboxDexEx(cmbMaritalStatus, ClsParameter.MATERIAL_VALUE_SINGLE);
            ClsCommonProcess.selectedComboboxDexEx(cmbEducation, ClsParameter.EDUCATION_VALUE_BACHELOR);

            
            bttSave.Enabled = true;

        }
       
  
        private void bttSave_Click(object sender, EventArgs e)
        {
            /*
             * Dungnv   :   13/11/2015
             * Purpose  :   Luu thong Employee
             */
 
            bool bConfirm = false;
            if (checkValidate() == false)
            {
                return;
            }

            try
            {
                EmployeeObject objEmployee = new EmployeeObject();
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();
            string strId = "";
            int iOut = 0;

            Int32.TryParse(txtEmployeeId.Text.Trim(), out iOut);

            objEmployee.Id = iOut;
            objEmployee.Name = txtEmployeeName.Text.Trim();
            if(cmbStatus.SelectedItem!=null)
            {
                objEmployee.Status = ((ComboboxItem)cmbStatus.SelectedItem).Value.ToString();
            }
            else
            {
                objEmployee.Status = "";
            }
           
            objEmployee.BirthDay = Convert.ToDateTime(dateBirthday.Text.Trim());
            objEmployee.Identitycard = txtIdentityCard.Text.Trim();
            if (dateIdentityCard.Text.Trim() != String.Empty)
            {
                objEmployee.Identitycard_DateIssue = Convert.ToDateTime(dateIdentityCard.Text.Trim());
            }
            else
            {
                objEmployee.Identitycard_DateIssue = Convert.ToDateTime("01/01/1900");
            }

            if (cmbGender.SelectedItem!=null)
            {
                objEmployee.Gender = ((ComboboxItem)cmbGender.SelectedItem).Value.ToString();
            }
            else
            {
                objEmployee.Gender = "";
            }
            
            objEmployee.Address = txtAddress.Text.Trim();
            objEmployee.Phone = txtPhone.Text.Trim();
            objEmployee.Mobile = txtMobile.Text.Trim();

            if(cmbMaritalStatus.SelectedItem!=null)
            {
                 objEmployee.MaritalStatus = ((ComboboxItem)cmbMaritalStatus.SelectedItem).Value.ToString();
            }
            else
            {
                objEmployee.MaritalStatus ="";
            }

           if(cmbEducation.SelectedItem !=null)
           {
               objEmployee.Education = ((ComboboxItem)cmbEducation.SelectedItem).Value.ToString();
           }
           else
           {
               objEmployee.Education  ="";
           }
            
            if(cmbLicenseType.SelectedItem !=null)
            {
                objEmployee.LicenseType = ((ComboboxItem)cmbLicenseType.SelectedItem).Value.ToString();
            }
            else
            {
                objEmployee.Position ="";
            }

            if(cmbType.SelectedItem !=null)
            {
                objEmployee.Type = ((ComboboxItem)cmbType.SelectedItem).Value.ToString();
            }
            else
            {
                objEmployee.Type = "";
            }
            
            
            
            if(cmbPosition.SelectedItem!=null)
            {
                objEmployee.Position = ((ComboboxItem)cmbPosition.SelectedItem).Value.ToString();
            }
            else
            {
                objEmployee.Position = "";
            }
            
            
            objEmployee.Email = txtEmail.Text.Trim();

            try
            {
                objEmployee.Birth_Place = lookUpBirthPlace.EditValue.ToString();
                objEmployee.Identitycard_PlaceIssue = lookUpIdentityCardPlace.EditValue.ToString();
                objEmployee.CityId = lookUpCity.EditValue.ToString();
                objEmployee.UserID = lookUpUser.EditValue.ToString();
            }
            catch (Exception ex)
            {
                objEmployee.Birth_Place = "";
                objEmployee.Identitycard_PlaceIssue = "";
                objEmployee.CityId = "";
                objEmployee.UserID = "";

            }

            
            bConfirm = ClsCommonProcess.confirmYesNo(ClsParameter.MSG_QUESTION_SAVE);
            if (bConfirm == true)
            {
                switch (strMode)
                {
                    case ClsParameter.MODE_UPDATE:
                    case ClsParameter.MODE_ADD:
                        if (ws.insertUpdateEmployee(out strId, objEmployee))
                        {
                            if (strId == ClsParameter.OBJECT_EXIST_CODE)
                            {
                                ClsCommonProcess.msgError(ClsParameter.MSG_EMPLOYEE_NAME_EXIST);
                                txtEmployeeName.Text = "";
                                txtEmployeeName.Focus();
                                return;
                            }
                            else
                            {
                                txtEmployeeId.Text = strId;
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

                        }
                        else
                        {
                            ClsCommonProcess.msgError(ClsParameter.MSG_ADD_FAIL);
                            return;
                        }
                    default:
                        break;
                }}
            }
            catch(Exception ex)
            {

            }
            

            
        }
        private bool checkValidate()
        {
            /*
             *  Dungnv  :   13/11/2015
             *  Purpose :   Check Validate
             */
  

            if (txtEmployeeName.Text.Trim() == "")
            {
                ClsCommonProcess.msgError(ClsParameter.MSG_EMPLOYEE_NAME_EMPTY);
                txtEmployeeName.Focus();
                return false;
            }

            if (dateBirthday.Text.Trim() == "")
            {
                ClsCommonProcess.msgError(ClsParameter.MSG_EMPLOYEE_BIRTH_DAY_EMPTY);
                //dateBirthday.Focus();
                return false;
            }

            if (dateBirthday.DateTime > DateTime.Now)
            {
                ClsCommonProcess.msgError(ClsParameter.MSG_EMPLOYEE_BIRTH_DAY_INVALID);
                //dateBirthday.Focus();
                return false;
            }

            if (dateIdentityCard.DateTime > DateTime.Now)
            {
                ClsCommonProcess.msgError(ClsParameter.MSG_EMPLOYEE_ID_CARD_DAY_NOW_INVALID);
                //dateBirthday.Focus();
                return false;
            }

            if (dateIdentityCard.Text != "" && dateIdentityCard.DateTime < dateBirthday.DateTime)
            {
                ClsCommonProcess.msgError(ClsParameter.MSG_EMPLOYEE_ID_CARD_DAY_INVALID);
                //dateIdentityCard.Focus();
                return false;
            }

        
            return true;

        }
        private void bttNext_Click(object sender, EventArgs e)
        {
            /*
             * Dungnv   :   13/11/2015
             * Purpose  :   Reset 
             */
 
            initialize();
        }
    
     

        private void bttExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
             * Dungnv   :   12/06/2016
             * Purpose  :   Khong cho nhap so 
             */
            ClsCommonProcess.textBox_keyPress(sender, e);
        }

        private void txtMobile_Properties_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
             * Dungnv   :   12/06/2016
             * Purpose  :   Khong cho nhap so 
             */
            ClsCommonProcess.textBox_keyPress(sender, e);
        }

        private void loadEmployee(int ID)
        {
            
            WebServiceDuyTanSoapClient ws = new WebServiceDuyTanSoapClient();
                    EmployeeObject objEmployee = new EmployeeObject();
                    try
                    {
                        objEmployee = ws.selectEmployee(ID);
                        txtEmployeeId.Text = objEmployee.Id.ToString();
                        txtEmployeeName.Text = objEmployee.Name;
                        ClsCommonProcess.selectedComboboxDexEx(cmbStatus, objEmployee.Status);
                        dateBirthday.DateTime = objEmployee.BirthDay;
                        txtIdentityCard.Text = objEmployee.Identitycard;
                        dateIdentityCard.DateTime = objEmployee.Identitycard_DateIssue;
                        ClsCommonProcess.selectedComboboxDexEx(cmbGender, objEmployee.Gender);
                        txtAddress.Text = objEmployee.Address;
                        txtPhone.Text = objEmployee.Phone;
                        txtMobile.Text = objEmployee.Mobile;
                        ClsCommonProcess.selectedComboboxDexEx(cmbMaritalStatus, objEmployee.MaritalStatus);
                        ClsCommonProcess.selectedComboboxDexEx(cmbEducation, objEmployee.Education);
                        ClsCommonProcess.selectedComboboxDexEx(cmbPosition, objEmployee.Position);

                        
                        txtEmail.Text = objEmployee.Email;

                        lookUpBirthPlace.EditValue = objEmployee.Birth_Place;
                        lookUpIdentityCardPlace.EditValue = objEmployee.Identitycard_PlaceIssue;
                        lookUpCity.EditValue = objEmployee.CityId;

                        bttNext.Visible = false;

                    }
                    catch (Exception ex)
                    {
                    }
        }
    }
}