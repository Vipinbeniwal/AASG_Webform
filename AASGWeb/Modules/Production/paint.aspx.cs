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
    public partial class paint : System.Web.UI.Page
    {
        #region Global Properties

        ProcessPaint _objProcessPaint = new ProcessPaint();
        ProcessPaintBL _objProcessPaintBL = null;
        List<ProcessPaint> _lstProcessPaint = new List<ProcessPaint>();

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
                    string _paintItemid = RouteData.Values["id"].ToString();
                    ItemId = App.Core.DataSecurity.Decryptdata(_paintItemid);
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

                // PopulateData("2");

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
                Int32 ProcessPaintID = Convert.ToInt32(ItemId);

                _objProcessPaintBL = new ProcessPaintBL();

                _objProcessPaint = _objProcessPaintBL.GetAllProcessPaintItems().Where(x => x.process_paint_id == Convert.ToInt32(ProcessPaintID)).FirstOrDefault();

                //_objProcessPaintBL = new ProcessPaintBL();
                //ProcessPaint _objProcessPaint = new ProcessPaint();
                //_lstProcessPaint = _objProcessPaintBL.GetAllProcessPaintItems().Where(x=>x.process_cutting_id==Convert.ToInt32(_ProcessPaintid)).ToList();
                if (_objProcessPaint != null)
                {
                    _objItemMasterBL = new ItemMasterBL();
                    _objItemMaster = _objItemMasterBL.GetItemMasterItemsByID(_objProcessPaint.item_master_id).FirstOrDefault();
                    if (_objItemMaster.item_master_id > 0)
                    {
                       
                    }


                   

                    txtreceived.Text = _objProcessPaint.total_received.ToString();
                    txtbreakage.Text = _objProcessPaint.total_broken.ToString();
                    txtReject.Text = _objProcessPaint.total_reject.ToString();
                    txtFinalTransferred.Text = _objProcessPaint.total_pcs_transferred.ToString();
                    ddlSignature.SelectedValue = _objProcessPaint.signature.ToString();
                    txtRemarks.Text = _objProcessPaint.remarks;
                    if (_objProcessPaint.total_broken > 0)
                    {
                        bindBreakageReason(_objProcessPaint.total_broken);
                    }
                    else
                    {

                    }


                    if (_objProcessPaint.total_reject > 0)
                    {
                        bindRejectReason(_objProcessPaint.total_reject);
                    }
                    else
                    {

                    }
                   

                    if (_objProcessPaint.total_pcs_transferred > 0)
                    {
                        txtFinalTransferred.Text = _objProcessPaint.total_pcs_transferred.ToString();
                        txtbreakage.ReadOnly =  txtReject.ReadOnly = txtRemarks.ReadOnly = true;
                        btnUpdateData.Visible =  btnResetData.Visible = false;
                    }
                    else
                    {
                        txtFinalTransferred.Text = txtreceived.Text;
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
            Int32 ProcessPaintID = Convert.ToInt32(hdnItemId.Value);

            _objProcessPaintBL = new ProcessPaintBL();

            _objProcessPaint = _objProcessPaintBL.GetAllProcessPaintItems().Where(x => x.process_paint_id == Convert.ToInt32(ProcessPaintID)).FirstOrDefault();
            if (_objProcessPaint != null)
            {
                txtbreakage.Text = total_broken.ToString();
               

                _dataTableItemsBreakageList.Columns.Add("Pcs_Reject_id", typeof(int));
                _dataTableItemsBreakageList.Columns.Add("PcsNo", typeof(string));
                _dataTableItemsBreakageList.Columns.Add("Reason", typeof(string));

                rptrBreakagePcsItemList.DataSource = _dataTableItemsBreakageList;
                rptrBreakagePcsItemList.DataBind();

                if (_objProcessPaint.breakage_pcs_number == null)
                {

                }
                else
                {
                    string breakagePcsNumber = _objProcessPaint.breakage_pcs_number;
                    string lasttmPcsNumber = breakagePcsNumber.TrimEnd(',');
                    arrOfSelectionsPcsNumber = lasttmPcsNumber.Split(',');
                }
                if (_objProcessPaint.breakage_reason == null)
                {

                }
                else
                {
                    string breason = _objProcessPaint.breakage_reason;
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
            Int32 ProcessPaintID = Convert.ToInt32(hdnItemId.Value);

            _objProcessPaintBL = new ProcessPaintBL();

            _objProcessPaint = _objProcessPaintBL.GetAllProcessPaintItems().Where(x => x.process_paint_id == Convert.ToInt32(ProcessPaintID)).FirstOrDefault();
            if (_objProcessPaint != null)
            {
                txtReject.Text = total_reject.ToString();
               


                _dataTableItemsRejectList.Columns.Add("Pcs_Reject_id", typeof(int));
                _dataTableItemsRejectList.Columns.Add("PcsNo", typeof(string));
                _dataTableItemsRejectList.Columns.Add("Reason", typeof(string));

                rptrRejectPcsItemList.DataSource = _dataTableItemsRejectList;
                rptrRejectPcsItemList.DataBind();

                if (_objProcessPaint.reject_pcs_number == null)
                {
                }
                else
                {
                    string rejectPcsNumber = _objProcessPaint.reject_pcs_number;
                    string lasttmPcsNumber = rejectPcsNumber.TrimEnd(',');
                    arrOfSelectionsRejectPcsNumber = lasttmPcsNumber.Split(',');
                }
                if (_objProcessPaint.reject_reason == null)
                {

                }
                else
                {
                    string rejectReason = _objProcessPaint.reject_reason;
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
                        rptrBreakagePcsItemList.Visible = false;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingDetailError();", true);
                    }
                    else
                    {
                        createtable();
                        calculate();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
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
                        rptrRejectPcsItemList.Visible = false;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingDetailError();", true);
                    }
                    else
                    {
                        createRejectTable();
                        calculate();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
           
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

        protected void rptrBreakagePcsItemList_ItemCommand(object source, RepeaterCommandEventArgs e)
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

        protected void rptrRejectPcsItemList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void btnUpdateData_Click(object sender, EventArgs e)
        {
            _objProcessPaint = new ProcessPaint();
            _objProcessPaintBL = new ProcessPaintBL();
            try 
            {
                if (txtFinalTransferred.Text == "0")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingDetailError();", true);
                }
                else if(Convert.ToInt32(txtreceived.Text) != (Convert.ToInt32(txtFinalTransferred.Text) + Convert.ToInt32(txtbreakage.Text) + Convert.ToInt32(txtReject.Text)))
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
                            _objProcessPaint = _objProcessPaintBL.GetAllProcessPaintItems().Where(x => x.process_paint_id == Convert.ToInt32(hdnItemId.Value)).FirstOrDefault();
                            if (_objProcessPaint.process_paint_id > 0)
                            {
                                _objProcessPaint = _objProcessPaintBL.UpdateProcessPaint(GetProcessPaintUpdateObject());
                                if (_objProcessPaint.process_paint_id > 0)
                                {
                                    //int itemMasterId = _objProcessPaint.item_master_id;
                                    //string batchNumber = _objProcessPaint.batch_number;

                                    _objProductionBL = new ProductionBL();
                                    _objProduction = _objProductionBL.GetAllProductionItems().Where(x => x.item_master_id == _objProcessPaint.item_master_id && x.batch_number == _objProcessPaint.batch_number).FirstOrDefault();
                                    if (_objProduction.production_id > 0)
                                    {
                                        _objProduction.paint_id = _objProcessPaint.process_paint_id;
                                        _objProduction.paint_quantity = _objProcessPaint.total_pcs_transferred;
                                        //_objProduction.is_under_paint = true;
                                        _objProduction = _objProductionBL.UpdateProduction(_objProduction);
                                        if (_objProduction.production_id > 0)
                                        {
                                            string _productionId = _objProduction.production_id.ToString();
                                            string _itemMasterId = _objProduction.item_master_id.ToString();
                                            string _processName = "Paint";
                                            string _heading = "Paint Submitted Successfully";
                                            string _heading_class = "text-success";
                                            string _activity = "Paint Submitted with Total Pcs Received:" + _objProcessPaint.total_received + ", Breakage:" + _objProcessPaint.total_broken + "" + ", Rejected:" + _objProcessPaint.total_reject + ", Total Pcs Transfer:" + _objProcessPaint.total_pcs_transferred;
                                            string _icon = "fas fa-add";
                                            string _iconClass = "timeline-icon themed-background-emerald themed-border-emerald";
                                            ProductionTrailLogs(_productionId, _itemMasterId, _processName, _heading, _heading_class, _activity, _icon, _iconClass);
                                            txtRemarks.Text = string.Empty;
                                            txtreceived.Text = txtbreakage.Text = txtReject.Text = txtFinalTransferred.Text = "0";
                                            btnUpdateData.Visible =  btnResetData.Visible = false;
                                            Response.Redirect("/production/plan-productions-detail", false);
                                           // ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showPaintProcessSuccess();", true);
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
        private ProcessPaint GetProcessPaintUpdateObject()
        {
            

            string breakReasonData = null;
            if (txtbreakage.Text == "0")
            {
                _objProcessPaint.breakage_reason = "";
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
                _objProcessPaint.breakage_reason = totalBreakReasonData;

                string breakagePcsNumber = null;
                foreach (RepeaterItem item in rptrBreakagePcsItemList.Items)
                {
                    TextBox txtBreakagePcsNumber = (TextBox)item.FindControl("txtBreakagePcsNumber");
                    string selectedPcsNumber = txtBreakagePcsNumber.Text + ",";
                    breakagePcsNumber = breakagePcsNumber + selectedPcsNumber;
                }
                string totalBreakagePcsNumber = breakagePcsNumber.TrimEnd(',');
                _objProcessPaint.breakage_pcs_number = totalBreakagePcsNumber;
                _objProcessPaint.paint_status = App.Helper.Utils.OrderStatus.progress.ToString();
            }



            string rejectReasonData = null;
            if (txtReject.Text == "0")
            {
                _objProcessPaint.reject_reason = "";
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
                _objProcessPaint.reject_reason = totalRejectReasonData;

                string rejectPcsNumber = null;
                foreach (RepeaterItem item in rptrRejectPcsItemList.Items)
                {
                    TextBox txtRejectPcsNumber = (TextBox)item.FindControl("txtRejectPcsNumber");
                    string selectedPcsNumber = txtRejectPcsNumber.Text + ",";
                    rejectPcsNumber = rejectPcsNumber + selectedPcsNumber;
                }
                string totalRejectPcsNumber = rejectPcsNumber.TrimEnd(',');
                _objProcessPaint.reject_pcs_number = totalRejectPcsNumber;
            }


            _objProcessPaint.total_received = _objProcessPaint.total_received;
           // _objProcessPaint.total_received = Convert.ToInt32(txtreceived.Text);
            _objProcessPaint.total_broken = Convert.ToInt32(txtbreakage.Text);
            _objProcessPaint.total_reject = Convert.ToInt32(txtReject.Text);
            _objProcessPaint.total_pcs_transferred = Convert.ToInt32(txtFinalTransferred.Text);

            _objProcessPaint.signature = Convert.ToInt32(ddlSignature.SelectedValue);
            _objProcessPaint.paint_ended_on = System.DateTime.Now;
            _objProcessPaint.remarks = txtRemarks.Text;
            _objProcessPaint.paint_status = App.Helper.Utils.OrderStatus.complete.ToString();

            return _objProcessPaint;
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