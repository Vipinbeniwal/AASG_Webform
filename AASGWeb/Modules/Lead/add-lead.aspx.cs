using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Text;
using System.Dynamic;
using System.IO;
using System.Net;
using App.BusinessModel;
using App.Business;

namespace AASGWeb.Modules.Lead
{
    public partial class add_lead : System.Web.UI.Page
    {
        #region Global Properties
        ActivityLog _objActivityLog = new ActivityLog();
        ActivityLogBL _objActivityLogBL = null;
        List<ActivityLog> _lstActivityLog = new List<ActivityLog>();

        LeadHeader _objLeadHeader = new LeadHeader();
       LeadHeaderBL _objLeadHeaderBL = null;
        List<LeadHeader> _lstLeadHeader = new List<LeadHeader>();

        string UserIp = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    BindPartyMaster();
            //}
            if (!IsPostBack)
            {
                BindPartyMaster();
                string lead_header_id;
                if (RouteData.Values["id"] == null)
                {
                    // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "editorInit();", true);
                }
                else
                {

                    string LeadHeader_id = RouteData.Values["id"].ToString();
                    lead_header_id = App.Core.DataSecurity.Decryptdata(LeadHeader_id);
                    if (lead_header_id == "" || lead_header_id == null)
                    {
                        Response.Redirect("/home", false);
                    }
                    else
                    {
                        hdnId.Value = lead_header_id;

                        if (hdnId.Value == "")
                        {
                            Response.Redirect("/home", false);

                        }
                        else
                        {
                            PopulateData(lead_header_id);
                        }

                    }


                }
            }
        }
        private void PopulateData(string _LeadHeaderid)
        {
            try
            {
                Int32 LeadHeaderID = Convert.ToInt32(_LeadHeaderid);

                _objLeadHeaderBL = new LeadHeaderBL();
                _objLeadHeader = _objLeadHeaderBL.GetLeadHeaderItemsByID(Convert.ToInt32(LeadHeaderID)).FirstOrDefault();
                if (_objLeadHeader.party_master_id != 0)
                {
                    btnAddLead.Visible = false;
                    btnUpdate.Visible = true;

                    txtContactPerson.Text = _objLeadHeader.party_contact_person;
                    txtMobile.Text = _objLeadHeader.party_phoneno;
                    txtFollowUpDate.Text = Convert.ToDateTime(_objLeadHeader.followup_date).ToShortDateString();
                    txtLeadRemarks.Text = _objLeadHeader.lead_remarks;
                    ddlPartyName.SelectedValue = _objLeadHeader.party_master_id.ToString();

                    ddlPartyName.Enabled = false;

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
        private void BindPartyMaster()
        {
            try
            {
                List<PartyMaster> _lstPartyMaster = new List<PartyMaster>();
                PartyMasterBL _objPartyMasterBL = new PartyMasterBL();

                _lstPartyMaster = _objPartyMasterBL.GetAllPartyMasterItems().ToList();

                ddlPartyName.DataSource = _lstPartyMaster;
                ddlPartyName.DataTextField = "party_name";
                ddlPartyName.DataValueField = "party_master_id";
                ddlPartyName.DataBind();
                ddlPartyName.Items.Insert(0, new ListItem("Select", "Select"));
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }

        protected void btnAddLeadHeader_Click(object sender, EventArgs e)
        {
            _objLeadHeaderBL = new LeadHeaderBL();
            try
            {
                if (txtMobile.Text == ""  || txtMobile.Text==null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                }
                else
                {
                    _lstLeadHeader = _objLeadHeaderBL.GetAllLeadHeaderItems().Where(x => x.party_master_id == Convert.ToInt32(ddlPartyName.SelectedValue) && x.followup_date == Convert.ToDateTime(txtFollowUpDate.Text)).ToList();

                    if (_lstLeadHeader.Count == 0)
                    {
                        _objLeadHeaderBL = new LeadHeaderBL();
                        var response = _objLeadHeaderBL.CreateLeadHeader(GetLeadHeaderObject());

                        if (response.lead_header_id != 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccess();", true);
                            ClearGeneralForm();
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlreadyLeadHeader();", true);
                    }
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }

        }
        private LeadHeader GetLeadHeaderObject()
        {
            try
            {
                _objLeadHeader.guid = Guid.NewGuid();
                _objLeadHeader.party_master_id = Convert.ToInt32(ddlPartyName.SelectedValue);
                _objLeadHeader.party_name = ddlPartyName.SelectedItem.Text;
                _objLeadHeader.party_contact_person = txtContactPerson.Text;
                _objLeadHeader.party_phoneno = txtMobile.Text;
                _objLeadHeader.lead_remarks =  txtLeadRemarks.Text;
                //_objLeadHeader.followup_date = Convert.ToDateTime(txtFollowUpDate.Text);
                _objLeadHeader.followup_date = DateTime.ParseExact(txtFollowUpDate.Text, "dd/MM/yyyy", null);

                return _objLeadHeader;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objLeadHeader;
        }
        #region Clear control
        /// <summary>
        /// This Method is Used to Clear General Form Fields
        /// </summary>
        private void ClearGeneralForm()
        {
            txtContactPerson.Text = txtFollowUpDate.Text = txtLeadRemarks.Text = txtMobile.Text= string.Empty;
            BindPartyMaster();
        }
        #endregion

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearGeneralForm();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            _objLeadHeaderBL = new LeadHeaderBL();
            try
            {
                _lstLeadHeader = _objLeadHeaderBL.GetAllLeadHeaderItems().Where(x => x.party_master_id == Convert.ToInt32(ddlPartyName.SelectedValue) && x.followup_date == Convert.ToDateTime(txtFollowUpDate.Text)).ToList();

                if (_lstLeadHeader.Count > 0)
                {
                    _objLeadHeaderBL = new LeadHeaderBL();
                    var response = _objLeadHeaderBL.UpdateLeadHeader(GetUpdateLeadHeaderObject());

                    if (response.lead_header_id != 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccess();", true);
                        ClearGeneralForm();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlreadyLeadHeader();", true);
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
        }
        private LeadHeader GetUpdateLeadHeaderObject()
        {
            try
            {
                _objLeadHeaderBL = new LeadHeaderBL();
                 _objLeadHeader = _objLeadHeaderBL.GetAllLeadHeaderItems().Where(x => x.party_master_id == Convert.ToInt32(ddlPartyName.SelectedValue)).FirstOrDefault();

                    if (_objLeadHeader.lead_header_id > 0)
                    {
                        _objLeadHeader.guid = _objLeadHeader.guid;

                        _objLeadHeader.party_master_id = _objLeadHeader.party_master_id;
                        _objLeadHeader.party_contact_person = txtContactPerson.Text;
                        _objLeadHeader.party_phoneno = txtMobile.Text;
                        _objLeadHeader.lead_remarks = txtLeadRemarks.Text;
                        _objLeadHeader.followup_date = Convert.ToDateTime(txtFollowUpDate.Text);
                    }
                
                return _objLeadHeader;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objLeadHeader;
        }
    }
}