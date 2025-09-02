using App.Business;
using App.BusinessModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AASGWeb.Modules.Admin
{
    public partial class add_role : System.Web.UI.Page
    {
        #region Global Properties
        ActivityLog _objActivityLog = new ActivityLog();
        ActivityLogBL _objActivityLogBL = null;
        List<ActivityLog> _lstActivityLog = new List<ActivityLog>();

        UserRole _objUserRole = new UserRole();
        UserRoleBL _objUserRoleBL = null;
        List<UserRole> _lstUserRole = new List<UserRole>();

        MenuMaster MenuMasterobj = new MenuMaster();
        MenuMasterBL MenuMasterBLobj = new MenuMasterBL("admin");
        List<MenuMaster> MenuMasterlstobj = new List<MenuMaster>();

        string UserIp = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                string _roleid;
                if (RouteData.Values["id"] == null)
                {
                    // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "editorInit();", true);
                }
                else
                {

                    string _role_master_id = RouteData.Values["id"].ToString();
                    _roleid = App.Core.DataSecurity.Decryptdata(_role_master_id);
                    if (_roleid == "" || _roleid == null)
                    {
                        Response.Redirect("/home", false);
                    }
                    else
                    {
                        hdfdroleId.Value = _roleid;

                        if (hdfdroleId.Value == "")
                        {
                            Response.Redirect("/home", false);

                        }
                        else
                        {
                            PopulateData(_roleid);
                            
                        }

                    }
                   

                }
                BindMenus();
            }
        }

        #region  Page Load Method
        #region Get User Role Data

        private void PopulateData(string _roleid)
        {
            try
            {
                Int32 USERROLEID = Convert.ToInt32(_roleid);

                _objUserRoleBL = new UserRoleBL();
                _objUserRole = _objUserRoleBL.GetUserRoleItemsByID(Convert.ToInt32(USERROLEID)).FirstOrDefault();
                if (_objUserRole.user_role_id > 0)
                {
                    btnUpdateRole.Visible = true;
                    btnAddRole.Visible = false;
                    txtRoleName.Text = _objUserRole.user_role_name.ToString();

                    //  ddlAssignedMenu.SelectedValue = _objUserRole.user_role_id.ToString();
                    //  _objLoanTypeModel = _lstLoanTypeModel.Where(x => x.loan_name.ToLower() == value.ToLower() && x.is_active == true).FirstOrDefault();

                    string AssignedMenusId = _objUserRole.assigned_menu_ids;

                    if (!string.IsNullOrEmpty(AssignedMenusId))
                    {
                        string lasttm = AssignedMenusId.TrimEnd(',');
                        string[] arrOfSelections = lasttm.Split(',');
                        foreach (string value in arrOfSelections)
                        {
                            if (value == "1")
                            {
                                ddlAssignedMenu.Items.Add(new ListItem() { Text = "Item", Value = value, Selected = true });
                            }
                            else if (value == "2")
                            {
                                ddlAssignedMenu.Items.Add(new ListItem() { Text = "Party", Value = value, Selected = true });
                            }
                            else if (value == "3")
                            {
                                ddlAssignedMenu.Items.Add(new ListItem() { Text = "Supplier", Value = value, Selected = true });
                            }
                            else
                            {
                                ddlAssignedMenu.Items.Add(new ListItem() { Text = "Stock", Value = value, Selected = true });
                            }
                        }
                    }

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

        private void BindMenus()
        {
            try
            {
                MenuMasterlstobj = MenuMasterBLobj.GetAllMenuMasterItems().Where(x=>x.is_active == true).OrderBy(x => x.display_name).ToList();
                ddlAssignedMenu.DataSource = MenuMasterlstobj;
                ddlAssignedMenu.DataTextField = "display_name";
                ddlAssignedMenu.DataValueField = "menu_master_id";
                ddlAssignedMenu.DataBind();
                ddlAssignedMenu.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        #endregion

        #endregion

        protected void btnAddRole_Click(object sender, EventArgs e)
        {
            _objUserRoleBL = new UserRoleBL();
            try
            {
                _lstUserRole = _objUserRoleBL.GetAllUserRoleItems().Where(x => x.user_role_name.ToLower() == txtRoleName.Text.ToLower()).ToList();

                if (_lstUserRole.Count == 0)
                {
                    _objUserRoleBL = new UserRoleBL();
                    var response = _objUserRoleBL.CreateUserRole(GetUserRoleObject());

                    if (response.user_role_id != 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccess();", true);
                        ClearGeneralForm();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlreadyUserRole();", true);
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
        }
        private App.BusinessModel.UserRole GetUserRoleObject()
        {
            try
            {
                _objUserRole.guid = Guid.NewGuid();
                _objUserRole.user_role_name = txtRoleName.Text;
                _objUserRole.assigned_menu_ids = "0";

                if (ddlAssignedMenu.Items.Count > 0)
                {
                    string totalitem = null;
                    for (int i = 0; i < ddlAssignedMenu.Items.Count; i++)
                    {
                        if (ddlAssignedMenu.Items[i].Selected)
                        {
                            string selectedItem = ddlAssignedMenu.Items[i].Value + ",";
                            //insert command
                            totalitem = totalitem + selectedItem;
                        }
                    }
                    string lasttm = totalitem.TrimEnd(',');
                    _objUserRole.assigned_menu_ids = lasttm;
                }

             //   ddlAssignedMenu.DataTextField = Convert.ToString(_objUserRole.assigned_menu_ids);




                return _objUserRole;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objUserRole;
        }
        #region Clear control
        /// <summary>
        /// This Method is Used to Clear General Form Fields
        /// </summary>
        private void ClearGeneralForm()
        {
            txtRoleName.Text = string.Empty;
            BindMenus();
            btnUpdateRole.Visible = false;
        }
        #endregion

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearGeneralForm();
        }

        protected void btnUpdateRole_Click(object sender, EventArgs e)
        {
            _objUserRoleBL = new UserRoleBL();
            try
            {
                _objUserRole = _objUserRoleBL.GetAllUserRoleItems().Where(x => x.user_role_name.ToLower() == txtRoleName.Text.ToLower()).FirstOrDefault();

                if (_objUserRole.user_role_id > 0)
                {
                    _objUserRoleBL = new UserRoleBL();
                    var response = _objUserRoleBL.UpdateUserRole(GetUserRoleUpdateObject());

                    if (response.user_role_id != 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccess();", true);
                        ClearGeneralForm();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlreadyUserRole();", true);
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
        }
        private App.BusinessModel.UserRole GetUserRoleUpdateObject()
        {
            try
            {
                //_objUserRole.user_role_id = Convert.ToInt32(hdfdroleId.Value);
                _objUserRole.user_role_name = txtRoleName.Text;
                
                if (ddlAssignedMenu.Items.Count > 0)
                {
                    string totalitem = null;
                    for (int i = 0; i < ddlAssignedMenu.Items.Count; i++)
                    {
                        if (ddlAssignedMenu.Items[i].Selected)
                        {
                            string selectedItem = ddlAssignedMenu.Items[i].Value + ",";
                            //insert command
                            totalitem = totalitem + selectedItem;
                        }
                    }
                    string lasttm = totalitem.TrimEnd(',');
                    _objUserRole.assigned_menu_ids = lasttm;
                }

                //   ddlAssignedMenu.DataTextField = Convert.ToString(_objUserRole.assigned_menu_ids);




                return _objUserRole;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objUserRole;
        }
    }
}