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

namespace AASGWeb.Modules.Admin
{
    public partial class add_time_sheet : System.Web.UI.Page
    {
        #region Global Properties


        App.BusinessModel.xp_TimeSheetHeader _objxp_TimeSheetHeader = new App.BusinessModel.xp_TimeSheetHeader();
        App.Business.xp_TimeSheetHeaderBL _objxp_TimeSheetHeaderBL = null;
        List<App.BusinessModel.xp_TimeSheetHeader> _lstxp_TimeSheetHeader = new List<App.BusinessModel.xp_TimeSheetHeader>();

        App.BusinessModel.xp_TimeSheetChild _objxp_TimeSheetChild = new App.BusinessModel.xp_TimeSheetChild();
        App.Business.xp_TimeSheetChildBL _objxp_TimeSheetChildBL = null;
        List<App.BusinessModel.xp_TimeSheetChild> _lstxp_TimeSheetChild = new List<App.BusinessModel.xp_TimeSheetChild>();

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
                BindProjectList();
                  // BindSupplierList();

                  _totalItemCount = 0;
                btnSubmit.Visible = false;
                BtnReset.Visible = false;


            }
        }



        #region

        private void BindProjectList()
        {
            try
            {

                _objDropdownMasterBL = new DropdownMasterBL();

                _lstDropdownMaster = _objDropdownMasterBL.GetAllDropdownMasterItems().Where(x => x.dropdown_type == "Project").ToList();

                ddlProjectName.DataSource = _lstDropdownMaster;

                ddlProjectName.DataTextField = "dropdown_item_name";
                ddlProjectName.DataValueField = "dropdown_master_id";
                ddlProjectName.DataBind();
                ddlProjectName.Items.Insert(0, new ListItem("Select", "Select"));


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
            _dataTableItemsList.Columns.Add("project_id", typeof(int));
            _dataTableItemsList.Columns.Add("project_name", typeof(string));
            _dataTableItemsList.Columns.Add("date", typeof(DateTime));
            _dataTableItemsList.Columns.Add("hours", typeof(string));
            _dataTableItemsList.Columns.Add("remarks", typeof(string));

            rptrTimeSheetChildItems.DataSource = _dataTableItemsList;
            rptrTimeSheetChildItems.DataBind();
            if (ViewState["Row"] != null)
            {
                int _alreadyCount = 0;
                _dataTableItemsList = (DataTable)ViewState["Row"];

                for (int _datatableRowIndexPostion = 0; _datatableRowIndexPostion < _dataTableItemsList.Rows.Count; _datatableRowIndexPostion++)
                {
                    if (_dataTableItemsList.Rows[_datatableRowIndexPostion]["project_id"].ToString() == Convert.ToInt32(ddlProjectName.SelectedValue).ToString())
                    {
                        _alreadyCount = _alreadyCount + 1;
                    }
                }

                if (_alreadyCount == 0)
                {
                    DataRow _dataRowItemsList = _dataTableItemsList.NewRow();
                    _dataRowItemsList["project_id"] = Convert.ToInt32(ddlProjectName.SelectedValue);
                    _dataRowItemsList["project_name"] = ddlProjectName.SelectedItem.Text;
                    _dataRowItemsList["date"] = Convert.ToDateTime(txtDate.Text);
                    _dataRowItemsList["hours"] = txthours.Text;
                    _dataRowItemsList["remarks"] = txtremarks.Text;
                    _dataTableItemsList.Rows.Add(_dataRowItemsList);
                    _totalItemCount = _totalItemCount + Convert.ToInt32(txthours.Text);
                    ViewState["Row"] = _dataTableItemsList;
                    //if (_dataTableItemsList.Rows.Count > 0)
                    //{
                    //    int _totalPiad = 0;
                    //    for (int i = 0; i < _dataTableItemsList.Rows.Count; i++)
                    //    {
                    //        _totalPiad += Convert.ToInt32(_dataTableItemsList.Rows[i]["hours"].ToString());
                    //    }
                    //   // txttotalAmount.Text = _totalPiad.ToString();
                       
                    //}
                    rptrTimeSheetChildItems.DataSource = ViewState["Row"];
                    rptrTimeSheetChildItems.DataBind();
                    rptrTimeSheetChildItems.Visible = true;
                    btnSubmit.Visible = true;
                    BtnReset.Visible = true;
                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAllreadyTimeSheet();", true);
                    ViewState["Row"] = _dataTableItemsList;
                    rptrTimeSheetChildItems.DataSource = ViewState["Row"];
                    rptrTimeSheetChildItems.DataBind();
                    rptrTimeSheetChildItems.Visible = true;
                   
                }

            }
            else
            {
                DataRow _dataRowItemsList = _dataTableItemsList.NewRow();
                _dataRowItemsList["project_id"] = Convert.ToInt32(ddlProjectName.SelectedValue);
                _dataRowItemsList["project_name"] = ddlProjectName.SelectedItem.Text;
                _dataRowItemsList["date"] = Convert.ToDateTime(txtDate.Text);
                _dataRowItemsList["hours"] = txthours.Text;
                _dataRowItemsList["remarks"] = txtremarks.Text;
                _dataTableItemsList.Rows.Add(_dataRowItemsList);
                _totalItemCount = _totalItemCount + Convert.ToInt32(txthours.Text);
                ViewState["Row"] = _dataTableItemsList;
                //if (_dataTableItemsList.Rows.Count > 0)
                //{
                //    int _totalPiad = 0;
                //    for (int i = 0; i < _dataTableItemsList.Rows.Count; i++)
                //    {
                //        _totalPiad += Convert.ToInt32(_dataTableItemsList.Rows[i]["hours"].ToString());
                //    }
                //    //txttotalAmount.Text = _totalPiad.ToString();
                //    //txtPendingAmount.Text = "0";
                //    //txtTotalPaid.Text = "0";
                //    //txtTotalPaid.Enabled = true;
                //}
                rptrTimeSheetChildItems.DataSource = ViewState["Row"];
                rptrTimeSheetChildItems.DataBind();
                rptrTimeSheetChildItems.Visible = true;
                btnSubmit.Visible = true;
                BtnReset.Visible = true;
            }
        }

        /// <summary>
        /// This Method is Used to Delete Item from Table at Run Time
        /// </summary>
        //public void deleteRowfromtable(int _itemIdForRemove)
        //{
        //    // Get  Repeater Values From View to Data Table
        //    _dataTableItemsList.Columns.Add("project_id", typeof(int));
        //    _dataTableItemsList.Columns.Add("project_name", typeof(string));
        //    _dataTableItemsList.Columns.Add("date", typeof(DateTime));
        //    _dataTableItemsList.Columns.Add("hours", typeof(string));
        //    _dataTableItemsList.Columns.Add("remarks", typeof(string));

        //    rptrTimeSheetChildItems.DataSource = _dataTableItemsList;
        //    rptrTimeSheetChildItems.DataBind();

        //    _dataTableItemsList = (DataTable)ViewState["Row"];

        //    // Create New DataTable and Columns At Run Time
        //    DataTable _dataTableItemsListRemove = new DataTable();
        //    _dataTableItemsListRemove.Columns.Add("purchase_item_type_id", typeof(int));
        //    _dataTableItemsListRemove.Columns.Add("item_master_id", typeof(int));
        //    _dataTableItemsListRemove.Columns.Add("purchase_item_name", typeof(string));
        //    _dataTableItemsListRemove.Columns.Add("purchase_item_quantity", typeof(string));
        //    _dataTableItemsListRemove.Columns.Add("purchase_item_price", typeof(int));


        //    // Assing Datable Items To Another DataTable and Skip Selected Item  for Remove/Delete

        //    for (int _datatableRowIndexPostion = 0; _datatableRowIndexPostion < _dataTableItemsList.Rows.Count; _datatableRowIndexPostion++)
        //    {
        //        if (_dataTableItemsList.Rows[_datatableRowIndexPostion]["item_master_id"].ToString() != Convert.ToInt32(_itemIdForRemove).ToString())
        //        {
        //            DataRow _dataRowItemsListRemove = _dataTableItemsListRemove.NewRow();

        //            _dataRowItemsListRemove["purchase_item_type_id"] = Convert.ToInt32(_dataTableItemsList.Rows[_datatableRowIndexPostion]["purchase_item_type_id"]);
        //            _dataRowItemsListRemove["item_master_id"] = Convert.ToInt32(_dataTableItemsList.Rows[_datatableRowIndexPostion]["item_master_id"]);
        //            _dataRowItemsListRemove["purchase_item_name"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["purchase_item_name"];
        //            _dataRowItemsListRemove["purchase_item_quantity"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["purchase_item_quantity"];
        //            _dataRowItemsListRemove["purchase_item_price"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["purchase_item_price"];

        //            // Add Values one -by one to New DataTable 
        //            _dataTableItemsListRemove.Rows.Add(_dataRowItemsListRemove);

        //            if (_dataTableItemsListRemove.Rows.Count > 0)
        //            {
        //                int _totalPiad = 0;
        //                for (int RowIndexPostionForRemove = 0; RowIndexPostionForRemove < _dataTableItemsListRemove.Rows.Count; RowIndexPostionForRemove++)
        //                {
        //                    _totalPiad += Convert.ToInt32(_dataTableItemsListRemove.Rows[RowIndexPostionForRemove]["purchase_item_price"].ToString());
        //                }
        //                //txttotalAmount.Text = _totalPiad.ToString();
        //                //txtPendingAmount.Text = "0";
        //                //txtTotalPaid.Text = "0";

        //            }
        //        }
        //        else
        //        {
        //            _totalItemCount = _totalItemCount - Convert.ToInt32(_dataTableItemsList.Rows[_datatableRowIndexPostion]["purchase_item_quantity"]);
        //        }

        //    }

        //    if (_dataTableItemsListRemove.Rows.Count > 0)
        //    {
        //        ViewState["Row"] = _dataTableItemsListRemove;
        //        rptrTimeSheetChildItems.DataSource = ViewState["Row"];
        //        rptrTimeSheetChildItems.DataBind();
        //        rptrTimeSheetChildItems.Visible = true;

        //    }
        //    else
        //    {

        //        ViewState["Row"] = _dataTableItemsListRemove;
        //        rptrTimeSheetChildItems.DataSource = ViewState["Row"];
        //        rptrTimeSheetChildItems.DataBind();
        //        rptrTimeSheetChildItems.Visible = false;

        //    }


        //}

        #endregion


        #region
        #region Get xp_TimeSheetChild From xp_TimeSheetChild Form TextFields
        /// <summary>
        /// This Method is Used to Get xp_TimeSheetChild Details From General Form TextFields to xp_TimeSheetChild Object
        /// </summary>
        /// <returns></returns>
        private App.BusinessModel.xp_TimeSheetHeader Getxp_TimeSheetHeaderDetailsObject()
        {
            try
            {


                _objxp_TimeSheetHeader.guid = Guid.NewGuid();
                _objxp_TimeSheetHeader.staff_master_id = 1;
                _objxp_TimeSheetHeader.staff_name = "Deepak";
                _objxp_TimeSheetHeader.total_hours = _totalItemCount.ToString();
                _objxp_TimeSheetHeader.remarks = txtremarks.Text ;
                _objxp_TimeSheetHeader.is_approved = false;
                _objxp_TimeSheetHeader.status = App.Helper.Utils.OrderStatus.pending.ToString();
                _objxp_TimeSheetHeader.approved_by = "";
                _objxp_TimeSheetHeader.approved_date = Convert.ToDateTime(System.DateTime.Now.ToString());

                //Convert.ToDateTime(_objStaffMaster.staff_joinning_date).ToString("MM/dd/yyyy");


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objxp_TimeSheetHeader;
        }

        #endregion

        #region Get xp_TimeSheetChild Details From xp_TimeSheetChild Form TextFields
        /// <summary>
        /// This Method is Used to Get xp_TimeSheetChild Details From General Form TextFields to xp_TimeSheetChild Object
        /// </summary>
        /// <returns></returns>
        private App.BusinessModel.xp_TimeSheetHeader Getxp_TimeSheetChildDetailsObject()
        {
            try
            {
                _objxp_TimeSheetHeader.guid = Guid.NewGuid();


                _objxp_TimeSheetHeader.staff_master_id = 1;

                //Convert.ToDateTime(_objStaffMaster.staff_joinning_date).ToString("MM/dd/yyyy");


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objxp_TimeSheetHeader;
        }

        #endregion

        #endregion

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["Row"] != null)
                {
                    _objxp_TimeSheetHeaderBL = new xp_TimeSheetHeaderBL();
                    _objxp_TimeSheetChildBL = new xp_TimeSheetChildBL();

                    _objxp_TimeSheetHeader = _objxp_TimeSheetHeaderBL.Createxp_TimeSheetHeader(Getxp_TimeSheetHeaderDetailsObject());

                    if (_objxp_TimeSheetHeader.time_sheet_header_id > 0)
                    {
                        _dataTableItemsList = (DataTable)ViewState["Row"];
                        if (_dataTableItemsList.Rows.Count > 0)
                        {
                            int _timechildItemSaveCount = 0;

                            for (int _rowIndexPosition = 0; _rowIndexPosition < _dataTableItemsList.Rows.Count; _rowIndexPosition++)
                            {
                                _objxp_TimeSheetChild.guid = Guid.NewGuid();
                                _objxp_TimeSheetChild.time_sheet_header_id = _objxp_TimeSheetHeader.time_sheet_header_id;
                                _objxp_TimeSheetChild.staff_master_id = _objxp_TimeSheetHeader.staff_master_id;
                                _objxp_TimeSheetChild.staff_name = _objxp_TimeSheetHeader.staff_name;

                                _objxp_TimeSheetChild.project_id = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["project_id"].ToString());
                                _objxp_TimeSheetChild.project_name = _dataTableItemsList.Rows[_rowIndexPosition]["project_name"].ToString();
                                _objxp_TimeSheetChild.time_sheet_date = Convert.ToDateTime(_dataTableItemsList.Rows[_rowIndexPosition]["date"].ToString());
                                _objxp_TimeSheetChild.hours = _dataTableItemsList.Rows[_rowIndexPosition]["hours"].ToString();

                                _objxp_TimeSheetChild.remarks = _dataTableItemsList.Rows[_rowIndexPosition]["remarks"].ToString();

                                _objxp_TimeSheetChild = _objxp_TimeSheetChildBL.Createxp_TimeSheetChild(_objxp_TimeSheetChild);
                                _timechildItemSaveCount = _timechildItemSaveCount + 1;
                            }

                            if (_timechildItemSaveCount > 0)
                            {
                               // ClearPurchaseForm();
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccess();", true);

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

        protected void btnTimeChildList_Click(object sender, EventArgs e)
        {
            createtable();
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            txthours.Text = txtremarks.Text = string.Empty;
            btnSubmit.Visible = false;
            BtnReset.Visible = false;
        }

        protected void rptrTimeSheetChildItems_ItemCommand(object source, RepeaterCommandEventArgs e)
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
                       // deleteRowfromtable(Convert.ToInt32(hdfditemId.Value));
                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;

            }
        }

        protected void rptrTimeSheetChildItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}