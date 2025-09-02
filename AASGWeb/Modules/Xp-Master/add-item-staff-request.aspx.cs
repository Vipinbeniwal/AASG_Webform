using App.Business;
using App.BusinessModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AASGWeb.Modules.Xp_Master
{
    public partial class add_item_staff_request : System.Web.UI.Page
    {
        #region Global Properties
        ActivityLog _objActivityLog = new ActivityLog();
        ActivityLogBL _objActivityLogBL = null;
        List<ActivityLog> _lstActivityLog = new List<ActivityLog>();

        StaffMaster _objStaffMaster = new StaffMaster();
        StaffMasterBL _objStaffMasterBL = null;
        List<StaffMaster> _lstStaffMaster = new List<StaffMaster>();

        xp_ItemMaster _objxpItemMaster = new xp_ItemMaster();
        xp_ItemMasterBL _objxpItemMasterBL = null;
        List<xp_ItemMaster> _lstpItemMaster = new List<xp_ItemMaster>();

        DataTable _dataTableItemsList = new DataTable();
        public static int _totalItemCount = 0;
        string UserIp = string.Empty;
        
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropdownMaster();
                BindItemMaster();
                _totalItemCount = 0;
            }
        }
        private void BindDropdownMaster()
        {
            try
            {
                List<DropdownMaster> _lstDropdownMaster = new List<DropdownMaster>();
                DropdownMasterBL _objDropdownMasterBL = new DropdownMasterBL();

                _lstDropdownMaster = _objDropdownMasterBL.GetAllDropdownMasterItems().Where(x => x.dropdown_type == "Designation").ToList();
                ddlDepartment.DataSource = _lstDropdownMaster;

                ddlDepartment.DataTextField = "dropdown_item_name";
                ddlDepartment.DataValueField = "dropdown_master_id";
                ddlDepartment.DataBind();
                ddlDepartment.Items.Insert(0, new ListItem("Select", "Select"));

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }

        private void BindItemMaster()
        {
            try
            {
                List<xp_ItemMaster> _lstxpItemMaster = new List<xp_ItemMaster>();
                _objxpItemMasterBL = new xp_ItemMasterBL();

                _lstxpItemMaster = _objxpItemMasterBL.GetAllxp_ItemMasterItems().Where(x=>x.item_quantity>0).ToList();

                ddlItemName.DataSource = _lstxpItemMaster;

                ddlItemName.DataTextField = "item_name";
                ddlItemName.DataValueField = "xp_item_master_id";
                ddlItemName.DataBind();
                ddlItemName.Items.Insert(0, new ListItem("Select", "Select"));

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }

        protected void ddlItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlItemName.SelectedIndex > 0)
            {
                _objxpItemMasterBL = new xp_ItemMasterBL();

                _objxpItemMaster = _objxpItemMasterBL.GetAllxp_ItemMasterItems().Where(x => x.xp_item_master_id == Convert.ToInt32(ddlItemName.SelectedValue)).FirstOrDefault();
                if (_objxpItemMaster!=null)
                {
                    txtSerialNumber.Text = _objxpItemMaster.item_serial_number;
                    txtSerialNumber.Enabled = false;
                    txtBrandName.Text = _objxpItemMaster.item_brand;
                    txtBrandName.Enabled = false;
                }
                else
                {
                    txtSerialNumber.Text = "";
                    txtSerialNumber.Enabled = false;
                    txtBrandName.Text = "";
                    txtBrandName.Enabled = false;
                }
            }
        }

        public void createtable()
        {
            _dataTableItemsList.Columns.Add("department_name", typeof(string));
            _dataTableItemsList.Columns.Add("department_id", typeof(int));
            _dataTableItemsList.Columns.Add("xp_item_master_id", typeof(int));
            _dataTableItemsList.Columns.Add("item_serial_number", typeof(string));
            _dataTableItemsList.Columns.Add("item_name", typeof(string));
            _dataTableItemsList.Columns.Add("item_brand", typeof(string));   
            _dataTableItemsList.Columns.Add("item_quantity", typeof(int));
            // _dataTableItemsList.Columns.Add("item_price", typeof(int));

            rptrXItems.DataSource = _dataTableItemsList;
            rptrXItems.DataBind();
            if (ViewState["Row"] != null)
            {
                int _alreadyCount = 0;
                _dataTableItemsList = (DataTable)ViewState["Row"];

                for (int _datatableRowIndexPostion = 0; _datatableRowIndexPostion < _dataTableItemsList.Rows.Count; _datatableRowIndexPostion++)
                {
                    if (_dataTableItemsList.Rows[_datatableRowIndexPostion]["xp_item_master_id"].ToString() == Convert.ToInt32(ddlItemName.SelectedValue).ToString())
                    {
                        _alreadyCount = _alreadyCount + 1;
                    }
                }

                if (_alreadyCount == 0)
                {
                    DataRow _dataRowItemsList = _dataTableItemsList.NewRow();
                    _dataRowItemsList["department_name"] = ddlDepartment.SelectedItem.Text;
                    _dataRowItemsList["department_id"] = Convert.ToInt32(ddlDepartment.SelectedValue);
                    _dataRowItemsList["xp_item_master_id"] = Convert.ToInt32(ddlItemName.SelectedValue);
                    _dataRowItemsList["item_serial_number"] = txtSerialNumber.Text;
                    _dataRowItemsList["item_name"] = ddlItemName.SelectedItem.Text;
                    _dataRowItemsList["item_brand"] = txtBrandName.Text;
                    _dataRowItemsList["item_quantity"] = txtItemQuantity.Text;
                    _dataTableItemsList.Rows.Add(_dataRowItemsList);
                    _totalItemCount = _totalItemCount + Convert.ToInt32(txtItemQuantity.Text);
                    ViewState["Row"] = _dataTableItemsList;
                    
                    rptrXItems.DataSource = ViewState["Row"];
                    rptrXItems.DataBind();
                    rptrXItems.Visible = true;
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlreadyPurchaseItemMaster();", true);
                    ViewState["Row"] = _dataTableItemsList;
                    rptrXItems.DataSource = ViewState["Row"];
                    rptrXItems.DataBind();
                    rptrXItems.Visible = true;
                }

            }
            else
            {
                DataRow _dataRowItemsList = _dataTableItemsList.NewRow();
                _dataRowItemsList["department_name"] = ddlDepartment.SelectedItem.Text;
                _dataRowItemsList["department_id"] = Convert.ToInt32(ddlDepartment.SelectedValue);
                _dataRowItemsList["xp_item_master_id"] = Convert.ToInt32(ddlItemName.SelectedValue);
                _dataRowItemsList["item_serial_number"] = txtSerialNumber.Text;
                _dataRowItemsList["item_name"] = ddlItemName.SelectedItem.Text;
                _dataRowItemsList["item_brand"] = txtBrandName.Text;
                _dataRowItemsList["item_quantity"] = txtItemQuantity.Text;
                _dataTableItemsList.Rows.Add(_dataRowItemsList);
                _totalItemCount = _totalItemCount + Convert.ToInt32(txtItemQuantity.Text);
                ViewState["Row"] = _dataTableItemsList;

                rptrXItems.DataSource = ViewState["Row"];
                rptrXItems.DataBind();
                rptrXItems.Visible = true;
            }
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            createtable();
        }

        protected void rptrXItems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void rptrXItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //if (ViewState["Row"] != null)
                //{
                //    _objPurchaseHeaderBL = new PurchaseHeaderBL();
                //    _objPurchaseItemBL = new PurchaseItemBL();

                //    _objPurchaseHeader = _objPurchaseHeaderBL.CreatePurchaseHeader(GetPurchaseHeaderDetailsObject());

                //    if (_objPurchaseHeader.purchase_header_id > 0)
                //    {
                //        _dataTableItemsList = (DataTable)ViewState["Row"];
                //        if (_dataTableItemsList.Rows.Count > 0)
                //        {
                //            int _purchaseItemSaveCount = 0;

                //            for (int _rowIndexPosition = 0; _rowIndexPosition < _dataTableItemsList.Rows.Count; _rowIndexPosition++)
                //            {
                //                _objPurchaseItem.guid = Guid.NewGuid();
                //                _objPurchaseItem.purchase_header_id = _objPurchaseHeader.purchase_header_id;
                //                _objPurchaseItem.item_master_id = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["item_master_id"].ToString());
                //                _objPurchaseItem.supplier_master_id = _objPurchaseHeader.supplier_master_id;
                //                _objPurchaseItem.purchase_item_type_id = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["purchase_item_type_id"].ToString());
                //                _objPurchaseItem.purchase_item_name = _dataTableItemsList.Rows[_rowIndexPosition]["purchase_item_name"].ToString();
                //                _objPurchaseItem.purchase_item_quantity = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["purchase_item_quantity"].ToString());

                //                _objPurchaseItem.purchase_item_price = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["purchase_item_price"].ToString());

                //                _objPurchaseItem = _objPurchaseItemBL.CreatePurchaseItem(_objPurchaseItem);
                //                _purchaseItemSaveCount = _purchaseItemSaveCount + 1;
                //            }

                //            if (_purchaseItemSaveCount > 0)
                //            {
                //                ClearPurchaseForm();
                //                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showPurchaseSuccess();", true);

                //            }
                //        }
                //        else
                //        {
                //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                //        }


                //        // ClearGeneralForm();

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


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
        }
    }
}