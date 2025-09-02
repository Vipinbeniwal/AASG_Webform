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

namespace AASGWeb.Modules.Xp_Master
{
    public partial class add_customer_request : System.Web.UI.Page
    {
        #region Global Properties


        xp_ProcurementHeader _objxp_ProcurementHeader = new xp_ProcurementHeader();
        xp_ProcurementHeaderBL _objxp_ProcurementHeaderBL = null;
        List<xp_ProcurementHeader> _lstxp_ProcurementHeader = new List<xp_ProcurementHeader>();

        xp_ProcurementItem _objxp_ProcurementItem = new xp_ProcurementItem();
        App.Business.xp_ProcurementItemBL _objxp_ProcurementItemBL = null;
        List<xp_ProcurementItem> _lstxp_ProcurementItem = new List<xp_ProcurementItem>();

        xp_ItemMaster _objxp_ItemMaster = new xp_ItemMaster();
        xp_ItemMasterBL _objxp_ItemMasterBL = null;
        List<xp_ItemMaster> _lstxp_ItemMaster = new List<xp_ItemMaster>();

        DropdownMaster _objDropdownMaster = new DropdownMaster();
        DropdownMasterBL _objDropdownMasterBL = null;
        List<DropdownMaster> _lstDropdownMaster = new List<DropdownMaster>();
        

        string UserIp = string.Empty;
        
        public static int _totalItemCount = 0;
        DataTable _dataTableItemsList = new DataTable();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindItemTypeList();
                //BindSupplierList();
               
                _totalItemCount = 0;


            }
        }


        #region

        private void BindItemTypeList()
        {
            try
            {

                _objxp_ItemMasterBL = new xp_ItemMasterBL();

                _lstxp_ItemMaster = _objxp_ItemMasterBL.GetAllxp_ItemMasterItems().Where(x => x.is_active == true).ToList();

                ddlItemList.DataSource = _lstxp_ItemMaster;

                ddlItemList.DataTextField = "item_name";
                ddlItemList.DataValueField = "xp_item_master_id";
                ddlItemList.DataBind();
                ddlItemList.Items.Insert(0, new ListItem("Select", "Select"));


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

            _dataTableItemsList.Columns.Add("item_master_id", typeof(int));
            _dataTableItemsList.Columns.Add("purchase_item_name", typeof(string));
            _dataTableItemsList.Columns.Add("brand", typeof(string));
            _dataTableItemsList.Columns.Add("purchase_item_quantity", typeof(string));
            

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
                        _alreadyCount = _alreadyCount + 1;
                    }
                }

                if (_alreadyCount == 0)
                {
                    DataRow _dataRowItemsList = _dataTableItemsList.NewRow();
                    _dataRowItemsList["item_master_id"] = Convert.ToInt32(ddlItemList.SelectedValue);
                    _dataRowItemsList["purchase_item_name"] = ddlItemList.SelectedItem.Text;
                    _dataRowItemsList["purchase_item_quantity"] = txtItemQuantity.Text;
                    _dataRowItemsList["brand"] = txtBrand.Text;
                   
                    _dataTableItemsList.Rows.Add(_dataRowItemsList);
                    _totalItemCount = _totalItemCount + Convert.ToInt32(txtItemQuantity.Text);
                    ViewState["Row"] = _dataTableItemsList;
                   
                    rptrPurchaseItems.DataSource = ViewState["Row"];
                    rptrPurchaseItems.DataBind();
                    rptrPurchaseItems.Visible = true;
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlreadyPurchasexp_ItemMaster();", true);
                    ViewState["Row"] = _dataTableItemsList;
                    rptrPurchaseItems.DataSource = ViewState["Row"];
                    rptrPurchaseItems.DataBind();
                    rptrPurchaseItems.Visible = true;
                    
                }

            }
            else
            {
                DataRow _dataRowItemsList = _dataTableItemsList.NewRow();
                _dataRowItemsList["item_master_id"] = Convert.ToInt32(ddlItemList.SelectedValue);
                _dataRowItemsList["purchase_item_name"] = ddlItemList.SelectedItem.Text;
                _dataRowItemsList["purchase_item_quantity"] = txtItemQuantity.Text;
                _dataRowItemsList["brand"] = txtBrand.Text;
               
                _dataTableItemsList.Rows.Add(_dataRowItemsList);
                _totalItemCount = _totalItemCount + Convert.ToInt32(txtItemQuantity.Text);
                ViewState["Row"] = _dataTableItemsList;
                
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

            _dataTableItemsList.Columns.Add("item_master_id", typeof(int));
            _dataTableItemsList.Columns.Add("purchase_item_name", typeof(string));
            _dataTableItemsList.Columns.Add("brand", typeof(string));
            _dataTableItemsList.Columns.Add("purchase_item_quantity", typeof(string));
            _dataTableItemsList.Columns.Add("purchase_item_price", typeof(int));

            rptrPurchaseItems.DataSource = _dataTableItemsList;
            rptrPurchaseItems.DataBind();

            _dataTableItemsList = (DataTable)ViewState["Row"];

            // Create New DataTable and Columns At Run Time
            DataTable _dataTableItemsListRemove = new DataTable();

            _dataTableItemsListRemove.Columns.Add("item_master_id", typeof(int));
            _dataTableItemsListRemove.Columns.Add("purchase_item_name", typeof(string));
            _dataTableItemsListRemove.Columns.Add("brand", typeof(string));
            _dataTableItemsListRemove.Columns.Add("purchase_item_quantity", typeof(string));
           

            // Assing Datable Items To Another DataTable and Skip Selected Item  for Remove/Delete

            for (int _datatableRowIndexPostion = 0; _datatableRowIndexPostion < _dataTableItemsList.Rows.Count; _datatableRowIndexPostion++)
            {
                if (_dataTableItemsList.Rows[_datatableRowIndexPostion]["item_master_id"].ToString() != Convert.ToInt32(_itemIdForRemove).ToString())
                {
                    DataRow _dataRowItemsListRemove = _dataTableItemsListRemove.NewRow();

                    _dataRowItemsListRemove["purchase_item_type_id"] = Convert.ToInt32(_dataTableItemsList.Rows[_datatableRowIndexPostion]["purchase_item_type_id"]);
                    _dataRowItemsListRemove["item_master_id"] = Convert.ToInt32(_dataTableItemsList.Rows[_datatableRowIndexPostion]["item_master_id"]);
                    _dataRowItemsListRemove["purchase_item_name"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["purchase_item_name"];
                    _dataRowItemsListRemove["brand"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["brand"];
                    _dataRowItemsListRemove["purchase_item_quantity"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["purchase_item_quantity"];
                    
                    // Add Values one -by one to New DataTable 
                    _dataTableItemsListRemove.Rows.Add(_dataRowItemsListRemove);

                    if (_dataTableItemsListRemove.Rows.Count > 0)
                    {
                        int _totalPiad = 0;
                        for (int RowIndexPostionForRemove = 0; RowIndexPostionForRemove < _dataTableItemsListRemove.Rows.Count; RowIndexPostionForRemove++)
                        {
                            _totalPiad += Convert.ToInt32(_dataTableItemsListRemove.Rows[RowIndexPostionForRemove]["purchase_item_price"].ToString());
                        }
                       
                    }
                }
                else
                {
                    _totalItemCount = _totalItemCount - Convert.ToInt32(_dataTableItemsList.Rows[_datatableRowIndexPostion]["purchase_item_quantity"]);
                }

            }

            if (_dataTableItemsListRemove.Rows.Count > 0)
            {
                ViewState["Row"] = _dataTableItemsListRemove;
                rptrPurchaseItems.DataSource = ViewState["Row"];
                rptrPurchaseItems.DataBind();
                rptrPurchaseItems.Visible = true;
                
            }
            else
            {
               
                ViewState["Row"] = _dataTableItemsListRemove;
                rptrPurchaseItems.DataSource = ViewState["Row"];
                rptrPurchaseItems.DataBind();
                rptrPurchaseItems.Visible = false;
               
            }


        }

        #endregion
        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            createtable();
        }

        protected void rptrPurchaseItems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void rptrPurchaseItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}