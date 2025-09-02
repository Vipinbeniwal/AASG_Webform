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
    public partial class manage_time_sheet : System.Web.UI.Page
    {
        #region Global Properties
        ActivityLog _objActivityLog = new ActivityLog();
        ActivityLogBL _objActivityLogBL = null;
        List<ActivityLog> _lstActivityLog = new List<ActivityLog>();

        xp_TimeSheetHeader _objxp_TimeSheetHeader = new xp_TimeSheetHeader();
        xp_TimeSheetHeaderBL _objxp_TimeSheetHeaderBL = null;
        List<xp_TimeSheetHeader> _lstxp_TimeSheetHeader = new List<xp_TimeSheetHeader>();


        string UserIp = string.Empty;
        string[] FileNameFile;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTimeSheetChildList();
            }
            
        }

        #region Pageload method

        private void BindTimeSheetChildList()
        {
            _objxp_TimeSheetHeaderBL = new xp_TimeSheetHeaderBL();

            _lstxp_TimeSheetHeader = _objxp_TimeSheetHeaderBL.GetAllxp_TimeSheetHeaderItems().OrderByDescending(x => x.time_sheet_header_id).ToList();
            rptrManageTimeSheet.DataSource = _lstxp_TimeSheetHeader;
            rptrManageTimeSheet.DataBind();
        }
        #endregion

        protected void rptrManageTimeSheet_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string commandname = e.CommandName;
            string id = e.CommandArgument.ToString();
            hdfdTimeSheetHeaderId.Value = id;

            Int32 ID = Convert.ToInt32(id);
            switch (commandname)
            {
                case "active":
                    try
                    {
                      //  updateStatus(id);
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

                        string url = "view_time-sheet-employee-details/" + App.Core.DataSecurity.Encryptdata(id).ToString();

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

        protected void rptrManageTimeSheet_ItemDataBound(object sender, RepeaterItemEventArgs e)
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