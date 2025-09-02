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
    public partial class dropdown_master : System.Web.UI.Page
    {
        #region Global Properties
        ActivityLog _objActivityLog = new ActivityLog();
        ActivityLogBL _objActivityLogBL = null;
        List<ActivityLog> _lstActivityLog = new List<ActivityLog>();

        App.BusinessModel.DropdownMaster _objDropdownMaster = new App.BusinessModel.DropdownMaster();
        App.Business.DropdownMasterBL _objDropdownMasterBL = null;
        List<App.BusinessModel.DropdownMaster> _lstDropdownMaster = new List<App.BusinessModel.DropdownMaster>();

        string UserIp = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
          //  Page.MaintainScrollPositionOnPostBack = true;
            if(!IsPostBack)
            {
                BindDropdownMasterGrid();
            }
        }

        protected void btnAddDropdownType_Click(object sender, EventArgs e)
        {
            _objDropdownMasterBL = new DropdownMasterBL();
            try
            {
                if (ddlDropdownType.SelectedValue =="0" || ddlDropdownType.SelectedValue=="")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlertDropDownType();", true);
                }
                else
                {
                    _lstDropdownMaster = _objDropdownMasterBL.GetAllDropdownMasterItems().Where(x => x.dropdown_type.ToLower() == ddlDropdownType.SelectedItem.Text.ToLower() && x.dropdown_item_name.ToLower() == txtDropdownItemName.Text.ToLower()).ToList();

                    if (_lstDropdownMaster.Count == 0)
                    {
                        _objDropdownMasterBL = new DropdownMasterBL();
                        var response = _objDropdownMasterBL.CreateDropdownMaster(GetDropdownMasterObject());

                        if (response.dropdown_master_id != 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccess();", true);
                            BindDropdownMasterGrid();
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlreadyDropdownMaster();", true);
                    }
                }


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }

        }
        private App.BusinessModel.DropdownMaster GetDropdownMasterObject()
        {
            try
            {
                _objDropdownMaster.guid = Guid.NewGuid();
                _objDropdownMaster.dropdown_type = ddlDropdownType.SelectedValue;
                _objDropdownMaster.dropdown_item_name = txtDropdownItemName.Text;
                _objDropdownMaster.dropdown_item_alias = txtDropdownItemAlias.Text;

                return _objDropdownMaster;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objDropdownMaster;
        }
        #region Clear control
        /// <summary>
        /// This Method is Used to Clear General Form Fields
        /// </summary>
        private void ClearGeneralForm()
        {
            txtDropdownItemName.Text =txtDropdownItemAlias.Text  = string.Empty;
        }
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

        private void BindDropdownMasterGrid()
        {
            try
            {
                _objDropdownMasterBL = new DropdownMasterBL();
                _lstDropdownMaster = _objDropdownMasterBL.GetAllDropdownMasterItems().OrderByDescending(x => x.created_on).ToList();

                rptrDropdownType.DataSource = _lstDropdownMaster;
                rptrDropdownType.DataBind();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }

        #endregion

        protected void rptrDropdownType_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string commandname = e.CommandName;
            string id = e.CommandArgument.ToString();
            hdnfDropDownTypeId.Value = id;
             Int32 ID = Convert.ToInt32(id);
            switch (commandname)
            {
                case "active":
                    try
                    {
                       
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
                        _objDropdownMasterBL = new DropdownMasterBL();
                        _objDropdownMaster = _objDropdownMasterBL.GetAllDropdownMasterItems().Where(x => x.dropdown_master_id == ID).FirstOrDefault();
                        if (_objDropdownMaster !=null)
                        {
                            txtDropdownItemAlias.Text = _objDropdownMaster.dropdown_item_alias.ToString();
                            txtDropdownItemName.Text = _objDropdownMaster.dropdown_item_name.ToString();
                            ddlDropdownType.SelectedValue = _objDropdownMaster.dropdown_type;
                            btnUpdateDropdownType.Visible = true;
                            btnAddDropdownType.Visible = false;
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
                    break;

            }
        }

        protected void rptrDropdownType_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    Label lblIsActive = (Label)e.Item.FindControl("lblIsActive");
                    LinkButton btnstatusactive = (LinkButton)e.Item.FindControl("btnstatusactive");
                    LinkButton btnstatusdeactive = (LinkButton)e.Item.FindControl("btnstatusdeactive");
                    
                    string isactive = lblIsActive.Text;
                    if (isactive == "True")
                    {
                        btnstatusactive.Visible = true;
                        btnstatusdeactive.Visible = false;
                       
                    }
                    else
                    {
                        btnstatusactive.Visible = false;
                        btnstatusdeactive.Visible = true;
                      
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "notification('Something went wrong','danger');", true);
            }
        }

        protected void btnUpdateDropdownType_Click(object sender, EventArgs e)
        {
            _objDropdownMasterBL = new DropdownMasterBL();
            try
            {
                if (ddlDropdownType.SelectedValue == "0" || ddlDropdownType.SelectedValue == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlertDropDownType();", true);
                }
                else
                {
                    _objDropdownMaster = _objDropdownMasterBL.GetAllDropdownMasterItems().Where(x => x.dropdown_master_id == Convert.ToInt32(hdnfDropDownTypeId.Value)).FirstOrDefault();

                    if (_objDropdownMaster != null)
                    {
                        _objDropdownMasterBL = new DropdownMasterBL();
                        _objDropdownMaster.dropdown_type = ddlDropdownType.SelectedValue.ToString();
                        _objDropdownMaster.dropdown_item_name = txtDropdownItemName.Text;
                        _objDropdownMaster.dropdown_item_alias = txtDropdownItemAlias.Text;

                        var response = _objDropdownMasterBL.UpdateDropdownMaster(_objDropdownMaster);
                       
                        if (response.dropdown_master_id != 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccess();", true);
                            BindDropdownMasterGrid();
                            btnUpdateDropdownType.Visible = false;
                            btnAddDropdownType.Visible = true;
                            hdnfDropDownTypeId.Value = "";
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlreadyDropdownMaster();", true);
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