using App.Business;
using App.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AASGWeb.Modules.Admin
{
    public partial class add_party : System.Web.UI.Page
    {
        #region Global Properties
        ActivityLog _objActivityLog = new ActivityLog();
        App.Business.ActivityLogBL _objActivityLogBL = null;
        List<ActivityLog> _lstActivityLog = new List<ActivityLog>();

        PartyMaster _objPartyMaster = new PartyMaster();
        PartyMasterBL _objPartyMasterBL = null;
        List<PartyMaster> _lstPartyMaster = new List<PartyMaster>();


        string UserIp = string.Empty;
        
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                string _partyid;
                if (RouteData.Values["id"] == null)
                {
                    // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "editorInit();", true);
                }
                else
                {

                    string party_master_id = RouteData.Values["id"].ToString();
                    _partyid = App.Core.DataSecurity.Decryptdata(party_master_id);
                    if (_partyid == "" || _partyid == null)
                    {
                        Response.Redirect("/home", false);
                    }
                    else
                    {
                        hdnId.Value = _partyid;

                        if (hdnId.Value == "")
                        {
                            Response.Redirect("/home", false);

                        }
                        else
                        {
                            PopulateData(_partyid);
                        }

                    }


                }
            }
        }
        private void PopulateData(string _partyid)
        {
            try
            {
                Int32 PartyID = Convert.ToInt32(_partyid);

                _objPartyMasterBL = new PartyMasterBL();
                _objPartyMaster = _objPartyMasterBL.GetPartyMasterItemsByID(Convert.ToInt32(PartyID)).FirstOrDefault();
                if (_objPartyMaster.party_master_id != 0)
                {
                    btnAddParty.Visible = false;
                    BtnUpdate.Visible = true;

                    txtPartyName.Text = _objPartyMaster.party_name;
                    txtContactPerson.Text=_objPartyMaster.party_contact_person ;
                    txtMobile.Text=_objPartyMaster.party_phoneno;
                    txtEmail.Text=_objPartyMaster.party_email;
                    txtGstNumber.Text=_objPartyMaster.party_gst;
                    txtBillToAddress.Text= _objPartyMaster.party_address;
                    txtState.Text=_objPartyMaster.party_state;
                    txtCity.Text=_objPartyMaster.party_city;
                    txtPinCode.Text=_objPartyMaster.party_pincode;
                    txtRegion.Text=_objPartyMaster.party_region;
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

        protected void btnAddParty_Click(object sender, EventArgs e)
        {
            _objPartyMasterBL = new PartyMasterBL();
            try
            {
                if (txtPartyName.Text == "" || txtPartyName.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showError();", true);
                }
                else if (txtContactPerson.Text == "" || txtContactPerson.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showError();", true);
                }
                else if (txtMobile.Text == "" || txtMobile.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showError();", true);
                }
                else if (txtEmail.Text == "" || txtEmail.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showError();", true);
                }
                else if (txtState.Text == "" || txtState.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showError();", true);
                }
                else if (txtCity.Text == "" || txtCity.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showError();", true);
                }
                else if (txtPinCode.Text == "" || txtPinCode.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showError();", true);
                }
                else if (txtGstNumber.Text == "" || txtGstNumber.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showError();", true);
                }
                else
                {
                    _lstPartyMaster = _objPartyMasterBL.GetAllPartyMasterItems().Where(x => x.party_phoneno == txtMobile.Text).ToList();

                    if (_lstPartyMaster.Count == 0)
                    {
                        _objPartyMasterBL = new PartyMasterBL();
                        _objPartyMaster = new PartyMaster();
                        _objPartyMaster = _objPartyMasterBL.CreatePartyMaster(GetPartyMasterObject());

                        // var response = _objPartyMasterBL.CreatePartyMaster(GetPartyMasterObject());

                        // if (response.party_master_id != 0)
                        if (_objPartyMaster.party_master_id != 0)
                        {
                            ClearGeneralForm();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showPartySuccess();", true);
                            btnAddParty.Visible = true;
                            BtnUpdate.Visible = false;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlreadyPartyPhonenumber();", true);
                    }
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            

           
           
        }
        private PartyMaster GetPartyMasterObject()
        {
            try
            {
                _objPartyMaster.guid = Guid.NewGuid();
                _objPartyMaster.party_name = txtPartyName.Text;
                _objPartyMaster.party_contact_person = txtContactPerson.Text;
                _objPartyMaster.party_phoneno = txtMobile.Text;
                _objPartyMaster.party_email = txtEmail.Text;
                _objPartyMaster.party_gst = txtGstNumber.Text;
                _objPartyMaster.party_address = txtBillToAddress.Text;
                _objPartyMaster.party_state = txtState.Text;
                _objPartyMaster.party_city = txtCity.Text;
                _objPartyMaster.party_pincode = txtPinCode.Text;
                _objPartyMaster.party_region = txtRegion.Text;

                return _objPartyMaster;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objPartyMaster;
        }
        private PartyMaster GetUpdatePartyMasterObject()
        {
            try
            {
                //_objPartyMaster.guid = Guid.NewGuid();
                _objPartyMaster.party_name = txtPartyName.Text;
                _objPartyMaster.party_contact_person = txtContactPerson.Text;
               // _objPartyMaster.party_phoneno = txtMobile.Text;
                _objPartyMaster.party_email = txtEmail.Text;
                _objPartyMaster.party_gst = txtGstNumber.Text;
                _objPartyMaster.party_address = txtBillToAddress.Text;
                _objPartyMaster.party_state = txtState.Text;
                _objPartyMaster.party_city = txtCity.Text;
                _objPartyMaster.party_pincode = txtPinCode.Text;
                _objPartyMaster.party_region = txtRegion.Text;

                return _objPartyMaster;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objPartyMaster;
        }
        private void ClearGeneralForm()
        {
            txtPartyName.Text = txtContactPerson.Text= txtMobile.Text = txtEmail.Text= txtGstNumber.Text= txtBillToAddress.Text= txtState.Text = txtCity.Text = txtPinCode.Text = txtRegion.Text = string.Empty;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearGeneralForm();
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {

           try {
                _objPartyMasterBL = new PartyMasterBL();

                if (txtPartyName.Text == "" || txtPartyName.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showError();", true);
                }
                else if (txtContactPerson.Text == "" || txtContactPerson.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showError();", true);
                }
                else if (txtMobile.Text == "" || txtMobile.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showError();", true);
                }
                else if (txtEmail.Text == "" || txtEmail.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showError();", true);
                }
                else if (txtState.Text == "" || txtState.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showError();", true);
                }
                else if (txtCity.Text == "" || txtCity.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showError();", true);
                }
                else if (txtPinCode.Text == "" || txtPinCode.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showError();", true);
                }
                else if (txtGstNumber.Text == "" || txtGstNumber.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showError();", true);
                }
                else
                {
                    _objPartyMaster = _objPartyMasterBL.GetAllPartyMasterItems().Where(x => x.party_master_id == Convert.ToInt32(hdnId.Value)).FirstOrDefault();
                    if (_objPartyMaster.party_master_id != 0)
                    {
                        _objPartyMaster = _objPartyMasterBL.UpdatePartyMaster(GetUpdatePartyMasterObject());

                        if (_objPartyMaster.party_master_id > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showPartyUpdate();", true);
                            btnAddParty.Visible = false;
                            BtnUpdate.Visible = true;
                            ClearGeneralForm();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showNoRecordFound();", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
        }
    }
}