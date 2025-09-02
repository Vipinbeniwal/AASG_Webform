using App.Business;
using App.BusinessModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AASGWeb.Modules.Admin
{
    public partial class manage_party : System.Web.UI.Page
    {
        #region Global Properties
        ActivityLog _objActivityLog = new ActivityLog();
        ActivityLogBL _objActivityLogBL = null;
        List<ActivityLog> _lstActivityLog = new List<ActivityLog>();

        App.BusinessModel.PartyMaster _objPartyMaster = new App.BusinessModel.PartyMaster();
        App.Business.PartyMasterBL _objPartyMasterBL = null;
        List<App.BusinessModel.PartyMaster> _lstPartyMaster = new List<App.BusinessModel.PartyMaster>();

        string UserIp = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPartysGrid();
            }
        }
        private void BindPartysGrid()
        {
            try
            {
                _objPartyMasterBL = new PartyMasterBL();
                _lstPartyMaster = _objPartyMasterBL.GetAllPartyMasterItems().OrderByDescending(x => x.created_on).ToList();

                rptrManageParty.DataSource = _lstPartyMaster;
                rptrManageParty.DataBind();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }

        protected void rptrManageParty_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string commandname = e.CommandName;
            string id = e.CommandArgument.ToString();
            hdfdpartyId.Value = id;

            Int32 ID = Convert.ToInt32(id);
            switch (commandname)
            {
                case "active":
                    try
                    {
                        updateStatus(id);
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

                        string url = "add-party/" + App.Core.DataSecurity.Encryptdata(id).ToString();

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

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }
        protected void ExportToExcel(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=PartyMaster.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";

            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                foreach (RepeaterItem item in rptrManageParty.Items)
                {
                    List<Control> controls = new List<Control>();
                    foreach (Control control in item.Controls)
                    {
                        if (control.GetType() == typeof(LinkButton))
                        {
                            controls.Add(control);
                        }
                    }
                    foreach (Control control in controls)
                    {
                        switch (control.GetType().Name)
                        {
                            case "LinkButton":
                                //item.Controls.Add(new Literal { Text = (control as LinkButton).Text });
                                break;
                        }
                        item.Controls.Remove(control);
                    }
                }
                rptrManageParty.RenderControl(hw);
                Response.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        protected void DownloadFile(object sender, EventArgs e)
        {
            string filePath = "~/assets/templates/ManagePartyMaster.xls";
            if (filePath != string.Empty)
            {
                WebClient req = new WebClient();
                HttpResponse response = HttpContext.Current.Response;

                response.Clear();
                response.ClearContent();
                response.ClearHeaders();
                response.Buffer = true;
                response.AddHeader("Content-Disposition", "attachment;filename=ManagePartyMaster.xls");
                byte[] data = req.DownloadData(Server.MapPath(filePath));
                response.BinaryWrite(data);
                response.End();
            }
        }
        private void updateStatus(string partyid)
        {
            Int64 id = Convert.ToInt64(partyid);
            _objPartyMasterBL = new PartyMasterBL();
            _objPartyMaster = _objPartyMasterBL.GetAllPartyMasterItems().Where(x => x.party_master_id == id).FirstOrDefault();
            if (_objPartyMaster.is_active == true)
            {
                _objPartyMaster.is_active = false;
            }
            else
            {
                _objPartyMaster.is_active = true;
            }

            _objPartyMaster = _objPartyMasterBL.UpdatePartyMaster(_objPartyMaster);
            if (_objPartyMaster != null)
            {
                //string description = "Article  <b>" + _objArticle.title + "</b> status has been updated By " + loginParams.UserName;
                //Logs("Article status Updated", "fa fa-user", "timeline-icon themed-background-fire themed-border-fire", "push-bit text-danger", description);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccess();", true);
                BindPartysGrid();
            }
        }

        protected void rptrManageParty_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    Label lblIsActive = (Label)e.Item.FindControl("lblIsActive");
                    LinkButton btnstatusactive = (LinkButton)e.Item.FindControl("btnstatusactive");
                    LinkButton btnstatusdeactive = (LinkButton)e.Item.FindControl("btnstatusdeactive");
                    //CheckBox chkActive=(CheckBox)e.Item.FindControl("chkActive");
                    string isactive = lblIsActive.Text;
                    if (isactive == "True")
                    {
                        btnstatusactive.Visible = true;
                        btnstatusdeactive.Visible = false;
                        //chkActive.Checked=true;

                    }
                    else
                    {
                        btnstatusactive.Visible = false;
                        btnstatusdeactive.Visible = true;
                        //chkActive.Checked = false;

                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "notification('Something went wrong','danger');", true);
            }
        }
    }
}