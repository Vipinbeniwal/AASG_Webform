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
    public partial class view_purchase_order_bill : System.Web.UI.Page
    {
        #region Global Properties

        App.BusinessModel.PurchaseHeader _objPurchaseHeader = new App.BusinessModel.PurchaseHeader();
        App.Business.PurchaseHeaderBL _objPurchaseHeaderBL = null;
        List<App.BusinessModel.PurchaseHeader> _lstPurchaseHeader = new List<App.BusinessModel.PurchaseHeader>();

        App.BusinessModel.PurchaseItem _objPurchaseItem = new App.BusinessModel.PurchaseItem();
        App.Business.PurchaseItemBL _objPurchaseItemBL = null;
        List<App.BusinessModel.PurchaseItem> _lstPurchaseItem = new List<App.BusinessModel.PurchaseItem>();


        App.BusinessModel.SupplierMaster _objSupplierMaster = new App.BusinessModel.SupplierMaster();
        App.Business.SupplierMasterBL _objSupplierMasterBL = null;
        List<App.BusinessModel.SupplierMaster> _lstSupplierMaster = new List<App.BusinessModel.SupplierMaster>();

        App.BusinessModel.StockLedger _objStockLedger = new App.BusinessModel.StockLedger();
        App.Business.StockLedgerBL _objStockLedgerBL = null;
        List<App.BusinessModel.StockLedger> _lstStockLedger = new List<App.BusinessModel.StockLedger>();

        App.BusinessModel.vwPurchaseHeaderSupplierDetail _objvwPurchaseHeader = new App.BusinessModel.vwPurchaseHeaderSupplierDetail();
        List<App.BusinessModel.vwPurchaseHeaderSupplierDetail> _lstPurchaseHeaderSupplierDetail = new List<App.BusinessModel.vwPurchaseHeaderSupplierDetail>();


        string UserIp = string.Empty;
        string[] FileNameFile;
        int _sUbTotalIAmount , _mainTotalIAmount = 0;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                string _poNumber;
                if (RouteData.Values["id"] == null)
                {
                    // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "editorInit();", true);
                }
                else
                {

                    string purchase_header_id = RouteData.Values["id"].ToString();
                    _poNumber = App.Core.DataSecurity.Decryptdata(purchase_header_id);
                    hdfdPurchaseNumber.Value = _poNumber;
                    if (_poNumber == "" || _poNumber == null)
                    {
                        Response.Redirect("/home", false);
                    }
                    else
                    {
                        BindPurchaseItemrptr(_poNumber);
                        GetPurchaseOrderBillDetails(_poNumber);
                        BindTableFooterData();
                        GetInvoiceNumber();
                    }


                }
            }
        }


        #region Pageload method

        private void BindPurchaseItemrptr( string poNumber)
        {
            Int32 _pONumber = Convert.ToInt32(poNumber);
            _objPurchaseItemBL = new PurchaseItemBL();

            _lstPurchaseItem = _objPurchaseItemBL.GetPurchaseItemItemsByID(Convert.ToInt32(_pONumber)).ToList();

            rptrPurchaseItems.DataSource = _lstPurchaseItem;
            rptrPurchaseItems.DataBind();
            _objPurchaseItem = _lstPurchaseItem.Where(x => x.purchase_header_id == _pONumber).FirstOrDefault();

        }

        /// <summary>
        /// This Method is Used to get Invoice Number according to PO Number
        /// </summary>
        private void GetInvoiceNumber()
        {
            try
            {
                Int32 _pONumber = Convert.ToInt32(hdfdPurchaseNumber.Value);

                _objStockLedgerBL = new StockLedgerBL();

                _lstStockLedger = _objStockLedgerBL.GetAllStockLedgerItems().OrderByDescending(x => x.purchase_header_id).ToList();

                _objStockLedger = _lstStockLedger.Where(x => x.purchase_header_id == _pONumber).FirstOrDefault();

                if (_objStockLedger != null)
                {
                    lblInvoiceNumber.Text = _objStockLedger.purchase_invoice_number;
                    lblDate.Text = Convert.ToDateTime(_objStockLedger.created_on).ToShortDateString();
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

        /// <summary>
        /// This Method is Used to Get Supplier or Party  Details ( Like Address, GST Number etc)
        /// </summary>
        /// <param name="poNumber"> This is Used for Purchased_header_id</param>
        private void GetPurchaseOrderBillDetails(string poNumber)
        {
            try
            {
                Int32 pONumber = Convert.ToInt32(poNumber);
                _objPurchaseHeaderBL = new PurchaseHeaderBL();

                _lstPurchaseHeaderSupplierDetail = _objPurchaseHeaderBL.GetAllPurchaseHeaderWithSupplierItems().OrderByDescending(x => x.purchase_header_id).ToList();

                _objvwPurchaseHeader = _lstPurchaseHeaderSupplierDetail.Where(x => x.purchase_header_id == pONumber).FirstOrDefault();


                if (_objvwPurchaseHeader !=null)
                {
                    if (_objvwPurchaseHeader.purchase_header_id > 0)
                    {
                        lblPartyName.Text = _objvwPurchaseHeader.supplier_name;
                        lblPartyAddress.Text = _objvwPurchaseHeader.supplier_address;
                        lblPartyCity.Text = _objvwPurchaseHeader.supplier_city;
                        lblPartyEmailId.Text = _objvwPurchaseHeader.supplier_email;
                        lblPartyPhoneNumber.Text = _objvwPurchaseHeader.supplier_phoneno;
                        lblPartyGst.Text = _objvwPurchaseHeader.supplier_gst;
                        lblPartyState.Text = _objvwPurchaseHeader.supplier_state + " , " + _objvwPurchaseHeader.supplier_pincode;

                    }
                    else
                    {

                    }

                }
                else
                {
                   
                }
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }

            
        }


        /// <summary>
        /// This Method Is Used to Bind Table Footer Data
        /// </summary>
        private void BindTableFooterData()
        {
            Control FooterTemplate = rptrPurchaseItems.Controls[rptrPurchaseItems.Controls.Count - 1].Controls[0];
            Label lblsubTotal = FooterTemplate.FindControl("lblsubTotal") as Label;
            Label lblmainTotal = FooterTemplate.FindControl("lblmainTotal") as Label;

            lblsubTotal.Text = _sUbTotalIAmount.ToString();
            lblmainTotal.Text = _mainTotalIAmount.ToString();
            lblGrandTotal.Text = _mainTotalIAmount.ToString();
        }

        #endregion

        protected void rptrPurchaseItems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

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
                    Label lblitemgst = (Label)e.Item.FindControl("lblitemgst");
                    Label lblItemTotalAmount = (Label)e.Item.FindControl("lblItemTotalAmount");
                   

                    int _itemAmount = Convert.ToInt32(lblItemQuantity.Text) * Convert.ToInt32(lblItemPrice.Text);
                    if (lblitemgst.Text == "")
                    {
                        lblitemgst.Text = "18";
                    }
                    lblItemAmount.Text = _itemAmount.ToString();
                    int _ItemAmountafterAddGst = Convert.ToInt32(lblItemAmount.Text) * Convert.ToInt32(lblitemgst.Text)/100;

                    lblitemgst.Text = lblitemgst.Text + "%";


                    int _Total = Convert.ToInt32(lblItemAmount.Text) + Convert.ToInt32(_ItemAmountafterAddGst);
                    lblItemTotalAmount.Text = _Total.ToString();

                     _sUbTotalIAmount = _sUbTotalIAmount + Convert.ToInt32(lblItemAmount.Text);
                   
                    _mainTotalIAmount = _mainTotalIAmount + Convert.ToInt32(lblItemTotalAmount.Text);
                   


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