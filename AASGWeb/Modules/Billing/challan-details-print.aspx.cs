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
    public partial class challan_details_print : System.Web.UI.Page
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
        vwSaleHeaderPartyDetail _objSaleHeaderPartyDetail = new vwSaleHeaderPartyDetail();

        ChallanHeader _objChallanHeader = new ChallanHeader();
        ChallanHeaderBL _objChallanHeaderBL = null;
        List<ChallanHeader> _lstChallanHeader = new List<ChallanHeader>();

        ChallanItem _objChallanItem = new ChallanItem();
        ChallanItemBL _objChallanItemBL = null;
        List<ChallanItem> _lstChallanItem = new List<ChallanItem>();


        string UserIp = string.Empty;
        
        int _totalItemQuantity , _totalItemQuantity2, _toughBillPercentage, _toughBillPercentage2, _netBillingPercentage, _netBillingPercentage2= 0;
        Decimal _sUbTotalIAmount, _mainTotalIAmount, _totalGstAmount, _totalBillAmount, _totalCashAmount, _toughDiscountPercentage = 0;
        Decimal _sUbTotalIAmount2, _mainTotalIAmount2, _totalGstAmount2, _totalBillAmount2, _totalCashAmount2, _toughDiscountPercentage2 = 0;

        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                string _saleHederId,_challan_master_id;
                if (RouteData.Values["id"] == null)
                {
                    // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "editorInit();", true);
                }
                else
                {

                    string sale_header_id = RouteData.Values["id"].ToString();
                    string challan_header_id = RouteData.Values["challanid"].ToString();

                    _saleHederId = App.Core.DataSecurity.Decryptdata(sale_header_id);
                    _challan_master_id = App.Core.DataSecurity.Decryptdata(challan_header_id);
                    hdfdSaleOrderNumber.Value = _saleHederId;
                    if (_saleHederId == "" || _saleHederId == null)
                    {
                        Response.Redirect("/home", false);
                    }
                    else
                    {
                        GetSaleOrderPartyDetails(_saleHederId);
                        GetChallanHeaderDetails(_saleHederId, _challan_master_id);
                        // BindSaleItemrptr(_saleHederId);
                        BindChallanItemrptr(_saleHederId, _challan_master_id);
                        BindTableFooterData();
                        BindTableFooterData2();


                    }


                }

               
            }
        }


        #region Repeater Code

        protected void rptrPurchaseItems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void rptrItemList2_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void rptrItemList2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {

                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    Label lblItemQuantity = (Label)e.Item.FindControl("lblItemQuantity");
                    Label lblItemPrice = (Label)e.Item.FindControl("lblItemPrice");
                    Label lblItemAmount = (Label)e.Item.FindControl("lblItemAmount");
                    Label lblSaleItemNetPrice = (Label)e.Item.FindControl("lblSaleItemNetPrice");
                    Label lblItemTotalAmount = (Label)e.Item.FindControl("lblItemTotalAmount");

                    Label lblItemBilledAmount = (Label)e.Item.FindControl("lblItemBilledAmount");
                    Label lblItemGSTAmount = (Label)e.Item.FindControl("lblItemGSTAmount");


                    int _itemQuanity = Convert.ToInt32(lblItemQuantity.Text);
                    decimal Item_price = Convert.ToDecimal(lblItemPrice.Text);
                    decimal _itemNetPrice = Convert.ToDecimal(lblSaleItemNetPrice.Text);

                    decimal _Itemgst_amount = Convert.ToDecimal(lblItemGSTAmount.Text);
                    decimal _item_BilledAmount = Convert.ToDecimal(lblItemBilledAmount.Text);

                    _totalGstAmount2 = _totalGstAmount2 + _Itemgst_amount;
                    _totalBillAmount2 = _totalBillAmount2 + _item_BilledAmount;

                    if (_itemNetPrice > 0)
                    {
                        lblItemPrice.Text = "0";
                    }
                    else
                    { }

                    _totalItemQuantity2 = _totalItemQuantity2 + _itemQuanity;
                    _sUbTotalIAmount2 = _sUbTotalIAmount2 + Convert.ToDecimal(lblItemAmount.Text);
                    _mainTotalIAmount2 = _mainTotalIAmount2 + Convert.ToDecimal(lblItemTotalAmount.Text);
                }


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "notification('Something went wrong','danger');", true);
            }
        }

        protected void rptrPurchaseItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {

                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    Label lblItemQuantity = (Label)e.Item.FindControl("lblItemQuantity");
                    Label lblItemPrice = (Label)e.Item.FindControl("lblItemPrice");
                    Label lblItemAmount = (Label)e.Item.FindControl("lblItemAmount");
                    Label lblSaleItemNetPrice = (Label)e.Item.FindControl("lblSaleItemNetPrice");
                    Label lblItemTotalAmount = (Label)e.Item.FindControl("lblItemTotalAmount");

                    Label lblItemBilledAmount = (Label)e.Item.FindControl("lblItemBilledAmount");
                    Label lblItemGSTAmount = (Label)e.Item.FindControl("lblItemGSTAmount");
                    

                    int _itemQuanity = Convert.ToInt32(lblItemQuantity.Text);
                    decimal Item_price = Convert.ToDecimal(lblItemPrice.Text);
                    decimal _itemNetPrice = Convert.ToDecimal(lblSaleItemNetPrice.Text);

                    decimal _Itemgst_amount = Convert.ToDecimal( lblItemGSTAmount.Text);
                    decimal _item_BilledAmount = Convert.ToDecimal(lblItemBilledAmount.Text);

                    _totalGstAmount = _totalGstAmount + _Itemgst_amount;
                    _totalBillAmount = _totalBillAmount + _item_BilledAmount;

                    if (_itemNetPrice > 0)
                    {  
                        lblItemPrice.Text = "0";
                       // lblItemAmount.Text = lblSaleItemNetPrice.Text;

                    }
                    else
                    { }

                    _totalItemQuantity = _totalItemQuantity + _itemQuanity;
                    _sUbTotalIAmount = _sUbTotalIAmount + Convert.ToDecimal(lblItemAmount.Text);
                    _mainTotalIAmount = _mainTotalIAmount + Convert.ToDecimal(lblItemTotalAmount.Text);

                }



            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "notification('Something went wrong','danger');", true);
            }
        }


        private void BindSaleItemrptr(string _saleOrderId)
        {
            Int32 _SaleHeader_id = Convert.ToInt32(_saleOrderId);
            _objSaleItemBL = new SaleItemBL();
            _lstSaleItem = _objSaleItemBL.GetAllSaleItemItems().Where(x => x.sale_header_id == _SaleHeader_id).OrderBy(x => x.sale_item_net_price).ToList();//   _objsp_GetSaleDetail_Result = _objsp_GetSaleDetail_ResultBL.GetAllsp_GetSaleDetail_ResultItems().Where(x => x.sale_header_id == Convert.ToInt32(saleid)).FirstOrDefault();

            rptrPurchaseItems.DataSource = _lstSaleItem;
            rptrPurchaseItems.DataBind();
            _objSaleItem = _lstSaleItem.Where(x => x.sale_header_id == _SaleHeader_id).FirstOrDefault();

        }


        private void BindChallanItemrptr(string _saleOrderId, string _challanId)
        {
            Int32 _SaleHeader_id = Convert.ToInt32(_saleOrderId);
            Int32 _ChallanId = Convert.ToInt32(_challanId);
            _objChallanItemBL = new ChallanItemBL();
            _lstChallanItem = _objChallanItemBL.GetAllChallanItemItems().Where(x => x.sale_header_id == _SaleHeader_id & x.challan_header_id == _ChallanId).OrderBy(x => x.sale_item_net_price).ToList();//   _objsp_GetSaleDetail_Result = _objsp_GetSaleDetail_ResultBL.GetAllsp_GetSaleDetail_ResultItems().Where(x => x.sale_header_id == Convert.ToInt32(saleid)).FirstOrDefault();

            rptrPurchaseItems.DataSource = _lstChallanItem.Where(x => x.item_gst_percentage == 18).ToList();
            rptrPurchaseItems.DataBind();

            rptrItemList2.DataSource = _lstChallanItem.Where(x => x.item_gst_percentage == 28).ToList();
            rptrItemList2.DataBind();
            _objChallanItem = _lstChallanItem.Where(x => x.sale_header_id == _SaleHeader_id & x.challan_header_id == _ChallanId).FirstOrDefault();

        }

        /// <summary>
        /// This Method Is Used to Bind Table Footer Data
        /// </summary>
        private void BindTableFooterData()
        {
            try
            {
                Control FooterTemplate = rptrPurchaseItems.Controls[rptrPurchaseItems.Controls.Count - 1].Controls[0];
                Label lblsubTotal = FooterTemplate.FindControl("lblsubTotal") as Label;
                Label lblmainTotal = FooterTemplate.FindControl("lblmainTotal") as Label;
                Label lblTotalGst = FooterTemplate.FindControl("lblTotalGst") as Label;
                Label lblTotalBillableAmount = FooterTemplate.FindControl("lblTotalBillableAmount") as Label;
                Label lblTotalCashAmount = FooterTemplate.FindControl("lblTotalCashAmount") as Label;
                Label lblTotalItemQuantity = FooterTemplate.FindControl("lblTotalItemQuantity") as Label;

                lblsubTotal.Text = _sUbTotalIAmount.ToString();
                lblmainTotal.Text =_mainTotalIAmount.ToString();
                lblTotalGst.Text = _totalGstAmount.ToString();
                lblTotalBillableAmount.Text =  (_totalBillAmount + _totalGstAmount).ToString();
                // lblTotalCashAmount.Text = _totalCashAmount.ToString();
                _totalCashAmount = ((_mainTotalIAmount + _totalGstAmount) - (_totalBillAmount + _totalGstAmount));
                lblTotalCashAmount.Text = _totalCashAmount.ToString();

                lblTotalItemQuantity.Text = _totalItemQuantity.ToString();

                _sUbTotalIAmount = _mainTotalIAmount = _totalGstAmount = _totalBillAmount = _totalCashAmount =  0;
                _totalItemQuantity = 0;
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }
            
        }

        /// <summary>
        /// This Method Is Used to Bind Table Footer Data
        /// </summary>
        private void BindTableFooterData2()
        {
            try
            {
                Control FooterTemplate = rptrItemList2.Controls[rptrItemList2.Controls.Count - 1].Controls[0];
                Label lblsubTotal = FooterTemplate.FindControl("lblsubTotal") as Label;
                Label lblmainTotal = FooterTemplate.FindControl("lblmainTotal") as Label;
                Label lblTotalGst = FooterTemplate.FindControl("lblTotalGst") as Label;
                Label lblTotalBillableAmount = FooterTemplate.FindControl("lblTotalBillableAmount") as Label;
                Label lblTotalCashAmount = FooterTemplate.FindControl("lblTotalCashAmount") as Label;
                Label lblTotalItemQuantity = FooterTemplate.FindControl("lblTotalItemQuantity") as Label;

                //lblsubTotal.Text = _sUbTotalIAmount2.ToString();
                //lblmainTotal.Text = _mainTotalIAmount2.ToString();
                //lblTotalGst.Text = _totalGstAmount2.ToString();
                //lblTotalBillableAmount.Text = _totalBillAmount2.ToString();
                //lblTotalCashAmount.Text = _totalCashAmount2.ToString();

                lblsubTotal.Text = _sUbTotalIAmount2.ToString();
                lblmainTotal.Text = _mainTotalIAmount2.ToString();
                lblTotalGst.Text = _totalGstAmount2.ToString();
                lblTotalBillableAmount.Text = (_totalBillAmount2 + _totalGstAmount2).ToString();
                
                _totalCashAmount2 = ((_mainTotalIAmount2 + _totalGstAmount2) - (_totalBillAmount2 + _totalGstAmount2));
                lblTotalCashAmount.Text = _totalCashAmount2.ToString();

                lblTotalItemQuantity.Text = _totalItemQuantity2.ToString();

                _sUbTotalIAmount2 = _mainTotalIAmount2 = _totalGstAmount2 = _totalBillAmount2 = _totalCashAmount2 = 0;
                _totalItemQuantity2 = 0;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

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

            _lstSaleHeaderPartyDetail = _objSaleHeaderBL.GetAllSaleHeaderItemsWithPatryDetails().Where(x => x.sale_header_id == _SaleHeader_id).ToList();

            //rptrPurchaseItems.DataSource = _lstSaleHeaderPartyDetail;
            //rptrPurchaseItems.DataBind();

            _objSaleHeaderPartyDetail = _lstSaleHeaderPartyDetail.Where(x => x.sale_header_id == _SaleHeader_id).FirstOrDefault();

            if(_objSaleHeaderPartyDetail != null)
            {
                lblClientname.Text = _objSaleHeaderPartyDetail.party_name;
                lblClientAddress.Text = _objSaleHeaderPartyDetail.party_address + " , " + _objSaleHeaderPartyDetail.party_state;
                lblPartyName.Text = _objSaleHeaderPartyDetail.party_name;
                lblState.Text = _objSaleHeaderPartyDetail.party_state;
                lblGSTNumber.Text = _objSaleHeaderPartyDetail.party_gst;
                lblBillNumber.Text = _objSaleHeaderPartyDetail.order_number;
                lblDate.Text = _objSaleHeaderPartyDetail.sale_item_date.ToShortDateString();
                lblBillPercentage.Text = _objSaleHeaderPartyDetail.tough_billing_precentage.ToString();
               // lblDiscount.Text = _objSaleHeaderPartyDetail.tough_discount.ToString();
                lblDiscount.Text = _objSaleHeaderPartyDetail.tough_discount_precentage.ToString();

                //_totalCashAmount = Convert.ToDecimal(_objSaleHeaderPartyDetail.total_amount_cash);
                //_totalBillAmount = Convert.ToDecimal(_objSaleHeaderPartyDetail.total_amount_billed);
                //_totalGstAmount = Convert.ToDecimal(_objSaleHeaderPartyDetail.gst_amount);
                //_toughDiscountPercentage = Convert.ToDecimal(_objSaleHeaderPartyDetail.tough_discount_precentage);
                //_totalItemQuantity = _objSaleHeaderPartyDetail.total_items;
                //_toughBillPercentage = _objSaleHeaderPartyDetail.tough_billing_precentage;
                //_netBillingPercentage = _objSaleHeaderPartyDetail.netrate_billing_precentage;

                #region Second Table header Party Details

                lblClientname2.Text = _objSaleHeaderPartyDetail.party_name;
                lblClientAddress2.Text = _objSaleHeaderPartyDetail.party_address + " , " + _objSaleHeaderPartyDetail.party_state;
                lblPartyName2.Text = _objSaleHeaderPartyDetail.party_name;
                lblState2.Text = _objSaleHeaderPartyDetail.party_state;
                lblGSTNumber2.Text = _objSaleHeaderPartyDetail.party_gst;
                lblBillNumber2.Text = _objSaleHeaderPartyDetail.order_number;
                lblDate2.Text = _objSaleHeaderPartyDetail.sale_item_date.ToShortDateString();
                lblBillPercentage2.Text = _objSaleHeaderPartyDetail.tough_billing_precentage.ToString();
                // lblDiscount.Text = _objSaleHeaderPartyDetail.tough_discount.ToString();
                lblDiscount2.Text = _objSaleHeaderPartyDetail.tough_discount_precentage.ToString();

                #endregion

            }

        }

        #endregion

        #region Get Challan Header Details
        /// <summary>
        /// This Method Is Use to Get Challan Header Details
        /// </summary>
        /// <param name="_saleHeader_id"></param>
        private void GetChallanHeaderDetails(string _saleHeader_id, string _challan_Id)
        {
            Int32 _SaleHeader_id = Convert.ToInt32(_saleHeader_id);
            Int32 _Challan_id = Convert.ToInt32(_challan_Id);
            _objChallanHeaderBL = new ChallanHeaderBL();

            _lstChallanHeader = _objChallanHeaderBL.GetAllChallanHeaderItems().Where(x => x.sale_header_id == _SaleHeader_id & x.challan_header_id == _Challan_id).ToList();

            //rptrPurchaseItems.DataSource = _lstSaleHeaderPartyDetail;
            //rptrPurchaseItems.DataBind();

            _objChallanHeader = _lstChallanHeader.Where(x => x.sale_header_id == _SaleHeader_id & x.challan_header_id == _Challan_id).FirstOrDefault();

            if (_objChallanHeader != null)
            {
                //lblClientname.Text = _objSaleHeaderPartyDetail.party_name;
                //lblClientAddress.Text = _objSaleHeaderPartyDetail.party_address + " , " + _objSaleHeaderPartyDetail.party_state;
                //lblPartyName.Text = _objSaleHeaderPartyDetail.party_name;
                //lblState.Text = _objSaleHeaderPartyDetail.party_state;
                //lblGSTNumber.Text = _objSaleHeaderPartyDetail.party_gst;
                //lblBillNumber.Text = _objSaleHeaderPartyDetail.order_number;
                //lblDate.Text = _objSaleHeaderPartyDetail.sale_item_date.ToShortDateString();
                //lblBillPercentage.Text = _objSaleHeaderPartyDetail.tough_billing_precentage.ToString();
                //lblDiscount.Text = _objSaleHeaderPartyDetail.tough_discount.ToString();

                //_totalCashAmount = Convert.ToDecimal(_objChallanHeader.total_amount_cash);
                //_totalBillAmount = Convert.ToDecimal(_objChallanHeader.total_amount_billed);
                //_totalGstAmount = Convert.ToDecimal(_objChallanHeader.gst_amount);
                _toughDiscountPercentage = Convert.ToDecimal(_objChallanHeader.tough_discount_precentage);
               // _totalItemQuantity = _objChallanHeader.total_items_after_challan;
                _toughBillPercentage = _objChallanHeader.tough_billing_precentage;
                _netBillingPercentage = _objChallanHeader.netrate_billing_precentage;

                lblVehicleNumber.Text = _objChallanHeader.vehicle_number;
                lblDriverName.Text = _objChallanHeader.driver_name;
                lblDeliveryBoy.Text = _objChallanHeader.delivery_boy;
                lblGstPercentage.Text = "18 %";


                #region  Second Table value

                //_totalCashAmount2 = Convert.ToDecimal(_objChallanHeader.total_amount_cash);
                //_totalBillAmount2 = Convert.ToDecimal(_objChallanHeader.total_amount_billed);
                //_totalGstAmount2 = Convert.ToDecimal(_objChallanHeader.gst_amount);
                _toughDiscountPercentage2 = Convert.ToDecimal(_objChallanHeader.tough_discount_precentage);
               // _totalItemQuantity2 = _objChallanHeader.total_items_after_challan;
                _toughBillPercentage2 = _objChallanHeader.tough_billing_precentage;
                _netBillingPercentage2 = _objChallanHeader.netrate_billing_precentage;

                lblVehicleNumber2.Text = _objChallanHeader.vehicle_number;
                lblDriverName2.Text = _objChallanHeader.driver_name;
                lblDeliveryBoy2.Text = _objChallanHeader.delivery_boy;
                lblGstPercentage2.Text = "28 %";

                #endregion



            }

        }

        #endregion

    }
}