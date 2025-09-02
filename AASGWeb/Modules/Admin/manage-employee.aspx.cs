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
    public partial class manage_employee : System.Web.UI.Page
    {
        #region Global Properties
        ActivityLog _objActivityLog = new ActivityLog();
        ActivityLogBL _objActivityLogBL = null;
        List<ActivityLog> _lstActivityLog = new List<ActivityLog>();

        App.BusinessModel.StaffMaster _objStaffMaster = new App.BusinessModel.StaffMaster();
        App.Business.StaffMasterBL _objStaffMasterBL = null;
        List<App.BusinessModel.StaffMaster> _lstStaffMaster = new List<App.BusinessModel.StaffMaster>();


        string UserIp = string.Empty;
        
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                BindStaffrptr();
            }

        }

        #region Pageload method

        private void BindStaffrptr()
        {
            _objStaffMasterBL = new StaffMasterBL();

            _lstStaffMaster = _objStaffMasterBL.GetAllStaffMasterItems().OrderByDescending(x=> x.staff_master_id).ToList();
            rptrStaff.DataSource = _lstStaffMaster;
            rptrStaff.DataBind();
        }
        #endregion

        protected void rptrStaff_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string commandname = e.CommandName;
            string id = e.CommandArgument.ToString();
            hdfdstaffId.Value = id;

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

                        string url = "add-employee/" + App.Core.DataSecurity.Encryptdata(id).ToString();

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

        protected void rptrStaff_ItemDataBound(object sender, RepeaterItemEventArgs e)
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

        #region Stafff Status Update Method

        private void updateStatus(string articleid)
        {
            Int64 id = Convert.ToInt64(articleid);
            _objStaffMasterBL = new StaffMasterBL();
            _objStaffMaster = _objStaffMasterBL.GetAllStaffMasterItems().Where(x => x.staff_master_id == id).FirstOrDefault();
            if (_objStaffMaster.is_active == true)
            {
                _objStaffMaster.is_active = false;
            }
            else
            {
                _objStaffMaster.is_active = true;
            }

            _objStaffMaster = _objStaffMasterBL.UpdateStaffMaster(_objStaffMaster);
            if (_objStaffMaster != null)
            {
                //string description = "Article  <b>" + _objArticle.title + "</b> status has been updated By " + loginParams.UserName;
                //Logs("Article status Updated", "fa fa-user", "timeline-icon themed-background-fire themed-border-fire", "push-bit text-danger", description);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccess();", true);
                BindStaffrptr();
            }
        }

        #endregion
    }
}