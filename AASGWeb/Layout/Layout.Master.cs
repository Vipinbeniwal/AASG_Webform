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
using App.Core;
using App.BusinessModel;
using App.Business;

namespace AASGWeb.Layout
{
    public partial class Layout : System.Web.UI.MasterPage
    {
        #region Global Variables

        MenuMaster _objMenuMaster = new MenuMaster();
        MenuMasterBL _objMenuMasterBL = new MenuMasterBL("admin");
        List<MenuMaster> _lstMenuMaster = new List<MenuMaster>();
        List<MenuMaster> _lstMenuMasterParentTypeFOnly = new List<MenuMaster>();
        List<MenuMaster> _lstMenuMasterParentTypeROnly = new List<MenuMaster>();

        StaffMaster _objStaffMaster = new StaffMaster();
        StaffMasterBL _objStaffMasterBL = new StaffMasterBL("admin");
        List<StaffMaster> _lstStaffMaster = new List<StaffMaster>();
        List<StaffMaster> userList = new List<StaffMaster>();

        UserRole _objUserRole = new UserRole();
        UserRoleBL _objUserRoleBL = new UserRoleBL("admin");
        List<UserRole> _lstUserRole = new List<UserRole>();

        const string _menu = "menudata";

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //lbluserName.Text = Session[Constants.UserName] == null ? "User" : Convert.ToString(Session[Constants.UserName]);

                string id = Convert.ToString(Session[Constants.Id]);

                if (id == "")
                {
                    Response.Redirect(Constants.LoginPage);
                }
                else
                {
                    string RoleId = Convert.ToString(Session[Constants.RoleId]);
                    string UserId = Convert.ToString(Session[Constants.Id]);
                    _objStaffMaster = _objStaffMasterBL.GetAllStaffMasterItems().Where(x => x.user_role_id == Convert.ToInt32(RoleId) && x.staff_master_id == Convert.ToInt32(UserId)).FirstOrDefault();

                    if (_objStaffMaster == null)
                    {

                    }
                    else
                    {

                    }

                    _objUserRole = _objUserRoleBL.GetUserRoleItemsByID(Convert.ToInt32(RoleId)).FirstOrDefault();

                    string MenuIds = _objUserRole.assigned_menu_ids;
                    userList = userList = (List<StaffMaster>)Session[Constants.SessionUserList];

                    if (userList != null)
                    {

                        CreateMenu(MenuIds);
                    }
                    else
                    {
                        Response.Redirect("~/Unlock.aspx", false);
                    }
                }
                

            }
            catch (Exception ex)
            { Response.Write(ex.ToString()); }

        }

        #region create menu

        private void CreateMenu(string MenuIds)
        {

            _lstMenuMaster = _objMenuMasterBL.GetAllMenuMasterItems().ToList();

            if (!string.IsNullOrEmpty(MenuIds))
            {
                var ID = MenuIds.Split(',').Select(int.Parse).ToList();

                var displayMenus = from menu in _lstMenuMaster.AsQueryable<App.BusinessModel.MenuMaster>()
                                   where ID.Any(x => menu.menu_master_id.Equals(x))
                                   select menu;

                _lstMenuMaster = displayMenus.ToList();
            }
            var sb = new StringBuilder();
            _lstMenuMasterParentTypeROnly = _lstMenuMaster.Where(x => x.parent_id == 0).OrderBy(x => x.parent_order).ToList();

            string unorderedList = GenerateUL(_lstMenuMasterParentTypeROnly, _lstMenuMaster, sb);
            ltrlRecMenu.Text = unorderedList;
        }

        private string GenerateUL(List<MenuMaster> menuListParentsOnly, List<MenuMaster> menuListAll, StringBuilder sb)
        {
            if (menuListParentsOnly.Count > 0)
            {
                foreach (MenuMaster menu in menuListParentsOnly)
                {
                    string pageUrl = menu.page_url;
                    string menuDisplayName = menu.display_name;
                    string CssClass = menu.cssclass;
                    string line = string.Empty;

                    string pid = Convert.ToString(menu.menu_master_id);
                    string parentId = menu.parent_id.ToString();

                    if (parentId == "0")
                    {
                        line = String.Format(@"<li> <a href=""{0}"" class=""sidebar-nav-menu""><i class=""fa fa-angle-left sidebar-nav-indicator sidebar-nav-mini-hide""></i><i class=""{2}""></i><span class=""sidebar-nav-mini-hide"">{1} </span></a>", pageUrl, menuDisplayName, CssClass + " sidebar-nav-icon");
                        sb.Append(line);
                    }

                    else
                    {
                        line = String.Format(@" <li><a href=""{0}"">{1}</a></li>", pageUrl, menuDisplayName);
                        sb.Append(line);
                    }

                    List<App.BusinessModel.MenuMaster> subMenu = menuListAll.Where(x => x.parent_id == Convert.ToInt32(pid)).OrderBy(x => x.child_order).ToList();

                    if (subMenu.Count > 0 && !pid.Equals(parentId))
                    {
                        var subMenuBuilder = new StringBuilder();

                        string lineUlSub = String.Format(@"<ul class=""{0}"">", "treeview-menu");
                        subMenuBuilder.AppendLine(lineUlSub);
                        sb.Append(GenerateUL(subMenu, menuListAll, subMenuBuilder));
                    }
                    sb.Append("</li>");
                }
                sb.Append("</ul>");
            }
            return sb.ToString();
        }

        #endregion


       
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Abandon();
                Session.Clear();
                Response.Redirect(Constants.LoginPage, false);
            }
            catch (Exception ex)
            {
               
            }
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Abandon();
                Session.Clear();
                Response.Redirect(Constants.LoginPage, false);
            }
            catch(Exception ex)
            {
                Session.Abandon();
                Session.Clear();
                Response.Redirect(Constants.LoginPage,false);
            }
            
        }

        
    }
}