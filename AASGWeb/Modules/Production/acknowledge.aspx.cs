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

namespace AASGWeb.Modules.Production
{
    public partial class acknowledge : System.Web.UI.Page
    {
        #region Global Properties
        ActivityLog _objActivityLog = new ActivityLog();
        ActivityLogBL _objActivityLogBL = null;
        List<ActivityLog> _lstActivityLog = new List<ActivityLog>();

        UserRole _objUserRole = new UserRole();
        UserRoleBL _objUserRoleBL = null;
        List<UserRole> _lstUserRole = new List<UserRole>();

        ItemMaster _objItemMaster = new ItemMaster();
        ItemMasterBL _objItemMasterBL = null;
        List<ItemMaster> _lstItemMaster = new List<ItemMaster>();

        vwItemListWithModelAndGlassColor _objItemListWithModelAndGlassColor = new vwItemListWithModelAndGlassColor();

        List<vwItemListWithModelAndGlassColor> _lstvwItemListWithModelAndGlassColor = new List<vwItemListWithModelAndGlassColor>();

        DrawingMaster _objDrawingMaster = new DrawingMaster();
        DrawingMasterBL _objDrawingMasterBL = null;
        List<DrawingMaster> _lstDrawingMaster = new List<DrawingMaster>();

        string UserIp = string.Empty;
        public static byte[] bytes;
        public static int _totalItemCount = 0;
        DataTable _dataTableItemsList = new DataTable();
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string _ProductionMasterid;
               // BindItemsName();
                if (RouteData.Values["id"] == null)
                {
                    // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "editorInit();", true);
                }
                else
                {

                    string _production_master_id = RouteData.Values["id"].ToString();
                    _ProductionMasterid = App.Core.DataSecurity.Decryptdata(_production_master_id);
                    if (_ProductionMasterid == "" || _ProductionMasterid == null)
                    {
                        Response.Redirect("/home", false);
                    }
                    else
                    {
                        hdnfAcknowledgeProductionId.Value = _ProductionMasterid;

                        if (hdnfAcknowledgeProductionId.Value == "")
                        {
                            Response.Redirect("/home", false);

                        }
                        else
                        {
                         //   PopulateData(_drawingMasterid);

                        }

                    }


                }

            }
        }

        private void BindItemsName()
        {
            try
            {
                _objItemMasterBL = new ItemMasterBL();
                _lstvwItemListWithModelAndGlassColor = _objItemMasterBL.GetVwItemListWithModelAndGlassColors().OrderBy(x => x.model).ToList();
                ddlItemList.DataSource = _lstvwItemListWithModelAndGlassColor;
                ddlItemList.DataTextField = "modelwithglass";
                ddlItemList.DataValueField = "item_master_id";
                ddlItemList.DataBind();
                ddlItemList.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                btnAddItem.Visible = false;
                createtable();
                
                
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }
        }

        protected void btnShowMoreItemField_Click(object sender, EventArgs e)
        {
            try
            {
                btnAddItem.Visible = false;
                divMoreItemAdd.Visible = true;
                BindItemsName();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        protected void rptrAcknowledgeItemsList_ItemCommand(object source, RepeaterCommandEventArgs e)
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

        protected void rptrAcknowledgeItemsList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }


        #region Create Item Table at Run Time
        /// <summary>
        /// This Method is Used to Create Item Table at Run Time
        /// </summary>
        public void createtableForMoreItem()
        {
            
            _dataTableItemsList.Columns.Add("item_master_id", typeof(int));
            _dataTableItemsList.Columns.Add("item_name", typeof(string));
            _dataTableItemsList.Columns.Add("item_quantity_per_sheet", typeof(int));
            _dataTableItemsList.Columns.Add("item_pcs_total_expectation", typeof(int));

            rptrAcknowledgeItemsList.DataSource = _dataTableItemsList;
            rptrAcknowledgeItemsList.DataBind();
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
                    _dataRowItemsList["item_name"] = ddlItemList.SelectedItem.Text;
                    _dataRowItemsList["item_quantity_per_sheet"] = txtItemQuantityPerSheetfromMore.Text;
                    _dataRowItemsList["item_pcs_total_expectation"] = txtTotalExpectationfromMore.Text;
                    _dataTableItemsList.Rows.Add(_dataRowItemsList);
                    _totalItemCount = _totalItemCount + Convert.ToInt32(txtTotalExpectationfromMore.Text);
                    ViewState["Row"] = _dataTableItemsList;
                    //if (_dataTableItemsList.Rows.Count > 0)
                    //{
                    //    int _totalPiad = 0;
                    //    for (int i = 0; i < _dataTableItemsList.Rows.Count; i++)
                    //    {
                    //        _totalPiad += Convert.ToInt32(_dataTableItemsList.Rows[i]["purchase_item_price"].ToString());
                    //    }
                        
                    //}
                    rptrAcknowledgeItemsList.DataSource = ViewState["Row"];
                    rptrAcknowledgeItemsList.DataBind();
                    rptrAcknowledgeItemsList.Visible = true;
                    btnShowMoreItemField.Visible = true;
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlreadyPurchaseItemMaster();", true);
                    ViewState["Row"] = _dataTableItemsList;
                    rptrAcknowledgeItemsList.DataSource = ViewState["Row"];
                    rptrAcknowledgeItemsList.DataBind();
                    rptrAcknowledgeItemsList.Visible = true;
                    btnShowMoreItemField.Visible = true;

                }

            }
            else
            {
                DataRow _dataRowItemsList = _dataTableItemsList.NewRow();
                _dataRowItemsList["item_master_id"] = Convert.ToInt32(ddlItemList.SelectedValue);
                _dataRowItemsList["item_name"] = ddlItemList.SelectedItem.Text;
                _dataRowItemsList["item_quantity_per_sheet"] = txtItemQuantityPerSheetfromMore.Text;
                _dataRowItemsList["item_pcs_total_expectation"] = txtTotalExpectationfromMore.Text;
                _dataTableItemsList.Rows.Add(_dataRowItemsList);
                _totalItemCount = _totalItemCount + Convert.ToInt32(txtTotalExpectationfromMore.Text);
                ViewState["Row"] = _dataTableItemsList;
                //if (_dataTableItemsList.Rows.Count > 0)
                //{
                //    int _totalPiad = 0;
                //    for (int i = 0; i < _dataTableItemsList.Rows.Count; i++)
                //    {
                //        _totalPiad += Convert.ToInt32(_dataTableItemsList.Rows[i]["purchase_item_price"].ToString());
                //    }
                   
                //}
                rptrAcknowledgeItemsList.DataSource = ViewState["Row"];
                rptrAcknowledgeItemsList.DataBind();
                rptrAcknowledgeItemsList.Visible = true;
                btnShowMoreItemField.Visible = true;
            }
        }



        public void createtable()
        {

            _dataTableItemsList.Columns.Add("item_master_id", typeof(int));
            _dataTableItemsList.Columns.Add("item_name", typeof(string));
            _dataTableItemsList.Columns.Add("item_quantity_per_sheet", typeof(int));
            _dataTableItemsList.Columns.Add("item_pcs_total_expectation", typeof(int));

            rptrAcknowledgeItemsList.DataSource = _dataTableItemsList;
            rptrAcknowledgeItemsList.DataBind();
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

                    _dataRowItemsList["item_master_id"] = Convert.ToInt32(txtThickness.Text);
                    _dataRowItemsList["item_name"] = txtItemName.Text;
                    _dataRowItemsList["item_quantity_per_sheet"] = txtQuantityPerSheet.Text;
                    _dataRowItemsList["item_pcs_total_expectation"] = txttotalExpectation.Text;
                    _dataTableItemsList.Rows.Add(_dataRowItemsList);
                    _totalItemCount = _totalItemCount + Convert.ToInt32(txttotalExpectation.Text);
                    ViewState["Row"] = _dataTableItemsList;
                    //if (_dataTableItemsList.Rows.Count > 0)
                    //{
                    //    int _totalPiad = 0;
                    //    for (int i = 0; i < _dataTableItemsList.Rows.Count; i++)
                    //    {
                    //        _totalPiad += Convert.ToInt32(_dataTableItemsList.Rows[i]["purchase_item_price"].ToString());
                    //    }

                    //}
                    rptrAcknowledgeItemsList.DataSource = ViewState["Row"];
                    rptrAcknowledgeItemsList.DataBind();
                    rptrAcknowledgeItemsList.Visible = true;
                    btnShowMoreItemField.Visible = true;
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlreadyPurchaseItemMaster();", true);
                    ViewState["Row"] = _dataTableItemsList;
                    rptrAcknowledgeItemsList.DataSource = ViewState["Row"];
                    rptrAcknowledgeItemsList.DataBind();
                    rptrAcknowledgeItemsList.Visible = true;
                    btnShowMoreItemField.Visible = true;

                }

            }
            else
            {
                DataRow _dataRowItemsList = _dataTableItemsList.NewRow();
                _dataRowItemsList["item_master_id"] = Convert.ToInt32(txtThickness.Text);
                _dataRowItemsList["item_name"] = txtItemName.Text;
                _dataRowItemsList["item_quantity_per_sheet"] = txtQuantityPerSheet.Text;
                _dataRowItemsList["item_pcs_total_expectation"] = txttotalExpectation.Text;
                _dataTableItemsList.Rows.Add(_dataRowItemsList);
                _totalItemCount = _totalItemCount + Convert.ToInt32(txttotalExpectation.Text);
                ViewState["Row"] = _dataTableItemsList;
                //if (_dataTableItemsList.Rows.Count > 0)
                //{
                //    int _totalPiad = 0;
                //    for (int i = 0; i < _dataTableItemsList.Rows.Count; i++)
                //    {
                //        _totalPiad += Convert.ToInt32(_dataTableItemsList.Rows[i]["purchase_item_price"].ToString());
                //    }

                //}
                rptrAcknowledgeItemsList.DataSource = ViewState["Row"];
                rptrAcknowledgeItemsList.DataBind();
                rptrAcknowledgeItemsList.Visible = true;
                btnShowMoreItemField.Visible = true;
            }
        }



        /// <summary>
        /// This Method is Used to Delete Item from Table at Run Time
        /// </summary>
        public void deleteRowfromtable(int _itemIdForRemove)
        {
            // Get  Repeater Values From View to Data Table
            _dataTableItemsList.Columns.Add("item_master_id", typeof(int));
            _dataTableItemsList.Columns.Add("item_name", typeof(string));
            _dataTableItemsList.Columns.Add("item_quantity_per_sheet", typeof(int));
            _dataTableItemsList.Columns.Add("item_pcs_total_expectation", typeof(int));

            rptrAcknowledgeItemsList.DataSource = _dataTableItemsList;
            rptrAcknowledgeItemsList.DataBind();

            _dataTableItemsList = (DataTable)ViewState["Row"];

            // Create New DataTable and Columns At Run Time
            DataTable _dataTableItemsListRemove = new DataTable();
            _dataTableItemsListRemove.Columns.Add("item_master_id", typeof(int));
            _dataTableItemsListRemove.Columns.Add("item_name", typeof(string));
            _dataTableItemsListRemove.Columns.Add("item_quantity_per_sheet", typeof(int));
            _dataTableItemsListRemove.Columns.Add("item_pcs_total_expectation", typeof(int));


            // Assing Datable Items To Another DataTable and Skip Selected Item  for Remove/Delete

            for (int _datatableRowIndexPostion = 0; _datatableRowIndexPostion < _dataTableItemsList.Rows.Count; _datatableRowIndexPostion++)
            {
                if (_dataTableItemsList.Rows[_datatableRowIndexPostion]["item_master_id"].ToString() != Convert.ToInt32(_itemIdForRemove).ToString())
                {
                    DataRow _dataRowItemsListRemove = _dataTableItemsListRemove.NewRow();

                   
                    _dataRowItemsListRemove["item_master_id"] = Convert.ToInt32(_dataTableItemsList.Rows[_datatableRowIndexPostion]["item_master_id"]);
                    _dataRowItemsListRemove["item_name"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["item_name"];
                    _dataRowItemsListRemove["item_quantity_per_sheet"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["item_quantity_per_sheet"];
                    _dataRowItemsListRemove["item_pcs_total_expectation"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["item_pcs_total_expectation"];

                    // Add Values one -by one to New DataTable 
                    _dataTableItemsListRemove.Rows.Add(_dataRowItemsListRemove);

                    //if (_dataTableItemsListRemove.Rows.Count > 0)
                    //{
                    //    int _totalPiad = 0;
                    //    for (int RowIndexPostionForRemove = 0; RowIndexPostionForRemove < _dataTableItemsListRemove.Rows.Count; RowIndexPostionForRemove++)
                    //    {
                    //        _totalPiad += Convert.ToInt32(_dataTableItemsListRemove.Rows[RowIndexPostionForRemove]["purchase_item_price"].ToString());
                    //    }
                       
                    //}
                }
                else
                {
                    _totalItemCount = _totalItemCount - Convert.ToInt32(_dataTableItemsList.Rows[_datatableRowIndexPostion]["item_pcs_total_expectation"]);
                }

            }

            if (_dataTableItemsListRemove.Rows.Count > 0)
            {
                ViewState["Row"] = _dataTableItemsListRemove;
                rptrAcknowledgeItemsList.DataSource = ViewState["Row"];
                rptrAcknowledgeItemsList.DataBind();
                rptrAcknowledgeItemsList.Visible = true;
                
            }
            else
            {
                
                ViewState["Row"] = _dataTableItemsListRemove;
                rptrAcknowledgeItemsList.DataSource = ViewState["Row"];
                rptrAcknowledgeItemsList.DataBind();
                rptrAcknowledgeItemsList.Visible = false;
               
            }


        }

        #endregion

    }
}