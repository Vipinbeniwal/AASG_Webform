using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App.Core;
using App.Business;
using App.BusinessModel;

namespace AASGWeb.Modules.Xp_Master
{
    public partial class manage_procurement : System.Web.UI.Page
    {
        #region Global Properties

        xp_ProcurementHeader _objxp_ProcurementHeader = new xp_ProcurementHeader();
        xp_ProcurementHeaderBL _objxp_ProcurementHeaderBL = null;
        List<xp_ProcurementHeader> _lstxp_ProcurementHeader = new List<xp_ProcurementHeader>();

        xp_ProcurementItem _objxp_ProcurementItem = new xp_ProcurementItem();
        xp_ProcurementItemBL _objxp_ProcurementItemBL = null;
        List<xp_ProcurementItem> _lstxp_ProcurementItem = new List<xp_ProcurementItem>();

        List<vwxp_ProcurementHeaderSupplierDetail> _lstvwxp_ProcurementHeaderSupplierDetail = new List<vwxp_ProcurementHeaderSupplierDetail>();

       


        string UserIp = string.Empty;
        
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                BindPurchaseOrderrptr();
               // BindPurchaseOrderDashboardDetails();
            }
        }

        #region Pageload method

        private void BindPurchaseOrderrptr()
        {

            DateTime date = DateTime.Now.Date;
            DateTime now = DateTime.Now;
            var _monthStartDate = new DateTime(now.Year, now.Month, 1);
            var _monthEndDate = _monthStartDate.AddMonths(1).AddDays(-1);


            _objxp_ProcurementHeaderBL = new xp_ProcurementHeaderBL();

            _lstvwxp_ProcurementHeaderSupplierDetail = _objxp_ProcurementHeaderBL.GetAllxp_ProcurementHeaderWithSupplierItems().OrderByDescending(x => x.xp_procurement_header_id).ToList();

            rptrPurchaseOrder.DataSource = _lstvwxp_ProcurementHeaderSupplierDetail;
            rptrPurchaseOrder.DataBind();
           

        }

        /// <summary>
        /// This Method Is Use dto get Purchase Order Count according to Today, Month Wise.
        /// </summary>
        private void BindPurchaseOrderDashboardDetails()
        {
            _objxp_ProcurementHeaderBL = new xp_ProcurementHeaderBL();

           // _lstvwPurchaseOrderDashboardDetail = _objxp_ProcurementHeaderBL.GetVwPurchaseOrderDashboardDatas().ToList();

           
        }


        #endregion

        protected void rptrPurchaseOrder_ItemDataBound(object sender, RepeaterItemEventArgs e)
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

        protected void rptrPurchaseOrder_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string commandname = e.CommandName;
            string id = e.CommandArgument.ToString();
            hdfdProcurementItemId.Value = id;

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

                     //   string url = "view-purchase-order-bill/" + App.Core.DataSecurity.Encryptdata(id).ToString();
                        //  string url = "view-purchase-order-bill";

                     //   Response.Redirect(url, false);
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
    }
}