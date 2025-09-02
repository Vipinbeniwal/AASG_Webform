using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Text;
using System.Dynamic;
using System.IO;
using System.Net;
using App.Core;
using App.Business;
using App.BusinessModel;

namespace AASGWeb.Modules.Billing
{
    public partial class add_sale_order : System.Web.UI.Page
    {
        #region Global Properties
        ActivityLog _objActivityLog = new ActivityLog();
        ActivityLogBL _objActivityLogBL = null;
        List<ActivityLog> _lstActivityLog = new List<ActivityLog>();

        SaleHeader _objSaleHeader = new SaleHeader();
        SaleHeaderBL _objSaleHeaderBL = null;
        List<SaleHeader> _lstSaleHeader = new List<SaleHeader>();

        SaleItem _objSaleItem = new SaleItem();
        SaleItemBL _objSaleItemBL = null;
        List<SaleItem> _lstSaleItem = new List<SaleItem>();
        
        Sale _objSale = new Sale();

        DropdownMaster _objDropdownMaster = new DropdownMaster();
        DropdownMasterBL _objDropdownMasterBL = null;
        List<DropdownMaster> _lstDropdownMaster = new List<DropdownMaster>();

        ItemMaster _objItemMaster = new ItemMaster();
        ItemMasterBL _objItemMasterBL = null;
        List<ItemMaster> _lstItemMaster = new List<ItemMaster>();


        PartyMaster _objPartyMaster = new PartyMaster();
        PartyMasterBL _objPartyMasterBL = null;
        List<PartyMaster> _lstPartyMaster = new List<PartyMaster>();

        List<vwItemListWithModelAndGlassColor> _lstvwItemListWithModelAndGlassColor = new List<vwItemListWithModelAndGlassColor>();
        List<vwSaleHeaderPartyDetail> _lstSaleHeaderPartyDetail = new List<vwSaleHeaderPartyDetail>();
        vwSaleHeaderPartyDetail _objvwSaleHeader = new vwSaleHeaderPartyDetail();

        string UserIp = string.Empty;
        public static int _totalItemCount ,_netRate ,_billAmount,_totalCash , _lblToughDiscountAmount = 0;
        public static Decimal _totalAmount , _totalItemWeight,_itemWiseGstAmountAfterCalculate = 0;
        public static Boolean _isDeletePermission = true;
        public static Decimal _SaleRptrTotalItemAmountBeforeGST, _SaleRptrTotalAmountAfterGST, _SaleRptrBillAmountBeforeGST, _SaleRptrBillAmountAfterGST, _SaleRptrTotalGSTAmount, _SaleRptrTotalCashAmount, _SaleRptrTotalItemWeight, _SaleRptrNetRate, _SaleRptrNormalItemAmount, _SaleRptrNetRateBillPercentage, _SaleRptrNetRateBillPercentageAmount = 0;
        public static int _SaleRptrTotalItemQuantity, _SaleRptrTotalActualItemQuantity = 0;
        DataTable _dataTableItemsList = new DataTable();
        public static string _orderStatus, _orderNumber;
        public static DateTime _orderCreatedOn;
        public Boolean _bindSaleItemStatus = false;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                BindItemTypeList();
                BindPartyList();
                _totalItemCount = 0;
                _totalItemWeight = 0;
                ResetTextField();

                string _saleHederId;
                if (RouteData.Values["id"] == null)
                {
                    // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "editorInit();", true);
                }
                else
                {

                    string sale_header_id = RouteData.Values["id"].ToString();
                    
                    _saleHederId = App.Core.DataSecurity.Decryptdata(sale_header_id);
                   
                    HdnfSaleHeaderId.Value = _saleHederId;
                    if (_saleHederId == "" || _saleHederId == null)
                    {
                        Response.Redirect("/home", false);
                    }
                    else
                    {
                        GetSaleOrderPartyDetails(HdnfSaleHeaderId.Value.ToString());
                        if (_bindSaleItemStatus == true)
                        {
                            PopulateDataSaleItems(HdnfSaleHeaderId.Value.ToString());
                            btnSubmitOrder.Visible = false;
                            btnUpdateOrder.Visible = true;
                        }
                        else
                        {
                            rptrItems.DataSource = null;
                            rptrItems.DataBind();
                            rptrItems.Visible = false;

                            btnSubmitOrder.Visible = true;
                            btnUpdateOrder.Visible = false;
                        }
                    }


                }

            }

        }


        #region Create Item Table at Run Time
        /// <summary>
        /// This Method is Used to Create Item Table at Run Time
        /// </summary>
        public void createtable()
        {
            _dataTableItemsList.Columns.Add("sale_item_type_id", typeof(int));
            _dataTableItemsList.Columns.Add("sale_item_type_title", typeof(string));
            _dataTableItemsList.Columns.Add("item_master_id", typeof(int));
            _dataTableItemsList.Columns.Add("sale_item_name", typeof(string));
            _dataTableItemsList.Columns.Add("sale_item_quantity", typeof(string));
            _dataTableItemsList.Columns.Add("sale_item_net_price", typeof(int));
            _dataTableItemsList.Columns.Add("sale_item_price", typeof(int));
            _dataTableItemsList.Columns.Add("sale_item_price_2", typeof(int));
            _dataTableItemsList.Columns.Add("sale_item_weight", typeof(Decimal));

            _dataTableItemsList.Columns.Add("item_gst_percentage", typeof(int));
            _dataTableItemsList.Columns.Add("item_discount_percentage", typeof(Decimal));
            _dataTableItemsList.Columns.Add("item_bill_percentage", typeof(Decimal));
            _dataTableItemsList.Columns.Add("item_discount_amount", typeof(Decimal));
            _dataTableItemsList.Columns.Add("item_amount", typeof(Decimal));
            _dataTableItemsList.Columns.Add("item_final_amount", typeof(Decimal));
            _dataTableItemsList.Columns.Add("item_bill_rate", typeof(Decimal));
            _dataTableItemsList.Columns.Add("item_bill_amount", typeof(Decimal));
            _dataTableItemsList.Columns.Add("item_gst_amount", typeof(Decimal));

            rptrItems.DataSource = _dataTableItemsList;
            rptrItems.DataBind();
            if (ViewState["Row"] != null)
            {
                int _alreadyCount = 0;
                _dataTableItemsList = (DataTable)ViewState["Row"];

                for (int _datatableRowIndexPostion = 0; _datatableRowIndexPostion < _dataTableItemsList.Rows.Count; _datatableRowIndexPostion++)
                {
                    if (_dataTableItemsList.Rows[_datatableRowIndexPostion]["item_master_id"].ToString() == Convert.ToInt32(ddlItemList.SelectedValue).ToString())
                    {
                        _alreadyCount = _alreadyCount + 1;
                    }
                }

                if (_alreadyCount == 0)
                {
                   // _objItemMaster = GetSelectedItemDetailsById(Convert.ToInt32(ddlItemList.SelectedValue));

                    DataRow _dataRowItemsList = _dataTableItemsList.NewRow();
                    _dataRowItemsList["sale_item_type_id"] = Convert.ToInt32(ddlItemTypeList.SelectedValue);
                    _dataRowItemsList["sale_item_type_title"] = ddlItemTypeList.SelectedItem.Text;
                    _dataRowItemsList["item_master_id"] = Convert.ToInt32(ddlItemList.SelectedValue);
                    _dataRowItemsList["sale_item_name"] = ddlItemList.SelectedItem.Text;
                    _dataRowItemsList["sale_item_quantity"] = txtItemQuantity.Text;
                    _dataRowItemsList["sale_item_net_price"] = txtNetRate.Text == "" ? 0 : Convert.ToInt32(txtNetRate.Text);
                    _dataRowItemsList["sale_item_price"] = Convert.ToDecimal( txtItemWisePrice.Text);
                    _dataRowItemsList["sale_item_price_2"] = Convert.ToDecimal(lblItemWisePrice2.Text);
                    _dataRowItemsList["sale_item_weight"] = Convert.ToDecimal(lblItemWiseWeight.Text);

                    Decimal _Item_price_after_Check_NetRate_or_Price = 0;
                    Decimal _itemDiscountAmount = 0;
                    if (txtNetRate.Text == "" || txtNetRate.Text == "0" || txtNetRate.Text == "0.0" || txtNetRate.Text == "0.00")
                    {
                        _Item_price_after_Check_NetRate_or_Price = Convert.ToDecimal(txtItemWisePrice.Text);

                         _itemDiscountAmount = Math.Round(Convert.ToDecimal(_Item_price_after_Check_NetRate_or_Price) - (Convert.ToDecimal(_Item_price_after_Check_NetRate_or_Price) * Convert.ToDecimal(txtItemWiseDiscountInPercentage.Text == "" ? 0 : Convert.ToDecimal(txtItemWiseDiscountInPercentage.Text)) / 100), 2);
                         _dataRowItemsList["item_discount_amount"] = _itemDiscountAmount;

                    }
                    else
                    {
                        _Item_price_after_Check_NetRate_or_Price = Convert.ToDecimal(txtNetRate.Text);
                        _itemDiscountAmount = Convert.ToDecimal(txtNetRate.Text);
                        _dataRowItemsList["item_discount_amount"] = _itemDiscountAmount;
                    }


                    _dataRowItemsList["item_gst_percentage"] = Convert.ToInt32(lblItemWiseGstinPercentage.Text == "" ? 0 : Convert.ToInt32(lblItemWiseGstinPercentage.Text));
                    _dataRowItemsList["item_discount_percentage"] = Convert.ToDecimal(txtItemWiseDiscountInPercentage.Text == "" ? 0 : Convert.ToDecimal(txtItemWiseDiscountInPercentage.Text));
                    _dataRowItemsList["item_bill_percentage"] = Convert.ToDecimal(txtItemWiseBillingInPercentage.Text == "" ? 0 : Convert.ToDecimal(txtItemWiseBillingInPercentage.Text));

                   //Decimal _itemDiscountAmount = Math.Round(Convert.ToDecimal(_Item_price_after_Check_NetRate_or_Price) - (Convert.ToDecimal(_Item_price_after_Check_NetRate_or_Price) * Convert.ToDecimal(txtItemWiseDiscountInPercentage.Text == "" ? 0 : Convert.ToDecimal(txtItemWiseDiscountInPercentage.Text)) / 100), 2);
                   // //_dataRowItemsList["item_discount_amount"] = Math.Round(Convert.ToDecimal(_Item_price_after_Check_NetRate_or_Price) - (Convert.ToDecimal(_Item_price_after_Check_NetRate_or_Price) * Convert.ToDecimal(txtItemWiseDiscountInPercentage.Text == "" ? 0 : Convert.ToDecimal(txtItemWiseDiscountInPercentage.Text)) / 100), 2).ToString();
                   // _dataRowItemsList["item_discount_amount"] = _itemDiscountAmount;


                    _dataRowItemsList["item_amount"] = Math.Round(Convert.ToDecimal(txtItemQuantity.Text == "" ? "0": txtItemQuantity.Text) * Convert.ToDecimal(_itemDiscountAmount), 2).ToString();
                   
                    Decimal _itemBillRate = Math.Round(Convert.ToDecimal(txtItemWiseBillingInPercentage.Text) * Convert.ToDecimal(_itemDiscountAmount) / 100, 2);

                    //_dataRowItemsList["item_bill_rate"] = Math.Round(Convert.ToDecimal(txtItemWiseBillingInPercentage.Text) * Convert.ToDecimal(_itemDiscountAmount) / 100, 2).ToString();
                    _dataRowItemsList["item_bill_rate"] = _itemBillRate;
                    Decimal _billedAmountItemWise = Math.Round(Convert.ToDecimal(txtItemQuantity.Text) * Convert.ToDecimal(_itemBillRate), 2);
                    _dataRowItemsList["item_bill_amount"] = _billedAmountItemWise;

                    Decimal _gstAmountItemWise = Math.Round(Convert.ToDecimal(_billedAmountItemWise)/100 * Convert.ToDecimal(lblItemWiseGstinPercentage.Text));

                    _itemWiseGstAmountAfterCalculate = _itemWiseGstAmountAfterCalculate +_gstAmountItemWise;
                    _dataRowItemsList["item_gst_amount"] = _gstAmountItemWise;
                    _dataRowItemsList["item_final_amount"] = Convert.ToDecimal(txtFinalItemAmount.Text);

                    _totalItemCount = _totalItemCount + Convert.ToInt32(txtItemQuantity.Text);
                    _totalItemWeight = _totalItemWeight + (Convert.ToDecimal(lblItemWiseWeight.Text) * Convert.ToDecimal(txtItemQuantity.Text));
                    _dataTableItemsList.Rows.Add(_dataRowItemsList);

                    ViewState["Row"] = _dataTableItemsList;
                    if (_dataTableItemsList.Rows.Count > 0)
                    {
                        int _totalPiad = 0;
                        for (int i = 0; i < _dataTableItemsList.Rows.Count; i++)
                        {
                            _totalPiad += Convert.ToInt32(_dataTableItemsList.Rows[i]["sale_item_net_price"].ToString());
                        }

                    }
                    txtItemQuantity.Text = txtNetRate.Text = txtFinalItemAmount.Text = "0";

                    _SaleRptrBillAmountBeforeGST =  _SaleRptrTotalItemAmountBeforeGST = 0;
                    _SaleRptrTotalItemQuantity = 0;
                    _SaleRptrTotalItemWeight = 0;
                    _SaleRptrTotalGSTAmount = 0;

                    _SaleRptrNetRate =  _SaleRptrNetRateBillPercentageAmount = _SaleRptrNormalItemAmount = 0;

                   
                    rptrItems.DataSource = ViewState["Row"];
                    rptrItems.DataBind();
                    rptrItems.Visible = true;
                    txtItemWisePrice.Text = txtItemWiseDiscountInPercentage.Text = txtItemWiseBillingInPercentage.Text = txtDiscountedValue.Text = "0";

                    BindTableFooterChallanItemData();

                    btnConfirmAndSubmit.Visible = false;
                    btnResetConfirm.Visible = false;
                    _isDeletePermission = true;
                    ddlPartyName.Enabled = false;


                    //if (_objItemMaster != null)
                    //{
                        
                    //}
                    //else
                    //{
                    //    rptrItems.DataSource = ViewState["Row"];
                    //    rptrItems.DataBind();
                    //    rptrItems.Visible = true;
                    //    btnConfirmAndSubmit.Visible = false;
                    //    btnResetConfirm.Visible = false;
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    //}
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlreadyPurchaseItemMaster();", true);
                    ViewState["Row"] = _dataTableItemsList;
                    rptrItems.DataSource = ViewState["Row"];
                    rptrItems.DataBind();
                    rptrItems.Visible = true;
                    BindTableFooterChallanItemData();



                }

            }
            else
            { // Add  Get Item Detail Method Here

              //  _objItemMaster = GetSelectedItemDetailsById(Convert.ToInt32(ddlItemList.SelectedValue));

                DataRow _dataRowItemsList = _dataTableItemsList.NewRow();
                _dataRowItemsList["sale_item_type_id"] = Convert.ToInt32(ddlItemTypeList.SelectedValue);
                _dataRowItemsList["sale_item_type_title"] = ddlItemTypeList.SelectedItem.Text;
                _dataRowItemsList["item_master_id"] = Convert.ToInt32(ddlItemList.SelectedValue);
                _dataRowItemsList["sale_item_name"] = ddlItemList.SelectedItem.Text;
                _dataRowItemsList["sale_item_quantity"] = txtItemQuantity.Text;
                _dataRowItemsList["sale_item_net_price"] = txtNetRate.Text == "" ? 0 : Convert.ToInt32(txtNetRate.Text);
                _dataRowItemsList["sale_item_price"] = Convert.ToDecimal(txtItemWisePrice.Text);
                _dataRowItemsList["sale_item_price_2"] = Convert.ToDecimal(lblItemWisePrice2.Text);
                _dataRowItemsList["sale_item_weight"] = Convert.ToDecimal(lblItemWiseWeight.Text);

                Decimal _Item_price_after_Check_NetRate_or_Price = 0;
                Decimal _itemDiscountAmount = 0;
                if (txtNetRate.Text == "" || txtNetRate.Text == "0" || txtNetRate.Text == "0.0" || txtNetRate.Text == "0.00")
                {
                    _Item_price_after_Check_NetRate_or_Price = Convert.ToDecimal(txtItemWisePrice.Text);

                    _itemDiscountAmount = Math.Round(Convert.ToDecimal(_Item_price_after_Check_NetRate_or_Price) - (Convert.ToDecimal(_Item_price_after_Check_NetRate_or_Price) * Convert.ToDecimal(txtItemWiseDiscountInPercentage.Text == "" ? 0 : Convert.ToDecimal(txtItemWiseDiscountInPercentage.Text)) / 100), 2);
                    _dataRowItemsList["item_discount_amount"] = _itemDiscountAmount;

                }
                else
                {
                    _Item_price_after_Check_NetRate_or_Price = Convert.ToDecimal(txtNetRate.Text);
                    _itemDiscountAmount = Convert.ToDecimal(txtNetRate.Text);
                    _dataRowItemsList["item_discount_amount"] = _itemDiscountAmount;
                }


                _dataRowItemsList["item_gst_percentage"] = Convert.ToInt32(lblItemWiseGstinPercentage.Text == "" ? 0 : Convert.ToInt32(lblItemWiseGstinPercentage.Text));
                _dataRowItemsList["item_discount_percentage"] = Convert.ToDecimal(txtItemWiseDiscountInPercentage.Text == "" ? 0 : Convert.ToDecimal(txtItemWiseDiscountInPercentage.Text));
                _dataRowItemsList["item_bill_percentage"] = Convert.ToDecimal(txtItemWiseBillingInPercentage.Text == "" ? 0 : Convert.ToDecimal(txtItemWiseBillingInPercentage.Text));

                //Decimal _itemDiscountAmount = Math.Round(Convert.ToDecimal(_Item_price_after_Check_NetRate_or_Price) - (Convert.ToDecimal(_Item_price_after_Check_NetRate_or_Price) * Convert.ToDecimal(txtItemWiseDiscountInPercentage.Text == "" ? 0 : Convert.ToDecimal(txtItemWiseDiscountInPercentage.Text)) / 100), 2);
                ////_dataRowItemsList["item_discount_amount"] = Math.Round(Convert.ToDecimal(_Item_price_after_Check_NetRate_or_Price) - (Convert.ToDecimal(_Item_price_after_Check_NetRate_or_Price) * Convert.ToDecimal(txtItemWiseDiscountInPercentage.Text == "" ? 0 : Convert.ToDecimal(txtItemWiseDiscountInPercentage.Text)) / 100), 2).ToString();
                //_dataRowItemsList["item_discount_amount"] = _itemDiscountAmount;


                _dataRowItemsList["item_amount"] = Math.Round(Convert.ToDecimal(txtItemQuantity.Text == "" ? "0" : txtItemQuantity.Text) * Convert.ToDecimal(_itemDiscountAmount), 2).ToString();

                Decimal _itemBillRate = Math.Round(Convert.ToDecimal(txtItemWiseBillingInPercentage.Text) * Convert.ToDecimal(_itemDiscountAmount) / 100, 2);

                //_dataRowItemsList["item_bill_rate"] = Math.Round(Convert.ToDecimal(txtItemWiseBillingInPercentage.Text) * Convert.ToDecimal(_itemDiscountAmount) / 100, 2).ToString();
                _dataRowItemsList["item_bill_rate"] = _itemBillRate;
                Decimal _billedAmountItemWise = Math.Round(Convert.ToDecimal(txtItemQuantity.Text) * Convert.ToDecimal(_itemBillRate), 2);
                _dataRowItemsList["item_bill_amount"] = _billedAmountItemWise;

                Decimal _gstAmountItemWise = Math.Round(Convert.ToDecimal(_billedAmountItemWise) / 100 * Convert.ToDecimal(lblItemWiseGstinPercentage.Text));

                _itemWiseGstAmountAfterCalculate = _itemWiseGstAmountAfterCalculate + _gstAmountItemWise;
                _dataRowItemsList["item_gst_amount"] = _gstAmountItemWise;
                _dataRowItemsList["item_final_amount"] = Convert.ToDecimal(txtFinalItemAmount.Text);

                _totalItemCount = _totalItemCount + Convert.ToInt32(txtItemQuantity.Text);
                _totalItemWeight = _totalItemWeight + (Convert.ToDecimal(lblItemWiseWeight.Text) * Convert.ToDecimal(txtItemQuantity.Text));
                _dataTableItemsList.Rows.Add(_dataRowItemsList);

                ViewState["Row"] = _dataTableItemsList;
                if (_dataTableItemsList.Rows.Count > 0)
                {
                    int _totalPiad = 0;
                    for (int i = 0; i < _dataTableItemsList.Rows.Count; i++)
                    {
                        _totalPiad += Convert.ToInt32(_dataTableItemsList.Rows[i]["sale_item_net_price"].ToString());
                    }

                }
                txtItemQuantity.Text = txtNetRate.Text = txtFinalItemAmount.Text = "0";

                _SaleRptrBillAmountBeforeGST = _SaleRptrTotalItemAmountBeforeGST = 0;
                _SaleRptrTotalItemQuantity = 0;
                _SaleRptrTotalItemWeight = 0;
                _SaleRptrTotalGSTAmount = 0;

                _SaleRptrNetRate = _SaleRptrNetRateBillPercentageAmount = _SaleRptrNormalItemAmount = 0;

                rptrItems.DataSource = ViewState["Row"];
                rptrItems.DataBind();
                rptrItems.Visible = true;
                txtItemWisePrice.Text = txtItemWiseDiscountInPercentage.Text = txtItemWiseBillingInPercentage.Text = txtDiscountedValue.Text = "0";
                BindTableFooterChallanItemData();
                btnConfirmAndSubmit.Visible = false;
                btnResetConfirm.Visible = false;
                _isDeletePermission = true;
                ddlPartyName.Enabled = false;

                //if (_objItemMaster != null)
                //{
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                //    rptrItems.DataSource = ViewState["Row"];
                //    rptrItems.DataBind();
                //    rptrItems.Visible = true;
                //    btnConfirmAndSubmit.Visible = false;
                //    btnResetConfirm.Visible = false;
                //}
            }
        }



        public void createtableforEditSaleOrder()
        {
            _dataTableItemsList.Columns.Add("sale_item_type_id", typeof(int));
            _dataTableItemsList.Columns.Add("sale_item_type_title", typeof(string));
            _dataTableItemsList.Columns.Add("item_master_id", typeof(int));
            _dataTableItemsList.Columns.Add("sale_item_name", typeof(string));
            _dataTableItemsList.Columns.Add("sale_item_quantity", typeof(string));
            _dataTableItemsList.Columns.Add("sale_item_net_price", typeof(int));
            _dataTableItemsList.Columns.Add("sale_item_price", typeof(int));
            _dataTableItemsList.Columns.Add("sale_item_price_2", typeof(int));
            _dataTableItemsList.Columns.Add("sale_item_weight", typeof(Decimal));

            _dataTableItemsList.Columns.Add("item_gst_percentage", typeof(int));
            _dataTableItemsList.Columns.Add("item_discount_percentage", typeof(Decimal));
            _dataTableItemsList.Columns.Add("item_bill_percentage", typeof(Decimal));
            _dataTableItemsList.Columns.Add("item_discount_amount", typeof(Decimal));
            _dataTableItemsList.Columns.Add("item_amount", typeof(Decimal));
            _dataTableItemsList.Columns.Add("item_final_amount", typeof(Decimal));
            _dataTableItemsList.Columns.Add("item_bill_rate", typeof(Decimal));
            _dataTableItemsList.Columns.Add("item_bill_amount", typeof(Decimal));
            _dataTableItemsList.Columns.Add("item_gst_amount", typeof(Decimal));

            rptrItems.DataSource = _dataTableItemsList;
            rptrItems.DataBind();
        }
        /// <summary>
        /// This Method is Used to Delete Item from Table at Run Time
        /// </summary>
        public void deleteRowfromtable(int _itemIdForRemove)
        {
            // Get  Repeater Values From View to Data Table
            _dataTableItemsList.Columns.Add("sale_item_type_id", typeof(int));
            _dataTableItemsList.Columns.Add("sale_item_type_title", typeof(string));
            _dataTableItemsList.Columns.Add("item_master_id", typeof(int));
            _dataTableItemsList.Columns.Add("sale_item_name", typeof(string));
            _dataTableItemsList.Columns.Add("sale_item_quantity", typeof(string));
            _dataTableItemsList.Columns.Add("sale_item_net_price", typeof(int));
            _dataTableItemsList.Columns.Add("sale_item_price", typeof(int));
            _dataTableItemsList.Columns.Add("sale_item_price_2", typeof(int));
            _dataTableItemsList.Columns.Add("sale_item_weight", typeof(Decimal));

            _dataTableItemsList.Columns.Add("item_gst_percentage", typeof(int));
            _dataTableItemsList.Columns.Add("item_discount_percentage", typeof(Decimal));
            _dataTableItemsList.Columns.Add("item_bill_percentage", typeof(Decimal));
            _dataTableItemsList.Columns.Add("item_discount_amount", typeof(Decimal));
            _dataTableItemsList.Columns.Add("item_amount", typeof(Decimal));
            _dataTableItemsList.Columns.Add("item_final_amount", typeof(Decimal));
            _dataTableItemsList.Columns.Add("item_bill_rate", typeof(Decimal));
            _dataTableItemsList.Columns.Add("item_bill_amount", typeof(Decimal));
            _dataTableItemsList.Columns.Add("item_gst_amount", typeof(Decimal));
           

            rptrItems.DataSource = _dataTableItemsList;
            rptrItems.DataBind();

            _dataTableItemsList = (DataTable)ViewState["Row"];

            // Create New DataTable and Columns At Run Time
            DataTable _dataTableItemsListRemove = new DataTable();
            _dataTableItemsListRemove.Columns.Add("sale_item_type_id", typeof(int));
            _dataTableItemsListRemove.Columns.Add("sale_item_type_title", typeof(string));
            _dataTableItemsListRemove.Columns.Add("item_master_id", typeof(int));
            _dataTableItemsListRemove.Columns.Add("sale_item_name", typeof(string));
            _dataTableItemsListRemove.Columns.Add("sale_item_quantity", typeof(string));
            _dataTableItemsListRemove.Columns.Add("sale_item_net_price", typeof(int));
            _dataTableItemsListRemove.Columns.Add("sale_item_price", typeof(int));
            _dataTableItemsListRemove.Columns.Add("sale_item_price_2", typeof(int));
            _dataTableItemsListRemove.Columns.Add("sale_item_weight", typeof(Decimal));

            _dataTableItemsListRemove.Columns.Add("item_gst_percentage", typeof(int));
            _dataTableItemsListRemove.Columns.Add("item_discount_percentage", typeof(Decimal));
            _dataTableItemsListRemove.Columns.Add("item_bill_percentage", typeof(Decimal));
            _dataTableItemsListRemove.Columns.Add("item_discount_amount", typeof(Decimal));
            _dataTableItemsListRemove.Columns.Add("item_amount", typeof(Decimal));
            _dataTableItemsListRemove.Columns.Add("item_final_amount", typeof(Decimal));
            _dataTableItemsListRemove.Columns.Add("item_bill_rate", typeof(Decimal));
            _dataTableItemsListRemove.Columns.Add("item_bill_amount", typeof(Decimal));
            _dataTableItemsListRemove.Columns.Add("item_gst_amount", typeof(Decimal));


            // Assing Datable Items To Another DataTable and Skip Selected Item  for Remove/Delete

            for (int _datatableRowIndexPostion = 0; _datatableRowIndexPostion < _dataTableItemsList.Rows.Count; _datatableRowIndexPostion++)
            {
                if (_dataTableItemsList.Rows[_datatableRowIndexPostion]["item_master_id"].ToString() != Convert.ToInt32(_itemIdForRemove).ToString())
                {
                    DataRow _dataRowItemsListRemove = _dataTableItemsListRemove.NewRow();

                    _dataRowItemsListRemove["sale_item_type_id"] = Convert.ToInt32(_dataTableItemsList.Rows[_datatableRowIndexPostion]["sale_item_type_id"]);
                    _dataRowItemsListRemove["sale_item_type_title"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["sale_item_type_title"];
                    _dataRowItemsListRemove["item_master_id"] = Convert.ToInt32(_dataTableItemsList.Rows[_datatableRowIndexPostion]["item_master_id"]);
                    _dataRowItemsListRemove["sale_item_name"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["sale_item_name"];
                    _dataRowItemsListRemove["sale_item_quantity"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["sale_item_quantity"];
                    _dataRowItemsListRemove["sale_item_net_price"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["sale_item_net_price"];
                    _dataRowItemsListRemove["sale_item_price"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["sale_item_price"];
                    _dataRowItemsListRemove["sale_item_price_2"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["sale_item_price_2"];
                    _dataRowItemsListRemove["sale_item_weight"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["sale_item_weight"];

                    _dataRowItemsListRemove["item_gst_percentage"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["item_gst_percentage"];
                    _dataRowItemsListRemove["item_discount_percentage"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["item_discount_percentage"];
                    _dataRowItemsListRemove["item_bill_percentage"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["item_bill_percentage"];
                    _dataRowItemsListRemove["item_discount_amount"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["item_discount_amount"];
                    _dataRowItemsListRemove["item_amount"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["item_amount"];
                    _dataRowItemsListRemove["item_bill_rate"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["item_bill_rate"];
                    _dataRowItemsListRemove["item_bill_amount"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["item_bill_amount"];
                    _dataRowItemsListRemove["item_gst_amount"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["item_gst_amount"];
                    _dataRowItemsListRemove["item_final_amount"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["item_final_amount"];

                    // Add Values one -by one to New DataTable 
                    _dataTableItemsListRemove.Rows.Add(_dataRowItemsListRemove);

                    if (_dataTableItemsListRemove.Rows.Count > 0)
                    {
                        int _totalPiad = 0;
                        for (int RowIndexPostionForRemove = 0; RowIndexPostionForRemove < _dataTableItemsListRemove.Rows.Count; RowIndexPostionForRemove++)
                        {
                            _totalPiad += Convert.ToInt32(_dataTableItemsListRemove.Rows[RowIndexPostionForRemove]["sale_item_net_price"].ToString());

                        }


                    }
                }
                else
                {
                      _totalItemCount = _totalItemCount - Convert.ToInt32(_dataTableItemsList.Rows[_datatableRowIndexPostion]["sale_item_quantity"]);
                    _totalItemWeight = _totalItemWeight - (Convert.ToDecimal(_dataTableItemsList.Rows[_datatableRowIndexPostion]["sale_item_weight"]) * Convert.ToDecimal(_dataTableItemsList.Rows[_datatableRowIndexPostion]["sale_item_quantity"]));
                }

            }

            if (_dataTableItemsListRemove.Rows.Count > 0)
            {
                ViewState["Row"] = _dataTableItemsListRemove;

                _SaleRptrBillAmountBeforeGST = _SaleRptrTotalItemAmountBeforeGST = 0;
                _SaleRptrTotalItemQuantity = 0;
                _SaleRptrTotalItemWeight = 0;
                _SaleRptrTotalGSTAmount = 0;

                _SaleRptrNetRate = _SaleRptrNetRateBillPercentageAmount = _SaleRptrNormalItemAmount = 0;
                rptrItems.DataSource = ViewState["Row"];
                rptrItems.DataBind();
                rptrItems.Visible = true;
                BindTableFooterChallanItemData();
                btnConfirmAndSubmit.Visible = false;
                btnResetConfirm.Visible = false;

            }
            else
            {

                ViewState["Row"] = _dataTableItemsListRemove;

                _SaleRptrBillAmountBeforeGST = _SaleRptrTotalItemAmountBeforeGST = 0;
                _SaleRptrTotalItemQuantity = 0;
                _SaleRptrTotalItemWeight = 0;
                _SaleRptrTotalGSTAmount = 0;

                _SaleRptrNetRate = _SaleRptrNetRateBillPercentageAmount = _SaleRptrNormalItemAmount = 0;

                rptrItems.DataSource = ViewState["Row"];
                rptrItems.DataBind();
                rptrItems.Visible = false;
                BindTableFooterChallanItemData();
                btnConfirmAndSubmit.Visible = false;
                btnResetConfirm.Visible = false;

            }


        }

        #endregion

        #region Get and Bind SaleOrder Details


        private void GetSaleOrderPartyDetails(string _saleHeader_id)
        {
            Int32 _SaleHeader_id = Convert.ToInt32(_saleHeader_id);
            _objSaleHeaderBL = new SaleHeaderBL();

            _lstSaleHeaderPartyDetail = _objSaleHeaderBL.GetAllSaleHeaderItemsWithPatryDetails().OrderByDescending(x => x.sale_header_id).ToList();

            //_objvwSaleHeader = _lstSaleHeaderPartyDetail.Where(x => x.sale_header_id == _SaleHeader_id && x.order_status == App.Helper.Utils.OrderStatus.rejected.ToString()).FirstOrDefault();

            _objvwSaleHeader = _lstSaleHeaderPartyDetail.Where(x => x.sale_header_id == _SaleHeader_id && x.order_status != App.Helper.Utils.OrderStatus.complete.ToString()).FirstOrDefault();

            if (_objvwSaleHeader != null)
            {
                _bindSaleItemStatus = true;

                HdnfSaleHeaderId.Value = _objvwSaleHeader.sale_header_id.ToString();

                txtFixedDiscountinPercentage.Text = _objvwSaleHeader.tough_discount_precentage.ToString();
                txtFixedBillingInPercentage.Text = _objvwSaleHeader.tough_billing_precentage.ToString();
                txtRemarks.Text = _objvwSaleHeader.sale_item_remarks.ToString();

                ddlPartyName.Enabled = false;
                ddlPartyName.SelectedValue = _objvwSaleHeader.party_master_id.ToString();

                ddlPriceType.SelectedValue = _objvwSaleHeader.price_list.ToString();

                ddlItemTypeList.SelectedIndex = 0;

                _orderStatus = _objvwSaleHeader.order_status.ToString();
                _orderCreatedOn = _objvwSaleHeader.created_on;
                _orderNumber = _objvwSaleHeader.order_number;



            }
            else
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "notification('Sorry Your Order Status is Complete','danger');", true);
            }

        }

        private void PopulateDataSaleItems(string _saleHeaderId)
        {
            try
            {
                Int32 _SaleHeaderId = Convert.ToInt32(_saleHeaderId);

                _objSaleItemBL = new SaleItemBL();
                _lstSaleItem = _objSaleItemBL.GetAllSaleItemItems().Where(x => x.sale_header_id == Convert.ToInt32(_SaleHeaderId)).ToList();


                if (_lstSaleItem  !=null)
                {
                    if (_lstSaleItem.Count > 0)
                    {
                        _SaleRptrBillAmountBeforeGST = _SaleRptrTotalItemAmountBeforeGST = 0;
                        _SaleRptrTotalItemQuantity = 0;
                        _SaleRptrTotalItemWeight = 0;
                        _SaleRptrTotalGSTAmount = 0;

                        _SaleRptrNetRate = _SaleRptrNetRateBillPercentageAmount = _SaleRptrNormalItemAmount = 0;

                        rptrItems.Visible = true;
                      //  createtableforEditSaleOrder();


                        

                        createtableforEditSaleOrder();

                        for (int _indexPosition = 0; _indexPosition < _lstSaleItem.Count; _indexPosition++)
                        {
                            if(ViewState["Row"] != null)
                            {
                                int _alreadyCount = 0;
                                _dataTableItemsList = (DataTable)ViewState["Row"];

                                for (int _datatableRowIndexPostion = 0; _datatableRowIndexPostion < _dataTableItemsList.Rows.Count; _datatableRowIndexPostion++)
                                {
                                    if (_dataTableItemsList.Rows[_datatableRowIndexPostion]["item_master_id"].ToString() == Convert.ToInt32(_lstSaleItem[_indexPosition].item_master_id).ToString())
                                    {
                                        _alreadyCount = _alreadyCount + 1;
                                    }
                                }

                                if (_alreadyCount == 0)
                                {
                                    DataRow _dataRowItemsList = _dataTableItemsList.NewRow();
                                    _dataRowItemsList["sale_item_type_id"] = Convert.ToInt32(_lstSaleItem[_indexPosition].sale_item_type_id.ToString());
                                    _dataRowItemsList["sale_item_type_title"] = _lstSaleItem[_indexPosition].sale_item_type_title.ToString();
                                    _dataRowItemsList["item_master_id"] = Convert.ToInt32(_lstSaleItem[_indexPosition].item_master_id);
                                    _dataRowItemsList["sale_item_name"] = _lstSaleItem[_indexPosition].sale_item_name;
                                    _dataRowItemsList["sale_item_quantity"] = _lstSaleItem[_indexPosition].sale_item_quantity;
                                    _dataRowItemsList["sale_item_net_price"] = _lstSaleItem[_indexPosition].sale_item_net_price;
                                    _dataRowItemsList["sale_item_price"] = Convert.ToDecimal(_lstSaleItem[_indexPosition].sale_item_price);
                                    _dataRowItemsList["sale_item_price_2"] = Convert.ToDecimal(_lstSaleItem[_indexPosition].sale_item_price_2);
                                    _dataRowItemsList["sale_item_weight"] = Convert.ToDecimal(_lstSaleItem[_indexPosition].item_weight);

                                    _dataRowItemsList["item_gst_percentage"] = Convert.ToInt32(_lstSaleItem[_indexPosition].item_gst_percentage);
                                    _dataRowItemsList["item_discount_percentage"] = Convert.ToDecimal(_lstSaleItem[_indexPosition].item_discount_percentage);
                                    _dataRowItemsList["item_bill_percentage"] = Convert.ToDecimal(_lstSaleItem[_indexPosition].item_bill_percentage);
                                    _dataRowItemsList["item_discount_amount"] = Convert.ToDecimal(_lstSaleItem[_indexPosition].item_discount_amount);
                                    _dataRowItemsList["item_amount"] = Convert.ToDecimal(_lstSaleItem[_indexPosition].item_amount);
                                    _dataRowItemsList["item_bill_rate"] = Convert.ToDecimal(_lstSaleItem[_indexPosition].item_bill_rate);
                                    _dataRowItemsList["item_bill_amount"] = Convert.ToDecimal(_lstSaleItem[_indexPosition].item_bill_amount);
                                    _dataRowItemsList["item_gst_amount"] = Convert.ToDecimal(_lstSaleItem[_indexPosition].item_gst_amount);
                                    _dataRowItemsList["item_final_amount"] = Convert.ToDecimal(_lstSaleItem[_indexPosition].item_final_amount);

                                    _dataTableItemsList.Rows.Add(_dataRowItemsList);

                                    ViewState["Row"] = _dataTableItemsList;

                                    //This Field Add Here for Store Total Item Count in SaleHeader Table and Item Weight
                                    _totalItemCount = _totalItemCount + Convert.ToInt32(_lstSaleItem[_indexPosition].sale_item_quantity);
                                    _totalItemWeight = _totalItemWeight + (Convert.ToDecimal(_lstSaleItem[_indexPosition].item_weight) * Convert.ToDecimal(_lstSaleItem[_indexPosition].sale_item_quantity));

                                    ////
                                }
                            }
                            else
                            {
                                DataRow _dataRowItemsList = _dataTableItemsList.NewRow();
                                _dataRowItemsList["sale_item_type_id"] = Convert.ToInt32(_lstSaleItem[_indexPosition].sale_item_type_id.ToString());
                                _dataRowItemsList["sale_item_type_title"] = _lstSaleItem[_indexPosition].sale_item_type_title.ToString();
                                _dataRowItemsList["item_master_id"] = Convert.ToInt32(_lstSaleItem[_indexPosition].item_master_id);
                                _dataRowItemsList["sale_item_name"] = _lstSaleItem[_indexPosition].sale_item_name;
                                _dataRowItemsList["sale_item_quantity"] = _lstSaleItem[_indexPosition].sale_item_quantity;
                                _dataRowItemsList["sale_item_net_price"] = _lstSaleItem[_indexPosition].sale_item_net_price;
                                _dataRowItemsList["sale_item_price"] = Convert.ToDecimal(_lstSaleItem[_indexPosition].sale_item_price);
                                _dataRowItemsList["sale_item_price_2"] = Convert.ToDecimal(_lstSaleItem[_indexPosition].sale_item_price_2);
                                _dataRowItemsList["sale_item_weight"] = Convert.ToDecimal(_lstSaleItem[_indexPosition].item_weight);

                                _dataRowItemsList["item_gst_percentage"] = Convert.ToInt32(_lstSaleItem[_indexPosition].item_gst_percentage);
                                _dataRowItemsList["item_discount_percentage"] = Convert.ToDecimal(_lstSaleItem[_indexPosition].item_discount_percentage);
                                _dataRowItemsList["item_bill_percentage"] = Convert.ToDecimal(_lstSaleItem[_indexPosition].item_bill_percentage);
                                _dataRowItemsList["item_discount_amount"] = Convert.ToDecimal(_lstSaleItem[_indexPosition].item_discount_amount);
                                _dataRowItemsList["item_amount"] = Convert.ToDecimal(_lstSaleItem[_indexPosition].item_amount);
                                _dataRowItemsList["item_bill_rate"] = Convert.ToDecimal(_lstSaleItem[_indexPosition].item_bill_rate);
                                _dataRowItemsList["item_bill_amount"] = Convert.ToDecimal(_lstSaleItem[_indexPosition].item_bill_amount);
                                _dataRowItemsList["item_gst_amount"] = Convert.ToDecimal(_lstSaleItem[_indexPosition].item_gst_amount);
                                _dataRowItemsList["item_final_amount"] = Convert.ToDecimal(_lstSaleItem[_indexPosition].item_final_amount);

                                _dataTableItemsList.Rows.Add(_dataRowItemsList);



                                ViewState["Row"] = _dataTableItemsList;

                                //This Field Add Here for Store Total Item Count in SaleHeader Table and Item Weight
                                _totalItemCount = _totalItemCount + Convert.ToInt32(_lstSaleItem[_indexPosition].sale_item_quantity);
                                _totalItemWeight = _totalItemWeight + (Convert.ToDecimal(_lstSaleItem[_indexPosition].item_weight) * Convert.ToDecimal(_lstSaleItem[_indexPosition].sale_item_quantity)); 
                                

                                ////
                            }
                        }


                        _dataTableItemsList = (DataTable)ViewState["Row"];
                        rptrItems.DataSource = _dataTableItemsList;
                        rptrItems.DataBind();

                        BindTableFooterChallanItemData();

                        //if (ViewState["Row"] != null)
                        //{

                        //}
                        //else
                        //{

                        //}

                        //for (int _indexPosition = 0; _indexPosition < _lstSaleItem.Count; _indexPosition++)
                        //{


                        //}
                    }
                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }

        }

        #endregion


        #region Get Staff Details From General Form TextFields
        /// <summary>
        /// This Method is Used to Get Staff Details From General Form TextFields to StaffMaster Object
        /// </summary>
        /// <returns></returns>
        private App.BusinessModel.SaleHeader GetSaleHeaderObject()
        {
            try
            {
                _objSaleHeaderBL = new App.Business.SaleHeaderBL();

                _objSaleHeader.guid = Guid.NewGuid();
                _objSaleHeader.party_master_id = Convert.ToInt32(ddlPartyName.SelectedValue);
               // _objSaleHeader.total_items = Convert.ToInt32(txtItemQuantity.Text);
                _objSaleHeader.order_number = CreateOrderNumber();
                _objSaleHeader.total_items = Convert.ToInt32(_totalItemCount);
                //_objSaleHeader.total_amount_billed = Convert.ToDecimal(txtBillAmount.Text);
                //_objSaleHeader.total_amount_cash = Convert.ToDecimal(txtTotalCash.Text);
                //_objSaleHeader.total_amount = Convert.ToDecimal(txtTotalAmount.Text);
                _objSaleHeader.total_amount_billed = Convert.ToDecimal(_SaleRptrBillAmountAfterGST);
                _objSaleHeader.total_amount_cash = Convert.ToDecimal(_SaleRptrTotalCashAmount);
                _objSaleHeader.total_amount = Convert.ToDecimal(_SaleRptrTotalAmountAfterGST);
                _objSaleHeader.tough_discount_precentage = Convert.ToDecimal(txtFixedDiscountinPercentage.Text == "" ? "0" : txtFixedDiscountinPercentage.Text);
               // _objSaleHeader.tough_discount = Convert.ToDecimal(_lblToughDiscountAmount) - Convert.ToDecimal(lblToughDiscountAmount.Text);
                _objSaleHeader.tough_discount = Convert.ToDecimal(0);
                _objSaleHeader.tough_total_amount = Convert.ToDecimal(0);

                _objSaleHeader.tough_billing_amount = Convert.ToDecimal(0);
                _objSaleHeader.tough_billing_precentage = Convert.ToInt32(txtFixedBillingInPercentage.Text == "" ? "0" : txtFixedBillingInPercentage.Text);

                _objSaleHeader.htf_discount = Convert.ToDecimal(0);
                _objSaleHeader.lami_discount = Convert.ToDecimal(0);
                _objSaleHeader.lami_discount_precentage = Convert.ToDecimal(txtLamiDiscount.Text);
                _objSaleHeader.lami_billing_precentage = Convert.ToInt32(txtLamiBillingPercentage.Text);
                _objSaleHeader.lami_billing_amount = Convert.ToDecimal(lblLamiBillingPercentageAmount.Text =="" ? "0": lblLamiBillingPercentageAmount.Text);
                _objSaleHeader.lami_total_amount = Convert.ToDecimal(0);
                _objSaleHeader.sale_item_remarks = txtRemarks.Text;


                _objSaleHeader.price_list = ddlPriceType.SelectedValue.ToString();

                //_objSaleHeader.total_net_rate = Convert.ToDecimal(_netRate);
                _objSaleHeader.total_net_rate = Convert.ToDecimal(_SaleRptrNetRate);
                _objSaleHeader.netrate_billing_amount = Convert.ToDecimal(_SaleRptrNetRateBillPercentageAmount);
                _objSaleHeader.netrate_billing_precentage = Convert.ToInt32(_SaleRptrNetRateBillPercentage);

               // _objSaleHeader.gst_amount = (Convert.ToDecimal(txtBillAmount.Text) * Convert.ToDecimal(18))/ Convert.ToDecimal(100);
                _objSaleHeader.gst_amount = Convert.ToDecimal(_SaleRptrTotalGSTAmount);
                _objSaleHeader.billing_grand_total = Convert.ToDecimal(_SaleRptrBillAmountAfterGST);
                _objSaleHeader.total_weight = _totalItemWeight;

                // _objSaleHeader.tough_discount = Convert.ToInt32(txtDiscount.Text);
                _objSaleHeader.order_status = App.Helper.Utils.OrderStatus.pending.ToString();

                _objSaleHeader.staff_name = Convert.ToString(Session[Constants.UserName]);
                _objSaleHeader.made_by = Convert.ToString(Session[Constants.UserName]);
                _objSaleHeader.created_by = Convert.ToInt32(Session[Constants.Id]);
                _objSaleHeader.modified_by = Convert.ToInt32(Session[Constants.Id]);

                _objSaleHeader.sale_item_date = Convert.ToDateTime(System.DateTime.Now.ToString());
                //Convert.ToDateTime(_objStaffMaster.staff_joinning_date).ToString("MM/dd/yyyy");


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objSaleHeader;
        }

        private App.BusinessModel.SaleHeader GetSaleHeaderObjectForUpdate()
        {
            try
            {
                _objSaleHeaderBL = new App.Business.SaleHeaderBL();

                _objSaleHeader.guid = Guid.NewGuid();
                _objSaleHeader.sale_header_id = Convert.ToInt32(HdnfSaleHeaderId.Value);
                _objSaleHeader.party_master_id = Convert.ToInt32(ddlPartyName.SelectedValue);
                
                _objSaleHeader.order_number = _orderNumber;
                _objSaleHeader.total_items = Convert.ToInt32(_totalItemCount);
                
                _objSaleHeader.total_amount_billed = Convert.ToDecimal(_SaleRptrBillAmountAfterGST);
                _objSaleHeader.total_amount_cash = Convert.ToDecimal(_SaleRptrTotalCashAmount);
                _objSaleHeader.total_amount = Convert.ToDecimal(_SaleRptrTotalAmountAfterGST);
                _objSaleHeader.tough_discount_precentage = Convert.ToDecimal(txtFixedDiscountinPercentage.Text == "" ? "0" : txtFixedDiscountinPercentage.Text);
                
                _objSaleHeader.tough_discount = Convert.ToDecimal(0);
                _objSaleHeader.tough_total_amount = Convert.ToDecimal(0);

                _objSaleHeader.tough_billing_amount = Convert.ToDecimal(0);
                _objSaleHeader.tough_billing_precentage = Convert.ToInt32(txtFixedBillingInPercentage.Text == "" ? "0" : txtFixedBillingInPercentage.Text);

                _objSaleHeader.htf_discount = Convert.ToDecimal(0);
                _objSaleHeader.lami_discount = Convert.ToDecimal(0);
                _objSaleHeader.lami_discount_precentage = Convert.ToDecimal(txtLamiDiscount.Text);
                _objSaleHeader.lami_billing_precentage = Convert.ToInt32(txtLamiBillingPercentage.Text);
                _objSaleHeader.lami_billing_amount = Convert.ToDecimal(lblLamiBillingPercentageAmount.Text == "" ? "0" : lblLamiBillingPercentageAmount.Text);
                _objSaleHeader.lami_total_amount = Convert.ToDecimal(0);
                _objSaleHeader.sale_item_remarks = txtRemarks.Text;


                _objSaleHeader.price_list = ddlPriceType.SelectedValue.ToString();

                //_objSaleHeader.total_net_rate = Convert.ToDecimal(_netRate);
                _objSaleHeader.total_net_rate = Convert.ToDecimal(_SaleRptrNetRate);
                _objSaleHeader.netrate_billing_amount = Convert.ToDecimal(_SaleRptrNetRateBillPercentageAmount);
                _objSaleHeader.netrate_billing_precentage = Convert.ToInt32(_SaleRptrNetRateBillPercentage);

                // _objSaleHeader.gst_amount = (Convert.ToDecimal(txtBillAmount.Text) * Convert.ToDecimal(18))/ Convert.ToDecimal(100);
                _objSaleHeader.gst_amount = Convert.ToDecimal(_SaleRptrTotalGSTAmount);
                _objSaleHeader.billing_grand_total = Convert.ToDecimal(_SaleRptrBillAmountAfterGST);
                _objSaleHeader.total_weight = _totalItemWeight;

                // _objSaleHeader.tough_discount = Convert.ToInt32(txtDiscount.Text);
               // _objSaleHeader.order_status = App.Helper.Utils.OrderStatus.pending.ToString();
                _objSaleHeader.order_status = _orderStatus.ToString();

                _objSaleHeader.staff_name = Convert.ToString(Session[Constants.UserName]);
                _objSaleHeader.made_by = Convert.ToString(Session[Constants.UserName]);
                _objSaleHeader.created_by = Convert.ToInt32(Session[Constants.Id]);
                _objSaleHeader.modified_by = Convert.ToInt32(Session[Constants.Id]);
                _objSaleHeader.created_on = _orderCreatedOn;
                _objSaleHeader.modified_on = _orderCreatedOn;
                _objSaleHeader.is_active = true;

                _objSaleHeader.sale_item_date = _orderCreatedOn;
                //Convert.ToDateTime(_objStaffMaster.staff_joinning_date).ToString("MM/dd/yyyy");


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objSaleHeader;
        }

        #endregion

        #region
        private void BindItemTypeList()
        {
            try
            {

                _objDropdownMasterBL = new DropdownMasterBL();

                _lstDropdownMaster = _objDropdownMasterBL.GetAllDropdownMasterItems().Where(x => x.dropdown_type == "Item Type" && x.is_active== true).ToList();

                ddlItemTypeList.DataSource = _lstDropdownMaster;

                ddlItemTypeList.DataTextField = "dropdown_item_name";
                ddlItemTypeList.DataValueField = "dropdown_master_id";
                ddlItemTypeList.DataBind();
                ddlItemTypeList.Items.Insert(0, new ListItem("Select", "Select"));


            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }


        /// <summary>
        /// This Method is Used to Get Party List
        /// </summary>
        private void BindPartyList()
        {
            try
            {

                _objPartyMasterBL = new PartyMasterBL();

                _lstPartyMaster = _objPartyMasterBL.GetAllPartyMasterItems().Where(x => x.is_active == true).ToList();

                if (_lstPartyMaster !=null)
                {
                    ddlPartyName.DataSource = _lstPartyMaster;

                    ddlPartyName.DataTextField = "party_name";
                    ddlPartyName.DataValueField = "party_master_id";
                    ddlPartyName.DataBind();
                    ddlPartyName.Items.Insert(0, new ListItem("Select", "Select"));
                }
                else
                {

                }
                

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }


        /// <summary>
        /// This Method is Used to Get Item Details Like Price, Type and ItemWeight, other
        /// </summary>
        private ItemMaster GetSelectedItemDetailsById( int _selectedItemMasterId)
        {
            try
            {

                _objItemMasterBL = new ItemMasterBL();

                _objItemMaster = _objItemMasterBL.GetItemMasterItemsByID(_selectedItemMasterId).FirstOrDefault();

                if (_objItemMaster != null)
                {
                    if(_objItemMaster.item_master_id > 0)
                    {

                    }
                    else
                    {

                    }

                    
                }
                else
                {

                }

                

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
               
            }
            return _objItemMaster;
        }

        #endregion

        #region Reset TextFiled Values
        /// <summary>
        /// This Method is Used to Reset TextFiled Values
        /// </summary>
        private void ResetTextField()
        {
            try
            {
                txtToughDiscount.Text = txtToughBillingPercentage.Text = txtLamiDiscount.Text = txtLamiBillingPercentage.Text = txtNetRateBillingPercentage.Text = txtTotalAmount.Text = txtTotalCash.Text = txtBillAmount.Text = "0";
                lblToughDiscountAmount.Text = lblToughBillingPercentageAmount.Text = lblLamiDiscountAmount.Text = lblLamiBillingPercentageAmount.Text = lblnetRateBillingPercentageAmount.Text = string.Empty;
                txtToughDiscount.ReadOnly = txtToughBillingPercentage.ReadOnly = txtLamiDiscount.ReadOnly = txtLamiBillingPercentage.ReadOnly = txtNetRateBillingPercentage.ReadOnly = true;


                _totalItemCount = 0;
                _totalItemWeight = 0;
                ddlPartyName.Enabled = true;
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }
           
        }
        #endregion

        #region Reset All TextFiled Values and Varriables and Repeater and Visible and Hide Buttons
        /// <summary>
        /// This Method is Used to Reset All TextFiled Values and Varriables and Repeater and Visible and Hide Buttons
        /// </summary>
        private void ResetAllFieldandValue()
        {
            try
            {
                _totalItemCount = 0;
                _totalItemWeight = 0;
                ResetTextField();
                _netRate = 0;
                _totalAmount = 0;
                ddlPartyName.Enabled = true;
                btnAddItem.Visible = true;
                btnResetPartyDetails.Visible = true;
                txtNetRate.Text = txtItemQuantity.Text = txtItemWiseBillingInPercentage.Text = txtItemWiseDiscountInPercentage.Text = txtFinalItemAmount.Text = "0";

                ddlPartyName.Enabled = true;
                ddlPartyName.SelectedIndex = 0;
                ddlItemList.SelectedIndex = 0;
                ddlItemList.Enabled = false;
                ddlPriceType.SelectedIndex = 0;
                ddlItemTypeList.SelectedIndex = 0;

                ViewState["Row"] = _dataTableItemsList = null;
                rptrItems.DataSource = ViewState["Row"];
                rptrItems.DataBind();
                rptrItems.Visible = true;
                btnConfirmAndSubmit.Visible = false;
                btnResetConfirm.Visible = false;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }
        #endregion
        public void SaveOrder()
        {
            GetSaleHeaderObject();
        }

        protected void txtItemWiseBillingInPercentage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Decimal _DiscountValue, BillRate, FinalItemAmount, _ItemWiseGstAmount = 0;

                if (txtItemWiseBillingInPercentage.Text == "" || txtItemWiseBillingInPercentage.Text == null)
                {
                    txtItemWiseBillingInPercentage.Focus();
                    txtItemWiseBillingInPercentage.Text = "0";

                    _DiscountValue = Convert.ToDecimal(txtItemWisePrice.Text) - (Convert.ToDecimal(txtItemWisePrice.Text) / 100 * Convert.ToDecimal(txtItemWiseDiscountInPercentage.Text));
                    txtDiscountedValue.Text = _DiscountValue.ToString();
                }
                else
                {
                    _DiscountValue = Convert.ToDecimal(txtItemWisePrice.Text) - (Convert.ToDecimal(txtItemWisePrice.Text) / 100 * Convert.ToDecimal(txtItemWiseDiscountInPercentage.Text));
                    txtDiscountedValue.Text = _DiscountValue.ToString();

                    BillRate = (Convert.ToDecimal(txtDiscountedValue.Text) / 100) * Convert.ToDecimal(txtItemWiseBillingInPercentage.Text);

                    _ItemWiseGstAmount = (BillRate / 100) * Convert.ToDecimal(lblItemWiseGstinPercentage.Text);

                    FinalItemAmount = Convert.ToDecimal(txtDiscountedValue.Text) + _ItemWiseGstAmount;
                    txtFinalItemAmount.Text = FinalItemAmount.ToString();
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        protected void btnAddParty_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("/add-party", false);
            }
            catch( Exception ex)
            {
                ex.Message.ToString();
            }
        }

    

        protected void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            try
            {
                //bool _deleteSaleHeader = false;
                bool _deleteSaleItem = false;

                if (ViewState["Row"] != null)
                {
                    _objSaleHeaderBL = new App.Business.SaleHeaderBL();
                    _objSaleHeader = new SaleHeader();
                    _objSaleItem = new SaleItem();
                    _objSaleItemBL = new App.Business.SaleItemBL();


                    _objSaleHeader= _objSaleHeaderBL.UpdateSaleHeader(GetSaleHeaderObjectForUpdate());

                    _objSaleItem.sale_header_id = Convert.ToInt32(HdnfSaleHeaderId.Value);
                    _deleteSaleItem = _objSaleItemBL.DeleteSaleItem(_objSaleItem);

                    if (_objSaleHeader.sale_header_id > 0)
                    {
                        _dataTableItemsList = (DataTable)ViewState["Row"];
                        if (_dataTableItemsList.Rows.Count > 0)
                        {
                            int _SaleorderItemSaveCount = 0;

                            for (int _rowIndexPosition = 0; _rowIndexPosition < _dataTableItemsList.Rows.Count; _rowIndexPosition++)
                            {
                                _objSaleItem.guid = Guid.NewGuid();
                                _objSaleItem.sale_header_id = _objSaleHeader.sale_header_id;
                                _objSaleItem.item_master_id = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["item_master_id"].ToString());
                                _objSaleItem.party_master_id = _objSaleHeader.party_master_id;
                                _objSaleItem.sale_item_type_id = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_type_id"].ToString());
                                _objSaleItem.sale_item_type_title = _dataTableItemsList.Rows[_rowIndexPosition]["sale_item_type_title"].ToString();

                                _objSaleItem.sale_item_name = _dataTableItemsList.Rows[_rowIndexPosition]["sale_item_name"].ToString();
                                _objSaleItem.sale_item_quantity = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_quantity"].ToString());
                                _objSaleItem.sale_item_price = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_price"].ToString());
                                _objSaleItem.sale_item_price_2 = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_price_2"].ToString());
                                _objSaleItem.sale_item_net_price = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_net_price"].ToString());
                                _objSaleItem.item_weight = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_weight"].ToString());

                                _objSaleItem.item_gst_percentage = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["item_gst_percentage"].ToString());
                                _objSaleItem.item_discount_percentage = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["item_discount_percentage"].ToString());
                                _objSaleItem.item_bill_percentage = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["item_bill_percentage"].ToString());

                                _objSaleItem.item_discount_amount = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["item_discount_amount"].ToString());
                                _objSaleItem.item_amount = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["item_amount"].ToString());
                                _objSaleItem.item_bill_rate = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["item_bill_rate"].ToString());
                                _objSaleItem.item_bill_amount = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["item_bill_amount"].ToString());
                                _objSaleItem.item_gst_amount = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["item_gst_amount"].ToString());
                                _objSaleItem.item_final_amount = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["item_final_amount"].ToString());


                                _objSaleItem.created_on = Convert.ToDateTime(System.DateTime.Now.ToString());

                                _objSaleItem.created_by = Convert.ToInt32(Session[Constants.Id]);
                                _objSaleItem.modified_by = Convert.ToInt32(Session[Constants.Id]);

                                //This Field Add Here for Store Total Item Count in SaleHeader Table and Item Weight
                                //_totalItemCount = _totalItemCount + Convert.ToInt32(_objSaleItem.sale_item_quantity);
                                //_totalItemWeight = _totalItemWeight + Convert.ToDecimal(_objSaleItem.item_weight);

                                ////

                                _objSaleItem = _objSaleItemBL.CreateSaleItem(_objSaleItem);
                                _SaleorderItemSaveCount = _SaleorderItemSaveCount + 1;
                            }

                            if (_SaleorderItemSaveCount > 0)
                            {
                                rptrItems.DataSource = null;
                                rptrItems.DataBind();
                                rptrItems.Visible = false;

                                ViewState["Row"] = _dataTableItemsList = null;
                                //Update Last NetRateBilling Percentage for Party

                                _objPartyMasterBL = new PartyMasterBL();
                                _objPartyMaster = new PartyMaster();

                                _objPartyMaster = _objPartyMasterBL.GetPartyMasterItemsByID(_objSaleItem.party_master_id).FirstOrDefault();

                                if (_objPartyMaster != null)
                                {
                                    PartyMaster _objPartyMasterNew = new PartyMaster();
                                    _objPartyMasterBL = new PartyMasterBL();

                                    _objPartyMaster.netrate_billing_precentage = _objSaleHeader.netrate_billing_precentage;

                                    _objPartyMasterNew = _objPartyMasterBL.UpdatePartyMaster(_objPartyMaster);

                                    if (_objPartyMasterNew != null)
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showPurchaseSuccess();", true);
                                        ResetTextField();
                                    }
                                    else
                                    {
                                    }
                                }
                                else
                                {
                                }

                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                        }


                        // ClearGeneralForm();

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                }


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
        }



        protected void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                ResetAllFieldandValue();
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            

        }



        protected void btnSubmitOrder_Click(object sender, EventArgs e)
        {

            // AASGWeb.WebService.service.AddSaleOrder(Convert.ToInt32(ddlPartyName.SelectedValue), Convert.ToInt32(txtItemQuantity.Text), Convert.ToDateTime(System.DateTime.Now.ToString()));

            //_objSaleHeader= GetSaleHeaderObject();
            //_dataTableItemsList = (DataTable)ViewState["Row"];
            //string jsonString = JsonConvert.SerializeObject(_dataTableItemsList);
            //_lstSaleItem = JsonConvert.DeserializeObject<List<SaleItem>>(jsonString);
            //_objSale.party_master_id = _objSaleHeader.party_master_id;

            //_objSale.sale_items = _lstSaleItem;
            //  string postData = JsonConvert.SerializeObject(_objSale);
            // AASGWeb.WebService.service.AddSaleOrder(_objSale);


            try
            {
                if (ViewState["Row"] != null)
                {
                    _objSaleHeaderBL = new App.Business.SaleHeaderBL();
                    _objSaleItemBL = new App.Business.SaleItemBL();

                    _objSaleHeader = _objSaleHeaderBL.CreateSaleHeader(GetSaleHeaderObject());

                    if (_objSaleHeader.sale_header_id > 0)
                    {
                        _dataTableItemsList = (DataTable)ViewState["Row"];
                        if (_dataTableItemsList.Rows.Count > 0)
                        {
                            int _SaleorderItemSaveCount = 0;

                            for (int _rowIndexPosition = 0; _rowIndexPosition < _dataTableItemsList.Rows.Count; _rowIndexPosition++)
                            {
                                _objSaleItem.guid = Guid.NewGuid();
                                _objSaleItem.sale_header_id = _objSaleHeader.sale_header_id;
                                _objSaleItem.item_master_id = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["item_master_id"].ToString());
                                _objSaleItem.party_master_id = _objSaleHeader.party_master_id;
                                _objSaleItem.sale_item_type_id = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_type_id"].ToString());
                                _objSaleItem.sale_item_type_title = _dataTableItemsList.Rows[_rowIndexPosition]["sale_item_type_title"].ToString();

                                _objSaleItem.sale_item_name = _dataTableItemsList.Rows[_rowIndexPosition]["sale_item_name"].ToString();
                                _objSaleItem.sale_item_quantity = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_quantity"].ToString());
                                _objSaleItem.sale_item_price = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_price"].ToString());
                                _objSaleItem.sale_item_price_2 = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_price_2"].ToString());
                                _objSaleItem.sale_item_net_price = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_net_price"].ToString());
                                _objSaleItem.item_weight = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_weight"].ToString());

                                _objSaleItem.item_gst_percentage = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["item_gst_percentage"].ToString());
                                _objSaleItem.item_discount_percentage = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["item_discount_percentage"].ToString());
                                _objSaleItem.item_bill_percentage = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["item_bill_percentage"].ToString());

                                _objSaleItem.item_discount_amount = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["item_discount_amount"].ToString());
                                _objSaleItem.item_amount = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["item_amount"].ToString());
                                _objSaleItem.item_bill_rate = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["item_bill_rate"].ToString());
                                _objSaleItem.item_bill_amount = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["item_bill_amount"].ToString());
                                _objSaleItem.item_gst_amount = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["item_gst_amount"].ToString());
                                _objSaleItem.item_final_amount = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["item_final_amount"].ToString());
                              

                                _objSaleItem.created_on = Convert.ToDateTime(System.DateTime.Now.ToString());

                                _objSaleItem.created_by = Convert.ToInt32(Session[Constants.Id]);
                                _objSaleItem.modified_by = Convert.ToInt32(Session[Constants.Id]);

                                _objSaleItem = _objSaleItemBL.CreateSaleItem(_objSaleItem);
                                _SaleorderItemSaveCount = _SaleorderItemSaveCount + 1;
                            }

                            if (_SaleorderItemSaveCount > 0)
                            {
                                rptrItems.DataSource = null;
                                rptrItems.DataBind();
                                rptrItems.Visible = false;

                                ViewState["Row"] = _dataTableItemsList = null;

                              
                                //Update Last NetRateBilling Percentage for Party

                                _objPartyMasterBL = new PartyMasterBL();
                                _objPartyMaster = new PartyMaster();

                                _objPartyMaster = _objPartyMasterBL.GetPartyMasterItemsByID(_objSaleItem.party_master_id).FirstOrDefault();

                                if(_objPartyMaster != null)
                                {
                                    PartyMaster _objPartyMasterNew = new PartyMaster();
                                    _objPartyMasterBL = new PartyMasterBL();

                                    _objPartyMaster.netrate_billing_precentage = _objSaleHeader.netrate_billing_precentage;

                                    _objPartyMasterNew = _objPartyMasterBL.UpdatePartyMaster(_objPartyMaster);

                                    if(_objPartyMasterNew != null)
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showPurchaseSuccess();", true);
                                        ResetTextField();
                                    }
                                    else
                                    {
                                    }
                                }
                                else
                                {
                                }

                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                        }


                        // ClearGeneralForm();

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                }


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlPartyName.SelectedValue =="Select" || ddlPartyName.SelectedValue == "" ||  ddlPartyName.SelectedValue == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlertClientName();", true);
                }
                else if (ddlPriceType.SelectedValue == "0" || ddlPriceType.SelectedValue == "" || ddlPriceType.SelectedValue == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlertItemTypeName();", true);
                }
                else if (ddlItemTypeList.SelectedValue == "Select" || ddlItemTypeList.SelectedValue == "" || ddlItemTypeList.SelectedValue == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlertItemTypeName();", true);
                }
                else if (ddlItemList.SelectedValue == "0" || ddlItemList.SelectedValue == "" || ddlItemList.SelectedValue == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlertItem();", true);
                }
                else if (txtItemWiseBillingInPercentage.Text == "" || txtItemWiseBillingInPercentage.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlertItemBilling();", true);
                }
                else if (txtItemWiseDiscountInPercentage.Text == "" || txtItemWiseDiscountInPercentage.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlertItemDiscount();", true);
                }
          
                else if (txtItemQuantity.Text == "0" || txtItemQuantity.Text == "" || txtItemQuantity.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlertItemQuantity();", true);
                }
                else if (txtItemWisePrice.Text == "0" || txtItemWisePrice.Text == "" || txtItemWisePrice.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlertItemMRP();", true);
                }
                else
                {
                    

                    if (_bindSaleItemStatus == true)
                    {
                        createtable();
                    }
                    else
                    {
                        createtable();
                    }

                }
                

            }
            catch(Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            
        }


        protected void rptrItems_ItemCommand(object source, RepeaterCommandEventArgs e)
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

                        //string url = "add-employee/" + App.Core.DataSecurity.Encryptdata(id).ToString();

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
                        if (_isDeletePermission == true)
                        {
                            deleteRowfromtable(Convert.ToInt32(hdfditemId.Value));
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showDeletePermissionAlert();", true);
                        }
                        

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;

            }
        }

        protected void txtToughDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtToughDiscount.Text == "" || txtToughDiscount.Text == null)
                {
                    txtToughDiscount.Text = "0";
                    txtToughDiscount.Focus();
                }
                
                    int _temporyToughDiscountAmount = _lblToughDiscountAmount;
                    Decimal _DiffrenceVale = (Convert.ToDecimal(txtToughDiscount.Text) * Convert.ToDecimal(_temporyToughDiscountAmount) / 100);
                    lblToughDiscountAmount.Text = (Convert.ToDecimal( _temporyToughDiscountAmount)-Convert.ToDecimal(_DiffrenceVale)).ToString();

                _totalAmount = (Convert.ToDecimal(_netRate) + Convert.ToDecimal(lblToughDiscountAmount.Text) + Convert.ToDecimal(lblLamiDiscountAmount.Text == "" ? 0 : Convert.ToDecimal(lblLamiDiscountAmount.Text)));

                    lblToughBillingPercentageAmount.Text = (Convert.ToDecimal(txtToughBillingPercentage.Text) * Convert.ToDecimal(lblToughDiscountAmount.Text) / 100).ToString();
                    lblLamiBillingPercentageAmount.Text = (Convert.ToDecimal(txtLamiBillingPercentage.Text) * Convert.ToDecimal(lblLamiDiscountAmount.Text == "" ? 0 : Convert.ToDecimal(lblLamiDiscountAmount.Text)) / 100).ToString();
                    lblnetRateBillingPercentageAmount.Text = (Convert.ToDecimal(txtNetRateBillingPercentage.Text == "" ? 0 : Convert.ToDecimal(txtNetRateBillingPercentage.Text)) * Convert.ToDecimal(_netRate) / 100).ToString();

                    txtTotalAmount.Text = (Convert.ToDecimal(_totalAmount)).ToString();

                    txtBillAmount.Text = (Convert.ToDecimal(lblToughBillingPercentageAmount.Text) + Convert.ToDecimal(lblLamiBillingPercentageAmount.Text) + Convert.ToDecimal(lblnetRateBillingPercentageAmount.Text)).ToString();

                    txtTotalCash.Text = (Convert.ToDecimal(txtTotalAmount.Text) - Convert.ToDecimal(txtBillAmount.Text)).ToString();

               

            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }
        }

        protected void txtToughBillingPercentage_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if ( txtToughBillingPercentage.Text == "" || txtToughBillingPercentage.Text == null)
                {
                    txtToughBillingPercentage.Text = "0";
                    txtToughBillingPercentage.Focus();
                }
              
                    int _temporyToughDiscountAmount = _lblToughDiscountAmount;
                    Decimal _DiffrenceVale = (Convert.ToDecimal(txtToughDiscount.Text) * Convert.ToDecimal(_temporyToughDiscountAmount) / 100);
                    lblToughDiscountAmount.Text = (Convert.ToDecimal(_temporyToughDiscountAmount) - Convert.ToDecimal(_DiffrenceVale)).ToString();
                _totalAmount = (Convert.ToDecimal(_netRate) + Convert.ToDecimal(lblToughDiscountAmount.Text) + Convert.ToDecimal(lblLamiDiscountAmount.Text == "" ? 0 : Convert.ToDecimal(lblLamiDiscountAmount.Text)));

                lblToughBillingPercentageAmount.Text = (Convert.ToDecimal(txtToughBillingPercentage.Text) * Convert.ToDecimal(lblToughDiscountAmount.Text) / 100).ToString();
                    lblLamiBillingPercentageAmount.Text = (Convert.ToDecimal(txtLamiBillingPercentage.Text) * Convert.ToDecimal(lblLamiDiscountAmount.Text == "" ? 0 : Convert.ToDecimal(lblLamiDiscountAmount.Text)) / 100).ToString();
                    lblnetRateBillingPercentageAmount.Text = (Convert.ToDecimal(txtNetRateBillingPercentage.Text == "" ? 0 : Convert.ToDecimal(txtNetRateBillingPercentage.Text)) * Convert.ToDecimal(_netRate) / 100).ToString();

                    txtTotalAmount.Text = (Convert.ToDecimal(_totalAmount)).ToString();

                    txtBillAmount.Text = (Convert.ToDecimal(lblToughBillingPercentageAmount.Text) + Convert.ToDecimal(lblLamiBillingPercentageAmount.Text) + Convert.ToDecimal(lblnetRateBillingPercentageAmount.Text)).ToString();

                    txtTotalCash.Text = (Convert.ToDecimal(txtTotalAmount.Text) - Convert.ToDecimal(txtBillAmount.Text)).ToString();

               
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        protected void btnResetConfirm_Click(object sender, EventArgs e)
        {
            btnConfirmAndSubmit.Visible = false;
            _isDeletePermission = true;
            btnAddItem.Visible = true;
            btnResetPartyDetails.Visible = true;
        }

        protected void btnResetPartyDetails_Click(object sender, EventArgs e)
        {
            try
            {
                txtNetRate.Text = txtItemQuantity.Text = txtItemWiseBillingInPercentage.Text = txtItemWiseDiscountInPercentage.Text = txtFinalItemAmount.Text = "0";
                ddlPartyName.Enabled = true;
                ddlItemList.SelectedIndex = 0;

            }
            catch(Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
        }

        protected void ddlItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlItemTypeList.SelectedIndex > 0)
                {
                    _objItemMasterBL = new ItemMasterBL();


                    _objItemMaster = _objItemMasterBL.GetItemMasterItemsByID(Convert.ToInt32(ddlItemList.SelectedValue)).FirstOrDefault();

                    if (_objItemMaster != null)
                    {
                        if (_objItemMaster.item_master_id > 0)
                        {
                            lblItemWiseGstinPercentage.Text = _objItemMaster.gst_rate;
                            if(ddlPriceType.Text == "10G")
                            {
                                txtItemWisePrice.Text = _objItemMaster.price;                                                                                           
                            }
                            if(ddlPriceType.Text == "11G")
                            {
                                txtItemWisePrice.Text = _objItemMaster.price_2;
                            }
                           
                            lblItemWisePrice.Text = _objItemMaster.price;
                            lblItemWisePrice2.Text = _objItemMaster.price_2;
                            lblItemWiseWeight.Text = _objItemMaster.item_weight;

                            txtItemWiseDiscountInPercentage.Text = txtFixedDiscountinPercentage.Text =="" ? "0": txtFixedDiscountinPercentage.Text;
                            txtItemWiseBillingInPercentage.Text = txtFixedBillingInPercentage.Text == "" ? "0" : txtFixedBillingInPercentage.Text;

                            try
                            {
                                Decimal _DiscountValue, BillRate, FinalItemAmount, _ItemWiseGstAmount = 0;

                                _DiscountValue = Convert.ToDecimal(txtItemWisePrice.Text) - (Convert.ToDecimal(txtItemWisePrice.Text) / 100 * Convert.ToDecimal(txtItemWiseDiscountInPercentage.Text));

                                    txtDiscountedValue.Text = _DiscountValue.ToString();

                                BillRate = (Convert.ToDecimal(txtDiscountedValue.Text) / 100) * Convert.ToDecimal(txtItemWiseBillingInPercentage.Text);

                                _ItemWiseGstAmount = (BillRate / 100) * Convert.ToDecimal(lblItemWiseGstinPercentage.Text);

                                FinalItemAmount = Convert.ToDecimal(txtDiscountedValue.Text) + _ItemWiseGstAmount;
                                txtFinalItemAmount.Text = FinalItemAmount.ToString();

                            }
                            catch (Exception ex)
                            {
                                ex.Message.ToString();
                            }
                        }
                        else
                        {
                            ddlItemList.Enabled = false;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showNoRecordFound();", true);
                        }
                    }
                    else
                    {
                        ddlItemList.Enabled = false;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showNoRecordFound();", true);
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

        protected void ddlPriceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlItemList.SelectedIndex > 0)
                {
                    _objItemMasterBL = new ItemMasterBL();


                    _objItemMaster = _objItemMasterBL.GetItemMasterItemsByID(Convert.ToInt32(ddlItemList.SelectedValue)).FirstOrDefault();

                    if (_objItemMaster != null)
                    {
                        if (_objItemMaster.item_master_id > 0)
                        {
                           
                            if (ddlPriceType.Text == "10G")
                            {
                                txtItemWisePrice.Text = _objItemMaster.price;
                            }
                            if (ddlPriceType.Text == "11G")
                            {
                                txtItemWisePrice.Text = _objItemMaster.price_2;
                            }

                            //lblItemWisePrice.Text = _objItemMaster.price;
                            //lblItemWisePrice2.Text = _objItemMaster.price_2;
                            //lblItemWiseWeight.Text = _objItemMaster.item_weight;

                            //txtItemWiseDiscountInPercentage.Text = txtFixedDiscountinPercentage.Text == "" ? "0" : txtFixedDiscountinPercentage.Text;
                            //txtItemWiseBillingInPercentage.Text = txtFixedBillingInPercentage.Text == "" ? "0" : txtFixedBillingInPercentage.Text;

                            try
                            {
                                Decimal _DiscountValue, BillRate, FinalItemAmount, _ItemWiseGstAmount = 0;

                                _DiscountValue = Convert.ToDecimal(txtItemWisePrice.Text) - (Convert.ToDecimal(txtItemWisePrice.Text) / 100 * Convert.ToDecimal(txtItemWiseDiscountInPercentage.Text));

                                txtDiscountedValue.Text = _DiscountValue.ToString();

                                BillRate = (Convert.ToDecimal(txtDiscountedValue.Text) / 100) * Convert.ToDecimal(txtItemWiseBillingInPercentage.Text);

                                _ItemWiseGstAmount = (BillRate / 100) * Convert.ToDecimal(lblItemWiseGstinPercentage.Text);

                                FinalItemAmount = Convert.ToDecimal(txtDiscountedValue.Text) + _ItemWiseGstAmount;
                                txtFinalItemAmount.Text = FinalItemAmount.ToString();

                            }
                            catch (Exception ex)
                            {
                                ex.Message.ToString();
                            }
                        }
                        else
                        {
                            ddlItemList.Enabled = false;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showNoRecordFound();", true);
                        }
                    }
                    else
                    {
                        ddlItemList.Enabled = false;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showNoRecordFound();", true);
                    }


                }
                else
                {
                    txtItemWisePrice.Text = "0";
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }

        protected void txtItemQuantity_TextChanged(object sender, EventArgs e)
        {
           
        }

        protected void txtItemWiseDiscountInPercentage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Decimal _DiscountValue ,BillRate, FinalItemAmount, _ItemWiseGstAmount = 0;
               
                if (txtItemWiseDiscountInPercentage.Text == "" || txtItemWiseDiscountInPercentage.Text == null)
                {
                    txtItemWiseDiscountInPercentage.Focus();
                    txtItemWiseDiscountInPercentage.Text = "0";

                    _DiscountValue = Convert.ToDecimal(txtItemWisePrice.Text) - (Convert.ToDecimal(txtItemWisePrice.Text) / 100 * Convert.ToDecimal(txtItemWiseDiscountInPercentage.Text));
                    txtDiscountedValue.Text = _DiscountValue.ToString();
                }
                else
                {
                    _DiscountValue = Convert.ToDecimal(txtItemWisePrice.Text) - (Convert.ToDecimal(txtItemWisePrice.Text) / 100 * Convert.ToDecimal(txtItemWiseDiscountInPercentage.Text));
                    txtDiscountedValue.Text = _DiscountValue.ToString();

                    BillRate = (Convert.ToDecimal(txtDiscountedValue.Text) / 100) * Convert.ToDecimal(txtItemWiseBillingInPercentage.Text);

                    _ItemWiseGstAmount = (BillRate/100)* Convert.ToDecimal(lblItemWiseGstinPercentage.Text);

                    FinalItemAmount = Convert.ToDecimal(txtDiscountedValue.Text) + _ItemWiseGstAmount;
                    txtFinalItemAmount.Text = FinalItemAmount.ToString();
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        
    }

        protected void txtNetRateBillingPercentage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if ( txtNetRateBillingPercentage.Text == "" || txtNetRateBillingPercentage.Text == null)
                {
                    txtNetRateBillingPercentage.Text = "0";
                    txtNetRateBillingPercentage.Focus();
                }
               
                    int _temporyToughDiscountAmount = _lblToughDiscountAmount;
                    Decimal _DiffrenceVale = (Convert.ToDecimal(txtToughDiscount.Text) * Convert.ToDecimal(_temporyToughDiscountAmount) / 100);
                    lblToughDiscountAmount.Text = (Convert.ToDecimal(_temporyToughDiscountAmount) - Convert.ToDecimal(_DiffrenceVale)).ToString();
                _totalAmount = (Convert.ToDecimal(_netRate) + Convert.ToDecimal(lblToughDiscountAmount.Text) + Convert.ToDecimal(lblLamiDiscountAmount.Text == "" ? 0 : Convert.ToDecimal(lblLamiDiscountAmount.Text)));

                lblToughBillingPercentageAmount.Text = (Convert.ToDecimal(txtToughBillingPercentage.Text) * Convert.ToDecimal(lblToughDiscountAmount.Text) / 100).ToString();
                    lblLamiBillingPercentageAmount.Text = (Convert.ToDecimal(txtLamiBillingPercentage.Text) * Convert.ToDecimal(lblLamiDiscountAmount.Text == "" ? 0 : Convert.ToDecimal(lblLamiDiscountAmount.Text)) / 100).ToString();
                    lblnetRateBillingPercentageAmount.Text = (Convert.ToDecimal(txtNetRateBillingPercentage.Text == "" ? 0 : Convert.ToDecimal(txtNetRateBillingPercentage.Text)) * Convert.ToDecimal(_netRate) / 100).ToString();

                    txtTotalAmount.Text = (Convert.ToDecimal(_totalAmount)).ToString();

                    txtBillAmount.Text = (Convert.ToDecimal(lblToughBillingPercentageAmount.Text) + Convert.ToDecimal(lblLamiBillingPercentageAmount.Text) + Convert.ToDecimal(lblnetRateBillingPercentageAmount.Text)).ToString();

                    txtTotalCash.Text = (Convert.ToDecimal(txtTotalAmount.Text) - Convert.ToDecimal(txtBillAmount.Text)).ToString();

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        protected void rptrItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    Label lblItemBilledAmount = (Label)e.Item.FindControl("lblItemBilledAmount");
                    Label lblItemTotalAmountQtyWise = (Label)e.Item.FindControl("lblItemTotalAmountQtyWise");
                    Label lblSaleItemQuantity = (Label)e.Item.FindControl("lblSaleItemQuantity");
                   // Label lblItemWeight = (Label)e.Item.FindControl("lblItemWeight");

                    Label lblSaleItemPrice = (Label)e.Item.FindControl("lblSaleItemPrice");
                    Label lblSaleItemNetRate = (Label)e.Item.FindControl("lblSaleItemNetRate");

                    

                    Decimal _netRateAmount = Convert.ToDecimal(lblSaleItemNetRate.Text);

                    Label lblItemGst = (Label)e.Item.FindControl("lblItemGst");
                    Label lblItemBillingPercenatge = (Label)e.Item.FindControl("lblItemBillingPercenatge");


                    Decimal _Total_billed_amount = Convert.ToDecimal(lblItemBilledAmount.Text);
                    Decimal _totalItem_amount = Convert.ToDecimal(lblItemTotalAmountQtyWise.Text);
                    int _totalItem_quantity = Convert.ToInt32(lblSaleItemQuantity.Text);
                   
                    //Decimal _totalItem_weight = Convert.ToDecimal(lblItemWeight.Text);



                    int _gstPercentage = 0;
                    _gstPercentage = Convert.ToInt32(lblItemGst.Text);
                    Decimal _gstAmount_Item_wise = Convert.ToDecimal(_Total_billed_amount / 100 * Convert.ToDecimal(_gstPercentage));

                    // _gstPercentage = Convert.ToInt32((_totalGst_amount * 100) / _Total_billed_amount);

                    _SaleRptrBillAmountBeforeGST = _SaleRptrBillAmountBeforeGST + _Total_billed_amount;
                    _SaleRptrTotalItemAmountBeforeGST = _SaleRptrTotalItemAmountBeforeGST + _totalItem_amount;
                    _SaleRptrTotalItemQuantity = _SaleRptrTotalItemQuantity + _totalItem_quantity;
                   // _SaleRptrTotalItemWeight = _SaleRptrTotalItemWeight + _totalItem_weight;
                    _SaleRptrTotalGSTAmount = _SaleRptrTotalGSTAmount + _gstAmount_Item_wise;


                    if (_netRateAmount > 0)
                    {
                        _SaleRptrNetRate = _SaleRptrNetRate + _netRateAmount;
                        _SaleRptrNetRateBillPercentageAmount = _SaleRptrNetRateBillPercentageAmount + (_netRateAmount * Convert.ToDecimal(lblItemBillingPercenatge.Text)) / 100;
                    }
                    else
                    {
                        _SaleRptrNormalItemAmount = _SaleRptrNormalItemAmount + Convert.ToDecimal(lblSaleItemPrice.Text);

                    }



                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "notification('Something went wrong','danger');", true);
            }
        }

        /// <summary>
        /// This Method Is Used to Bind Table Footer Data
        /// </summary>
        private void BindTableFooterChallanItemData()
        {

            Control FooterTemplate = rptrItems.Controls[rptrItems.Controls.Count - 1].Controls[0];


            Label lblTotalBillAmount = FooterTemplate.FindControl("lblTotalBillAmount") as Label;
            Label lblTotalItemAmount = FooterTemplate.FindControl("lblTotalItemAmount") as Label;
            Label lblTotalActualQuantity = FooterTemplate.FindControl("lblTotalActualQuantity") as Label;
            Label lblTotalItemWeight = FooterTemplate.FindControl("lblTotalItemWeight") as Label;

            Label lblTotalGstAmount = FooterTemplate.FindControl("lblTotalGstAmount") as Label;
            Label lblBillingGSTAmount = FooterTemplate.FindControl("lblBillingGSTAmount") as Label;

            Label lblSaleTotalAmount = FooterTemplate.FindControl("lblSaleTotalAmount") as Label;
            Label lblSaleBillAmount = FooterTemplate.FindControl("lblSaleBillAmount") as Label;
            Label lblSaleCashAmount = FooterTemplate.FindControl("lblSaleCashAmount") as Label;


            lblTotalBillAmount.Text = _SaleRptrBillAmountBeforeGST.ToString();
            lblTotalItemAmount.Text = _SaleRptrTotalItemAmountBeforeGST.ToString();
            lblTotalActualQuantity.Text = _SaleRptrTotalItemQuantity.ToString();
            lblTotalItemWeight.Text = _SaleRptrTotalItemWeight.ToString();

            lblBillingGSTAmount.Text = _SaleRptrTotalGSTAmount.ToString();
            lblTotalGstAmount.Text = _SaleRptrTotalGSTAmount.ToString();

            lblSaleTotalAmount.Text = Math.Round(_SaleRptrTotalItemAmountBeforeGST + _SaleRptrTotalGSTAmount).ToString();
            _SaleRptrTotalAmountAfterGST = Convert.ToDecimal(lblSaleTotalAmount.Text);

            lblSaleBillAmount.Text = Math.Round(_SaleRptrBillAmountBeforeGST + _SaleRptrTotalGSTAmount).ToString();
            _SaleRptrBillAmountAfterGST = Convert.ToDecimal(lblSaleBillAmount.Text);

            lblSaleCashAmount.Text = Math.Round(_SaleRptrTotalAmountAfterGST - _SaleRptrBillAmountAfterGST).ToString();
            _SaleRptrTotalCashAmount = Convert.ToDecimal(lblSaleCashAmount.Text);

            txtTotalAmount.Text = _SaleRptrTotalAmountAfterGST.ToString();
            txtBillAmount.Text = _SaleRptrBillAmountAfterGST.ToString();
            txtTotalCash.Text = _SaleRptrTotalCashAmount.ToString();


        }


        protected void ddlItemTypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlItemTypeList.SelectedIndex > 0)
            {
                _objItemMasterBL = new ItemMasterBL();


                _lstvwItemListWithModelAndGlassColor = _objItemMasterBL.GetVwItemListWithModelAndGlassColors().Where(x => x.category == ddlItemTypeList.SelectedItem.Text).ToList();

                if (_lstvwItemListWithModelAndGlassColor!=null)
                {
                    if (_lstvwItemListWithModelAndGlassColor.Count > 0)
                    {

                        ddlItemList.DataSource = _lstvwItemListWithModelAndGlassColor;
                        ddlItemList.DataTextField = "modelwithglass";
                        ddlItemList.DataValueField = "item_master_id";
                        ddlItemList.DataBind();
                        ddlItemList.Items.Insert(0, new ListItem("Select", "Select"));
                        ddlItemList.Enabled = true;
                    }
                    else
                    {
                        ddlItemList.Enabled = false;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showNoRecordFound();", true);
                    }
                }
                else
                {
                    ddlItemList.Enabled = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showNoRecordFound();", true);
                }
               

            }
            else
            {

            }
        }

        protected void btnConfirmAndSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["Row"] != null)
                {
                   

                    if (ddlPartyName.SelectedValue == "Select" || ddlPartyName.SelectedValue == "" || ddlPartyName.SelectedValue == null)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlertClientName();", true);
                    }
                    else
                    {
                         _objPartyMasterBL = new PartyMasterBL();
                        _objPartyMaster = _objPartyMasterBL.GetPartyMasterItemsByID(Convert.ToInt32(ddlPartyName.SelectedValue)).FirstOrDefault();

                        if(_objPartyMaster != null)
                        {

                            txtToughDiscount.Text = _objPartyMaster.tough_discount_precentage.ToString();
                            txtToughBillingPercentage.Text = _objPartyMaster.tough_billing_precentage.ToString();
                            txtLamiDiscount.Text = _objPartyMaster.lami_discount_precentage.ToString();
                            txtLamiBillingPercentage.Text = _objPartyMaster.lami_billing_precentage.ToString();
                            txtNetRateBillingPercentage.Text = _objPartyMaster.netrate_billing_precentage.ToString();
                            _dataTableItemsList = (DataTable)ViewState["Row"];

                            if (_objPartyMaster.party_master_id > 0)
                            {
                                if (_dataTableItemsList.Rows.Count > 0)
                                {   
                                     _lblToughDiscountAmount = 0;

                                    _netRate =  0;
                                    _totalAmount = 0;
                                    for (int _rowIndexPosition = 0; _rowIndexPosition < _dataTableItemsList.Rows.Count; _rowIndexPosition++)
                                    {
                                       
                                        if (Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_net_price"].ToString()) > 0)
                                        {
                                            _netRate += Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_net_price"].ToString()) * Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_quantity"].ToString());

                                        }
                                        else
                                        {
                                            _lblToughDiscountAmount += Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_price"].ToString()) * Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_quantity"].ToString());
                                        }

                                    }


                                    int _temporyToughDiscountAmount = _lblToughDiscountAmount;
                                    Decimal _DiffrenceVale = (Convert.ToDecimal(txtToughDiscount.Text) * Convert.ToDecimal(_temporyToughDiscountAmount) / 100);
                                    lblToughDiscountAmount.Text = (Convert.ToDecimal(_temporyToughDiscountAmount) - Convert.ToDecimal(_DiffrenceVale)).ToString();


                                    //lblToughDiscountAmount.Text = _lblToughDiscountAmount.ToString();

                                    lblLamiDiscountAmount.Text = "0";

                                    _totalAmount =  (Convert.ToDecimal( _netRate ) + Convert.ToDecimal(lblToughDiscountAmount.Text ) + Convert.ToDecimal( lblLamiDiscountAmount.Text == "" ? 0 : Convert.ToDecimal(lblLamiDiscountAmount.Text)));

                                    lblToughBillingPercentageAmount.Text = ( Convert.ToDecimal(txtToughBillingPercentage.Text ) * Convert.ToDecimal(lblToughDiscountAmount.Text) / 100).ToString();
                                    lblLamiBillingPercentageAmount.Text = (Convert.ToDecimal(txtLamiBillingPercentage.Text) * Convert.ToDecimal(lblLamiDiscountAmount.Text == "" ? 0 : Convert.ToDecimal(lblLamiDiscountAmount.Text)) / 100).ToString();
                                    lblnetRateBillingPercentageAmount.Text = ( Convert.ToDecimal(txtNetRateBillingPercentage.Text == "" ? 0 : Convert.ToDecimal(txtNetRateBillingPercentage.Text)) * Convert.ToDecimal(_netRate) / 100).ToString();

                                    txtTotalAmount.Text = _totalAmount.ToString();

                                    txtBillAmount.Text = (  Convert.ToDecimal(lblToughBillingPercentageAmount.Text ) + Convert.ToDecimal( lblLamiBillingPercentageAmount.Text ) + Convert.ToDecimal( lblnetRateBillingPercentageAmount.Text )).ToString();

                                    txtTotalCash.Text = (Convert.ToDecimal( txtTotalAmount.Text) - Convert.ToDecimal( txtBillAmount.Text )).ToString();

                                    btnConfirmAndSubmit.Visible = false;
                                    btnResetConfirm.Visible = false;
                                    btnAddItem.Visible = false;
                                    btnResetPartyDetails.Visible = false;
                                    _isDeletePermission = false;
                                    txtToughDiscount.ReadOnly = txtToughBillingPercentage.ReadOnly = txtLamiDiscount.ReadOnly = txtLamiBillingPercentage.ReadOnly = txtNetRateBillingPercentage.ReadOnly = false;

                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                                }


                            }
                            else
                            { }

                        }
                        else
                        { }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
        }


        public string CreateOrderNumber()
        {
            _objSaleHeaderBL = new SaleHeaderBL();

            string latestOrderNumber = _objSaleHeaderBL.GetLatestOrderNumber();
                string orderNumber = "100";
            int resultNumber = 0;

            string year = DateTime.UtcNow.AddHours(5.30).Year.ToString().Substring(2, 2);
            string day = DateTime.UtcNow.AddHours(5.30).Day.ToString("00");
            string month = DateTime.UtcNow.AddHours(5.30).Month.ToString("00");

            if (!string.IsNullOrEmpty(latestOrderNumber))
            {
                Int32 seriesNumber = Convert.ToInt32(latestOrderNumber.Substring(6, 5)) + 1;
                orderNumber = year + day + month + seriesNumber.ToString().PadLeft(5, '0');
            }
            else
            {
                Int32.TryParse(orderNumber, out resultNumber);
                orderNumber = year + day + month + resultNumber.ToString().PadLeft(5, '0');
            }
            return orderNumber;
        }
    }
}