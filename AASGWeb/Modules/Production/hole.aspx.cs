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
    public partial class hole : System.Web.UI.Page
    {
        #region Global Properties

        ProcessHole _objProcessHole = new ProcessHole();
        ProcessHoleBL _objProcessHoleBL = null;
        List<ProcessHole> _lstProcessHole = new List<ProcessHole>();

        ItemMaster _objItemMaster = new ItemMaster();
        ItemMasterBL _objItemMasterBL = null;
        List<ItemMaster> _lstItemMaster = new List<ItemMaster>();

        ProductionTrail _objProductionTrail = new ProductionTrail();
        ProductionTrailBL _objProductionTrailBL = null;
        List<ProductionTrail> _lstProductionTrail = new List<ProductionTrail>();

        App.BusinessModel.Production _objProduction = new App.BusinessModel.Production();
        ProductionBL _objProductionBL = null;
        List<App.BusinessModel.Production> _lstProduction = new List<App.BusinessModel.Production>();

        //DataTable _dataTableItemsList = new DataTable();
        DataTable _dataTableItemsBreakageList = new DataTable();
        DataTable _dataTableItemsRejectList = new DataTable();
        string UserIp = string.Empty;
        
        string[] arrOfSelectionsPcsNumber, arrOfSelectionsRejectPcsNumber;
        string[] arrOfSelectionsBreakReason, arrOfSelectionsRejectReason;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {

                string ItemId;
                if (RouteData.Values["id"] == null)
                {
                    // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "editorInit();", true);
                }
                else
                {
                    string _holeItemid = RouteData.Values["id"].ToString();
                    ItemId = App.Core.DataSecurity.Decryptdata(_holeItemid);
                    if (ItemId == "" || ItemId == null)
                    {
                        Response.Redirect("/home", false);
                    }
                    else
                    {
                        hdnItemId.Value = ItemId;

                        if (hdnItemId.Value == "")
                        {
                            Response.Redirect("/home", false);

                        }
                        else
                        {
                            PopulateData(ItemId);
                        }

                    }
                }
                // PopulateData("1");
                // createtable();
               
                txtFinalTransferred.ReadOnly = true;
                txtreceived.ReadOnly = true;
            }
        }
        private void PopulateData(string ItemId)
        {
            try
            {
                hdnItemId.Value = ItemId;
                Int32 ProcessHoleID = Convert.ToInt32(ItemId);

                _objProcessHoleBL = new ProcessHoleBL();

                _objProcessHole = _objProcessHoleBL.GetAllProcessHoleItems().Where(x => x.process_hole_id == Convert.ToInt32(ProcessHoleID)).FirstOrDefault();

                //_objProcessHoleBL = new ProcessHoleBL();
                //ProcessHole _objProcessHole = new ProcessHole();
                //_lstProcessHole = _objProcessHoleBL.GetAllProcessHoleItems().Where(x=>x.process_cutting_id==Convert.ToInt32(_ProcessHoleid)).ToList();
                if (_objProcessHole != null)
                {
                    _objItemMasterBL = new ItemMasterBL();
                    _objItemMaster = _objItemMasterBL.GetItemMasterItemsByID(_objProcessHole.item_master_id).FirstOrDefault();
                    if (_objItemMaster.item_master_id > 0)
                    {
                       
                    }


                   

                    txtreceived.Text = _objProcessHole.total_received.ToString();
                    txtbreakage.Text = _objProcessHole.total_broken.ToString();
                    txtReject.Text = _objProcessHole.total_reject.ToString();
                    txtFinalTransferred.Text = _objProcessHole.total_pcs_transferred.ToString();
                    ddlSignature.SelectedValue = _objProcessHole.signature.ToString();
                    txtRemarks.Text = _objProcessHole.remarks;
                    if (_objProcessHole.total_broken > 0)
                    {
                        bindBreakageReason(_objProcessHole.total_broken);
                    }
                    else
                    {

                    }


                    if (_objProcessHole.total_reject > 0)
                    {
                        bindRejectReason(_objProcessHole.total_reject);
                    }
                    else
                    {

                    }
                   

                    if (_objProcessHole.total_pcs_transferred > 0)
                    {
                        txtFinalTransferred.Text = _objProcessHole.total_pcs_transferred.ToString();
                        txtbreakage.ReadOnly = true;
                        txtReject.ReadOnly = txtRemarks.ReadOnly = true;
                        btnUpdateData.Visible = false;
                        btnResetData.Visible = false;
                    }
                }
                else
                {
                    txtFinalTransferred.Text = txtreceived.Text;
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        private void bindBreakageReason(int total_broken)
        {
            Int32 ProcessHoleID = Convert.ToInt32(hdnItemId.Value);

            _objProcessHoleBL = new ProcessHoleBL();

            _objProcessHole = _objProcessHoleBL.GetAllProcessHoleItems().Where(x => x.process_hole_id == Convert.ToInt32(ProcessHoleID)).FirstOrDefault();
            if (_objProcessHole != null)
            {
                txtbreakage.Text = total_broken.ToString();
               

                _dataTableItemsBreakageList.Columns.Add("Pcs_Reject_id", typeof(int));
                _dataTableItemsBreakageList.Columns.Add("PcsNo", typeof(string));
                _dataTableItemsBreakageList.Columns.Add("Reason", typeof(string));

                rptrBreakagePcsItemList.DataSource = _dataTableItemsBreakageList;
                rptrBreakagePcsItemList.DataBind();

                
                if (_objProcessHole.breakage_pcs_number == null)
                {

                }
                else
                {
                    string breakagePcsNumber = _objProcessHole.breakage_pcs_number;
                    string lasttmPcsNumber = breakagePcsNumber.TrimEnd(',');
                    arrOfSelectionsPcsNumber = lasttmPcsNumber.Split(',');
                }
                if (_objProcessHole.breakage_reason == null)
                {

                }
                else
                {
                    string breason = _objProcessHole.breakage_reason;
                    string lasttm = breason.TrimEnd(',');
                    arrOfSelectionsBreakReason = lasttm.Split(',');
                }


                int _numberOfPcs = 0;


                for (int _PcsNumberPosition = 0; _PcsNumberPosition < arrOfSelectionsPcsNumber.Length; _PcsNumberPosition++)
                {
                    DataRow _dataRowItemsList = _dataTableItemsBreakageList.NewRow();
                    _dataRowItemsList["Pcs_Reject_id"] = _numberOfPcs + 1;
                    _dataRowItemsList["PcsNo"] = arrOfSelectionsPcsNumber[_PcsNumberPosition];
                    _dataRowItemsList["Reason"] = arrOfSelectionsBreakReason[_PcsNumberPosition];
                    _dataTableItemsBreakageList.Rows.Add(_dataRowItemsList);
                    ViewState["Row"] = _dataTableItemsBreakageList;
                }

                rptrBreakagePcsItemList.Visible = true;
                rptrBreakagePcsItemList.DataSource = ViewState["Row"];
                rptrBreakagePcsItemList.DataBind();
            }
        }
        private void bindRejectReason(int total_reject)
        {
            Int32 ProcessHoleID = Convert.ToInt32(hdnItemId.Value);

            _objProcessHoleBL = new ProcessHoleBL();

            _objProcessHole = _objProcessHoleBL.GetAllProcessHoleItems().Where(x => x.process_hole_id == Convert.ToInt32(ProcessHoleID)).FirstOrDefault();
            if (_objProcessHole != null)
            {
                txtReject.Text = total_reject.ToString();
               

                _dataTableItemsRejectList.Columns.Add("Pcs_Reject_id", typeof(int));
                _dataTableItemsRejectList.Columns.Add("PcsNo", typeof(string));
                _dataTableItemsRejectList.Columns.Add("Reason", typeof(string));

                rptrRejectPcsItemList.DataSource = _dataTableItemsRejectList;
                rptrRejectPcsItemList.DataBind();

                
                if (_objProcessHole.reject_pcs_number == null)
                {
                }
                else
                {
                    string rejectPcsNumber = _objProcessHole.reject_pcs_number;
                    string lasttmPcsNumber = rejectPcsNumber.TrimEnd(',');
                    arrOfSelectionsRejectPcsNumber = lasttmPcsNumber.Split(',');
                }
                if (_objProcessHole.reject_reason == null)
                {

                }
                else
                {
                    string rejectReason = _objProcessHole.reject_reason;
                    string lasttm = rejectReason.TrimEnd(',');
                    arrOfSelectionsRejectReason = lasttm.Split(',');
                }


                int _numberOfPcs = 0;


                for (int _PcsNumberPosition = 0; _PcsNumberPosition < arrOfSelectionsRejectPcsNumber.Length; _PcsNumberPosition++)
                {
                    DataRow _dataRowItemsList = _dataTableItemsRejectList.NewRow();
                    _dataRowItemsList["Pcs_Reject_id"] = _numberOfPcs + 1;
                    _dataRowItemsList["PcsNo"] = arrOfSelectionsRejectPcsNumber[_PcsNumberPosition];
                    _dataRowItemsList["Reason"] = arrOfSelectionsRejectReason[_PcsNumberPosition];
                    _dataTableItemsRejectList.Rows.Add(_dataRowItemsList);
                    ViewState["Row"] = _dataTableItemsRejectList;
                }


                rptrRejectPcsItemList.Visible = true;
                rptrRejectPcsItemList.DataSource = ViewState["Row"];
                rptrRejectPcsItemList.DataBind();
            }
        }

       

        protected void txtReject_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtReject.Text == "0" || txtReject.Text == "")
                {
                    rptrRejectPcsItemList.Visible = false;
                    calculate();
                }
                else
                {
                    if (Convert.ToInt32(txtReject.Text) > Convert.ToInt32(txtreceived.Text))
                    {
                        rptrBreakagePcsItemList.Visible = false;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingDetailError();", true);
                    }
                    else
                    {
                        createRejectTable();
                        calculate();
                    }
                }
            }
            catch( Exception ex)
            {
                ex.Message.ToString();
            }
           
        }

        protected void txtbreakage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtbreakage.Text == "0" || txtbreakage.Text == "")
                {
                    rptrBreakagePcsItemList.Visible = false;
                    calculate();
                }
                else
                {
                    if (Convert.ToInt32(txtbreakage.Text) > Convert.ToInt32(txtreceived.Text))
                    {
                        rptrRejectPcsItemList.Visible = false;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingDetailError();", true);
                    }
                    else
                    {
                        createtable();
                        calculate();
                    }
                }
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }
           
        }

        protected void rptrBreakagePcsItemList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void rptrBreakagePcsItemList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {

                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    DropDownList ddlBreakageReason = (DropDownList)e.Item.FindControl("ddlBreakageReason");

                    Label lblBreakagePcsNo = (Label)e.Item.FindControl("lblBreakagePcsNo");
                    TextBox txtBreakagePcsNumber = (TextBox)e.Item.FindControl("txtBreakagePcsNumber");

                    Label lblBreakageReason = (Label)e.Item.FindControl("lblBreakageReason");


                    //if (lblBreakagePcsNo.Text == "")
                    //{

                    //    txtBreakagePcsNumber.Visible = true;
                    //    lblBreakagePcsNo.Visible = false;
                    //}
                    //else
                    //{
                    //    txtBreakagePcsNumber.Visible = false;
                    //    lblBreakagePcsNo.Visible = true;

                    //}
                    if (lblBreakageReason.Text == "")
                    {

                        ddlBreakageReason.Visible = true;
                        lblBreakageReason.Visible = false;
                        txtBreakagePcsNumber.Visible = true;
                        lblBreakagePcsNo.Visible = false;
                    }
                    else
                    {
                        ddlBreakageReason.Visible = false;
                        lblBreakageReason.Visible = true;
                        ddlBreakageReason.SelectedValue = lblBreakageReason.Text;
                        txtBreakagePcsNumber.Visible = false;
                        lblBreakagePcsNo.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        protected void rptrRejectPcsItemList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void rptrRejectPcsItemList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {

                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    DropDownList ddlRejectReason = (DropDownList)e.Item.FindControl("ddlRejectReason");
                    Label lblRejectPcsNo = (Label)e.Item.FindControl("lblRejectPcsNo");
                    TextBox txtRejectPcsNumber = (TextBox)e.Item.FindControl("txtRejectPcsNumber");
                    Label lblRejectReason = (Label)e.Item.FindControl("lblRejectReason");


                    //if (lblRejectPcsNo.Text == "")
                    //{

                    //    txtRejectPcsNumber.Visible = true;
                    //    lblRejectPcsNo.Visible = false;
                    //}
                    //else
                    //{
                    //    txtRejectPcsNumber.Visible = false;
                    //    lblRejectPcsNo.Visible = true;

                    //}
                    if (lblRejectReason.Text == "")
                    {

                        ddlRejectReason.Visible = true;
                        lblRejectReason.Visible = false;
                        txtRejectPcsNumber.Visible = true;
                        lblRejectPcsNo.Visible = false;
                    }
                    else
                    {
                        ddlRejectReason.Visible = false;
                        lblRejectReason.Visible = true;
                        ddlRejectReason.SelectedValue = lblRejectReason.Text;
                        txtRejectPcsNumber.Visible = false;
                        lblRejectPcsNo.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        #region Create Item Table at Run Time
        /// <summary>
        /// This Method is Used to Create Item Table at Run Time for Reject Table
        /// </summary>
        public void createtable()
        {
            #region Get Data table Header Columns name/Text

            //for (int j = 0; j < _dataTableItemsList.Rows.Count; j++)
            //{
            //    for (int i = 0; i < _dataTableItemsList.Columns.Count; i++)
            //    {
            //        string _txt = _dataTableItemsList.Columns[i].ColumnName + " ";
            //        string _txt2 = _dataTableItemsList.Rows[j].ItemArray[i] + " ";

            //    }
            //}

            #endregion

            try
            {
                _dataTableItemsBreakageList.Columns.Add("Pcs_Breakage_id", typeof(int));
                _dataTableItemsBreakageList.Columns.Add("PcsNo", typeof(string));
                _dataTableItemsBreakageList.Columns.Add("Reason", typeof(string));

                rptrBreakagePcsItemList.DataSource = _dataTableItemsBreakageList;
                rptrBreakagePcsItemList.DataBind();
                if (ViewState["Row"] != null)
                {

                    if (txtbreakage.Text == "0" && txtbreakage.Text == "")
                    {
                    }
                    else
                    {
                        for (int _numberOfPcs = 0; _numberOfPcs < Convert.ToInt32(txtbreakage.Text); _numberOfPcs++)
                        {
                            DataRow _dataRowItemsList = _dataTableItemsBreakageList.NewRow();
                            _dataRowItemsList["Pcs_Breakage_id"] = _numberOfPcs + 1;
                            _dataRowItemsList["PcsNo"] = (_numberOfPcs + 1);

                            _dataTableItemsBreakageList.Rows.Add(_dataRowItemsList);
                            ViewState["Row"] = _dataTableItemsBreakageList;
                        }

                    }

                    rptrBreakagePcsItemList.DataSource = ViewState["Row"];
                    rptrBreakagePcsItemList.DataBind();
                    rptrBreakagePcsItemList.Visible = true;

                }
                else
                {

                    if (txtbreakage.Text == "0" && txtbreakage.Text == "")
                    {
                    }
                    else
                    {
                        for (int _numberOfPcs = 0; _numberOfPcs < Convert.ToInt32(txtbreakage.Text); _numberOfPcs++)
                        {
                            DataRow _dataRowItemsList = _dataTableItemsBreakageList.NewRow();
                            _dataRowItemsList["Pcs_Breakage_id"] = _numberOfPcs + 1;
                            _dataRowItemsList["PcsNo"] = (_numberOfPcs + 1);

                            _dataTableItemsBreakageList.Rows.Add(_dataRowItemsList);
                            ViewState["Row"] = _dataTableItemsBreakageList;
                        }
                    }


                    rptrBreakagePcsItemList.DataSource = ViewState["Row"];
                    rptrBreakagePcsItemList.DataBind();
                    rptrBreakagePcsItemList.Visible = true;
                }
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }

           
        }

        public void calculate()
        {
            try
            {
                int _finalReject, _finalBroken, _finalTransferred = 0;
                if (txtbreakage.Text == null || txtbreakage.Text == "")
                {
                    txtbreakage.Text = "0";
                }
                if (txtReject.Text == null || txtReject.Text == "")
                {
                    txtReject.Text = "0";
                }

                if (txtFinalTransferred.Text == null || txtFinalTransferred.Text == "")
                {
                    txtFinalTransferred.Text = "0";
                    txtFinalTransferred.Text = txtreceived.Text;

                }
                else
                {
                    txtFinalTransferred.Text = txtreceived.Text;
                }

                _finalReject = Convert.ToInt32(txtReject.Text);
                _finalBroken = Convert.ToInt32(txtbreakage.Text);
                _finalTransferred = Convert.ToInt32(txtFinalTransferred.Text);

                if (_finalTransferred < (_finalBroken + _finalReject))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingDetailError();", true);
                }
                else
                {
                    _finalTransferred = _finalTransferred - (_finalBroken + _finalReject);
                    txtFinalTransferred.Text = _finalTransferred.ToString();
                    txtFinalTransferred.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            

        }

        /// <summary>
        /// This Method is Used to Create Item Table at Run Time for Reject Table
        /// </summary>
        public void createRejectTable()
        {
            try
            {
                _dataTableItemsRejectList.Columns.Add("Pcs_Reject_id", typeof(int));
                _dataTableItemsRejectList.Columns.Add("PcsNo", typeof(string));
                _dataTableItemsRejectList.Columns.Add("Reason", typeof(string));

                rptrRejectPcsItemList.DataSource = _dataTableItemsRejectList;
                rptrRejectPcsItemList.DataBind();

                if (ViewState["Row"] != null)
                {


                    if (txtReject.Text == "0" && txtReject.Text == "")
                    {
                    }
                    else
                    {

                        for (int _numberOfPcs = 0; _numberOfPcs < Convert.ToInt32(txtReject.Text); _numberOfPcs++)
                        {
                            DataRow _dataRowItemsList = _dataTableItemsRejectList.NewRow();
                            _dataRowItemsList["Pcs_Reject_id"] = _numberOfPcs + 1;
                            _dataRowItemsList["PcsNo"] = (_numberOfPcs + 1);

                            _dataTableItemsRejectList.Rows.Add(_dataRowItemsList);
                            ViewState["Row"] = _dataTableItemsRejectList;
                        }

                    }

                    rptrRejectPcsItemList.DataSource = ViewState["Row"];
                    rptrRejectPcsItemList.DataBind();
                    rptrRejectPcsItemList.Visible = true;

                }
                else
                {

                    if (txtReject.Text == "0" && txtReject.Text == "")
                    {
                    }
                    else
                    {
                        for (int _numberOfPcs = 0; _numberOfPcs < Convert.ToInt32(txtReject.Text); _numberOfPcs++)
                        {
                            DataRow _dataRowItemsList = _dataTableItemsRejectList.NewRow();
                            _dataRowItemsList["Pcs_Reject_id"] = _numberOfPcs + 1;
                            _dataRowItemsList["PcsNo"] = (_numberOfPcs + 1);

                            _dataTableItemsRejectList.Rows.Add(_dataRowItemsList);
                            ViewState["Row"] = _dataTableItemsRejectList;
                        }
                    }


                    rptrRejectPcsItemList.DataSource = ViewState["Row"];
                    rptrRejectPcsItemList.DataBind();
                    rptrRejectPcsItemList.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            
            

        }

        /// <summary>
        /// This Method is Used to Delete Item from Table at Run Time
        /// </summary>
        public void deleteRowfromtable(int _itemIdForRemove)
        {
            // Get  Repeater Values From View to Data Table
            //_dataTableItemsList.Columns.Add("purchase_item_type_id", typeof(int));
            //_dataTableItemsList.Columns.Add("item_master_id", typeof(int));
            //_dataTableItemsList.Columns.Add("purchase_item_name", typeof(string));
            //_dataTableItemsList.Columns.Add("purchase_item_quantity", typeof(string));
            //_dataTableItemsList.Columns.Add("purchase_item_price", typeof(int));

            //rptrBreakagePcsItemList.DataSource = _dataTableItemsList;
            //rptrBreakagePcsItemList.DataBind();

            //_dataTableItemsList = (DataTable)ViewState["Row"];

            //// Create New DataTable and Columns At Run Time
            //DataTable _dataTableItemsListRemove = new DataTable();
            //_dataTableItemsListRemove.Columns.Add("purchase_item_type_id", typeof(int));
            //_dataTableItemsListRemove.Columns.Add("item_master_id", typeof(int));
            //_dataTableItemsListRemove.Columns.Add("purchase_item_name", typeof(string));
            //_dataTableItemsListRemove.Columns.Add("purchase_item_quantity", typeof(string));
            //_dataTableItemsListRemove.Columns.Add("purchase_item_price", typeof(int));


            //// Assing Datable Items To Another DataTable and Skip Selected Item  for Remove/Delete

            //for (int _datatableRowIndexPostion = 0; _datatableRowIndexPostion < _dataTableItemsList.Rows.Count; _datatableRowIndexPostion++)
            //{
            //    if (_dataTableItemsList.Rows[_datatableRowIndexPostion]["item_master_id"].ToString() != Convert.ToInt32(_itemIdForRemove).ToString())
            //    {
            //        DataRow _dataRowItemsListRemove = _dataTableItemsListRemove.NewRow();

            //        _dataRowItemsListRemove["purchase_item_type_id"] = Convert.ToInt32(_dataTableItemsList.Rows[_datatableRowIndexPostion]["purchase_item_type_id"]);
            //        _dataRowItemsListRemove["item_master_id"] = Convert.ToInt32(_dataTableItemsList.Rows[_datatableRowIndexPostion]["item_master_id"]);
            //        _dataRowItemsListRemove["purchase_item_name"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["purchase_item_name"];
            //        _dataRowItemsListRemove["purchase_item_quantity"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["purchase_item_quantity"];
            //        _dataRowItemsListRemove["purchase_item_price"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["purchase_item_price"];

            //        // Add Values one -by one to New DataTable 
            //        _dataTableItemsListRemove.Rows.Add(_dataRowItemsListRemove);

            //        if (_dataTableItemsListRemove.Rows.Count > 0)
            //        {
            //            int _totalPiad = 0;
            //            for (int RowIndexPostionForRemove = 0; RowIndexPostionForRemove < _dataTableItemsListRemove.Rows.Count; RowIndexPostionForRemove++)
            //            {
            //                _totalPiad += Convert.ToInt32(_dataTableItemsListRemove.Rows[RowIndexPostionForRemove]["purchase_item_price"].ToString());
            //            }
            //            txttotalAmount.Text = _totalPiad.ToString();
            //            txtPendingAmount.Text = "0";
            //            txtTotalPaid.Text = "0";

            //        }
            //    }
            //    else
            //    {
            //        _totalItemCount = _totalItemCount - Convert.ToInt32(_dataTableItemsList.Rows[_datatableRowIndexPostion]["purchase_item_quantity"]);
            //    }

            //}

            //if (_dataTableItemsListRemove.Rows.Count > 0)
            //{
            //    ViewState["Row"] = _dataTableItemsListRemove;
            //    rptrBreakagePcsItemList.DataSource = ViewState["Row"];
            //    rptrBreakagePcsItemList.DataBind();
            //    rptrBreakagePcsItemList.Visible = true;
            //    txtTotalPaid.Enabled = true;
            //}
            //else
            //{
            //    txttotalAmount.Text = "0";
            //    txtPendingAmount.Text = "0";
            //    txtTotalPaid.Text = "0";
            //    ViewState["Row"] = _dataTableItemsListRemove;
            //    rptrBreakagePcsItemList.DataSource = ViewState["Row"];
            //    rptrBreakagePcsItemList.DataBind();
            //    rptrBreakagePcsItemList.Visible = false;
            //    txtTotalPaid.Enabled = false;
            //}


        }


        #endregion

        protected void btnUpdateData_Click(object sender, EventArgs e)
        {
            _objProcessHole = new ProcessHole();
            _objProcessHoleBL = new ProcessHoleBL();
            try
            {
                if (txtFinalTransferred.Text == "0")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingDetailError();", true);
                }
                else if (Convert.ToInt32(txtreceived.Text) != (Convert.ToInt32(txtFinalTransferred.Text) + Convert.ToInt32(txtbreakage.Text) + Convert.ToInt32(txtReject.Text)))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingDetailError();", true);
                }
                else
                {
                    try
                    {
                        Boolean _breakageRejectStatus = GetBreakageRejectRepeaterValue();
                        if (_breakageRejectStatus == false)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingDetailError();", true);
                        }
                        else
                        {
                            _objProcessHole = _objProcessHoleBL.GetAllProcessHoleItems().Where(x => x.process_hole_id == Convert.ToInt32(hdnItemId.Value)).FirstOrDefault();
                            if (_objProcessHole.process_hole_id > 0)
                            {
                                _objProcessHole = _objProcessHoleBL.UpdateProcessHole(GetProcessHoleUpdateObject());
                                if (_objProcessHole.process_hole_id > 0)
                                {
                                    //int itemMasterId = _objProcessHole.item_master_id;
                                    //string batchNumber = _objProcessHole.batch_number;

                                    _objProductionBL = new ProductionBL();
                                    _objProduction = _objProductionBL.GetAllProductionItems().Where(x => x.item_master_id == _objProcessHole.item_master_id && x.batch_number == _objProcessHole.batch_number).FirstOrDefault();
                                    if (_objProduction.production_id > 0)
                                    {
                                        _objProduction.hole_id = _objProcessHole.process_hole_id;
                                        _objProduction.hole_quantity = _objProcessHole.total_pcs_transferred;
                                        // _objProduction.is_under_hole = true;
                                        _objProduction = _objProductionBL.UpdateProduction(_objProduction);
                                        if (_objProduction.production_id > 0)
                                        {

                                            string _productionId = _objProduction.production_id.ToString();
                                            string _itemMasterId = _objProduction.item_master_id.ToString();
                                            string _processName = "Hole";
                                            string _heading = "Hole Submitted Successfully";
                                            string _heading_class = "text-success";
                                            string _activity = "Hole Submitted with Total Pcs Received:" + _objProcessHole.total_received + ", Breakage:" + _objProcessHole.total_broken + "" + ", Rejected:" + _objProcessHole.total_reject + ", Total Pcs Transfer:" + _objProcessHole.total_pcs_transferred;
                                            string _icon = "fas fa-add";
                                            string _iconClass = "timeline-icon themed-background-emerald themed-border-emerald";
                                            ProductionTrailLogs(_productionId, _itemMasterId, _processName, _heading, _heading_class, _activity, _icon, _iconClass);
                                            txtRemarks.Text = string.Empty;
                                            txtreceived.Text = txtbreakage.Text = txtReject.Text = txtFinalTransferred.Text = "0";
                                            btnUpdateData.Visible = btnResetData.Visible  = false;
                                            Response.Redirect("/production/plan-productions-detail", false);
                                           // ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showHoleProcessSuccess();", true);
                                        }

                                    }

                                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingProcessSuccess();", true);

                                }
                            }
                        }
                     }
                    catch(Exception ex)
                    {
                        ex.Message.ToString();
                    }
                   
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private ProcessHole GetProcessHoleUpdateObject()
        {
            

            string breakReasonData = null;
            if(txtbreakage.Text=="0")
            {
                _objProcessHole.breakage_reason = "";
            }
            else
            {
               
                foreach (RepeaterItem item in rptrBreakagePcsItemList.Items)
                {
                    //TextBox breakageReason = (TextBox)item.FindControl("txtBreakageReason");
                    //string selectedReason = breakageReason.Text + ",";
                    DropDownList ddlBreakageReason = (DropDownList)item.FindControl("ddlBreakageReason");
                    string selectedReason = ddlBreakageReason.SelectedValue + ",";
                    breakReasonData = breakReasonData + selectedReason;
                }
                string totalBreakReasonData = breakReasonData.TrimEnd(',');
                _objProcessHole.breakage_reason = totalBreakReasonData;

                string breakagePcsNumber = null;
                foreach (RepeaterItem item in rptrBreakagePcsItemList.Items)
                {
                    TextBox txtBreakagePcsNumber = (TextBox)item.FindControl("txtBreakagePcsNumber");
                    string selectedPcsNumber = txtBreakagePcsNumber.Text + ",";
                    breakagePcsNumber = breakagePcsNumber + selectedPcsNumber;
                }
                string totalBreakagePcsNumber = breakagePcsNumber.TrimEnd(',');
                _objProcessHole.breakage_pcs_number = totalBreakagePcsNumber;
                _objProcessHole.hole_status = App.Helper.Utils.OrderStatus.progress.ToString();
            }

            

            string rejectReasonData = null;
            if(txtReject.Text=="0")
            {
                _objProcessHole.reject_reason = "";
            }
            else
            {
                
                foreach (RepeaterItem item in rptrRejectPcsItemList.Items)
                {
                    //TextBox rejectReason = (TextBox)item.FindControl("txtRejectReason");
                    //string selectedReason = rejectReason.Text + ",";
                    DropDownList ddlRejectReason = (DropDownList)item.FindControl("ddlRejectReason");
                    string selectedReason = ddlRejectReason.SelectedValue + ",";
                    rejectReasonData = rejectReasonData + selectedReason;
                }
                string totalRejectReasonData = rejectReasonData.TrimEnd(',');

                _objProcessHole.reject_reason = totalRejectReasonData;

                string rejectPcsNumber = null;
                foreach (RepeaterItem item in rptrRejectPcsItemList.Items)
                {
                    TextBox txtRejectPcsNumber = (TextBox)item.FindControl("txtRejectPcsNumber");
                    string selectedPcsNumber = txtRejectPcsNumber.Text + ",";
                    rejectPcsNumber = rejectPcsNumber + selectedPcsNumber;
                }
                string totalRejectPcsNumber = rejectPcsNumber.TrimEnd(',');
                _objProcessHole.reject_pcs_number = totalRejectPcsNumber;

            }


            _objProcessHole.total_received = _objProcessHole.total_received;
           // _objProcessHole.total_received = Convert.ToInt32(txtreceived.Text);
            _objProcessHole.total_broken = Convert.ToInt32(txtbreakage.Text);
            _objProcessHole.total_reject = Convert.ToInt32(txtReject.Text);
            _objProcessHole.total_pcs_transferred = Convert.ToInt32(txtFinalTransferred.Text);

            _objProcessHole.signature = Convert.ToInt32(ddlSignature.SelectedValue);
            _objProcessHole.hole_ended_on = System.DateTime.Now;
            _objProcessHole.remarks = txtRemarks.Text;
            _objProcessHole.hole_status = App.Helper.Utils.OrderStatus.complete.ToString();

            return _objProcessHole;
        }


        #region production trail logs

        /// <summary>
        /// This Method is Used to Save Activity of Any Action Perform By User/Admin
        /// </summary>
        /// <param name="production_id"></param>
        /// <param name="item_master_id"></param>
        /// <param name="process_name"></param>
        /// <param name="heading"></param>
        /// <param name="heading_class"></param>
        /// <param name="activity"></param>
        /// <param name="icon"></param>
        /// <param name="iconclass"></param>
        private void ProductionTrailLogs(string production_id, string item_master_id, string process_name, string heading, string heading_class, string activity, string icon, string iconclass)
        {
            try
            {
                _objProductionTrailBL = new ProductionTrailBL();
                _objProductionTrail.guid = System.Guid.NewGuid();
                _objProductionTrail.production_id = Convert.ToInt32(production_id);
                _objProductionTrail.item_master_id = Convert.ToInt32(item_master_id);
                _objProductionTrail.process_name = process_name;
                _objProductionTrail.user_name = Session[Constants.UserName].ToString();
                _objProductionTrail.heading = heading;
                _objProductionTrail.heading_class = heading_class;
                _objProductionTrail.activity = activity;
                _objProductionTrail.icon = icon;
                _objProductionTrail.icon_class = iconclass;

                // _objActivityLog.user_name = loginParams.UserName;
                //   _objActivityLog.IpAddress = UserIp;
                _objProductionTrail.created_on = Convert.ToDateTime(DateTime.Now);
                _objProductionTrail.modified_on = Convert.ToDateTime(DateTime.Now);
                _objProductionTrail.is_active = true;
                _objProductionTrailBL.CreateProductionTrail(_objProductionTrail);

                //string id = Convert.ToString(Session[Constants.Id]);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        #endregion

        #region Get Breakage,Reject Table Fields Value
        /// <summary>
        /// This Method is Used to Breakage,Reject Table Fields Value
        /// </summary>
        private Boolean GetBreakageRejectRepeaterValue()
        {
            Boolean _objBreakageRejectStatus = true;
            Boolean _objBreakageStatus = true;
            Boolean _objRejectStatus = true;
            try
            {
                try
                {
                    if (txtbreakage.Text == "0")
                    {

                    }

                    else
                    {

                        foreach (RepeaterItem item in rptrBreakagePcsItemList.Items)
                        {

                            DropDownList ddlBreakageReason = (DropDownList)item.FindControl("ddlBreakageReason");
                            TextBox txtBreakagePcsNumber = (TextBox)item.FindControl("txtBreakagePcsNumber");

                            _objBreakageStatus = ddlBreakageReason.SelectedValue == "0" ? _objBreakageStatus = false : _objBreakageStatus = true;



                        }

                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
                try
                {
                    if (txtReject.Text == "0")
                    {

                    }

                    else
                    {

                        foreach (RepeaterItem item in rptrRejectPcsItemList.Items)
                        {

                            DropDownList ddlRejectReason = (DropDownList)item.FindControl("ddlRejectReason");
                            TextBox txtRejectPcsNumber = (TextBox)item.FindControl("txtRejectPcsNumber");

                            _objRejectStatus = ddlRejectReason.SelectedValue == "0" ? _objRejectStatus = false : _objRejectStatus = true;


                        }


                    }

                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }

                if (_objBreakageStatus == true && _objRejectStatus == true)
                {
                    _objBreakageRejectStatus = true;
                }
                else
                {
                    _objBreakageRejectStatus = false;
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }


            return _objBreakageRejectStatus;
        }

        #endregion
    }
}