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
using App.Business;
using App.BusinessModel;

namespace AASGWeb.Modules.Lead
{
    public partial class manage_lead : System.Web.UI.Page
    {
        LeadHeader _objLead = new LeadHeader();
        LeadHeaderBL _objLeadBL = null;
        List<LeadHeader> _lstLead = new List<LeadHeader>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindLeadGrid();
            }
        }

        protected void rptrLead_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string commandname = e.CommandName;
            string id = e.CommandArgument.ToString();
            hdfdLeadId.Value = id;

            Int32 ID = Convert.ToInt32(id);
            switch (commandname)
            {
                case "addfollowup":
                    try
                    {
                        string url = "add-followup/" + App.Core.DataSecurity.Encryptdata(id).ToString();

                        Response.Redirect(url, false);
                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;
                case "viewfollowup":
                    try
                    {
                        string url = "view-followup/" + App.Core.DataSecurity.Encryptdata(id).ToString();

                        Response.Redirect(url, false);
                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;
                case "active":
                    try
                    {
                        //updateStatus(id);
                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;
                case "edit":
                    try
                    {

                        string url = "add-lead/" + App.Core.DataSecurity.Encryptdata(id).ToString();

                        Response.Redirect(url, false);
                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;
                case "delete":
                    try
                    {
                        // DeleteArticle(ID);

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;

            }
        }
        private void BindLeadGrid()
        {
            try
            {
                _objLeadBL = new LeadHeaderBL();
                _lstLead = _objLeadBL.GetAllLeadHeaderItems().OrderByDescending(x => x.created_on).ToList();

                rptrLead.DataSource = _lstLead;
                rptrLead.DataBind();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }

        protected void rptrLead_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}