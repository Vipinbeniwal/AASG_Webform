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
    public partial class add_purchase : System.Web.UI.Page
    {
        #region Global Properties
       

         PurchaseHeader _objPurchaseHeader = new  PurchaseHeader();
        PurchaseHeaderBL _objPurchaseHeaderBL = null;
        List< PurchaseHeader> _lstPurchaseHeader = new List< PurchaseHeader>();

         PurchaseItem _objPurchaseItem = new  PurchaseItem();
        PurchaseItemBL _objPurchaseItemBL = null;
        List< PurchaseItem> _lstPurchaseItem = new List< PurchaseItem>();

         DropdownMaster _objDropdownMaster = new  DropdownMaster();
        DropdownMasterBL _objDropdownMasterBL  = null;
        List< DropdownMaster> _lstDropdownMaster = new List< DropdownMaster>();

         ItemMaster _objItemMaster = new  ItemMaster();
        ItemMasterBL _objItemMasterBL = null;
        List< ItemMaster> _lstItemMaster = new List< ItemMaster>();


         SupplierMaster _objSupplierMaster = new  SupplierMaster();
        SupplierMasterBL _objSupplierMasterBL = null;
        List< SupplierMaster> _lstSupplierMaster = new List< SupplierMaster>();

        List< vwItemListWithModelAndGlassColor> _lstvwItemListWithModelAndGlassColor = new List< vwItemListWithModelAndGlassColor>();


        string UserIp = string.Empty;
        
        public static int _totalItemCount = 0;
        DataTable _dataTableItemsList = new DataTable();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            //Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                BindItemTypeList();
                BindSupplierList();
                txtTotalPaid.Enabled = false;
                _totalItemCount = 0;


            }

           

        }


        #region

        private void BindItemTypeList()
        {
            try
            {
               
                 _objDropdownMasterBL = new DropdownMasterBL();

                _lstDropdownMaster = _objDropdownMasterBL.GetAllDropdownMasterItems().Where(x => x.dropdown_type == "Item Type").ToList();

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

        private void BindSupplierList()
        {
            try
            {

                _objSupplierMasterBL = new SupplierMasterBL();

                _lstSupplierMaster = _objSupplierMasterBL.GetAllSupplierMasterItems().Where(x => x.is_active == true).ToList();

                ddlPurchaseBy.DataSource = _lstSupplierMaster;

                ddlPurchaseBy.DataTextField = "supplier_name";
                ddlPurchaseBy.DataValueField = "supplier_master_id";
                ddlPurchaseBy.DataBind();
                ddlPurchaseBy.Items.Insert(0, new ListItem("Select", "Select"));

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }

        #endregion

        #region Create Item Table at Run Time
        /// <summary>
        /// This Method is Used to Create Item Table at Run Time
        /// </summary>
        public void createtable()
        {
            _dataTableItemsList.Columns.Add("purchase_item_type_id", typeof(int));
            _dataTableItemsList.Columns.Add("item_master_id", typeof(int));
            _dataTableItemsList.Columns.Add("purchase_item_name", typeof(string));
            _dataTableItemsList.Columns.Add("purchase_item_quantity", typeof(string));
            _dataTableItemsList.Columns.Add("purchase_item_price", typeof(int));

            rptrPurchaseItems.DataSource = _dataTableItemsList;
            rptrPurchaseItems.DataBind();
            if (ViewState["Row"] != null)
            {
                int _alreadyCount = 0;
                _dataTableItemsList = (DataTable)ViewState["Row"];

                for (int _datatableRowIndexPostion = 0; _datatableRowIndexPostion < _dataTableItemsList.Rows.Count; _datatableRowIndexPostion++)
                {
                    if (_dataTableItemsList.Rows[_datatableRowIndexPostion]["item_master_id"].ToString() == Convert.ToInt32(ddlItemList.SelectedValue).ToString())
                    {
                        _alreadyCount  = _alreadyCount + 1;
                    }
                }

                if (_alreadyCount == 0)
                {
                    DataRow _dataRowItemsList = _dataTableItemsList.NewRow();
                    _dataRowItemsList["purchase_item_type_id"] = Convert.ToInt32(ddlItemTypeList.SelectedValue);
                    _dataRowItemsList["item_master_id"] = Convert.ToInt32(ddlItemList.SelectedValue);
                    _dataRowItemsList["purchase_item_name"] = ddlItemList.SelectedItem.Text;
                    _dataRowItemsList["purchase_item_quantity"] = txtItemQuantity.Text;
                    _dataRowItemsList["purchase_item_price"] = txtItemPrice.Text;
                    _dataTableItemsList.Rows.Add(_dataRowItemsList);
                    _totalItemCount = _totalItemCount + Convert.ToInt32(txtItemQuantity.Text);
                    ViewState["Row"] = _dataTableItemsList;
                    if (_dataTableItemsList.Rows.Count > 0)
                    {
                        int _totalPiad = 0;
                        for (int i = 0; i < _dataTableItemsList.Rows.Count; i++)
                        {
                            _totalPiad += Convert.ToInt32(_dataTableItemsList.Rows[i]["purchase_item_price"].ToString());
                        }
                        txttotalAmount.Text = _totalPiad.ToString();
                        txtPendingAmount.Text = "0";
                        txtTotalPaid.Text = "0";
                        txtTotalPaid.Enabled = true;
                    }
                    rptrPurchaseItems.DataSource = ViewState["Row"];
                    rptrPurchaseItems.DataBind();
                    rptrPurchaseItems.Visible = true;
                }
                else
                {
                   
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlreadyPurchaseItemMaster();", true);
                    ViewState["Row"] = _dataTableItemsList;
                    rptrPurchaseItems.DataSource = ViewState["Row"];
                    rptrPurchaseItems.DataBind();
                    rptrPurchaseItems.Visible = true;
                    txtTotalPaid.Enabled = true;
                }

            }
            else
            {
                DataRow _dataRowItemsList = _dataTableItemsList.NewRow();
                _dataRowItemsList["purchase_item_type_id"] =  Convert.ToInt32(ddlItemTypeList.SelectedValue);
                _dataRowItemsList["item_master_id"] =  Convert.ToInt32(ddlItemList.SelectedValue);
                _dataRowItemsList["purchase_item_name"] = ddlItemList.SelectedItem.Text;
                _dataRowItemsList["purchase_item_quantity"] = txtItemQuantity.Text;
                _dataRowItemsList["purchase_item_price"] = txtItemPrice.Text;
                _dataTableItemsList.Rows.Add(_dataRowItemsList);
                _totalItemCount = _totalItemCount + Convert.ToInt32(txtItemQuantity.Text);
                ViewState["Row"] = _dataTableItemsList;
                if (_dataTableItemsList.Rows.Count > 0)
                {
                    int _totalPiad = 0;
                    for (int i = 0; i < _dataTableItemsList.Rows.Count; i++)
                    {
                        _totalPiad += Convert.ToInt32(_dataTableItemsList.Rows[i]["purchase_item_price"].ToString());
                    }
                    txttotalAmount.Text = _totalPiad.ToString();
                    txtPendingAmount.Text = "0";
                    txtTotalPaid.Text = "0";
                    txtTotalPaid.Enabled = true;
                }
                rptrPurchaseItems.DataSource = ViewState["Row"];
                rptrPurchaseItems.DataBind();
                rptrPurchaseItems.Visible = true;
            }
        }

        /// <summary>
        /// This Method is Used to Delete Item from Table at Run Time
        /// </summary>
        public void deleteRowfromtable(int _itemIdForRemove)
        {
            // Get  Repeater Values From View to Data Table
            _dataTableItemsList.Columns.Add("purchase_item_type_id", typeof(int));
            _dataTableItemsList.Columns.Add("item_master_id", typeof(int));
            _dataTableItemsList.Columns.Add("purchase_item_name", typeof(string));
            _dataTableItemsList.Columns.Add("purchase_item_quantity", typeof(string));
            _dataTableItemsList.Columns.Add("purchase_item_price", typeof(int));

            rptrPurchaseItems.DataSource = _dataTableItemsList;
            rptrPurchaseItems.DataBind();

            _dataTableItemsList = (DataTable)ViewState["Row"];

            // Create New DataTable and Columns At Run Time
            DataTable _dataTableItemsListRemove = new DataTable();
            _dataTableItemsListRemove.Columns.Add("purchase_item_type_id", typeof(int));
            _dataTableItemsListRemove.Columns.Add("item_master_id", typeof(int));
            _dataTableItemsListRemove.Columns.Add("purchase_item_name", typeof(string));
            _dataTableItemsListRemove.Columns.Add("purchase_item_quantity", typeof(string));
            _dataTableItemsListRemove.Columns.Add("purchase_item_price", typeof(int));


            // Assing Datable Items To Another DataTable and Skip Selected Item  for Remove/Delete
            
            for (int _datatableRowIndexPostion = 0; _datatableRowIndexPostion < _dataTableItemsList.Rows.Count; _datatableRowIndexPostion++)
            {
                if (_dataTableItemsList.Rows[_datatableRowIndexPostion]["item_master_id"].ToString() != Convert.ToInt32(_itemIdForRemove).ToString())
                {
                    DataRow _dataRowItemsListRemove = _dataTableItemsListRemove.NewRow();

                    _dataRowItemsListRemove["purchase_item_type_id"] = Convert.ToInt32(_dataTableItemsList.Rows[_datatableRowIndexPostion]["purchase_item_type_id"]);
                    _dataRowItemsListRemove["item_master_id"] = Convert.ToInt32(_dataTableItemsList.Rows[_datatableRowIndexPostion]["item_master_id"]);
                    _dataRowItemsListRemove["purchase_item_name"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["purchase_item_name"];
                    _dataRowItemsListRemove["purchase_item_quantity"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["purchase_item_quantity"];
                    _dataRowItemsListRemove["purchase_item_price"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["purchase_item_price"];

                    // Add Values one -by one to New DataTable 
                    _dataTableItemsListRemove.Rows.Add(_dataRowItemsListRemove);
                    
                    if (_dataTableItemsListRemove.Rows.Count > 0)
                    {
                        int _totalPiad = 0;
                        for (int RowIndexPostionForRemove = 0; RowIndexPostionForRemove < _dataTableItemsListRemove.Rows.Count; RowIndexPostionForRemove++)
                        {
                            _totalPiad += Convert.ToInt32(_dataTableItemsListRemove.Rows[RowIndexPostionForRemove]["purchase_item_price"].ToString());
                        }
                        txttotalAmount.Text = _totalPiad.ToString();
                        txtPendingAmount.Text = "0";
                        txtTotalPaid.Text = "0";
                        
                    }
                }
                else
                {
                    _totalItemCount = _totalItemCount - Convert.ToInt32(_dataTableItemsList.Rows[_datatableRowIndexPostion]["purchase_item_quantity"]);
                }

            }

            if(_dataTableItemsListRemove.Rows.Count > 0)
            {
                ViewState["Row"] = _dataTableItemsListRemove;
                rptrPurchaseItems.DataSource = ViewState["Row"];
                rptrPurchaseItems.DataBind();
                rptrPurchaseItems.Visible = true;
                txtTotalPaid.Enabled = true;
            }
            else
            {
                txttotalAmount.Text = "0";
                txtPendingAmount.Text = "0";
                txtTotalPaid.Text = "0";
                ViewState["Row"] = _dataTableItemsListRemove;
                rptrPurchaseItems.DataSource = ViewState["Row"];
                rptrPurchaseItems.DataBind();
                rptrPurchaseItems.Visible = false;
                txtTotalPaid.Enabled = false;
            }

           
        }

        #endregion


        #region
        #region Get Purchase Details From Purchase Form TextFields
        /// <summary>
        /// This Method is Used to Get Purchase Header Details From General Form TextFields to Purchase Header Object
        /// </summary>
        /// <returns></returns>
        private  PurchaseHeader GetPurchaseHeaderDetailsObject()
        {
            try
            {
                _objPurchaseHeaderBL = new PurchaseHeaderBL();

                _objPurchaseHeader.guid = Guid.NewGuid();
                _objPurchaseHeader.supplier_master_id = Convert.ToInt32(ddlPurchaseBy.SelectedValue);
                _objPurchaseHeader.purchase_items_quantity = Convert.ToInt32(_totalItemCount);
                _objPurchaseHeader.purchase_items_payment_by = ddlPaymentBy.SelectedValue;
                _objPurchaseHeader.purchase_items_reference_number = txtReffrenceNo.Text;
                _objPurchaseHeader.purchase_items_total_amount = Convert.ToInt32(txttotalAmount.Text);
                _objPurchaseHeader.purchase_items_pay_amount = Convert.ToInt32(txtTotalPaid.Text);
                _objPurchaseHeader.purchase_items_pending_amount = Convert.ToInt32(txtPendingAmount.Text);
                _objPurchaseHeader.purchase_item_discount = Convert.ToInt32(txtDiscount.Text);

                _objPurchaseHeader.purchase_item_remarks = txtRemarks.Text;


                _objPurchaseHeader.purchase_item_date = Convert.ToDateTime(System.DateTime.Now.ToString());
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

        #region Get Purchase Details From Purchase Form TextFields
        /// <summary>
        /// This Method is Used to Get Purchase Header Details From General Form TextFields to Purchase Header Object
        /// </summary>
        /// <returns></returns>
        private  PurchaseHeader GetPurchaseItemDetailsObject()
        {
            try
            {
                _objPurchaseItemBL = new PurchaseItemBL();

                _objPurchaseItem.guid = Guid.NewGuid();
                

                _objPurchaseHeader.purchase_item_remarks = txtRemarks.Text;


                _objPurchaseHeader.purchase_item_date = Convert.ToDateTime(System.DateTime.Now.ToString());
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


        #region Clear Form Method
        /// <summary>
        /// This Method is Used to Clear General Form Fields
        /// </summary>
        private void ClearPurchaseForm()
        {
            txtItemQuantity.Text = txtItemPrice.Text = txttotalAmount.Text = txtTotalPaid.Text = txtPendingAmount.Text = txtDiscount.Text = txtReffrenceNo.Text = txtRemarks.Text = string.Empty;

            ddlPaymentBy.SelectedItem.Text="";
            ddlItemTypeList.SelectedItem.Text="";
            ddlItemList.SelectedItem.Text="";
            BindItemTypeList();
            BindSupplierList();
            rptrPurchaseItems.DataSource = null;
            rptrPurchaseItems.DataBind();
            txtTotalPaid.Enabled = false;
            _totalItemCount = 0;
        }
        #endregion

        protected void rptrPurchaseItems_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                        deleteRowfromtable(Convert.ToInt32(hdfditemId.Value));
                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;

            }
        }

        protected void rptrPurchaseItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlPurchaseBy.SelectedValue == "0" || ddlPurchaseBy.SelectedValue == "" || ddlPurchaseBy.SelectedValue == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlertPurchasePartyName();", true);

                }
                else if (ddlItemTypeList.SelectedValue == "0" || ddlItemTypeList.SelectedValue == "" || ddlItemTypeList.SelectedValue == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlertItemTypeName();", true);

                }
                else if (ddlItemList.SelectedValue == "0" || ddlItemList.SelectedValue == "" || ddlItemList.SelectedValue == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlertItem();", true);

                }
                else if (txtItemQuantity.Text == "0" || txtItemQuantity.Text == "" || txtItemQuantity.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlertItemQuantity();", true);

                }
                else if (txtItemPrice.Text == "0" || txtItemPrice.Text == "" || txtItemPrice.Text == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlertItemPrice();", true);

                }
                else
                {
                    createtable();
                }


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["Row"] != null)
                {
                    _objPurchaseHeaderBL = new PurchaseHeaderBL();
                    _objPurchaseItemBL = new PurchaseItemBL();

                    _objPurchaseHeader = _objPurchaseHeaderBL.CreatePurchaseHeader(GetPurchaseHeaderDetailsObject());

                    if (_objPurchaseHeader.purchase_header_id > 0)
                    {
                        _dataTableItemsList = (DataTable)ViewState["Row"]; 
                         if (_dataTableItemsList.Rows.Count > 0)
                        {
                            int _purchaseItemSaveCount = 0;

                            for (int _rowIndexPosition = 0; _rowIndexPosition < _dataTableItemsList.Rows.Count; _rowIndexPosition++)
                            {
                                _objPurchaseItem.guid = Guid.NewGuid();
                                _objPurchaseItem.purchase_header_id = _objPurchaseHeader.purchase_header_id;
                                _objPurchaseItem.item_master_id = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["item_master_id"].ToString());
                                _objPurchaseItem.supplier_master_id = _objPurchaseHeader.supplier_master_id;
                                _objPurchaseItem.purchase_item_type_id = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["purchase_item_type_id"].ToString());
                                _objPurchaseItem.purchase_item_name = _dataTableItemsList.Rows[_rowIndexPosition]["purchase_item_name"].ToString();
                                _objPurchaseItem.purchase_item_quantity = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["purchase_item_quantity"].ToString());
                                
                                _objPurchaseItem.purchase_item_price = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["purchase_item_price"].ToString());

                                _objPurchaseItem = _objPurchaseItemBL.CreatePurchaseItem(_objPurchaseItem);
                                _purchaseItemSaveCount = _purchaseItemSaveCount + 1;
                            }

                            if (_purchaseItemSaveCount > 0)
                            {
                                ClearPurchaseForm();
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showPurchaseSuccess();", true);

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
            ClearPurchaseForm();
        }

        protected void txtTotalPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int _totalAmount, _totalPending, _totalPaid = 0;
                if(txtTotalPaid.Text ==null || txtTotalPaid.Text =="")
                {
                    txtTotalPaid.Text = "0";
                }
                _totalAmount = Convert.ToInt32(txttotalAmount.Text);
                _totalPending = Convert.ToInt32(txtPendingAmount.Text);
                _totalPaid = Convert.ToInt32(txtTotalPaid.Text);

                if (_totalPaid > _totalAmount)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                }
                else
                {
                    _totalPending = _totalAmount - _totalPaid;
                    txtPendingAmount.Text = _totalPending.ToString();
                }

            }
            catch ( Exception ex)
            {
                ex.Message.ToString();
            }
           

        }

        protected void ddlItemTypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlItemTypeList.SelectedIndex > 0)
            {
                    _objItemMasterBL = new ItemMasterBL();


                _lstvwItemListWithModelAndGlassColor = _objItemMasterBL.GetVwItemListWithModelAndGlassColors().Where(x => x.category == ddlItemTypeList.SelectedItem.Text).ToList();

                if (_lstvwItemListWithModelAndGlassColor.Count > 0)
                {

                    ddlItemList.DataSource = _lstvwItemListWithModelAndGlassColor;
                    ddlItemList.DataTextField = "modelwithglass";
                    ddlItemList.DataValueField = "item_master_id";
                    ddlItemList.DataBind();
                    ddlItemList.Items.Insert(0, new ListItem("Select", "Select"));
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
}