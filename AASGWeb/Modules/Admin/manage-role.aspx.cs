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
    public partial class manage_role : System.Web.UI.Page
    {
        #region Global Properties
        ActivityLog _objActivityLog = new ActivityLog();
        ActivityLogBL _objActivityLogBL = null;
        List<ActivityLog> _lstActivityLog = new List<ActivityLog>();

        App.BusinessModel.UserRole _objUserRole = new App.BusinessModel.UserRole();
        App.Business.UserRoleBL _objUserRoleBL = null;
        List<App.BusinessModel.UserRole> _lstUserRole = new List<App.BusinessModel.UserRole>();

        string UserIp = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRoleGrid();
            }
        }

        #region  Page Load Method
        /// <summary>
        /// This Method is Used to Get All Role Details
        /// </summary>
        private void BindRoleGrid()
        {
            DateTime today = DateTime.Today;
            try
            {
                _objUserRoleBL = new UserRoleBL();
                _lstUserRole = _objUserRoleBL.GetAllUserRoleItems().ToList();
                if(_lstUserRole.Count>0)
                {
                   int mcount= _objUserRoleBL.GetAllUserRoleItems().Where(x => x.created_on.Month == today.Month).ToList().Count;
                    lblTotalRole.Text = _lstUserRole.Count.ToString();
                    lblTotalRoleThisMonth.Text = mcount.ToString();

                    rptrManageRole.DataSource = _lstUserRole;
                    rptrManageRole.DataBind();
                } 
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }

        #endregion

        #region Update Role Status Method
        /// <summary>
        /// This Method is Used to Update  Role Status By Particular id
        /// </summary>
        /// <param name="roleid">This is Unique Role Id</param>
        private void updateStatus(string roleid)
        {
            Int64 id = Convert.ToInt64(roleid);
            _objUserRoleBL = new UserRoleBL();
            _objUserRole = _objUserRoleBL.GetAllUserRoleItems().Where(x => x.user_role_id == id).FirstOrDefault();
            if (_objUserRole.is_active == true)
            {
                _objUserRole.is_active = false;
            }
            else
            {
                _objUserRole.is_active = true;
            }

            _objUserRole = _objUserRoleBL.UpdateUserRole(_objUserRole);
            if (_objUserRole != null)
            {
                //string description = "Article  <b>" + _objArticle.title + "</b> status has been updated By " + loginParams.UserName;
                //Logs("Article status Updated", "fa fa-user", "timeline-icon themed-background-fire themed-border-fire", "push-bit text-danger", description);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccess();", true);
                BindRoleGrid();
            }
        }

        #endregion
        #region Repeater Code
        protected void rptrManageRole_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string commandname = e.CommandName;
            string id = e.CommandArgument.ToString();
            hdfdroleId.Value = id;

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

                        string url = "add-role/" + App.Core.DataSecurity.Encryptdata(id).ToString();

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
       

        protected void rptrManageRole_ItemDataBound(object sender, RepeaterItemEventArgs e)
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

        #endregion
    }
}