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


namespace AASGWeb.Modules.GRN
{
    public partial class view_stock_ledger_order_details : System.Web.UI.Page
    {
        #region Global Properties

        StockLedger _objStockLedger = new StockLedger();
        StockLedgerBL _objStockLedgerBL = null;
        List<StockLedger> _lstStockLedger = new List<StockLedger>();



        string UserIp = string.Empty;
        string[] FileNameFile;
        int _TotalItems, _totalItemRecieved;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
           // Page.MaintainScrollPositionOnPostBack = true;
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
                        BindStockLedgerrptr(_poNumber);
                        Control FooterTemplate = rptrStockLedgerOrderDetails.Controls[rptrStockLedgerOrderDetails.Controls.Count - 1].Controls[0];
                        Label lblTotalItemQuantity = FooterTemplate.FindControl("lblTotalItemQuantity") as Label;
                        Label lblTotalRecieveQuantity = FooterTemplate.FindControl("lblTotalRecieveQuantity") as Label;

                        lblTotalItemQuantity.Text = _TotalItems.ToString();
                        lblTotalRecieveQuantity.Text = _totalItemRecieved.ToString();

                    }


                }
            }
        }
        #region Pageload method

        private void BindStockLedgerrptr(string poNumber)
        {
            Int32 _pONumber = Convert.ToInt32(poNumber);
            _objStockLedgerBL = new StockLedgerBL();

            //_lstStockLedger = _objStockLedgerBL.GetAllStockLedgerItems().OrderByDescending(x => x.purchase_header_id == _pONumber).ToList(); ;

            _lstStockLedger = _objStockLedgerBL.GetAllStockLedgerItems().Where(x => x.purchase_header_id == _pONumber).ToList(); 

            rptrStockLedgerOrderDetails.DataSource = _lstStockLedger;
            rptrStockLedgerOrderDetails.DataBind();
          

        }

        private void GetInvoiceNumber()
        {
            Int32 _pONumber = Convert.ToInt32(hdfdPurchaseNumber.Value);

            _objStockLedger = _lstStockLedger.Where(x => x.purchase_header_id == _pONumber).FirstOrDefault();
        }
        #endregion


        protected void rptrStockLedgerOrderDetails_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void rptrStockLedgerOrderDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    Label lblItemName = (Label)e.Item.FindControl("lblItemName");
                    Label lblItemQuantity = (Label)e.Item.FindControl("lblItemQuantity");
                    Label lblreceivedItem = (Label)e.Item.FindControl("lblreceivedItem");
                    

                    int _itemAmount = Convert.ToInt32(lblItemQuantity.Text);
                    _TotalItems = _TotalItems + _itemAmount;
                    int _itemReceiveAmount = Convert.ToInt32(lblreceivedItem.Text);
                    _totalItemRecieved = _totalItemRecieved + _itemReceiveAmount;

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