using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using App.Core;
using App.Business;
using App.BusinessModel;

namespace AASGWeb.Modules.GRN
{
    public partial class add_grn : System.Web.UI.Page
    {
        #region Global Properties

        PurchaseHeader _objPurchaseHeader = new PurchaseHeader();
        PurchaseHeaderBL _objPurchaseHeaderBL = null;
        List<PurchaseHeader> _lstPurchaseHeader = new List<PurchaseHeader>();

        PurchaseItem _objPurchaseItem = new PurchaseItem();
        PurchaseItemBL _objPurchaseItemBL = null;
        List<PurchaseItem> _lstPurchaseItem = new List<PurchaseItem>();

        vwPurchaseHeaderSupplierDetail _objvwPurchaseHeader = new vwPurchaseHeaderSupplierDetail();
        List<vwPurchaseHeaderSupplierDetail> _lstPurchaseHeaderSupplierDetail = new List<vwPurchaseHeaderSupplierDetail>();


        StockLedger _objStockLedger = new StockLedger();
        StockLedgerBL _objStockLedgerBL = null;
        List<StockLedger> _lstStockLedger = new List<StockLedger>();

        DataTable _datatable = new DataTable();
        string UserIp = string.Empty;
       
        int _totalItemActual,_TotalItems, _totalItemRecieved;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
           // Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {


                
            }
        }

        #region Pageload method

      
        #region Get Purchase Order Items List
        /// <summary>
        /// This Method is Used to Get Purchase Order Items List
        /// </summary>
        private void bindPurchaseOrderRepeater( string _poNumber)
        {
            int _pOnumber = Convert.ToInt32(_poNumber);
            _objPurchaseItemBL = new PurchaseItemBL();

            _lstPurchaseItem = _objPurchaseItemBL.GetAllPurchaseItemItems().Where(x => x.purchase_header_id == _pOnumber).ToList();
            rptrPurchaseOrderItemsList.DataSource = _lstPurchaseItem;
            rptrPurchaseOrderItemsList.DataBind();

            divSupplierDetail_first.Visible = true;
            divSupplierDetail_second.Visible = true;
            divPurchaseItemList.Visible = true;
            divActionButtons.Visible = true;

            Control FooterTemplate = rptrPurchaseOrderItemsList.Controls[rptrPurchaseOrderItemsList.Controls.Count - 1].Controls[0];
            Label lblTotalItemQuantity = FooterTemplate.FindControl("lblTotalItemQuantity") as Label;
            Label lblTotalActualQuantity = FooterTemplate.FindControl("lblTotalActualQuantity") as Label;

            lblTotalItemQuantity.Text = _TotalItems.ToString();
            lblTotalActualQuantity.Text = _totalItemActual.ToString();
        }
        #endregion

        #endregion

        #region
        #region Get Purchase Details From Purchase Form TextFields
        /// <summary>
        /// This Method is Used to Get Purchase Header Details From General Form TextFields to Purchase Header Object
        /// </summary>
        /// <returns></returns>
        private PurchaseHeader GetStockLedgerDetailsObject()
        {
            try
            {
                _objStockLedgerBL = new StockLedgerBL();

                _objStockLedger.guid = Guid.NewGuid();
                _objStockLedger.purchase_header_id = Convert.ToInt32(txtPoNumber.Text);
                _objStockLedger.purchase_invoice_number = txtInvoiceNumber.Text;
                
                if (ViewState["Row"] != null)
                {
                    _datatable = (DataTable)ViewState["Row"];
                    if (_datatable.Rows.Count > 0)
                    {
                        int _stockLedgerItemSaveCount = 0;

                        for (int i = 0; i < _datatable.Rows.Count; i++)
                        {
                            _objStockLedger.item_master_id = Convert.ToInt32(_datatable.Rows[i]["item_master_id"].ToString());
                            _objStockLedger.purchase_item_name = _datatable.Rows[i]["purchase_item_name"].ToString();
                            _objStockLedger.purchase_item_quantity = Convert.ToInt32(_datatable.Rows[i]["purchase_item_quantity"].ToString());
                            _objStockLedger.purchase_item_received_quantity = Convert.ToInt32(_datatable.Rows[i]["purchase_item_received_quantity"].ToString());
                            _objStockLedger.purchase_item_remarks = _datatable.Rows[i]["purchase_item_remarks"].ToString();
                            _objStockLedger = _objStockLedgerBL.CreateStockLedger(_objStockLedger);
                            _stockLedgerItemSaveCount = _stockLedgerItemSaveCount + 1;
                        }

                        if (_stockLedgerItemSaveCount > 0)
                        {
                            txtPoNumber.Text = string.Empty;
                            ClearGrnForm();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccess();", true);
                        }
                        else
                        {

                        }
                    }
                }
                else
                {

                }
               


                //Convert.ToDateTime(_objStaffMaster.staff_joinning_date).ToString("MM/dd/yyyy");


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objPurchaseHeader;
        }

        #endregion

        #endregion


        protected void rptrPurchaseOrderItemsList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string commandname = e.CommandName;
            string id = e.CommandArgument.ToString();
            hdfditemId.Value = id;

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

                        // string url = "view-purchase-bill/" + App.Core.DataSecurity.Encryptdata(id).ToString();
                        //string url = "view-purchase-order-bill";

                        //Response.Redirect(url, false);
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

        protected void rptrPurchaseOrderItemsList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Label lblActualQuantity = (Label)e.Item.FindControl("lblActualQuantity");
                    Label lblItemQuantity = (Label)e.Item.FindControl("lblItemQuantity");
                    


                    int _itemQuantity = Convert.ToInt32(lblItemQuantity.Text);
                    _TotalItems = _TotalItems + _itemQuantity;
                    int _itemActualQuantity = Convert.ToInt32(lblActualQuantity.Text);
                    _totalItemActual = _totalItemActual + _itemActualQuantity;
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "notification('Something went wrong','danger');", true);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                GetRepeaterItemValues();
                _objStockLedgerBL = new StockLedgerBL();
                GetStockLedgerDetailsObject();

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
        }


        #region

        /// <summary>
        /// This Method is Used To get Repeater All Rows ( All fields Value)
        /// </summary>
        public void GetRepeaterItemValues()
        {
            _datatable.Columns.Add("item_master_id", typeof(int));
            _datatable.Columns.Add("purchase_item_name", typeof(string));
            _datatable.Columns.Add("purchase_item_quantity", typeof(int));
            _datatable.Columns.Add("purchase_item_received_quantity", typeof(int));
            _datatable.Columns.Add("purchase_item_remarks", typeof(string));
            ViewState["Row"] = _datatable;
            foreach (RepeaterItem item in rptrPurchaseOrderItemsList.Items)
            {

                Label lblitemid = (Label)item.FindControl("lblitemid");
                Label lblItemName = (Label)item.FindControl("lblItemName");
                Label lblItemQuantity = (Label)item.FindControl("lblItemQuantity");
                TextBox txtReceivedQuantity = (TextBox)item.FindControl("txtReceivedQuantity");
                TextBox txtremarks = (TextBox)item.FindControl("txtremarks");

                _datatable = (DataTable)ViewState["Row"];
                if (_datatable.Rows.Count > 0)
                {

                    DataRow _dataRowItemsList = _datatable.NewRow();
                    _dataRowItemsList["item_master_id"] = lblitemid.Text;
                    _dataRowItemsList["purchase_item_name"] = lblItemName.Text;
                    _dataRowItemsList["purchase_item_quantity"] = lblItemQuantity.Text;
                    _dataRowItemsList["purchase_item_received_quantity"] = txtReceivedQuantity.Text;
                    _dataRowItemsList["purchase_item_remarks"] = txtremarks.Text;
                    _datatable.Rows.Add(_dataRowItemsList);
                    ViewState["Row"] = _datatable;



                }
                else
                {
                    DataRow _dataRowItemsList = _datatable.NewRow();
                    _dataRowItemsList["item_master_id"] = lblitemid.Text;
                    _dataRowItemsList["purchase_item_name"] = lblItemName.Text;
                    _dataRowItemsList["purchase_item_quantity"] = lblItemQuantity.Text;
                    _dataRowItemsList["purchase_item_received_quantity"] = txtReceivedQuantity.Text;
                    _dataRowItemsList["purchase_item_remarks"] = txtremarks.Text;
                    _datatable.Rows.Add(_dataRowItemsList);
                    ViewState["Row"] = _datatable;
                }
                

            }


        }

        #endregion

        #region Clear Form Method
        /// <summary>
        /// This Method is Used to Clear General Form Fields
        /// </summary>
        private void ClearGrnForm()
        {
             txtSupplierName.Text = txtMobile.Text = txtSupplierAddress.Text = txtEmail.Text = txtGst.Text = txtInvoiceNumber.Text = string.Empty;

            rptrPurchaseOrderItemsList.DataSource = null;
            rptrPurchaseOrderItemsList.DataBind();

            divSupplierDetail_first.Visible = false;
            divSupplierDetail_second.Visible = false;
            divPurchaseItemList.Visible = false;
            divActionButtons.Visible = false;
        }
        #endregion

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            ClearGrnForm();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtPoNumber.Text !=null && txtPoNumber.Text !="")
                {
                    _objPurchaseHeaderBL = new PurchaseHeaderBL();
                    _lstPurchaseHeaderSupplierDetail = _objPurchaseHeaderBL.GetAllPurchaseHeaderWithSupplierItems().OrderByDescending(x => x.purchase_header_id).ToList();

                    _objvwPurchaseHeader = _lstPurchaseHeaderSupplierDetail.Where(x => x.purchase_header_id == Convert.ToInt32(txtPoNumber.Text)).FirstOrDefault();


                    if (_objvwPurchaseHeader != null)
                    {
                        if (_objvwPurchaseHeader.purchase_header_id > 0)
                        {
                            txtSupplierName.Text = _objvwPurchaseHeader.supplier_name;
                            txtMobile.Text = _objvwPurchaseHeader.supplier_phoneno;
                            txtSupplierAddress.Text = _objvwPurchaseHeader.supplier_address;
                            txtEmail.Text = _objvwPurchaseHeader.supplier_email;
                            txtGst.Text = _objvwPurchaseHeader.supplier_gst;

                            bindPurchaseOrderRepeater(_objvwPurchaseHeader.purchase_header_id.ToString());

                        }
                        else
                        {
                            ClearGrnForm();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showNoRecordFound();", true);
                           

                        }

                       
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showNoRecordFound();", true);

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showErrorFillValue();", true);
                }
               
              


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
        }
    }
}