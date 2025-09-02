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

namespace AASGWeb.Modules.Billing
{
    public partial class manage_sale_orders : System.Web.UI.Page
    {
        #region Global Properties

        App.BusinessModel.SaleHeader _objSaleHeader = new App.BusinessModel.SaleHeader();
        App.Business.SaleHeaderBL _objSaleHeaderBL = null;
        List<App.BusinessModel.SaleHeader> _lstSaleHeader = new List<App.BusinessModel.SaleHeader>();

        List<App.BusinessModel.vwSaleHeaderPartyDetail> _lstSaleHeaderPartyDetail = new List<App.BusinessModel.vwSaleHeaderPartyDetail>();

        List<App.BusinessModel.vwSaleOrderDashboardData> _lstvwSaleOrderDashboardDetail = new List<App.BusinessModel.vwSaleOrderDashboardData>();
        App.BusinessModel.vwSaleOrderDashboardData _objvwSaleOrderDashboardDetail = new App.BusinessModel.vwSaleOrderDashboardData();
       


        string UserIp = string.Empty;
        
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSaleOrderrptr();
                BindSaleOrderDashboardDetails();
            }
        }

        #region Pageload method

        private void BindSaleOrderrptr()
        {
            _objSaleHeaderBL = new SaleHeaderBL();

            _lstSaleHeaderPartyDetail = _objSaleHeaderBL.GetAllSaleHeaderItemsWithPatryDetails().OrderByDescending(x => x.sale_header_id).ToList();
            rptrSaleOrder.DataSource = _lstSaleHeaderPartyDetail;
            rptrSaleOrder.DataBind();
        }

        /// <summary>
        /// This Method Is Use dto get Order Count according to Today, Month Wise.
        /// </summary>
        private void BindSaleOrderDashboardDetails()
        {
            _objSaleHeaderBL = new SaleHeaderBL();

            _lstvwSaleOrderDashboardDetail = _objSaleHeaderBL.GetVwSaleOrderDashboardDatas().ToList();

            if (_lstvwSaleOrderDashboardDetail != null)
            {
                _objvwSaleOrderDashboardDetail = _lstvwSaleOrderDashboardDetail.Where(x => x.Attribute == "TodaySaleOrder").FirstOrDefault();

                if (_objvwSaleOrderDashboardDetail != null)
                {
                    lblTodaySaleOrders.Text = _objvwSaleOrderDashboardDetail.Value.ToString();
                    lblOrderAmountToday.Text = _objvwSaleOrderDashboardDetail.Total_Amount.ToString();
                }

                _objvwSaleOrderDashboardDetail = _lstvwSaleOrderDashboardDetail.Where(x => x.Attribute == "CurrentMonthSaleOrder").FirstOrDefault();

                if (_objvwSaleOrderDashboardDetail != null)
                {
                    lblCurrentMonthSaleOrders.Text = _objvwSaleOrderDashboardDetail.Value.ToString();
                    lblOrderAmountCurrentMonth.Text = _objvwSaleOrderDashboardDetail.Total_Amount.ToString();
                }

                _objvwSaleOrderDashboardDetail = _lstvwSaleOrderDashboardDetail.Where(x => x.Attribute == "LastMonthSaleOrder").FirstOrDefault();

                if (_objvwSaleOrderDashboardDetail != null)
                {
                    lblLastMonthSaleOrder.Text = _objvwSaleOrderDashboardDetail.Value.ToString();
                    lblOrderAmountLastMonth.Text = _objvwSaleOrderDashboardDetail.Total_Amount.ToString();
                }

            }
            else
            {

            }
        }

        #endregion

        protected void rptrSaleOrder_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string commandname = e.CommandName;
            string id = e.CommandArgument.ToString();
            hdfdSaleOrderId.Value = id;

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
                case "view":
                    try
                    {

                        string url = "sale-order-item-details/" + App.Core.DataSecurity.Encryptdata(id).ToString();
                        // string url = "view-purchase-order-bill";

                        Response.Redirect(url, false);
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

                        string url = "add-sale-order/" + App.Core.DataSecurity.Encryptdata(id).ToString();
                        
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

        protected void rptrSaleOrder_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {


                    Label lblOrderStatus = (Label)e.Item.FindControl("lblOrderStatus");
                    //CheckBox chkActive=(CheckBox)e.Item.FindControl("chkActive");
                    string isOrder_status = lblOrderStatus.Text;
                    if (isOrder_status == "pending")
                    {

                        lblOrderStatus.CssClass = "label label-primary";
                        //chkActive.Checked=true;

                    }
                    else if (isOrder_status == "approved")
                    {
                        lblOrderStatus.CssClass = "label label-success";
                    }
                    else
                    {
                        lblOrderStatus.CssClass = "label label-danger";
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