using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App.Core;
using App.Business;
using App.BusinessModel;


namespace AASGWeb.Modules.Admin
{
    public partial class add_employee : System.Web.UI.Page
    {
        #region Global Properties
        ActivityLog _objActivityLog = new ActivityLog();
        ActivityLogBL _objActivityLogBL = null;
        List<ActivityLog> _lstActivityLog = new List<ActivityLog>();

        App.BusinessModel.StaffMaster _objStaffMaster = new App.BusinessModel.StaffMaster();
        App.Business.StaffMasterBL _objStaffMasterBL = null;
        List<App.BusinessModel.StaffMaster> _lstStaffMaster = new List<App.BusinessModel.StaffMaster>();


        string UserIp = string.Empty;
        string[] FileNameFile;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
           // Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                BindDropdownMaster();
                BindTourGradeMaster();
                BindUserRole();
                string _staffid;
                if (RouteData.Values["id"] == null)
                {
                    // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "editorInit();", true);
                }
                else
                {

                    string staff_master_id = RouteData.Values["id"].ToString();
                    _staffid = App.Core.DataSecurity.Decryptdata(staff_master_id);
                    if (_staffid == "" || _staffid == null)
                    {
                        Response.Redirect("/home", false);
                    }
                    else
                    {
                        hdnId.Value = _staffid;

                        if (hdnId.Value == "")
                        {
                            Response.Redirect("/home", false);

                        }
                        else
                        {
                            PopulateData(_staffid);
                        }

                    }


                }
            }
        }
        private void BindDropdownMaster()
        {
            try
            {
                List<DropdownMaster> _lstDropdownMaster = new List<DropdownMaster>();
                DropdownMasterBL _objDropdownMasterBL = new DropdownMasterBL();

                _lstDropdownMaster = _objDropdownMasterBL.GetAllDropdownMasterItems().Where(x => x.dropdown_type == "Designation").ToList();

                ddlDesignation.DataSource = _lstDropdownMaster;

                ddlDesignation.DataTextField = "dropdown_item_name";
                ddlDesignation.DataValueField = "dropdown_master_id";
                ddlDesignation.DataBind();
                ddlDesignation.Items.Insert(0, new ListItem("Select", "Select"));

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }
        private void BindTourGradeMaster()
        {
            try
            {
                List<TourGradeMaster> _lstTourGradeMaster = new List<TourGradeMaster>();
                TourGradeMasterBL _objTourGradeMasterBL = new TourGradeMasterBL();

                _lstTourGradeMaster = _objTourGradeMasterBL.GetAllTourGradeMasterItems().ToList();

                ddlGrade.DataSource = _lstTourGradeMaster;

                ddlGrade.DataTextField = "tourgrade_name";
                ddlGrade.DataValueField = "tourgrade_master_id";
                ddlGrade.DataBind();
                ddlGrade.Items.Insert(0, new ListItem("Select", "Select"));

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }
        private void BindUserRole()
        {
            try
            {
                List<UserRole> _lstUserRole = new List<UserRole>();
                UserRoleBL _objUserRoleBL = new UserRoleBL();

                _lstUserRole = _objUserRoleBL.GetAllUserRoleItems().ToList();

                ddlUserRole.DataSource = _lstUserRole;

                ddlUserRole.DataTextField = "user_role_name";
                ddlUserRole.DataValueField = "user_role_id";
                ddlUserRole.DataBind();
                ddlUserRole.Items.Insert(0, new ListItem("Select", "Select"));

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }

        //private void BindDynamicDropdownMaster(int dropdownmasterid)
        //{
        //    try
        //    {

        //        List<DropdownMaster> _lstDropdownMaster = new List<DropdownMaster>();
        //        DropdownMaster _objdropdownMaster = new DropdownMaster();
        //        DropdownMasterBL _objDropdownMasterBL = new DropdownMasterBL();

        //        _objdropdownMaster = _objDropdownMasterBL.GetAllDropdownMasterItems().Where(x => x.dropdown_type == "Designation" && x.dropdown_master_id==dropdownmasterid).FirstOrDefault();

        //        //ddlDesignation.Items.Clear();
        //        BindDropdownMaster();
        //       // ddlDesignation.SelectedItem.Text = _objdropdownMaster.dropdown_item_name;
        //        ddlDesignation.SelectedValue = _objdropdownMaster.dropdown_master_id.ToString();


        //        //ddlDesignation.DataSource = _lstDropdownMaster;

        //        //ddlDesignation.DataTextField = "dropdown_item_name";
        //        //ddlDesignation.DataValueField = "dropdown_master_id";
        //        //ddlDesignation.DataBind();
        //        //ddlDesignation.Items.Insert(0, new ListItem("Select", "Select"));


        //    }
        //    catch (Exception ex)
        //    {
        //        string error = ex.ToString();
        //    }
        //}

        #region Get Staff Data

        private void PopulateData(string _staffid)
        {
            try
            {
                Int32 STAFFID = Convert.ToInt32(_staffid);
               
                _objStaffMasterBL = new StaffMasterBL();
                _objStaffMaster = _objStaffMasterBL.GetStaffMasterItemsByID(Convert.ToInt32(STAFFID)).FirstOrDefault();
                if (_objStaffMaster.staff_master_id != 0)
                {
                    btnSubmitGeneralForm.Visible = false;
                    btnUpdateGeneralForm.Visible = true;

                    btnSubmitAddressForm.Visible = false;
                    btnUpdateAddressForm.Visible = true;

                    btnSubmitDocumentForm.Visible = false;
                    btnUpdateDocumentForm.Visible = true;

                    txtEmployeeId.Text = _objStaffMaster.staff_employee_id;
                    txtEmployeeName.Text = _objStaffMaster.staff_name;
                    txtEmail.Text = _objStaffMaster.staff_email;
                    txtMobile.Text = _objStaffMaster.staff_phoneNo;
                    ddlDesignation.SelectedValue = _objStaffMaster.staff_designation_id.ToString();
                    //  txtJoinningDate.Text = _objStaffMaster.staff_joinning_date.ToString("mm-dd-yyyy");
                    txtJoinningDate.Text = _objStaffMaster.staff_joinning_date.ToShortDateString();
                    ddlGrade.SelectedValue = _objStaffMaster.staff_grade_id.ToString();
                    ddlUserRole.SelectedValue = _objStaffMaster.user_role_id.ToString();

                    txtCurrentAddress.Text = _objStaffMaster.staff_current_address;
                    txtCurrentState.Text = _objStaffMaster.staff_current_state;
                    txtCurrentPincode.Text = _objStaffMaster.staff_current_pincode;
                    txtCurrentCity.Text = _objStaffMaster.staff_current_city;

                    txtPermanentAddress.Text = _objStaffMaster.staff_permanent_address;
                    txtPermanentState.Text = _objStaffMaster.staff_permanent_state;
                    txtPermanentPincode.Text = _objStaffMaster.staff_permanent_pincode;
                    txtPermanentCity.Text = _objStaffMaster.staff_permanent_city;

                    txtBankName.Text = _objStaffMaster.staff_bankname;
                    txtBankAccountNumber.Text = _objStaffMaster.staff_account_number;
                    txtIfscCode.Text = _objStaffMaster.staff_ifsc_number;
                    txtPancardNumber.Text = _objStaffMaster.staff_pancard_number;
                    txtAadharNumber.Text = _objStaffMaster.staff_aadhar_number;

                    if (string.IsNullOrEmpty(_objStaffMaster.staff_aadhar_back))
                    {
                        AadharBackImagePreview.ImageUrl = "/Content/img/default-image.jpg";
                    }
                    else
                    {
                     //   AadharBackImagePreview.ImageUrl =  _objStaffMaster.staff_aadhar_back;

                        AadharBackImagePreview.ImageUrl = ConfigurationManager.AppSettings["documentbaseurl"].ToString() +_objStaffMaster.staff_aadhar_back;
                    }
                    if (string.IsNullOrEmpty(_objStaffMaster.staff_aadhar_front))
                    {
                        AadharFrontImagePreview.ImageUrl = "/Content/img/default-image.jpg";
                    }
                    else
                    {
                       // AadharFrontImagePreview.ImageUrl = _objStaffMaster.staff_aadhar_front;

                       AadharFrontImagePreview.ImageUrl = ConfigurationManager.AppSettings["documentbaseurl"].ToString() + _objStaffMaster.staff_aadhar_front;
                    }
                    if (string.IsNullOrEmpty(_objStaffMaster.staff_pancard_image))
                    {
                        PancardImagePreview.ImageUrl = "/Content/img/default-image.jpg";
                    }
                    else
                    {
                      //  PancardImagePreview.ImageUrl = _objStaffMaster.staff_pancard_image;

                       PancardImagePreview.ImageUrl = ConfigurationManager.AppSettings["documentbaseurl"].ToString() + _objStaffMaster.staff_pancard_image;
                    }

                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }


        }

        #endregion

        #region Add,Update,Clear Button Actions

        protected void btnSubmitGeneralForm_Click(object sender, EventArgs e)
        {
            try
            {
                _objStaffMasterBL = new StaffMasterBL();

                _lstStaffMaster = _objStaffMasterBL.GetAllStaffMasterItems().Where(x => x.staff_phoneNo == txtMobile.Text).ToList();
                if (_lstStaffMaster.Count == 0)
                {
                    _objStaffMaster = _objStaffMasterBL.CreateStaffMaster(GetStaffMasterGeneralFormForSaveObject());

                    if (_objStaffMaster.staff_master_id > 0)
                    {
                        hdnId.Value = _objStaffMaster.staff_master_id.ToString();
                        string sMSText = "Dear " + _objStaffMaster.staff_name + ", Welcome to AASG. Your login details to for AASG app is given below:" + System.Environment.NewLine + "username-" + txtMobile.Text + System.Environment.NewLine + "password-" + _objStaffMaster.staff_password + System.Environment.NewLine + "-" + System.Environment.NewLine + "Thanks" + System.Environment.NewLine + "Team AASG";

                        App.Helper.Utils.sendSMS(txtMobile.Text, sMSText, ConfigurationManager.AppSettings["DLT_TE_ID_New_User"].ToString());

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccess();", true);
                        // ClearGeneralForm(); 
                        btnSubmitAddressForm.Visible = true;
                        btnUpdateAddressForm.Visible = false;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAllreadyEmployee();", true);
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
        }

        protected void btnUpdateGeneralForm_Click(object sender, EventArgs e)
        {
            try
            {
                _objStaffMasterBL = new StaffMasterBL();

                _objStaffMaster = _objStaffMasterBL.GetAllStaffMasterItems().Where(x => x.staff_master_id == Convert.ToInt32(hdnId.Value)).FirstOrDefault();
                if (_objStaffMaster.staff_master_id != 0)
                {
                    _objStaffMaster = _objStaffMasterBL.UpdateStaffMaster(GetStaffMasterGeneralFormForUpdateObject());

                    if (_objStaffMaster.staff_master_id > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showEmployeeUpdate();", true);
                        ClearAddressForm();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }

        }

        protected void btnSubmitAddressForm_Click(object sender, EventArgs e)
        {
            try
            {
                _objStaffMasterBL = new StaffMasterBL();


                _objStaffMaster = _objStaffMasterBL.GetAllStaffMasterItems().Where(x => x.staff_master_id == Convert.ToInt32(hdnId.Value)).FirstOrDefault();
                if (_objStaffMaster.staff_master_id != 0)
                {
                    _objStaffMaster = _objStaffMasterBL.UpdateStaffMaster(GetStaffMasterAddressFormObject());
                    
                    if (_objStaffMaster.staff_master_id > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showEmployeeUpdate();", true);
                        ClearAddressForm();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
        }

        protected void btnUpdateAddressForm_Click(object sender, EventArgs e)
        {
            try
            {
                _objStaffMasterBL = new StaffMasterBL();


                _objStaffMaster = _objStaffMasterBL.GetAllStaffMasterItems().Where(x => x.staff_master_id == Convert.ToInt32(hdnId.Value)).FirstOrDefault();
                if (_objStaffMaster.staff_master_id != 0)
                {
                    _objStaffMaster = _objStaffMasterBL.UpdateStaffMaster(GetStaffMasterAddressFormObject());

                    if (_objStaffMaster.staff_master_id > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showEmployeeUpdate();", true);
                        ClearAddressForm();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
        }

        protected void btnUpdateDocumentForm_Click(object sender, EventArgs e)
        {
            try
            {
                _objStaffMasterBL = new StaffMasterBL();


                _objStaffMaster = _objStaffMasterBL.GetAllStaffMasterItems().Where(x => x.staff_master_id == Convert.ToInt32(hdnId.Value)).FirstOrDefault();
                if (_objStaffMaster.staff_master_id != 0)
                {

                    _objStaffMaster = _objStaffMasterBL.UpdateStaffMaster(GetStaffMasterDocumentFormObject());
                    if (_objStaffMaster.staff_master_id > 0)
                    {

                        if (fuUploadedFileAadharFront.HasFile)
                        {
                            SaveAadharFrontdocument(_objStaffMaster.staff_master_id);
                        }
                        else
                        {

                        }

                        if (fuUploadedFilePanCard.HasFile)
                        {
                            SavePancarddocument(_objStaffMaster.staff_master_id);
                        }
                        else
                        {

                        }
                        if (fuUploadedFileAadharBack.HasFile)
                        {
                            SaveAadharBackdocument(_objStaffMaster.staff_master_id);
                        }
                        else
                        {

                        }
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showEmployeeUpdate();", true);
                        ClearDocumentForm();
                        ClearAddressForm();
                        ClearGeneralForm();
                        btnSubmitDocumentForm.Visible = true;
                        btnUpdateDocumentForm.Visible = false;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                }


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
        }

        protected void btnSubmitDocumentForm_Click(object sender, EventArgs e)
        {
            try
            {
                _objStaffMasterBL = new StaffMasterBL();


                _objStaffMaster = _objStaffMasterBL.GetAllStaffMasterItems().Where(x => x.staff_master_id == Convert.ToInt32(hdnId.Value)).FirstOrDefault();
                if (_objStaffMaster.staff_master_id != 0)
                {

                    _objStaffMaster = _objStaffMasterBL.UpdateStaffMaster(GetStaffMasterDocumentFormObject());
                    if (_objStaffMaster.staff_master_id > 0)
                    {

                        if (fuUploadedFileAadharFront.HasFile)
                        {
                            SaveAadharFrontdocument(_objStaffMaster.staff_master_id);
                        }
                        else
                        {

                        }

                        if (fuUploadedFilePanCard.HasFile)
                        {
                            SavePancarddocument(_objStaffMaster.staff_master_id);
                        }
                        else
                        {

                        }
                        if (fuUploadedFileAadharBack.HasFile)
                        {
                            SaveAadharBackdocument(_objStaffMaster.staff_master_id);
                        }
                        else
                        {

                        }
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showEmployeeUpdate();", true);
                        ClearDocumentForm();
                        ClearAddressForm();
                        ClearGeneralForm();
                        btnSubmitDocumentForm.Visible = true;
                        btnUpdateDocumentForm.Visible = false;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                }


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
        }

        protected void BtnResetDocumentForm_Click(object sender, EventArgs e)
        {
            ClearDocumentForm();
        }

        protected void BtnResetAddressForm_Click(object sender, EventArgs e)
        {
            ClearAddressForm();
        }

        protected void BtnResetGeneralForm_Click(object sender, EventArgs e)
        {
            ClearGeneralForm();
        }

        #endregion 

        #region Get Staff Master Details According To Form Module Like( General Form, Bank/Document etc)

        #region Get Staff Details From General Form TextFields
        /// <summary>
        /// This Method is Used to Get Staff Details From General Form TextFields to StaffMaster Object
        /// </summary>
        /// <returns></returns>
        private App.BusinessModel.StaffMaster GetStaffMasterGeneralFormForSaveObject()
        {
            try
            {
                _objStaffMasterBL = new App.Business.StaffMasterBL();

                _objStaffMaster.guid = Guid.NewGuid();
                _objStaffMaster.staff_employee_id = txtEmployeeId.Text;
                _objStaffMaster.staff_name = txtEmployeeName.Text.ToLower();
                _objStaffMaster.staff_email = txtEmail.Text;
                _objStaffMaster.staff_phoneNo = txtMobile.Text;
                _objStaffMaster.staff_password = GenerateRandomNo();
                _objStaffMaster.staff_designation_id = Convert.ToInt32(ddlDesignation.SelectedValue);
                _objStaffMaster.staff_joinning_date = DateTime.ParseExact(txtJoinningDate.Text, "dd/MM/yyyy", null);
                // _objStaffMaster.staff_joinning_date = Convert.ToDateTime(txtJoinningDate.Text);
                _objStaffMaster.staff_grade_id = Convert.ToInt32(ddlGrade.SelectedValue);
                _objStaffMaster.user_role_id = Convert.ToInt32(ddlUserRole.SelectedValue);
                //Convert.ToDateTime(_objStaffMaster.staff_joinning_date).ToString("MM/dd/yyyy");
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objStaffMaster;
        }
        #endregion

        #region Get Staff Details From General Form TextFields For Update
        /// <summary>
        /// This Method is Used to Get Staff Details From General Form TextFields to StaffMaster Object
        /// </summary>
        /// <returns></returns>
        private App.BusinessModel.StaffMaster GetStaffMasterGeneralFormForUpdateObject()
        {
            try
            {
                _objStaffMasterBL = new App.Business.StaffMasterBL();

                _objStaffMaster.guid = _objStaffMaster.guid;
                if (_objStaffMaster.staff_employee_id != null)
                {
                   
                    _objStaffMaster.staff_employee_id = _objStaffMaster.staff_employee_id;
                }
                else
                {
                    _objStaffMaster.staff_employee_id = txtEmployeeId.Text;
                }
                
                _objStaffMaster.staff_name = txtEmployeeName.Text.ToLower();
                _objStaffMaster.staff_email = txtEmail.Text;
                _objStaffMaster.staff_phoneNo = _objStaffMaster.staff_phoneNo;
                _objStaffMaster.staff_password = _objStaffMaster.staff_password;
                _objStaffMaster.staff_designation_id = Convert.ToInt32(ddlDesignation.SelectedValue);
                _objStaffMaster.staff_joinning_date = Convert.ToDateTime(txtJoinningDate.Text);
                //Convert.ToDateTime(_objStaffMaster.staff_joinning_date).ToString("MM/dd/yyyy");
                _objStaffMaster.staff_grade_id = Convert.ToInt32(ddlGrade.SelectedValue);
                _objStaffMaster.user_role_id = Convert.ToInt32(ddlUserRole.SelectedValue);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objStaffMaster;
        }
        #endregion


        #region Get Staff Details From Address Form TextFields
        /// <summary>
        /// This Method is Used to Get Staff Details from Address Form TextField to StaffMaster Object
        /// </summary>
        /// <returns></returns>
        private App.BusinessModel.StaffMaster GetStaffMasterAddressFormObject()
        {
            try
            {
                _objStaffMasterBL = new App.Business.StaffMasterBL();

              //  _objStaffMaster.staff_master_id = Convert.ToInt32(hdnId.Value);
                _objStaffMaster.staff_current_address = txtCurrentAddress.Text;
                _objStaffMaster.staff_current_city = txtCurrentCity.Text;
                _objStaffMaster.staff_current_state = txtCurrentState.Text;
                _objStaffMaster.staff_current_pincode = txtCurrentPincode.Text;
                _objStaffMaster.staff_permanent_address = txtPermanentAddress.Text;
                _objStaffMaster.staff_permanent_city = txtPermanentCity.Text;
                _objStaffMaster.staff_permanent_state = txtPermanentState.Text;
                _objStaffMaster.staff_permanent_pincode = txtPermanentPincode.Text;

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objStaffMaster;
        }
        #endregion

        #region Get Staff Details From Bank/Document Form TextFields
        /// <summary>
        /// This Method is Used to Get Staff Details from Document Form TextField to StaffMaster Object
        /// </summary>
        /// <returns></returns>
        private App.BusinessModel.StaffMaster GetStaffMasterDocumentFormObject()
        {
            try
            {
                _objStaffMasterBL = new App.Business.StaffMasterBL();

                 _objStaffMaster.staff_bankname = txtBankName.Text;
                _objStaffMaster.staff_account_number = txtBankAccountNumber.Text;
                _objStaffMaster.staff_ifsc_number = txtIfscCode.Text;
                _objStaffMaster.staff_pancard_number = txtPancardNumber.Text;
                _objStaffMaster.staff_aadhar_number = txtAadharNumber.Text;

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objStaffMaster;
        }
        #endregion
        #endregion

        #region Generate Random Number

        public static string GenerateRandomNo()
        {
            int _min = 100000;
            int _max = 999999;
            Random _rdm = new Random();
            return Convert.ToString(_rdm.Next(_min, _max));
        }
        #endregion

        #region Clear TextField Method

        #region Clear GeneralForm
        /// <summary>
        /// This Method is Used to Clear General Form Fields
        /// </summary>
        private void ClearGeneralForm()
        {
            txtEmployeeId.Text = txtEmployeeName.Text = txtEmail.Text = txtMobile.Text = txtJoinningDate.Text =ddlUserRole.Text= string.Empty;
        }
        #endregion



        #region Clear AddressForm
        /// <summary>
        /// This Method is Used to Clear General Form Fields
        /// </summary>
        private void ClearAddressForm()
        {
            txtCurrentAddress.Text = txtCurrentCity.Text = txtCurrentState.Text = txtCurrentPincode.Text = txtPermanentAddress.Text = txtPermanentCity.Text = txtPermanentState.Text = txtPermanentState.Text = string.Empty;
        }
        #endregion


        #region Clear DocumentForm
        /// <summary>
        /// This Method is Used to Clear General Form Fields
        /// </summary>
        private void ClearDocumentForm()
        {
            txtBankName.Text = txtBankAccountNumber.Text = txtPancardNumber.Text = txtAadharNumber.Text = string.Empty;
            PancardImagePreview.ImageUrl = AadharFrontImagePreview.ImageUrl = AadharBackImagePreview.ImageUrl = "/Content/img/default-image.jpg";
        }
        #endregion

        #endregion


        #region activity logs
        /// <summary>
        /// This Method is Used to Save Activity of Any Action Perform By User/Admin
        /// </summary>
        /// <param name="title"></param>
        /// <param name="icon"></param>
        /// <param name="iconclass"></param>
        /// <param name="titleclass"></param>
        /// <param name="description"></param>
        private void Logs(string title, string icon, string iconclass, string titleclass, string description)
        {
            try
            {
                _objActivityLogBL = new ActivityLogBL();
                _objActivityLog.created_on = Convert.ToDateTime(DateTime.Now);
                _objActivityLog.heading = title;
                //_objActivityLog. = description;
                _objActivityLog.icon = icon;
                _objActivityLog.icon_class = iconclass;
                _objActivityLog.heading_class = titleclass;
                //_objActivityLog.vendor_master_id = loginParams.Id;
                // _objActivityLog.user_name = loginParams.UserName;
                //   _objActivityLog.IpAddress = UserIp;
                _objActivityLogBL.CreateActivityLog(_objActivityLog);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        #endregion


        #region Save All Documents Images

        #region Save PanCard Image
        /// <summary>
        /// This Method is Used to Save Pan Card Image
        /// </summary>
        /// <param name="sid">This is Staff Id</param>
        private void SavePancarddocument(long staffid)
        {
            try
            {

                _objStaffMasterBL = new StaffMasterBL();
                _objStaffMaster = _objStaffMasterBL.GetStaffMasterItemsByID(Convert.ToInt32(staffid)).FirstOrDefault();
                if (fuUploadedFilePanCard.HasFile) //save Picture
                {
                    string FileName = staffid + "_pancard" + _objStaffMaster.guid.ToString();
                    string fileUploadFile = Path.GetExtension(fuUploadedFilePanCard.FileName.ToString());
                    if (fileUploadFile == ".jpg" || fileUploadFile == ".jpeg" || fileUploadFile == ".png" || fileUploadFile == ".gif")
                    {
                        string fileUploadFileName = fuUploadedFilePanCard.FileName.ToString();
                        FileNameFile = fileUploadFileName.Split('.');
                        // FileNameFile[0] = Utils.RemoveSpecialCharacters(FileNameFile[0]);
                        //--------------------
                        if (File.Exists(Server.MapPath("~/assets/docs/") + FileName + fileUploadFile))
                        {
                            File.Delete(Server.MapPath("~/assets/docs/") + FileName + fileUploadFile);
                        }

                        fuUploadedFilePanCard.SaveAs(Server.MapPath("~/assets/docs/") + FileName + fileUploadFile);
                        _objStaffMaster.staff_pancard_image = "/assets/docs/" + FileName + fileUploadFile;
                        _objStaffMaster.staff_master_id = Convert.ToInt32(staffid);
                        _objStaffMasterBL.UpdateStaffMaster(_objStaffMaster);
                        // Clear();
                    }
                }


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
        }

        #endregion 

        #region Save Aadhar Front Image
        /// <summary>
        /// This Method is Used to Aadhar Front Image
        /// </summary>
        /// <param name="sid">This is Staff Id</param>
        private void SaveAadharFrontdocument(long staffid)
        {
            try
            {

                _objStaffMasterBL = new StaffMasterBL();
                _objStaffMaster = _objStaffMasterBL.GetStaffMasterItemsByID(Convert.ToInt32(staffid)).FirstOrDefault();
                if (fuUploadedFileAadharFront.HasFile) //save Picture
                {
                    string FileName = staffid + "_aadharFront" + _objStaffMaster.guid.ToString();
                    string fileUploadFile = Path.GetExtension(fuUploadedFileAadharFront.FileName.ToString());
                    if (fileUploadFile == ".jpg" || fileUploadFile == ".jpeg" || fileUploadFile == ".png" || fileUploadFile == ".gif")
                    {
                        string fileUploadFileName = fuUploadedFileAadharFront.FileName.ToString();
                        FileNameFile = fileUploadFileName.Split('.');
                        // FileNameFile[0] = Utils.RemoveSpecialCharacters(FileNameFile[0]);
                        //--------------------
                        if (File.Exists(Server.MapPath("~/assets/docs/") + FileName + fileUploadFile))
                        {
                            File.Delete(Server.MapPath("~/assets/docs/") + FileName + fileUploadFile);
                        }

                        fuUploadedFileAadharFront.SaveAs(Server.MapPath("~/assets/docs/") + FileName + fileUploadFile);
                        _objStaffMaster.staff_aadhar_front = "/assets/docs/" + FileName + fileUploadFile;
                        _objStaffMaster.staff_master_id = Convert.ToInt32(staffid);
                        _objStaffMasterBL.UpdateStaffMaster(_objStaffMaster);
                        // Clear();
                    }
                }


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
        }

        #endregion 

        #region Save Aadhar Back Image
        /// <summary>
        /// This Method is Used to Aadhar Back Image
        /// </summary>
        /// <param name="sid"> This is Staff Id</param>
        private void SaveAadharBackdocument(long staffid)
        {
            try
            {

                _objStaffMasterBL = new StaffMasterBL();
                _objStaffMaster = _objStaffMasterBL.GetStaffMasterItemsByID(Convert.ToInt32(staffid)).FirstOrDefault();
                if (fuUploadedFileAadharBack.HasFile) //save Picture
                {
                    string FileName = staffid + "_aadharback" + _objStaffMaster.guid.ToString();
                    string fileUploadFile = Path.GetExtension(fuUploadedFileAadharBack.FileName.ToString());
                    if (fileUploadFile == ".jpg" || fileUploadFile == ".jpeg" || fileUploadFile == ".png" || fileUploadFile == ".gif")
                    {
                        string fileUploadFileName = fuUploadedFileAadharBack.FileName.ToString();
                        FileNameFile = fileUploadFileName.Split('.');
                        // FileNameFile[0] = Utils.RemoveSpecialCharacters(FileNameFile[0]);
                        //--------------------
                        if (File.Exists(Server.MapPath("~/assets/docs/") + FileName + fileUploadFile))
                        {
                            File.Delete(Server.MapPath("~/assets/docs/") + FileName + fileUploadFile);
                        }

                        fuUploadedFileAadharBack.SaveAs(Server.MapPath("~/assets/docs/") + FileName + fileUploadFile);
                        _objStaffMaster.staff_aadhar_back = "/assets/docs/" + FileName + fileUploadFile;
                        _objStaffMaster.staff_master_id = Convert.ToInt32(staffid);
                        _objStaffMasterBL.UpdateStaffMaster(_objStaffMaster);
                        // Clear();
                    }
                }


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
        }

        #endregion

        #endregion
    }
}