using App.Business;
using App.BusinessModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AASGWeb.Modules.Xp_Master
{
    public partial class manage_xp_item : System.Web.UI.Page
    {
        #region Global Properties
        ActivityLog _objActivityLog = new ActivityLog();
        ActivityLogBL _objActivityLogBL = null;
        List<ActivityLog> _lstActivityLog = new List<ActivityLog>();

        App.BusinessModel.xp_ItemMaster _objxp_ItemMaster = new App.BusinessModel.xp_ItemMaster();
        App.Business.xp_ItemMasterBL _objxp_ItemMasterBL = null;
        List<App.BusinessModel.xp_ItemMaster> _lstxp_ItemMaster = new List<App.BusinessModel.xp_ItemMaster>();

        string UserIp = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindItemsGrid();
            }
        }
        private void BindItemsGrid()
        {
            try
            {
                _objxp_ItemMasterBL = new xp_ItemMasterBL();
                _lstxp_ItemMaster = _objxp_ItemMasterBL.GetAllxp_ItemMasterItems().OrderByDescending(x => x.created_on).ToList();

                rptrManageXPItems.DataSource = _lstxp_ItemMaster;
                rptrManageXPItems.DataBind();

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }

        protected void rptrManageXPItems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string commandname = e.CommandName;
            string id = e.CommandArgument.ToString();
            hdfdXPItemId.Value = id;

            Int32 ID = Convert.ToInt32(id);
            switch (commandname)
            {
                case "active":
                    try
                    {
                        // updateStatus(id);
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

                        string url = "add-xp-item/" + App.Core.DataSecurity.Encryptdata(id).ToString();

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

        protected void rptrManageXPItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {


                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "notification('Something went wrong','danger');", true);
            }
        }

        protected void btnDownloadExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=xp_ItemMaster.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";

            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                foreach (RepeaterItem item in rptrManageXPItems.Items)
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
                rptrManageXPItems.RenderControl(hw);
                Response.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
    }
}