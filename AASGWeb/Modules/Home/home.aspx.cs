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

namespace AASGWeb.Modules.Home
{
    public partial class home : System.Web.UI.Page
    {
        #region Global Properties

        SaleHeader _objSaleHeader = new SaleHeader();
        SaleHeaderBL _objSaleHeaderBL = null;
        List<SaleHeader> _lstSaleHeader = new List<SaleHeader>();
        List<vwSaleHeaderPartyDetail> _lstSaleHeaderPartyDetail = new List<vwSaleHeaderPartyDetail>();
        List<vwSaleOrderDashboardData> _lstvwSaleOrderDashboardDetail = new List<vwSaleOrderDashboardData>();
        vwSaleOrderDashboardData _objvwSaleOrderDashboardDetail = new vwSaleOrderDashboardData();


        string UserIp = string.Empty;
        public static decimal _itemTotalWeight = 0;
        
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                BindSaleOrderrptr();
                BindSaleOrderDashboardDetails();
                _itemTotalWeight = 0;
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
                case "edit":
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
                case "select":
                    try
                    {

                       // Label lblTotalItems = (Label)e.Item.FindControl("lblTotalItems");
                        Label lblTotalItemWeight = (Label)e.Item.FindControl("lblTotalItemWeight");
                        Label lblIscheck = (Label)e.Item.FindControl("lblIscheck");
                        string _checkStatus = lblIscheck.Text = "";
                        if (_checkStatus == "Uncheck")
                        {
                            LinkButton btnSelect = (LinkButton)e.Item.FindControl("btnSelect");
                            LinkButton btnUnSelect = (LinkButton)e.Item.FindControl("btnUnSelect");
                            btnSelect.Visible = true;
                            btnUnSelect.Visible = false;
                            _itemTotalWeight = _itemTotalWeight + Convert.ToDecimal(lblTotalItemWeight.Text);
                            lblPatryTotalItemsCount.Text = _itemTotalWeight.ToString() + " Kg";

                        }
                        else
                        {
                            LinkButton btnSelect = (LinkButton)e.Item.FindControl("btnSelect");
                            LinkButton btnUnSelect = (LinkButton)e.Item.FindControl("btnUnSelect");
                            btnSelect.Visible = false;
                            btnUnSelect.Visible = true;
                            _itemTotalWeight = _itemTotalWeight - Convert.ToDecimal(lblTotalItemWeight.Text);
                            lblPatryTotalItemsCount.Text = _itemTotalWeight.ToString() + " Kg";
                        }

                    }

                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;
                case "unselect":
                    try
                    {

                        // Label lblTotalItems = (Label)e.Item.FindControl("lblTotalItems");
                        Label lblTotalItemWeight = (Label)e.Item.FindControl("lblTotalItemWeight");
                        Label lblIscheck = (Label)e.Item.FindControl("lblIscheck");
                        string _checkStatus = lblIscheck.Text = "";
                        if (_checkStatus == "Uncheck")
                        {
                            LinkButton btnSelect = (LinkButton)e.Item.FindControl("btnSelect");
                            LinkButton btnUnSelect = (LinkButton)e.Item.FindControl("btnUnSelect");
                            btnSelect.Visible = false;
                            btnUnSelect.Visible = true;
                            _itemTotalWeight = _itemTotalWeight - Convert.ToDecimal(lblTotalItemWeight.Text);
                            lblPatryTotalItemsCount.Text = _itemTotalWeight.ToString() + " Kg";

                        }
                        else
                        {
                            LinkButton btnSelect = (LinkButton)e.Item.FindControl("btnSelect");
                            LinkButton btnUnSelect = (LinkButton)e.Item.FindControl("btnUnSelect");
                            btnSelect.Visible = true;
                            btnUnSelect.Visible = false;
                            _itemTotalWeight = _itemTotalWeight + Convert.ToDecimal(lblTotalItemWeight.Text);
                            lblPatryTotalItemsCount.Text = _itemTotalWeight.ToString() + " Kg";
                        }

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
                    //Label lblIscheck = (Label)e.Item.FindControl("lblIscheck");
                    //LinkButton btnSelect = (LinkButton)e.Item.FindControl("btnSelect");
                    //LinkButton btnUnSelect = (LinkButton)e.Item.FindControl("btnUnSelect");

                   // Label lblSaleHeaderCode = (Label)e.Item.FindControl("lblSaleOrderId");
                    //if (lblSaleHeaderCode.Text == "2")
                    //{
                    //    e.Item.FindControl("chkSaleOrder").Visible = false;
                    //}

                    string isOrder_status = lblOrderStatus.Text;
                    //string ischkSelect = lblIscheck.Text;
                    if (isOrder_status == "pending")
                    {

                        lblOrderStatus.CssClass = "label label-primary";
                        //chkActive.Checked=true;

                    }
                    else if (isOrder_status == "production")
                    {
                        CheckBox chkSaleOrder = (CheckBox)e.Item.FindControl("chkSaleOrder");
                        chkSaleOrder.Visible = false;
                        lblOrderStatus.CssClass = "label label-success";
                        //chkActive.Checked=true;

                    }
                    else if (isOrder_status == "approved")
                    {
                        lblOrderStatus.CssClass = "label label-success";
                    }
                    else if (isOrder_status == "complete")
                    {
                        CheckBox chkSaleOrder = (CheckBox)e.Item.FindControl("chkSaleOrder");
                        chkSaleOrder.Visible = false;
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

        protected void chkSaleOrder_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox _checkboxSaleOrder = (CheckBox)sender;
            RepeaterItem item = (RepeaterItem)_checkboxSaleOrder.NamingContainer;
           // Label lblTotalItems = (Label)item.FindControl("lblTotalItems");
            Label lblTotalItemWeight = (Label)item.FindControl("lblTotalItemWeight");
            Label lblOrderStatus = (Label)item.FindControl("lblOrderStatus");

            if (lblOrderStatus.Text == App.Helper.Utils.OrderStatus.approved.ToString())
            {
                if (_checkboxSaleOrder.Checked == true)
                {
                    _itemTotalWeight = _itemTotalWeight + Convert.ToDecimal(lblTotalItemWeight.Text);
                    lblPatryTotalItemsCount.Text = _itemTotalWeight.ToString() + " Kg";


                }
                else
                {
                    _itemTotalWeight = _itemTotalWeight - Convert.ToDecimal(lblTotalItemWeight.Text);
                    lblPatryTotalItemsCount.Text = _itemTotalWeight.ToString() + " Kg";
                }
            }
            else
            {
                _checkboxSaleOrder.Checked = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "notification('Sorry Only Approved SaleOrder Added','danger');", true);

            }

          


        }

        protected void btnSubmitToProduction_Click(object sender, EventArgs e)
        {
            string totalitem = null;
            string totalpartyitem = null;
            foreach (RepeaterItem item2 in rptrSaleOrder.Items)
            {
                Label lblSaleOrderId = (Label)item2.FindControl("lblSaleOrderId");
                Label lblPartyMasterId = (Label)item2.FindControl("lblPartyMasterId");
                CheckBox chkSaleOrder = (CheckBox)item2.FindControl("chkSaleOrder");

                if (chkSaleOrder.Checked == true)
                {
                    string selectedItem = lblSaleOrderId.Text + ",";
                    totalitem = totalitem + selectedItem;

                    string selectedPartyItem = lblPartyMasterId.Text + ",";
                    totalpartyitem = totalpartyitem + selectedPartyItem;
                }

            }

            if (totalpartyitem==null)
            {
              //  ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "notification('Something went wrong','danger');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showPartyAlert();", true);
            }
            else
            {
                
                string saleheaderid = totalitem.TrimEnd(',');
                string partyid = totalpartyitem.TrimEnd(',');

                if (saleheaderid.Length > 0)
                {
                    Response.Redirect("production/plan-production/" + App.Core.DataSecurity.Encryptdata(saleheaderid).ToString() + "/" + App.Core.DataSecurity.Encryptdata(partyid).ToString(), false);
                }
                else
                {

                }
            }
            
            //string _selectedsaleorderid , _Totalsaleorderid = string.Empty;

            //foreach (RepeaterItem _itemList in rptrSaleOrder.Items)
            //{
            //    CheckBox _chksaleorder = (CheckBox)_itemList.FindControl("chksaleorder");
            //    Label lblsaleorderid = (Label)_itemList.FindControl("lblsaleorderid");
            //    if (_chksaleorder.Checked == true)
            //    {

            //        _selectedsaleorderid = lblsaleorderid.Text + ",";
            //        _Totalsaleorderid = _Totalsaleorderid + _selectedsaleorderid;
            //    }
            //    else
            //    {
            //    }

            //}
            //string _finalSelectedSaleOrderId = _Totalsaleorderid.TrimEnd(',');
            ////string _finalSelectedSaleOrderPartyId = _Totalsaleorderid.TrimEnd(',');
            //if (_finalSelectedSaleOrderId.Length > 0)
            //{
            //    string url = "production/plan-production/" + App.Core.DataSecurity.Encryptdata(_finalSelectedSaleOrderId).ToString();
            //    //string url = "production/plan-production/" + App.Core.DataSecurity.Encryptdata(_finalSelectedSaleOrderId).ToString()+"/"+ App.Core.DataSecurity.Encryptdata(_finalSelectedSaleOrderPartyId).ToString();
            //    // string url = "view-purchase-order-bill";

            //    Response.Redirect(url, false);
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "notification('Something went wrong','danger');", true);
            //}
        }
    }
}