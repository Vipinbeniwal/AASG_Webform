using App.Business;
using App.BusinessModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AASGWeb.Modules.Admin
{
    public partial class manage_drawing_master : System.Web.UI.Page
    {
        #region Global Properties
        ActivityLog _objActivityLog = new ActivityLog();
        ActivityLogBL _objActivityLogBL = null;
        List<ActivityLog> _lstActivityLog = new List<ActivityLog>();

        vwItemListWithModelAndGlassColor _objItemListWithModelAndGlassColor = new vwItemListWithModelAndGlassColor();

        List<vwItemListWithModelAndGlassColor> _lstvwItemListWithModelAndGlassColor = new List<vwItemListWithModelAndGlassColor>();

        DrawingMaster _objDrawingMaster = new DrawingMaster();
        DrawingMasterBL _objDrawingMasterBL = null;
        List<DrawingMaster> _lstDrawingMaster = new List<DrawingMaster>();


        string UserIp = string.Empty;
        public static byte[] bytes;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                BindDrawingRptr();
                
            }
        }

        private void BindDrawingRptr()
        {
            try
            {
                _objDrawingMasterBL = new DrawingMasterBL();
                _lstDrawingMaster = _objDrawingMasterBL.GetAllDrawingMasterItems().OrderBy(x => x.drawing_master_id).ToList();
                rptrDrawingList.DataSource = _lstDrawingMaster;
                rptrDrawingList.DataBind();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        protected void rptrDrawingList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string commandname = e.CommandName;
            string id = e.CommandArgument.ToString();
          
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

                        string url = "drawing-master/" + App.Core.DataSecurity.Encryptdata(id).ToString();
                        //  string url = "view-purchase-order-bill";

                        Response.Redirect(url, false);
                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;
                case "send":
                    try
                    {
                        //string _ToEmail = "deepaksaini307@gmail.com";
                        //string _Subject = "Purchase Order Detail";
                        //string _Message = ConfigurationManager.AppSettings["documentbaseurl"].ToString() + "view-purchase-order-bill/" + App.Core.DataSecurity.Encryptdata(id).ToString();
                        //SendEmail(_ToEmail, _Subject, _Message);

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;

            }
        }

        protected void rptrDrawingList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    Label lblpic = (Label)e.Item.FindControl("lblpic");
                    Label lblIsActive = (Label)e.Item.FindControl("lblIsActive");
                    Image lblDrawingImageUrl = (Image)e.Item.FindControl("lblDrawingImageUrl");

                    string url;
                    if (string.IsNullOrEmpty(lblpic.Text))
                    {
                        url = "/Content/img/default-image.jpg";
                    }
                    else
                    {

                        url = "/assets/drawing/" + lblpic.Text;
                    }
                    lblDrawingImageUrl.ImageUrl = url;

                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "oopsToast()", true);
            }
        }
    }
}