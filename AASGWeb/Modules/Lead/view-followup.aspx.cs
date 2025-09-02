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
    public partial class view_followup : System.Web.UI.Page
    {
         FollowUp _objFollowUp = new  FollowUp();
         FollowUpBL _objFollowUpBL = null;
        List< FollowUp> _lstFollowUp = new List< FollowUp>();

         LeadHeader _objLeadHeader = new  LeadHeader();
         LeadHeaderBL _objLeadHeaderBL = null;
        List< LeadHeader> _lstLeadHeader = new List< LeadHeader>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
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
        private void PopulateData(string _lead_header_id)
        {
            try
            {
                Int32 LeadHeaderID = Convert.ToInt32(_lead_header_id);
                _objLeadHeaderBL = new LeadHeaderBL();
                _objLeadHeader = _objLeadHeaderBL.GetLeadHeaderItemsByID(Convert.ToInt32(_lead_header_id)).FirstOrDefault();
                if (_objLeadHeader.lead_header_id != 0)
                {
                    lblPartyName.Text = _objLeadHeader.party_name;
                    lblleadFollowUpDate.Text = Convert.ToDateTime(_objLeadHeader.followup_date).ToShortDateString();
                    lblleadFollowUpText.Text = _objLeadHeader.lead_remarks;
                    BindViewFollowUprptr(LeadHeaderID);
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
        private void BindViewFollowUprptr(int id)
        {
            try
            {
                _objFollowUpBL = new FollowUpBL();
                _lstFollowUp = _objFollowUpBL.GetAllFollowUpItems().Where(x=>x.lead_header_id==id).ToList();

                if(_lstFollowUp!=null)
                {
                    rptrFollowUpDetail.DataSource = _lstFollowUp;
                    rptrFollowUpDetail.DataBind();
                }
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }

        protected void rptrFollowUpDetail_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void rptrFollowUpDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}