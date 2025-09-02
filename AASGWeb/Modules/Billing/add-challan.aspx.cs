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
using System.Data;

namespace AASGWeb.Modules.Billing
{
    public partial class add_challan : System.Web.UI.Page
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

        PartyMaster _objPartyMaster = new PartyMaster();
        PartyMasterBL _objPartyMasterBL = null;
        List<PartyMaster> _lstPartyMaster = new List<PartyMaster>();

        ChallanHeader _objChallanHeader = new ChallanHeader();
        ChallanHeaderBL _objChallanHeaderBL = null;
        List<ChallanHeader> _lstChallanHeader = new List<ChallanHeader>();

        ChallanItem _objChallanItem = new ChallanItem();
        ChallanItemBL _objChallanItemBL = null;
        List<ChallanItem> _lstChallanItem = new List<ChallanItem>();

        ItemMaster _objItemMaster = new ItemMaster();
        ItemMasterBL _objItemMasterBL = null;
        List<ItemMaster> _lstItemMaster = new List<ItemMaster>();

        string UserIp = string.Empty;

        public static int _totalItemQuantity, _toughBillPercentage, _netBillingPercentage = 0;
        public static Decimal _totalGstAmount, _totalBillAmount, _totalCashAmount, _toughDiscountPercentage, _TotalItems, _TotalItemsBy28Percentage, _netRate, _totalAmount, _lblToughDiscountAmount = 0;

        DataTable _dataTableItemsList, _dataTableChallanItemsList = new DataTable();
        public static Boolean _saveBy18Percenatge, _saveBy28Percentage, _IsMultipleGstTable = false;

        public static int _totalItemActual, _totalItemActualBy28Percentage, _totalItemActualLoad, _totalItemActualLoadBy28Percentage, _totalCash, _itemGst18Percentage, _itemGst28Percentage;
        public static Decimal _ChallanRptrTotalItemAmountBeforeGST, _ChallanRptrTotalAmountAfterGST, _ChallanRptrBillAmountBeforeGST, _ChallanRptrBillAmountAfterGST, _ChallanRptrTotalGSTAmount, _ChallanRptrTotalCashAmount, _ChallanRptrTotalItemWeight, _ChallanRptrNetRate, _ChallanRptrNormalItemAmount, _ChallanRptrNetRateBillPercentage, _ChallanRptrNetRateBillPercentageAmount = 0;
        public static int _ChallanRptrTotalItemQuantity, _ChallanRptrTotalActualItemQuantity = 0;

        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                string _saleHederId, _loadingMasterId;
                if (RouteData.Values["id"] == null)
                {
                    // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "editorInit();", true);
                }
                else
                {

                    string sale_header_id = RouteData.Values["id"].ToString();
                    string loading_id = RouteData.Values["loadingid"].ToString();
                    _saleHederId = App.Core.DataSecurity.Decryptdata(sale_header_id);
                    _loadingMasterId = App.Core.DataSecurity.Decryptdata(loading_id);
                    hdfdSaleHeaderId.Value = _saleHederId;
                    hdfdLoadingMasterId.Value = _loadingMasterId;


                    if (sale_header_id == "" || sale_header_id == null)
                    {
                        Response.Redirect("/home", false);
                    }
                    else
                    {
                        divPartyDetail_first.Visible = true;
                        divSaleItemList.Visible = true;
                        divActionButtons.Visible = true;
                        _TotalItems = 0;
                        _totalItemActual = 0;
                        _totalItemActualBy28Percentage = 0;
                        _TotalItemsBy28Percentage = 0;
                        _itemGst18Percentage = 0;
                        _itemGst28Percentage = 0;
                        _ChallanRptrTotalItemAmountBeforeGST = _ChallanRptrTotalAmountAfterGST = _ChallanRptrBillAmountBeforeGST = _ChallanRptrBillAmountAfterGST = _ChallanRptrTotalGSTAmount = _ChallanRptrTotalCashAmount = _ChallanRptrTotalItemWeight = 0;
                        _ChallanRptrTotalItemQuantity = _ChallanRptrTotalActualItemQuantity = 0;
                        GetSaleOrderPartyDetails(_saleHederId);
                        BindSaleItemrptr(_saleHederId);
                        BindTableFooterData();
                        BindTableFooterFor28PercentageData();

                        BindChallanDetailrptr();

                        CreateChallanTableOnlyHeader();

                    }


                }


            }
        }


        protected void rptrSaleOrderItemsList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Label lblitemid = (Label)e.Item.FindControl("lblitemid");
                    //  Label lblItemGstPercentage = (Label)e.Item.FindControl("lblItemGstPercentage");
                    Label lblActualQuantity = (Label)e.Item.FindControl("lblActualQuantity");
                    Label lblItemWeight = (Label)e.Item.FindControl("lblItemWeight");

                    Decimal _itemWeight = Convert.ToDecimal(lblItemWeight.Text);
                    _TotalItems = _TotalItems + _itemWeight;
                    int _itemActualQuantity = Convert.ToInt32(lblActualQuantity.Text);
                    _totalItemActual = _totalItemActual + _itemActualQuantity;

                    int _itemmasterId = Convert.ToInt32(lblitemid.Text);

                    // This is Used to get Item Details for check is DFG true or false for apply GST Condition 18% or 28%
                    // lblItemGstPercentage.Text = _itemGst18Percentage.ToString();


                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "notification('Something went wrong','danger');", true);
            }
        }



        protected void rptrSaleOrderItemsList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }


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

            if (_objSaleHeaderPartyDetail != null)
            {
                hdfdPartyMasterId.Value = _objSaleHeaderPartyDetail.party_master_id.ToString();
                txtPartyName.Text = _objSaleHeaderPartyDetail.party_name;
                txtPartyAddress.Text = _objSaleHeaderPartyDetail.party_address + " , " + _objSaleHeaderPartyDetail.party_state;
                txtMobile.Text = _objSaleHeaderPartyDetail.party_phoneno;
                hdfdSaleOrderNumber.Value = _objSaleHeaderPartyDetail.order_number;

                _totalCashAmount = Convert.ToDecimal(_objSaleHeaderPartyDetail.total_amount_cash);
                _totalBillAmount = Convert.ToDecimal(_objSaleHeaderPartyDetail.total_amount_billed);
                _totalGstAmount = Convert.ToDecimal(_objSaleHeaderPartyDetail.gst_amount);

                _totalItemQuantity = _objSaleHeaderPartyDetail.total_items;
                _toughDiscountPercentage = Convert.ToDecimal(_objSaleHeaderPartyDetail.tough_discount_precentage);
                _toughBillPercentage = _objSaleHeaderPartyDetail.tough_billing_precentage;
                _netBillingPercentage = _objSaleHeaderPartyDetail.netrate_billing_precentage;

                //_toughDiscountPercentage = Convert.ToDecimal(_objSaleHeaderPartyDetail.tough_discount_precentage_party);
                //_toughBillPercentage = _objSaleHeaderPartyDetail.tough_billing_precentage_party;
                //_netBillingPercentage = _objSaleHeaderPartyDetail.netrate_billing_precentage_party;


                //txtToughDiscount.Text = (Convert.ToInt32( _toughDiscountPercentage)).ToString();
                //txtToughBillingPercentage.Text = _toughBillPercentage.ToString();
                //txtLamiDiscount.Text = _objSaleHeaderPartyDetail.lami_discount_precentage.ToString();
                //txtLamiBillingPercentage.Text = _objSaleHeaderPartyDetail.lami_billing_precentage.ToString();
                //txtNetRateBillingPercentage.Text = _netBillingPercentage.ToString();

                //txtTotalCash.Text = _totalCashAmount.ToString();
                //txtBillAmount.Text = _totalBillAmount.ToString();
                //txtTotalAmount.Text = _objSaleHeaderPartyDetail.total_amount.ToString();

                txtToughDiscount.Text = (Convert.ToInt32(0)).ToString();
                txtToughBillingPercentage.Text = "0";
                txtLamiDiscount.Text = "0";
                txtLamiBillingPercentage.Text = "0";
                txtNetRateBillingPercentage.Text = "0";

                txtTotalCash.Text = "0";
                txtBillAmount.Text = "0";
                txtTotalAmount.Text = "0";
            }

        }



        protected void rptrChallanHeaderList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                string commandname = e.CommandName;
                string id = e.CommandArgument.ToString();


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
                            // string url = "/challan-print/" + App.Core.DataSecurity.Encryptdata(id).ToString();
                            string url = "/challan-print/" + App.Core.DataSecurity.Encryptdata(hdfdSaleHeaderId.Value).ToString() + "/" + App.Core.DataSecurity.Encryptdata(id).ToString();
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
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        protected void rptrChallanHeaderList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    Label lblTotalBillAmount = (Label)e.Item.FindControl("lblTotalBillAmount");
                    Label lblGstAmount = (Label)e.Item.FindControl("lblGstAmount");
                    Label lblGst = (Label)e.Item.FindControl("lblGst");

                    Decimal _Total_billed_amount = Convert.ToDecimal(lblTotalBillAmount.Text);
                    Decimal _totalGst_amount = Convert.ToDecimal(lblGstAmount.Text);
                    //int _gstPercentage = 0; 

                    //_gstPercentage = Convert.ToInt32( (_totalGst_amount * 100) / _Total_billed_amount);

                    //lblGst.Text = _gstPercentage.ToString();

                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "notification('Something went wrong','danger');", true);
            }
        }

        protected void btnConfirmAndSubmitGst28Percentage_Click(object sender, EventArgs e)
        {
            try
            {
                GetRepeaterItemValuesBy28Percentage();

                if (ViewState["RowBy28"] != null)
                {
                    if (hdfdPartyMasterId.Value == "" || hdfdPartyMasterId.Value == null)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlertClientName();", true);
                    }
                    else
                    {
                        _dataTableItemsList = (DataTable)ViewState["RowBy28"];

                        if (_dataTableItemsList.Rows.Count > 0)
                        {
                            _lblToughDiscountAmount = 0;

                            txtToughDiscount.Text = (Convert.ToInt32(_toughDiscountPercentage)).ToString();
                            txtToughBillingPercentage.Text = _toughBillPercentage.ToString();
                            txtNetRateBillingPercentage.Text = _netBillingPercentage.ToString();
                            txtTotalCash.Text = _totalCashAmount.ToString();
                            txtBillAmount.Text = _totalBillAmount.ToString();

                            _netRate = 0;
                            _totalAmount = 0;
                            for (int _rowIndexPosition = 0; _rowIndexPosition < _dataTableItemsList.Rows.Count; _rowIndexPosition++)
                            {

                                if (Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_net_price"].ToString()) > 0)
                                {
                                    _netRate += Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_net_price"].ToString()) * Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_quantity_actual_load"].ToString());

                                }
                                else
                                {
                                    _lblToughDiscountAmount += Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_price"].ToString()) * Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_quantity_actual_load"].ToString());
                                }

                            }


                            Decimal _temporyToughDiscountAmount = _lblToughDiscountAmount;
                            Decimal _DiffrenceVale = (Convert.ToDecimal(txtToughDiscount.Text) * Convert.ToDecimal(_temporyToughDiscountAmount) / 100);
                            lblToughDiscountAmount.Text = (Convert.ToDecimal(_temporyToughDiscountAmount) - Convert.ToDecimal(_DiffrenceVale)).ToString();


                            //lblToughDiscountAmount.Text = _lblToughDiscountAmount.ToString();

                            lblLamiDiscountAmount.Text = "0";

                            _totalAmount = (Convert.ToDecimal(_netRate) + Convert.ToDecimal(lblToughDiscountAmount.Text) + Convert.ToDecimal(lblLamiDiscountAmount.Text == "" ? 0 : Convert.ToDecimal(lblLamiDiscountAmount.Text)));

                            lblToughBillingPercentageAmount.Text = (Convert.ToDecimal(txtToughBillingPercentage.Text) * Convert.ToDecimal(lblToughDiscountAmount.Text) / 100).ToString();
                            lblLamiBillingPercentageAmount.Text = (Convert.ToDecimal(txtLamiBillingPercentage.Text) * Convert.ToDecimal(lblLamiDiscountAmount.Text == "" ? 0 : Convert.ToDecimal(lblLamiDiscountAmount.Text)) / 100).ToString();
                            lblnetRateBillingPercentageAmount.Text = (Convert.ToDecimal(txtNetRateBillingPercentage.Text == "" ? 0 : Convert.ToDecimal(txtNetRateBillingPercentage.Text)) * Convert.ToDecimal(_netRate) / 100).ToString();

                            txtTotalAmount.Text = _totalAmount.ToString();

                            txtBillAmount.Text = (Convert.ToDecimal(lblToughBillingPercentageAmount.Text) + Convert.ToDecimal(lblLamiBillingPercentageAmount.Text) + Convert.ToDecimal(lblnetRateBillingPercentageAmount.Text)).ToString();

                            txtTotalCash.Text = (Convert.ToDecimal(txtTotalAmount.Text) - Convert.ToDecimal(txtBillAmount.Text)).ToString();

                            btnConfirmAndSubmit.Visible = false;
                            btnResetConfirm.Visible = true;
                            txtToughDiscount.ReadOnly = txtToughBillingPercentage.ReadOnly = txtLamiDiscount.ReadOnly = txtLamiBillingPercentage.ReadOnly = txtNetRateBillingPercentage.ReadOnly = false;

                            _saveBy18Percenatge = false;
                            _saveBy28Percentage = true;
                            btnConfirmAndSubmitGst28Percentage.Visible = false;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showError();", true);
                        }
                        //_objPartyMasterBL = new PartyMasterBL();
                        //_objPartyMaster = _objPartyMasterBL.GetPartyMasterItemsByID(Convert.ToInt32(hdfdPartyMasterId.Value)).FirstOrDefault();

                        //if (_objPartyMaster != null)
                        //{
                        //    txtToughDiscount.Text = _objPartyMaster.tough_discount_precentage.ToString();
                        //    txtToughBillingPercentage.Text = _objPartyMaster.tough_billing_precentage.ToString();
                        //    txtLamiDiscount.Text = _objPartyMaster.lami_discount_precentage.ToString();
                        //    txtLamiBillingPercentage.Text = _objPartyMaster.lami_billing_precentage.ToString();
                        //    txtNetRateBillingPercentage.Text = _objPartyMaster.netrate_billing_precentage.ToString();


                        //    if (_objPartyMaster.party_master_id > 0)
                        //    {

                        //    }
                        //    else
                        //    { }

                        //}
                        //else
                        //{ }
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

        protected void btnAddMultipleGSTTable_Click(object sender, EventArgs e)
        {
            try
            {
                _IsMultipleGstTable = true;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        protected void btnResetGst28Percentage_Click(object sender, EventArgs e)
        {
            try
            {
                // btnConfirmAndSubmitGst28Percentage.Visible = true;
                _saveBy28Percentage = false;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        protected void chkChallanItem_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlItemWiseGst.SelectedValue == "Select" || ddlItemWiseGst.SelectedValue == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showError();", true);
                }
                else if (txtItemWiseDiscount.Text == "" || txtItemWiseDiscount.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showError();", true);
                }
                else if (ddlItemWiseBill.SelectedValue == "Select" || ddlItemWiseBill.SelectedValue == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showError();", true);
                }
                else
                {
                    CreateTableforRptrChallanItem();


                }


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }



        #endregion

        #region
        private void BindSaleItemrptr(string _saleOrderId)
        {
            Int32 _SaleHeader_id = Convert.ToInt32(_saleOrderId);
            _objSaleItemBL = new SaleItemBL();
            _lstSaleItem = _objSaleItemBL.GetAllSaleItemItems().Where(x => x.sale_header_id == _SaleHeader_id).OrderBy(x => x.sale_item_net_price).ToList();//   _objsp_GetSaleDetail_Result = _objsp_GetSaleDetail_ResultBL.GetAllsp_GetSaleDetail_ResultItems().Where(x => x.sale_header_id == Convert.ToInt32(saleid)).FirstOrDefault();

            if (_lstSaleItem != null)
            {
                #region
                //List<SaleItem> _lstSaleItemWithPercetageAndWeight = new List<SaleItem>();

                //for (int _indexposition = 0; _indexposition < _lstSaleItem.Count; _indexposition++)
                //{
                //    _objItemMasterBL = new ItemMasterBL();
                //    _objItemMaster = _objItemMasterBL.GetItemMasterItemsByID(_lstSaleItem[_indexposition].item_master_id).FirstOrDefault();
                //    if (_objItemMaster != null)
                //    {
                //            SaleItem _objSaleItemWithGst18Percetage = new SaleItem();

                //            _objSaleItemWithGst18Percetage.sale_item_id = _lstSaleItem[_indexposition].sale_item_id;
                //            _objSaleItemWithGst18Percetage.guid = _lstSaleItem[_indexposition].guid;
                //            _objSaleItemWithGst18Percetage.sale_header_id = _lstSaleItem[_indexposition].sale_header_id;
                //            _objSaleItemWithGst18Percetage.item_master_id = _lstSaleItem[_indexposition].item_master_id;
                //            _objSaleItemWithGst18Percetage.party_master_id = _lstSaleItem[_indexposition].party_master_id;
                //            _objSaleItemWithGst18Percetage.sale_item_type_id = _lstSaleItem[_indexposition].sale_item_type_id;
                //            _objSaleItemWithGst18Percetage.sale_item_type_title = _lstSaleItem[_indexposition].sale_item_type_title;
                //            _objSaleItemWithGst18Percetage.sale_item_name = _lstSaleItem[_indexposition].sale_item_name;
                //            _objSaleItemWithGst18Percetage.sale_item_quantity = _lstSaleItem[_indexposition].sale_item_quantity;
                //            _objSaleItemWithGst18Percetage.sale_item_price = _lstSaleItem[_indexposition].sale_item_price;
                //            _objSaleItemWithGst18Percetage.sale_item_price_2 = _lstSaleItem[_indexposition].sale_item_price_2;
                //            _objSaleItemWithGst18Percetage.sale_item_net_price = _lstSaleItem[_indexposition].sale_item_net_price;

                //            if (_lstSaleItem[_indexposition].item_weight > 0)
                //            {
                //                _objSaleItemWithGst18Percetage.item_weight = _lstSaleItem[_indexposition].item_weight;
                //            }
                //            else
                //            {
                //                _objSaleItemWithGst18Percetage.item_weight = Convert.ToDecimal(_objItemMaster.item_weight);
                //            }

                //            _objSaleItemWithGst18Percetage.created_on = _lstSaleItem[_indexposition].created_on;
                //            _objSaleItemWithGst18Percetage.created_by = _lstSaleItem[_indexposition].created_by;
                //            _objSaleItemWithGst18Percetage.modified_on = _lstSaleItem[_indexposition].modified_on;
                //            _objSaleItemWithGst18Percetage.modified_by = _lstSaleItem[_indexposition].modified_by;
                //            _objSaleItemWithGst18Percetage.user_ip = _lstSaleItem[_indexposition].user_ip;
                //            _objSaleItemWithGst18Percetage.is_active = _lstSaleItem[_indexposition].is_active;

                //            _lstSaleItemWithPercetageAndWeight.Add(_objSaleItemWithGst18Percetage);

                //    }
                //    else
                //    {

                //    }
                //}

                #endregion

                rptrSaleOrderItemsList.DataSource = _lstSaleItem;
                rptrSaleOrderItemsList.DataBind();

            }
            else
            {

            }


            #region This code is Used to Seprate Item GST Percentage Wise like (18% and 28%)
            //List<SaleItem> _lstSaleItemWithGst18Percetage = new List<SaleItem>();

            //List<SaleItem> _lstSaleItemWithGst28Percetage = new List<SaleItem>();

            //for (int _indexposition = 0; _indexposition < _lstSaleItem.Count; _indexposition++)
            //{
            //    _objItemMasterBL = new ItemMasterBL();
            //    _objItemMaster = _objItemMasterBL.GetItemMasterItemsByID(_lstSaleItem[_indexposition].item_master_id).FirstOrDefault();
            //    if (_objItemMaster != null)
            //    {


            //        if (_objItemMaster.is_dfg_paint == true)
            //        {
            //            SaleItem _objSaleItemWithGst28Percetage = new SaleItem();
            //            _itemGst28Percentage = 28;
            //            _objSaleItemWithGst28Percetage.sale_item_id = _lstSaleItem[_indexposition].sale_item_id;
            //            _objSaleItemWithGst28Percetage.guid = _lstSaleItem[_indexposition].guid;
            //            _objSaleItemWithGst28Percetage.sale_header_id = _lstSaleItem[_indexposition].sale_header_id;
            //            _objSaleItemWithGst28Percetage.item_master_id = _lstSaleItem[_indexposition].item_master_id;
            //            _objSaleItemWithGst28Percetage.party_master_id = _lstSaleItem[_indexposition].party_master_id;
            //            _objSaleItemWithGst28Percetage.sale_item_type_id = _lstSaleItem[_indexposition].sale_item_type_id;
            //            _objSaleItemWithGst28Percetage.sale_item_type_title = _lstSaleItem[_indexposition].sale_item_type_title;
            //            _objSaleItemWithGst28Percetage.sale_item_name = _lstSaleItem[_indexposition].sale_item_name;
            //            _objSaleItemWithGst28Percetage.sale_item_quantity = _lstSaleItem[_indexposition].sale_item_quantity;
            //            _objSaleItemWithGst28Percetage.sale_item_price = _lstSaleItem[_indexposition].sale_item_price;
            //            _objSaleItemWithGst28Percetage.sale_item_price_2 = _lstSaleItem[_indexposition].sale_item_price_2;
            //            _objSaleItemWithGst28Percetage.sale_item_net_price = _lstSaleItem[_indexposition].sale_item_net_price;

            //            if (_lstSaleItem[_indexposition].item_weight > 0)
            //            {
            //                _objSaleItemWithGst28Percetage.item_weight = _lstSaleItem[_indexposition].item_weight;
            //            }
            //            else
            //            {
            //                _objSaleItemWithGst28Percetage.item_weight = Convert.ToDecimal(_objItemMaster.item_weight);
            //            }
            //            _objSaleItemWithGst28Percetage.created_on = _lstSaleItem[_indexposition].created_on;
            //            _objSaleItemWithGst28Percetage.created_by = _lstSaleItem[_indexposition].created_by;
            //            _objSaleItemWithGst28Percetage.modified_on = _lstSaleItem[_indexposition].modified_on;
            //            _objSaleItemWithGst28Percetage.modified_by = _lstSaleItem[_indexposition].modified_by;
            //            _objSaleItemWithGst28Percetage.user_ip = _lstSaleItem[_indexposition].user_ip;
            //            _objSaleItemWithGst28Percetage.is_active = _lstSaleItem[_indexposition].is_active;


            //            _lstSaleItemWithGst28Percetage.Add(_objSaleItemWithGst28Percetage);
            //        }
            //        else
            //        {
            //            SaleItem _objSaleItemWithGst18Percetage = new SaleItem();
            //            _itemGst18Percentage = 18;


            //            _objSaleItemWithGst18Percetage.sale_item_id = _lstSaleItem[_indexposition].sale_item_id;
            //            _objSaleItemWithGst18Percetage.guid = _lstSaleItem[_indexposition].guid;
            //            _objSaleItemWithGst18Percetage.sale_header_id = _lstSaleItem[_indexposition].sale_header_id;
            //            _objSaleItemWithGst18Percetage.item_master_id = _lstSaleItem[_indexposition].item_master_id;
            //            _objSaleItemWithGst18Percetage.party_master_id = _lstSaleItem[_indexposition].party_master_id;
            //            _objSaleItemWithGst18Percetage.sale_item_type_id = _lstSaleItem[_indexposition].sale_item_type_id;
            //            _objSaleItemWithGst18Percetage.sale_item_type_title = _lstSaleItem[_indexposition].sale_item_type_title;
            //            _objSaleItemWithGst18Percetage.sale_item_name = _lstSaleItem[_indexposition].sale_item_name;
            //            _objSaleItemWithGst18Percetage.sale_item_quantity = _lstSaleItem[_indexposition].sale_item_quantity;
            //            _objSaleItemWithGst18Percetage.sale_item_price = _lstSaleItem[_indexposition].sale_item_price;
            //            _objSaleItemWithGst18Percetage.sale_item_price_2 = _lstSaleItem[_indexposition].sale_item_price_2;
            //            _objSaleItemWithGst18Percetage.sale_item_net_price = _lstSaleItem[_indexposition].sale_item_net_price;

            //            if (_lstSaleItem[_indexposition].item_weight > 0)
            //            {
            //                _objSaleItemWithGst18Percetage.item_weight = _lstSaleItem[_indexposition].item_weight;
            //            }
            //            else
            //            {
            //                _objSaleItemWithGst18Percetage.item_weight = Convert.ToDecimal(_objItemMaster.item_weight);
            //            }

            //            _objSaleItemWithGst18Percetage.created_on = _lstSaleItem[_indexposition].created_on;
            //            _objSaleItemWithGst18Percetage.created_by = _lstSaleItem[_indexposition].created_by;
            //            _objSaleItemWithGst18Percetage.modified_on = _lstSaleItem[_indexposition].modified_on;
            //            _objSaleItemWithGst18Percetage.modified_by = _lstSaleItem[_indexposition].modified_by;
            //            _objSaleItemWithGst18Percetage.user_ip = _lstSaleItem[_indexposition].user_ip;
            //            _objSaleItemWithGst18Percetage.is_active = _lstSaleItem[_indexposition].is_active;

            //            _lstSaleItemWithGst18Percetage.Add(_objSaleItemWithGst18Percetage);
            //        }
            //    }
            //    else
            //    {

            //    }
            //}

            //rptrSaleOrderItemsList.DataSource = _lstSaleItemWithGst18Percetage;
            //rptrSaleOrderItemsList.DataBind();

            //if (_lstSaleItemWithGst28Percetage != null)
            //{
            //    if (_lstSaleItemWithGst28Percetage.Count > 0)
            //    {
            //        divSaleItemwithGSt28Percentage.Visible = true;
            //        rptrSaleOrderItemGst28Percentage.DataSource = _lstSaleItemWithGst28Percetage;
            //        rptrSaleOrderItemGst28Percentage.DataBind();
            //    }
            //    else
            //    {
            //        divSecondRepeaterActionButton.Visible = false;
            //    }

            //}
            //else
            //{
            //    divSecondRepeaterActionButton.Visible = false;
            //}

            #endregion

            //  _objSaleItem = _lstSaleItem.Where(x => x.sale_header_id == _SaleHeader_id).FirstOrDefault();


        }

        /// <summary>
        /// This Method Is Used to Bind Table Footer Data
        /// </summary>
        private void BindTableFooterData()
        {
            Control FooterTemplate = rptrSaleOrderItemsList.Controls[rptrSaleOrderItemsList.Controls.Count - 1].Controls[0];


            Label lblTotalItemWeight = FooterTemplate.FindControl("lblTotalItemWeight") as Label;
            Label lblTotalActualQuantity = FooterTemplate.FindControl("lblTotalActualQuantity") as Label;


            lblTotalItemWeight.Text = _TotalItems.ToString();
            lblTotalActualQuantity.Text = _totalItemActual.ToString();


        }


        /// <summary>
        /// This Method Is Used to Bind Table Footer Data
        /// </summary>
        private void BindTableFooterFor28PercentageData()
        {
            if (divSaleItemwithGSt28Percentage.Visible == true)
            {
                Control FooterTemplate = rptrSaleOrderItemGst28Percentage.Controls[rptrSaleOrderItemGst28Percentage.Controls.Count - 1].Controls[0];


                Label lblTotalItemWeight = FooterTemplate.FindControl("lblTotalItemWeight") as Label;
                Label lblTotalActualQuantity = FooterTemplate.FindControl("lblTotalActualQuantity") as Label;


                lblTotalItemWeight.Text = _TotalItemsBy28Percentage.ToString();
                lblTotalActualQuantity.Text = _totalItemActualBy28Percentage.ToString();
            }
            else
            {

            }



        }

        private void BindChallanDetailrptr()
        {
            try
            {
                List<ChallanHeader> _lstChallanHeader = new List<ChallanHeader>();
                _objChallanHeaderBL = new ChallanHeaderBL();

                _lstChallanHeader = _objChallanHeaderBL.GetChallanHeaderItemsByOrderNumber(hdfdSaleOrderNumber.Value.ToString()).ToList();

                if (_lstChallanHeader != null)
                {
                    rptrChallanHeaderList.DataSource = _lstChallanHeader;
                    rptrChallanHeaderList.DataBind();

                    if (_lstChallanHeader.Count >= 1)
                    {
                        divSaleItemList.Visible = false;
                        divSaleItemwithGSt28Percentage.Visible = false;
                        divFirstRepeaterActionButton.Visible = false;
                        divSecondRepeaterActionButton.Visible = false;
                        divActionButtons.Visible = false;
                        divDiscountandPercentage.Visible = false;
                        divTotalAmountCashBill.Visible = false;
                       
                    }
                    else
                    {
                        divDiscountandPercentage.Visible = false;
                        divSaleItemwithGSt28Percentage.Visible = false;
                        divSecondRepeaterActionButton.Visible = false;
                    }

                }
                else
                {
                    divDiscountandPercentage.Visible = false;
                    divSaleItemwithGSt28Percentage.Visible = false;
                    divSecondRepeaterActionButton.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }

        private void BindChallanDetailrptrWithoutHideOtherControl()
        {
            try
            {
                List<ChallanHeader> _lstChallanHeader = new List<ChallanHeader>();
                _objChallanHeaderBL = new ChallanHeaderBL();

                _lstChallanHeader = _objChallanHeaderBL.GetChallanHeaderItemsByOrderNumber(hdfdSaleOrderNumber.Value.ToString()).ToList();

                if (_lstChallanHeader != null)
                {
                    rptrChallanHeaderList.DataSource = _lstChallanHeader;
                    rptrChallanHeaderList.DataBind();

                    divDiscountandPercentage.Visible = false;
                    divSaleItemwithGSt28Percentage.Visible = false;
                    divSecondRepeaterActionButton.Visible = false;
                }
                else
                {
                    divDiscountandPercentage.Visible = false;
                    divSaleItemwithGSt28Percentage.Visible = false;
                    divSecondRepeaterActionButton.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }

        /// <summary>
        /// This Method Is Used to Bind Table Footer Data
        /// </summary>
        private void BindTableFooterChallanItemData()
        {

            Control FooterTemplate = rptrchallanItemList.Controls[rptrchallanItemList.Controls.Count - 1].Controls[0];


            Label lblTotalBillAmount = FooterTemplate.FindControl("lblTotalBillAmount") as Label;
            Label lblTotalItemAmount = FooterTemplate.FindControl("lblTotalItemAmount") as Label;
            Label lblTotalActualQuantity = FooterTemplate.FindControl("lblTotalActualQuantity") as Label;
            Label lblTotalItemWeight = FooterTemplate.FindControl("lblTotalItemWeight") as Label;

            Label lblTotalGstAmount = FooterTemplate.FindControl("lblTotalGstAmount") as Label;
            Label lblBillingGSTAmount = FooterTemplate.FindControl("lblBillingGSTAmount") as Label;

            Label lblChallanTotalAmount = FooterTemplate.FindControl("lblChallanTotalAmount") as Label;
            Label lblChallanBillAmount = FooterTemplate.FindControl("lblChallanBillAmount") as Label;
            Label lblChallanCashAmount = FooterTemplate.FindControl("lblChallanCashAmount") as Label;


            lblTotalBillAmount.Text = _ChallanRptrBillAmountBeforeGST.ToString();
            lblTotalItemAmount.Text = _ChallanRptrTotalItemAmountBeforeGST.ToString();
            lblTotalActualQuantity.Text = _ChallanRptrTotalItemQuantity.ToString();
            lblTotalItemWeight.Text = _ChallanRptrTotalItemWeight.ToString();

            lblBillingGSTAmount.Text = _ChallanRptrTotalGSTAmount.ToString();
            lblTotalGstAmount.Text = _ChallanRptrTotalGSTAmount.ToString();

            lblChallanTotalAmount.Text = Math.Round(_ChallanRptrTotalItemAmountBeforeGST + _ChallanRptrTotalGSTAmount).ToString();
            _ChallanRptrTotalAmountAfterGST = Convert.ToDecimal(lblChallanTotalAmount.Text);

            lblChallanBillAmount.Text = Math.Round(_ChallanRptrBillAmountBeforeGST + _ChallanRptrTotalGSTAmount).ToString();
            _ChallanRptrBillAmountAfterGST = Convert.ToDecimal(lblChallanBillAmount.Text);

            lblChallanCashAmount.Text = Math.Round(_ChallanRptrTotalAmountAfterGST - _ChallanRptrBillAmountAfterGST).ToString();
            _ChallanRptrTotalCashAmount = Convert.ToDecimal(lblChallanCashAmount.Text);

            txtTotalAmount.Text = _ChallanRptrTotalAmountAfterGST.ToString();
            txtBillAmount.Text = _ChallanRptrBillAmountAfterGST.ToString();
            txtTotalCash.Text = _ChallanRptrTotalCashAmount.ToString();

            divDiscountandPercentage.Visible = false;
            divSecondRepeaterActionButton.Visible = false;
            divTotalAmountCashBill.Visible = true;

        }

        #endregion

        #region Challan Item Repeater
        protected void rptrchallanItemList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void rptrchallanItemList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    Label lblItemBillAmount = (Label)e.Item.FindControl("lblItemBillAmount");
                    Label lblItemWiseAmount = (Label)e.Item.FindControl("lblItemWiseAmount");
                    Label lblLoadingQuantity = (Label)e.Item.FindControl("lblLoadingQuantity");
                    Label lblItemWeight = (Label)e.Item.FindControl("lblItemWeight");

                    Label lblSaleItemPrice = (Label)e.Item.FindControl("lblSaleItemPrice");
                    Label lblSaleItemNetRate = (Label)e.Item.FindControl("lblSaleItemNetRate");

                    Label lblActualQuantity = (Label)e.Item.FindControl("lblActualQuantity");

                    Decimal _netRateAmount = Convert.ToDecimal(lblSaleItemNetRate.Text);

                    Label lblItemGstPercentage = (Label)e.Item.FindControl("lblItemGstPercentage");
                    Label lblItemWiseBillPercentage = (Label)e.Item.FindControl("lblItemWiseBillPercentage");


                    Decimal _Total_billed_amount = Convert.ToDecimal(lblItemBillAmount.Text);
                    Decimal _totalItem_amount = Convert.ToDecimal(lblItemWiseAmount.Text);
                    int _totalItem_quantity = Convert.ToInt32(lblLoadingQuantity.Text);
                    int _totalActualItem_quantity = Convert.ToInt32(lblActualQuantity.Text);
                    Decimal _totalItem_weight = Convert.ToDecimal(lblItemWeight.Text);



                    int _gstPercentage = 0;
                    _gstPercentage = Convert.ToInt32(lblItemGstPercentage.Text);
                    Decimal _gstAmount_Item_wise = Convert.ToDecimal(_Total_billed_amount / 100 * Convert.ToDecimal(_gstPercentage));

                    // _gstPercentage = Convert.ToInt32((_totalGst_amount * 100) / _Total_billed_amount);

                    _ChallanRptrBillAmountBeforeGST = _ChallanRptrBillAmountBeforeGST + _Total_billed_amount;
                    _ChallanRptrTotalItemAmountBeforeGST = _ChallanRptrTotalItemAmountBeforeGST + _totalItem_amount;
                    _ChallanRptrTotalItemQuantity = _ChallanRptrTotalItemQuantity + _totalItem_quantity;
                    _ChallanRptrTotalItemWeight = _ChallanRptrTotalItemWeight + _totalItem_weight;
                    _ChallanRptrTotalGSTAmount = _ChallanRptrTotalGSTAmount + _gstAmount_Item_wise;

                    _ChallanRptrTotalActualItemQuantity = _ChallanRptrTotalActualItemQuantity + _totalActualItem_quantity;

                    if (_netRateAmount > 0)
                    {
                        _ChallanRptrNetRate = _ChallanRptrNetRate + _netRateAmount;
                        _ChallanRptrNetRateBillPercentageAmount = _ChallanRptrNetRateBillPercentageAmount + (_netRateAmount * Convert.ToDecimal(lblItemWiseBillPercentage.Text)) / 100;
                    }
                    else
                    {
                        _ChallanRptrNormalItemAmount = _ChallanRptrNormalItemAmount + Convert.ToDecimal(lblSaleItemPrice.Text);

                    }



                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "notification('Something went wrong','danger');", true);
            }

        }

        #endregion

        protected void txtToughDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtToughDiscount.Text == "" || txtToughDiscount.Text == null)
                {
                    txtToughDiscount.Text = "0";
                    txtToughDiscount.Focus();
                }

                Decimal _temporyToughDiscountAmount = _lblToughDiscountAmount;
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

        protected void txtToughBillingPercentage_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (txtToughBillingPercentage.Text == "" || txtToughBillingPercentage.Text == null)
                {
                    txtToughBillingPercentage.Text = "0";
                    txtToughBillingPercentage.Focus();
                }

                Decimal _temporyToughDiscountAmount = _lblToughDiscountAmount;
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

        protected void txtNetRateBillingPercentage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtNetRateBillingPercentage.Text == "" || txtNetRateBillingPercentage.Text == null)
                {
                    txtNetRateBillingPercentage.Text = "0";
                    txtNetRateBillingPercentage.Focus();
                }

                Decimal _temporyToughDiscountAmount = _lblToughDiscountAmount;
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


        #region

        /// <summary>
        /// This Method is Used To get Repeater All Rows ( All fields Value)
        /// </summary>
        public void GetRepeaterItemValues()
        {
            try
            {
                _totalItemActualLoad = 0;

                _dataTableItemsList = new DataTable();
                _dataTableItemsList.Columns.Add("sale_item_type_id", typeof(int));
                _dataTableItemsList.Columns.Add("sale_item_type_title", typeof(string));
                _dataTableItemsList.Columns.Add("item_master_id", typeof(int));
                _dataTableItemsList.Columns.Add("sale_item_name", typeof(string));
                _dataTableItemsList.Columns.Add("sale_item_quantity", typeof(string));
                _dataTableItemsList.Columns.Add("sale_item_net_price", typeof(Decimal));
                _dataTableItemsList.Columns.Add("sale_item_price", typeof(Decimal));
                _dataTableItemsList.Columns.Add("sale_item_price_2", typeof(Decimal));
                _dataTableItemsList.Columns.Add("sale_item_weight", typeof(Decimal));
                _dataTableItemsList.Columns.Add("sale_item_quantity_actual_load", typeof(string));

                _dataTableItemsList.Columns.Add("item_gst_percentage", typeof(int));
                _dataTableItemsList.Columns.Add("item_discount_percentage", typeof(Decimal));
                _dataTableItemsList.Columns.Add("item_bill_percentage", typeof(Decimal));
                //_dataTableItemsList.Columns.Add("item_gst_amount", typeof(Decimal));

                ViewState["Row"] = _dataTableItemsList;

                foreach (RepeaterItem item in rptrSaleOrderItemsList.Items)
                {
                    CheckBox chkChallanItem = (CheckBox)item.FindControl("chkChallanItem");
                    Label lblSaleItemTypeId = (Label)item.FindControl("lblSaleItemTypeId");
                    Label lblSaleItemTypeName = (Label)item.FindControl("lblSaleItemTypeName");
                    Label lblitemid = (Label)item.FindControl("lblitemid");
                    Label lblItemName = (Label)item.FindControl("lblItemName");
                    Label lblActualQuantity = (Label)item.FindControl("lblActualQuantity");
                    Label lblSaleItemNetRate = (Label)item.FindControl("lblSaleItemNetRate");
                    Label lblSaleItemPrice = (Label)item.FindControl("lblSaleItemPrice");
                    Label lblSaleItemPrice2 = (Label)item.FindControl("lblSaleItemPrice2");
                    Label lblItemWeight = (Label)item.FindControl("lblItemWeight");
                    TextBox txtSendQuantity = (TextBox)item.FindControl("txtSendQuantity");

                    Label lblItemGstPercentage = (Label)item.FindControl("lblItemGstPercentage");
                    Label lblItemWiseDiscountInPercentage = (Label)item.FindControl("lblItemWiseDiscountInPercentage");
                    Label lblItemWiseBillingInPercentage = (Label)item.FindControl("lblItemWiseBillingInPercentage");
                    //Label lblGstAmount = (Label)item.FindControl("lblItemWiseBillingInPercentage");


                    _dataTableItemsList = (DataTable)ViewState["Row"];
                    if (_dataTableItemsList.Rows.Count > 0)
                    {
                        //if (chkChallanItem.Checked == true)
                        //{   
                        //}

                        if (txtSendQuantity.Text == "" || txtSendQuantity.Text == null || txtSendQuantity.Text == "0")
                        {
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showError();", true);
                        }
                        else
                        {
                            DataRow _dataRowItemsList = _dataTableItemsList.NewRow();
                            _dataRowItemsList["sale_item_type_id"] = lblSaleItemTypeId.Text;
                            _dataRowItemsList["sale_item_type_title"] = lblSaleItemTypeName.Text;
                            _dataRowItemsList["item_master_id"] = lblitemid.Text;
                            _dataRowItemsList["sale_item_name"] = lblItemName.Text;
                            _dataRowItemsList["sale_item_quantity"] = lblActualQuantity.Text;
                            _dataRowItemsList["sale_item_net_price"] = lblSaleItemNetRate.Text;
                            _dataRowItemsList["sale_item_price"] = lblSaleItemPrice.Text;
                            _dataRowItemsList["sale_item_price_2"] = lblSaleItemPrice2.Text;
                            _dataRowItemsList["sale_item_weight"] = lblItemWeight.Text;
                            _dataRowItemsList["sale_item_quantity_actual_load"] = txtSendQuantity.Text;

                            _dataRowItemsList["item_gst_percentage"] = lblItemGstPercentage.Text;
                            _dataRowItemsList["item_discount_percentage"] = lblItemWiseDiscountInPercentage.Text;
                            _dataRowItemsList["item_bill_percentage"] = lblItemWiseBillingInPercentage.Text;
                            //_dataRowItemsList["item_gst_amount"] = lblItemWiseBillingInPercentage.Text;

                            _totalItemActualLoad = _totalItemActualLoad + Convert.ToInt32(txtSendQuantity.Text);

                            _dataTableItemsList.Rows.Add(_dataRowItemsList);
                            ViewState["Row"] = _dataTableItemsList;
                        }

                    }
                    else
                    {
                        //if (chkChallanItem.Checked == true)
                        //{


                        //}

                        if (txtSendQuantity.Text == "" || txtSendQuantity.Text == null || txtSendQuantity.Text == "0")
                        {
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showError();", true);
                        }
                        else
                        {
                            DataRow _dataRowItemsList = _dataTableItemsList.NewRow();

                            _dataRowItemsList["sale_item_type_id"] = lblSaleItemTypeId.Text;
                            _dataRowItemsList["sale_item_type_title"] = lblSaleItemTypeName.Text;
                            _dataRowItemsList["item_master_id"] = lblitemid.Text;
                            _dataRowItemsList["sale_item_name"] = lblItemName.Text;
                            _dataRowItemsList["sale_item_quantity"] = lblActualQuantity.Text;
                            _dataRowItemsList["sale_item_net_price"] = lblSaleItemNetRate.Text;
                            _dataRowItemsList["sale_item_price"] = lblSaleItemPrice.Text;
                            _dataRowItemsList["sale_item_price_2"] = lblSaleItemPrice2.Text;
                            _dataRowItemsList["sale_item_weight"] = lblItemWeight.Text;
                            _dataRowItemsList["sale_item_quantity_actual_load"] = txtSendQuantity.Text;


                            _dataRowItemsList["item_gst_percentage"] = lblItemGstPercentage.Text;
                            _dataRowItemsList["item_discount_percentage"] = lblItemWiseDiscountInPercentage.Text;
                            _dataRowItemsList["item_bill_percentage"] = lblItemWiseBillingInPercentage.Text;
                            //_dataRowItemsList["item_gst_amount"] = lblItemWiseBillingInPercentage.Text;

                            _totalItemActualLoad = _totalItemActualLoad + Convert.ToInt32(txtSendQuantity.Text);
                            _dataTableItemsList.Rows.Add(_dataRowItemsList);
                            ViewState["Row"] = _dataTableItemsList;
                        }


                    }


                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }



        }

        /// <summary>
        /// This Method is Used To get Repeater All Rows ( All fields Value)
        /// </summary>
        public void GetRepeaterItemValuesBy28Percentage()
        {
            try
            {
                _totalItemActualLoadBy28Percentage = 0;
                _dataTableItemsList.Columns.Add("sale_item_type_id", typeof(int));
                _dataTableItemsList.Columns.Add("sale_item_type_title", typeof(string));
                _dataTableItemsList.Columns.Add("item_master_id", typeof(int));
                _dataTableItemsList.Columns.Add("sale_item_name", typeof(string));
                _dataTableItemsList.Columns.Add("sale_item_quantity", typeof(string));
                _dataTableItemsList.Columns.Add("sale_item_net_price", typeof(Decimal));
                _dataTableItemsList.Columns.Add("sale_item_price", typeof(Decimal));
                _dataTableItemsList.Columns.Add("sale_item_price_2", typeof(Decimal));
                _dataTableItemsList.Columns.Add("sale_item_weight", typeof(Decimal));
                _dataTableItemsList.Columns.Add("sale_item_quantity_actual_load", typeof(string));
                ViewState["RowBy28"] = _dataTableItemsList;

                foreach (RepeaterItem item in rptrSaleOrderItemGst28Percentage.Items)
                {

                    Label lblSaleItemTypeId = (Label)item.FindControl("lblSaleItemTypeId");
                    Label lblSaleItemTypeName = (Label)item.FindControl("lblSaleItemTypeName");
                    Label lblitemid = (Label)item.FindControl("lblitemid");
                    Label lblItemName = (Label)item.FindControl("lblItemName");
                    Label lblActualQuantity = (Label)item.FindControl("lblActualQuantity");
                    Label lblSaleItemNetRate = (Label)item.FindControl("lblSaleItemNetRate");
                    Label lblSaleItemPrice = (Label)item.FindControl("lblSaleItemPrice");
                    Label lblSaleItemPrice2 = (Label)item.FindControl("lblSaleItemPrice2");
                    Label lblItemWeight = (Label)item.FindControl("lblItemWeight");
                    TextBox txtSendQuantity = (TextBox)item.FindControl("txtSendQuantity");


                    _dataTableItemsList = (DataTable)ViewState["RowBy28"];
                    if (_dataTableItemsList.Rows.Count > 0)
                    {

                        DataRow _dataRowItemsList = _dataTableItemsList.NewRow();
                        _dataRowItemsList["sale_item_type_id"] = lblSaleItemTypeId.Text;
                        _dataRowItemsList["sale_item_type_title"] = lblSaleItemTypeName.Text;
                        _dataRowItemsList["item_master_id"] = lblitemid.Text;
                        _dataRowItemsList["sale_item_name"] = lblItemName.Text;
                        _dataRowItemsList["sale_item_quantity"] = lblActualQuantity.Text;
                        _dataRowItemsList["sale_item_net_price"] = lblSaleItemNetRate.Text;
                        _dataRowItemsList["sale_item_price"] = lblSaleItemPrice.Text;
                        _dataRowItemsList["sale_item_price_2"] = lblSaleItemPrice2.Text;
                        _dataRowItemsList["sale_item_weight"] = lblItemWeight.Text;
                        _dataRowItemsList["sale_item_quantity_actual_load"] = txtSendQuantity.Text;

                        _totalItemActualLoadBy28Percentage = _totalItemActualLoadBy28Percentage + Convert.ToInt32(txtSendQuantity.Text);

                        _dataTableItemsList.Rows.Add(_dataRowItemsList);
                        ViewState["RowBy28"] = _dataTableItemsList;



                    }
                    else
                    {
                        DataRow _dataRowItemsList = _dataTableItemsList.NewRow();

                        _dataRowItemsList["sale_item_type_id"] = lblSaleItemTypeId.Text;
                        _dataRowItemsList["sale_item_type_title"] = lblSaleItemTypeName.Text;
                        _dataRowItemsList["item_master_id"] = lblitemid.Text;
                        _dataRowItemsList["sale_item_name"] = lblItemName.Text;
                        _dataRowItemsList["sale_item_quantity"] = lblActualQuantity.Text;
                        _dataRowItemsList["sale_item_net_price"] = lblSaleItemNetRate.Text;
                        _dataRowItemsList["sale_item_price"] = lblSaleItemPrice.Text;
                        _dataRowItemsList["sale_item_price_2"] = lblSaleItemPrice2.Text;
                        _dataRowItemsList["sale_item_weight"] = lblItemWeight.Text;
                        _dataRowItemsList["sale_item_quantity_actual_load"] = txtSendQuantity.Text;

                        _totalItemActualLoadBy28Percentage = _totalItemActualLoadBy28Percentage + Convert.ToInt32(txtSendQuantity.Text);
                        _dataTableItemsList.Rows.Add(_dataRowItemsList);
                        ViewState["RowBy28"] = _dataTableItemsList;
                    }


                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }



        }


        /// <summary>
        /// This Method is Used To get Repeater All Rows ( All fields Value)
        /// </summary>
        public void GetRepeaterChallanItemValues()
        {
            try
            {



            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }



        }

        /// <summary>
        /// This Method is Used To Create Table for Repeater Challan Item List
        /// </summary>
        public void CreateTableforRptrChallanItem()
        {
            try
            {
                GetRepeaterItemValues();


                if (ViewState["Row"] != null)
                {
                    _dataTableItemsList = (DataTable)ViewState["Row"];

                    if (_dataTableItemsList.Rows.Count > 0)
                    {
                        if (_IsMultipleGstTable == true)
                        {
                            _dataTableChallanItemsList = (DataTable)ViewState["ChallanList"];
                        }
                        else
                        {
                            CreateChallanTableOnlyHeader();
                        }
                        _ChallanRptrTotalItemAmountBeforeGST = _ChallanRptrTotalAmountAfterGST = _ChallanRptrBillAmountBeforeGST = _ChallanRptrBillAmountAfterGST = _ChallanRptrTotalGSTAmount = _ChallanRptrTotalCashAmount = _ChallanRptrTotalItemWeight = 0;
                        _ChallanRptrTotalItemQuantity = _ChallanRptrTotalActualItemQuantity = 0;

                        for (int _rowIndexPosition = 0; _rowIndexPosition < _dataTableItemsList.Rows.Count; _rowIndexPosition++)
                        {

                            DataRow _dataRowChallanItemsList = _dataTableChallanItemsList.NewRow();

                            _dataRowChallanItemsList["sale_item_type_id"] = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_type_id"]);
                            _dataRowChallanItemsList["sale_item_type_title"] = _dataTableItemsList.Rows[_rowIndexPosition]["sale_item_type_title"];
                            _dataRowChallanItemsList["item_master_id"] = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["item_master_id"]);
                            _dataRowChallanItemsList["sale_item_name"] = _dataTableItemsList.Rows[_rowIndexPosition]["sale_item_name"];
                            _dataRowChallanItemsList["item_weight"] = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_weight"]).ToString();
                            _dataRowChallanItemsList["item_gst_percentage"] = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["item_gst_percentage"]).ToString();
                            _dataRowChallanItemsList["sale_item_quantity"] = _dataTableItemsList.Rows[_rowIndexPosition]["sale_item_quantity"].ToString();
                            _dataRowChallanItemsList["sale_item_quantity_actual_load"] = _dataTableItemsList.Rows[_rowIndexPosition]["sale_item_quantity_actual_load"].ToString();

                            Decimal _Item_price_after_Check_NetRate_or_Price = 0;
                            Decimal _itemDiscountAmount = 0;
                            if (_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_net_price"].ToString() == "" || _dataTableItemsList.Rows[_rowIndexPosition]["sale_item_net_price"].ToString() == "0" || _dataTableItemsList.Rows[_rowIndexPosition]["sale_item_net_price"].ToString() == "0.0" || _dataTableItemsList.Rows[_rowIndexPosition]["sale_item_net_price"].ToString() == "0.00")
                            {
                                _Item_price_after_Check_NetRate_or_Price = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_price"].ToString());
                                _itemDiscountAmount = Math.Round(Convert.ToDecimal(_Item_price_after_Check_NetRate_or_Price) - (Convert.ToDecimal(_Item_price_after_Check_NetRate_or_Price) * Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["item_discount_percentage"]) / 100), 2);
                                _dataRowChallanItemsList["item_discount_amount"] = _itemDiscountAmount;
                            }
                            else
                            {
                                _Item_price_after_Check_NetRate_or_Price = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_net_price"].ToString());
                                _itemDiscountAmount = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_net_price"].ToString());
                                _dataRowChallanItemsList["item_discount_amount"] = _itemDiscountAmount;
                            }

                            _dataRowChallanItemsList["sale_item_price"] = _dataTableItemsList.Rows[_rowIndexPosition]["sale_item_price"].ToString();
                            _dataRowChallanItemsList["sale_item_price_2"] = _dataTableItemsList.Rows[_rowIndexPosition]["sale_item_price_2"].ToString();
                            _dataRowChallanItemsList["sale_item_net_price"] = _dataTableItemsList.Rows[_rowIndexPosition]["sale_item_net_price"].ToString();
                            _dataRowChallanItemsList["item_discount_percentage"] = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["item_discount_percentage"]).ToString();
                            _dataRowChallanItemsList["item_bill_percentage"] = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["item_bill_percentage"]).ToString();
                            // _dataRowChallanItemsList["item_discount_amount"] = Math.Round(Convert.ToDecimal(_dataRowChallanItemsList["sale_item_price"].ToString())-(Convert.ToDecimal(_dataRowChallanItemsList["sale_item_price"].ToString()) * Convert.ToDecimal(txtItemWiseDiscount.Text)/100),2).ToString();
                            //  _dataRowChallanItemsList["item_discount_amount"] = Math.Round(Convert.ToDecimal(_Item_price_after_Check_NetRate_or_Price) - (Convert.ToDecimal(_Item_price_after_Check_NetRate_or_Price) * Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["item_discount_percentage"]) / 100), 2).ToString();
                            _dataRowChallanItemsList["item_amount"] = Math.Round(Convert.ToDecimal(_dataRowChallanItemsList["sale_item_quantity_actual_load"].ToString()) * Convert.ToDecimal(_dataRowChallanItemsList["item_discount_amount"]), 2).ToString();
                            _dataRowChallanItemsList["item_bill_rate"] = Math.Round(Convert.ToDecimal(_dataRowChallanItemsList["item_bill_percentage"].ToString()) * Convert.ToDecimal(_dataRowChallanItemsList["item_discount_amount"]) / 100, 2).ToString();
                            _dataRowChallanItemsList["item_bill_amount"] = Math.Round(Convert.ToDecimal(_dataRowChallanItemsList["sale_item_quantity_actual_load"].ToString()) * Convert.ToDecimal(_dataRowChallanItemsList["item_bill_rate"]), 2).ToString();
                           
                            Decimal _item_Billing_Amount  = Convert.ToDecimal(_dataRowChallanItemsList["sale_item_quantity_actual_load"].ToString()) * Convert.ToDecimal(_dataRowChallanItemsList["item_bill_rate"]);
                            Decimal _item_gst_Percentage = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["item_gst_percentage"]);
                           
                            _dataRowChallanItemsList["item_gst_amount"] = Convert.ToDecimal(_item_Billing_Amount /100 * _item_gst_Percentage);

                            // Add Values one -by one to New DataTable 
                            _dataTableChallanItemsList.Rows.Add(_dataRowChallanItemsList);
                        }

                        ViewState["ChallanList"] = _dataTableChallanItemsList;
                        divFinalChallanItemList.Visible = true;
                        rptrchallanItemList.DataSource = _dataTableChallanItemsList;
                        rptrchallanItemList.DataBind();

                        BindTableFooterChallanItemData();

                    }
                    else
                    {

                        divFinalChallanItemList.Visible = true;
                        //_dataTableChallanItemsList = (DataTable)ViewState["ChallanList"];
                        //rptrchallanItemList.DataSource = _dataTableChallanItemsList;
                        //rptrchallanItemList.DataBind();
                    }
                }
                else
                { }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }


        }



        /// <summary>
        /// This is Used to Create Blank Table only Header
        /// </summary>
        public void CreateChallanTableOnlyHeader()
        {
            try
            {
                _dataTableChallanItemsList.Columns.Add("sale_item_type_id", typeof(int));
                _dataTableChallanItemsList.Columns.Add("sale_item_type_title", typeof(string));
                _dataTableChallanItemsList.Columns.Add("item_master_id", typeof(int));
                _dataTableChallanItemsList.Columns.Add("sale_item_name", typeof(string));
                _dataTableChallanItemsList.Columns.Add("item_weight", typeof(Decimal));
                _dataTableChallanItemsList.Columns.Add("item_gst_percentage", typeof(Decimal));
                _dataTableChallanItemsList.Columns.Add("sale_item_quantity", typeof(string));
                _dataTableChallanItemsList.Columns.Add("sale_item_quantity_actual_load", typeof(string));
                _dataTableChallanItemsList.Columns.Add("sale_item_price", typeof(Decimal));
                _dataTableChallanItemsList.Columns.Add("sale_item_price_2", typeof(Decimal));
                _dataTableChallanItemsList.Columns.Add("sale_item_net_price", typeof(Decimal));

                _dataTableChallanItemsList.Columns.Add("item_discount_percentage", typeof(Decimal));
                _dataTableChallanItemsList.Columns.Add("item_bill_percentage", typeof(Decimal));
                _dataTableChallanItemsList.Columns.Add("item_discount_amount", typeof(Decimal));
                _dataTableChallanItemsList.Columns.Add("item_amount", typeof(Decimal));
                _dataTableChallanItemsList.Columns.Add("item_bill_rate", typeof(Decimal));
                _dataTableChallanItemsList.Columns.Add("item_bill_amount", typeof(Decimal));
                _dataTableChallanItemsList.Columns.Add("item_gst_amount", typeof(Decimal));


                ViewState["ChallanList"] = _dataTableChallanItemsList;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }

        public void ResetSaleOrderRepeaterCheckItem()
        {
            try
            {
                foreach (RepeaterItem item in rptrSaleOrderItemsList.Items)
                {
                    CheckBox chkChallanItem = (CheckBox)item.FindControl("chkChallanItem");
                    Label lblSaleItemTypeId = (Label)item.FindControl("lblSaleItemTypeId");
                    Label lblSaleItemTypeName = (Label)item.FindControl("lblSaleItemTypeName");
                    Label lblitemid = (Label)item.FindControl("lblitemid");
                    Label lblItemName = (Label)item.FindControl("lblItemName");
                    Label lblActualQuantity = (Label)item.FindControl("lblActualQuantity");
                    Label lblSaleItemNetRate = (Label)item.FindControl("lblSaleItemNetRate");
                    Label lblSaleItemPrice = (Label)item.FindControl("lblSaleItemPrice");
                    Label lblSaleItemPrice2 = (Label)item.FindControl("lblSaleItemPrice2");
                    Label lblItemWeight = (Label)item.FindControl("lblItemWeight");
                    TextBox txtSendQuantity = (TextBox)item.FindControl("txtSendQuantity");


                    if (chkChallanItem.Checked == true)
                    {
                        chkChallanItem.Checked = false;
                    }

                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }

        #endregion

        protected void btnConfirmAndSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                #region Old Code
                //GetRepeaterItemValues();

                //if (ViewState["Row"] != null)
                //{
                //    if (hdfdPartyMasterId.Value == "" || hdfdPartyMasterId.Value == null)
                //    {
                //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlertClientName();", true);
                //    }
                //    else
                //    {
                //        _dataTableItemsList = (DataTable)ViewState["Row"];

                //        if (_dataTableItemsList.Rows.Count > 0)
                //        {
                //            _lblToughDiscountAmount = 0;

                //            txtToughDiscount.Text = (Convert.ToInt32(_toughDiscountPercentage)).ToString();
                //            txtToughBillingPercentage.Text = _toughBillPercentage.ToString();
                //            txtNetRateBillingPercentage.Text = _netBillingPercentage.ToString();
                //            txtTotalCash.Text = _totalCashAmount.ToString();
                //            txtBillAmount.Text = _totalBillAmount.ToString();


                //            _netRate = 0;
                //            _totalAmount = 0;
                //            for (int _rowIndexPosition = 0; _rowIndexPosition < _dataTableItemsList.Rows.Count; _rowIndexPosition++)
                //            {

                //                if (Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_net_price"].ToString()) > 0)
                //                {
                //                    _netRate += Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_net_price"].ToString()) * Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_quantity_actual_load"].ToString());

                //                }
                //                else
                //                {
                //                    _lblToughDiscountAmount += Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_price"].ToString()) * Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_quantity_actual_load"].ToString());
                //                }

                //            }


                //            Decimal _temporyToughDiscountAmount = _lblToughDiscountAmount;
                //            Decimal _DiffrenceVale = (Convert.ToDecimal(txtToughDiscount.Text) * Convert.ToDecimal(_temporyToughDiscountAmount) / 100);
                //            lblToughDiscountAmount.Text = (Convert.ToDecimal(_temporyToughDiscountAmount) - Convert.ToDecimal(_DiffrenceVale)).ToString();


                //            //lblToughDiscountAmount.Text = _lblToughDiscountAmount.ToString();

                //            lblLamiDiscountAmount.Text = "0";

                //            _totalAmount = (Convert.ToDecimal(_netRate) + Convert.ToDecimal(lblToughDiscountAmount.Text) + Convert.ToDecimal(lblLamiDiscountAmount.Text == "" ? 0 : Convert.ToDecimal(lblLamiDiscountAmount.Text)));

                //            lblToughBillingPercentageAmount.Text = (Convert.ToDecimal(txtToughBillingPercentage.Text) * Convert.ToDecimal(lblToughDiscountAmount.Text) / 100).ToString();
                //            lblLamiBillingPercentageAmount.Text = (Convert.ToDecimal(txtLamiBillingPercentage.Text) * Convert.ToDecimal(lblLamiDiscountAmount.Text == "" ? 0 : Convert.ToDecimal(lblLamiDiscountAmount.Text)) / 100).ToString();
                //            lblnetRateBillingPercentageAmount.Text = (Convert.ToDecimal(txtNetRateBillingPercentage.Text == "" ? 0 : Convert.ToDecimal(txtNetRateBillingPercentage.Text)) * Convert.ToDecimal(_netRate) / 100).ToString();

                //            txtTotalAmount.Text = _totalAmount.ToString();

                //            txtBillAmount.Text = (Convert.ToDecimal(lblToughBillingPercentageAmount.Text) + Convert.ToDecimal(lblLamiBillingPercentageAmount.Text) + Convert.ToDecimal(lblnetRateBillingPercentageAmount.Text)).ToString();

                //            txtTotalCash.Text = (Convert.ToDecimal(txtTotalAmount.Text) - Convert.ToDecimal(txtBillAmount.Text)).ToString();

                //            btnConfirmAndSubmit.Visible = false;
                //            btnResetConfirm.Visible = true;
                //            txtToughDiscount.ReadOnly = txtToughBillingPercentage.ReadOnly = txtLamiDiscount.ReadOnly = txtLamiBillingPercentage.ReadOnly = txtNetRateBillingPercentage.ReadOnly = false;

                //            _saveBy18Percenatge = true;
                //            _saveBy28Percentage = false;
                //        }
                //        else
                //        {
                //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showError();", true);

                //        }
                //        //_objPartyMasterBL = new PartyMasterBL();
                //        //_objPartyMaster = _objPartyMasterBL.GetPartyMasterItemsByID(Convert.ToInt32(hdfdPartyMasterId.Value)).FirstOrDefault();

                //        //if (_objPartyMaster != null)
                //        //{
                //        //    txtToughDiscount.Text = _objPartyMaster.tough_discount_precentage.ToString();
                //        //    txtToughBillingPercentage.Text = _objPartyMaster.tough_billing_precentage.ToString();
                //        //    txtLamiDiscount.Text = _objPartyMaster.lami_discount_precentage.ToString();
                //        //    txtLamiBillingPercentage.Text = _objPartyMaster.lami_billing_precentage.ToString();
                //        //    txtNetRateBillingPercentage.Text = _objPartyMaster.netrate_billing_precentage.ToString();


                //        //    if (_objPartyMaster.party_master_id > 0)
                //        //    {

                //        //    }
                //        //    else
                //        //    { }

                //        //}
                //        //else
                //        //{ }
                //    }
                //}
                //else
                //{
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                //}

                #endregion

                try
                {
                    CreateTableforRptrChallanItem();
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
        }

        protected void btnResetConfirm_Click(object sender, EventArgs e)
        {
            try
            {

                _saveBy18Percenatge = false;

                ResetSaleOrderRepeaterCheckItem();

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                _ChallanRptrTotalItemAmountBeforeGST = _ChallanRptrTotalAmountAfterGST = _ChallanRptrBillAmountBeforeGST = _ChallanRptrBillAmountAfterGST = _ChallanRptrTotalGSTAmount = _ChallanRptrTotalCashAmount = _ChallanRptrTotalItemWeight = 0;
                _ChallanRptrTotalItemQuantity = 0;
                ResetTextField();
                ResetSaleOrderRepeaterCheckItem();
                _IsMultipleGstTable = false;
                rptrchallanItemList.DataSource = null;
                rptrchallanItemList.DataBind();
                CreateChallanTableOnlyHeader();

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtVehicleNumber.Text == "" || txtVehicleNumber.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showError();", true);
                }
                else if (txtDriverName.Text == "" || txtDriverName.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showError();", true);
                }
                else if (txtDeliveryBoy.Text == "" || txtDeliveryBoy.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showError();", true);
                }
                else
                {
                    #region Old Code 
                    //if (_saveBy18Percenatge == true)
                    //{
                    //    if (ViewState["Row"] != null)
                    //    {
                    //        _objChallanHeaderBL = new ChallanHeaderBL();
                    //        _objChallanItemBL = new ChallanItemBL();

                    //        _objChallanHeader = _objChallanHeaderBL.CreateChallanHeader(GetChallanHeaderObject(true));

                    //        if (_objChallanHeader.challan_header_id > 0)
                    //        {
                    //            _dataTableItemsList = (DataTable)ViewState["Row"];
                    //            if (_dataTableItemsList.Rows.Count > 0)
                    //            {
                    //                int _SaleChallanItemSaveCount = 0;

                    //                for (int _rowIndexPosition = 0; _rowIndexPosition < _dataTableItemsList.Rows.Count; _rowIndexPosition++)
                    //                {
                    //                    try
                    //                    {
                    //                        _objChallanItem.guid = Guid.NewGuid();
                    //                        _objChallanItem.loading_master_id = _objChallanHeader.loading_master_id;
                    //                        _objChallanItem.challan_header_id = _objChallanHeader.challan_header_id;
                    //                        _objChallanItem.sale_header_id = _objChallanHeader.sale_header_id;
                    //                        _objChallanItem.item_master_id = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["item_master_id"].ToString());
                    //                        _objChallanItem.party_master_id = _objChallanHeader.party_master_id;
                    //                        _objChallanItem.sale_item_type_id = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_type_id"].ToString());
                    //                        _objChallanItem.sale_item_type_title = _dataTableItemsList.Rows[_rowIndexPosition]["sale_item_type_title"].ToString();

                    //                        _objChallanItem.sale_item_name = _dataTableItemsList.Rows[_rowIndexPosition]["sale_item_name"].ToString();
                    //                        _objChallanItem.sale_item_quantity = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_quantity"].ToString());
                    //                        _objChallanItem.sale_item_price = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_price"].ToString());
                    //                        _objChallanItem.sale_item_price_2 = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_price_2"].ToString());
                    //                        _objChallanItem.sale_item_net_price = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_net_price"].ToString());
                    //                        _objChallanItem.item_weight = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_weight"].ToString());
                    //                        _objChallanItem.sale_item_quantity_actual_load = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_quantity_actual_load"].ToString());

                    //                        _objChallanItem.created_on = Convert.ToDateTime(System.DateTime.Now.ToString());

                    //                        _objChallanItem.created_by = Convert.ToInt32(Session[Constants.Id]);
                    //                        _objChallanItem.modified_by = Convert.ToInt32(Session[Constants.Id]);

                    //                        _objChallanItem = _objChallanItemBL.CreateChallanItem(_objChallanItem);
                    //                        _SaleChallanItemSaveCount = _SaleChallanItemSaveCount + 1;
                    //                    }
                    //                    catch (Exception ex)
                    //                    {
                    //                        ex.Message.ToString();
                    //                    }

                    //                }

                    //                if (_SaleChallanItemSaveCount > 0)
                    //                {
                    //                    rptrSaleOrderItemsList.DataSource = null;
                    //                    rptrSaleOrderItemsList.DataBind();
                    //                    rptrSaleOrderItemsList.Visible = false;


                    //                    rptrSaleOrderItemGst28Percentage.DataSource = null;
                    //                    rptrSaleOrderItemGst28Percentage.DataBind();
                    //                    rptrSaleOrderItemGst28Percentage.Visible = false;

                    //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccess();", true);
                    //                    ResetTextField();
                    //                    _totalItemActual = 0;
                    //                    _totalItemActualBy28Percentage = 0;
                    //                    _totalItemActualLoad = 0;
                    //                    _totalItemActualLoadBy28Percentage = 0;

                    //                    try
                    //                    {
                    //                      //  BindChallanDetailrptr();
                    //                    }
                    //                    catch(Exception ex)
                    //                    {
                    //                        ex.Message.ToString();
                    //                    }

                    //                }
                    //            }
                    //            else
                    //            {
                    //                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    //            }


                    //            // ClearGeneralForm();

                    //        }
                    //        else
                    //        {
                    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    //        }
                    //    }
                    //    else
                    //    {
                    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    //    }
                    //}
                    //else if (_saveBy28Percentage == true)
                    //{
                    //    if (ViewState["RowBy28"] != null)
                    //    {
                    //        _objChallanHeaderBL = new ChallanHeaderBL();
                    //        _objChallanItemBL = new ChallanItemBL();

                    //        _objChallanHeader = _objChallanHeaderBL.CreateChallanHeader(GetChallanHeaderObject(false));

                    //        if (_objChallanHeader.challan_header_id > 0)
                    //        {
                    //            _dataTableItemsList = (DataTable)ViewState["RowBy28"];
                    //            if (_dataTableItemsList.Rows.Count > 0)
                    //            {
                    //                int _SaleChallanItemSaveCount = 0;

                    //                for (int _rowIndexPosition = 0; _rowIndexPosition < _dataTableItemsList.Rows.Count; _rowIndexPosition++)
                    //                {
                    //                    try
                    //                    {
                    //                        _objChallanItem.guid = Guid.NewGuid();
                    //                        _objChallanItem.loading_master_id = _objChallanHeader.loading_master_id;
                    //                        _objChallanItem.challan_header_id = _objChallanHeader.challan_header_id;
                    //                        _objChallanItem.sale_header_id = _objChallanHeader.sale_header_id;
                    //                        _objChallanItem.item_master_id = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["item_master_id"].ToString());
                    //                        _objChallanItem.party_master_id = _objChallanHeader.party_master_id;
                    //                        _objChallanItem.sale_item_type_id = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_type_id"].ToString());
                    //                        _objChallanItem.sale_item_type_title = _dataTableItemsList.Rows[_rowIndexPosition]["sale_item_type_title"].ToString();

                    //                        _objChallanItem.sale_item_name = _dataTableItemsList.Rows[_rowIndexPosition]["sale_item_name"].ToString();
                    //                        _objChallanItem.sale_item_quantity = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_quantity"].ToString());
                    //                        _objChallanItem.sale_item_price = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_price"].ToString());
                    //                        _objChallanItem.sale_item_price_2 = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_price_2"].ToString());
                    //                        _objChallanItem.sale_item_net_price = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_net_price"].ToString());
                    //                        _objChallanItem.item_weight = Convert.ToDecimal(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_weight"].ToString());
                    //                        _objChallanItem.sale_item_quantity_actual_load = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["sale_item_quantity_actual_load"].ToString());

                    //                        _objChallanItem.created_on = Convert.ToDateTime(System.DateTime.Now.ToString());

                    //                        _objChallanItem.created_by = Convert.ToInt32(Session[Constants.Id]);
                    //                        _objChallanItem.modified_by = Convert.ToInt32(Session[Constants.Id]);

                    //                        _objChallanItem = _objChallanItemBL.CreateChallanItem(_objChallanItem);
                    //                        _SaleChallanItemSaveCount = _SaleChallanItemSaveCount + 1;
                    //                    }
                    //                    catch (Exception ex)
                    //                    {
                    //                        ex.Message.ToString();
                    //                    }

                    //                }

                    //                if (_SaleChallanItemSaveCount > 0)
                    //                {
                    //                    rptrSaleOrderItemsList.DataSource = null;
                    //                    rptrSaleOrderItemsList.DataBind();
                    //                    rptrSaleOrderItemsList.Visible = false;


                    //                    rptrSaleOrderItemGst28Percentage.DataSource = null;
                    //                    rptrSaleOrderItemGst28Percentage.DataBind();
                    //                    rptrSaleOrderItemGst28Percentage.Visible = false;

                    //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccess();", true);
                    //                    ResetTextField();
                    //                    _totalItemActual = 0;
                    //                    _totalItemActualBy28Percentage = 0;
                    //                    _totalItemActualLoad = 0;
                    //                    _totalItemActualLoadBy28Percentage = 0;

                    //                    try
                    //                    {
                    //                      //  BindChallanDetailrptr();
                    //                    }
                    //                    catch (Exception ex)
                    //                    {
                    //                        ex.Message.ToString();
                    //                    }
                    //                }
                    //            }
                    //            else
                    //            {
                    //                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    //            }


                    //            // ClearGeneralForm();

                    //        }
                    //        else
                    //        {
                    //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    //        }
                    //    }
                    //    else
                    //    {
                    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    //    }
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    //}

                    #endregion

                    if (ViewState["ChallanList"] != null)
                    {
                        _objChallanHeaderBL = new ChallanHeaderBL();
                        _objChallanItemBL = new ChallanItemBL();

                        _objChallanHeader = _objChallanHeaderBL.CreateChallanHeader(GetChallanHeaderObject(false));

                        if (_objChallanHeader.challan_header_id > 0)
                        {
                            _dataTableChallanItemsList = (DataTable)ViewState["ChallanList"];
                            if (_dataTableChallanItemsList.Rows.Count > 0)
                            {
                                int _SaleChallanItemSaveCount = 0;

                                for (int _rowIndexPosition = 0; _rowIndexPosition < _dataTableChallanItemsList.Rows.Count; _rowIndexPosition++)
                                {
                                    try
                                    {
                                        _objChallanItem.guid = Guid.NewGuid();
                                        _objChallanItem.loading_master_id = _objChallanHeader.loading_master_id;
                                        _objChallanItem.challan_header_id = _objChallanHeader.challan_header_id;
                                        _objChallanItem.sale_header_id = _objChallanHeader.sale_header_id;
                                        _objChallanItem.item_master_id = Convert.ToInt32(_dataTableChallanItemsList.Rows[_rowIndexPosition]["item_master_id"].ToString());
                                        _objChallanItem.party_master_id = _objChallanHeader.party_master_id;
                                        _objChallanItem.sale_item_type_id = Convert.ToInt32(_dataTableChallanItemsList.Rows[_rowIndexPosition]["sale_item_type_id"].ToString());
                                        _objChallanItem.sale_item_type_title = _dataTableChallanItemsList.Rows[_rowIndexPosition]["sale_item_type_title"].ToString();

                                        _objChallanItem.sale_item_name = _dataTableChallanItemsList.Rows[_rowIndexPosition]["sale_item_name"].ToString();
                                        _objChallanItem.item_weight = Convert.ToDecimal(_dataTableChallanItemsList.Rows[_rowIndexPosition]["item_weight"].ToString());
                                        _objChallanItem.item_gst_percentage = Convert.ToInt32(_dataTableChallanItemsList.Rows[_rowIndexPosition]["item_gst_percentage"].ToString());
                                        _objChallanItem.sale_item_quantity = Convert.ToInt32(_dataTableChallanItemsList.Rows[_rowIndexPosition]["sale_item_quantity"].ToString());
                                        _objChallanItem.sale_item_quantity_actual_load = Convert.ToInt32(_dataTableChallanItemsList.Rows[_rowIndexPosition]["sale_item_quantity_actual_load"].ToString());

                                        _objChallanItem.sale_item_price = Convert.ToDecimal(_dataTableChallanItemsList.Rows[_rowIndexPosition]["sale_item_price"].ToString());
                                        _objChallanItem.sale_item_price_2 = Convert.ToDecimal(_dataTableChallanItemsList.Rows[_rowIndexPosition]["sale_item_price_2"].ToString());
                                        _objChallanItem.sale_item_net_price = Convert.ToDecimal(_dataTableChallanItemsList.Rows[_rowIndexPosition]["sale_item_net_price"].ToString());

                                        _objChallanItem.item_discount_percentage = Convert.ToDecimal(_dataTableChallanItemsList.Rows[_rowIndexPosition]["item_discount_percentage"].ToString());
                                        _objChallanItem.item_bill_percentage = Convert.ToDecimal(_dataTableChallanItemsList.Rows[_rowIndexPosition]["item_bill_percentage"].ToString());
                                        _objChallanItem.item_discount_amount = Convert.ToDecimal(_dataTableChallanItemsList.Rows[_rowIndexPosition]["item_discount_amount"].ToString());
                                        _objChallanItem.item_amount = Convert.ToDecimal(_dataTableChallanItemsList.Rows[_rowIndexPosition]["item_amount"].ToString());
                                        _objChallanItem.item_bill_rate = Convert.ToDecimal(_dataTableChallanItemsList.Rows[_rowIndexPosition]["item_bill_rate"].ToString());
                                        _objChallanItem.item_bill_amount = Convert.ToDecimal(_dataTableChallanItemsList.Rows[_rowIndexPosition]["item_bill_amount"].ToString());
                                        _objChallanItem.item_gst_amount = Convert.ToDecimal(_dataTableChallanItemsList.Rows[_rowIndexPosition]["item_gst_amount"].ToString());
                                        _objChallanItem.item_unit = "Pcs";


                                        _objChallanItem.created_on = Convert.ToDateTime(System.DateTime.Now.ToString());

                                        _objChallanItem.created_by = Convert.ToInt32(Session[Constants.Id]);
                                        _objChallanItem.modified_by = Convert.ToInt32(Session[Constants.Id]);

                                        _objChallanItem = _objChallanItemBL.CreateChallanItem(_objChallanItem);
                                        _SaleChallanItemSaveCount = _SaleChallanItemSaveCount + 1;
                                    }
                                    catch (Exception ex)
                                    {
                                        ex.Message.ToString();
                                    }

                                }

                                if (_SaleChallanItemSaveCount > 0)
                                {
                                    rptrSaleOrderItemsList.DataSource = null;
                                    rptrSaleOrderItemsList.DataBind();
                                    rptrSaleOrderItemsList.Visible = false;


                                    rptrSaleOrderItemGst28Percentage.DataSource = null;
                                    rptrSaleOrderItemGst28Percentage.DataBind();
                                    rptrSaleOrderItemGst28Percentage.Visible = false;

                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccess();", true);
                                    ResetTextField();
                                    _totalItemActual = 0;
                                    _totalItemActualBy28Percentage = 0;
                                    _totalItemActualLoad = 0;
                                    _totalItemActualLoadBy28Percentage = 0;

                                    rptrchallanItemList.Visible = false;
                                    divFinalChallanItemList.Visible = false;

                                    try
                                    {
                                        BindChallanDetailrptrWithoutHideOtherControl();


                                    }
                                    catch (Exception ex)
                                    {
                                        ex.Message.ToString();
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


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
        }


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

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }
        #endregion

        #region Get Challan Header From General Form TextFields
        /// <summary>
        /// This Method is Used to Get Challan Header Details From General Form TextFields to SaleHeaderMaster Object
        /// </summary>
        /// <returns></returns>
        private ChallanHeader GetChallanHeaderObject(Boolean _isGst18Percentage)
        {
            try
            {

                _objChallanHeaderBL = new ChallanHeaderBL();

                _objChallanHeader.guid = Guid.NewGuid();
                _objChallanHeader.party_master_id = Convert.ToInt32(hdfdPartyMasterId.Value);
                // _objChallanHeader.total_items = Convert.ToInt32(txtItemQuantity.Text);
                _objChallanHeader.sale_header_id = Convert.ToInt32(hdfdSaleHeaderId.Value);
                _objChallanHeader.loading_master_id = Convert.ToInt32(hdfdLoadingMasterId.Value);
                _objChallanHeader.order_number = hdfdSaleOrderNumber.Value;

                #region Value from Old TextField and Label
                //_objChallanHeader.total_amount_billed = Convert.ToDecimal(txtBillAmount.Text);
                //_objChallanHeader.total_amount_cash = Convert.ToDecimal(txtTotalCash.Text);
                //_objChallanHeader.total_amount = Convert.ToDecimal(txtTotalAmount.Text);
                //_objChallanHeader.tough_discount_precentage = Convert.ToDecimal(txtToughDiscount.Text);
                //_objChallanHeader.tough_discount = Convert.ToDecimal(_lblToughDiscountAmount) - Convert.ToDecimal(lblToughDiscountAmount.Text);
                //_objChallanHeader.tough_total_amount = Convert.ToDecimal(lblToughDiscountAmount.Text);

                //_objChallanHeader.tough_billing_amount = Convert.ToDecimal(lblToughBillingPercentageAmount.Text);
                //_objChallanHeader.tough_billing_precentage = Convert.ToInt32(txtToughBillingPercentage.Text);

                //_objChallanHeader.htf_discount = Convert.ToDecimal(0);
                //_objChallanHeader.lami_discount = Convert.ToDecimal(0);
                //_objChallanHeader.lami_discount_precentage = Convert.ToDecimal(txtLamiDiscount.Text);
                //_objChallanHeader.lami_billing_precentage = Convert.ToInt32(txtLamiBillingPercentage.Text);
                //_objChallanHeader.lami_billing_amount = Convert.ToDecimal(lblLamiBillingPercentageAmount.Text);
                //_objChallanHeader.lami_total_amount = Convert.ToDecimal(0);
                //_objChallanHeader.sale_item_remarks = "";


                //_objChallanHeader.price_list = "";

                //_objChallanHeader.total_net_rate = Convert.ToDecimal(_netRate);
                //_objChallanHeader.netrate_billing_amount = Convert.ToDecimal(lblnetRateBillingPercentageAmount.Text);
                //_objChallanHeader.netrate_billing_precentage = Convert.ToInt32(txtNetRateBillingPercentage.Text);

                //if (_isGst18Percentage == true)
                //{
                //    _objChallanHeader.gst_amount = (Convert.ToDecimal(txtBillAmount.Text) * Convert.ToDecimal(_itemGst18Percentage)) / Convert.ToDecimal(100);
                //    _objChallanHeader.total_items_pre_challan = Convert.ToInt32(_totalItemActual);
                //    _objChallanHeader.total_items_after_challan = Convert.ToInt32(_totalItemActualLoad);
                //    _objChallanHeader.total_weight = (_TotalItems * _totalItemActualLoad);
                //}
                //else
                //{
                //    _objChallanHeader.total_items_pre_challan = Convert.ToInt32(_totalItemActualBy28Percentage);
                //    _objChallanHeader.total_items_after_challan = Convert.ToInt32(_totalItemActualLoadBy28Percentage);
                //    _objChallanHeader.gst_amount = (Convert.ToDecimal(txtBillAmount.Text) * Convert.ToDecimal(_itemGst28Percentage)) / Convert.ToDecimal(100);
                //    _objChallanHeader.total_weight = (_TotalItemsBy28Percentage * _totalItemActualLoadBy28Percentage);
                //}

                //// _objChallanHeader.gst_amount = (Convert.ToDecimal(txtBillAmount.Text) * Convert.ToDecimal(_itemGstPercentage)) / Convert.ToDecimal(100);
                //_objChallanHeader.billing_grand_total = Convert.ToDecimal(txtBillAmount.Text) + _objChallanHeader.gst_amount;

                #endregion

                _objChallanHeader.total_amount_billed = Convert.ToDecimal(txtBillAmount.Text);
                _objChallanHeader.total_amount_cash = Convert.ToDecimal(txtTotalCash.Text);
                _objChallanHeader.total_amount = Convert.ToDecimal(txtTotalAmount.Text);


                _objChallanHeader.tough_discount_precentage = Convert.ToDecimal(txtToughDiscount.Text);
                //_objChallanHeader.tough_discount = Convert.ToDecimal(_lblToughDiscountAmount) - Convert.ToDecimal(lblToughDiscountAmount.Text); /*This is */
                _objChallanHeader.tough_discount = Convert.ToDecimal(0); /*This is */
                _objChallanHeader.tough_total_amount = Convert.ToDecimal(0);

                _objChallanHeader.tough_billing_amount = Convert.ToDecimal(0);
                _objChallanHeader.tough_billing_precentage = Convert.ToInt32(0);

                _objChallanHeader.htf_discount = Convert.ToDecimal(0);
                _objChallanHeader.lami_discount = Convert.ToDecimal(0);
                _objChallanHeader.lami_discount_precentage = Convert.ToDecimal(0);
                _objChallanHeader.lami_billing_precentage = Convert.ToInt32(0);
                _objChallanHeader.lami_billing_amount = Convert.ToDecimal(0);
                _objChallanHeader.lami_total_amount = Convert.ToDecimal(0);
                _objChallanHeader.sale_item_remarks = "";


                _objChallanHeader.price_list = "";

                _objChallanHeader.total_net_rate = Convert.ToDecimal(_ChallanRptrNetRate);
                _objChallanHeader.netrate_billing_amount = Convert.ToDecimal(_ChallanRptrNetRateBillPercentageAmount);
                _objChallanHeader.netrate_billing_precentage = Convert.ToInt32(txtNetRateBillingPercentage.Text);

                _objChallanHeader.total_items_pre_challan = Convert.ToInt32(_ChallanRptrTotalActualItemQuantity);
                _objChallanHeader.total_items_after_challan = Convert.ToInt32(_ChallanRptrTotalItemQuantity);
                _objChallanHeader.gst_amount = Convert.ToDecimal(_ChallanRptrTotalGSTAmount);
                _objChallanHeader.total_weight = _ChallanRptrTotalItemWeight;

                // _objChallanHeader.gst_amount = (Convert.ToDecimal(txtBillAmount.Text) * Convert.ToDecimal(_itemGstPercentage)) / Convert.ToDecimal(100);
                _objChallanHeader.billing_grand_total = Convert.ToDecimal(txtBillAmount.Text) + _objChallanHeader.gst_amount;



                // _objChallanHeader.tough_discount = Convert.ToInt32(txtDiscount.Text);
                _objChallanHeader.order_status = "";

                _objChallanHeader.vehicle_number = txtVehicleNumber.Text;
                _objChallanHeader.driver_name = txtDriverName.Text;
                _objChallanHeader.delivery_boy = txtDeliveryBoy.Text;

                _objChallanHeader.staff_name = Convert.ToString(Session[Constants.UserName]);
                _objChallanHeader.made_by = Convert.ToString(Session[Constants.UserName]);
                _objChallanHeader.created_by = Convert.ToInt32(Session[Constants.Id]);
                _objChallanHeader.modified_by = Convert.ToInt32(Session[Constants.Id]);

                _objChallanHeader.sale_item_date = Convert.ToDateTime(System.DateTime.Now.ToString());
                //Convert.ToDateTime(_objStaffMaster.staff_joinning_date).ToString("MM/dd/yyyy");



            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objChallanHeader;
        }
        #endregion

        protected void rptrSaleOrderItemGst28Percentage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void rptrSaleOrderItemGst28Percentage_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Label lblitemid = (Label)e.Item.FindControl("lblitemid");
                    // Label lblItemGstPercentage = (Label)e.Item.FindControl("lblItemGstPercentage");
                    Label lblActualQuantity = (Label)e.Item.FindControl("lblActualQuantity");
                    Label lblItemWeight = (Label)e.Item.FindControl("lblItemWeight");

                    Decimal _itemWeight = Convert.ToDecimal(lblItemWeight.Text);
                    _TotalItemsBy28Percentage = _TotalItemsBy28Percentage + _itemWeight;
                    int _itemActualQuantity = Convert.ToInt32(lblActualQuantity.Text);
                    _totalItemActualBy28Percentage = _totalItemActualBy28Percentage + _itemActualQuantity;

                    int _itemmasterId = Convert.ToInt32(lblitemid.Text);

                    // This is Used to get Item Details for check is DFG true or false for apply GST Condition 18% or 28%
                    //  lblItemGstPercentage.Text = _itemGst28Percentage.ToString();


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