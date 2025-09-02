using App.Business;
using App.BusinessModel;
using App.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AASGWeb.Modules.Admin
{
    public partial class add_menu_master : System.Web.UI.Page ,ILogin
    {
        #region Global Properties
        ActivityLog _objActivityLog = new ActivityLog();
        ActivityLogBL _objActivityLogBL = null;
        List<ActivityLog> _lstActivityLog = new List<ActivityLog>();

        public LoginParams loginParams { get; set; }

        MenuMaster MenuMasterobj = new MenuMaster();
        MenuMasterBL MenuMasterBLobj = new MenuMasterBL("admin");
        List<MenuMaster> MenuMasterlstobj = new List<MenuMaster>();
       
        string UserIp = string.Empty;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

            UserIp = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (UserIp == "" || UserIp == null)

                UserIp = Request.ServerVariables["REMOTE_ADDR"];

            if (!IsPostBack)
            {
                BindMenuGrid();
                BindParentPages();
            }
        }
        #region binding methods
        private void BindMenuGrid()
        {
            try
            {
                MenuMasterBLobj = new MenuMasterBL("admin");
                rptrMenuDetails.DataSource= MenuMasterBLobj.GetAllMenuMasterItems();
                rptrMenuDetails.DataBind();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        private void BindParentPages()
        {
            try
            {
                MenuMasterlstobj = MenuMasterBLobj.GetAllMenuMasterItems().Where(x => x.parent_id == 0).OrderBy(x => x.display_name).ToList();
                lbParentPage.DataSource = MenuMasterlstobj;
                lbParentPage.DataTextField = "display_name";
                lbParentPage.DataValueField = "menu_master_id";
                lbParentPage.DataBind();
                lbParentPage.Items.Insert(0, new ListItem("Select", "0")); 
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
     
        private void BindParentPageList()
        {

        }
        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                MenuMasterobj = MenuMasterobject();
                MenuMasterobj.guid = System.Guid.NewGuid();
                MenuMasterobj = MenuMasterBLobj.CreateMenuMaster(MenuMasterobj);
                BindMenuGrid();
                BindParentPages();

               // string description = "Menu Name <b>" + MenuMasterobj.display_name + "</b> has been Added By " + loginParams.user_name;
                // Logs("Menu Added", description);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAddMenuSuccess();", true);

                Response.Redirect("/add-menu-master");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccessModal();", true);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showErrorModal();", true);
            }
        }
        private App.BusinessModel.MenuMaster MenuMasterobject()
        {
            MenuMasterobj.display_name = txtDisplayName.Text.Trim();
            MenuMasterobj.page_url = txtPageURL.Text.Trim();
            MenuMasterobj.parent_id = lbParentPage.SelectedValue == "" ? 0 : Convert.ToInt32(lbParentPage.SelectedValue); //Convert.ToInt32(lbParentPage.SelectedItem.Value == null ? 0 : Convert.ToInt32(lbParentPage.SelectedItem.Value));
            MenuMasterobj.cssclass = txtCssIcon.Text.Trim();
            MenuMasterobj.parent_order = Convert.ToInt32(txtParentOrder.Text.Trim());
            MenuMasterobj.child_order = Convert.ToInt32(txtChildOrder.Text.Trim());

            return MenuMasterobj;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            MenuMasterobj = MenuMasterBLobj.GetMenuMasterItemsByID(Convert.ToInt32(hdnMenuMasterID.Value)).FirstOrDefault();
            MenuMasterobj = MenuMasterobject();
            MenuMasterobj = MenuMasterBLobj.UpdateMenuMaster(MenuMasterobj);
            BindMenuGrid();
            BindParentPages();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showUpdateMenuSuccess();", true);
            Response.Redirect("/add-menu-master");
            //btnSubmit.Visible = true;
            //btnUpdate.Visible = false;
            //BindMenuGrid();

        }


        #region Export To Excel
        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }
        
        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=MenuMaster.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";

            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                foreach (RepeaterItem item in rptrMenuDetails.Items)
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
                rptrMenuDetails.RenderControl(hw);
                Response.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        #endregion
        private void ClearForm()
        {
            txtDisplayName.Text = txtParentOrder.Text = txtChildOrder.Text = txtCssIcon.Text = txtPageURL.Text = String.Empty;
            lbParentPage.SelectedIndex = 0;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        #region Grid Method
        
        private void DeleteData(string pid)
        {
            Int32 PID = Convert.ToInt32(pid);
            MenuMasterobj = MenuMasterBLobj.GetMenuMasterItemsByID(PID).FirstOrDefault();
            string var = MenuMasterobj.display_name;
           // MenuMasterBLobj.DeleteMenuMaster(MenuMasterobj);

            string description = "Menu Name <b>" + var + "</b> has been Deleted By " + loginParams.user_name;
            //Logs("Menu Deleted", description);
        }

        private void PopulateData(string mid)
        {
            Int32 MID = Convert.ToInt32(mid);
            MenuMasterobj = MenuMasterBLobj.GetMenuMasterItemsByID(MID).FirstOrDefault();
            lbParentPage.SelectedValue = MenuMasterobj.parent_id.ToString();
            txtDisplayName.Text = MenuMasterobj.display_name;
            txtPageURL.Text = MenuMasterobj.page_url;
            txtCssIcon.Text = MenuMasterobj.cssclass;
            txtParentOrder.Text = Convert.ToString(MenuMasterobj.parent_order);
            txtChildOrder.Text = Convert.ToString(MenuMasterobj.child_order);
            btnUpdate.Visible = true;
            btnSubmit.Visible = false;
        }

        #endregion

        #region activity logs
        private void Logs(string heading, string activity)
        {
            //try
            //{
            //    _objActivityLogBL = new ActivityLogBL(loginParams.user_name);
            //    _objActivityLog.Timestamp = DateTime.Now;
            //    _objActivityLog.Heading = heading;
            //    _objActivityLog.Activity = activity;
            //    _objActivityLog.UserId = loginParams.Id;
            //    _objActivityLog.UserName = loginParams.UserName;
            //    _objActivityLog.IpAddress = UserIp;
            //    _objActivityLogBL.CreateActivityLog(_objActivityLog);
            //}
            //catch (Exception ex)
            //{
            //    ex.Message.ToString();
            //}
        }

        #endregion

        protected void rptrMenuDetails_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string commandname = e.CommandName;
            string id = e.CommandArgument.ToString();
            hdnMenuMasterID.Value = id;

            Int32 ID = Convert.ToInt32(id);
            switch (commandname)
            {
                case "active":
                    try
                    {
                        UpdateStatus(id);
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
                        PopulateData(id);
                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;

            }
        }

        protected void rptrMenuDetails_ItemCreated(object sender, RepeaterItemEventArgs e)
        {

        }
        private void UpdateStatus(string mid)
        {
            Int64 id = Convert.ToInt64(mid);
            //_objStaffMasterBL = new StaffMasterBL();
            MenuMasterobj = MenuMasterBLobj.GetAllMenuMasterItems().Where(x => x.menu_master_id == id).FirstOrDefault();
            if (MenuMasterobj.is_active == true)
            {
                MenuMasterobj.is_active = false;
            }
            else
            {
                MenuMasterobj.is_active = true;
            }

            MenuMasterobj = MenuMasterBLobj.UpdateMenuMaster(MenuMasterobj);
            if (MenuMasterobj != null)
            {
                //string description = "Article  <b>" + _objArticle.title + "</b> status has been updated By " + loginParams.UserName;
                //Logs("Article status Updated", "fa fa-user", "timeline-icon themed-background-fire themed-border-fire", "push-bit text-danger", description);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccess();", true);
                Response.Redirect("/add-menu-master");
                BindMenuGrid();
                BindParentPages();
            }
        }

        protected void rptrMenuDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
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