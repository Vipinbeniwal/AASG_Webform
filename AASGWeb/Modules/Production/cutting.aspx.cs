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
    public partial class cutting : System.Web.UI.Page
    {
        #region Global Properties

        ProcessCutting _objProcessCutting = new ProcessCutting();
        ProcessCuttingBL _objProcessCuttingBL = null;
        List<ProcessCutting> _lstProcessCutting = new List<ProcessCutting>();

        ItemMaster _objItemMaster = new ItemMaster();
        ItemMasterBL _objItemMasterBL = null;
        List<ItemMaster> _lstItemMaster = new List<ItemMaster>();

        ProductionTrail _objProductionTrail = new ProductionTrail();
        ProductionTrailBL _objProductionTrailBL = null;
        List<ProductionTrail> _lstProductionTrail = new List<ProductionTrail>();


        DraftMaster _objDraftMaster = new DraftMaster();
        DraftMasterBL _objDraftMasterBL = null;
        List<DraftMaster> _lstDraftMaster = new List<DraftMaster>();

        OnFloorItemMaster _objOnFloorItemMaster = new OnFloorItemMaster();
        OnFloorItemMasterBL _objOnFloorItemMasterBL = null;
        List<OnFloorItemMaster> _lstOnFloorItemMaster = new List<OnFloorItemMaster>();

        App.BusinessModel.Production _objProduction = new App.BusinessModel.Production();
        ProductionBL _objProductionBL = null;
        List<App.BusinessModel.Production> _lstProduction = new List<App.BusinessModel.Production>();

        //DataTable _dataTableItemsList = new DataTable();
        DataTable _dataTableItemsBreakageList = new DataTable();
        DataTable _dataTableItemsRejectList = new DataTable();

        string UserIp = string.Empty;
        public  static Boolean _otherItemStatus = false;
        
        string[] arrOfSelectionsPcsNumber, arrOfSelectionsRejectPcsNumber;
        string[] arrOfSelectionsBreakReason, arrOfSelectionsRejectReason;


        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.MaintainScrollPositionOnPostBack = true;
                if (!IsPostBack)
                {
                    // createtable();
                    string ItemId;
                    if (RouteData.Values["id"] == null)
                    {
                        // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "editorInit();", true);
                    }
                    else
                    {
                        string _cuttingItemid = RouteData.Values["id"].ToString();
                        ItemId = App.Core.DataSecurity.Decryptdata(_cuttingItemid);
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

                    txtFinalTransferred.ReadOnly =  txtreceived.ReadOnly = true;

                    txtSheetReceived.ReadOnly = txtSheetHeight.ReadOnly = txtSheetWidth.ReadOnly = txtActualPcsFromRejection.ReadOnly = txtSheetIssued.ReadOnly = txtSheetIssuedActualPcs.ReadOnly = txtSheetIssuedTargetPcs.ReadOnly = txtDraftTargetPcs.ReadOnly = txtDraftActualPcs.ReadOnly =
                        txtBrokenSheetInCreate.ReadOnly = txtNoofSheet.ReadOnly = txtLeftOverSize.ReadOnly = txtPcsCutFromSheet.ReadOnly = txtTotalPcsTransferred.ReadOnly =
                        txtleftOverDraftHeight.ReadOnly = txtleftOverDraftWidth.ReadOnly = true;

                }
            }
            catch (Exception)
            {

            }
           

           
        }
        private void PopulateData(string ItemId)
        {
            try
            {
                hdnItemId.Value = ItemId;
                Int32 ProcessCuttingID = Convert.ToInt32(ItemId);

                _objProcessCuttingBL = new ProcessCuttingBL();

                _objProcessCutting = _objProcessCuttingBL.GetAllProcessCuttingItems().Where(x=>x.process_cutting_id==Convert.ToInt32(ProcessCuttingID)).FirstOrDefault();
                
                //_objProcessCuttingBL = new ProcessCuttingBL();
                //ProcessCutting _objProcessCutting = new ProcessCutting();
                //_lstProcessCutting = _objProcessCuttingBL.GetAllProcessCuttingItems().Where(x=>x.process_cutting_id==Convert.ToInt32(_processcuttingid)).ToList();
                if (_objProcessCutting!=null)
                {
                    _objItemMasterBL = new ItemMasterBL();
                    _objItemMaster = _objItemMasterBL.GetItemMasterItemsByID(_objProcessCutting.item_master_id).FirstOrDefault();
                    if(_objItemMaster.item_master_id>0)
                    {
                        txtthickness.Text = _objItemMaster.thickness;

                        txtItemsheetSize.Text = _objItemMaster.item_height + "x" + _objItemMaster.item_width;
                        txtItemHeight.Text = _objItemMaster.item_height;
                        txtItemWidth.Text = _objItemMaster.item_width;
                        txtItemName.Text = _objItemMaster.model + "|" + _objItemMaster.item_type_name + "|" + _objItemMaster.glass_color;
                        txtItemsheetSize.ReadOnly = false;
                        txtItemName.ReadOnly = true;
                        txtthickness.ReadOnly = true;
                    }

                    
                    txtBrokenSheetInCreate.Text = _objProcessCutting.broken_sheets_in_crate.ToString();
                    
                    txtSheetIssued.Text = _objProcessCutting.sheet_issued.ToString();

                    
                    txtSheetReceived.Text = (Convert.ToInt32(txtSheetIssued.Text == "" ? "0" : txtSheetIssued.Text) - Convert.ToInt32(txtBrokenSheetInCreate.Text == "" ? "0" : txtBrokenSheetInCreate.Text)).ToString();

                    txtSheetSize.Text = _objProcessCutting.sheet_size.ToString()==null ? "0" : _objProcessCutting.sheet_size.ToString();
                    txtSheetHeight.Text = _objProcessCutting.sheet_height.ToString() == null ? "0" : _objProcessCutting.sheet_height.ToString();
                    txtSheetWidth.Text = _objProcessCutting.sheet_width.ToString() == null ? "0" : _objProcessCutting.sheet_width.ToString();
                    txtSheetIssuedTargetPcs.Text = _objProcessCutting.target_pcs_from_sheet_issued.ToString();
                    txtSheetIssuedActualPcs.Text = _objProcessCutting.actual_pcs_from_sheet_issued.ToString();
                    txtNoofSheet.Text = _objProcessCutting.broken_no_of_sheet.ToString();
                    //txtDraftSize.Text = _objProcessCutting.draft_size;

                    txtDraftTargetPcs.Text = txtDraftActualPcs.Text = "0";
                    txtPcsCutFromSheet.Text = _objProcessCutting.broken_pcs_cut_from_sheet.ToString();

                    txtPcsFromRejection.Text = _objProcessCutting.pcs_from_rejection.ToString();
                    txtActualPcsFromRejection.Text = _objProcessCutting.actual_pcs_from_rejection.ToString();
                    //txtTotalPcsTransferred.Text = _objProcessCutting.total_pcs_transferred.ToString();
                    txtTotalPcsTransferred.Text = _objProcessCutting.total_received.ToString(); 
                    txtLeftOverSize.Text = _objProcessCutting.broken_left_over_size.ToString();


                    if (_objProcessCutting.broken_left_over_size.ToString() != null)
                    {
                        string[] arrOfLeftOverDraftHeightWidth;
                        string _leftOverDraftSizeInHeightWidth = _objProcessCutting.broken_left_over_size.ToString();
                        string lasttmLeftOverdraftSizeInHeightWidth = _leftOverDraftSizeInHeightWidth.TrimEnd(',');
                        arrOfLeftOverDraftHeightWidth = lasttmLeftOverdraftSizeInHeightWidth.Split('x');

                        txtleftOverDraftHeight.Text = arrOfLeftOverDraftHeightWidth[0];
                        txtleftOverDraftWidth.Text = arrOfLeftOverDraftHeightWidth[1];
                    }
                    else
                    {
                        //txtUsedDraftHeight.Text = "0";
                        //txtUsedDraftWidth.Text = "0";
                    }

                    txtreceived.Text = _objProcessCutting.total_received.ToString();
                    txtbreakage.Text = _objProcessCutting.total_broken.ToString();
                    txtReject.Text = _objProcessCutting.total_reject.ToString();
                    txtFinalTransferred.Text= _objProcessCutting.total_pcs_transferred.ToString();
                    ddlSignature.SelectedValue = _objProcessCutting.signature.ToString();

                    txtKeptOnFloorItemStatus.Text = (_objProcessCutting.kept_on_floor_item_status == true ?"Yes":"No").ToString();
                    if (txtKeptOnFloorItemStatus.Text == "Yes")
                    {
                        txtKeptOnFloorPcsQuantity.ReadOnly = txtKeptOnFloorItemStatus.ReadOnly = txtKeptOnFloorItemStatus.ReadOnly = true;
                        txtKeptOnFloorPcsReceived.ReadOnly = false;
                        txtKeptOnFloorItemMasterId.Text = _objProcessCutting.kept_on_floor_item_master_id.ToString();
                        txtKeptOnFloorPcsQuantity.Text = _objProcessCutting.kept_on_floor_item_pcs_quantity.ToString();
                        txtKeptOnFloorPcsReceived.Text = _objProcessCutting.kept_on_floor_item_pcs_received.ToString();
                        
                    }
                    else
                    {
                        txtKeptOnFloorPcsQuantity.ReadOnly = txtKeptOnFloorPcsReceived.ReadOnly = txtKeptOnFloorItemStatus.ReadOnly = true;
                        txtKeptOnFloorItemMasterId.Text = _objProcessCutting.kept_on_floor_item_master_id.ToString();
                        txtKeptOnFloorPcsQuantity.Text = _objProcessCutting.kept_on_floor_item_pcs_quantity.ToString();
                        txtKeptOnFloorPcsReceived.Text = "0";
                        
                    }
                   
                    txtRemarks.Text = _objProcessCutting.remarks;
                    if(_objProcessCutting.total_broken > 0)
                    {
                        bindBreakageReason(_objProcessCutting.total_broken);
                    }
                    else
                    {

                    }

                    
                    if(_objProcessCutting.total_reject >0)
                    {
                        bindRejectReason(_objProcessCutting.total_reject);
                    }
                    else
                    {

                    }

                    if (_objProcessCutting.total_pcs_transferred > 0)
                    {
                        txtItemName.ReadOnly = txtthickness.ReadOnly = txtItemsheetSize.ReadOnly = txtBrokenSheetInCreate.ReadOnly =
                            txtSheetIssued.ReadOnly = txtSheetIssuedTargetPcs.ReadOnly = txtSheetIssuedActualPcs.ReadOnly = txtTotalPcsTransferred.ReadOnly = txtNoofSheet.ReadOnly =
                             txtDraftTargetPcs.ReadOnly = txtDraftActualPcs.ReadOnly = txtPcsCutFromSheet.ReadOnly = txtPcsFromRejection.ReadOnly = txtActualPcsFromRejection.ReadOnly = txtLeftOverSize.ReadOnly = txtRemarks.ReadOnly = true;

                        txtbreakage.ReadOnly =  txtReject.ReadOnly = true;
                        btnUpdateData.Visible =   btnResetData.Visible =  btnSubmit.Visible =   btnReset.Visible = false;

                    }
                    else
                    {
                        txtbreakage.ReadOnly =   txtReject.ReadOnly = btnSubmit.Visible = btnReset.Visible = true;
                        btnUpdateData.Visible =  btnResetData.Visible = false;
                        
                    }

                    #region Comment OnFloor Draft
                    //_objOnFloorItemMasterBL = new OnFloorItemMasterBL();

                    //_objOnFloorItemMaster = _objOnFloorItemMasterBL.GetAllOnFloorItemMasterItems().Where(x => x.batch_number == _objProcessCutting.batch_number && x.parent_item_master_id == _objProcessCutting.item_master_id && x.items_type== "Draft").FirstOrDefault();

                    //if (_objOnFloorItemMaster != null)
                    //{
                    //    if(_objOnFloorItemMaster.on_floor_item_master_id > 0)
                    //    {
                    //       // txtDraftSize.Text = _objOnFloorItemMaster.items_name;
                    //       // txtDraftSize.Text = _objOnFloorItemMaster.left_over_size;
                    //        txtDraftTargetPcs.Text = _objOnFloorItemMaster.per_broken_sheet_quantity.ToString();
                    //        txtDraftActualPcs.Text = _objOnFloorItemMaster.per_broken_sheet_quantity_expected.ToString();

                    //        if (_objOnFloorItemMaster.items_name != null)
                    //        {
                    //            string[] arrOfUsedDraftHeightWidth;
                    //            string _draftSizeInHeightWidth = _objOnFloorItemMaster.items_name;
                    //            string lasttmdraftSizeInHeightWidth = _draftSizeInHeightWidth.TrimEnd(',');
                    //            arrOfUsedDraftHeightWidth = lasttmdraftSizeInHeightWidth.Split('x');

                    //            //txtUsedDraftHeight.Text = arrOfUsedDraftHeightWidth[0];
                    //            //txtUsedDraftWidth.Text = arrOfUsedDraftHeightWidth[1];
                    //            decimal _itemDraftSqm = (Convert.ToDecimal(arrOfUsedDraftHeightWidth[0])* Convert.ToDecimal(arrOfUsedDraftHeightWidth[1])/1000000);

                    //            //txtDraftSheetSqm.Text = _itemDraftSqm.ToString();
                    //        }
                    //        else
                    //        {
                    //            //txtUsedDraftHeight.Text = "0";
                    //            //txtUsedDraftWidth.Text = "0";
                    //        }

                    //    }
                    //    else
                    //    {
                    //        //txtUsedDraftHeight.Text = "0";
                    //        //txtUsedDraftWidth.Text = "0";
                    //    }
                    //}
                    //else
                    //{
                    //    //txtUsedDraftHeight.Text = "0";
                    //    //txtUsedDraftWidth.Text = "0";
                    //}

                    #endregion

                    // Get Other Item List From OnFloorItem Table and Also Bind DraftList in Table  start
                    BindOnFloorOtherItemRptr( _objProcessCutting.batch_number, _objProcessCutting.item_master_id.ToString());

                    // Get Other Item List From OnFloorItem Table  End


                    // Start Code for Calculate

                    txtSheetReceived.Text = string.IsNullOrEmpty(txtSheetReceived.Text) ? "0" : txtSheetReceived.Text;

                    
                    if(Convert.ToInt32(txtSheetReceived.Text) > 0)
                    {
                        int _sheetReceived, _sheetIssuedTargetPcs, _sheetIssuedActualPcs = 0;
                        txtSheetIssuedTargetPcs.Text = string.IsNullOrEmpty(txtSheetIssuedTargetPcs.Text) ? "0" : txtSheetIssuedTargetPcs.Text;
                        
                        _sheetReceived = Convert.ToInt32(txtSheetReceived.Text);
                        _sheetIssuedTargetPcs = Convert.ToInt32(txtSheetIssuedTargetPcs.Text);
                        _sheetIssuedActualPcs = Convert.ToInt32(txtSheetIssuedActualPcs.Text);

                        _sheetIssuedActualPcs = (_sheetReceived * _sheetIssuedTargetPcs);
                        txtSheetIssuedActualPcs.Text = _sheetIssuedActualPcs.ToString();

                        //Pcs from Broken Sheet - txtPcsCutFromSheet.text
                        //
                        // pcs from Draft size - txtDraftActualPcs.Text


                        txtTotalPcsTransferred.Text = (Convert.ToInt32(string.IsNullOrEmpty(txtKeptOnFloorPcsReceived.Text) ? "0" : txtKeptOnFloorPcsReceived.Text) + Convert.ToInt32(string.IsNullOrEmpty(txtActualPcsFromRejection.Text)  ? "0" : txtActualPcsFromRejection.Text) + Convert.ToInt32(string.IsNullOrEmpty(txtSheetIssuedActualPcs.Text)  ? "0" : txtSheetIssuedActualPcs.Text) + Convert.ToInt32(string.IsNullOrEmpty(txtPcsCutFromSheet.Text)  ? "0" : txtPcsCutFromSheet.Text) + Convert.ToInt32(string.IsNullOrEmpty(txtDraftActualPcs.Text)  ? "0" : txtDraftActualPcs.Text)).ToString();
                        txtSheetIssuedActualPcs.ReadOnly = true;
                    }

                    // End code for Calculate


                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void bindBreakageReason(int total_broken)
        {
            Int32 ProcessCuttingID = Convert.ToInt32(hdnItemId.Value);

            _objProcessCuttingBL = new ProcessCuttingBL();

            _objProcessCutting = _objProcessCuttingBL.GetAllProcessCuttingItems().Where(x => x.process_cutting_id == Convert.ToInt32(ProcessCuttingID)).FirstOrDefault();
            if (_objProcessCutting != null)
            {
                txtbreakage.Text = total_broken.ToString();
               
                _dataTableItemsBreakageList.Columns.Add("Pcs_Reject_id", typeof(int));
                _dataTableItemsBreakageList.Columns.Add("PcsNo", typeof(string));
                _dataTableItemsBreakageList.Columns.Add("Reason", typeof(string));

                rptrBreakagePcsItemList.DataSource = _dataTableItemsBreakageList;
                rptrBreakagePcsItemList.DataBind();

                
                if (_objProcessCutting.breakage_pcs_number == null)
                {

                }
                else
                {
                    string breakagePcsNumber = _objProcessCutting.breakage_pcs_number;
                    string lasttmPcsNumber = breakagePcsNumber.TrimEnd(',');
                     arrOfSelectionsPcsNumber = lasttmPcsNumber.Split(',');
                }
                if (_objProcessCutting.breakage_reason == null)
                {

                }
                else
                {
                    string breason = _objProcessCutting.breakage_reason;
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
            Int32 ProcessCuttingID = Convert.ToInt32(hdnItemId.Value);

            _objProcessCuttingBL = new ProcessCuttingBL();

            _objProcessCutting = _objProcessCuttingBL.GetAllProcessCuttingItems().Where(x => x.process_cutting_id == Convert.ToInt32(ProcessCuttingID)).FirstOrDefault();
            if (_objProcessCutting != null)
            {
                txtReject.Text = total_reject.ToString();
               

                _dataTableItemsRejectList.Columns.Add("Pcs_Reject_id", typeof(int));
                _dataTableItemsRejectList.Columns.Add("PcsNo", typeof(string));
                _dataTableItemsRejectList.Columns.Add("Reason", typeof(string));

                rptrRejectPcsItemList.DataSource = _dataTableItemsRejectList;
                rptrRejectPcsItemList.DataBind();

                if (_objProcessCutting.reject_pcs_number == null)
                {
                }
                else
                {
                    string rejectPcsNumber = _objProcessCutting.reject_pcs_number;
                    string lasttmPcsNumber = rejectPcsNumber.TrimEnd(',');
                    arrOfSelectionsRejectPcsNumber = lasttmPcsNumber.Split(',');
                }
                if (_objProcessCutting.reject_reason == null)
                {

                }
                else
                {
                    string rejectReason = _objProcessCutting.reject_reason;
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
             catch ( Exception ex)
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
                if (txtTotalPcsTransferred.Text == null || txtTotalPcsTransferred.Text == "")
                {
                    txtTotalPcsTransferred.Text = "0";
                }
                else
                {
                    if (txtFinalTransferred.Text == null || txtFinalTransferred.Text == "")
                    {
                        txtFinalTransferred.Text = "0";
                        txtFinalTransferred.Text = txtreceived.Text;

                    }
                    else
                    {
                        txtFinalTransferred.Text = txtreceived.Text;
                    }

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
            catch( Exception ex)
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
            catch(Exception ex)
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

        /// <summary>
        /// This Method is Used to Get Procduction Details of All Items and Items Current Status Department Wise and Data in Repeater
        /// </summary>
        private void BindOnFloorOtherItemRptr(string _batchNumber,string _parentItemMasterId)
        {
            _objOnFloorItemMasterBL = new OnFloorItemMasterBL();
            #region
            //_lstOnFloorItemMaster = _objOnFloorItemMasterBL.GetAllOnFloorItemMasterItems().Where(x => x.batch_number == _batchNumber && x.parent_item_master_id == Convert.ToInt32(_parentItemMasterId) && x.items_type == "Item").ToList();

            //if (_lstOnFloorItemMaster!=null)
            //{
            //    if (_lstOnFloorItemMaster.Count > 0)
            //    {
            //        rptrOnFloorOtherItemsList.DataSource = _lstOnFloorItemMaster;
            //        rptrOnFloorOtherItemsList.DataBind();
            //        divOnFloorOtherItemList.Visible = true;
            //        rptrOnFloorOtherItemsList.Visible = true;
            //    }
            //    else
            //    {
            //        rptrOnFloorOtherItemsList.DataSource = null;
            //        rptrOnFloorOtherItemsList.DataBind();
            //        divOnFloorOtherItemList.Visible = false;
            //        rptrOnFloorOtherItemsList.Visible = false;
            //    }
            //}
            //else
            //{
            //    rptrOnFloorOtherItemsList.DataSource = null;
            //    rptrOnFloorOtherItemsList.DataBind();
            //    divOnFloorOtherItemList.Visible = false;
            //    rptrOnFloorOtherItemsList.Visible = false;
            //}
            #endregion

            _lstOnFloorItemMaster = _objOnFloorItemMasterBL.GetAllOnFloorItemMasterItems().Where(x => x.batch_number == _batchNumber && x.parent_item_master_id == Convert.ToInt32(_parentItemMasterId) ).ToList();

            if (_lstOnFloorItemMaster != null)
            {
                if (_lstOnFloorItemMaster.Count > 0)
                {
                    rptrDraftList.DataSource = _lstOnFloorItemMaster.Where(x => x.items_type == "Draft").ToList();
                    rptrDraftList.DataBind();
                    divOnFloorOtherItemList.Visible = true;
                    rptrDraftList.Visible = true;


                    _lstOnFloorItemMaster = _lstOnFloorItemMaster.Where(x => x.items_type == "Item").ToList();
                    if (_lstOnFloorItemMaster.Count > 0)
                    {
                        rptrOnFloorOtherItemsList.DataSource = _lstOnFloorItemMaster;
                        rptrOnFloorOtherItemsList.DataBind();
                        divOnFloorOtherItemList.Visible = true;
                        rptrOnFloorOtherItemsList.Visible = true;
                        
                    }
                    else
                    {
                        _otherItemStatus = true;
                        rptrOnFloorOtherItemsList.DataSource = null;
                        rptrOnFloorOtherItemsList.DataBind();
                        divOnFloorOtherItemList.Visible = false;
                        rptrOnFloorOtherItemsList.Visible = false;
                    }

                }
                else
                {
                    rptrOnFloorOtherItemsList.DataSource = null;
                    rptrOnFloorOtherItemsList.DataBind();
                    divOnFloorOtherItemList.Visible = false;
                    rptrOnFloorOtherItemsList.Visible = false;
                    _otherItemStatus = true;
                }
            }
            else
            {
                rptrOnFloorOtherItemsList.DataSource = null;
                rptrOnFloorOtherItemsList.DataBind();
                divOnFloorOtherItemList.Visible = false;
                rptrOnFloorOtherItemsList.Visible = false;
                _otherItemStatus = true;
            }

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
             txtPcsFromRejection.Text = txtActualPcsFromRejection.Text = "0";
            if (txtKeptOnFloorItemStatus.Text == "No" || txtKeptOnFloorItemStatus.Text == "" || txtKeptOnFloorItemStatus.Text == null)
            {
                txtKeptOnFloorPcsQuantity.Text = txtKeptOnFloorPcsReceived.Text = "0";
                txtKeptOnFloorPcsReceived.ReadOnly = true;
            }
            else
            {
                txtKeptOnFloorPcsReceived.Text = "0";
                txtKeptOnFloorPcsReceived.ReadOnly = false;
            }
            
               txtPcsFromRejection.ReadOnly = false;
            btnSubmit.Visible = true;
            txtSheetReceived.ReadOnly = txtSheetHeight.ReadOnly = txtSheetWidth.ReadOnly = txtSheetIssuedTargetPcs.ReadOnly = txtActualPcsFromRejection.ReadOnly = txtSheetIssued.ReadOnly = txtSheetIssuedActualPcs.ReadOnly = txtDraftActualPcs.ReadOnly = txtBrokenSheetInCreate.ReadOnly = txtNoofSheet.ReadOnly = txtLeftOverSize.ReadOnly = txtPcsCutFromSheet.ReadOnly = txtTotalPcsTransferred.ReadOnly =
                txtleftOverDraftHeight.ReadOnly = txtleftOverDraftWidth.ReadOnly =  txtDraftTargetPcs.ReadOnly  = true;
            
            rptrBreakagePcsItemList.Visible = false;
            rptrRejectPcsItemList.Visible = false;
            txtbreakage.Text = txtReject.Text = "";
            txtKeptOnFloorItemStatus.Text = "";
            txtreceived.Text = txtFinalTransferred.Text = txtbreakage.Text = txtReject.Text = "0";
           
            txtbreakage.ReadOnly = true;
            txtReject.ReadOnly = true;
            btnUpdateData.Visible = false;
            btnResetData.Visible = false;
            txtItemsheetSize.ReadOnly = false;
            txtItemName.ReadOnly = true;
            txtthickness.ReadOnly = true;

            // Start Code for Calculate

            if (txtSheetReceived.Text == "0" || txtSheetReceived.Text == "" || txtSheetReceived.Text == null)
            {
                txtSheetReceived.Text = "0"; 

            }
            else
            {
                int _sheetReceived, _sheetIssuedTargetPcs, _sheetIssuedActualPcs = 0;
                if (txtSheetReceived.Text == null || txtSheetReceived.Text == "")
                {
                    txtSheetReceived.Text = "0";
                }
                if (txtSheetIssuedTargetPcs.Text == null || txtSheetIssuedTargetPcs.Text == "")
                {
                    txtSheetIssuedTargetPcs.Text = "0";
                }


                _sheetReceived = Convert.ToInt32(txtSheetReceived.Text);
                _sheetIssuedTargetPcs = Convert.ToInt32(txtSheetIssuedTargetPcs.Text);
                _sheetIssuedActualPcs = Convert.ToInt32(txtSheetIssuedActualPcs.Text);

                _sheetIssuedActualPcs = (_sheetReceived * _sheetIssuedTargetPcs);
                txtSheetIssuedActualPcs.Text = _sheetIssuedActualPcs.ToString();

                //Pcs from Broken Sheet - txtPcsCutFromSheet.text
                //
                // pcs from Draft size - txtDraftActualPcs.Text


                txtTotalPcsTransferred.Text = (Convert.ToInt32(txtKeptOnFloorPcsReceived.Text == "" ? "0" : txtKeptOnFloorPcsReceived.Text) + Convert.ToInt32(txtActualPcsFromRejection.Text == "" ? "0" : txtActualPcsFromRejection.Text) + Convert.ToInt32(txtSheetIssuedActualPcs.Text == "" ? "0" : txtSheetIssuedActualPcs.Text) + Convert.ToInt32(txtPcsCutFromSheet.Text == "" ? "0" : txtPcsCutFromSheet.Text) + Convert.ToInt32(txtDraftActualPcs.Text == "" ? "0" : txtDraftActualPcs.Text)).ToString();
                txtSheetIssuedActualPcs.ReadOnly = true;
            }

            // End code for Calculate

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtSheetIssued.Text =="0" || txtSheetIssued.Text==null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingDetailError();", true);
           
            }
            else if (txtSheetIssuedTargetPcs.Text == "0" || txtSheetIssuedTargetPcs.Text == null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingDetailError();", true);
            }
            else if (txtSheetIssuedActualPcs.Text == "0" || txtSheetIssuedActualPcs.Text == null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingDetailError();", true);
            }
            else
            {
                //txtreceived.Text = txtTotalPcsTransferred.Text;
                txtbreakage.Text = txtReject.Text = "0";
                txtFinalTransferred.Text = txtTotalPcsTransferred.Text;

                int _sheetReceived, _sheetIssuedTargetPcs, _sheetIssuedActualPcs = 0;
                if (txtSheetIssued.Text == null || txtSheetIssued.Text == "")
                {
                    txtSheetIssued.Text = "0";
                }
                if (txtSheetIssuedTargetPcs.Text == null || txtSheetIssuedTargetPcs.Text == "")
                {
                    txtSheetIssuedTargetPcs.Text = "0";
                }
                if (txtDraftTargetPcs.Text == null || txtDraftTargetPcs.Text == "")
                {
                    txtDraftTargetPcs.Text = "0";
                    txtDraftActualPcs.Text = txtDraftTargetPcs.Text;
                }

                
                
                _sheetReceived = Convert.ToInt32(txtSheetIssued.Text);
                _sheetIssuedTargetPcs = Convert.ToInt32(txtSheetIssuedTargetPcs.Text);
                _sheetIssuedActualPcs = Convert.ToInt32(txtSheetIssuedActualPcs.Text);

                _sheetIssuedActualPcs = (_sheetReceived * _sheetIssuedTargetPcs);
                //txtSheetIssuedActualPcs.Text = _sheetIssuedActualPcs.ToString();

                //Pcs from Broken Sheet - txtPcsCutFromSheet.text
                //
                // pcs from Draft size - txtDraftActualPcs.Text

                
                txtreceived.Text = (Convert.ToInt32(txtKeptOnFloorPcsReceived.Text == "" ? "0" : txtKeptOnFloorPcsReceived.Text) +  _sheetIssuedActualPcs  + Convert.ToInt32(txtDraftActualPcs.Text == "" ? "0" : txtDraftActualPcs.Text)).ToString();
                txtSheetIssuedActualPcs.ReadOnly = true;


                txtBrokenSheetInCreate.ReadOnly = txtSheetIssued.ReadOnly = txtSheetIssuedTargetPcs.ReadOnly = txtSheetIssuedActualPcs.ReadOnly = txtNoofSheet.ReadOnly =
                txtDraftTargetPcs.ReadOnly = txtDraftActualPcs.ReadOnly = txtPcsCutFromSheet.ReadOnly = txtPcsFromRejection.ReadOnly =   txtActualPcsFromRejection.ReadOnly = txtTotalPcsTransferred.ReadOnly = txtLeftOverSize.ReadOnly = true;

                btnSubmit.Visible = false;
                txtbreakage.ReadOnly = false;
                txtReject.ReadOnly = false;
                btnUpdateData.Visible = true;
                btnResetData.Visible = false;
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


                    if (lblRejectPcsNo.Text == "")
                    {

                       
                    }
                    else
                    {
                        

                    }
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
                   

                    if (lblBreakagePcsNo.Text == "")
                    {

                        
                    }
                    else
                    {
                        
                        
                    }
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
                    if ((Convert.ToInt32(txtTotalPcsTransferred.Text) + Convert.ToInt32(txtbreakage.Text) + Convert.ToInt32(txtReject.Text)) > Convert.ToInt32(txtreceived.Text))
                    {
                        rptrBreakagePcsItemList.Visible = false;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingDetailError();", true);
                    }
                    else
                    {
                       // txtreceived.Text = txtTotalPcsTransferred.Text;
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
                    if ((Convert.ToInt32(txtTotalPcsTransferred.Text) + Convert.ToInt32(txtbreakage.Text) + Convert.ToInt32(txtReject.Text)) > Convert.ToInt32(txtreceived.Text))
                    {
                        rptrRejectPcsItemList.Visible = false;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingDetailError();", true);
                    }
                    else
                    {
                        //  txtreceived.Text = txtTotalPcsTransferred.Text; (Convert.ToInt32(txtFinalTransferred.Text) + Convert.ToInt32(txtbreakage.Text) + Convert.ToInt32(txtReject.Text))
                        createRejectTable();
                        calculate();
                    }
                }
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }
           
        }

        //protected void btnUpdate_Click(object sender, EventArgs e)
        //{
        //    _objProcessCutting = new ProcessCutting();
        //    _objProcessCuttingBL = new ProcessCuttingBL();
        //   _objProcessCutting= _objProcessCuttingBL.GetAllProcessCuttingItems().Where(x => x.process_cutting_id == Convert.ToInt32(hdnId.Value)).FirstOrDefault();
        //    if(_objProcessCutting.process_cutting_id>0)
        //    {
        //        _objProcessCutting = _objProcessCuttingBL.UpdateProcessCutting(GetProcessCuttingUpdateObject());
        //        if(_objProcessCutting.process_cutting_id>0)
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingProcessSuccess();", true);
        //        }
        //    }
        //}


        private ProcessCutting GetProcessCuttingUpdateObject()
        {
            _objProcessCutting.item_thickness = txtthickness.Text;
            _objProcessCutting.item_sheet_size = txtItemsheetSize.Text;
            _objProcessCutting.broken_sheets_in_crate = Convert.ToInt32(txtBrokenSheetInCreate.Text);
            _objProcessCutting.sheet_issued = Convert.ToInt32(txtSheetIssued.Text);

            _objProcessCutting.sheet_size = txtSheetHeight.Text+'x'+ txtSheetWidth.Text;
            _objProcessCutting.sheet_height = txtSheetHeight.Text;
            _objProcessCutting.sheet_width = txtSheetWidth.Text;

            _objProcessCutting.target_pcs_from_sheet_issued = Convert.ToInt32(txtSheetIssuedTargetPcs.Text);
            _objProcessCutting.actual_pcs_from_sheet_issued = Convert.ToInt32(txtSheetIssuedActualPcs.Text);
            _objProcessCutting.broken_no_of_sheet = Convert.ToInt32(txtNoofSheet.Text);
            _objProcessCutting.draft_size = "";
            _objProcessCutting.target_pcs_from_draft_size = Convert.ToInt32(txtDraftTargetPcs.Text);
            _objProcessCutting.actual_pcs_from_draft_size = Convert.ToInt32(txtDraftActualPcs.Text);
            _objProcessCutting.broken_pcs_cut_from_sheet = Convert.ToInt32(txtPcsCutFromSheet.Text);

            _objProcessCutting.pcs_from_rejection = Convert.ToInt32(txtPcsFromRejection.Text);
            _objProcessCutting.actual_pcs_from_rejection = Convert.ToInt32(txtActualPcsFromRejection.Text);
            _objProcessCutting.total_pcs_transferred = Convert.ToInt32(txtTotalPcsTransferred.Text);
            _objProcessCutting.broken_left_over_size = txtLeftOverSize.Text;

            if (txtbreakage.Text == "0")
            {
                _objProcessCutting.breakage_reason = "";
            }
            else
            {
                string breakReasonData = null;
                foreach (RepeaterItem item in rptrBreakagePcsItemList.Items)
                {
                    //TextBox breakageReason = (TextBox)item.FindControl("txtBreakageReason");
                    //string selectedReason = breakageReason.Text + ",";
                    DropDownList ddlBreakageReason = (DropDownList)item.FindControl("ddlBreakageReason");
                    string selectedReason = ddlBreakageReason.SelectedValue + ",";
                    breakReasonData = breakReasonData + selectedReason;
                }
                string totalBreakReasonData = breakReasonData.TrimEnd(',');
                _objProcessCutting.breakage_reason = totalBreakReasonData;

                string breakagePcsNumber = null;
                foreach (RepeaterItem item in rptrBreakagePcsItemList.Items)
                {
                    TextBox txtBreakagePcsNumber = (TextBox)item.FindControl("txtBreakagePcsNumber");
                    string selectedPcsNumber = txtBreakagePcsNumber.Text + ",";
                    breakagePcsNumber = breakagePcsNumber + selectedPcsNumber;
                }
                string totalBreakagePcsNumber = breakagePcsNumber.TrimEnd(',');
                _objProcessCutting.breakage_pcs_number = totalBreakagePcsNumber;
                _objProcessCutting.cutting_status = App.Helper.Utils.OrderStatus.progress.ToString();

            }

            if (txtReject.Text == "0")
            {
                _objProcessCutting.reject_reason = "";
            }
            else
            {

                string rejectReasonData = null;
                foreach (RepeaterItem item in rptrRejectPcsItemList.Items)
                {
                    //TextBox rejectReason = (TextBox)item.FindControl("txtRejectReason");
                    //string selectedReason = rejectReason.Text + ",";
                    DropDownList ddlRejectReason = (DropDownList)item.FindControl("ddlRejectReason");
                    string selectedReason = ddlRejectReason.SelectedValue + ",";
                    rejectReasonData = rejectReasonData + selectedReason;
                }
                string totalRejectReasonData = rejectReasonData.TrimEnd(',');

                _objProcessCutting.reject_reason = totalRejectReasonData;

                string rejectPcsNumber = null;
                foreach (RepeaterItem item in rptrRejectPcsItemList.Items)
                {
                    TextBox txtRejectPcsNumber = (TextBox)item.FindControl("txtRejectPcsNumber");
                    string selectedPcsNumber = txtRejectPcsNumber.Text + ",";
                    rejectPcsNumber = rejectPcsNumber + selectedPcsNumber;
                }
                string totalRejectPcsNumber = rejectPcsNumber.TrimEnd(',');
                _objProcessCutting.reject_pcs_number = totalRejectPcsNumber;


            }


            //_objProcessCutting.total_received = _objProcessCutting.total_received;
            _objProcessCutting.total_received = Convert.ToInt32(txtreceived.Text);
            _objProcessCutting.total_broken = Convert.ToInt32(txtbreakage.Text);
            _objProcessCutting.total_reject = Convert.ToInt32(txtReject.Text);
            _objProcessCutting.total_pcs_transferred = Convert.ToInt32(txtFinalTransferred.Text);

            _objProcessCutting.signature = Convert.ToInt32(ddlSignature.SelectedValue);
            _objProcessCutting.cutting_ended_on = System.DateTime.Now;
            _objProcessCutting.remarks = txtRemarks.Text;
            _objProcessCutting.cutting_status = App.Helper.Utils.OrderStatus.complete.ToString();

            
            _objProcessCutting.kept_on_floor_item_pcs_received = Convert.ToInt32(txtKeptOnFloorPcsReceived.Text ==""?"0": txtKeptOnFloorPcsReceived.Text);

            return _objProcessCutting;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdateData_Click(object sender, EventArgs e)
        {
            _objProcessCutting = new ProcessCutting();
            _objProcessCuttingBL = new ProcessCuttingBL();
            try
            {
                if (txtFinalTransferred.Text == "0") 
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingDetailError();", true);
                }
                else if (_otherItemStatus == false)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingDetailError();", true);
                }
                else if (Convert.ToInt32(txtreceived.Text) != (Convert.ToInt32(txtTotalPcsTransferred.Text) + Convert.ToInt32(txtbreakage.Text) + Convert.ToInt32(txtReject.Text)))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingDetailError();", true);
                }
                else
                {
                    Boolean _breakageRejectStatus = GetBreakageRejectRepeaterValue();

                    if (_breakageRejectStatus == false)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingDetailError();", true);
                    }
                    else
                    {
                        try
                        {
                            _objProcessCutting = _objProcessCuttingBL.GetAllProcessCuttingItems().Where(x => x.process_cutting_id == Convert.ToInt32(hdnItemId.Value)).FirstOrDefault();
                            if (_objProcessCutting.process_cutting_id > 0)
                            {
                                _objProcessCutting = _objProcessCuttingBL.UpdateProcessCutting(GetProcessCuttingUpdateObject());
                                if (_objProcessCutting.process_cutting_id > 0)
                                {
                                    //int itemMasterId = _objProcessCutting.item_master_id;
                                    //string batchNumber = _objProcessCutting.batch_number;
                                    if (_objProcessCutting.kept_on_floor_item_status == true)
                                    {
                                        _objOnFloorItemMasterBL = new OnFloorItemMasterBL();

                                        // _objOnFloorItemMaster = _objOnFloorItemMasterBL.GetAllOnFloorItemMasterItems().Where(x => x.on_floor_items_master_id == _objProcessCutting.kept_on_floor_item_master_id && x.items_pcs_quantity>0).FirstOrDefault();

                                        _lstOnFloorItemMaster = _objOnFloorItemMasterBL.GetAllOnFloorItemMasterItems().Where(x => x.on_floor_items_master_id == _objProcessCutting.item_master_id && x.items_pcs_quantity > 0).ToList();


                                        if (_lstOnFloorItemMaster != null)
                                        {
                                            if (_lstOnFloorItemMaster.Count > 0)
                                            {
                                                for (int _indexofOnFloorItemMaster = 0; _indexofOnFloorItemMaster < _lstOnFloorItemMaster.Count; _indexofOnFloorItemMaster++)
                                                {
                                                    _objOnFloorItemMaster = _lstOnFloorItemMaster[_indexofOnFloorItemMaster];
                                                    _objOnFloorItemMaster.items_pcs_quantity = 0;
                                                    _objOnFloorItemMaster = _objOnFloorItemMasterBL.UpdateOnFloorItemMaster(_objOnFloorItemMaster);

                                                }


                                            }
                                            else
                                            {

                                            }


                                        }
                                        else
                                        {

                                        }
                                    }
                                    else
                                    {

                                    }


                                    _objProductionBL = new ProductionBL();
                                    _objProduction = _objProductionBL.GetAllProductionItems().Where(x => x.item_master_id == _objProcessCutting.item_master_id && x.batch_number == _objProcessCutting.batch_number).FirstOrDefault();
                                    if (_objProduction.production_id > 0)
                                    {


                                        _objProduction.guid = _objProduction.guid;
                                        _objProduction.cutting_id = _objProcessCutting.process_cutting_id;
                                        _objProduction.cutting_quantity = _objProcessCutting.total_pcs_transferred;
                                        // _objProduction.is_under_cutting = true;
                                        _objProduction = _objProductionBL.UpdateProduction(_objProduction);
                                        if (_objProduction.production_id > 0)
                                        {
                                            string _productionId = _objProduction.production_id.ToString();
                                            string _itemMasterId = _objProduction.item_master_id.ToString();
                                            string _processName = "Cutting";
                                            string _heading = "Cutting Submitted Successfully";
                                            string _heading_class = "text-success";
                                            string _activity = "Cutting Submitted with Total Pcs Received from Sheet:" + _objProcessCutting.total_received + ", Breakage:" + _objProcessCutting.total_broken + "" + ", Rejected:" + _objProcessCutting.total_reject + ", Total Pcs Transfer:" + _objProcessCutting.total_pcs_transferred;
                                            string _icon = "fas fa-add";
                                            string _iconClass = "timeline-icon themed-background-emerald themed-border-emerald";
                                            ProductionTrailLogs(_productionId, _itemMasterId, _processName, _heading, _heading_class, _activity, _icon, _iconClass);

                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingProcessSuccess();", true);
                                            txtRemarks.Text = string.Empty;
                                            txtreceived.Text = txtbreakage.Text = txtReject.Text = txtFinalTransferred.Text = "0";
                                            btnUpdateData.Visible = false;
                                            btnResetData.Visible = false;
                                            btnSubmit.Visible = false;
                                            btnReset.Visible = false;
                                            txtDraftTargetPcs.Text = txtDraftActualPcs.Text = "0";

                                        }

                                    }

                                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingProcessSuccess();", true);

                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            ex.Message.ToString();
                        }
                       
                    }



                    
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            
        }

        protected void txtSheetIssued_TextChanged(object sender, EventArgs e)
        {
            //if (txtSheetIssued.Text == "0" || txtSheetIssued.Text == "" || txtSheetIssued.Text == null)
            //{
            //    txtSheetIssued.Text = "0";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showErrorSheet();", true);
            //    txtSheetIssued.Focus();
            //}
            //else
            //{
            //    int _sheetIssued, _sheetIssuedTargetPcs, _sheetIssuedActualPcs = 0;
            //    if (txtSheetIssued.Text == null || txtSheetIssued.Text == "")
            //    {
            //        txtSheetIssued.Text = "0";
            //    }
            //    if (txtSheetIssuedTargetPcs.Text == null || txtSheetIssuedTargetPcs.Text == "")
            //    {
            //        txtSheetIssuedTargetPcs.Text = "0";
            //    }


            //    _sheetIssued = Convert.ToInt32(txtSheetIssued.Text);
            //    _sheetIssuedTargetPcs = Convert.ToInt32(txtSheetIssuedTargetPcs.Text);
            //    _sheetIssuedActualPcs = Convert.ToInt32(txtSheetIssuedActualPcs.Text);

            //    _sheetIssuedActualPcs = (_sheetIssued * _sheetIssuedTargetPcs);
            //    txtSheetIssuedActualPcs.Text = _sheetIssuedActualPcs.ToString();
            //    txtTotalPcsTransferred.Text = txtSheetIssuedActualPcs.Text;
            //    txtSheetIssuedActualPcs.ReadOnly = true;

            //}

            if (txtSheetReceived.Text == "0" || txtSheetReceived.Text == "" || txtSheetReceived.Text == null)
            {
                txtSheetReceived.Text = "0";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showErrorSheet();", true);
                txtSheetIssued.Focus();
            }
            else
            {
                int _sheetReceived, _sheetIssuedTargetPcs, _sheetIssuedActualPcs = 0;
                if (txtSheetReceived.Text == null || txtSheetReceived.Text == "")
                {
                    txtSheetReceived.Text = "0";
                }
                if (txtSheetIssuedTargetPcs.Text == null || txtSheetIssuedTargetPcs.Text == "")
                {
                    txtSheetIssuedTargetPcs.Text = "0";
                }


                _sheetReceived = Convert.ToInt32(txtSheetReceived.Text);
                _sheetIssuedTargetPcs = Convert.ToInt32(txtSheetIssuedTargetPcs.Text);
                _sheetIssuedActualPcs = Convert.ToInt32(txtSheetIssuedActualPcs.Text);

                _sheetIssuedActualPcs = (_sheetReceived * _sheetIssuedTargetPcs);
                txtSheetIssuedActualPcs.Text = _sheetIssuedActualPcs.ToString();

                //Pcs from Broken Sheet - txtPcsCutFromSheet.text
                //
                // pcs from Draft size - txtDraftActualPcs.Text

                txtTotalPcsTransferred.Text = (Convert.ToInt32(txtKeptOnFloorPcsReceived.Text == "" ? "0" : txtKeptOnFloorPcsReceived.Text) + Convert.ToInt32(txtActualPcsFromRejection.Text == "" ? "0" : txtActualPcsFromRejection.Text) + Convert.ToInt32(txtSheetIssuedActualPcs.Text == "" ? "0" : txtSheetIssuedActualPcs.Text) + Convert.ToInt32(txtPcsCutFromSheet.Text == "" ? "0" : txtPcsCutFromSheet.Text) + Convert.ToInt32(txtDraftActualPcs.Text == "" ? "0" : txtDraftActualPcs.Text)).ToString();
                txtSheetIssuedActualPcs.ReadOnly = true;

            }

        }

        protected void btnResetData_Click(object sender, EventArgs e)
        {

        }

        protected void txtDraftTargetPcs_TextChanged(object sender, EventArgs e)
        {

            if (txtDraftTargetPcs.Text == "0" || txtDraftTargetPcs.Text == "" || txtDraftTargetPcs.Text == null)
            {
                txtDraftTargetPcs.Text = "0";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showErrorSheet();", true);
                txtDraftTargetPcs.Focus();
            }
            else
            {
                int _sheetReceived, _sheetIssuedTargetPcs, _sheetIssuedActualPcs = 0;
                if (txtSheetReceived.Text == null || txtSheetReceived.Text == "")
                {
                    txtSheetReceived.Text = "0";
                }
                if (txtSheetIssuedTargetPcs.Text == null || txtSheetIssuedTargetPcs.Text == "")
                {
                    txtSheetIssuedTargetPcs.Text = "0";
                }

                txtDraftActualPcs.Text = txtDraftTargetPcs.Text;
                _sheetReceived = Convert.ToInt32(txtSheetReceived.Text);
                _sheetIssuedTargetPcs = Convert.ToInt32(txtSheetIssuedTargetPcs.Text);
                _sheetIssuedActualPcs = Convert.ToInt32(txtSheetIssuedActualPcs.Text);

                _sheetIssuedActualPcs = (_sheetReceived * _sheetIssuedTargetPcs);
                txtSheetIssuedActualPcs.Text = _sheetIssuedActualPcs.ToString();

                //Pcs from Broken Sheet - txtPcsCutFromSheet.text
                //
                // pcs from Draft size - txtDraftActualPcs.Text


                txtTotalPcsTransferred.Text = (Convert.ToInt32(txtKeptOnFloorPcsReceived.Text == "" ? "0" : txtKeptOnFloorPcsReceived.Text) + Convert.ToInt32(txtActualPcsFromRejection.Text == "" ? "0" : txtActualPcsFromRejection.Text) + Convert.ToInt32(txtSheetIssuedActualPcs.Text == "" ? "0" : txtSheetIssuedActualPcs.Text) + Convert.ToInt32(txtPcsCutFromSheet.Text == "" ? "0" : txtPcsCutFromSheet.Text) + Convert.ToInt32(txtDraftActualPcs.Text == "" ? "0" : txtDraftActualPcs.Text)).ToString();
                txtSheetIssuedActualPcs.ReadOnly = true;

            }
        }

        protected void txtPcsFromRejection_TextChanged(object sender, EventArgs e)
        {
            if (txtPcsFromRejection.Text == "0" || txtPcsFromRejection.Text == "" || txtPcsFromRejection.Text == null)
            {
                txtPcsFromRejection.Text = "0";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showErrorSheet();", true);
                txtPcsFromRejection.Focus();
            }
            else
            {
                int _sheetReceived, _sheetIssuedTargetPcs, _sheetIssuedActualPcs = 0;
                if (txtSheetReceived.Text == null || txtSheetReceived.Text == "")
                {
                    txtSheetReceived.Text = "0";
                }
                if (txtSheetIssuedTargetPcs.Text == null || txtSheetIssuedTargetPcs.Text == "")
                {
                    txtSheetIssuedTargetPcs.Text = "0";
                }
                if (txtDraftTargetPcs.Text == null || txtDraftTargetPcs.Text == "")
                {
                    txtDraftTargetPcs.Text = "0";
                }

                txtDraftActualPcs.Text = txtDraftTargetPcs.Text;
                txtActualPcsFromRejection.Text = txtPcsFromRejection.Text;
                _sheetReceived = Convert.ToInt32(txtSheetReceived.Text);
                _sheetIssuedTargetPcs = Convert.ToInt32(txtSheetIssuedTargetPcs.Text);
                _sheetIssuedActualPcs = Convert.ToInt32(txtSheetIssuedActualPcs.Text);

                _sheetIssuedActualPcs = (_sheetReceived * _sheetIssuedTargetPcs);
                txtSheetIssuedActualPcs.Text = _sheetIssuedActualPcs.ToString();

                //Pcs from Broken Sheet - txtPcsCutFromSheet.text
                //
                // pcs from Draft size - txtDraftActualPcs.Text


              //  txtTotalPcsTransferred.Text = (Convert.ToInt32(txtKeptOnFloorPcsReceived.Text == "" ? "0" : txtKeptOnFloorPcsReceived.Text) + Convert.ToInt32(txtActualPcsFromRejection.Text == "" ? "0" : txtActualPcsFromRejection.Text) + Convert.ToInt32(txtSheetIssuedActualPcs.Text == "" ? "0" : txtSheetIssuedActualPcs.Text) + Convert.ToInt32(txtPcsCutFromSheet.Text == "" ? "0" : txtPcsCutFromSheet.Text) + Convert.ToInt32(txtDraftActualPcs.Text == "" ? "0" : txtDraftActualPcs.Text)).ToString();
                txtTotalPcsTransferred.Text = (Convert.ToInt32(txtKeptOnFloorPcsReceived.Text == "" ? "0" : txtKeptOnFloorPcsReceived.Text) + Convert.ToInt32(txtActualPcsFromRejection.Text == "" ? "0" : txtActualPcsFromRejection.Text) + Convert.ToInt32(txtSheetIssuedActualPcs.Text == "" ? "0" : txtSheetIssuedActualPcs.Text) + Convert.ToInt32(txtPcsCutFromSheet.Text == "" ? "0" : txtPcsCutFromSheet.Text) + Convert.ToInt32(txtDraftActualPcs.Text == "" ? "0" : txtDraftActualPcs.Text)).ToString();
                txtSheetIssuedActualPcs.ReadOnly = true;

            }
        }

        protected void rptrOnFloorOtherItemsList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string commandname = e.CommandName;
            string id = e.CommandArgument.ToString();


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
                case "update":
                    try
                    {

                       // Label lblItemMasterId = (Label)e.Item.FindControl("lblItemMasterId");
                        Label lblOnFloorItemPcsStatus = (Label)e.Item.FindControl("lblOnFloorItemPcsStatus");
                        Label lblOnFloorItemPcsTotalExpected = (Label)e.Item.FindControl("lblOnFloorItemPcsTotalExpected");
                        LinkButton btnUpdateOnFloorItemPcs = (LinkButton)e.Item.FindControl("btnUpdateOnFloorItemPcs");
                        TextBox txtOnFloorItemPcsProduce = (TextBox)e.Item.FindControl("txtOnFloorItemPcsProduce");
                        TextBox txtOnFloorItemRemark = (TextBox)e.Item.FindControl("txtOnFloorItemRemark");

                        if (txtOnFloorItemPcsProduce.Text == "0" || txtOnFloorItemPcsProduce.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                        }
                        else if (Convert.ToInt32(txtOnFloorItemPcsProduce.Text) > Convert.ToInt32(lblOnFloorItemPcsTotalExpected.Text))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                        }
                        else
                        {
                            _objOnFloorItemMasterBL = new OnFloorItemMasterBL();

                            _objOnFloorItemMaster = _objOnFloorItemMasterBL.GetOnFloorItemMasterItemsByID(Convert.ToInt32(id)).FirstOrDefault();
                            if (_objOnFloorItemMaster != null)
                            {
                                _objOnFloorItemMaster.items_pcs_quantity = Convert.ToInt32(txtOnFloorItemPcsProduce.Text);
                                _objOnFloorItemMaster.remarks = txtOnFloorItemRemark.Text;
                                _objOnFloorItemMaster = _objOnFloorItemMasterBL.UpdateOnFloorItemMaster(_objOnFloorItemMaster);
                                if (_objOnFloorItemMaster != null)
                                {

                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccess();", true);
                                    btnUpdateOnFloorItemPcs.Visible = false;
                                    lblOnFloorItemPcsStatus.Visible = true;
                                    lblOnFloorItemPcsStatus.Text = "Updated";
                                    _otherItemStatus = true;
                                    BindOnFloorOtherItemRptr(_objOnFloorItemMaster.batch_number, _objOnFloorItemMaster.parent_item_master_id.ToString());
                                }
                                else
                                {
                                    _otherItemStatus = false;
                                }
                            }
                            else
                            {

                            }
                        }



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

        protected void rptrOnFloorOtherItemsList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Label lblOnFloorItemPcsStatus = (Label)e.Item.FindControl("lblOnFloorItemPcsStatus");
                    Label lblOnFloorItemRemark = (Label)e.Item.FindControl("lblOnFloorItemRemark");
                    Label lblOnFloorItemPcsProduce = (Label)e.Item.FindControl("lblOnFloorItemPcsProduce");
                    TextBox txtOnFloorItemPcsProduce = (TextBox)e.Item.FindControl("txtOnFloorItemPcsProduce");
                    TextBox txtOnFloorItemRemark = (TextBox)e.Item.FindControl("txtOnFloorItemRemark");
                    LinkButton btnUpdateOnFloorItemPcs = (LinkButton)e.Item.FindControl("btnUpdateOnFloorItemPcs");

                    if(txtOnFloorItemPcsProduce.Text=="" || txtOnFloorItemPcsProduce.Text == "0")
                    {
                        _otherItemStatus = false;
                        lblOnFloorItemPcsStatus.Visible = false;
                        btnUpdateOnFloorItemPcs.Visible = true;
                        if (txtOnFloorItemPcsProduce.Text == "" || txtOnFloorItemPcsProduce.Text == "0")
                        {
                            lblOnFloorItemRemark.Visible = false;
                            txtOnFloorItemPcsProduce.Visible = true;
                            lblOnFloorItemPcsProduce.Visible = false;
                            txtOnFloorItemRemark.Visible = true;
                        }
                        else
                        {
                            lblOnFloorItemRemark.Visible = true;
                            txtOnFloorItemPcsProduce.Visible = false;
                            lblOnFloorItemPcsProduce.Visible = true;
                            txtOnFloorItemRemark.Visible = false;
                        }
                    }
                    else
                    {
                        _otherItemStatus = true;
                        lblOnFloorItemPcsStatus.Visible = true;
                        btnUpdateOnFloorItemPcs.Visible = false;

                        if (txtOnFloorItemPcsProduce.Text == "" || txtOnFloorItemPcsProduce.Text == "0")
                        {
                            lblOnFloorItemRemark.Visible = false;
                            txtOnFloorItemPcsProduce.Visible = true;
                            lblOnFloorItemPcsProduce.Visible = false;
                            txtOnFloorItemRemark.Visible = true;
                        }
                        else
                        {
                            lblOnFloorItemRemark.Visible = true;
                            txtOnFloorItemPcsProduce.Visible = false;
                            lblOnFloorItemPcsProduce.Visible = true;
                            txtOnFloorItemRemark.Visible = false;
                        }

                    }
                    
                   
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "notification('Something went wrong','danger');", true);
            }
        }

        protected void rptrDraftList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void rptrDraftList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    Label lblOnFloorQuantityPerSheet = (Label)e.Item.FindControl("lblOnFloorQuantityPerSheet");
                    Label lblOnFloorItemPcsTotalExpected = (Label)e.Item.FindControl("lblOnFloorItemPcsTotalExpected");
                    Label lblDisplayItemNameforDraftInCutting = (Label)e.Item.FindControl("lblDisplayItemNameforDraftInCutting");

                    lblDisplayItemNameforDraftInCutting.Text = txtItemName.Text;
                    if (lblOnFloorQuantityPerSheet.Text != null && lblOnFloorQuantityPerSheet.Text!="")
                    {
                        if (txtDraftActualPcs.Text == "" || txtDraftTargetPcs.Text ==null)
                        {
                            txtDraftActualPcs.Text ="0";
                        }
                        else
                        {
                            

                            int _draftTargetPcs = Convert.ToInt32(txtDraftTargetPcs.Text);
                            int _onFloorQuantityPerSheet = Convert.ToInt32(lblOnFloorQuantityPerSheet.Text);

                            int _draftActualPcs = Convert.ToInt32(txtDraftActualPcs.Text);
                            int _onFloorItemPcsTotalExpected = Convert.ToInt32(lblOnFloorItemPcsTotalExpected.Text);


                            txtDraftTargetPcs.Text = (_draftTargetPcs + _onFloorQuantityPerSheet).ToString();
                            txtDraftActualPcs.Text = (_draftActualPcs + _onFloorItemPcsTotalExpected).ToString();
                        }

                    }
                    else
                    {

                    }
                   

                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "notification('Something went wrong','danger');", true);
            }
        }

        protected void txtKeptOnFloorPcsReceived_TextChanged(object sender, EventArgs e)
        {
            if (txtKeptOnFloorPcsReceived.Text == "0" || txtKeptOnFloorPcsReceived.Text == "" || txtKeptOnFloorPcsReceived.Text == null)
            {
                txtKeptOnFloorPcsReceived.Text = "0";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showErrorSheet();", true);
                txtKeptOnFloorPcsReceived.Focus();
            }
            else if ( Convert.ToInt32( txtKeptOnFloorPcsReceived.Text) > Convert.ToInt32(txtKeptOnFloorPcsQuantity.Text))
            {
                txtKeptOnFloorPcsReceived.Text = "0";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showErrorSheet();", true);
                txtKeptOnFloorPcsReceived.Focus();
            }
            else
            {
                int _sheetReceived, _sheetIssuedTargetPcs, _sheetIssuedActualPcs = 0;
                if (txtSheetReceived.Text == null || txtSheetReceived.Text == "")
                {
                    txtSheetReceived.Text = "0";
                }
                if (txtSheetIssuedTargetPcs.Text == null || txtSheetIssuedTargetPcs.Text == "")
                {
                    txtSheetIssuedTargetPcs.Text = "0";
                }
                if (txtDraftTargetPcs.Text == null || txtDraftTargetPcs.Text == "")
                {
                    txtDraftTargetPcs.Text = "0";
                    txtDraftActualPcs.Text = txtDraftTargetPcs.Text;
                }

                
                _sheetReceived = Convert.ToInt32(txtSheetReceived.Text);
                _sheetIssuedTargetPcs = Convert.ToInt32(txtSheetIssuedTargetPcs.Text);
                _sheetIssuedActualPcs = Convert.ToInt32(txtSheetIssuedActualPcs.Text);

                _sheetIssuedActualPcs = (_sheetReceived * _sheetIssuedTargetPcs);
                txtSheetIssuedActualPcs.Text = _sheetIssuedActualPcs.ToString();

                //Pcs from Broken Sheet - txtPcsCutFromSheet.text
                //
                // pcs from Draft size - txtDraftActualPcs.Text


                txtTotalPcsTransferred.Text = (Convert.ToInt32(txtKeptOnFloorPcsReceived.Text == "" ? "0" : txtKeptOnFloorPcsReceived.Text) + Convert.ToInt32(txtActualPcsFromRejection.Text == "" ? "0" : txtActualPcsFromRejection.Text) + Convert.ToInt32(txtSheetIssuedActualPcs.Text == "" ? "0" : txtSheetIssuedActualPcs.Text) + Convert.ToInt32(txtPcsCutFromSheet.Text == "" ? "0" : txtPcsCutFromSheet.Text) + Convert.ToInt32(txtDraftActualPcs.Text == "" ? "0" : txtDraftActualPcs.Text)).ToString();
                txtSheetIssuedActualPcs.ReadOnly = true;

            }
        }

        protected void txtSheetIssuedTargetPcs_TextChanged(object sender, EventArgs e)
        {
            //if (txtSheetIssuedTargetPcs.Text == "0" || txtSheetIssuedTargetPcs.Text == "")
            //{
            //    txtSheetIssuedTargetPcs.Text = "0";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showErrorSheet();", true);
            //    txtSheetIssuedTargetPcs.Focus();
            //}
            //else
            //{
            //    int _sheetIssued, _sheetIssuedTargetPcs, _sheetIssuedActualPcs = 0;
            //    if (txtSheetIssued.Text == null || txtSheetIssued.Text == "")
            //    {
            //        txtSheetIssued.Text = "0";
            //    }
            //    if (txtSheetIssuedTargetPcs.Text == null || txtSheetIssuedTargetPcs.Text == "")
            //    {
            //        txtSheetIssuedTargetPcs.Text = "0";
            //    }


            //    _sheetIssued = Convert.ToInt32(txtSheetIssued.Text);
            //    _sheetIssuedTargetPcs = Convert.ToInt32(txtSheetIssuedTargetPcs.Text);
            //    _sheetIssuedActualPcs = Convert.ToInt32(txtSheetIssuedActualPcs.Text);

            //    _sheetIssuedActualPcs = (_sheetIssued * _sheetIssuedTargetPcs);
            //    txtSheetIssuedActualPcs.Text = _sheetIssuedActualPcs.ToString();
            //    txtTotalPcsTransferred.Text = txtSheetIssuedActualPcs.Text;
            //    txtSheetIssuedActualPcs.ReadOnly = true;
            //}

            if (txtSheetReceived.Text == "0" || txtSheetReceived.Text == "" || txtSheetReceived.Text == null)
            {
                txtSheetReceived.Text = "0";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showErrorSheet();", true);
                txtSheetIssued.Focus();
            }
            else
            {
                int _sheetReceived, _sheetIssuedTargetPcs, _sheetIssuedActualPcs = 0;
                if (txtSheetReceived.Text == null || txtSheetReceived.Text == "")
                {
                    txtSheetReceived.Text = "0";
                }
                if (txtSheetIssuedTargetPcs.Text == null || txtSheetIssuedTargetPcs.Text == "")
                {
                    txtSheetIssuedTargetPcs.Text = "0";
                }


                _sheetReceived = Convert.ToInt32(txtSheetReceived.Text);
                _sheetIssuedTargetPcs = Convert.ToInt32(txtSheetIssuedTargetPcs.Text);
                _sheetIssuedActualPcs = Convert.ToInt32(txtSheetIssuedActualPcs.Text);

                _sheetIssuedActualPcs = (_sheetReceived * _sheetIssuedTargetPcs);
                txtSheetIssuedActualPcs.Text = _sheetIssuedActualPcs.ToString();

                //Pcs from Broken Sheet - txtPcsCutFromSheet.text
                //
                // pcs from Draft size - txtDraftActualPcs.Text


                txtTotalPcsTransferred.Text = (Convert.ToInt32(txtKeptOnFloorPcsReceived.Text == "" ? "0" : txtKeptOnFloorPcsReceived.Text) + Convert.ToInt32(txtActualPcsFromRejection.Text == "" ? "0" : txtActualPcsFromRejection.Text) + Convert.ToInt32(txtSheetIssuedActualPcs.Text == "" ? "0" : txtSheetIssuedActualPcs.Text) + Convert.ToInt32(txtPcsCutFromSheet.Text == "" ? "0" : txtPcsCutFromSheet.Text) + Convert.ToInt32(txtDraftActualPcs.Text == "" ? "0" : txtDraftActualPcs.Text)).ToString();
                txtSheetIssuedActualPcs.ReadOnly = true;
            }


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