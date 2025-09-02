using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using App.Helper;
using System.Web.UI;
using System.Web.UI.WebControls;
using App.Core;
using App.Business;
using App.BusinessModel;

namespace AASGWeb.Modules.Billing
{
    public partial class sale_order_item_details : System.Web.UI.Page
    {
        #region Global Properties

        SaleItem _objSaleItem = new SaleItem();
        SaleItemBL _objSaleItemBL = null;
        List<SaleItem> _lstSaleItem = new List<SaleItem>();

        vwSaleHeaderPartyDetail _objvwSaleHeader = new vwSaleHeaderPartyDetail();
        SaleHeader _objSaleHeader = new SaleHeader();
        SaleHeaderBL _objSaleHeaderBL = null;
        List<SaleHeader> _lstSaleHeader = new List<SaleHeader>();

        List<vwSaleHeaderPartyDetail> _lstSaleHeaderPartyDetail = new List<vwSaleHeaderPartyDetail>();


        string UserIp, _price_list = string.Empty;
        
        int _TotalItems;
        decimal _subTotalItemPrice, _netPriceSubTotal, _totalItemnetPrice, _lamiDiscountPercentage, _lamiBillingAmount, _toughDiscountPercentage, _toughBillingAmount, _netRateBillPercentage, _netRateBillAmount, _netRateTotalAmount, _totalBilled, _totalCash, _totalAmount, _gstAmount, _billingGrandTotal;




        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _sale_header_id;
                if (RouteData.Values["id"] == null)
                {
                    // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "editorInit();", true);
                }
                else
                {

                    string sale_header_id = RouteData.Values["id"].ToString();
                    _sale_header_id = App.Core.DataSecurity.Decryptdata(sale_header_id);
                    hdfdPurchaseNumber.Value = _sale_header_id;
                    if (_sale_header_id == "" || _sale_header_id == null)
                    {
                        Response.Redirect("/home", false);
                    }
                    else
                    {
                        BindSaleOrderItemrptr(_sale_header_id);
                        GetSaleOrderPartyDetails(_sale_header_id);

                        BindTableFooterData();
                       
                    }


                }
            }
        }


        #region Button Event remove( Update Order Status Change Button like (pending, approve))

        //protected void btnUpdateStatus_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        _objSaleHeaderBL = new SaleHeaderBL();

        //        _objSaleHeader = _objSaleHeaderBL.GetAllSaleHeaderItems().Where(x => x.sale_header_id == Convert.ToInt32(hdfdSaleOrderId.Value)).FirstOrDefault();
        //        if (_objSaleHeader.sale_header_id != 0)
        //        {
        //            _objSaleHeader = _objSaleHeaderBL.UpdateSaleHeader(GetSaleHeaderDetailsObjectForUpdate());

        //            if (_objSaleHeader.sale_header_id > 0)
        //            {
        //                //divRejectPannel.Visible = false;
        //                //btnUpdateStatus.Visible = false;
        //                //ddlOrderStatus.Enabled = false;
        //                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSaleOrderUpdate();", true);

        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
        //            }

        //        }
        //        else
        //        {

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
        //    }
        //}

        #endregion


        #region Pageload method

        #region Bind Sale Order Repeater(Table)

        /// <summary>
        /// This Method is Used to Get All Item List According to Sale Header Id  and Bind Data In Repeater
        /// </summary>
        /// <param name="_saleHeader_id"></param>
        private void BindSaleOrderItemrptr(string _saleHeader_id)
        {
            Int32 _SaleHeader_id = Convert.ToInt32(_saleHeader_id);
            _objSaleItemBL = new SaleItemBL();
            _lstSaleItem = _objSaleItemBL.GetAllSaleItemItems().Where(x => x.sale_header_id == _SaleHeader_id).OrderBy(x => x.sale_item_net_price).ToList();

            rptrSaleOrderItemDetails.DataSource = _lstSaleItem;
            rptrSaleOrderItemDetails.DataBind();


        }

        #endregion

        #region Get Sale Order Party Details
        /// <summary>
        /// This Method Is Use to Get Party Billing Details
        /// </summary>
        /// <param name="_saleHeader_id"></param>
        private void GetSaleOrderPartyDetails(string _saleHeader_id)
        {
            Int32 _SaleHeader_id = Convert.ToInt32(_saleHeader_id);
            _objSaleHeaderBL = new SaleHeaderBL();

            _lstSaleHeaderPartyDetail = _objSaleHeaderBL.GetAllSaleHeaderItemsWithPatryDetails().OrderByDescending(x => x.sale_header_id).ToList();


            _objvwSaleHeader = _lstSaleHeaderPartyDetail.Where(x => x.sale_header_id == _SaleHeader_id).FirstOrDefault();


            if (_objvwSaleHeader != null)
            {
                // _htfDiscount = Convert.ToDecimal(_objvwSaleHeader.htf_discount);

                hdfdSaleOrderId.Value = _objvwSaleHeader.sale_header_id.ToString();
                _price_list = _objvwSaleHeader.price_list.ToString();

                _lamiDiscountPercentage = Convert.ToDecimal(_objvwSaleHeader.lami_discount_precentage);
                _lamiBillingAmount = Convert.ToDecimal(_objvwSaleHeader.lami_billing_amount);
                _toughDiscountPercentage = Convert.ToDecimal(_objvwSaleHeader.tough_discount_precentage);
                _toughBillingAmount = Convert.ToDecimal(_objvwSaleHeader.tough_billing_amount);

                // Net Rate Bill Percentage and Bill Amount and Total Amount Bind in Varriable 
                _netRateBillPercentage = Convert.ToDecimal(_objvwSaleHeader.netrate_billing_precentage);
                _netRateBillAmount = Convert.ToDecimal(_objvwSaleHeader.netrate_billing_amount);
                _netRateTotalAmount = Convert.ToDecimal(_objvwSaleHeader.total_net_rate);


                _totalBilled = Convert.ToDecimal(_objvwSaleHeader.total_amount_billed);
                _totalCash = Convert.ToDecimal(_objvwSaleHeader.total_amount_cash);
                _totalAmount = Convert.ToDecimal(_objvwSaleHeader.total_amount);

                _gstAmount = Convert.ToDecimal(_objvwSaleHeader.gst_amount);
                _billingGrandTotal = Convert.ToDecimal(_objvwSaleHeader.billing_grand_total);


                lblPartyName.Text = _objvwSaleHeader.party_name;
                lblPartyAddress.Text = _objvwSaleHeader.party_address;
                lblPartyCity.Text = _objvwSaleHeader.party_city;
                lblPartyEmailId.Text = _objvwSaleHeader.party_email;
                lblPartyPhoneNumber.Text = _objvwSaleHeader.party_phoneno;
                lblPartyState.Text = _objvwSaleHeader.party_state + " , " + _objvwSaleHeader.party_pincode;

                lblshippingPartyName.Text = _objvwSaleHeader.party_name;
                lblShippiAddress.Text = _objvwSaleHeader.party_address;
                lblshippingcity.Text = _objvwSaleHeader.party_city;
                lblshippingEMailid.Text = _objvwSaleHeader.party_email;
                lblshippingPhonenumber.Text = _objvwSaleHeader.party_phoneno;
                lblshippingState.Text = _objvwSaleHeader.party_state + " , " + _objvwSaleHeader.party_pincode;
                if (_objvwSaleHeader.order_number != null)
                {
                    lblOrderNumber.Text = _objvwSaleHeader.order_number.ToString();
                }
                else
                {
                    lblOrderNumber.Text = "";
                }

                if (_objvwSaleHeader.rejection_remarks != null)
                {
                    //txtRejectionRemarks.Text = _objvwSaleHeader.rejection_remarks.ToString();
                }
                else
                {
                    //txtRejectionRemarks.Text = "";
                }


                if (_objvwSaleHeader.order_status != null)
                {
                    if (_objvwSaleHeader.order_status == "pending")
                    {
                        //ddlOrderStatus.SelectedValue = _objvwSaleHeader.order_status.ToString();
                        //divRejectPannel.Visible = true;
                        //btnUpdateStatus.Visible = true;
                        //txtRejectionRemarks.Enabled = true;
                        //ddlOrderStatus.Enabled = true;

                    }
                    else if (_objvwSaleHeader.order_status == "rejected")
                    {
                        //ddlOrderStatus.SelectedValue = _objvwSaleHeader.order_status.ToString();
                        //divRejectPannel.Visible = true;
                        //btnUpdateStatus.Visible = false;
                        //txtRejectionRemarks.Visible = true;
                        //txtRejectionRemarks.Enabled = false;
                        //ddlOrderStatus.Enabled = false;

                    }
                    else
                    {
                        //ddlOrderStatus.SelectedValue = _objvwSaleHeader.order_status.ToString();
                        //divRejectPannel.Visible = false;
                        //btnUpdateStatus.Visible = false;
                        //txtRejectionRemarks.Enabled = false;
                        //ddlOrderStatus.Enabled = false;
                    }
                }
                else
                {
                }

            }
            else
            {

            }

        }

        #endregion

        #region Bind Table Footer Row Data Like ( Total, SubTotal)
        /// <summary>
        /// This Method Is Used to Bind Table Footer Data
        /// </summary>
        private void BindTableFooterData()
        {

            //Finding the HeaderTemplate and access its controls
            Control HeaderTemplate = rptrSaleOrderItemDetails.Controls[0].Controls[0];
            Label lblPriceList = HeaderTemplate.FindControl("lblPriceList") as Label;
            lblPriceList.Text = _price_list;


            Control FooterTemplate = rptrSaleOrderItemDetails.Controls[rptrSaleOrderItemDetails.Controls.Count - 1].Controls[0];

            //Item Total According to All Items Like ( Total Item Quantity, Total Items Net Price, Total Item MRP etc)
            Label lblTotalItemQuantity = FooterTemplate.FindControl("lblTotalItemQuantity") as Label;
            Label lblItemTotalPrice = FooterTemplate.FindControl("lblItemTotalPrice") as Label;
            Label lblItemNetPrice = FooterTemplate.FindControl("lblItemNetPrice") as Label;
            Label lblTotalallPrice = FooterTemplate.FindControl("lblTotalallPrice") as Label;

            // Item Wise Discount Percentage and Bill Amount
            Label lblToughDiscountPercentage = FooterTemplate.FindControl("lblToughDiscountPercentage") as Label;
            Label lblToughBillingAmount = FooterTemplate.FindControl("lblToughBillingAmount") as Label;

            Label lblLamiDiscountPercentage = FooterTemplate.FindControl("lblLamiDiscountPercentage") as Label;
            Label lblLamiBillingAmount = FooterTemplate.FindControl("lblLamiBillingAmount") as Label;

            // All Items Net Rate Billing Percentage, and Amount and Its Total Amount
            Label lblNetRateBillingParcentage = FooterTemplate.FindControl("lblNetRateBillingParcentage") as Label;
            Label lblNetRateBillingAmount = FooterTemplate.FindControl("lblNetRateBillingAmount") as Label;
            Label lblTotalNetRateAmount = FooterTemplate.FindControl("lblTotalNetRateAmount") as Label;

            // All Items Billeable Amount, Total cash and Total Amount
            Label lblTotalBilledAmount = FooterTemplate.FindControl("lblTotalBilledAmount") as Label;
            Label LblTotalCash = FooterTemplate.FindControl("LblTotalCash") as Label;
            Label lblGstAmount = FooterTemplate.FindControl("lblGstAmount") as Label;
            Label lblTotalAmount = FooterTemplate.FindControl("lblTotalAmount") as Label;

            Label lblGrandTotalAmount = FooterTemplate.FindControl("lblGrandTotalAmount") as Label;

            // Bind Values to Footer Labels ,
            lblTotalItemQuantity.Text = _TotalItems.ToString();
            lblItemTotalPrice.Text = _subTotalItemPrice.ToString();
            lblItemNetPrice.Text = "";
            lblTotalallPrice.Text = _totalItemnetPrice.ToString();

            lblToughDiscountPercentage.Text = _toughDiscountPercentage.ToString();
            lblToughBillingAmount.Text = _toughBillingAmount.ToString();

            lblLamiDiscountPercentage.Text = _lamiDiscountPercentage.ToString();
            lblLamiBillingAmount.Text = _lamiBillingAmount.ToString();

            lblNetRateBillingParcentage.Text = _netRateBillPercentage.ToString();
            lblNetRateBillingAmount.Text = _netRateBillAmount.ToString();
            lblTotalNetRateAmount.Text = _netRateTotalAmount.ToString();

            lblTotalBilledAmount.Text = _totalBilled.ToString();
            LblTotalCash.Text = _totalCash.ToString();
            lblGstAmount.Text = _gstAmount.ToString();
            lblTotalAmount.Text = _totalAmount.ToString();
            lblGrandTotalAmount.Text = _billingGrandTotal.ToString();
        }
        #endregion

        #endregion

        #region Get Sale Order Status  Details For Update
        /// <summary>
        /// This Method is Used to Get Sale Order Status Details for Update
        /// </summary>
        /// <returns></returns>
        private App.BusinessModel.SaleHeader GetSaleHeaderDetailsObjectForUpdate()
        {
            try
            {

                _objSaleHeader.sale_header_id = _objSaleHeader.sale_header_id;
                //_objSaleHeader.rejection_remarks = txtRejectionRemarks.Text;
                //if (ddlOrderStatus.SelectedItem.Text == "approved")
                //{
                //    _objSaleHeader.order_status = Utils.OrderStatus.approved.ToString();
                //}
                //else
                //{
                //    _objSaleHeader.order_status = Utils.OrderStatus.rejected.ToString();
                //}


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objSaleHeader;
        }
        #endregion



        #region Repeater Bind 
        protected void rptrSaleOrderItemDetails_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void rptrSaleOrderItemDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    Label lblItemName = (Label)e.Item.FindControl("lblItemName");
                    Label lblItemTypetitle = (Label)e.Item.FindControl("lblItemTypetitle");
                    Label lblItemQuantity = (Label)e.Item.FindControl("lblItemQuantity");
                    Label lblItemPrice = (Label)e.Item.FindControl("lblItemPrice");
                    Label lblItemNetPrice = (Label)e.Item.FindControl("lblItemNetPrice");
                    Label lblTotalPrice = (Label)e.Item.FindControl("lblTotalPrice");
                    int _itemQuanity = Convert.ToInt32(lblItemQuantity.Text);
                    decimal Item_price = Convert.ToDecimal(lblItemPrice.Text);
                    decimal _itemNetPrice = Convert.ToDecimal(lblItemNetPrice.Text);
                    decimal _ItemAmountAfterCalulate;

                    // Calculate Amount According to Item and Its Total for Show in Table Footer lblItemNetPrice
                    if (_itemNetPrice > 0)
                    {
                        lblItemName.CssClass = "text-danger";
                        lblItemTypetitle.CssClass = "text-danger";
                        lblItemQuantity.CssClass = "text-danger";
                        lblItemPrice.CssClass = "text-danger";
                        lblItemNetPrice.CssClass = "text-danger";
                        lblTotalPrice.CssClass = "text-danger";
                        _ItemAmountAfterCalulate = _itemNetPrice * Convert.ToInt32(_itemQuanity);
                        lblTotalPrice.Text = _ItemAmountAfterCalulate.ToString();
                        _netPriceSubTotal = _netPriceSubTotal + _itemNetPrice;

                        decimal _ItemWIseNetDiscount = Item_price - _itemNetPrice;
                        decimal _percenatgeAfterCalculate = _ItemWIseNetDiscount * 100 / Item_price;
                       decimal _afterconvertindecimal= App.BusinessModel.CommonProperties.FormatDecimalNumber(_percenatgeAfterCalculate, 2);
                        lblItemNetPrice.Text = _itemNetPrice.ToString() + ' ' + '(' + _afterconvertindecimal + '%' + ')';

                    }
                    else
                    {

                        _ItemAmountAfterCalulate = Item_price * Convert.ToInt32(_itemQuanity);
                        lblTotalPrice.Text = _ItemAmountAfterCalulate.ToString();
                        _subTotalItemPrice = _subTotalItemPrice + Item_price;

                    }

                    _TotalItems = _TotalItems + _itemQuanity;

                    _totalItemnetPrice = _totalItemnetPrice + _ItemAmountAfterCalulate;
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