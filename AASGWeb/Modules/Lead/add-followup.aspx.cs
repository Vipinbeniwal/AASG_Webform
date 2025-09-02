using App.Business;
using App.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AASGWeb.Modules.Lead
{
    public partial class add_followup : System.Web.UI.Page
    {
        #region Global Properties
        ActivityLog _objActivityLog = new ActivityLog();
        ActivityLogBL _objActivityLogBL = null;
        List<ActivityLog> _lstActivityLog = new List<ActivityLog>();

        FollowUp _objFollowUp = new FollowUp();
        FollowUpBL _objFollowUpBL = null;
        List<FollowUp> _lstFollowUp = new List<FollowUp>();

        LeadHeader _objLeadHeader = new LeadHeader();
        LeadHeaderBL _objLeadHeaderBL = null;
        List<LeadHeader> _lstLeadHeader = new List<LeadHeader>();

        string UserIp = string.Empty;
        
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPartyMaster();
                string _lead_header_id;
                if (RouteData.Values["id"] == null)
                {
                    // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "editorInit();", true);
                }
                else
                {

                    string lead_header_id = RouteData.Values["id"].ToString();
                    _lead_header_id = App.Core.DataSecurity.Decryptdata(lead_header_id);
                    if (_lead_header_id == "" || _lead_header_id == null)
                    {
                        Response.Redirect("/home", false);
                    }
                    else
                    {
                        hdnId.Value = _lead_header_id;

                        if (hdnId.Value == "")
                        {
                            Response.Redirect("/home", false);

                        }
                        else
                        {
                            PopulateData(_lead_header_id);
                        }

                    }


                }
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
        private void PopulateData(string _lead_header_id)
        {
            try
            {
                Int32 LeadHeaderID = Convert.ToInt32(_lead_header_id);

                _objLeadHeaderBL = new LeadHeaderBL();
                _objLeadHeader = _objLeadHeaderBL.GetLeadHeaderItemsByID(Convert.ToInt32(_lead_header_id)).FirstOrDefault();
                if (_objLeadHeader.lead_header_id != 0)
                {
                    ddlPartyName.SelectedValue = _objLeadHeader.party_master_id.ToString();
                    ddlPartyName.Enabled = false;
                    txtFollowUpDate.Text = Convert.ToDateTime(_objLeadHeader.followup_date).ToShortDateString();
                    txtFollowUpDate.Enabled = false;
                    txtFollowUpText.Enabled = false;
                    txtFollowUpText.Text = _objLeadHeader.lead_remarks;
                    txtNextFollowUpDate.Text = "";
                    txtSpecialRemarks.Text = "";
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

        protected void btnAddFollowUp_Click(object sender, EventArgs e)
        {
            _objFollowUpBL = new FollowUpBL();
            try
            {
                _objFollowUpBL = new FollowUpBL();
                var response = _objFollowUpBL.CreateFollowUp(GetFollowUpObject());

                if (response.followup_id != 0)
                {
                    ClearGeneralForm();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccess();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlreadyFollowUp();", true);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
        }
        private void ClearGeneralForm()
        {
            txtNextFollowUpDate.Text = txtSpecialRemarks.Text =  string.Empty;
        }
        private FollowUp GetFollowUpObject()
        {
            try
            {
                _objFollowUp.guid = Guid.NewGuid();
                _objFollowUp.lead_header_id = Convert.ToInt32(hdnId.Value);
                _objFollowUp.followup_date = Convert.ToDateTime(txtFollowUpDate.Text);
                _objFollowUp.followup_text = txtFollowUpText.Text;
                //_objFollowUp.next_followup_date = Convert.ToDateTime(txtNextFollowUpDate.Text);
                _objFollowUp.next_followup_date = DateTime.ParseExact(txtNextFollowUpDate.Text, "dd/MM/yyyy", null);
                _objFollowUp.special_remarks = txtSpecialRemarks.Text;

                return _objFollowUp;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objFollowUp;
        } 

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearGeneralForm();
        }
    }
}