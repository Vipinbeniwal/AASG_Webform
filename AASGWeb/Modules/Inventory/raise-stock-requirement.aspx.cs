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
using System.Web.Services;
using App.BusinessModel;
using App.Business;

namespace AASGWeb.Modules.Inventory
{
    public partial class raise_stock_requirement : System.Web.UI.Page
    {
        DataTable _dataTableItemsList = new DataTable();

        StockIssuanceHeader _objStockIssuanceHeader = new StockIssuanceHeader();
        StockIssuanceHeaderBL _objStockIssuanceHeaderBL = null;
        List<StockIssuanceHeader> _lstStockIssuanceHeader = new List<StockIssuanceHeader>();

        StockIssuanceItem _objStockIssuanceItem = new StockIssuanceItem();
        StockIssuanceItemBL _objStockIssuanceItemBL = null;
        List<StockIssuanceItem> _lstStockIssuanceItem = new List<StockIssuanceItem>();

        DropdownMaster _objDropdownMaster = new DropdownMaster();
        DropdownMasterBL _objDropdownMasterBL = null;
        List<DropdownMaster> _lstDropdownMaster = new List<DropdownMaster>();

        StaffMaster _objStaffMaster = new StaffMaster();
        StaffMasterBL _objStaffMasterBL = null;
        List<StaffMaster> _lstStaffMaster = new List<StaffMaster>();


        List<vwItemListWithModelAndGlassColor> _lstvwItemListWithModelAndGlassColor = new List<vwItemListWithModelAndGlassColor>();


        protected void Page_Load(object sender, EventArgs e)
        {

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

                _objStaffMasterBL = new StaffMasterBL();

                _lstStaffMaster = _objStaffMasterBL.GetAllStaffMasterItems().Where(x => x.is_active == true).ToList();

                ddlEmployee.DataSource = _lstStaffMaster;

                ddlEmployee.DataTextField = "supplier_name";
                ddlEmployee.DataValueField = "supplier_master_id";
                ddlEmployee.DataBind();
                ddlEmployee.Items.Insert(0, new ListItem("Select", "Select"));

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }

        #endregion


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            List<ItemMaster> lstItemMasterWM = new List<ItemMaster>();
            ItemMaster objItemMaster = new ItemMaster();
            ItemMasterBL objItemMasterBL = new ItemMasterBL();
            objItemMaster = objItemMasterBL.GetItemMasterItemsByID(Convert.ToInt32(txtItemBatchNo.Text)).FirstOrDefault();
            if (objItemMaster != null)
            {
                txtBrand.Text = objItemMaster.brand;

            }
        }

        protected void rptrBatchItems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string commandname = e.CommandName;
            string id = e.CommandArgument.ToString();
            hdfdItemMasterId.Value = id;

            Int32 ID = Convert.ToInt32(id);
            switch (commandname)
            {

                case "delete":
                    try
                    {
                        DeleteDataRowItem(ID);

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;

            }
        }

        protected void rptrBatchItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            createtable();
        }

        private void DeleteDataRowItem(int id)
        {
            _dataTableItemsList = (DataTable)ViewState["Row"];
            for (int i = _dataTableItemsList.Rows.Count - 1; i >= 0; i--)
            {
                DataRow _dataRowItemsList2 = _dataTableItemsList.Rows[i];
                if (_dataRowItemsList2["item_master_id"].ToString() == Convert.ToInt32(id).ToString())
                {
                    _dataRowItemsList2.Delete();
                }
            }
        }

        #region Create Item Table at Run Time
        /// <summary>
        /// This Method is Used to Create Item Table at Run Time
        /// </summary>
        public void createtable()
        {

            _dataTableItemsList.Columns.Add("issuance_item_type_id", typeof(int));
            _dataTableItemsList.Columns.Add("item_master_id", typeof(int));
            _dataTableItemsList.Columns.Add("brand", typeof(string));
            _dataTableItemsList.Columns.Add("item_name", typeof(string));
            _dataTableItemsList.Columns.Add("item_quantity", typeof(string));
            _dataTableItemsList.Columns.Add("item_amount", typeof(string));

            rptrBatchItems.DataSource = _dataTableItemsList;
            rptrBatchItems.DataBind();
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
                    DataRow _dataRowItemsList = _dataTableItemsList.NewRow();
                    _dataRowItemsList["issuance_item_type_id"] = Convert.ToInt32(ddlItemTypeList.SelectedValue);
                    _dataRowItemsList["item_master_id"] = Convert.ToInt32(ddlItemList.SelectedValue);
                    _dataRowItemsList["brand"] = txtBrand.Text;
                    _dataRowItemsList["item_name"] = ddlItemList.SelectedItem.Text;
                    _dataRowItemsList["item_quantity"] = txtItemQuantity.Text;
                    _dataRowItemsList["item_amount"] = txtItemPrice.Text;
                    _dataTableItemsList.Rows.Add(_dataRowItemsList);
                    // _totalItemCount = _totalItemCount + Convert.ToInt32(txtItemQuantity.Text);
                    ViewState["Row"] = _dataTableItemsList;
                    if (_dataTableItemsList.Rows.Count > 0)
                    {
                        int _totalPiad = 0;
                        for (int i = 0; i < _dataTableItemsList.Rows.Count; i++)
                        {
                            _totalPiad += Convert.ToInt32(_dataTableItemsList.Rows[i]["purchase_item_price"].ToString());
                        }
                        // txttotalAmount.Text = _totalPiad.ToString();

                    }
                    rptrBatchItems.DataSource = ViewState["Row"];
                    rptrBatchItems.DataBind();
                    rptrBatchItems.Visible = true;
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlreadyPurchaseItemMaster();", true);
                    ViewState["Row"] = _dataTableItemsList;
                    rptrBatchItems.DataSource = ViewState["Row"];
                    rptrBatchItems.DataBind();
                    rptrBatchItems.Visible = true;

                }


            }
            else
            {

                DataRow _dataRowItemsList = _dataTableItemsList.NewRow();
                _dataRowItemsList["issuance_item_type_id"] = Convert.ToInt32(ddlItemTypeList.SelectedValue);
                _dataRowItemsList["item_master_id"] = Convert.ToInt32(ddlItemList.SelectedValue);
                _dataRowItemsList["brand"] = txtBrand.Text;
                _dataRowItemsList["item_name"] = ddlItemList.SelectedItem.Text;
                _dataRowItemsList["item_quantity"] = txtItemQuantity.Text;
                _dataRowItemsList["item_amount"] = txtItemPrice.Text;
                _dataTableItemsList.Rows.Add(_dataRowItemsList);
                ViewState["Row"] = _dataTableItemsList;
                if (_dataTableItemsList.Rows.Count > 0)
                {
                    int _totalPiad = 0;
                    for (int i = 0; i < _dataTableItemsList.Rows.Count; i++)
                    {
                        _totalPiad += Convert.ToInt32(_dataTableItemsList.Rows[i]["item_price"].ToString());
                    }
                    // txttotalAmount.Text = _totalPiad.ToString();
                }
                rptrBatchItems.DataSource = ViewState["Row"];
                rptrBatchItems.DataBind();
                rptrBatchItems.Visible = true;
            }
        }


        /// <summary>
        /// This Method is Used to Delete Item from Table at Run Time
        /// </summary>
        public void deleteRowfromtable(int _itemIdForRemove)
        {
            // Get  Repeater Values From View to Data Table
            _dataTableItemsList.Columns.Add("issuance_item_type_id", typeof(int));
            _dataTableItemsList.Columns.Add("item_master_id", typeof(int));
            _dataTableItemsList.Columns.Add("brand", typeof(string));
            _dataTableItemsList.Columns.Add("item_name", typeof(string));
            _dataTableItemsList.Columns.Add("item_quantity", typeof(string));
            _dataTableItemsList.Columns.Add("item_amount", typeof(string));

            rptrBatchItems.DataSource = _dataTableItemsList;
            rptrBatchItems.DataBind();

            _dataTableItemsList = (DataTable)ViewState["Row"];

            // Create New DataTable and Columns At Run Time
            DataTable _dataTableItemsListRemove = new DataTable();
            _dataTableItemsListRemove.Columns.Add("issuance_item_type_id", typeof(int));
            _dataTableItemsListRemove.Columns.Add("item_master_id", typeof(int));
            _dataTableItemsListRemove.Columns.Add("brand", typeof(string));
            _dataTableItemsListRemove.Columns.Add("item_name", typeof(string));
            _dataTableItemsListRemove.Columns.Add("item_quantity", typeof(string));
            _dataTableItemsListRemove.Columns.Add("item_amount", typeof(int));


            // Assing Datable Items To Another DataTable and Skip Selected Item  for Remove/Delete

            for (int _datatableRowIndexPostion = 0; _datatableRowIndexPostion < _dataTableItemsList.Rows.Count; _datatableRowIndexPostion++)
            {
                if (_dataTableItemsList.Rows[_datatableRowIndexPostion]["item_master_id"].ToString() != Convert.ToInt32(_itemIdForRemove).ToString())
                {
                    DataRow _dataRowItemsListRemove = _dataTableItemsListRemove.NewRow();

                    _dataRowItemsListRemove["issuance_item_type_id"] = Convert.ToInt32(_dataTableItemsList.Rows[_datatableRowIndexPostion]["issuance_item_type_id"]);
                    _dataRowItemsListRemove["item_master_id"] = Convert.ToInt32(_dataTableItemsList.Rows[_datatableRowIndexPostion]["item_master_id"]);
                    _dataRowItemsListRemove["brand"] = Convert.ToInt32(_dataTableItemsList.Rows[_datatableRowIndexPostion]["brand"]);
                    _dataRowItemsListRemove["item_name"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["item_name"];
                    _dataRowItemsListRemove["item_quantity"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["item_quantity"];
                    _dataRowItemsListRemove["item_amount"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["item_amount"];

                    // Add Values one -by one to New DataTable 
                    _dataTableItemsListRemove.Rows.Add(_dataRowItemsListRemove);

                    if (_dataTableItemsListRemove.Rows.Count > 0)
                    {
                        int _totalPiad = 0;
                        for (int RowIndexPostionForRemove = 0; RowIndexPostionForRemove < _dataTableItemsListRemove.Rows.Count; RowIndexPostionForRemove++)
                        {
                            _totalPiad += Convert.ToInt32(_dataTableItemsListRemove.Rows[RowIndexPostionForRemove]["purchase_item_price"].ToString());
                        }
                        // txttotalAmount.Text = _totalPiad.ToString();


                    }
                }
                else
                {
                    //  _totalItemCount = _totalItemCount - Convert.ToInt32(_dataTableItemsList.Rows[_datatableRowIndexPostion]["purchase_item_quantity"]);
                }

            }

            if (_dataTableItemsListRemove.Rows.Count > 0)
            {
                ViewState["Row"] = _dataTableItemsListRemove;
                rptrBatchItems.DataSource = ViewState["Row"];
                rptrBatchItems.DataBind();
                rptrBatchItems.Visible = true;

            }
            else
            {

                ViewState["Row"] = _dataTableItemsListRemove;
                rptrBatchItems.DataSource = ViewState["Row"];
                rptrBatchItems.DataBind();
                rptrBatchItems.Visible = false;

            }


        }




        #endregion

        #region Web Method

        //[WebMethod]
        //public static string GetItemBatchNoDetails(string ItemBatchNo)
        //{
        //    int ItemBNo = Convert.ToInt32(ItemBatchNo);
        //    List<ItemMaster> lstItemMasterWM = new List<ItemMaster>();
        //    var _JavaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        //    ItemMasterBL objItemMasterBL = new ItemMasterBL();

        //   // AddEmployee addEmployeePageObject = new AddEmployee();
        //    List<string> strList = new List<string>();
        //    int i = 0;
        //    lstItemMasterWM = objItemMasterBL.GetItemMasterItemsByID(ItemBNo);
        //    for (i = 0; i < lstItemMasterWM.Count(); i++)
        //    {
        //        strList.Add(lstItemMasterWM[i].item_master_id + "-" + lstItemMasterWM[i].brand + "-" + lstItemMasterWM[i].model + "-" + lstItemMasterWM[i].itemtype_id);
        //    }
        //    //return lstItemMasterWM.ToArray();
        //    return _JavaScriptSerializer.Serialize(lstItemMasterWM);
        //}

        #endregion Web Method

        protected void btnAddItemRequire_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["Row"] != null)
                {
                    _objStockIssuanceHeaderBL = new StockIssuanceHeaderBL();
                    _objStockIssuanceItemBL = new StockIssuanceItemBL();

                    _objStockIssuanceHeader = _objStockIssuanceHeaderBL.CreateStockIssuanceHeader(GetStockIssuanceHeaderDetailsObject());

                    if (_objStockIssuanceHeader.stock_issuance_header_id > 0)
                    {
                        _dataTableItemsList = (DataTable)ViewState["Row"];
                        if (_dataTableItemsList.Rows.Count > 0)
                        {
                            for (int i = 0; i < _dataTableItemsList.Rows.Count; i++)
                            {
                                _objStockIssuanceItem.guid = Guid.NewGuid();
                                _objStockIssuanceItem.stock_issuance_header_id = _objStockIssuanceHeader.stock_issuance_header_id;
                                _objStockIssuanceItem.item_master_id = Convert.ToInt32(_dataTableItemsList.Rows[i]["item_master_id"].ToString());
                                _objStockIssuanceItem.item_name = _dataTableItemsList.Rows[i]["item_type_name"].ToString();
                                _objStockIssuanceItem.item_quantity = Convert.ToInt32(_dataTableItemsList.Rows[i]["item_quantity"].ToString());
                                _objStockIssuanceItem.item_amount = Convert.ToInt32(_dataTableItemsList.Rows[i]["item_price"].ToString());

                                _objStockIssuanceItem = _objStockIssuanceItemBL.CreateStockIssuanceItem(_objStockIssuanceItem);
                            }

                        }
                        else
                        {

                        }
                        if (_objStockIssuanceItem.stock_issuance_item_id != 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccess();", true);

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
        private StockIssuanceHeader GetStockIssuanceHeaderDetailsObject()
        {
            try
            {
                _objStockIssuanceHeaderBL = new StockIssuanceHeaderBL();

                _objStockIssuanceHeader.guid = Guid.NewGuid();
                _objStockIssuanceHeader.items_total_quantity = Convert.ToInt32(txtItemQuantity.Text);
                _objStockIssuanceHeader.items_total_amount = 0;
                _objStockIssuanceHeader.item_remarks = txtRemarks.Text;
                //_objStockIssuanceHeader.item_require_date = Convert.ToDateTime(txtRequireDate.Text);
                _objStockIssuanceHeader.item_require_date = DateTime.ParseExact(txtRequireDate.Text, "dd/MM/yyyy", null);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objStockIssuanceHeader;
        }

        protected void ddlItemTypeList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}