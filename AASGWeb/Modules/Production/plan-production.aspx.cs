using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using App.Core;
using App.Business;
using App.BusinessModel;
using System.Globalization;
using System.Web.UI.HtmlControls;

namespace AASGWeb.Modules.Production
{
    public partial class plan_production : System.Web.UI.Page
    {
        #region Global Properties

        ProductionPlanning _objProductionPlanning = new ProductionPlanning();
        List<ProductionPlanning> _lstProductionPlanning = new List<ProductionPlanning>();

        App.BusinessModel.Production _objProduction = new App.BusinessModel.Production();
        ProductionBL _objProductionBL = null;
        List<App.BusinessModel.Production> _lstProduction = new List<App.BusinessModel.Production>();

        ProcessCutting _objProcessCutting = new ProcessCutting();
        ProcessCuttingBL _objProcessCuttingBL = null;
        List<ProcessCutting> _lstProcessCutting = new List<ProcessCutting>();

        ProcessGrinding _objProcessGrinding = new ProcessGrinding();
        ProcessGrindingBL _objProcessGrindingBL = null;
        List<ProcessGrinding> _lstProcessGrinding = new List<ProcessGrinding>();

        ProcessWashingOne _objProcessWashingOne = new ProcessWashingOne();
        ProcessWashingOneBL _objProcessWashingOneBL = null;
        List<ProcessWashingOne> _lstProcessWashingOne = new List<ProcessWashingOne>();

        ProcessHole _objProcessHole = new ProcessHole();
        ProcessHoleBL _objProcessHoleBL = null;
        List<ProcessHole> _lstProcessHole = new List<ProcessHole>();

        ProcessWashing _objProcessWashing = new ProcessWashing();
        ProcessWashingBL _objProcessWashingBL = null;
        List<ProcessWashing> _lstProcessWashing = new List<ProcessWashing>();

        ProcessPaint _objProcessPaint = new ProcessPaint();
        ProcessPaintBL _objProcessPaintBL = null;
        List<ProcessPaint> _lstProcessPaint = new List<ProcessPaint>();

        ProcessDfgPrint _objProcessDfgPrint = new ProcessDfgPrint();
        ProcessDfgPrintBL _objProcessDfgPrintBL = null;
        List<ProcessDfgPrint> _lstProcessDfgPrint = new List<ProcessDfgPrint>();

        ProcessTempering _objProcessTempering = new ProcessTempering();
        ProcessTemperingBL _objProcessTemperingBL = null;
        List<ProcessTempering> _lstProcessTempering = new List<ProcessTempering>();

        ProcessTemperingReport _objProcessTemperingReport = new ProcessTemperingReport();
        ProcessTemperingReportBL _objProcessTemperingReportBL = null;
        List<ProcessTemperingReport> _lstProcessTemperingReport = new List<ProcessTemperingReport>();

        ProcessPackaging _objProcessPackaging = new ProcessPackaging();
        ProcessPackagingBL _objProcessPackagingBL = null;
        List<ProcessPackaging> _lstProcessPackaging = new List<ProcessPackaging>();

        ProcessStore _objProcessStore = new ProcessStore();
        ProcessStoreBL _objProcessStoreBL = null;
        List<ProcessStore> _lstProcessStore = new List<ProcessStore>();


        ItemMaster _objItemMaster = new ItemMaster();
        ItemMasterBL _objItemMasterBL = null;
        List<ItemMaster> _lstItemMaster = new List<ItemMaster>();

        ProductionTrail _objProductionTrail = new ProductionTrail();
        ProductionTrailBL _objProductionTrailBL = null;
        List<ProductionTrail> _lstProductionTrail = new List<ProductionTrail>();

        DrawingMaster _objDrawingMaster = new DrawingMaster();
        DrawingMasterBL _objDrawingMasterBL = null;
        List<DrawingMaster> _lstDrawingMaster = new List<DrawingMaster>();

        OnFloorItemMaster _objOnFloorItemMaster = new OnFloorItemMaster();
        OnFloorItemMasterBL _objOnFloorItemMasterBL = null;
        List<OnFloorItemMaster> _lstOnFloorItemMaster = new List<OnFloorItemMaster>();

        DraftMaster _objDraftMaster = new DraftMaster();
        DraftMasterBL _objDraftMasterBL = null;
        List<DraftMaster> _lstDraftMaster = new List<DraftMaster>();

        vwItemListWithModelAndGlassColor _objItemListWithModelAndGlassColor = new vwItemListWithModelAndGlassColor();

        List<vwItemListWithModelAndGlassColor> _lstvwItemListWithModelAndGlassColor = new List<vwItemListWithModelAndGlassColor>();

        PartyMaster _objPartyMaster = new PartyMaster();
        PartyMasterBL _objPartyMasterBL = null;
        List<PartyMaster> _lstPartyMaster = new List<PartyMaster>();

        DataTable _datatable , _dataTableItemsList = new DataTable();
        string UserIp = string.Empty;
        string _is_washingOne_required, _is_hole_required , _is_washing_required, _is_normal_paint, is_dfg_paint = string.Empty;
        public static string _shiftName, _plantName , _plannedDate = string.Empty;
        string[] arrOfProductionsheetSize, arrOfItemHeightWidth, arrOfProductionPartyId;
        public static int _totalItemCount = 0;
       
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            // Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {

                BindProductionRptr();
                _shiftName = _plantName = string.Empty;
                txttotalExpectation.ReadOnly = txtTotalExpectationfromOther.ReadOnly = true; 
                txtSheetHeight.Text= txtSheetWidth.Text = txtNoofSheetIssue.Text = txtQuantityPerSheet.Text = txttotalExpectation.Text = txtItemQuantityPerSheetfromOther.Text = txtTotalExpectationfromOther.Text = "0";
            }
            
        }

        #region Pageload method


        /// <summary>
        /// This Method is Used to Get Procduction Details of All Items and Items Current Status Department Wise and Data in Repeater
        /// </summary>
        private void BindProductionRptr()
        {
            _objProductionBL = new ProductionBL();
          DateTime _date_Afetr_Add_Two_Days =DateTime.Today.AddDays(2);
           // _lstProduction = _objProductionBL.GetAllProductionItems().Where(x => x.planned_date >= DateTime.Today.AddDays(-2) && x.planned_date <= _date_Afetr_Add_Two_Days).OrderByDescending(x => x.production_id).ToList();
           _lstProduction = _objProductionBL.GetAllProductionItems().OrderByDescending(x => x.production_id).ToList();
            rptrProductionDetail.DataSource = _lstProduction;
            rptrProductionDetail.DataBind();
        }


        /// <summary>
        /// This Method is Used to Get ItemName WIth GlassColor 
        /// </summary>
        private void BindItemsName(string _itemThickness)
        {
            try
            {
                ddlItemList.Items.Clear();
                _objItemMasterBL = new ItemMasterBL();
                _lstvwItemListWithModelAndGlassColor = _objItemMasterBL.GetVwItemListWithModelAndGlassColors().Where(x => x.thickness == _itemThickness).OrderBy(x => x.model).ToList();
                ddlItemList.DataSource = _lstvwItemListWithModelAndGlassColor;
                ddlItemList.DataTextField = "modelwithglass";
                ddlItemList.DataValueField = "item_master_id";
                ddlItemList.DataBind();
                ddlItemList.Items.Insert(0, new ListItem("Select", "0"));
            }
            catch (Exception ex) {   ex.Message.ToString();  }
        }


        /// <summary>
        /// This Method is Used to Get Draft Item Name at on Floor 
        /// </summary>
        private void BindDraftItemsName()
        {
            try
            {
                ddlItemList.Items.Clear();
                _objDraftMasterBL = new DraftMasterBL();
                _lstDraftMaster = _objDraftMasterBL.GetAllDraftMasterItems().Where( x => x.draft_status== "available").OrderBy(x => x.draft_master_id).ToList();
                if (_lstDraftMaster != null)
                {
                    if (_lstDraftMaster.Count >0)
                    {
                        ddlItemList.DataSource = _lstDraftMaster;
                       // ddlItemList.DataTextField = "left_over_size";
                        ddlItemList.DataTextField = "items_name";
                        ddlItemList.DataValueField = "draft_master_id";
                        ddlItemList.DataBind();
                        ddlItemList.Items.Insert(0, new ListItem("Select", "0"));
                    }
                }
                
            }
            catch (Exception ex) {  ex.Message.ToString();  }
        }

        #endregion


        #region Search By Plant Name
        /// <summary>
        /// This Method is Used to Get Procduction Details of All Items and Items Current Status Department Wise and Data in Repeater
        /// </summary>
        private void BindProductionRptrBySelectPlant(string _selectedPlantName)
        {
            _objProductionBL = new ProductionBL();
            DateTime _date_Afetr_Add_Two_Days = DateTime.Today.AddDays(2);
            _lstProduction = _objProductionBL.GetAllProductionItems().Where(x => x.production_plant== _selectedPlantName && x.planned_date >= DateTime.Today && x.planned_date <= _date_Afetr_Add_Two_Days).OrderByDescending(x => x.production_id).ToList();
            rptrProductionDetail.DataSource = _lstProduction;
            rptrProductionDetail.DataBind();
        }

        #endregion


        #region Search By ItemMasterId
        /// <summary>
        /// This Method is Used to Get Drawing List Details
        /// </summary>
        private void BindDrawingItemListrptr(string _itemMasterId)
        {
            try
            {
                _objDrawingMasterBL = new DrawingMasterBL();

                _lstDrawingMaster = _objDrawingMasterBL.GetAllDrawingMasterItems().Where( x => x.selected_item_master_id.Contains(_itemMasterId)).OrderByDescending(x => x.drawing_master_id).ToList();
                if (_lstDrawingMaster != null)
                {
                    rptrDrawingItemList.DataSource = _lstDrawingMaster;
                    rptrDrawingItemList.DataBind();

                    lblSelectedDrawingName.Text = lblSelectedDrawingId.Text= string.Empty;
    
                        txtSheetHeight.ReadOnly = (Convert.ToInt32(txtSheetHeight.Text) == 0 ? false : true);
                        txtSheetWidth.ReadOnly = (Convert.ToInt32(txtSheetWidth.Text) == 0 ? false : true);
                        txtNoofSheetIssue.ReadOnly = (Convert.ToInt32(txtNoofSheetIssue.Text) == 0 ? false : true);
                        txtQuantityPerSheet.ReadOnly = (Convert.ToInt32(txtQuantityPerSheet.Text) == 0 ? false : true);

                    if (rptrAcknowledgeItemsList.Items.Count>0)
                    {   
                        rptrAcknowledgeItemsList.Visible = true;
                    }
                    else
                    {
                        rptrAcknowledgeItemsList.DataSource = null;
                        rptrAcknowledgeItemsList.DataBind();
                        rptrAcknowledgeItemsList.Visible = false;
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);

                }
            }
            catch (Exception ex) {   ex.Message.ToString(); }
           
        }

        private void BindDrawingItemListrptrV2(string _itemMasterId)
        {
            try
            {
                _objDrawingMasterBL = new DrawingMasterBL();

                _lstDrawingMaster = _objDrawingMasterBL.GetAllDrawingMasterItems().Where(x => x.selected_item_master_id.Contains(_itemMasterId)).OrderByDescending(x => x.drawing_master_id).ToList();
                if (_lstDrawingMaster != null)
                {
                    rptrDrawingItemList.DataSource = _lstDrawingMaster;
                    rptrDrawingItemList.DataBind();

                    txtSheetHeight.ReadOnly = (Convert.ToInt32(txtSheetHeight.Text) == 0 ? false : true);
                    txtSheetWidth.ReadOnly = (Convert.ToInt32(txtSheetWidth.Text) == 0 ? false : true);
                    txtNoofSheetIssue.ReadOnly = (Convert.ToInt32(txtNoofSheetIssue.Text) == 0 ? false : true);
                    txtQuantityPerSheet.ReadOnly = (Convert.ToInt32(txtQuantityPerSheet.Text) == 0 ? false : true);

                    if (rptrAcknowledgeItemsList.Items.Count > 0)
                    {
                        rptrAcknowledgeItemsList.Visible = true;
                    }
                    else
                    {
                        rptrAcknowledgeItemsList.DataSource = null;
                        rptrAcknowledgeItemsList.DataBind();
                        rptrAcknowledgeItemsList.Visible = false;
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);

                }
            }
            catch (Exception ex) {     ex.Message.ToString(); }

        }

        #endregion

        protected void ddlShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList _ddlShiftName = (DropDownList)sender;
            RepeaterItem item = (RepeaterItem)_ddlShiftName.NamingContainer;
            if (_ddlShiftName.SelectedValue != "" && _ddlShiftName.SelectedValue != null)
            {
                _shiftName = _ddlShiftName.SelectedValue.ToString();
            }
            else
            {
                _shiftName = "";
            }
        }

        protected void txtPlannedDate_TextChanged(object sender, EventArgs e)
        {

            TextBox _txtplannedDate = (TextBox)sender;
            RepeaterItem item = (RepeaterItem)_txtplannedDate.NamingContainer;
            if (_txtplannedDate.Text != "" && _txtplannedDate.Text != null)
            {
                _plannedDate = _txtplannedDate.Text;
            }
            else
            {
                _plannedDate = "";
            }
        }

        protected void ddlPlant_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList _ddlPlantName = (DropDownList)sender;
            RepeaterItem item = (RepeaterItem)_ddlPlantName.NamingContainer;
            if (_ddlPlantName.SelectedValue !="" && _ddlPlantName.SelectedValue!=null)
            {
                _plantName = _ddlPlantName.SelectedValue.ToString();
            }
            else
            {
                _plantName = "";
            }
        }


        #region Production Repeater

        protected void rptrProductionDetail_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string commandname = e.CommandName;
            string id = e.CommandArgument.ToString();

            Int32 ID = Convert.ToInt32(id);
            switch (commandname)
            {
                case "active":
                    try
                    {
                        DropDownList ddlPlant = (DropDownList)e.Item.FindControl("ddlPlant");
                        DropDownList ddlShift = (DropDownList)e.Item.FindControl("ddlShift");
                        //var ddlShift = "Day";
                        //_shiftName = ddlShift;
                        Label lblItemMasterId = (Label)e.Item.FindControl("lblItemMasterId");
                        TextBox txtPlannedDate = (TextBox)e.Item.FindControl("txtPlannedDate");
                        // DateTime txtPlannedDate = DateTime.Now;
                        //// _plannedDate = txtPlannedDate.ToShortDateString();
                        // string _tempDateResult = txtPlannedDate.ToShortDateString();
                        // string[] dateString = _tempDateResult.Split('/');
                        // _plannedDate = dateString[1] + "/" + dateString[0] + "/" + dateString[2];
                        if ( ddlShift == null)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showShiftAlert();", true);
                        }
                        else
                        {
                            if (txtPlannedDate != null)
                            {
                                if (_plannedDate == "")
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showPlannedDateAlert();", true);
                                }
                                else
                                {
                                    _plantName = ddlPlant.SelectedValue.ToString();
                                 
                                    hdnfAcknowledgeProductionId.Value = id.ToString();
                                    hdnfAcknowledgePlantName.Value = _plantName.ToString();
                                    if(lblItemMasterId.Text != "")
                                    {
                                        hdnfAcknowledgeProductionItemMasterId.Value = lblItemMasterId.Text;

                                        DateTime _plane_Date = DateTime.Parse(_plannedDate, CultureInfo.CreateSpecificCulture("fr-FR"));

                                        //This for Get Item in Production or Not ,if Not in Production Then Show Modal for next Process other Wise Show alert for Item in Production

                                        _objProductionBL = new ProductionBL();

                                        //Convert Date and Create Date for Match Data

                                        DateTime _convertPlannedDate = Convert.ToDateTime(_plane_Date);
                                        DateTime _finalPlannedDate = new DateTime(_convertPlannedDate.Year, _convertPlannedDate.Month, _convertPlannedDate.Day, _convertPlannedDate.Hour, _convertPlannedDate.Minute, _convertPlannedDate.Second);

                                        //this is original and main Line but its comment due to client want to add multiple item in same plant at same time

                                       // _objProduction = _objProductionBL.GetAllProductionItems().Where(x => x.production_plant == hdnfAcknowledgePlantName.Value && x.production_status == App.Helper.Utils.OrderStatus.production.ToString() && x.planned_date == Convert.ToDateTime(_finalPlannedDate)).FirstOrDefault();

                                        _objProduction = _objProductionBL.GetAllProductionItems().Where(x => x.production_plant == hdnfAcknowledgePlantName.Value && x.production_status == App.Helper.Utils.OrderStatus.production.ToString() && x.planned_date == Convert.ToDateTime(_finalPlannedDate) && x.item_master_id == Convert.ToInt32( hdnfAcknowledgeProductionItemMasterId.Value)).FirstOrDefault();


                                        if (_objProduction != null)
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlreadyInProduction();", true);
                                        }
                                        else
                                        {
                                            string _itemMasterId = lblItemMasterId.Text == "" ? "0" : lblItemMasterId.Text;
                                            _objItemMasterBL = new ItemMasterBL();
                                            _objItemMaster = _objItemMasterBL.GetAllItemMasterItems().Where(x => x.item_master_id == Convert.ToInt32(_itemMasterId)).FirstOrDefault();

                                            if (_objItemMaster != null)
                                            {
                                                txtItemName.ReadOnly = true;
                                                txtItemName.Text = _objItemMaster.model + " | " + _objItemMaster.item_type_name + " | " + _objItemMaster.glass_color;
                                                txtThickness.Text = _objItemMaster.thickness;

                                                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);

                                                _objOnFloorItemMasterBL = new OnFloorItemMasterBL();
                                                //_objOnFloorItemMaster = _objOnFloorItemMasterBL.GetAllOnFloorItemMasterItems().Where(x => x.on_floor_items_master_id == _objItemMaster.item_master_id && x.items_pcs_quantity >0).FirstOrDefault();
                                                _lstOnFloorItemMaster = _objOnFloorItemMasterBL.GetAllOnFloorItemMasterItems().Where(x => x.on_floor_items_master_id == _objItemMaster.item_master_id && x.items_pcs_quantity > 0).ToList();
                                                
                                                if (_lstOnFloorItemMaster != null)
                                                {
                                                    lblKeptonFloorPcs.Text = "0";
                                                    lblKeptonFloorItemMasterId.Text = "0";
                                                    if (_lstOnFloorItemMaster.Count > 0)
                                                    {
                                                        for (int _indexOnFloorItemMaster = 0; _indexOnFloorItemMaster < _lstOnFloorItemMaster.Count; _indexOnFloorItemMaster++)
                                                        {
                                                            lblKeptonFloorPcs.Text = (Convert.ToInt32(lblKeptonFloorPcs.Text) + Convert.ToInt32(_lstOnFloorItemMaster[_indexOnFloorItemMaster].items_pcs_quantity)).ToString();
                                                            lblKeptonFloorItemMasterId.Text = _lstOnFloorItemMaster[_indexOnFloorItemMaster].on_floor_items_master_id.ToString();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        lblKeptonFloorPcs.Text = "0";
                                                    }
                                                    // lblKeptonFloorPcs.Text = ( Convert.ToInt32( _objOnFloorItemMaster.broken_sheet_quantity)*Convert.ToInt32(_objOnFloorItemMaster.per_broken_sheet_quantity)).ToString();
                                                    


                                                    //lblKeptonFloorPcs.Text = (Convert.ToInt32(_objOnFloorItemMaster.items_pcs_quantity)).ToString();
                                                }
                                                else
                                                {
                                                    lblKeptonFloorPcs.Text = "0";
                                                }
                                                
                                                BindDrawingItemListrptr(_itemMasterId);
                                            }
                                            else
                                            {

                                            }
                                        }

                                        //End Get Item in Production
                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                                    }

                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showPlannedDateAlert();", true);
                            }
                        }
                        // TextBox txtPlannedDate = (TextBox)e.Item.FindControl("txtPlannedDate");
                       
                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;
                case "start":
                    try
                    {
                        Label lblCurrentStatus = (Label)e.Item.FindControl("lblCurrentStatus");
                        if (lblCurrentStatus.Text == App.Helper.Utils.OrderStatus.hold.ToString())
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showNotPermission();", true);
                        }
                        else
                        {
                            StartDepartmentProcess(id);
                        }


                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;
                case "submit":
                    try
                    {
                        Label lblCurrentStatus = (Label)e.Item.FindControl("lblCurrentStatus");
                        if (lblCurrentStatus.Text == App.Helper.Utils.OrderStatus.hold.ToString())
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showNotPermission();", true);
                        }
                        else
                        {

                            string url = GetDepartmentRoutingUrl(id);

                            Response.Redirect(url, false);
                        }

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;
                case "hold":
                    try
                    {
                        HoldProduction(id);

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;
                case "cutting":
                    try
                    {
                        // string url = GetDepartmentRoutingUrl(id);
                        //string url = "/" + App.Core.DataSecurity.Encryptdata(id).ToString();
                        Label lblCuttingId = (Label)e.Item.FindControl("lblCuttingId");
                        string _cutting_id = lblCuttingId.Text;
                        string url = "/production/cutting/" + App.Core.DataSecurity.Encryptdata(_cutting_id).ToString();

                        Response.Redirect(url, false);

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;
                case "grinding":
                    try
                    {

                        Label lblGrindingId = (Label)e.Item.FindControl("lblGrindingId");
                        string _grinding_id = lblGrindingId.Text;
                        string url = "/production/grinding/" + App.Core.DataSecurity.Encryptdata(_grinding_id).ToString();

                        Response.Redirect(url, false);

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }

                    break;
                case "washingone":
                    try
                    {

                        Label lblWashingOneId = (Label)e.Item.FindControl("lblWashingOneId");
                        string _washing_one_id = lblWashingOneId.Text;
                        string url = "/production/washing-one/" + App.Core.DataSecurity.Encryptdata(_washing_one_id).ToString();

                        Response.Redirect(url, false);

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }

                    break;

                case "hole":
                    try
                    {

                        Label lblHoleId = (Label)e.Item.FindControl("lblHoleId");
                        string _hole_id = lblHoleId.Text;
                        string url = "/production/hole/" + App.Core.DataSecurity.Encryptdata(_hole_id).ToString();

                        Response.Redirect(url, false);

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }

                    break;
                case "washing":
                    try
                    {

                        Label lblWashingId = (Label)e.Item.FindControl("lblWashingId");
                        string _washing_id = lblWashingId.Text;
                        string url = "/production/washing/" + App.Core.DataSecurity.Encryptdata(_washing_id).ToString();

                        Response.Redirect(url, false);

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }

                    break;
                case "paint":
                    try
                    {

                        Label lblPaintId = (Label)e.Item.FindControl("lblPaintId");
                        string _paint_id = lblPaintId.Text;
                        string url = "/production/paint/" + App.Core.DataSecurity.Encryptdata(_paint_id).ToString();

                        Response.Redirect(url, false);

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }

                    break;
                case "dfgprint":
                    try
                    {

                        Label lblDfgPrintId = (Label)e.Item.FindControl("lblDfgPrintId");
                        string _dfgprint_id = lblDfgPrintId.Text;
                        string url = "/production/dfgprint/" + App.Core.DataSecurity.Encryptdata(_dfgprint_id).ToString();

                        Response.Redirect(url, false);

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }

                    break;
                case "tempering":
                    try
                    {

                        Label lblTemperingId = (Label)e.Item.FindControl("lblTemperingId");
                        string _tempering_id = lblTemperingId.Text;
                        string url = "/production/tempering/" + App.Core.DataSecurity.Encryptdata(_tempering_id).ToString();

                        Response.Redirect(url, false);

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }

                    break;
                case "packing":
                    try
                    {

                        Label lblPackingId = (Label)e.Item.FindControl("lblPackingId");
                        string _packing_id = lblPackingId.Text;
                        string url = "/production/packing/" + App.Core.DataSecurity.Encryptdata(_packing_id).ToString();

                        Response.Redirect(url, false);

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }

                    break;
                case "store":
                    try
                    {

                        Label lblStoreId = (Label)e.Item.FindControl("lblStoreId");
                        string _store_id = lblStoreId.Text;
                        string url = "/production/store/" + App.Core.DataSecurity.Encryptdata(_store_id).ToString();

                        Response.Redirect(url, false);

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
                        Label lblItemMasterId = (Label)e.Item.FindControl("lblItemMasterId");
                        Label lblBatchNumber = (Label)e.Item.FindControl("lblBatchNumber");
                        if (lblItemMasterId.Text == "" || lblItemMasterId.Text == null)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                        }
                        else if (lblBatchNumber.Text == "" || lblBatchNumber.Text == null)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                        }
                        else
                        {
                            string _item_id = lblItemMasterId.Text;
                            string _batch_number = lblBatchNumber.Text;
                            string url = "/production/item-complete-detail/" + App.Core.DataSecurity.Encryptdata(_item_id).ToString() + "/" + App.Core.DataSecurity.Encryptdata(_batch_number).ToString();

                            Response.Redirect(url, false);
                        }


                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;
                case "viewstatus":
                    try
                    {
                        Label lblItemMasterId = (Label)e.Item.FindControl("lblItemMasterId");
                        Label lblBatchNumber = (Label)e.Item.FindControl("lblBatchNumber");
                        if (lblItemMasterId.Text == "" || lblItemMasterId.Text == null)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                        }
                        else if (lblBatchNumber.Text == "" || lblBatchNumber.Text == null)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                        }
                        else
                        {
                            string _item_id = lblItemMasterId.Text;
                            string _batch_number = lblBatchNumber.Text;
                            string url = "/production/item-complete-detail/" + App.Core.DataSecurity.Encryptdata(_item_id).ToString() + "/" + App.Core.DataSecurity.Encryptdata(_batch_number).ToString();

                            Response.Redirect(url, false);
                        }


                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;
                case "transferbycutting":
                    try
                    {
                        Label lblItemMasterId = (Label)e.Item.FindControl("lblItemMasterId");
                        Label lblBatchNumber = (Label)e.Item.FindControl("lblBatchNumber");
                        if (lblItemMasterId.Text == "" || lblItemMasterId.Text == null)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                        }
                        else if (lblBatchNumber.Text == "" || lblBatchNumber.Text == null)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                        }
                        else
                        {
                            string _item_id = lblItemMasterId.Text;
                            string _batch_number = lblBatchNumber.Text;

                            TransferProductionItemOnFloor(_item_id, _batch_number, App.Helper.Utils.ProductionType.cutting.ToString());

                        }

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;
                case "transferbygrinding":
                    try
                    {
                        Label lblItemMasterId = (Label)e.Item.FindControl("lblItemMasterId");
                        Label lblBatchNumber = (Label)e.Item.FindControl("lblBatchNumber");
                        if (lblItemMasterId.Text == "" || lblItemMasterId.Text == null)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                        }
                        else if (lblBatchNumber.Text == "" || lblBatchNumber.Text == null)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                        }
                        else
                        {
                            string _item_id = lblItemMasterId.Text;
                            string _batch_number = lblBatchNumber.Text;

                            TransferProductionItemOnFloor(_item_id, _batch_number, App.Helper.Utils.ProductionType.grinding.ToString());

                        }

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;
                case "transferbywashingone":
                    try
                    {
                        Label lblItemMasterId = (Label)e.Item.FindControl("lblItemMasterId");
                        Label lblBatchNumber = (Label)e.Item.FindControl("lblBatchNumber");
                        if (lblItemMasterId.Text == "" || lblItemMasterId.Text == null)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                        }
                        else if (lblBatchNumber.Text == "" || lblBatchNumber.Text == null)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                        }
                        else
                        {
                            string _item_id = lblItemMasterId.Text;
                            string _batch_number = lblBatchNumber.Text;

                            TransferProductionItemOnFloor(_item_id, _batch_number, App.Helper.Utils.ProductionType.washingone.ToString());

                        }

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;
                case "transferbyhole":
                    try
                    {
                        Label lblItemMasterId = (Label)e.Item.FindControl("lblItemMasterId");
                        Label lblBatchNumber = (Label)e.Item.FindControl("lblBatchNumber");
                        if (lblItemMasterId.Text == "" || lblItemMasterId.Text == null)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                        }
                        else if (lblBatchNumber.Text == "" || lblBatchNumber.Text == null)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                        }
                        else
                        {
                            string _item_id = lblItemMasterId.Text;
                            string _batch_number = lblBatchNumber.Text;

                            TransferProductionItemOnFloor(_item_id, _batch_number, App.Helper.Utils.ProductionType.hole.ToString());

                        }

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;
                case "transferbywashing":
                    try
                    {
                        Label lblItemMasterId = (Label)e.Item.FindControl("lblItemMasterId");
                        Label lblBatchNumber = (Label)e.Item.FindControl("lblBatchNumber");
                        if (lblItemMasterId.Text == "" || lblItemMasterId.Text == null)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                        }
                        else if (lblBatchNumber.Text == "" || lblBatchNumber.Text == null)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                        }
                        else
                        {
                            string _item_id = lblItemMasterId.Text;
                            string _batch_number = lblBatchNumber.Text;

                            TransferProductionItemOnFloor(_item_id, _batch_number, App.Helper.Utils.ProductionType.washing.ToString());

                        }

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;
                case "transferbypaint":
                    try
                    {
                        Label lblItemMasterId = (Label)e.Item.FindControl("lblItemMasterId");
                        Label lblBatchNumber = (Label)e.Item.FindControl("lblBatchNumber");
                        if (lblItemMasterId.Text == "" || lblItemMasterId.Text == null)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                        }
                        else if (lblBatchNumber.Text == "" || lblBatchNumber.Text == null)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                        }
                        else
                        {
                            string _item_id = lblItemMasterId.Text;
                            string _batch_number = lblBatchNumber.Text;

                            TransferProductionItemOnFloor(_item_id, _batch_number, App.Helper.Utils.ProductionType.paint.ToString());

                        }

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;
                case "transferbydfgprint":
                    try
                    {
                        Label lblItemMasterId = (Label)e.Item.FindControl("lblItemMasterId");
                        Label lblBatchNumber = (Label)e.Item.FindControl("lblBatchNumber");
                        if (lblItemMasterId.Text == "" || lblItemMasterId.Text == null)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                        }
                        else if (lblBatchNumber.Text == "" || lblBatchNumber.Text == null)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                        }
                        else
                        {
                            string _item_id = lblItemMasterId.Text;
                            string _batch_number = lblBatchNumber.Text;

                            TransferProductionItemOnFloor(_item_id, _batch_number, App.Helper.Utils.ProductionType.dfgprint.ToString());

                        }

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;
                case "transferbytempring":
                    try
                    {
                        Label lblItemMasterId = (Label)e.Item.FindControl("lblItemMasterId");
                        Label lblBatchNumber = (Label)e.Item.FindControl("lblBatchNumber");
                        if (lblItemMasterId.Text == "" || lblItemMasterId.Text == null)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                        }
                        else if (lblBatchNumber.Text == "" || lblBatchNumber.Text == null)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                        }
                        else
                        {
                            string _item_id = lblItemMasterId.Text;
                            string _batch_number = lblBatchNumber.Text;

                            TransferProductionItemOnFloor(_item_id, _batch_number, App.Helper.Utils.ProductionType.tempring.ToString());

                        }

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;
                case "transferbypacking":
                    try
                    {
                        Label lblItemMasterId = (Label)e.Item.FindControl("lblItemMasterId");
                        Label lblBatchNumber = (Label)e.Item.FindControl("lblBatchNumber");
                        if (lblItemMasterId.Text == "" || lblItemMasterId.Text == null)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                        }
                        else if (lblBatchNumber.Text == "" || lblBatchNumber.Text == null)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                        }
                        else
                        {
                            string _item_id = lblItemMasterId.Text;
                            string _batch_number = lblBatchNumber.Text;

                            TransferProductionItemOnFloor(_item_id, _batch_number, App.Helper.Utils.ProductionType.packing.ToString());

                        }

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;
                case "transferbyunderstore":
                    try
                    {
                        Label lblItemMasterId = (Label)e.Item.FindControl("lblItemMasterId");
                        Label lblBatchNumber = (Label)e.Item.FindControl("lblBatchNumber");
                        if (lblItemMasterId.Text == "" || lblItemMasterId.Text == null)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                        }
                        else if (lblBatchNumber.Text == "" || lblBatchNumber.Text == null)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                        }
                        else
                        {
                            string _item_id = lblItemMasterId.Text;
                            string _batch_number = lblBatchNumber.Text;

                            TransferProductionItemOnFloor(_item_id, _batch_number, App.Helper.Utils.ProductionType.store.ToString());

                        }

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;

            }
        }

        protected void rptrProductionDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {



                    Label lblIsActive = (Label)e.Item.FindControl("lblIsActive");
                    
                    Label lblItemMasterId = (Label)e.Item.FindControl("lblItemMasterId");

                    Label lblBatchNumber = (Label)e.Item.FindControl("lblBatchNumber");

                   

                    Label lblPartyMasterId = (Label)e.Item.FindControl("lblPartyMasterId");
                    //Label lblPartyNames = (Label)e.Item.FindControl("lblPartyNames");


                    Label lblProductionStatus = (Label)e.Item.FindControl("lblProductionStatus");

                    Label lblStartedOn = (Label)e.Item.FindControl("lblStartedOn");
                    Label lblCurrentStatus = (Label)e.Item.FindControl("lblCurrentStatus");

                    #region Find Repeater label According to Department Wise
                    #region Find Cutting Department Labels
                    Label lblCuttingId = (Label)e.Item.FindControl("lblCuttingId");
                    Label lblIsUnderCutting = (Label)e.Item.FindControl("lblIsUnderCutting");
                    // Label lblCuttingQuantity = (Label)e.Item.FindControl("lblCuttingQuantity");
                    LinkButton btnCuttingQuantity = (LinkButton)e.Item.FindControl("btnCuttingQuantity");
                    Label lblCuttingStatus = (Label)e.Item.FindControl("lblCuttingStatus");
                    LinkButton btnTransferFromCutting = (LinkButton)e.Item.FindControl("btnTransferFromCutting");

                    #endregion

                    #region Find Grinding Department Labels
                    Label lblGrindingId = (Label)e.Item.FindControl("lblGrindingId");
                    Label lblIsUnderGrinding = (Label)e.Item.FindControl("lblIsUnderGrinding");
                    // Label lblGrindingQuantity = (Label)e.Item.FindControl("lblGrindingQuantity");
                    LinkButton btnGrindingQuantity = (LinkButton)e.Item.FindControl("btnGrindingQuantity");
                    Label lblGrindingStatus = (Label)e.Item.FindControl("lblGrindingStatus");
                    LinkButton btnTransferFromgrinding = (LinkButton)e.Item.FindControl("btnTransferFromgrinding");

                    #endregion

                    #region Find Washing One Department Labels
                    Label lblWashingOneId = (Label)e.Item.FindControl("lblWashingOneId");
                    Label lblIsUnderWashingOne = (Label)e.Item.FindControl("lblIsUnderWashingOne");
                    //Label lblHoleQuantity = (Label)e.Item.FindControl("lblHoleQuantity");
                    LinkButton btnWashingOneQuantity = (LinkButton)e.Item.FindControl("btnWashingOneQuantity");
                    Label lblWashingOneStatus = (Label)e.Item.FindControl("lblWashingOneStatus");
                    LinkButton btnTransferFromWashingOne = (LinkButton)e.Item.FindControl("btnTransferFromWashingOne");
                    #endregion

                    #region Find Hole Department Labels
                    Label lblHoleId = (Label)e.Item.FindControl("lblHoleId");
                    Label lblIsUnderHole = (Label)e.Item.FindControl("lblIsUnderHole");
                    //Label lblHoleQuantity = (Label)e.Item.FindControl("lblHoleQuantity");
                    LinkButton btnHoleQuantity = (LinkButton)e.Item.FindControl("btnHoleQuantity");
                    Label lblHoleStatus = (Label)e.Item.FindControl("lblHoleStatus");
                    LinkButton btnTransferFromHole = (LinkButton)e.Item.FindControl("btnTransferFromHole");
                    #endregion

                    #region Find Washing Department Labels
                    Label lblWashingId = (Label)e.Item.FindControl("lblWashingId");
                    Label lblIsUnderWashing = (Label)e.Item.FindControl("lblIsUnderWashing");
                    // Label lblWashingQuantity = (Label)e.Item.FindControl("lblWashingQuantity"); 
                    LinkButton btnWashingQuantity = (LinkButton)e.Item.FindControl("btnWashingQuantity");
                    Label lblWashingStatus = (Label)e.Item.FindControl("lblWashingStatus");
                    LinkButton btnTransferFromWashing = (LinkButton)e.Item.FindControl("btnTransferFromWashing");
                    #endregion

                    #region Find Paint Department Labels
                    Label lblPaintId = (Label)e.Item.FindControl("lblPaintId");
                    Label lblIsUnderPaint = (Label)e.Item.FindControl("lblIsUnderPaint");
                    //Label lblPaintQuantity = (Label)e.Item.FindControl("lblPaintQuantity");
                    LinkButton btnPaintQuantity = (LinkButton)e.Item.FindControl("btnPaintQuantity");
                    Label lblPaintStatus = (Label)e.Item.FindControl("lblPaintStatus");
                    LinkButton btnTransferFromPaint = (LinkButton)e.Item.FindControl("btnTransferFromPaint");
                    #endregion

                    #region Find DFG Print Department Labels
                    Label lblDfgPrintId = (Label)e.Item.FindControl("lblDfgPrintId");
                    Label lblIsUnderDfgPrint = (Label)e.Item.FindControl("lblIsUnderDfgPrint");
                    // Label lblDfgPrintQuantity = (Label)e.Item.FindControl("lblDfgPrintQuantity");
                    LinkButton btnDfgPrintQuantity = (LinkButton)e.Item.FindControl("btnDfgPrintQuantity");
                    Label lblDfgPrintStatus = (Label)e.Item.FindControl("lblDfgPrintStatus");
                    LinkButton btnTransferFromDfgPrint = (LinkButton)e.Item.FindControl("btnTransferFromDfgPrint");
                    #endregion

                    #region Find Tempring Department Labels
                    Label lblTemperingId = (Label)e.Item.FindControl("lblTemperingId");
                    Label lblIsUnderTempering = (Label)e.Item.FindControl("lblIsUnderTempering");
                    // Label lblTemperingQuantity = (Label)e.Item.FindControl("lblTemperingQuantity");
                    LinkButton btnTemperingQuantity = (LinkButton)e.Item.FindControl("btnTemperingQuantity");
                    Label lblTemperingStatus = (Label)e.Item.FindControl("lblTemperingStatus");
                    LinkButton btnTransferFromTempering = (LinkButton)e.Item.FindControl("btnTransferFromTempering");
                    #endregion

                    #region Find Packing Department Labels
                    Label lblPackingId = (Label)e.Item.FindControl("lblPackingId");
                    Label lblIsUnderPacking = (Label)e.Item.FindControl("lblIsUnderPacking");
                    // Label lblPackingQuantity = (Label)e.Item.FindControl("lblPackingQuantity");
                    LinkButton btnPackingQuantity = (LinkButton)e.Item.FindControl("btnPackingQuantity");
                    Label lblPackingStatus = (Label)e.Item.FindControl("lblPackingStatus");
                    LinkButton btnTransferFromPacking = (LinkButton)e.Item.FindControl("btnTransferFromPacking");
                    #endregion

                    #region Find Store Department Labels
                    Label lblStoreId = (Label)e.Item.FindControl("lblStoreId");
                    Label lblIsUnderStore = (Label)e.Item.FindControl("lblIsUnderStore");
                    // Label lblStoreQuantity = (Label)e.Item.FindControl("lblStoreQuantity");
                    LinkButton btnStoreQuantity = (LinkButton)e.Item.FindControl("btnStoreQuantity");
                    Label lblStoreStatus = (Label)e.Item.FindControl("lblStoreStatus");
                    LinkButton btnTransferFromUnderStore = (LinkButton)e.Item.FindControl("btnTransferFromUnderStore");
                    #endregion



                    DropDownList ddlShift = (DropDownList)e.Item.FindControl("ddlShift");
                    Label lblShiftName = (Label)e.Item.FindControl("lblShiftName");

                    TextBox txtPlannedDate = (TextBox)e.Item.FindControl("txtPlannedDate");
                    Label lblPlannedDate = (Label)e.Item.FindControl("lblPlannedDate");

                    #region Action Buttons ( like Start, Submit, View, etc)
                    LinkButton btnAcknowledge = (LinkButton)e.Item.FindControl("btnAcknowledge");
                    LinkButton btnStart = (LinkButton)e.Item.FindControl("btnStart");
                    LinkButton btnSubmit = (LinkButton)e.Item.FindControl("btnSubmit");
                    LinkButton btnViewStatus = (LinkButton)e.Item.FindControl("btnViewStatus");
                    LinkButton btnHold = (LinkButton)e.Item.FindControl("btnHold");
                    LinkButton btnView = (LinkButton)e.Item.FindControl("btnView");
                    #endregion
                    #endregion
                    //CheckBox chkActive=(CheckBox)e.Item.FindControl("chkActive");  

                    //Plant Code

                    Label lblProductionPlant = (Label)e.Item.FindControl("lblProductionPlant");
                    DropDownList ddlPlant = (DropDownList)e.Item.FindControl("ddlPlant");


                    _objItemMasterBL = new ItemMasterBL();
                    _objItemMaster = _objItemMasterBL.GetAllItemMasterItems().Where(x => x.item_master_id == Convert.ToInt32(lblItemMasterId.Text)).FirstOrDefault();
                    if (_objItemMaster != null)
                    {
                        ddlPlant.SelectedValue = _objItemMaster.plant_no.ToString();
                        _is_washingOne_required = _objItemMaster.washing_one == true ? "Yes" : "No";
                        _is_hole_required = _objItemMaster.hole_required == true ? "Yes" : "No";
                        _is_washing_required = _objItemMaster.washing_two == true ? "Yes" : "No";
                        _is_normal_paint = _objItemMaster.is_normal_paint == true ? "Yes" : "No";
                        is_dfg_paint = _objItemMaster.is_dfg_paint == true ? "Yes" : "No";
                       
                    }


                    _objProcessCuttingBL = new ProcessCuttingBL();
                    _objProcessCutting = _objProcessCuttingBL.GetAllProcessCuttingItems().Where(x => x.process_cutting_id == Convert.ToInt32(lblCuttingId.Text)).FirstOrDefault();
                    if (_objProcessCutting != null)
                    {
                        if (_objProcessCutting.actual_pcs_from_sheet_issued > 0)
                        {

                        }
                        else
                        {

                        }

                    }

                    //Plant End Code

                    ////Bind Party Name According to Item and SaleHeader

                   
                    lblBatchNumber = (Label)(lblBatchNumber.FindControl("lblBatchNumber"));
                    lblBatchNumber.Attributes.Add("title",getPartyFullNameForTooltip(lblPartyMasterId.Text));

                   // lblPartyNames.Text = _partyNameBind.TrimEnd(',');




                    string _productionstatus = lblProductionStatus.Text;

                    string _productionPlant = ddlPlant.SelectedValue.ToString() =="" ? null : ddlPlant.SelectedValue.ToString();

                    if ( string.IsNullOrEmpty(_productionPlant))
                    {

                    }
                    else
                    {
                        _plantName = _productionPlant;
                    }

                    #region Get Labels Value in String or Int type Variables 
                    string _isUnderCutting = lblIsUnderCutting.Text;
                    int _cuttingId = Convert.ToInt32(lblCuttingId.Text);
                    //int _cuttingQuantity = Convert.ToInt32(lblCuttingQuantity.Text);
                    int _cuttingQuantity = Convert.ToInt32(btnCuttingQuantity.Text);

                    int _grindingId = Convert.ToInt32(lblGrindingId.Text);
                    int _grindingQuantity = Convert.ToInt32(btnGrindingQuantity.Text);

                   
                    int _washinhOneId = Convert.ToInt32(lblWashingOneId.Text);
                    int _washingOneQnatity = Convert.ToInt32(btnWashingOneQuantity.Text);

                    int _holeId = Convert.ToInt32(lblHoleId.Text);
                    int _holeQnatity = Convert.ToInt32(btnHoleQuantity.Text);

                    int _washinId = Convert.ToInt32(lblWashingId.Text);
                    int _washingQuantity = Convert.ToInt32(btnWashingQuantity.Text);

                    int _paintId = Convert.ToInt32(lblPaintId.Text);
                    int _paintQuantity = Convert.ToInt32(btnPaintQuantity.Text);

                    int _dfgPrintId = Convert.ToInt32(lblDfgPrintId.Text);
                    int _dfgPrintQuantity = Convert.ToInt32(btnDfgPrintQuantity.Text);

                    int _temperingId = Convert.ToInt32(lblTemperingId.Text);
                    int _temperingQuantity = Convert.ToInt32(btnTemperingQuantity.Text);
                    int _packaingId = Convert.ToInt32(lblPackingId.Text);
                    int _packingQuantity = Convert.ToInt32(btnPackingQuantity.Text);
                    int _storeId = Convert.ToInt32(lblStoreId.Text);
                    int _storeQuantity = Convert.ToInt32(btnStoreQuantity.Text);

                    #endregion

                    if (_productionstatus == App.Helper.Utils.OrderStatus.added.ToString())
                    {
                        btnAcknowledge.Visible = ddlPlant.Visible = true;
                        lblProductionPlant.Visible =  lblStartedOn.Visible = false;

                        #region Cutting Department Labels Operation Like ( Visisble-true/false) etc
                        lblIsUnderCutting.Visible = btnCuttingQuantity.Visible = btnTransferFromCutting.Visible = false;
                        lblCuttingStatus.Visible = true;
                        lblCuttingStatus.Text = "--";
                        lblCuttingStatus.CssClass = "";
                        #endregion

                        #region Grinding Department Labels Operation Like ( Visisble-true/false) etc
                        lblIsUnderGrinding.Visible = btnGrindingQuantity.Visible = btnTransferFromgrinding.Visible = false;
                        lblGrindingStatus.Visible = true;
                        lblGrindingStatus.Text = "--";
                        lblGrindingStatus.CssClass = "";
                        
                        #endregion

                        #region Washinh One Department Labels Operation Like ( Visisble-true/false) etc
                        lblWashingOneId.Visible = btnWashingOneQuantity.Visible = btnTransferFromWashingOne.Visible = false;
                        lblWashingOneStatus.Visible = true;
                        lblWashingOneStatus.Text = "--";
                       
                        #endregion

                        #region Hole Department Labels Operation Like ( Visisble-true/false) etc
                        lblIsUnderHole.Visible =  btnHoleQuantity.Visible = btnTransferFromHole.Visible = false;
                        lblHoleStatus.Visible = true;
                        lblHoleStatus.Text = "--";
                        
                        #endregion

                        #region Washing Department Labels Operation Like ( Visisble-true/false) etc
                        lblIsUnderWashing.Visible =  btnWashingQuantity.Visible = btnTransferFromWashing.Visible = false;
                        lblWashingStatus.Visible = true;
                        lblWashingStatus.Text = "--";
                        
                        #endregion

                        #region Paint Department Labels Operation Like ( Visisble-true/false) etc
                        lblIsUnderPaint.Visible = btnPaintQuantity.Visible = btnTransferFromWashing.Visible = false;
                        lblPaintStatus.Visible = true;
                        lblPaintStatus.Text = "--";
                        
                        #endregion

                        #region DFG Print Department Labels Operation Like ( Visisble-true/false) etc
                        lblIsUnderDfgPrint.Visible =  btnDfgPrintQuantity.Visible = btnTransferFromDfgPrint.Visible = false;
                        lblDfgPrintStatus.Visible = true;
                        lblDfgPrintStatus.Text = "--";
                        
                        #endregion

                        #region Tempring Department Labels Operation Like ( Visisble-true/false) etc
                        lblIsUnderTempering.Visible =  btnTemperingQuantity.Visible = btnTransferFromTempering.Visible = false;
                        lblTemperingStatus.Visible = true;
                        lblTemperingStatus.Text = "--";
                        
                        #endregion

                        #region Packing Department Labels Operation Like ( Visisble-true/false) etc
                        lblIsUnderPacking.Visible =  btnPackingQuantity.Visible = btnTransferFromPacking.Visible = false;
                        lblPackingStatus.Visible = true;
                        lblPackingStatus.Text = "--";
                        
                        #endregion

                        #region Store Department Labels Operation Like ( Visisble-true/false) etc
                        lblIsUnderStore.Visible =  btnStoreQuantity.Visible = btnTransferFromUnderStore.Visible = false;
                        lblStoreStatus.Visible = true;
                        lblStoreStatus.Text = "--";

                        #endregion

                        ddlShift.Visible = txtPlannedDate.Visible = true;
                        lblShiftName.Visible = lblPlannedDate.Visible = false;



                        //chkActive.Checked=true;

                    }
                    else
                    {
                        btnAcknowledge.Visible = ddlPlant.Visible = false;
                        lblProductionPlant.Visible = true;
                        //ddlPlant.Visible = false;
                        
                        if (lblCuttingId.Text == "0" || lblCuttingId.Text=="")
                        {
                            lblStartedOn.Visible = false;
                        }
                        else
                        {
                            lblStartedOn.Visible = true;

                        }

                        ddlShift.Visible = txtPlannedDate.Visible = false;
                        lblShiftName.Visible = lblPlannedDate.Visible = true;



                        #region All Lebels Set Visible False and empty

                        btnStart.Visible = true;
                        btnSubmit.Visible = false;
                        btnView.Visible = false;
                        #endregion

                        #region Labels Value Set and SHow According to Current Status 


                        btnHold.Visible = true;
                        if (lblCurrentStatus.Text == App.Helper.Utils.OrderStatus.hold.ToString())
                        {
                            btnHold.CssClass = "btn btn-default text-center hi hi-stop text-primary";
                            lblCurrentStatus.CssClass = "label label-danger";
                        }
                        else
                        {
                            btnHold.CssClass = "btn btn-default text-center hi hi-stop text-danger";
                            lblCurrentStatus.CssClass = "";
                        }

                        #region Cutting Department Status Check
                        if (_cuttingQuantity > 0)
                        {
                          
                            btnCuttingQuantity.Text = (_objProcessCutting.total_received + "/" + _cuttingQuantity).ToString();
                            lblCuttingStatus.CssClass = "";
                            btnStart.Visible = btnViewStatus.Visible = btnCuttingQuantity.Visible = true;
                            btnSubmit.Visible =  btnView.Visible =  btnTransferFromCutting.Visible = lblCuttingStatus.Visible = lblIsUnderCutting.Visible = false;


                        }
                        else if (_cuttingId > 0)
                        {
                            lblIsUnderCutting.Visible =  btnCuttingQuantity.Visible = btnStart.Visible = btnView.Visible = false;
                            lblCuttingStatus.Text = App.Helper.Utils.OrderStatus.progress.ToString();
                            lblCuttingStatus.CssClass = "text-capitalize zoom-in-out-box";
                            lblCuttingStatus.Visible = btnSubmit.Visible =  btnViewStatus.Visible =  btnTransferFromCutting.Visible = true;
                        }
                        else
                        {
                            lblIsUnderCutting.Visible =  btnCuttingQuantity.Visible = btnSubmit.Visible = btnView.Visible = btnTransferFromCutting.Visible = false;
                            lblCuttingStatus.Text = "--";
                            lblCuttingStatus.CssClass = "";
                            btnStart.Visible = lblCuttingStatus.Visible = true;
                            
                        }

                        #endregion

                        #region Grinding Department Status Check
                        if (_grindingQuantity > 0)
                        {
                            lblIsUnderGrinding.Visible = lblGrindingStatus.Visible = btnSubmit.Visible = btnView.Visible = btnTransferFromgrinding.Visible = false;
                            btnGrindingQuantity.Text = (_cuttingQuantity + "/" + _grindingQuantity).ToString();
                            lblGrindingStatus.CssClass = "";
                            btnStart.Visible = btnViewStatus.Visible = btnGrindingQuantity.Visible = true;
                        }
                        else if (_grindingId > 0)
                        {
                            lblIsUnderGrinding.Visible = btnStart.Visible = btnGrindingQuantity.Visible = btnView.Visible = false;
                            lblGrindingStatus.Text = App.Helper.Utils.OrderStatus.progress.ToString();
                            lblGrindingStatus.CssClass = "text-capitalize zoom-in-out-box";
                            btnSubmit.Visible = lblGrindingStatus.Visible = btnViewStatus.Visible = btnTransferFromgrinding.Visible = true;
                        }
                        else
                        {

                            if (_cuttingQuantity > 0)
                            {
                                lblIsUnderGrinding.Visible =  btnGrindingQuantity.Visible = btnSubmit.Visible = btnView.Visible = false;
                                lblGrindingStatus.Text = App.Helper.Utils.OrderStatus.progress.ToString();
                                lblGrindingStatus.CssClass = "text-capitalize zoom-in-out-box";
                                btnViewStatus.Visible = lblGrindingStatus.Visible = btnTransferFromgrinding.Visible = btnStart.Visible = true;
                            }
                            else if (_cuttingId > 0)
                            {
                                lblGrindingStatus.Text = "--";
                                btnStart.Visible = btnView.Visible = btnTransferFromgrinding.Visible = false;
                                btnSubmit.Visible = lblGrindingStatus.Visible = btnViewStatus.Visible = true;
                            }
                            else
                            {
                                lblIsUnderGrinding.Visible = btnGrindingQuantity.Visible = btnTransferFromgrinding.Visible = false;
                                lblGrindingStatus.Visible = btnViewStatus.Visible = true;
                                lblGrindingStatus.Text = "--";
                                lblGrindingStatus.CssClass = "";
                            }

                        }

                        #endregion

                        //washing One Start

                        #region Washing One Department Status Check

                        if (_is_washingOne_required == "No")
                        {
                            lblIsUnderWashingOne.Visible =  btnWashingOneQuantity.Visible = btnTransferFromWashingOne.Visible = false;
                            lblWashingOneStatus.Visible = btnViewStatus.Visible = true;
                            lblWashingOneStatus.Text = "-NA-";
                            lblWashingOneStatus.CssClass = "";
                           
                        }
                        else
                        {  
                            if (_washingOneQnatity > 0)
                            {
                                lblIsUnderWashingOne.Visible = lblWashingOneStatus.Visible = btnSubmit.Visible = btnView.Visible = btnTransferFromWashingOne.Visible = false;
                                btnWashingOneQuantity.Text = (_grindingQuantity + "/" + _washingOneQnatity).ToString();
                                lblWashingOneStatus.CssClass = "";
                                btnStart.Visible =  btnViewStatus.Visible = btnWashingOneQuantity.Visible = true;
                            }
                            else if (_washinhOneId > 0)
                            {
                                lblIsUnderWashingOne.Visible =  btnWashingOneQuantity.Visible = btnStart.Visible = btnView.Visible = false;
                                lblWashingOneStatus.Text = App.Helper.Utils.OrderStatus.progress.ToString();
                                lblWashingOneStatus.CssClass = "text-capitalize zoom-in-out-box";
                                btnSubmit.Visible = lblWashingOneStatus.Visible = btnViewStatus.Visible = btnTransferFromWashingOne.Visible = true;
                                
                            }
                            else
                            {

                                if (_grindingQuantity > 0)
                                {
                                    //correct Name Here
                                    lblIsUnderWashingOne.Visible =   btnWashingOneQuantity.Visible = btnSubmit.Visible = btnView.Visible = false;
                                    lblWashingOneStatus.Text = App.Helper.Utils.OrderStatus.progress.ToString();
                                    lblWashingOneStatus.CssClass = "text-capitalize zoom-in-out-box";
                                    btnStart.Visible = lblWashingOneStatus.Visible = btnViewStatus.Visible = btnTransferFromWashingOne.Visible = true;
                                    
                                }
                                else if (_grindingId > 0)
                                {
                                    lblWashingOneStatus.Text = "--";
                                    lblWashingOneStatus.Visible = btnSubmit.Visible = btnViewStatus.Visible = true;
                                    btnStart.Visible = btnView.Visible = btnTransferFromWashingOne.Visible = false;

                                }
                                else
                                {
                                    lblIsUnderWashingOne.Visible =  btnWashingOneQuantity.Visible = btnTransferFromWashingOne.Visible = false;
                                    lblWashingOneStatus.Visible = btnViewStatus.Visible = true;
                                    lblWashingOneStatus.Text = "--";
                                    lblWashingOneStatus.CssClass = "";
                                }

                            }
                        }




                        #endregion
                        //Washing One End


                        #region Hole Department Status Check

                        if (_is_hole_required == "No")
                        {
                            lblIsUnderHole.Visible =  btnHoleQuantity.Visible = btnTransferFromHole.Visible = false;
                            lblHoleStatus.Visible = btnViewStatus.Visible = true;
                            lblHoleStatus.Text = "-NA-";
                            lblHoleStatus.CssClass = "";
                        }
                        else
                        {
                            if (_holeQnatity > 0)
                            {
                                lblIsUnderHole.Visible = false;
                                if (_washingOneQnatity > 0)
                                {
                                    btnHoleQuantity.Text = (_washingOneQnatity + "/" + _holeQnatity).ToString();
                                }
                                else
                                {
                                    btnHoleQuantity.Text = (_grindingQuantity + "/" + _holeQnatity).ToString();

                                }
                               
                                lblHoleStatus.CssClass = "";
                                btnStart.Visible = btnViewStatus.Visible = btnHoleQuantity.Visible = true;
                                btnSubmit.Visible = lblHoleStatus.Visible =  btnView.Visible = btnTransferFromHole.Visible = false;
                            }
                            else if (_holeId > 0)
                            {
                                lblIsUnderHole.Visible =  btnHoleQuantity.Visible = btnStart.Visible = btnView.Visible = false;
                                lblHoleStatus.Visible = btnSubmit.Visible = btnViewStatus.Visible = btnTransferFromHole.Visible = true;
                                lblHoleStatus.Text = App.Helper.Utils.OrderStatus.progress.ToString();
                                lblHoleStatus.CssClass = "text-capitalize zoom-in-out-box";
                                
                            }
                            else
                            {

                                if (_washingOneQnatity > 0)
                                {
                                    //correct Name Here
                                    lblIsUnderHole.Visible =  btnHoleQuantity.Visible = btnSubmit.Visible = btnView.Visible = false;
                                    lblHoleStatus.Text = App.Helper.Utils.OrderStatus.progress.ToString();
                                    lblHoleStatus.CssClass = "text-capitalize zoom-in-out-box";
                                    btnStart.Visible = lblHoleStatus.Visible = btnViewStatus.Visible = btnTransferFromHole.Visible = true;
                                }
                                else if (_washinhOneId > 0)
                                {
                                    lblHoleStatus.Text = "--";
                                    lblHoleStatus.Visible = btnViewStatus.Visible = btnSubmit.Visible = true;
                                    btnView.Visible = btnStart.Visible = btnTransferFromHole.Visible = false;
                                }
                                else
                                {
                                    lblIsUnderHole.Visible =  btnHoleQuantity.Visible = btnTransferFromHole.Visible = false;
                                    lblHoleStatus.Visible = btnViewStatus.Visible = true;
                                    lblHoleStatus.Text = "--";
                                    lblHoleStatus.CssClass = "";
                                }

                            }
                        }




                        #endregion

                        #region Washing Department Status Check
                        if (_washingQuantity > 0)
                        {
                            lblIsUnderWashing.Visible = false;
                            if (_holeQnatity > 0)
                            {
                                btnWashingQuantity.Text = (_holeQnatity + "/" + _washingQuantity).ToString();
                            }
                            else if (_washingOneQnatity > 0)
                            {
                                btnWashingQuantity.Text = (_washingOneQnatity + "/" + _washingQuantity).ToString();
                            }
                            else
                            {
                                btnWashingQuantity.Text = (_grindingQuantity + "/" + _washingQuantity).ToString();

                            }
                            btnWashingQuantity.Visible = btnStart.Visible = btnViewStatus.Visible = true;
                            lblWashingStatus.Visible = btnSubmit.Visible = btnView.Visible = btnTransferFromWashing.Visible = false;
                            lblWashingStatus.CssClass = "";
                        }
                        else if (_washinId > 0)
                        {
                            lblIsUnderWashing.Visible = btnWashingQuantity.Visible = btnStart.Visible = btnView.Visible = false;
                            lblWashingStatus.Visible = btnSubmit.Visible = btnViewStatus.Visible = btnTransferFromWashing.Visible = true;
                            lblWashingStatus.Text = App.Helper.Utils.OrderStatus.progress.ToString();
                            lblWashingStatus.CssClass = "text-capitalize zoom-in-out-box";
                        }
                        else
                        {

                            if (_holeQnatity > 0)
                            {
                                //correct Name Here
                                lblIsUnderWashing.Visible =  btnWashingQuantity.Visible = btnSubmit.Visible = btnView.Visible = false;
                                lblWashingStatus.Visible = btnStart.Visible = btnViewStatus.Visible = btnTransferFromWashing.Visible = true;
                                lblWashingStatus.Text = App.Helper.Utils.OrderStatus.progress.ToString();
                                lblWashingStatus.CssClass = "text-capitalize zoom-in-out-box";
                            }
                            else if (_holeId > 0)
                            {
                                lblWashingStatus.Text = "--";
                                lblWashingStatus.Visible = btnSubmit.Visible = btnViewStatus.Visible = true;
                                btnStart.Visible = btnView.Visible =  btnTransferFromWashing.Visible = false;
                            }
                            else
                            {
                                lblIsUnderWashing.Visible = btnWashingQuantity.Visible = btnTransferFromWashing.Visible = false;
                                lblWashingStatus.Visible = btnViewStatus.Visible = btnHold.Visible = true;
                                lblWashingStatus.Text = "-NA-";
                                lblWashingStatus.CssClass = "";
                            }

                        }

                        #endregion

                        #region Paint Department Status Check

                        if (_is_normal_paint == "No")
                        {
                            lblIsUnderPaint.Visible =  btnPaintQuantity.Visible = btnTransferFromPaint.Visible = false;
                            lblPaintStatus.Visible = btnViewStatus.Visible = true;
                            lblPaintStatus.Text = "-NA-";
                            lblPaintStatus.CssClass = "";
                        }
                        else
                        {
                            if (_paintQuantity > 0)
                            {
                                lblIsUnderPaint.Visible = false;
                                
                                 if (_washingQuantity > 0)
                                {
                                    btnPaintQuantity.Text = (_washingQuantity + "/" + _paintQuantity).ToString();
                                }
                                else if (_holeQnatity > 0)
                                {
                                    btnPaintQuantity.Text = (_holeQnatity + "/" + _paintQuantity).ToString();
                                }
                                else if (_washingOneQnatity > 0)
                                {
                                    btnPaintQuantity.Text = (_washingOneQnatity + "/" + _paintQuantity).ToString();
                                }
                                else
                                {
                                    btnPaintQuantity.Text = (_grindingQuantity + "/" + _paintQuantity).ToString();

                                }
                              
                                btnPaintQuantity.Visible = btnStart.Visible = btnViewStatus.Visible = true;
                                lblPaintStatus.Visible = btnSubmit.Visible = btnView.Visible = btnTransferFromPaint.Visible = false;
                                lblPaintStatus.CssClass = "";
                            }
                            else if (_paintId > 0)
                            {
                                lblIsUnderPaint.Visible =  btnPaintQuantity.Visible = btnStart.Visible = btnView.Visible = false;
                                lblPaintStatus.Visible = btnSubmit.Visible = btnViewStatus.Visible = btnTransferFromPaint.Visible = true;
                                lblPaintStatus.Text = App.Helper.Utils.OrderStatus.progress.ToString();
                                lblPaintStatus.CssClass = "text-capitalize zoom-in-out-box";
                            }
                            else
                            {
                                if (_washingQuantity > 0)
                                {
                                    //correct Name Here
                                    lblIsUnderPaint.Visible =  btnPaintQuantity.Visible = btnSubmit.Visible = btnView.Visible = false;
                                    lblPaintStatus.Visible = btnStart.Visible = btnViewStatus.Visible = btnTransferFromPaint.Visible = true;
                                    lblPaintStatus.Text = App.Helper.Utils.OrderStatus.progress.ToString();
                                    lblPaintStatus.CssClass = "text-capitalize zoom-in-out-box";
                                }
                                else if (_washinId > 0)
                                {
                                    lblPaintStatus.Text = "--";
                                    lblPaintStatus.Visible = btnSubmit.Visible = btnViewStatus.Visible = true;
                                    btnStart.Visible =  btnView.Visible = btnTransferFromPaint.Visible = false;
                                }
                                else
                                {
                                    lblIsUnderPaint.Visible =  btnPaintQuantity.Visible = btnTransferFromPaint.Visible = false;
                                    lblPaintStatus.Visible = btnViewStatus.Visible = true;
                                    lblPaintStatus.Text = "--";
                                    lblPaintStatus.CssClass = "";
                                }

                            }
                        }



                        #endregion

                        #region DFG Print Department Status Check

                        if (is_dfg_paint == "No")
                        {
                            lblIsUnderDfgPrint.Visible =  btnDfgPrintQuantity.Visible = btnTransferFromDfgPrint.Visible = false;
                            lblDfgPrintStatus.Visible = btnViewStatus.Visible = true;
                            lblDfgPrintStatus.Text = "-NA-";
                            lblDfgPrintStatus.CssClass = "";
                        }
                        else
                        {
                            if (_dfgPrintQuantity > 0)
                            {
                                lblIsUnderDfgPrint.Visible = false;
                                if (_paintQuantity > 0)
                                {
                                    btnDfgPrintQuantity.Text = (_paintQuantity + "/" + _dfgPrintQuantity).ToString();
                                }
                                else if (_washingQuantity > 0)
                                {
                                    btnDfgPrintQuantity.Text = (_washingQuantity + "/" + _dfgPrintQuantity).ToString();
                                }
                                else if (_holeQnatity > 0)
                                {
                                    btnDfgPrintQuantity.Text = (_holeQnatity + "/" + _dfgPrintQuantity).ToString();
                                }
                                else
                                {
                                    btnDfgPrintQuantity.Text = (_grindingQuantity + "/" + _dfgPrintQuantity).ToString();

                                }
                                btnDfgPrintQuantity.Text = (_paintQuantity + "/" + _dfgPrintQuantity).ToString();
                                btnDfgPrintQuantity.Visible = btnStart.Visible = btnViewStatus.Visible = true;
                                lblDfgPrintStatus.Visible = btnSubmit.Visible = btnView.Visible = btnTransferFromDfgPrint.Visible = false;
                                lblDfgPrintStatus.CssClass = "";
                            }
                            else if (_dfgPrintId > 0)
                            {
                                lblIsUnderDfgPrint.Visible =  btnDfgPrintQuantity.Visible = btnStart.Visible = btnView.Visible = false;
                                lblDfgPrintStatus.Visible = btnSubmit.Visible = btnViewStatus.Visible = btnTransferFromDfgPrint.Visible = true;
                                lblDfgPrintStatus.Text = App.Helper.Utils.OrderStatus.progress.ToString();
                                lblDfgPrintStatus.CssClass = "text-capitalize zoom-in-out-box";
                            }
                            else
                            {

                                if (_paintQuantity > 0)
                                {
                                    //correct Name Here
                                    lblIsUnderDfgPrint.Visible =  btnDfgPrintQuantity.Visible = btnSubmit.Visible = btnView.Visible = false;
                                    lblDfgPrintStatus.Visible = btnStart.Visible = btnViewStatus.Visible = btnTransferFromDfgPrint.Visible = true;
                                    lblDfgPrintStatus.Text = App.Helper.Utils.OrderStatus.progress.ToString();
                                    lblDfgPrintStatus.CssClass = "text-capitalize zoom-in-out-box";
                                }
                                else if (_paintId > 0)
                                {
                                    lblDfgPrintStatus.Text = "--";
                                    lblDfgPrintStatus.Visible = btnSubmit.Visible = btnViewStatus.Visible = true;
                                    btnStart.Visible =  btnView.Visible = false;
                                }
                                else
                                {
                                    lblIsUnderDfgPrint.Visible = btnDfgPrintQuantity.Visible = btnTransferFromDfgPrint.Visible = false;
                                    lblDfgPrintStatus.Visible = btnViewStatus.Visible = true;
                                    lblDfgPrintStatus.Text = "--";
                                    lblDfgPrintStatus.CssClass = "";
                                }

                            }
                        }



                        #endregion

                        #region Tempering Department Status Check
                        if (_temperingQuantity > 0)
                        {
                            lblIsUnderTempering.Visible = false;
                            if (_dfgPrintQuantity > 0)
                            {
                                btnTemperingQuantity.Text = (_dfgPrintQuantity + "/" + _temperingQuantity).ToString();
                            }
                            else if (_paintQuantity > 0)
                            {
                                btnTemperingQuantity.Text = (_paintQuantity + "/" + _temperingQuantity).ToString();
                            }
                            else if (_washingQuantity > 0)
                            {
                                btnTemperingQuantity.Text = (_washingQuantity + "/" + _temperingQuantity).ToString();
                            }
                            else
                            {
                                btnTemperingQuantity.Text = (_grindingQuantity + "/" + _temperingQuantity).ToString();

                            }

                            btnTemperingQuantity.Visible = btnStart.Visible = btnViewStatus.Visible = true;
                            lblTemperingStatus.Visible = btnSubmit.Visible = btnView.Visible = btnTransferFromTempering.Visible = false;
                            lblTemperingStatus.CssClass = "";
                        }
                        else if (_temperingId > 0)
                        {
                            lblIsUnderTempering.Visible =  btnTemperingQuantity.Visible = btnStart.Visible = btnView.Visible = false;
                            lblTemperingStatus.Visible = btnSubmit.Visible = btnViewStatus.Visible = btnTransferFromTempering.Visible = true;
                            lblTemperingStatus.Text = App.Helper.Utils.OrderStatus.progress.ToString();
                            lblTemperingStatus.CssClass = "text-capitalize zoom-in-out-box";
                        }
                        else
                        {

                            if (_dfgPrintQuantity > 0)
                            {
                                //correct Name Here
                                lblIsUnderTempering.Visible =  btnTemperingQuantity.Visible = btnSubmit.Visible = btnView.Visible = false;
                                lblTemperingStatus.Visible = btnStart.Visible = btnViewStatus.Visible = btnTransferFromTempering.Visible = true;
                                lblTemperingStatus.Text = App.Helper.Utils.OrderStatus.progress.ToString();
                                lblTemperingStatus.CssClass = "text-capitalize zoom-in-out-box";
                            }
                            else if (_dfgPrintId > 0)
                            {
                                lblTemperingStatus.Text = "--";
                                lblTemperingStatus.Visible = btnSubmit.Visible = btnViewStatus.Visible = true;
                                btnStart.Visible = btnView.Visible = btnTransferFromTempering.Visible = false;
                            }
                            else
                            {
                                lblIsUnderTempering.Visible = btnTemperingQuantity.Visible = btnTransferFromTempering.Visible = false;
                                lblTemperingStatus.Visible = btnViewStatus.Visible = true;
                                lblTemperingStatus.Text = "--";
                                lblTemperingStatus.CssClass = "";
                            }

                        }

                        #endregion

                        #region Packing Department Status Check
                        if (_packingQuantity > 0)
                        {
                            lblIsUnderPacking.Visible = lblPackingStatus.Visible = btnSubmit.Visible = btnView.Visible = btnTransferFromPacking.Visible = false;
                            btnPackingQuantity.Text = (_temperingQuantity + "/" + _packingQuantity).ToString();
                            btnPackingQuantity.Visible = btnStart.Visible = btnViewStatus.Visible = true;
                            lblPackingStatus.CssClass = "";
                        }
                        else if (_packaingId > 0)
                        {
                            lblIsUnderPacking.Visible =  btnPackingQuantity.Visible = btnStart.Visible = btnView.Visible = false;
                            lblPackingStatus.Visible = btnSubmit.Visible = btnViewStatus.Visible = btnTransferFromPacking.Visible = true;
                            lblPackingStatus.Text = App.Helper.Utils.OrderStatus.progress.ToString();
                            lblPackingStatus.CssClass = "text-capitalize zoom-in-out-box";
                        }
                        else
                        {

                            if (_temperingQuantity > 0)
                            {
                                //correct Name Here
                                lblIsUnderPacking.Visible =  btnPackingQuantity.Visible = btnSubmit.Visible = btnView.Visible = false;
                                lblPackingStatus.Visible = btnStart.Visible = btnViewStatus.Visible = btnTransferFromPacking.Visible = true;
                                lblPackingStatus.Text = App.Helper.Utils.OrderStatus.progress.ToString();
                                lblPackingStatus.CssClass = "text-capitalize zoom-in-out-box";
                            }
                            else if (_temperingId > 0)
                            {
                                lblPackingStatus.Text = "--";
                                lblPackingStatus.Visible = btnSubmit.Visible = btnViewStatus.Visible = true;
                                btnStart.Visible =  btnView.Visible =  btnTransferFromPacking.Visible = false;
                            }
                            else
                            {
                                lblIsUnderPacking.Visible =  btnPackingQuantity.Visible = btnTransferFromPacking.Visible = false;
                                lblPackingStatus.Visible = btnViewStatus.Visible = true;
                                lblPackingStatus.Text = "--";
                                lblPackingStatus.CssClass = "";
                            }

                        }

                        #endregion

                        #region Store Department Status Check
                        if (_storeQuantity > 0)
                        {
                            lblIsUnderStore.Visible = lblStoreStatus.Visible = btnStart.Visible = btnSubmit.Visible = btnViewStatus.Visible = btnHold.Visible = btnTransferFromUnderStore.Visible = false;
                            btnStoreQuantity.Text = (_packingQuantity + "/" + _storeQuantity).ToString();
                            btnStoreQuantity.Visible = btnView.Visible = true;
                            lblStoreStatus.CssClass = "";
                        }
                        else if (_storeId > 0)
                        {
                            lblIsUnderStore.Visible = btnStoreQuantity.Visible = btnStart.Visible = btnView.Visible = false;
                            lblStoreStatus.Visible = btnSubmit.Visible = btnViewStatus.Visible = btnHold.Visible = btnTransferFromUnderStore.Visible = true;
                            lblStoreStatus.Text = App.Helper.Utils.OrderStatus.progress.ToString();
                            lblStoreStatus.CssClass = "text-capitalize zoom-in-out-box";
                        }
                        else
                        {

                            if (_packingQuantity > 0)
                            {
                                //correct Name Here
                                lblIsUnderStore.Visible =  btnStoreQuantity.Visible = btnSubmit.Visible = btnView.Visible = false;
                                lblStoreStatus.Visible = btnStart.Visible = btnViewStatus.Visible = btnHold.Visible = btnTransferFromUnderStore.Visible = true;
                                lblStoreStatus.Text = App.Helper.Utils.OrderStatus.progress.ToString();
                                lblStoreStatus.CssClass = "text-capitalize zoom-in-out-box";
                            }
                            else if (_packaingId > 0)
                            {
                                lblStoreStatus.Text = "--";
                                lblStoreStatus.Visible = btnSubmit.Visible = btnViewStatus.Visible = btnHold.Visible = true;
                                btnStart.Visible =  btnView.Visible = btnTransferFromUnderStore.Visible = false;
                            }
                            else
                            {
                                lblIsUnderStore.Visible =  btnStoreQuantity.Visible = btnTransferFromUnderStore.Visible = false;
                                lblStoreStatus.Visible = btnViewStatus.Visible = true;
                                lblStoreStatus.Text = "--";
                                lblStoreStatus.CssClass = "";
                            }

                        }

                        #endregion

                        #endregion


                        if(_productionstatus == App.Helper.Utils.ProductionType.transfer.ToString())
                        {
                            btnTransferFromCutting.Visible = btnTransferFromgrinding.Visible = btnTransferFromWashingOne.Visible = btnTransferFromHole.Visible = btnTransferFromWashing.Visible =
                            btnTransferFromPaint.Visible = btnTransferFromDfgPrint.Visible = btnTransferFromTempering.Visible = btnTransferFromPacking.Visible =  btnTransferFromPacking.Visible = false;

                            btnStart.Visible = btnSubmit.Visible = btnHold.Visible = false;
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


        #endregion



        /// <summary>
        /// This Method is Used to get Depatment Wise Route Url and Route Page According to Department Wise
        /// </summary>
        /// <param name="_productionId">This is Production Id  ( Like 1,2) </param>
        /// <returns></returns>
        private string GetDepartmentRoutingUrl(string _productionId)
        {
            string _urlRoutingString = string.Empty;
            Int64 id = Convert.ToInt64(_productionId);
            _objProductionBL = new ProductionBL();
            
            _objProduction = _objProductionBL.GetAllProductionItems().Where(x => x.production_id == id).FirstOrDefault();
            if (_objProduction != null)
            {
               
                if (_objProduction.store_id >0)
                {
                    _urlRoutingString = "/production/store/" + App.Core.DataSecurity.Encryptdata(_objProduction.store_id.ToString()).ToString();
                }
                else if (_objProduction.packing_id >0)
                {
                    _urlRoutingString = "/production/packing/" + App.Core.DataSecurity.Encryptdata(_objProduction.packing_id.ToString()).ToString();
                }
                else if (_objProduction.tempering_id >0)
                {
                    _urlRoutingString = "/production/tempering/" + App.Core.DataSecurity.Encryptdata(_objProduction.tempering_id.ToString()).ToString();
                }
                else if (_objProduction.dfg_print_id >0)
                {
                    _urlRoutingString = "/production/dfg-print/" + App.Core.DataSecurity.Encryptdata(_objProduction.dfg_print_id.ToString()).ToString();
                }
                else if (_objProduction.paint_id >0)
                {
                    _urlRoutingString = "/production/paint/" + App.Core.DataSecurity.Encryptdata(_objProduction.paint_id.ToString()).ToString();
                }
                else if (_objProduction.washing_id >0)
                {
                    _urlRoutingString = "/production/washing/" + App.Core.DataSecurity.Encryptdata(_objProduction.washing_id.ToString()).ToString();
                }
                
                else if (_objProduction.hole_id >0)
                {
                    _urlRoutingString = "/production/hole/" + App.Core.DataSecurity.Encryptdata(_objProduction.hole_id.ToString()).ToString();
                }
                else if (_objProduction.washing_one_id > 0)
                {
                    _urlRoutingString = "/production/washing-one/" + App.Core.DataSecurity.Encryptdata(_objProduction.washing_one_id.ToString()).ToString();
                }

                else if (_objProduction.grinding_id >0)
                {
                    _urlRoutingString = "/production/grinding/" + App.Core.DataSecurity.Encryptdata(_objProduction.grinding_id.ToString()).ToString();
                }
                else if (_objProduction.cutting_id >0)
                {
                    _urlRoutingString = "/production/cutting/" + App.Core.DataSecurity.Encryptdata(_objProduction.cutting_id.ToString()).ToString();
                }

                else
                {

                }

            }
            return _urlRoutingString;
        }


            #region  Add Production Method

        /// <summary>
        /// This Method is Used to Start Production like Set Shift and Planned Date and Plant Name and Approved Items for Production
        /// </summary>
        /// <param name="_productionId"></param>
            private void AddProduction(string _productionId, DateTime _planned_Date, string plantName)
        {
            Int64 id = Convert.ToInt64(_productionId);
            _objProductionBL = new ProductionBL();
            
            DateTime _convertPlannedDate = Convert.ToDateTime(_planned_Date);
            DateTime _finalPlannedDate = new DateTime(_convertPlannedDate.Year, _convertPlannedDate.Month, _convertPlannedDate.Day, _convertPlannedDate.Hour, _convertPlannedDate.Minute, _convertPlannedDate.Second);
            _objProduction = _objProductionBL.GetAllProductionItems().Where(x => x.production_plant == plantName && x.production_status == App.Helper.Utils.OrderStatus.production.ToString()&&  x.planned_date== Convert.ToDateTime(_finalPlannedDate)).FirstOrDefault();

            //DateTime _fDate = DateTime.ParseExact(_plannedDate, "dd/MM/yyyy", null);
            //_objProduction = _objProductionBL.GetAllProductionItems().Where(x => x.production_plant == plantName && x.production_status == App.Helper.Utils.OrderStatus.production.ToString() && x.planned_date == _dateCombinee).FirstOrDefault();

            if (_objProduction != null)
            {
                txtNoOfSheetIssuedByAcknowledge.Text = txtSheetHeight.Text = txtSheetWidth.Text = "0";
                lblSelectedDrawingName.Text = lblSelectedDrawingId.Text = string.Empty;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlreadyInProduction();", true);
            }
            else
            {
                _objProduction = _objProductionBL.GetAllProductionItems().Where(x => x.production_id == id).FirstOrDefault();

                if (_objProduction.production_id > 0)
                {
                   
                    _objProduction = _objProductionBL.UpdateProduction(GetProductionDetailsForAdd());
                    if (_objProduction != null)
                    {
                        _objDraftMasterBL = new DraftMasterBL();
                        try
                        {
                            

                            _objDraftMaster.guid = Guid.NewGuid();
                            _objDraftMaster.production_id = _objProduction.production_id;
                            _objDraftMaster.batch_number = _objProduction.batch_number;
                            _objDraftMaster.parent_item_master_id = _objProduction.item_master_id;
                            _objDraftMaster.items_name = txtLeftOverSizeHeight.Text + "x" + txtLeftOverSizeWidthfromAcknowledge.Text +" "+ _objProduction.item_glass_color;
                            _objDraftMaster.draft_quantity = Convert.ToInt32(txtNoofDraftSheetLeft.Text =="" ? "0" : txtNoofDraftSheetLeft.Text);

                            if (ddlLeftoverStatus.SelectedValue == "Yes")
                            {
                                _objDraftMaster.left_over_size_availabel = ddlLeftoverStatus.SelectedValue == "Yes" ? true : false;
                            }
                            else if (ddlLeftoverStatus.SelectedValue == "No")
                            {
                                _objDraftMaster.left_over_size_availabel = ddlLeftoverStatus.SelectedValue == "No" ? false : true;
                            }
                            else
                            {
                                _objDraftMaster.left_over_size_availabel = false;
                            }

                            _objDraftMaster.left_over_size = txtLeftOverSizeHeight.Text + "x" + txtLeftOverSizeWidthfromAcknowledge.Text;
                            _objDraftMaster.remarks = txtRemarks.Text;
                            _objDraftMaster.draft_status = _objDraftMaster.left_over_size_availabel == true ? "available" : "unavailable";

                            _objDraftMaster = _objDraftMasterBL.CreateDraftMaster(_objDraftMaster);
                        }
                        catch (Exception ex)
                        {
                            ex.Message.ToString();
                        }
                       

                        if (_objDraftMaster !=null)
                        {
                            _objOnFloorItemMasterBL = new OnFloorItemMasterBL();

                            _dataTableItemsList = (DataTable)ViewState["Acknowledge"];
                            if (_dataTableItemsList.Rows.Count > 1)
                            {
                                
                                int _OnFloorOtherItemSaveCount = 0;

                                for (int _rowIndexPosition = 1; _rowIndexPosition < _dataTableItemsList.Rows.Count; _rowIndexPosition++)
                                {

                                    try
                                    {
                                        _objOnFloorItemMaster.guid = Guid.NewGuid();
                                        _objOnFloorItemMaster.production_id = _objProduction.production_id;
                                        _objOnFloorItemMaster.batch_number = _objProduction.batch_number;
                                        _objOnFloorItemMaster.parent_item_master_id = _objProduction.item_master_id;
                                        _objOnFloorItemMaster.on_floor_items_master_id = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["item_master_id"].ToString());
                                        _objOnFloorItemMaster.items_name = _dataTableItemsList.Rows[_rowIndexPosition]["item_name"].ToString();
                                        _objOnFloorItemMaster.items_type = _dataTableItemsList.Rows[_rowIndexPosition]["item_type"].ToString();
                                        _objOnFloorItemMaster.broken_sheet_size = _objProduction.sheet_size;
                                        //_objOnFloorItemMaster.broken_sheet_quantity = _objProduction.no_of_sheets_issue;
                                        _objOnFloorItemMaster.per_broken_sheet_quantity = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["item_quantity_per_sheet"].ToString());
                                        _objOnFloorItemMaster.per_broken_sheet_quantity_expected = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["item_pcs_total_expectation"].ToString());
                                        _objOnFloorItemMaster.items_pcs_quantity = 0;

                                        if (ddlLeftoverStatus.SelectedValue == "Yes")
                                        {
                                            _objDraftMaster.left_over_size_availabel = ddlLeftoverStatus.SelectedValue == "Yes" ? true : false;
                                        }
                                        else if (ddlLeftoverStatus.SelectedValue == "No")
                                        {
                                            _objDraftMaster.left_over_size_availabel = ddlLeftoverStatus.SelectedValue == "No" ? false : true;
                                        }
                                        else
                                        {
                                            _objDraftMaster.left_over_size_availabel = false;
                                        }
                                        // _objOnFloorItemMaster.left_over_size_availabel = ddlLeftoverStatus.SelectedValue == "0" ? false : true;
                                        if (_objOnFloorItemMaster.items_type == "Draft")
                                        {
                                            _objOnFloorItemMaster.left_over_size = _objOnFloorItemMaster.items_name;
                                            int _itemQuantityPerSheet = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["item_quantity_per_sheet"].ToString());
                                            int _itemPcsTotalExpectation = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["item_pcs_total_expectation"].ToString());
                                            int _usedDraftQuantity = (_itemPcsTotalExpectation / _itemQuantityPerSheet);
                                            _objOnFloorItemMaster.broken_sheet_quantity = _usedDraftQuantity;
                                           
                                        }
                                        else
                                        {
                                            _objOnFloorItemMaster.left_over_size = txtLeftOverSizeHeight.Text + "x" + txtLeftOverSizeWidthfromAcknowledge.Text;
                                            _objOnFloorItemMaster.broken_sheet_quantity = Convert.ToInt32(_objProduction.no_of_sheets_issue);
                                        }

                                        _objOnFloorItemMaster.remarks = txtRemarks.Text;

                                        _objOnFloorItemMaster = _objOnFloorItemMasterBL.CreateOnFloorItemMaster(_objOnFloorItemMaster);
                                        _OnFloorOtherItemSaveCount = _OnFloorOtherItemSaveCount + 1;
                                    }
                                    catch (Exception ex)
                                    {
                                        ex.Message.ToString();
                                    }

                                    try
                                    {
                                        if (_dataTableItemsList.Rows[_rowIndexPosition]["item_type"].ToString() == "Draft")
                                        {
                                            _objDraftMasterBL = new DraftMasterBL();

                                            _objDraftMaster = _objDraftMasterBL.GetAllDraftMasterItems().Where(x => x.draft_master_id == _objOnFloorItemMaster.on_floor_items_master_id).FirstOrDefault();
                                            if (_objDraftMaster != null)
                                            {

                                                int _itemQuantityPerSheet = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["item_quantity_per_sheet"].ToString());
                                                int _itemPcsTotalExpectation = Convert.ToInt32(_dataTableItemsList.Rows[_rowIndexPosition]["item_pcs_total_expectation"].ToString());
                                                int _usedDraftQuantity = (_itemPcsTotalExpectation / _itemQuantityPerSheet);
                                                if (_objDraftMaster.draft_quantity == _usedDraftQuantity)
                                                {
                                                    _objDraftMaster.draft_status = _objDraftMaster.left_over_size_availabel == true ? "used" : "unavailable";
                                                }
                                                else
                                                {
                                                    _objDraftMaster.draft_quantity = (_objDraftMaster.draft_quantity - _usedDraftQuantity);
                                                    _objDraftMaster.draft_status = "available";
                                                }
                                                

                                                _objDraftMaster = _objDraftMasterBL.UpdateDraftMaster(_objDraftMaster);
                                                if (_objDraftMaster != null)
                                                {

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
                                    }
                                    catch (Exception ex)
                                    {
                                        ex.Message.ToString();
                                    }

                                   



                                }

                                if (_OnFloorOtherItemSaveCount > 0)
                                {
                                    rptrAcknowledgeItemsList.DataSource = null;
                                    rptrAcknowledgeItemsList.DataBind();
                                    rptrAcknowledgeItemsList.Visible = false;
                                    ViewState["Acknowledge"] = null;
                                    // ClearPurchaseForm();
                                    string _production_Id = _objProduction.production_id.ToString();
                                    string _itemMasterId = _objProduction.item_master_id.ToString();
                                    string _processName = "Acknowelge";
                                    string _heading = "Acknowelge Added Successfully";
                                    string _heading_class = "text-success";
                                    string _activity = "Acknowelge Added,Item Add in Production for Start Production";
                                    string _icon = "fas fa-add";
                                    string _iconClass = "timeline-icon themed-background-emerald themed-border-emerald";
                                    ProductionTrailLogs(_production_Id, _itemMasterId, _processName, _heading, _heading_class, _activity, _icon, _iconClass);

                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccess();", true);
                                    BindProductionRptr();
                                    txtNoOfSheetIssuedByAcknowledge.Text = txtSheetHeight.Text = txtSheetWidth.Text = txtNoofSheetIssue.Text = txtQuantityPerSheet.Text = txtItemQuantityPerSheetfromOther.Text = txttotalExpectation.Text = txtTotalExpectationfromOther.Text = "0";
                                    txtSheetHeight.ReadOnly = txtSheetWidth.ReadOnly = txtNoofSheetIssue.ReadOnly = txtQuantityPerSheet.ReadOnly = false;
                                    lblSelectedDrawingName.Text = lblSelectedDrawingId.Text = string.Empty;
                                    lblErrorMessage.Visible = false;
                                    lblErrorMessage.Text = string.Empty;

                                    ddlItemList.SelectedIndex = 0;
                                    ddlItemTypeforSearch.SelectedIndex = 0;

                                    txtSheetHeight.Text = txtLeftOverSizeHeight.Text = txtLeftOverSizeWidthfromAcknowledge.Text = "0";
                                    divMoreItemAdd.Visible = false;
                                    btnShowMoreItemField.Visible = false;
                                    btnAddItem.Visible = true;
                                    ddlLeftoverStatus.SelectedIndex = 0;
                                    txtRemarks.Text = "";

                                   


                                }
                            }
                            else
                            {
                                rptrAcknowledgeItemsList.DataSource = null;
                                rptrAcknowledgeItemsList.DataBind();
                                rptrAcknowledgeItemsList.Visible = false;
                                ViewState["Acknowledge"] = null;

                                string _production_Id = _objProduction.production_id.ToString();
                                string _itemMasterId = _objProduction.item_master_id.ToString();
                                string _processName = "Acknowelge";
                                string _heading = "Acknowelge Added Successfully";
                                string _heading_class = "text-success";
                                string _activity = "Acknowelge Added , Item Add in Production for Start Production";
                                string _icon = "fas fa-add";
                                string _iconClass = "timeline-icon themed-background-emerald themed-border-emerald";
                                ProductionTrailLogs(_production_Id, _itemMasterId, _processName, _heading, _heading_class, _activity, _icon, _iconClass);

                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccess();", true);
                                BindProductionRptr();
                                txtNoOfSheetIssuedByAcknowledge.Text = txtSheetHeight.Text = txtSheetWidth.Text = txtNoofSheetIssue.Text = txtQuantityPerSheet.Text = txtItemQuantityPerSheetfromOther.Text = txttotalExpectation.Text = txtTotalExpectationfromOther.Text = txtLeftOverSizeHeight.Text = txtLeftOverSizeWidthfromAcknowledge.Text = "0";
                                txtSheetHeight.ReadOnly = txtSheetWidth.ReadOnly = txtNoofSheetIssue.ReadOnly = txtQuantityPerSheet.ReadOnly = false;
                                lblSelectedDrawingName.Text = lblSelectedDrawingId.Text = string.Empty;
                                lblErrorMessage.Visible = false;
                                lblErrorMessage.Text = string.Empty;

                                ddlItemList.SelectedIndex = 0;
                                ddlItemTypeforSearch.SelectedIndex = 0;

                                txtSheetHeight.Text = txtLeftOverSizeHeight.Text = txtLeftOverSizeWidthfromAcknowledge.Text = "0";
                                divMoreItemAdd.Visible = false;
                                btnShowMoreItemField.Visible = false;
                                btnAddItem.Visible = true;
                                ddlLeftoverStatus.SelectedIndex = 0;
                                txtRemarks.Text = "";

                                
                                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
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
            }

           
        }

        #endregion


        #region  Hold Production Method

        /// <summary>
        /// This Method is Used to Start Production like Set Shift and Planned Date and Plant Name and Approved Items for Production
        /// </summary>
        /// <param name="_productionId"></param>
        private void HoldProduction(string _productionId)
        {
            Int64 id = Convert.ToInt64(_productionId);
            _objProductionBL = new ProductionBL();
           
                _objProduction = _objProductionBL.GetAllProductionItems().Where(x => x.production_id == id).FirstOrDefault();

                if (_objProduction.production_id > 0)
                {

                if(_objProduction.production_status == App.Helper.Utils.OrderStatus.production.ToString()) 
                {
                    _objProduction.production_status = App.Helper.Utils.OrderStatus.hold.ToString();
                }
                else if(_objProduction.production_status == App.Helper.Utils.OrderStatus.hold.ToString())
                {
                    _objProduction.production_status = App.Helper.Utils.OrderStatus.production.ToString();
                }
                else
                {

                }
                    _objProduction = _objProductionBL.UpdateProduction(_objProduction);
                    if (_objProduction != null)
                    {
                    string _heading ,_activity= string.Empty;
                    string _production_Id = _objProduction.production_id.ToString();
                    string _itemMasterId = _objProduction.item_master_id.ToString();
                    string _processName = "Hold";
                    if (_objProduction.production_status== App.Helper.Utils.OrderStatus.hold.ToString())
                    {
                        _heading = "Hold Started Successfully";
                         _activity = "Item Hold Procces Started ";
                    }
                    else
                    {
                        _heading = "Hold Stop Successfully";
                         _activity = "Item Hold Procces Stop ";
                    }
                    
                    string _heading_class = "text-success";
                    
                    string _icon = "fas fa-add";
                    string _iconClass = "timeline-icon themed-background-emerald themed-border-emerald";
                    ProductionTrailLogs(_production_Id, _itemMasterId, _processName, _heading, _heading_class, _activity, _icon, _iconClass);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccess();", true);
                        BindProductionRptr();

                    }



                }
                else
                {

                }
           

        }

        #endregion 

        #region  Hold Production Method

        /// <summary>
        /// This Method is Used to Transfer Production Item at onFloor 
        /// </summary>
        /// <param name="_productionitemMasterId"></param>
        /// <param name="_batchId"></param>
        /// <param name="_transferBy"></param>
        private void TransferProductionItemOnFloor(string _productionitemMasterId,string _batchId, string _transferBy)
        {
            Int64 _productionItemMasterId = Convert.ToInt64(_productionitemMasterId);
            string _productionBatchId = _batchId;
            _objProductionBL = new ProductionBL();
            _objOnFloorItemMasterBL = new OnFloorItemMasterBL();

            _objProduction = _objProductionBL.GetAllProductionItems().Where(x => x.batch_number == _productionBatchId && x.item_master_id  == _productionItemMasterId).FirstOrDefault();

            if (_objProduction.production_id > 0)
            {

                try
                {
                    _objOnFloorItemMaster.guid = Guid.NewGuid();
                    _objOnFloorItemMaster.production_id = _objProduction.production_id;
                    _objOnFloorItemMaster.batch_number = _objProduction.batch_number;
                    _objOnFloorItemMaster.parent_item_master_id = _objProduction.item_master_id;
                    _objOnFloorItemMaster.on_floor_items_master_id = _objProduction.item_master_id;
                    _objOnFloorItemMaster.items_name = _objProduction.item_brand + _objProduction.item_model+ _objProduction.item_type_name+ _objProduction.item_glass_color;
                    _objOnFloorItemMaster.items_type = "Item";
                    _objOnFloorItemMaster.broken_sheet_size = _objProduction.sheet_size;
                    //_objOnFloorItemMaster.broken_sheet_quantity = _objProduction.no_of_sheets_issue;
                    _objOnFloorItemMaster.per_broken_sheet_quantity = _objProduction.quantity_per_sheet;
                    _objOnFloorItemMaster.per_broken_sheet_quantity_expected = _objProduction.total_expectation;

                   if(_objProduction.cutting_id == 0 )
                    {
                        _objOnFloorItemMaster.items_pcs_quantity = _objProduction.total_expectation;
                    }
                   else if (_objProduction.cutting_id >0 && _objProduction.cutting_quantity > 0 && _transferBy == App.Helper.Utils.ProductionType.cutting.ToString())
                    {
                        _objOnFloorItemMaster.items_pcs_quantity = _objProduction.cutting_quantity;
                    }
                    else if (_objProduction.grinding_id > 0 && _objProduction.grinding_quantity > 0 && _transferBy == App.Helper.Utils.ProductionType.grinding.ToString())
                    {
                        _objOnFloorItemMaster.items_pcs_quantity = _objProduction.grinding_quantity;
                    }
                    else if (_objProduction.washing_one_id > 0 && _objProduction.washing_one_quantity > 0 && _transferBy == App.Helper.Utils.ProductionType.washingone.ToString())
                    {
                        _objOnFloorItemMaster.items_pcs_quantity = _objProduction.washing_one_quantity;
                    }
                    else if (_objProduction.hole_id > 0 && _objProduction.hole_quantity > 0 && _transferBy == App.Helper.Utils.ProductionType.hole.ToString())
                    {
                        _objOnFloorItemMaster.items_pcs_quantity = _objProduction.hole_quantity;
                    }
                    else if (_objProduction.washing_id > 0 && _objProduction.washing_quantity > 0 && _transferBy == App.Helper.Utils.ProductionType.washing.ToString())
                    {
                        _objOnFloorItemMaster.items_pcs_quantity = _objProduction.washing_quantity;
                    }
                    else if (_objProduction.paint_id > 0 && _objProduction.paint_quantity > 0 && _transferBy == App.Helper.Utils.ProductionType.paint.ToString())
                    {
                        _objOnFloorItemMaster.items_pcs_quantity = _objProduction.paint_quantity;
                    }
                    else if (_objProduction.dfg_print_id > 0 && _objProduction.dfg_print_quantity > 0 && _transferBy == App.Helper.Utils.ProductionType.dfgprint.ToString())
                    {
                        _objOnFloorItemMaster.items_pcs_quantity = _objProduction.dfg_print_quantity;
                    }
                    else if (_objProduction.tempering_id > 0 && _objProduction.tempering_quantity > 0 && _transferBy == App.Helper.Utils.ProductionType.tempring.ToString())
                    {
                        _objOnFloorItemMaster.items_pcs_quantity = _objProduction.tempering_quantity;
                    }
                    else if (_objProduction.packing_id > 0 && _objProduction.packing_quantity > 0 && _transferBy == App.Helper.Utils.ProductionType.packing.ToString())
                    {
                        _objOnFloorItemMaster.items_pcs_quantity = _objProduction.packing_quantity;
                    }
                    else if (_objProduction.store_id > 0 && _objProduction.store_quantity > 0 && _transferBy == App.Helper.Utils.ProductionType.store.ToString())
                    {
                        _objOnFloorItemMaster.items_pcs_quantity = _objProduction.store_quantity;
                    }
                    else
                    {
                        _objOnFloorItemMaster.items_pcs_quantity = _objProduction.total_expectation;
                    }
                    

                    _objDraftMaster.left_over_size_availabel = false;
                    // _objOnFloorItemMaster.left_over_size_availabel = ddlLeftoverStatus.SelectedValue == "0" ? false : true;

                    _objOnFloorItemMaster.left_over_size = txtLeftOverSizeHeight.Text + "x" + txtLeftOverSizeWidthfromAcknowledge.Text;
                    _objOnFloorItemMaster.broken_sheet_quantity = Convert.ToInt32(_objProduction.no_of_sheets_issue);

                    _objOnFloorItemMaster.remarks = "This Item is Transfer By "+_transferBy +" Department";

                    _objOnFloorItemMaster = _objOnFloorItemMasterBL.CreateOnFloorItemMaster(_objOnFloorItemMaster);
                   
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }

                _objProduction.production_status = App.Helper.Utils.OrderStatus.transfer.ToString();
                
                _objProduction = _objProductionBL.UpdateProduction(_objProduction);
                if (_objProduction != null)
                {
                    string _heading, _activity = string.Empty;
                    string _production_Id = _objProduction.production_id.ToString();
                    string _itemMasterId = _objProduction.item_master_id.ToString();
                    string _processName = "Transfer Item";

                    _heading = "Production Item Transfer on Floor Successfully";
                    _activity = "Production Item Transfer on Floor By " + _transferBy + " Department ";

                    string _heading_class = "text-success";

                    string _icon = "fas fa-add";
                    string _iconClass = "timeline-icon themed-background-emerald themed-border-emerald";
                    ProductionTrailLogs(_production_Id, _itemMasterId, _processName, _heading, _heading_class, _activity, _icon, _iconClass);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccess();", true);
                    BindProductionRptr();

                }



            }
            else
            {

            }


        }

        #endregion


        #region  Start Department Wise Process Method
        /// <summary>
        /// This Method is Used to Start Process of Items According to Department Wise Like Cutting Start and Submit Cutting Details and Grinding Start etc.
        /// </summary>
        /// <param name="_productionId"></param>
        private void StartDepartmentProcess(string _productionId)
        {
            Int64 id = Convert.ToInt64(_productionId);
            _objProductionBL = new ProductionBL();
            _objProcessCuttingBL = new ProcessCuttingBL();
            _objProduction = _objProductionBL.GetAllProductionItems().Where(x => x.production_id == id).FirstOrDefault();
            if (_objProduction !=null)
            {
                if (_objProduction.is_under_cutting ==true && _objProduction.cutting_id ==0)
                {
                    hdnProductionId.Value = string.Empty;

                    hdnProductionId.Value = _objProduction.production_id.ToString();

                    txtNoofSheet.Text = _objProduction.no_of_sheets_issue.ToString();
                    txtNoofSheet.ReadOnly = true;
                    txtCuttingItemThickness.Text = _objProduction.item_thickness.ToString();
                    txtCuttingItemThickness.ReadOnly = true;
                    txtCuttingItemNameWithColor.Text = _objProduction.item_model + " | " +_objProduction.item_type_name + " | " + _objProduction.item_glass_color;
                    txtCuttingItemNameWithColor.ReadOnly = true;
                    _objDrawingMasterBL = new DrawingMasterBL();
                    _objDrawingMaster = _objDrawingMasterBL.GetAllDrawingMasterItems().Where(x => x.drawing_master_id == _objProduction.drawing_master_id).FirstOrDefault();
                    if (_objDrawingMaster != null)
                    {
                       string url = "/assets/drawing/" + _objDrawingMaster.drawing_image;
                        lblCuttingDrawingImageUrl.ImageUrl = url;
                        
                       
                        txtBrokenSheetInCreate.Text = txtPcsCutFromSheet.Text = txtLeftOverSizeLength.Text = txtLeftOverSizeWidth.Text = txtSheetReceivedInCrate.Text = "0";
                        txtBrokenSheetInCreate.ReadOnly = txtPcsCutFromSheet.ReadOnly = txtLeftOverSizeLength.ReadOnly = txtLeftOverSizeWidth.ReadOnly = true;

                        BindOnFloorOtherItemRptr(_objProduction.batch_number, _objProduction.item_master_id.ToString());

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showBrokenCratetModal();", true);

                        
                    }
                    else
                    {

                    }

                }
                else if (_objProduction.is_under_grinding == true && _objProduction.grinding_id == 0)
                {
                    _objProcessGrindingBL = new ProcessGrindingBL();
                    _objProcessCuttingBL = new ProcessCuttingBL();
                    _objProcessCutting = _objProcessCuttingBL.GetAllProcessCuttingItems().Where(x => x.process_cutting_id == _objProduction.cutting_id).FirstOrDefault();
                    if (_objProcessCutting != null)
                    {
                        _objProcessGrinding = _objProcessGrindingBL.CreateProcessGrinding(GetProcessGrindingDetailsForAdd());
                        if (_objProcessGrinding != null)
                        {

                            _objProductionBL = new ProductionBL();
                            _objProduction = _objProductionBL.GetAllProductionItems().Where(x => x.item_master_id == _objProcessGrinding.item_master_id && x.batch_number == _objProcessGrinding.batch_number).FirstOrDefault();
                            if (_objProduction.production_id > 0)
                            {
                                _objProduction.grinding_id = _objProcessGrinding.process_grinding_id;
                                _objProduction.grinding_quantity = _objProcessGrinding.total_pcs_transferred;
                                //_objProduction.is_under_grinding = true;
                                _objProduction = _objProductionBL.UpdateProduction(_objProduction);
                                if (_objProduction.production_id > 0)
                                {
                                    string _production_Id = _objProduction.production_id.ToString();
                                    string _itemMasterId = _objProduction.item_master_id.ToString();
                                    string _processName = "Grinding";
                                    string _heading = "Grinding Started Successfully";
                                    string _heading_class = "text-success";
                                    string _activity = "Item  Grinding  Procces Started ";
                                    string _icon = "fas fa-add";
                                    string _iconClass = "timeline-icon themed-background-emerald themed-border-emerald";
                                    ProductionTrailLogs(_production_Id, _itemMasterId, _processName, _heading, _heading_class, _activity, _icon, _iconClass);

                                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingProcessSuccess();", true);
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showGrindingProcessStart();", true);
                                    BindProductionRptr();
                                }

                            }


                        }
                    }
                }

                //start Washing One 

                else if (_objProduction.is_under_washing_one == true && _objProduction.washing_one_id == 0)
                {
                    _objProcessWashingOneBL = new ProcessWashingOneBL();
                    _objProcessCuttingBL = new ProcessCuttingBL();
                    _objProcessCutting = _objProcessCuttingBL.GetAllProcessCuttingItems().Where(x => x.process_cutting_id == _objProduction.cutting_id).FirstOrDefault();
                    if (_objProcessCutting != null)
                    {
                        _objProcessWashingOne = _objProcessWashingOneBL.CreateProcessWashingOne(GetProcessWashingOneDetailsForAdd());
                        if (_objProcessWashingOne != null)
                        {

                            _objProductionBL = new ProductionBL();
                            _objProduction = _objProductionBL.GetAllProductionItems().Where(x => x.item_master_id == _objProcessWashingOne.item_master_id && x.batch_number == _objProcessWashingOne.batch_number).FirstOrDefault();
                            if (_objProduction.production_id > 0)
                            {
                                _objProduction.washing_one_id = _objProcessWashingOne.process_washing_one_id;
                                _objProduction.washing_one_quantity = _objProcessWashingOne.total_pcs_transferred;
                                // _objProduction.is_under_hole = true;
                                _objProduction = _objProductionBL.UpdateProduction(_objProduction);
                                if (_objProduction.production_id > 0)
                                {
                                    string _production_Id = _objProduction.production_id.ToString();
                                    string _itemMasterId = _objProduction.item_master_id.ToString();
                                    string _processName = "Washing One";
                                    string _heading = "Washing One Started Successfully";
                                    string _heading_class = "text-success";
                                    string _activity = "Item Washing One Procces Started";
                                    string _icon = "fas fa-add";
                                    string _iconClass = "timeline-icon themed-background-emerald themed-border-emerald";
                                    ProductionTrailLogs(_production_Id, _itemMasterId, _processName, _heading, _heading_class, _activity, _icon, _iconClass);
                                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingProcessSuccess();", true);
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showWashingOneProcessStart();", true);
                                    BindProductionRptr();
                                }

                            }


                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                }

                //End Washing One


                else if (_objProduction.is_under_hole == true && _objProduction.hole_id == 0)
                {
                    _objProcessHoleBL = new ProcessHoleBL();
                    _objProcessCuttingBL = new ProcessCuttingBL();
                    _objProcessCutting = _objProcessCuttingBL.GetAllProcessCuttingItems().Where(x => x.process_cutting_id == _objProduction.cutting_id).FirstOrDefault();
                    if (_objProcessCutting != null)
                    {
                        string _washingOne_status = string.Empty;
                        if (_objProduction.is_under_hole == false && _objProduction.hole_id == 0)
                        {
                            _washingOne_status = "false";
                        }
                        else
                        {
                            _washingOne_status = "true";
                        }
                        _objProcessHole = _objProcessHoleBL.CreateProcessHole(GetProcessHoleDetailsForAdd(_washingOne_status));
                        if (_objProcessHole != null)
                        {
                           
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
                                    string _production_Id = _objProduction.production_id.ToString();
                                    string _itemMasterId = _objProduction.item_master_id.ToString();
                                    string _processName = "Hole";
                                    string _heading = "Hole Started Successfully";
                                    string _heading_class = "text-success";
                                    string _activity = "Item Hole Procces Started";
                                    string _icon = "fas fa-add";
                                    string _iconClass = "timeline-icon themed-background-emerald themed-border-emerald";
                                    ProductionTrailLogs(_production_Id, _itemMasterId, _processName, _heading, _heading_class, _activity, _icon, _iconClass);
                                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingProcessSuccess();", true);
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showHoleProcessStart();", true);
                                    BindProductionRptr();
                                }

                            }


                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                }
                else if (_objProduction.is_under_washing == true && _objProduction.washing_id == 0)
                {
                    _objProcessWashingBL = new ProcessWashingBL();
                    _objProcessCuttingBL = new ProcessCuttingBL();
                    _objProcessCutting = _objProcessCuttingBL.GetAllProcessCuttingItems().Where(x => x.process_cutting_id == _objProduction.cutting_id).FirstOrDefault();
                    if (_objProcessCutting != null)
                    {
                        string _hole_status = string.Empty;
                        if (_objProduction.is_under_hole == false && _objProduction.hole_id==0)
                        {
                             _hole_status = "false";
                        }
                        else
                        {
                             _hole_status = "true";
                        }
                        _objProcessWashing = _objProcessWashingBL.CreateProcessWashing(GetProcessWashingDetailsForAdd(_hole_status));
                        if (_objProcessWashing != null)
                        {

                            _objProductionBL = new ProductionBL();
                            _objProduction = _objProductionBL.GetAllProductionItems().Where(x => x.item_master_id == _objProcessWashing.item_master_id && x.batch_number == _objProcessWashing.batch_number).FirstOrDefault();
                            if (_objProduction.production_id > 0)
                            {
                                _objProduction.washing_id = _objProcessWashing.process_washing_id;
                                _objProduction.washing_quantity = _objProcessWashing.total_pcs_transferred;
                                // _objProduction.is_under_washing = true;
                                _objProduction = _objProductionBL.UpdateProduction(_objProduction);
                                if (_objProduction.production_id > 0)
                                {
                                    string _production_Id = _objProduction.production_id.ToString();
                                    string _itemMasterId = _objProduction.item_master_id.ToString();
                                    string _processName = "Washing";
                                    string _heading = "Washing Started Successfully";
                                    string _heading_class = "text-success";
                                    string _activity = "Item Washing Procces Started";
                                    string _icon = "fas fa-add";
                                    string _iconClass = "timeline-icon themed-background-emerald themed-border-emerald";
                                    ProductionTrailLogs(_production_Id, _itemMasterId, _processName, _heading, _heading_class, _activity, _icon, _iconClass);

                                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingProcessSuccess();", true);
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showWashingProcessStart();", true);
                                    BindProductionRptr();
                                }

                            }


                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                }
                else if (_objProduction.is_under_paint == true && _objProduction.paint_id == 0)
                {
                    _objProcessPaintBL = new ProcessPaintBL();
                    _objProcessCuttingBL = new ProcessCuttingBL();
                    _objProcessCutting = _objProcessCuttingBL.GetAllProcessCuttingItems().Where(x => x.process_cutting_id == _objProduction.cutting_id).FirstOrDefault();
                    if (_objProcessCutting != null)
                    {
                        string _washing_status = string.Empty;
                        if (_objProduction.is_under_paint == false && _objProduction.paint_id == 0)
                        {
                            _washing_status = "false";
                        }
                        else
                        {
                            _washing_status = "true";
                        }

                        _objProcessPaint = _objProcessPaintBL.CreateProcessPaint(GetProcessPaintDetailsForAdd(_washing_status));
                        if (_objProcessPaint != null)
                        {

                            _objProductionBL = new ProductionBL();
                            _objProduction = _objProductionBL.GetAllProductionItems().Where(x => x.item_master_id == _objProcessPaint.item_master_id && x.batch_number == _objProcessPaint.batch_number).FirstOrDefault();
                            if (_objProduction.production_id > 0)
                            {
                                _objProduction.paint_id = _objProcessPaint.process_paint_id;
                                _objProduction.paint_quantity = _objProcessPaint.total_pcs_transferred;
                               // _objProduction.is_under_paint = true;
                                _objProduction = _objProductionBL.UpdateProduction(_objProduction);
                                if (_objProduction.production_id > 0)
                                {
                                    string _production_Id = _objProduction.production_id.ToString();
                                    string _itemMasterId = _objProduction.item_master_id.ToString();
                                    string _processName = "Paint";
                                    string _heading = "Paint Started Successfully";
                                    string _heading_class = "text-success";
                                    string _activity = "Item Paint Procces Started";
                                    string _icon = "fas fa-add";
                                    string _iconClass = "timeline-icon themed-background-emerald themed-border-emerald";
                                    ProductionTrailLogs(_production_Id, _itemMasterId, _processName, _heading, _heading_class, _activity, _icon, _iconClass);
                                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingProcessSuccess();", true);
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showPaintProcessStart();", true);
                                    BindProductionRptr();
                                }

                            }


                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                }
                else if (_objProduction.is_under_dfg_print == true && _objProduction.dfg_print_id == 0)
                {
                    _objProcessDfgPrintBL = new ProcessDfgPrintBL();
                    _objProcessCuttingBL = new ProcessCuttingBL();
                    _objProcessCutting = _objProcessCuttingBL.GetAllProcessCuttingItems().Where(x => x.process_cutting_id == _objProduction.cutting_id).FirstOrDefault();
                    if (_objProcessCutting != null)
                    {
                        string _paint_status = string.Empty;
                        if (_objProduction.is_under_paint == false && _objProduction.paint_id == 0)
                        {
                            _paint_status = "false";
                        }
                        else
                        {
                            _paint_status = "true";
                        }

                        
                        _objProcessDfgPrint = _objProcessDfgPrintBL.CreateProcessDfgPrint(GetProcessDfgPrintDetailsForAdd(_paint_status));
                        if (_objProcessDfgPrint != null)
                        {
                            
                            _objProductionBL = new ProductionBL();
                            _objProduction = _objProductionBL.GetAllProductionItems().Where(x => x.item_master_id == _objProcessDfgPrint.item_master_id && x.batch_number == _objProcessDfgPrint.batch_number).FirstOrDefault();
                            if (_objProduction.production_id > 0)
                            {
                                _objProduction.dfg_print_id = _objProcessDfgPrint.process_dfg_print_id;
                                _objProduction.dfg_print_quantity = _objProcessDfgPrint.total_pcs_transferred;
                                // _objProduction.is_under_dfg_print = true;
                                _objProduction = _objProductionBL.UpdateProduction(_objProduction);
                                if (_objProduction.production_id > 0)
                                {
                                    string _production_Id = _objProduction.production_id.ToString();
                                    string _itemMasterId = _objProduction.item_master_id.ToString();
                                    string _processName = "DFG Print";
                                    string _heading = "DFG Print Started Successfully";
                                    string _heading_class = "text-success";
                                    string _activity = "Item DFG Print Procces Started";
                                    string _icon = "fas fa-add";
                                    string _iconClass = "timeline-icon themed-background-emerald themed-border-emerald";
                                    ProductionTrailLogs(_production_Id, _itemMasterId, _processName, _heading, _heading_class, _activity, _icon, _iconClass);
                                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingProcessSuccess();", true);
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showDfgPrintProcessStart();", true);
                                    BindProductionRptr();
                                }

                            }


                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }

                }
                else if (_objProduction.is_under_tempering == true && _objProduction.tempering_id == 0)
                {
                    _objProcessTemperingBL = new ProcessTemperingBL();
                    _objProcessCuttingBL = new ProcessCuttingBL();
                    _objProcessCutting = _objProcessCuttingBL.GetAllProcessCuttingItems().Where(x => x.process_cutting_id == _objProduction.cutting_id).FirstOrDefault();
                    if (_objProcessCutting != null)
                    {
                        string _dfgPrint_status = string.Empty;
                        if (_objProduction.is_under_dfg_print == false && _objProduction.dfg_print_id == 0)
                        {
                            _dfgPrint_status = "false";
                        }
                        else if (_objProduction.is_under_paint == false && _objProduction.paint_id == 0)
                        {
                            _dfgPrint_status = "false";
                        }
                        else
                        {
                            _dfgPrint_status = "true";
                        }
                        _objProcessTempering = _objProcessTemperingBL.CreateProcessTempering(GetProcessTemperingDetailsForAdd(_dfgPrint_status));
                        if (_objProcessTempering != null)
                        {
                            _objProcessTemperingReportBL = new ProcessTemperingReportBL();

                            for (int _hoursVale = 1; _hoursVale < 13; _hoursVale++)
                            {
                                _objProcessTemperingReport.hour_name = (_hoursVale-1 +"-"+ _hoursVale.ToString());
                                _objProcessTemperingReport = _objProcessTemperingReportBL.CreateProcessTemperingReport(GetProcessTemperingReportDetailsForAdd(_dfgPrint_status));
                            }

                            

                            _objProductionBL = new ProductionBL();
                            _objProduction = _objProductionBL.GetAllProductionItems().Where(x => x.item_master_id == _objProcessTempering.item_master_id && x.batch_number == _objProcessTempering.batch_number).FirstOrDefault();
                            if (_objProduction.production_id > 0)
                            {
                                _objProduction.tempering_id = _objProcessTempering.process_tempering_id;
                                _objProduction.tempering_quantity = _objProcessTempering.total_pcs_transferred;
                                // _objProduction.is_under_tempering = true;
                                _objProduction = _objProductionBL.UpdateProduction(_objProduction);
                                if (_objProduction.production_id > 0)
                                {
                                    string _production_Id = _objProduction.production_id.ToString();
                                    string _itemMasterId = _objProduction.item_master_id.ToString();
                                    string _processName = "Tempering";
                                    string _heading = "Tempering Started Successfully";
                                    string _heading_class = "text-success";
                                    string _activity = "Item Tempering Procces Started";
                                    string _icon = "fas fa-add";
                                    string _iconClass = "timeline-icon themed-background-emerald themed-border-emerald";
                                    ProductionTrailLogs(_production_Id, _itemMasterId, _processName, _heading, _heading_class, _activity, _icon, _iconClass);
                                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingProcessSuccess();", true);
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showTemperingProcessStart();", true);
                                    BindProductionRptr();
                                }

                            }


                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                }
                else if (_objProduction.is_under_packing == true && _objProduction.packing_id == 0)
                {
                    _objProcessPackagingBL = new ProcessPackagingBL();
                    _objProcessPackaging = _objProcessPackagingBL.CreateProcessPackaging(GetProcessPackagingDetailsForAdd());
                    if (_objProcessPackaging != null)
                    {

                        _objProductionBL = new ProductionBL();
                        _objProduction = _objProductionBL.GetAllProductionItems().Where(x => x.item_master_id == _objProcessPackaging.item_master_id && x.batch_number == _objProcessPackaging.batch_number).FirstOrDefault();
                        if (_objProduction.production_id > 0)
                        {
                            _objProduction.packing_id = _objProcessPackaging.process_packaging_id;
                            _objProduction.packing_quantity = _objProcessPackaging.total_pcs_transferred;
                           // _objProduction.is_under_packing = true;
                            _objProduction = _objProductionBL.UpdateProduction(_objProduction);
                            if (_objProduction.production_id > 0)
                            {
                                string _production_Id = _objProduction.production_id.ToString();
                                string _itemMasterId = _objProduction.item_master_id.ToString();
                                string _processName = "Packing";
                                string _heading = "Packing Started Successfully";
                                string _heading_class = "text-success";
                                string _activity = "Item Packing Procces Started";
                                string _icon = "fas fa-add";
                                string _iconClass = "timeline-icon themed-background-emerald themed-border-emerald";
                                ProductionTrailLogs(_production_Id, _itemMasterId, _processName, _heading, _heading_class, _activity, _icon, _iconClass);
                                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingProcessSuccess();", true);
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showPackagingProcessStart();", true);
                                BindProductionRptr();
                            }

                        }


                    }
                }
                else if (_objProduction.is_under_store == true && _objProduction.store_id == 0)
                {
                    _objProcessStoreBL = new ProcessStoreBL();
                    _objProcessStore = _objProcessStoreBL.CreateProcessStore(GetProcessStoreDetailsForAdd());
                    if (_objProcessStore != null)
                    {

                        _objProductionBL = new ProductionBL();
                        _objProduction = _objProductionBL.GetAllProductionItems().Where(x => x.item_master_id == _objProcessStore.item_master_id && x.batch_number == _objProcessStore.batch_number).FirstOrDefault();
                        if (_objProduction.production_id > 0)
                        {
                            _objProduction.store_id = _objProcessStore.process_store_id;
                            _objProduction.store_quantity = _objProcessStore.total_pcs_transferred;
                           // _objProduction.is_under_store = true;
                            _objProduction = _objProductionBL.UpdateProduction(_objProduction);
                            if (_objProduction.production_id > 0)
                            {
                                string _production_Id = _objProduction.production_id.ToString();
                                string _itemMasterId = _objProduction.item_master_id.ToString();
                                string _processName = "Store";
                                string _heading = "Store Started Successfully";
                                string _heading_class = "text-success";
                                string _activity = "Item Store Procces Started";
                                string _icon = "fas fa-add";
                                string _iconClass = "timeline-icon themed-background-emerald themed-border-emerald";
                                ProductionTrailLogs(_production_Id, _itemMasterId, _processName, _heading, _heading_class, _activity, _icon, _iconClass);
                                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingProcessSuccess();", true);
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showStoreProcessStart();", true);
                                BindProductionRptr();
                            }

                        }


                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                }

                
            }


        }

        #endregion

        #region Get item DetailFor Add production
        /// <summary>
        /// This Method is Used to Get Staff Details From General Form TextFields to StaffMaster Object
        /// </summary>
        /// <returns></returns>
        private App.BusinessModel.Production GetProductionDetailsForAdd()
        {
            try
            {
               
                _objProduction.production_id = _objProduction.production_id;
                _objProduction.guid = _objProduction.guid;

                _objProduction.item_master_id = _objProduction.item_master_id;
                
                _objProduction.production_status = App.Helper.Utils.OrderStatus.production.ToString();
           
                _objProduction.batch_status = App.Helper.Utils.OrderStatus.production.ToString();
                //_objProduction.production_planning_id = _objProduction.production_planning_id;

                _objProduction.started_on = _objProduction.created_on;
                
                _objProduction.planned_date = DateTime.ParseExact(_plannedDate, "dd/MM/yyyy", null);
               // _objProduction.planned_date = _objProduction.planned_date;


                _objProduction.production_shift = _shiftName;

               

                if (_plantName =="" || _plantName == null)
                {
                    _objProduction.production_plant = _plantName;
                }
                else
                {
                    _objProduction.production_plant = _plantName;
                }
                _objProduction.item_thickness = txtThickness.Text;
                _objProduction.sheet_size = txtSheetHeight.Text+"x"+ txtSheetWidth.Text;
                _objProduction.no_of_sheets_issue = Convert.ToInt32( txtNoofSheetIssue.Text == "" ?"0": txtNoofSheetIssue.Text);
                _objProduction.quantity_per_sheet = Convert.ToInt32(txtQuantityPerSheet.Text == "" ? "0" : txtQuantityPerSheet.Text);
                _objProduction.total_expectation = Convert.ToInt32(txttotalExpectation.Text == "" ? "0" : txttotalExpectation.Text);

               // _objProduction.no_of_sheets_issue = Convert.ToInt32( txtNoOfSheetIssuedByAcknowledge.Text == "" ? "0": txtNoOfSheetIssuedByAcknowledge.Text);
                _objProduction.drawing_master_id = Convert.ToInt32( lblSelectedDrawingId.Text);

                
                
                _objProduction.kept_on_floor_item_status = Convert.ToInt32( lblKeptonFloorPcs.Text)==0?false:true;
                _objProduction.kept_on_floor_item_master_id = Convert.ToInt32(lblKeptonFloorItemMasterId.Text==""?"0": lblKeptonFloorItemMasterId.Text);
                _objProduction.kept_on_floor_item_pcs_quantity =  Convert.ToInt32( lblKeptonFloorPcs.Text ==""?"0": lblKeptonFloorPcs.Text);


                //Convert.ToDateTime(_objStaffMaster.staff_joinning_date).ToString("MM/dd/yyyy"); ddlpl.SelectedValue

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objProduction;
        }
        #endregion


        #region Get item DetailFor Add production
        /// <summary>
        /// This Method is Used to Get Staff Details From General Form TextFields to StaffMaster Object
        /// </summary>
        /// <returns></returns>
        //private App.BusinessModel.OnFloorItemMaster GetOnFloorItemsDetailForAdd()
        //{
        //    try
        //    {

        //        _objProduction.production_id = _objProduction.production_id;
        //        _objProduction.guid = _objProduction.guid;

        //        _objProduction.item_master_id = _objProduction.item_master_id;

        //        _objProduction.production_status = App.Helper.Utils.OrderStatus.production.ToString();

        //        _objProduction.batch_status = App.Helper.Utils.OrderStatus.production.ToString();
        //        //_objProduction.production_planning_id = _objProduction.production_planning_id;

        //        _objProduction.started_on = _objProduction.created_on;

        //        _objProduction.planned_date = DateTime.ParseExact(_plannedDate, "dd/MM/yyyy", null);
        //        // _objProduction.planned_date = _objProduction.planned_date;


        //        _objProduction.production_shift = _shiftName;



        //        if (_plantName == "" || _plantName == null)
        //        {
        //            _objProduction.production_plant = _plantName;
        //        }
        //        else
        //        {
        //            _objProduction.production_plant = _plantName;
        //        }
        //        _objProduction.item_thickness = txtThickness.Text;
        //        _objProduction.sheet_size = txtSheetHeight.Text + "x" + txtSheetWidth.Text;

        //        _objProduction.no_of_sheets_issue = Convert.ToInt32(txtNoOfSheetIssuedByAcknowledge.Text == "" ? "0" : txtNoOfSheetIssuedByAcknowledge.Text);
        //        _objProduction.drawing_master_id = Convert.ToInt32(lblSelectedDrawingId.Text);


        //        //Convert.ToDateTime(_objStaffMaster.staff_joinning_date).ToString("MM/dd/yyyy"); ddlpl.SelectedValue

        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Message.ToString();
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
        //    }
        //    return _objProduction;
        //}
        #endregion



        #region Get Items Details for Add according to Department
        #region Get item DetailFor Add ProcessCutting
        /// <summary>
        /// This Method is Used to Get ProcessCutting Details 
        /// </summary>
        /// <returns></returns>
        private ProcessCutting GetProcessCuttingDetailsForAdd()
        {
            try
            {



                _objProcessCutting.item_master_id = _objProduction.item_master_id;

                _objProcessCutting.guid = System.Guid.NewGuid();
                _objProcessCutting.item_brand = _objProduction.item_brand;
                _objProcessCutting.item_model = _objProduction.item_model;
                _objProcessCutting.item_type_name = _objProduction.item_type_name;
                _objProcessCutting.item_glass_color = _objProduction.item_glass_color;
                _objProcessCutting.sale_header_master_id = _objProduction.sale_header_master_id;
                _objProcessCutting.party_master_id = _objProduction.party_master_id;
                _objProcessCutting.batch_number = _objProduction.batch_number;
                _objProcessCutting.production_quantity = _objProduction.production_quantity;

                // Start Broken Text Details from Modal
                _objProcessCutting.broken_sheets_in_crate = Convert.ToInt32(txtBrokenSheetInCreate.Text == "" ? "0" : txtBrokenSheetInCreate.Text); 
                _objProcessCutting.broken_no_of_sheet = Convert.ToInt32(txtNoofSheet.Text == "" ? "0" : txtNoofSheet.Text);
                _objProcessCutting.broken_pcs_cut_from_sheet = Convert.ToInt32(txtPcsCutFromSheet.Text == "" ? "0" : txtPcsCutFromSheet.Text);
                _objProcessCutting.broken_left_over_size = txtLeftOverSizeLength.Text + "x" + txtLeftOverSizeWidth.Text;

                txtLeftOverSizeLength.Text = txtLeftOverSizeLength.Text == "" ? "0" : txtLeftOverSizeLength.Text;
                txtLeftOverSizeWidth.Text = txtLeftOverSizeWidth.Text == "" ? "0" : txtLeftOverSizeWidth.Text;
               


                _objProcessCutting.item_thickness = txtCuttingItemThickness.Text == "" ? "0" : txtCuttingItemThickness.Text;

                string _productionsheetSize = _objProduction.sheet_size;
                
                try
                {
                    string lasttm = _productionsheetSize.TrimEnd('x');

                    arrOfProductionsheetSize = lasttm.Split('x');
                }
                catch
                {

                }


                _objProcessCutting.item_sheet_size = "";
                _objProcessCutting.item_height = "0";
                _objProcessCutting.item_width = "0";
                _objProcessCutting.sheet_size = _objProduction.sheet_size;
                _objProcessCutting.sheet_height = Convert.ToString(arrOfProductionsheetSize[0]);
                _objProcessCutting.sheet_width = Convert.ToString(arrOfProductionsheetSize[1]);
                _objProcessCutting.sheet_issued = Convert.ToInt32(txtNoofSheet.Text == "" ? "0" : txtNoofSheet.Text);
                // _objProcessCutting.sheet_issued = _objProduction.no_of_sheets_issue;
                _objProcessCutting.target_pcs_from_sheet_issued = _objProduction.quantity_per_sheet;

                // Start Broken Text Details from Modal
                _objProcessCutting.total_received = 0;

                _objProcessCutting.total_broken = 0;
                _objProcessCutting.total_reject = 0;
                _objProcessCutting.total_pcs_transferred = 0;
                _objProcessCutting.signature = 0;

                _objProcessCutting.cutting_started_on = System.DateTime.Now;
                _objProcessCutting.cutting_ended_on = System.DateTime.Now;
                _objProcessCutting.cutting_status = App.Helper.Utils.OrderStatus.production.ToString();

                _objProcessCutting.kept_on_floor_item_status = _objProduction.kept_on_floor_item_status;
                _objProcessCutting.kept_on_floor_item_master_id = _objProduction.kept_on_floor_item_master_id;
                _objProcessCutting.kept_on_floor_item_pcs_quantity = _objProduction.kept_on_floor_item_pcs_quantity;
                _objProcessCutting.kept_on_floor_item_pcs_received = 0;


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objProcessCutting;
        }
        #endregion

        #region Get item DetailFor Add ProcessGrinding
        /// <summary>
        /// This Method is Used to Get ProcessGrinding Details
        /// </summary>
        /// <returns></returns>
        private ProcessGrinding GetProcessGrindingDetailsForAdd()
        {
            try
            {

                _objProcessGrinding.item_master_id = _objProduction.item_master_id;
                _objProcessGrinding.guid = System.Guid.NewGuid();
                _objProcessGrinding.item_brand = _objProduction.item_brand;
                _objProcessGrinding.item_model = _objProduction.item_model;
                _objProcessGrinding.item_type_name = _objProduction.item_type_name;
                _objProcessGrinding.item_glass_color = _objProduction.item_glass_color;
                _objProcessGrinding.sale_header_master_id = _objProduction.sale_header_master_id.ToString();
                _objProcessGrinding.party_master_id = _objProduction.party_master_id.ToString();
                _objProcessGrinding.batch_number = _objProduction.batch_number;
                _objProcessGrinding.production_quantity = _objProduction.production_quantity;

                _objProcessGrinding.item_thickness = _objProcessCutting.item_thickness;
                _objProcessGrinding.sheet_issued = _objProcessCutting.sheet_issued;
                _objProcessGrinding.target_pcs_from_sheet_issued = _objProcessCutting.target_pcs_from_sheet_issued;
                _objProcessGrinding.actual_pcs_from_sheet_issued = _objProcessCutting.actual_pcs_from_sheet_issued;
                _objProcessGrinding.draft_size = _objProcessCutting.draft_size;

                _objProcessGrinding.target_pcs_from_draft_size = _objProcessCutting.target_pcs_from_draft_size;
                _objProcessGrinding.actual_pcs_from_draft_size = _objProcessCutting.actual_pcs_from_draft_size;
                _objProcessGrinding.pcs_from_rejection = _objProcessCutting.pcs_from_rejection;
                _objProcessGrinding.actual_pcs_from_rejection = _objProcessCutting.actual_pcs_from_rejection;

                _objProcessGrinding.broken_sheets_in_crate = _objProcessCutting.broken_no_of_sheet;
                _objProcessGrinding.broken_pcs_cut_from_sheet = _objProcessCutting.broken_pcs_cut_from_sheet;
                _objProcessGrinding.broken_left_over_size = _objProcessCutting.broken_left_over_size;




                _objProcessGrinding.total_received = _objProduction.cutting_quantity;





                _objProcessGrinding.total_broken = 0;
                _objProcessGrinding.total_reject = 0;
                _objProcessGrinding.total_pcs_transferred = 0;
                _objProcessGrinding.signature = 0;

                _objProcessGrinding.grinding_started_on = System.DateTime.Now;
                _objProcessGrinding.grinding_ended_on = System.DateTime.Now;
                _objProcessGrinding.grinding_status = App.Helper.Utils.OrderStatus.production.ToString();



            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objProcessGrinding;
        }
        #endregion


        #region Get item DetailFor Add ProcessWashing One
        /// <summary>
        /// This Method is Used to Get ProcessWashing Details
        /// </summary>
        /// <returns></returns>
        private ProcessWashingOne GetProcessWashingOneDetailsForAdd()
        {
            try
            {

                _objProcessWashingOne.item_master_id = _objProduction.item_master_id;
                _objProcessWashingOne.guid = System.Guid.NewGuid();

                _objProcessWashingOne.item_brand = _objProduction.item_brand;
                _objProcessWashingOne.item_model = _objProduction.item_model;
                _objProcessWashingOne.item_glass_color = _objProduction.item_glass_color;
                _objProcessWashingOne.item_type_name = _objProduction.item_type_name;
                _objProcessWashingOne.sale_header_master_id = _objProduction.sale_header_master_id.ToString();
                _objProcessWashingOne.party_master_id = _objProduction.party_master_id.ToString();
                _objProcessWashingOne.batch_number = _objProduction.batch_number;
                _objProcessWashingOne.production_quantity = _objProduction.production_quantity;


                _objProcessWashingOne.item_thickness = _objProcessCutting.item_thickness;
                _objProcessWashingOne.sheet_issued = _objProcessCutting.sheet_issued;
                _objProcessWashingOne.target_pcs_from_sheet_issued = _objProcessCutting.target_pcs_from_sheet_issued;
                _objProcessWashingOne.actual_pcs_from_sheet_issued = _objProcessCutting.actual_pcs_from_sheet_issued;
                _objProcessWashingOne.draft_size = _objProcessCutting.draft_size;

                _objProcessWashingOne.target_pcs_from_draft_size = _objProcessCutting.target_pcs_from_draft_size;
                _objProcessWashingOne.actual_pcs_from_draft_size = _objProcessCutting.actual_pcs_from_draft_size;
                _objProcessWashingOne.pcs_from_rejection = _objProcessCutting.pcs_from_rejection;
                _objProcessWashingOne.actual_pcs_from_rejection = _objProcessCutting.actual_pcs_from_rejection;

                _objProcessWashingOne.broken_sheets_in_crate = _objProcessCutting.broken_no_of_sheet;
                _objProcessWashingOne.broken_pcs_cut_from_sheet = _objProcessCutting.broken_pcs_cut_from_sheet;
                _objProcessWashingOne.broken_left_over_size = _objProcessCutting.broken_left_over_size;



                _objProcessWashingOne.total_received = _objProduction.grinding_quantity;
                //_objProcessWashingOne.total_received = 0;

                _objProcessWashingOne.total_broken = 0;
                _objProcessWashingOne.total_reject = 0;
                _objProcessWashingOne.total_pcs_transferred = 0;
                _objProcessWashingOne.signature = 0;

                _objProcessWashingOne.washing_started_on = System.DateTime.Now;
                _objProcessWashingOne.washing_ended_on = System.DateTime.Now;
                _objProcessWashingOne.washing_one_status = App.Helper.Utils.OrderStatus.production.ToString();



            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objProcessWashingOne;
        }
        #endregion

        #region Get item DetailFor Add ProcessHole
        /// <summary>
        /// This Method is Used to Get ProcessHole Details
        /// </summary>
        /// <returns></returns>
        private ProcessHole GetProcessHoleDetailsForAdd(string _is_WashingOneYesNo)
        {
            try
            {

                _objProcessHole.item_master_id = _objProduction.item_master_id;
                _objProcessHole.guid = System.Guid.NewGuid();

                _objProcessHole.item_brand = _objProduction.item_brand;
                _objProcessHole.item_model = _objProduction.item_model;
                _objProcessHole.item_glass_color = _objProduction.item_glass_color;
                _objProcessHole.item_type_name = _objProduction.item_type_name;
                _objProcessHole.sale_header_master_id = _objProduction.sale_header_master_id.ToString();
                _objProcessHole.party_master_id = _objProduction.party_master_id.ToString();
                _objProcessHole.batch_number = _objProduction.batch_number;
                _objProcessHole.production_quantity = _objProduction.production_quantity;


                _objProcessHole.item_thickness = _objProcessCutting.item_thickness;
                _objProcessHole.sheet_issued = _objProcessCutting.sheet_issued;
                _objProcessHole.target_pcs_from_sheet_issued = _objProcessCutting.target_pcs_from_sheet_issued;
                _objProcessHole.actual_pcs_from_sheet_issued = _objProcessCutting.actual_pcs_from_sheet_issued;
                _objProcessHole.draft_size = _objProcessCutting.draft_size;

                _objProcessHole.target_pcs_from_draft_size = _objProcessCutting.target_pcs_from_draft_size;
                _objProcessHole.actual_pcs_from_draft_size = _objProcessCutting.actual_pcs_from_draft_size;
                _objProcessHole.pcs_from_rejection = _objProcessCutting.pcs_from_rejection;
                _objProcessHole.actual_pcs_from_rejection = _objProcessCutting.actual_pcs_from_rejection;

                _objProcessHole.broken_sheets_in_crate = _objProcessCutting.broken_no_of_sheet;
                _objProcessHole.broken_pcs_cut_from_sheet = _objProcessCutting.broken_pcs_cut_from_sheet;
                _objProcessHole.broken_left_over_size = _objProcessCutting.broken_left_over_size;

                if (_is_WashingOneYesNo == "false")
                {
                    _objProcessHole.total_received = _objProduction.grinding_quantity;

                }
                else
                {
                    _objProcessHole.total_received = _objProduction.washing_one_quantity;
                }

               
                //_objProcessHole.total_received = 0;

                _objProcessHole.total_broken = 0;
                _objProcessHole.total_reject = 0;
                _objProcessHole.total_pcs_transferred = 0;
                _objProcessHole.signature = 0;

                _objProcessHole.hole_started_on = System.DateTime.Now;
                _objProcessHole.hole_ended_on = System.DateTime.Now;
                _objProcessHole.hole_status = App.Helper.Utils.OrderStatus.production.ToString();



            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objProcessHole;
        }
        #endregion

        #region Get item DetailFor Add ProcessWashing
        /// <summary>
        /// This Method is Used to Get ProcessHole Details
        /// </summary>
        /// <returns></returns>
        private ProcessWashing GetProcessWashingDetailsForAdd(string _is_HoleYesNo)
        {
            try
            {
                string _holeStatus = _is_HoleYesNo;
                _objProcessWashing.item_master_id = _objProduction.item_master_id;
                _objProcessWashing.guid = System.Guid.NewGuid();

                _objProcessWashing.item_brand = _objProduction.item_brand;
                _objProcessWashing.item_model = _objProduction.item_model;
                _objProcessWashing.item_type_name = _objProduction.item_type_name;
                _objProcessWashing.item_glass_color = _objProduction.item_glass_color;
                _objProcessWashing.sale_header_master_id = _objProduction.sale_header_master_id.ToString();
                _objProcessWashing.party_master_id = _objProduction.party_master_id.ToString();
                _objProcessWashing.batch_number = _objProduction.batch_number;
                _objProcessWashing.production_quantity = _objProduction.production_quantity;


                _objProcessWashing.item_thickness = _objProcessCutting.item_thickness;
                _objProcessWashing.sheet_issued = _objProcessCutting.sheet_issued;
                _objProcessWashing.target_pcs_from_sheet_issued = _objProcessCutting.target_pcs_from_sheet_issued;
                _objProcessWashing.actual_pcs_from_sheet_issued = _objProcessCutting.actual_pcs_from_sheet_issued;
                _objProcessWashing.draft_size = _objProcessCutting.draft_size;

                _objProcessWashing.target_pcs_from_draft_size = _objProcessCutting.target_pcs_from_draft_size;
                _objProcessWashing.actual_pcs_from_draft_size = _objProcessCutting.actual_pcs_from_draft_size;
                _objProcessWashing.pcs_from_rejection = _objProcessCutting.pcs_from_rejection;
                _objProcessWashing.actual_pcs_from_rejection = _objProcessCutting.actual_pcs_from_rejection;

                _objProcessWashing.broken_sheets_in_crate = _objProcessCutting.broken_no_of_sheet;
                _objProcessWashing.broken_pcs_cut_from_sheet = _objProcessCutting.broken_pcs_cut_from_sheet;
                _objProcessWashing.broken_left_over_size = _objProcessCutting.broken_left_over_size;

                if (_holeStatus =="false")
                {
                    if (_objProduction.washing_one_quantity == 0)
                    {
                        _objProcessWashing.total_received = _objProduction.grinding_quantity;
                    }
                    else
                    {
                        _objProcessWashing.total_received = _objProduction.washing_one_quantity;
                    }
                   
                }
                else
                {
                    _objProcessWashing.total_received = _objProduction.hole_quantity;
                }


               
                //_objProcessWashing.total_received = 0;

                _objProcessWashing.total_broken = 0;
                _objProcessWashing.total_reject = 0;
                _objProcessWashing.total_pcs_transferred = 0;
                _objProcessWashing.signature = 0;

                _objProcessWashing.washing_started_on = System.DateTime.Now;
                _objProcessWashing.washing_ended_on = System.DateTime.Now;
                _objProcessWashing.washing_status = App.Helper.Utils.OrderStatus.production.ToString();


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objProcessWashing;
        }

        protected void btnAddBrokenCrate_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtNoofSheet.Text=="" || txtNoofSheet.Text == null || txtNoofSheet.Text == "0")
                {
                    txtLeftOverSizeLength.Text = txtLeftOverSizeWidth.Text = txtNoOfDraftSheetleftCuttingStart.Text = "0";
                    lblCuttingConfirmError.Visible = true;
                    lblCuttingConfirmError.Text = "No of Sheet Issued Should be greater than Zero(0)";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showBrokenCratetModal();", true);
                    
                }
                else if (txtSheetReceivedInCrate.Text == "" || txtSheetReceivedInCrate.Text == null || txtSheetReceivedInCrate.Text == "0")
                {
                    lblCuttingConfirmError.Visible = true;
                    lblCuttingConfirmError.Text = "No of Sheets Received In Crate Should be greater than Zero(0)";
                    txtLeftOverSizeLength.Text = txtLeftOverSizeWidth.Text = txtNoOfDraftSheetleftCuttingStart.Text = "0";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showBrokenCratetModal();", true);
                    
                }
                else if (Convert.ToInt32(txtSheetReceivedInCrate.Text == "" ? "0" : txtSheetReceivedInCrate.Text) > Convert.ToInt32(txtNoofSheet.Text == "" ? "0" : txtNoofSheet.Text))
                {
                    lblCuttingConfirmError.Visible = true;
                    lblCuttingConfirmError.Text = "Received Sheet Quantity can not be greater than Issued Sheet Quantity";
                    txtLeftOverSizeLength.Text = txtLeftOverSizeWidth.Text = txtNoOfDraftSheetleftCuttingStart.Text = "0";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showBrokenCratetModal();", true);

                }
                else if ( Convert.ToInt32( txtSheetReceivedInCrate.Text =="" ? "0" : txtSheetReceivedInCrate.Text) != Convert.ToInt32(txtNoofSheet.Text =="" ? "0" : txtNoofSheet.Text) - Convert.ToInt32( txtBrokenSheetInCreate.Text == "" ? "0" : txtBrokenSheetInCreate.Text))
                {
                    lblCuttingConfirmError.Visible = true;
                    lblCuttingConfirmError.Text = "Please Enter Broken Sheet Quantity";
                    txtLeftOverSizeLength.Text = txtLeftOverSizeWidth.Text = txtNoOfDraftSheetleftCuttingStart.Text = "0";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showBrokenCratetModal();", true);
                }
                else if (txtSheetReceivedInCrate.Text != txtNoofSheet.Text && Convert.ToInt32(txtBrokenSheetInCreate.Text) > 0 && ddlDraftfromBreakageSheet.SelectedValue == "0")
                {
                    lblCuttingConfirmError.Visible = true;
                    lblCuttingConfirmError.Text = "Please Select Draft Available (Yes) or (No)";
                    txtLeftOverSizeLength.Text = txtLeftOverSizeWidth.Text = txtNoOfDraftSheetleftCuttingStart.Text = "0";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showBrokenCratetModal();", true);
                }
                else if (ddlDraftfromBreakageSheet.SelectedValue == "Yes" && txtNoOfDraftSheetleftCuttingStart.Text=="0"  && txtLeftOverSizeWidth.Text =="0"  && txtNoOfDraftSheetleftCuttingStart.Text =="" && txtLeftOverSizeWidth.Text =="" )
                {

                    
                    lblCuttingConfirmError.Visible = true;
                    lblCuttingConfirmError.Text = "Please Fill Draft Length , Width and No of Sheet Left";
                    txtLeftOverSizeLength.Text = txtLeftOverSizeWidth.Text = txtNoOfDraftSheetleftCuttingStart.Text = "0";
                    divDraftLeftOverStatus.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showBrokenCratetModal();", true);
                }
                else
                {
                    lblCuttingConfirmError.Visible = false;
                    lblCuttingConfirmError.Text = "";

                    _objProductionBL = new ProductionBL();
                    _objProduction= new App.BusinessModel.Production();
                    _objProcessCuttingBL = new ProcessCuttingBL();
                    _objProduction = _objProductionBL.GetAllProductionItems().Where(x => x.production_id == Convert.ToInt32( hdnProductionId.Value)).FirstOrDefault();
                    if (_objProduction != null)
                    {
                        _objProcessCutting = _objProcessCuttingBL.CreateProcessCutting(GetProcessCuttingDetailsForAdd());
                        if (_objProcessCutting != null)
                        {

                            _objProductionBL = new ProductionBL();
                            _objProduction = _objProductionBL.GetAllProductionItems().Where(x => x.item_master_id == _objProcessCutting.item_master_id && x.batch_number == _objProcessCutting.batch_number).FirstOrDefault();
                            if (_objProduction.production_id > 0)
                            {
                                _objProduction.guid = _objProduction.guid;
                                _objProduction.started_on = _objProcessCutting.cutting_started_on;
                                _objProduction.cutting_id = _objProcessCutting.process_cutting_id;
                                _objProduction.cutting_quantity = _objProcessCutting.total_pcs_transferred;
                                //_objProduction.is_under_cutting = true;
                                _objProduction = _objProductionBL.UpdateProduction(_objProduction);
                                if (_objProduction.production_id > 0)
                                {
                                    if (ddlDraftfromBreakageSheet.SelectedValue == "Yes")
                                    {
                                        _objDraftMasterBL = new DraftMasterBL();
                                        try
                                        {

                                            _objDraftMaster.guid = Guid.NewGuid();
                                            _objDraftMaster.production_id = _objProduction.production_id;
                                            _objDraftMaster.batch_number = _objProduction.batch_number;
                                            _objDraftMaster.parent_item_master_id = _objProduction.item_master_id;
                                            _objDraftMaster.items_name = txtLeftOverSizeLength.Text + "x" + txtLeftOverSizeWidth.Text + " " + _objProduction.item_glass_color;
                                            _objDraftMaster.draft_quantity = Convert.ToInt32(txtNoOfDraftSheetleftCuttingStart.Text == "" ? "0" : txtNoOfDraftSheetleftCuttingStart.Text);

                                            if (ddlDraftfromBreakageSheet.SelectedValue == "Yes")
                                            {
                                                _objDraftMaster.left_over_size_availabel = ddlDraftfromBreakageSheet.SelectedValue == "Yes" ? true : false;
                                            }
                                            else if (ddlDraftfromBreakageSheet.SelectedValue == "No")
                                            {
                                                _objDraftMaster.left_over_size_availabel = ddlDraftfromBreakageSheet.SelectedValue == "No" ? false : true;
                                            }
                                            else
                                            {
                                                _objDraftMaster.left_over_size_availabel = false;
                                            }

                                            txtLeftOverSizeLength.Text = txtLeftOverSizeLength.Text == "" ? "0" : txtLeftOverSizeLength.Text;
                                            txtLeftOverSizeWidth.Text = txtLeftOverSizeWidth.Text == "" ? "0" : txtLeftOverSizeWidth.Text;

                                            _objDraftMaster.left_over_size = txtLeftOverSizeLength.Text + "x" + txtLeftOverSizeWidth.Text;
                                            _objDraftMaster.remarks = "";
                                            _objDraftMaster.draft_status = _objDraftMaster.left_over_size_availabel == true ? "available" : "unavailable";

                                            _objDraftMaster = _objDraftMasterBL.CreateDraftMaster(_objDraftMaster);
                                        }
                                        catch (Exception ex)
                                        {
                                            ex.Message.ToString();
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showBrokenCratetModal();", true);
                                            lblCuttingConfirmError.Visible = true;
                                            lblCuttingConfirmError.Text = ex.Message.ToString();
                                        }


                                        if (_objDraftMaster != null)
                                        {
                                            hdnProductionId.Value = "0";
                                            string _production_Id = _objProduction.production_id.ToString();
                                            string _itemMasterId = _objProduction.item_master_id.ToString();
                                            string _processName = "Cutting";
                                            string _heading = "Cutting Started Successfully";
                                            string _heading_class = "text-success";
                                            string _activity = "Item  Cutting  Procces Started ";
                                            string _icon = "fas fa-add";
                                            string _iconClass = "timeline-icon themed-background-emerald themed-border-emerald";
                                            ProductionTrailLogs(_production_Id, _itemMasterId, _processName, _heading, _heading_class, _activity, _icon, _iconClass);

                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingProcessStart();", true);
                                            BindProductionRptr();
                                            txtBrokenSheetInCreate.Text = txtThickness.Text = txtPcsCutFromSheet.Text = txtLeftOverSizeLength.Text = txtLeftOverSizeWidth.Text = "0";
                                        }
                                        else
                                        {
                                            hdnProductionId.Value = "0";
                                            string _production_Id = _objProduction.production_id.ToString();
                                            string _itemMasterId = _objProduction.item_master_id.ToString();
                                            string _processName = "Cutting";
                                            string _heading = "Cutting Started Successfully";
                                            string _heading_class = "text-success";
                                            string _activity = "Item  Cutting  Procces Started ";
                                            string _icon = "fas fa-add";
                                            string _iconClass = "timeline-icon themed-background-emerald themed-border-emerald";
                                            ProductionTrailLogs(_production_Id, _itemMasterId, _processName, _heading, _heading_class, _activity, _icon, _iconClass);

                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingProcessStart();", true);
                                            BindProductionRptr();
                                            txtBrokenSheetInCreate.Text = txtThickness.Text = txtPcsCutFromSheet.Text = txtLeftOverSizeLength.Text = txtLeftOverSizeWidth.Text = "0";
                                        }


                                    }
                                    else
                                    {

                                        if (_objProduction.production_id > 0)
                                        {
                                            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingProcessSuccess();", true);
                                            hdnProductionId.Value = "0";
                                            string _production_Id = _objProduction.production_id.ToString();
                                            string _itemMasterId = _objProduction.item_master_id.ToString();
                                            string _processName = "Cutting";
                                            string _heading = "Cutting Started Successfully";
                                            string _heading_class = "text-success";
                                            string _activity = "Item  Cutting  Procces Started ";
                                            string _icon = "fas fa-add";
                                            string _iconClass = "timeline-icon themed-background-emerald themed-border-emerald";
                                            ProductionTrailLogs(_production_Id, _itemMasterId, _processName, _heading, _heading_class, _activity, _icon, _iconClass);

                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showCuttingProcessStart();", true);
                                            BindProductionRptr();
                                            txtBrokenSheetInCreate.Text = txtThickness.Text = txtPcsCutFromSheet.Text = txtLeftOverSizeLength.Text = txtLeftOverSizeWidth.Text = "0";
                                        }
                                    }
                                }
                                else
                                {

                                }

                               
                                    
                                

                            }


                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showBrokenCratetModal();", true);
                        lblCuttingConfirmError.Visible = true;
                        lblCuttingConfirmError.Text = "Something went wrong , Please Refresh Page and Re-Open This Option";
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showBrokenCratetModal();", true);
                lblCuttingConfirmError.Visible = true;
                lblCuttingConfirmError.Text = ex.Message.ToString();
            }
           
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            txtBrokenSheetInCreate.Text = txtPcsCutFromSheet.Text = txtLeftOverSizeLength.Text = txtLeftOverSizeWidth.Text = txtNoOfDraftSheetleftCuttingStart.Text = "0";
            lblCuttingConfirmError.Visible = false;
            lblCuttingConfirmError.Text = "";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showBrokenCratetModal();", true);
        }

        protected void lnkBtnResetAcknowledge_Click(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                txtNoOfSheetIssuedByAcknowledge.Text = txtSheetHeight.Text = txtSheetWidth.Text = "0";
                txtThickness.Text = "";
                lblSelectedDrawingName.Text = lblSelectedDrawingId.Text = string.Empty;

                lblErrorMessage.Visible = false;
                lblErrorMessage.Text = string.Empty;
                txttotalExpectation.ReadOnly = true;
                //Clear feilds 

            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }
            
        }

        protected void lnkBtnAddAcknowledge_Click(object sender, EventArgs e)
        {
            try
            {
                 if (txtThickness.Text == "0" || txtThickness.Text == "")
                {
                    lblErrorMessage.Visible = true;
                    divselectedDrawing.Visible = true;
                    lblErrorMessage.Text = "Please Fill Thickness Detail";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                    
                }
                else if (txtNoofSheetIssue.Text == "0" || txtNoofSheetIssue.Text == "")
                {
                    lblErrorMessage.Visible = true;
                    divselectedDrawing.Visible = true;
                    lblErrorMessage.Text = "Please Fill No of Sheet Issue";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                    
                }
                else if (txtSheetHeight.Text == "0" || txtSheetHeight.Text == "")
                {
                    lblErrorMessage.Visible = true;
                    divselectedDrawing.Visible = true;
                    lblErrorMessage.Text = "Please Fill Sheet Height";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                    
                }
                else if (txtSheetWidth.Text == "0" || txtSheetWidth.Text == "")
                {
                    lblErrorMessage.Visible = true;
                    divselectedDrawing.Visible = true;
                    lblErrorMessage.Text = "Please Fill Sheet Width";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                    
                }
                else if (txtQuantityPerSheet.Text == "0" || txtQuantityPerSheet.Text == "")
                {
                    lblErrorMessage.Visible = true;
                    divselectedDrawing.Visible = true;
                    lblErrorMessage.Text = "Please Fill Quantity Per Sheet";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                   
                }
                else if (ViewState["Acknowledge"] == null)
                {
                    lblErrorMessage.Visible = true;
                    divselectedDrawing.Visible = true;
                    lblErrorMessage.Text = "Please Add Any Item for Acknowledge";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);

                }
                else if (lblSelectedDrawingId.Text == "0" || lblSelectedDrawingId.Text == "")
                {
                    lblErrorMessage.Visible = true;
                    divselectedDrawing.Visible = true;
                    lblErrorMessage.Text = "Please Select Any Drawing Image";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                    
                }
                else if (ddlLeftoverStatus.SelectedValue =="0" || ddlLeftoverStatus.SelectedValue == "")
                {
                    lblErrorMessage.Visible = true;
                    divselectedDrawing.Visible = true;
                    lblErrorMessage.Text = "Please Select Any Left Over Size Yes/No";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                    
                }
                else if (ddlLeftoverStatus.SelectedValue == "Yes" && txtNoofDraftSheetLeft.Text=="" || txtNoofDraftSheetLeft.Text == "0")
                {
                    lblErrorMessage.Visible = true;
                    divselectedDrawing.Visible = true;
                    lblErrorMessage.Text = "Please Fill Left Draft Sheet Details Height,Width and Quantity";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);

                }
                else
                {
                    lblErrorMessage.Visible = false;
                    lblErrorMessage.Text = string.Empty; 

                    DateTime _plane_Date = DateTime.Parse(_plannedDate, CultureInfo.CreateSpecificCulture("fr-FR"));
                    hdnfAcknowledgeProductionId.Value.ToString();
                    hdnfAcknowledgePlantName.Value.ToString();
                    AddProduction(hdnfAcknowledgeProductionId.Value.ToString(), _plane_Date, hdnfAcknowledgePlantName.Value.ToString());
                }
            }
            catch( Exception ex)
            {
                ex.Message.ToString();
            }
           
        }

        protected void rptrDrawingItemList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string commandname = e.CommandName;
            string id = e.CommandArgument.ToString();

            Int32 ID = Convert.ToInt32(id);
            switch (commandname)
            {
                case "select":
                    try
                    {
                        LinkButton lnkBtnDrawingMasterId = (LinkButton)e.Item.FindControl("lnkBtnDrawingMasterId");
                        Label lblDrawingName = (Label)e.Item.FindControl("lblDrawingName");
                        
                        if (lnkBtnDrawingMasterId.Text == "0" || lnkBtnDrawingMasterId.Text=="")
                        {
                            
                            lblErrorMessage.Visible = true;
                            lblErrorMessage.Text = "Please Select Any Drawing Image";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                        }
                        else
                        {
                            divselectedDrawing.Visible = true;
                            lblSelectedDrawingName.Text = lblDrawingName.Text;
                            lblSelectedDrawingId.Text = lnkBtnDrawingMasterId.Text;
                            lblErrorMessage.Visible = true;
                            lblErrorMessage.Text =string.Empty;

                            BindDrawingItemListrptrV2(hdnfAcknowledgeProductionItemMasterId.Value.ToString());   
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);

                        }
                        // TextBox txtPlannedDate = (TextBox)e.Item.FindControl("txtPlannedDate");

                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        lblErrorMessage.Visible = true;
                        lblErrorMessage.Text = ex.Message.ToString();
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeModal();", true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);

                    }
                    break;
             
                case "view":
                    try
                    {
                       


                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        lblErrorMessage.Visible = true;
                        lblErrorMessage.Text = ex.Message.ToString();
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                    }
                    break;
                
            }

        }

        protected void rptrDrawingItemList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    Label lblpic = (Label)e.Item.FindControl("lblpic");
                   
                    Image lblDrawingImageUrl = (Image)e.Item.FindControl("lblDrawingImageUrl");
                    //HtmlAnchor anchorDrawingImage = (HtmlAnchor)e.Item.FindControl("anchorDrawingImage");

                    Label lblIsSelectStatus = (Label)e.Item.FindControl("lblIsSelectStatus");
                    Label lblStatusClass = (Label)e.Item.FindControl("lblStatusClass");
                    LinkButton btnstatusunselected = (LinkButton)e.Item.FindControl("btnstatusunselected");
                    

                    string url;
                    if (string.IsNullOrEmpty(lblpic.Text))
                    {
                        url = "/Content/img/default-image.jpg";
                    }
                    else
                    {
                        
                        url = "/assets/drawing/" + lblpic.Text;
                    }
                    lblDrawingImageUrl.ImageUrl = url;
                    //anchorDrawingImage.HRef = url;

                    
                    string isstatusactive = lblIsSelectStatus.Text;
                    if (isstatusactive == lblSelectedDrawingId.Text)
                    {
                        lblStatusClass.Visible = true;
                        btnstatusunselected.Visible = false;
                        
                    }
                    else
                    {
                        lblStatusClass.Visible = false;
                        btnstatusunselected.Visible = true;

                    }

                    
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
            }
        }


        #region Create Item Table at Run Time
        /// <summary>
        /// This Method is Used to Create Item Table at Run Time
        /// </summary>
        public void createtableForMoreItem()
        {
            try
            {
                _dataTableItemsList.Columns.Add("item_master_id", typeof(int));
                _dataTableItemsList.Columns.Add("item_name", typeof(string));
                _dataTableItemsList.Columns.Add("item_type", typeof(string));
                _dataTableItemsList.Columns.Add("item_quantity_per_sheet", typeof(int));
                _dataTableItemsList.Columns.Add("item_pcs_total_expectation", typeof(int));

                rptrAcknowledgeItemsList.DataSource = _dataTableItemsList;
                rptrAcknowledgeItemsList.DataBind();
                if (ViewState["Acknowledge"] != null)
                {
                    int _alreadyCount = 0;
                    _dataTableItemsList = (DataTable)ViewState["Acknowledge"];
                   
                    for (int _datatableRowIndexPostion = 0; _datatableRowIndexPostion < _dataTableItemsList.Rows.Count; _datatableRowIndexPostion++)
                    {
                        
                            if (_dataTableItemsList.Rows[_datatableRowIndexPostion]["item_master_id"].ToString() == Convert.ToInt32(ddlItemList.SelectedValue).ToString() && _dataTableItemsList.Rows[_datatableRowIndexPostion]["item_type"].ToString() == ddlItemTypeforSearch.SelectedValue)
                            {
                                _alreadyCount = _alreadyCount + 1;
                            }
                       
                    }

                    if (_alreadyCount == 0)
                    {
                        DataRow _dataRowItemsList = _dataTableItemsList.NewRow();
                        _dataRowItemsList["item_master_id"] = Convert.ToInt32(ddlItemList.SelectedValue);
                        _dataRowItemsList["item_name"] = ddlItemList.SelectedItem.Text;
                        _dataRowItemsList["item_type"] = ddlItemTypeforSearch.SelectedItem.Text;
                        _dataRowItemsList["item_quantity_per_sheet"] = txtItemQuantityPerSheetfromOther.Text;
                        _dataRowItemsList["item_pcs_total_expectation"] = txtTotalExpectationfromOther.Text;
                        _dataTableItemsList.Rows.Add(_dataRowItemsList);
                        _totalItemCount = _totalItemCount + Convert.ToInt32(txtTotalExpectationfromOther.Text);

                        
                        ViewState["Acknowledge"] = _dataTableItemsList;
                        //if (_dataTableItemsList.Rows.Count > 0)
                        //{
                        //    int _totalPiad = 0;
                        //    for (int i = 0; i < _dataTableItemsList.Rows.Count; i++)
                        //    {
                        //        _totalPiad += Convert.ToInt32(_dataTableItemsList.Rows[i]["purchase_item_price"].ToString());
                        //    }

                        //}
                        rptrAcknowledgeItemsList.DataSource = ViewState["Acknowledge"];
                        rptrAcknowledgeItemsList.DataBind();
                        rptrAcknowledgeItemsList.Visible = true;
                        btnShowMoreItemField.Visible = false;
                        txtItemQuantityPerSheetfromOther.Text = txtTotalExpectationfromOther.Text = "0";
                        ddlItemList.SelectedIndex = 0;
                        ddlItemList.SelectedIndex = 0;
                        divselectedDrawing.Visible = false;
                        lblErrorMessage.Visible = false;
                        lblErrorMessage.Text = "";
                        txtNoofDraftSheetavialable.Text = "";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                    }
                    else
                    {
                        ViewState["Acknowledge"] = _dataTableItemsList;
                        rptrAcknowledgeItemsList.DataSource = ViewState["Acknowledge"];
                        rptrAcknowledgeItemsList.DataBind();
                        rptrAcknowledgeItemsList.Visible = true;
                        btnShowMoreItemField.Visible = false;
                        txtItemQuantityPerSheetfromOther.Text = txtTotalExpectationfromOther.Text = "0";
                        ddlItemList.SelectedIndex = 0;
                        divselectedDrawing.Visible = true;
                        lblErrorMessage.Visible = true;
                        txtNoofDraftSheetavialable.Text = "";
                        lblErrorMessage.Text = "You can not Select Item more than One Time";

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                        
                    }

                }
                else
                {
                    DataRow _dataRowItemsList = _dataTableItemsList.NewRow();
                    _dataRowItemsList["item_master_id"] = Convert.ToInt32(ddlItemList.SelectedValue);
                    _dataRowItemsList["item_name"] = ddlItemList.SelectedItem.Text;
                    _dataRowItemsList["item_type"] = ddlItemTypeforSearch.SelectedItem.Text;
                    _dataRowItemsList["item_quantity_per_sheet"] = txtItemQuantityPerSheetfromOther.Text;
                    _dataRowItemsList["item_pcs_total_expectation"] = txtTotalExpectationfromOther.Text;
                    _dataTableItemsList.Rows.Add(_dataRowItemsList);
                    _totalItemCount = _totalItemCount + Convert.ToInt32(txtTotalExpectationfromOther.Text);
                    ViewState["Acknowledge"] = _dataTableItemsList;
                    //if (_dataTableItemsList.Rows.Count > 0)
                    //{
                    //    int _totalPiad = 0;
                    //    for (int i = 0; i < _dataTableItemsList.Rows.Count; i++)
                    //    {
                    //        _totalPiad += Convert.ToInt32(_dataTableItemsList.Rows[i]["purchase_item_price"].ToString());
                    //    }

                    //}
                    rptrAcknowledgeItemsList.DataSource = ViewState["Acknowledge"];
                    rptrAcknowledgeItemsList.DataBind();
                    rptrAcknowledgeItemsList.Visible = true;
                    btnShowMoreItemField.Visible = false;
                    txtItemQuantityPerSheetfromOther.Text = txtTotalExpectationfromOther.Text = "0";
                    ddlItemList.SelectedIndex = 0;
                    divselectedDrawing.Visible = false;
                    lblErrorMessage.Visible = false;
                    lblErrorMessage.Text = "";
                    txtNoofDraftSheetavialable.Text = "";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                }
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
                lblErrorMessage.Text= ex.Message.ToString();
                divselectedDrawing.Visible = true;
                lblErrorMessage.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
            }

        }

        /// <summary>
        /// This Method is Used to Create Table at run Time, Show Data in Repeater Like (ItemName,No of Sheet Isuue, Qty. Per Sheet, etc)
        /// </summary>
        public void createtable()
        {
            try
            {
                _dataTableItemsList.Columns.Add("item_master_id", typeof(int));
                _dataTableItemsList.Columns.Add("item_name", typeof(string));
                _dataTableItemsList.Columns.Add("item_type", typeof(string));
                _dataTableItemsList.Columns.Add("item_quantity_per_sheet", typeof(int));
                _dataTableItemsList.Columns.Add("item_pcs_total_expectation", typeof(int));

                rptrAcknowledgeItemsList.DataSource = _dataTableItemsList;
                rptrAcknowledgeItemsList.DataBind();
                if (ViewState["Acknowledge"] != null)
                {
                    int _alreadyCount = 0;
                    _dataTableItemsList = (DataTable)ViewState["Acknowledge"];

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

                        _dataRowItemsList["item_master_id"] = Convert.ToInt32(hdnfAcknowledgeProductionItemMasterId.Value);
                        _dataRowItemsList["item_name"] = txtItemName.Text;
                        _dataRowItemsList["item_type"] = "Item";
                        _dataRowItemsList["item_quantity_per_sheet"] = txtQuantityPerSheet.Text;
                        _dataRowItemsList["item_pcs_total_expectation"] = txttotalExpectation.Text;
                        _dataTableItemsList.Rows.Add(_dataRowItemsList);
                        _totalItemCount = _totalItemCount + Convert.ToInt32(txttotalExpectation.Text);
                        ViewState["Acknowledge"] = _dataTableItemsList;
                        //if (_dataTableItemsList.Rows.Count > 0)
                        //{
                        //    int _totalPiad = 0;
                        //    for (int i = 0; i < _dataTableItemsList.Rows.Count; i++)
                        //    {
                        //        _totalPiad += Convert.ToInt32(_dataTableItemsList.Rows[i]["purchase_item_price"].ToString());
                        //    }

                        //}
                        rptrAcknowledgeItemsList.DataSource = ViewState["Acknowledge"];
                        rptrAcknowledgeItemsList.DataBind();
                        rptrAcknowledgeItemsList.Visible = true;
                        btnShowMoreItemField.Visible = true;
                        txtThickness.ReadOnly = txtQuantityPerSheet.ReadOnly = txtNoofSheet.ReadOnly = txtSheetHeight.ReadOnly = txtSheetWidth.ReadOnly = true;
                        ddlItemList.SelectedIndex = 0;
                        divselectedDrawing.Visible = false;
                        lblErrorMessage.Visible = false;
                        lblErrorMessage.Text = "";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                    }
                    else
                    {
                        ViewState["Acknowledge"] = _dataTableItemsList;
                        rptrAcknowledgeItemsList.DataSource = ViewState["Acknowledge"];
                        rptrAcknowledgeItemsList.DataBind();
                        rptrAcknowledgeItemsList.Visible = true;
                        btnShowMoreItemField.Visible = true;
                        ddlItemList.SelectedIndex = 0;
                        divselectedDrawing.Visible = true;
                        lblErrorMessage.Visible = true;
                        lblErrorMessage.Text = "You can not Select Item more than One Time";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                        
                    }

                }
                else
                {
                    DataRow _dataRowItemsList = _dataTableItemsList.NewRow();
                    _dataRowItemsList["item_master_id"] = Convert.ToInt32(hdnfAcknowledgeProductionItemMasterId.Value);
                    _dataRowItemsList["item_name"] = txtItemName.Text;
                    _dataRowItemsList["item_type"] = "Item";
                    _dataRowItemsList["item_quantity_per_sheet"] = txtQuantityPerSheet.Text;
                    _dataRowItemsList["item_pcs_total_expectation"] = txttotalExpectation.Text;
                    _dataTableItemsList.Rows.Add(_dataRowItemsList);
                    _totalItemCount = _totalItemCount + Convert.ToInt32(txttotalExpectation.Text);
                    ViewState["Acknowledge"] = _dataTableItemsList;
                    //if (_dataTableItemsList.Rows.Count > 0)
                    //{
                    //    int _totalPiad = 0;
                    //    for (int i = 0; i < _dataTableItemsList.Rows.Count; i++)
                    //    {
                    //        _totalPiad += Convert.ToInt32(_dataTableItemsList.Rows[i]["purchase_item_price"].ToString());
                    //    }

                    //}
                    rptrAcknowledgeItemsList.DataSource = ViewState["Acknowledge"];
                    rptrAcknowledgeItemsList.DataBind();
                    rptrAcknowledgeItemsList.Visible = true;
                    btnShowMoreItemField.Visible = true;
                    txtThickness.ReadOnly = txtQuantityPerSheet.ReadOnly = txtNoofSheetIssue.ReadOnly = txtSheetHeight.ReadOnly = txtSheetWidth.ReadOnly = true;
                    ddlItemList.SelectedIndex = 0;
                    divselectedDrawing.Visible = false;
                    lblErrorMessage.Visible = false;
                    lblErrorMessage.Text = "";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                }
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
                lblErrorMessage.Text = ex.Message.ToString();
                divselectedDrawing.Visible = true;
                lblErrorMessage.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
            }
           

        }

        /// <summary>
        /// This Method is Used to Delete Item from Table at Run Time
        /// </summary>
        public void deleteRowfromtable(int _itemIdForRemove, string _itemType)
        {
            try
            {
                // Get  Repeater Values From View to Data Table
                _dataTableItemsList.Columns.Add("item_master_id", typeof(int));
                _dataTableItemsList.Columns.Add("item_name", typeof(string));
                _dataTableItemsList.Columns.Add("item_type", typeof(string));
                _dataTableItemsList.Columns.Add("item_quantity_per_sheet", typeof(int));
                _dataTableItemsList.Columns.Add("item_pcs_total_expectation", typeof(int));

                rptrAcknowledgeItemsList.DataSource = _dataTableItemsList;
                rptrAcknowledgeItemsList.DataBind();

                _dataTableItemsList = (DataTable)ViewState["Acknowledge"];

                // Create New DataTable and Columns At Run Time
                DataTable _dataTableItemsListRemove = new DataTable();
                _dataTableItemsListRemove.Columns.Add("item_master_id", typeof(int));
                _dataTableItemsListRemove.Columns.Add("item_name", typeof(string));
                _dataTableItemsListRemove.Columns.Add("item_type", typeof(string));
                _dataTableItemsListRemove.Columns.Add("item_quantity_per_sheet", typeof(int));
                _dataTableItemsListRemove.Columns.Add("item_pcs_total_expectation", typeof(int));


                // Assing Datable Items To Another DataTable and Skip Selected Item  for Remove/Delete

                for (int _datatableRowIndexPostion = 0; _datatableRowIndexPostion < _dataTableItemsList.Rows.Count; _datatableRowIndexPostion++)
                {
                    if (_dataTableItemsList.Rows[_datatableRowIndexPostion]["item_master_id"].ToString() == Convert.ToInt32(_itemIdForRemove).ToString() && _dataTableItemsList.Rows[_datatableRowIndexPostion]["item_type"].ToString() == _itemType)
                    {
                        _totalItemCount = _totalItemCount - Convert.ToInt32(_dataTableItemsList.Rows[_datatableRowIndexPostion]["item_pcs_total_expectation"]);
                    }
                    else
                    {
                        DataRow _dataRowItemsListRemove = _dataTableItemsListRemove.NewRow();


                        _dataRowItemsListRemove["item_master_id"] = Convert.ToInt32(_dataTableItemsList.Rows[_datatableRowIndexPostion]["item_master_id"]);
                        _dataRowItemsListRemove["item_name"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["item_name"];
                        _dataRowItemsListRemove["item_type"] = _dataTableItemsList.Rows[_datatableRowIndexPostion]["item_type"];
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

                }

                if (_dataTableItemsListRemove.Rows.Count > 0)
                {
                    ViewState["Acknowledge"] = _dataTableItemsListRemove;
                    rptrAcknowledgeItemsList.DataSource = ViewState["Acknowledge"];
                    rptrAcknowledgeItemsList.DataBind();
                    rptrAcknowledgeItemsList.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);

                }
                else
                {

                    ViewState["Acknowledge"] = _dataTableItemsListRemove;
                    rptrAcknowledgeItemsList.DataSource = ViewState["Acknowledge"];
                    rptrAcknowledgeItemsList.DataBind();
                    rptrAcknowledgeItemsList.Visible = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);

                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                lblErrorMessage.Text = ex.Message.ToString();
                divselectedDrawing.Visible = true;
                lblErrorMessage.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
            }

        }

        #endregion

        protected void rptrAcknowledgeItemsList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
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
                            lblErrorMessage.Text = ex.Message.ToString();
                            lblErrorMessage.Visible = true;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);

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
                            lblErrorMessage.Text= ex.Message.ToString();
                            lblErrorMessage.Visible = true;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                        }
                        break;
                    case "delete":
                        try
                        {
                            
                            if(hdfditemId.Value== hdnfAcknowledgeProductionItemMasterId.Value)
                            {
                                lblErrorMessage.Visible = true;
                                divselectedDrawing.Visible = true;
                                lblErrorMessage.Text = "Primary Item Can not be Deleted";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);

                            }
                            else
                            {
                                Label lblItemType = (Label)e.Item.FindControl("lblItemType");
                                if (lblItemType.Text =="" && lblItemType.Text==null)
                                {
                                    lblErrorMessage.Visible = true;
                                    lblErrorMessage.Text = "Some thing went Wrong";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                                }
                                else
                                {
                                    string _selectedItemType = lblItemType.Text;
                                    lblErrorMessage.Visible = false;
                                    deleteRowfromtable(Convert.ToInt32(hdfditemId.Value), _selectedItemType);
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                                }

                               
                            }
                            
                        }
                        catch (Exception ex)
                        {
                            ex.Message.ToString();
                            lblErrorMessage.Text = ex.Message.ToString();
                            lblErrorMessage.Visible = true;
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                           // ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                        }
                        break;

                }

            }
            catch ( Exception ex)
            {
                lblErrorMessage.Text = ex.Message.ToString();
                lblErrorMessage.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
            }

          

        }

        protected void rptrAcknowledgeItemsList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {

                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                 
                    Label lblItemType = (Label)e.Item.FindControl("lblItemType");
                    Label lblDisplayItemNameforDraft = (Label)e.Item.FindControl("lblDisplayItemNameforDraft");

                    if (lblItemType.Text == "Draft")
                    {

                        lblDisplayItemNameforDraft.Text = txtItemName.Text;
                        lblDisplayItemNameforDraft.Visible = true;
                    }
                    else
                    {
                        lblDisplayItemNameforDraft.Text = "";
                        lblDisplayItemNameforDraft.Visible = false;

                    }
                    
                }
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
                if (txtThickness.Text == "0" || txtThickness.Text == "")
                {
                    divselectedDrawing.Visible =  lblErrorMessage.Visible = true;
                    lblErrorMessage.Text = "Please Fill Thickness Detail";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                   
                }
                else if (txtNoofSheetIssue.Text == "0" || txtNoofSheetIssue.Text == "")
                {
                    divselectedDrawing.Visible =  lblErrorMessage.Visible = true;
                    lblErrorMessage.Text = "Please Fill No of Sheet Issue";
                    txtNoofSheetIssue.ReadOnly = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                   
                }
                else if (txtSheetHeight.Text == "0" || txtSheetHeight.Text == "")
                {
                    divselectedDrawing.Visible = lblErrorMessage.Visible = true;
                    lblErrorMessage.Text = "Please Fill Sheet Height";
                    txtSheetHeight.ReadOnly = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                   
                }
                else if (txtSheetWidth.Text == "0" || txtSheetWidth.Text == "")
                {
                    divselectedDrawing.Visible =  lblErrorMessage.Visible = true;
                    lblErrorMessage.Text = "Please Fill Sheet Width";
                    txtSheetWidth.ReadOnly = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                  
                }
                else if (txtQuantityPerSheet.Text == "0" || txtQuantityPerSheet.Text == "")
                {
                    divselectedDrawing.Visible = lblErrorMessage.Visible = true;
                    lblErrorMessage.Text = "Please Fill Quantity Per Sheet";
                    txtQuantityPerSheet.ReadOnly = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                  
                }
                else if (txttotalExpectation.Text == "0" || txttotalExpectation.Text == "")
                {
                    divselectedDrawing.Visible =  lblErrorMessage.Visible = true;
                    lblErrorMessage.Text = "Please Fill Detail Proper of No of Sheet Issue and Quantity Per Sheet";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                   
                }
                else
                {
                    divselectedDrawing.Visible = lblErrorMessage.Visible = btnAddItem.Visible = false;
                    lblErrorMessage.Text = "";
                    createtable();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                }
                

            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message.ToString();
                divselectedDrawing.Visible = lblErrorMessage.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
            }
        }

        protected void btnShowMoreItemField_Click(object sender, EventArgs e)
        {
            try
            {
                btnAddItem.Visible = btnShowMoreItemField.Visible = false;
                divMoreItemAdd.Visible = true;
                txtItemQuantityPerSheetfromOther.Text =  txtTotalExpectationfromOther.Text = "0";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message.ToString();
                divselectedDrawing.Visible =  lblErrorMessage.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
            }
        }

        protected void btnAddMoreItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlItemTypeforSearch.SelectedValue == "0")
                {
                    divselectedDrawing.Visible = lblErrorMessage.Visible = true;
                    lblErrorMessage.Text = "Please Select Search Type";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                }
                else if(ddlItemList.SelectedValue =="0")
                {
                    divselectedDrawing.Visible =  lblErrorMessage.Visible = true;
                    lblErrorMessage.Text = "Please Select Any Item/Draft";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                }
                else if (txtItemQuantityPerSheetfromOther.Text == "0" || txtItemQuantityPerSheetfromOther.Text == "" )
                {
                    divselectedDrawing.Visible =  lblErrorMessage.Visible = true;
                    lblErrorMessage.Text = "Please Fill Item Quantity Per Sheet";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                }
                else if (txtTotalExpectationfromOther.Text == "0" || txtTotalExpectationfromOther.Text == "")
                {
                    divselectedDrawing.Visible = lblErrorMessage.Visible = true;
                    lblErrorMessage.Text = "Total Expectation should be greater than Zero (0)";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                }
                else
                {
                    divselectedDrawing.Visible =  lblErrorMessage.Visible = false;
                    lblErrorMessage.Text = "";
                    createtableForMoreItem();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                }

            }
            catch(Exception ex)
            {
                
                lblErrorMessage.Text = ex.Message.ToString();
                divselectedDrawing.Visible  = lblErrorMessage.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
            }
            
        }

        protected void ddlItemTypeforSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlItemTypeforSearch.SelectedValue== "Item")
                {
                    divselectedDrawing.Visible =  lblErrorMessage.Visible = false;
                    lblErrorMessage.Text = "";
                    BindItemsName(txtThickness.Text);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);

                }
                else if (ddlItemTypeforSearch.SelectedValue == "Draft")
                {
                    divselectedDrawing.Visible = lblErrorMessage.Visible = false;
                    lblErrorMessage.Text = "";
                    BindDraftItemsName();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                }
                else
                {
                    divselectedDrawing.Visible =  lblErrorMessage.Visible = true;
                    lblErrorMessage.Text = "Please Select Any Search Type";
                    ddlItemList.Items.Clear();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                }
            }
            catch(Exception ex)
            {
              
                lblErrorMessage.Text = ex.Message.ToString();
                divselectedDrawing.Visible =  lblErrorMessage.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);

            }
        }

        protected void txtNoofSheetIssue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtNoofSheetIssue.Text == "0" || txtNoofSheetIssue.Text == "" || txtNoofSheetIssue.Text == null)
                {
                    txtNoofSheetIssue.Text = "0";
                    lblErrorMessage.Text = "Issue Sheet Quantity Should be greater than Zero (0)";
                    divselectedDrawing.Visible =  lblErrorMessage.Visible = true;
                    txtNoofSheetIssue.Focus();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                }
                else
                {
                    int _noOfSheetIssue, _quantityPerSheet, _totalExpectation = 0;
                    if (txtNoofSheetIssue.Text == null || txtNoofSheetIssue.Text == "")
                    {
                        txtNoofSheetIssue.Text = "0";
                    }
                    if (txtQuantityPerSheet.Text == null || txtQuantityPerSheet.Text == "")
                    {
                        txtQuantityPerSheet.Text = "0";
                    }
                    if (txttotalExpectation.Text == null || txttotalExpectation.Text == "")
                    {
                        txttotalExpectation.Text = "0";
                    }


                    _noOfSheetIssue = Convert.ToInt32(txtNoofSheetIssue.Text);
                    _quantityPerSheet = Convert.ToInt32(txtQuantityPerSheet.Text);
                    _totalExpectation = Convert.ToInt32(txttotalExpectation.Text);

                    _totalExpectation = (_noOfSheetIssue * _quantityPerSheet);
                    txttotalExpectation.Text = _totalExpectation.ToString();
                    txttotalExpectation.ReadOnly = true;
                    lblErrorMessage.Text = "";
                    lblErrorMessage.Visible =  divselectedDrawing.Visible = false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);

                }
            }
            catch(Exception ex)
            {
                
                lblErrorMessage.Text = ex.Message.ToString();
                divselectedDrawing.Visible =  lblErrorMessage.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
            }
           
        }

        protected void txtQuantityPerSheet_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtQuantityPerSheet.Text == "0" || txtQuantityPerSheet.Text == "" || txtQuantityPerSheet.Text == null)
                {
                    txtQuantityPerSheet.Text = "0";
                    lblErrorMessage.Text = "Quantity Per Sheet Should be greater than Zero (0)";
                    divselectedDrawing.Visible = true;
                    lblErrorMessage.Visible = true;
                    txtQuantityPerSheet.Focus();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                }
                else
                {
                    int _noOfSheetIssue, _quantityPerSheet, _totalExpectation = 0;
                    if (txtNoofSheetIssue.Text == null  || txtNoofSheetIssue.Text == "")
                    {
                        txtNoofSheetIssue.Text = "0";
                    }
                    if (txtQuantityPerSheet.Text == null || txtQuantityPerSheet.Text == "")
                    {
                        txtQuantityPerSheet.Text = "0";
                    }
                    if (txttotalExpectation.Text == null || txttotalExpectation.Text == "")
                    {
                        txttotalExpectation.Text = "0";
                    }


                    _noOfSheetIssue = Convert.ToInt32(txtNoofSheetIssue.Text);
                    _quantityPerSheet = Convert.ToInt32(txtQuantityPerSheet.Text);
                    _totalExpectation = Convert.ToInt32(txttotalExpectation.Text);

                    _totalExpectation = (_noOfSheetIssue * _quantityPerSheet);
                    txttotalExpectation.Text = _totalExpectation.ToString();
                    txttotalExpectation.ReadOnly = true;
                    divselectedDrawing.Visible = lblErrorMessage.Visible = false;
                    lblErrorMessage.Text = "";
                    
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);

                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                lblErrorMessage.Text = ex.Message.ToString();
                divselectedDrawing.Visible = lblErrorMessage.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
            }

           

        }

        protected void txtItemQuantityPerSheetfromOther_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlItemTypeforSearch.SelectedValue == "Item")
                {
                    if (txtItemQuantityPerSheetfromOther.Text == "0" || txtItemQuantityPerSheetfromOther.Text == "" || txtItemQuantityPerSheetfromOther.Text == null)
                    {
                        txtItemQuantityPerSheetfromOther.Text = "0";
                        lblErrorMessage.Text = "Quantity Per Sheet Should be greater than Zero (0)";
                        txtItemQuantityPerSheetfromOther.Focus();
                        divselectedDrawing.Visible = lblErrorMessage.Visible = true;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                    }
                    else
                    {
                        int _noOfSheetIssue, _quantityPerSheetFromOther, _totalExpectationfromOther = 0;
                        if (txtNoofSheetIssue.Text == null || txtNoofSheetIssue.Text == "")
                        {
                            txtNoofSheetIssue.Text = "0";
                        }
                        if (txtItemQuantityPerSheetfromOther.Text == null || txtItemQuantityPerSheetfromOther.Text == "")
                        {
                            txtItemQuantityPerSheetfromOther.Text = "0";
                        }
                        if (txtTotalExpectationfromOther.Text == null || txtTotalExpectationfromOther.Text == "")
                        {
                            txtTotalExpectationfromOther.Text = "0";
                        }


                        _noOfSheetIssue = Convert.ToInt32(txtNoofSheetIssue.Text);
                        _quantityPerSheetFromOther = Convert.ToInt32(txtItemQuantityPerSheetfromOther.Text);
                        _totalExpectationfromOther = Convert.ToInt32(txtTotalExpectationfromOther.Text);

                        _totalExpectationfromOther = (_noOfSheetIssue * _quantityPerSheetFromOther);
                        txtTotalExpectationfromOther.Text = _totalExpectationfromOther.ToString();
                        txtTotalExpectationfromOther.ReadOnly = true;
                        divselectedDrawing.Visible = false;
                        lblErrorMessage.Text = "";
                        lblErrorMessage.Visible = false;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);

                    }
                }
                else if (ddlItemTypeforSearch.SelectedValue == "Draft")
                {
                    if (txtItemQuantityPerSheetfromOther.Text == "0" || txtItemQuantityPerSheetfromOther.Text == "" || txtItemQuantityPerSheetfromOther.Text == null)
                    {
                        txtItemQuantityPerSheetfromOther.Text = "0";
                        lblErrorMessage.Text = "Quantity Per Sheet Should be greater than Zero (0)";
                        txtItemQuantityPerSheetfromOther.Focus();
                        divselectedDrawing.Visible = lblErrorMessage.Visible = true;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                    }
                    else
                    {   
                        if (txtTotalExpectationfromOther.Text == null || txtTotalExpectationfromOther.Text == "")
                        {
                            txtTotalExpectationfromOther.Text = "0";
                        }
                        if (txtNoofDraftSheetavialable.Text == null || txtNoofDraftSheetavialable.Text == "")
                        {
                            txtNoofDraftSheetavialable.Text = "0";
                        }


                        txtTotalExpectationfromOther.Text = (Convert.ToInt32(txtNoofDraftSheetavialable.Text) * Convert.ToInt32(txtItemQuantityPerSheetfromOther.Text)).ToString();
                        txtTotalExpectationfromOther.ReadOnly = true;
                        divselectedDrawing.Visible = lblErrorMessage.Visible = false;
                        lblErrorMessage.Text = "";
                        
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);

                    }
                }
                else
                {
                    lblErrorMessage.Text = "Please Fill Details Proper";
                    divselectedDrawing.Visible = lblErrorMessage.Visible = true;

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                }

               

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                lblErrorMessage.Text = ex.Message.ToString();
                divselectedDrawing.Visible = true;
                lblErrorMessage.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
            }
        }

        protected void txtSheetReceivedInCrate_TextChanged(object sender, EventArgs e)
        {

            txtBrokenSheetInCreate.Text = txtPcsCutFromSheet.Text = "0";

            if (txtNoofSheet.Text == "0" || txtNoofSheet.Text == "" || txtNoofSheet.Text==null)
            {
                txtNoofSheet.Text = "0";
                txtNoofSheet.Focus();
                txtBrokenSheetInCreate.ReadOnly = txtPcsCutFromSheet.ReadOnly = txtLeftOverSizeLength.ReadOnly = txtLeftOverSizeWidth.ReadOnly = true;
                lblCuttingConfirmError.Visible = false;
                txtLeftOverSizeLength.Text =  txtLeftOverSizeWidth.Text =  txtNoOfDraftSheetleftCuttingStart.Text = "0";
                divDraftLeftOverStatus.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showBrokenCratetModal();", true);
                
            }
            else if (txtSheetReceivedInCrate.Text == "0" || txtSheetReceivedInCrate.Text == "" || txtSheetReceivedInCrate.Text == null)
            {
                txtSheetReceivedInCrate.Text = "0";
                txtSheetReceivedInCrate.Focus();
                txtBrokenSheetInCreate.ReadOnly = txtPcsCutFromSheet.ReadOnly = txtLeftOverSizeLength.ReadOnly = txtLeftOverSizeWidth.ReadOnly = true;
                lblCuttingConfirmError.Visible = true;
                lblCuttingConfirmError.Text = "Please Fill OK Sheet Received in Crate";
                txtLeftOverSizeLength.Text = txtLeftOverSizeWidth.Text =  txtNoOfDraftSheetleftCuttingStart.Text = "0";
                divDraftLeftOverStatus.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showBrokenCratetModal();", true);
                
            }
            else if (Convert.ToInt32(txtSheetReceivedInCrate.Text == "" ? "0" : txtSheetReceivedInCrate.Text) == Convert.ToInt32(txtNoofSheet.Text == "" ? "0" : txtNoofSheet.Text))
            {
                txtBrokenSheetInCreate.ReadOnly = txtPcsCutFromSheet.ReadOnly = txtLeftOverSizeLength.ReadOnly = txtLeftOverSizeWidth.ReadOnly = true;
                lblCuttingConfirmError.Visible = false;
                lblCuttingConfirmError.Text = "";
                txtLeftOverSizeLength.Text = txtLeftOverSizeWidth.Text = txtPcsCutFromSheet.Text = txtNoOfDraftSheetleftCuttingStart.Text = "0";
                divDraftLeftOverStatus.Visible = false;
                ddlDraftfromBreakageSheet.SelectedValue = "No";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showBrokenCratetModal();", true);
                

            }
            else  if (Convert.ToInt32( txtSheetReceivedInCrate.Text ==""?"0": txtSheetReceivedInCrate.Text) < Convert.ToInt32(txtNoofSheet.Text == ""?"0": txtNoofSheet.Text))
            {
                txtSheetReceivedInCrate.Focus();
                txtBrokenSheetInCreate.ReadOnly = txtPcsCutFromSheet.ReadOnly = txtLeftOverSizeLength.ReadOnly = txtLeftOverSizeWidth.ReadOnly = false;
                lblCuttingConfirmError.Visible = true;
                lblCuttingConfirmError.Text = "";
                txtLeftOverSizeLength.Text =  txtLeftOverSizeWidth.Text =  txtNoOfDraftSheetleftCuttingStart.Text = "0";
                divDraftLeftOverStatus.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showBrokenCratetModal();", true);
                
            }
            else if (Convert.ToInt32(txtSheetReceivedInCrate.Text == "" ? "0" : txtSheetReceivedInCrate.Text) > Convert.ToInt32(txtNoofSheet.Text == "" ? "0" : txtNoofSheet.Text))
            {
                txtSheetReceivedInCrate.Focus();
                txtBrokenSheetInCreate.ReadOnly = txtPcsCutFromSheet.ReadOnly = txtLeftOverSizeLength.ReadOnly = txtLeftOverSizeWidth.ReadOnly = true;
                lblCuttingConfirmError.Visible = true;
                lblCuttingConfirmError.Text = "You Can not entered value more than Sheet Issued";
                txtLeftOverSizeLength.Text = txtLeftOverSizeWidth.Text = txtNoOfDraftSheetleftCuttingStart.Text = "0";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showBrokenCratetModal();", true);
                divDraftLeftOverStatus.Visible = true;

            }
            
            else
            {

            }
        }

        protected void rptrOnFloorOtherItemsList_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void rptrOnFloorOtherItemsList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {

                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    Label lblOnFloorItemType = (Label)e.Item.FindControl("lblOnFloorItemType");
                    Label lblDisplayItemNameforDraftInCutting = (Label)e.Item.FindControl("lblDisplayItemNameforDraftInCutting");

                    if (lblOnFloorItemType.Text == "Draft")
                    {

                        lblDisplayItemNameforDraftInCutting.Text = txtCuttingItemNameWithColor.Text;
                        lblDisplayItemNameforDraftInCutting.Visible = true;
                    }
                    else
                    {
                        lblDisplayItemNameforDraftInCutting.Text = "";
                        lblDisplayItemNameforDraftInCutting.Visible = false;

                    }

                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        protected void ddlSearchByPlant_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (ddlSearchByPlant.SelectedValue == "All")
            {
                BindProductionRptr();
            }
            else
            {
                string _selectPlantName = ddlSearchByPlant.SelectedValue.ToString();
                BindProductionRptrBySelectPlant(_selectPlantName);
            }
        }

        protected void txtNoofDraftSheetavialable_TextChanged(object sender, EventArgs e)
        {

            if(txtNoofDraftSheetavialable.Text=="" && txtNoofDraftSheetavialable.Text == null)
            {
                txtNoofDraftSheetavialable.Text = "0";
                txtNoofDraftSheetavialable.Focus();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
            }
            else
            {
                txtItemQuantityPerSheetfromOther.Text = txtTotalExpectationfromOther.Text = "0";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
            }
        }

        protected void ddlItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlItemList.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                }
                else
                {

                    if (ddlItemTypeforSearch.SelectedValue == "Draft")
                    {
                        string _ItemHeightWidth = ddlItemList.SelectedItem.Text;

                        try
                        {
                            string lasttm = _ItemHeightWidth.TrimEnd('x');

                            arrOfItemHeightWidth = lasttm.Split('x');

                            string sublasttm = arrOfItemHeightWidth[1].TrimEnd(' ');

                            string[] subarrOfItemHeightWidth = sublasttm.Split(' ');

                            decimal _itemSqm = (Convert.ToDecimal(arrOfItemHeightWidth[0]) * Convert.ToDecimal(subarrOfItemHeightWidth[0]) / 1000000);
                            txtDraftItemSQM.Text = _itemSqm.ToString();

                            //Get Value from Drfat List to Selected Item

                            _objDraftMasterBL = new DraftMasterBL();
                            _lstDraftMaster = _objDraftMasterBL.GetAllDraftMasterItems().Where(x => x.draft_status == "available").OrderBy(x => x.draft_master_id).ToList();
                            if (_lstDraftMaster !=null)
                            {
                                _objDraftMaster = _lstDraftMaster.Where(x => x.draft_master_id == Convert.ToInt32(ddlItemList.SelectedValue)).FirstOrDefault();
                                txtNoofDraftSheetavialable.Text = _objDraftMaster.draft_quantity.ToString();
                                txtNoofDraftSheetavialable.ReadOnly = false;
                            }
                            else
                            {
                                txtNoofDraftSheetavialable.ReadOnly = true;
                                txtNoofDraftSheetavialable.Text = "0";
                            }
                            

                            //ENd


                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                        }
                        catch
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                        }

                    }
                    else if (ddlItemTypeforSearch.SelectedValue == "Item")
                    {
                        txtNoofDraftSheetavialable.ReadOnly = true;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
                    }
                    

                }
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemAcknowledgeNewModal();", true);
            }
            

        }

        protected void txtBrokenSheetInCreate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblCuttingConfirmError.Visible = false;
                lblCuttingConfirmError.Text = "";
                txtBrokenSheetInCreate.Text = txtBrokenSheetInCreate.Text == "" ? "0" : txtBrokenSheetInCreate.Text;

                
                if(Convert.ToInt32(txtBrokenSheetInCreate.Text == "" ? "0" : txtBrokenSheetInCreate.Text) > Convert.ToInt32(txtNoofSheet.Text == "" ? "0" : txtNoofSheet.Text))
                {
                    txtBrokenSheetInCreate.Focus();
                    lblCuttingConfirmError.Visible = true;
                    lblCuttingConfirmError.Text = "Please entered BrokenSheet value ";

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showBrokenCratetModal();", true);
                }

                if (Convert.ToInt32(txtNoofSheet.Text) != (Convert.ToInt32(txtBrokenSheetInCreate.Text) + Convert.ToInt32( txtSheetReceivedInCrate.Text)))
                {
                    txtBrokenSheetInCreate.Focus();
                    lblCuttingConfirmError.Visible = true;
                    lblCuttingConfirmError.Text = "please entered valid value";

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showBrokenCratetModal();", true);
                }

                else
                {
                    lblCuttingConfirmError.Visible = false;
                    lblCuttingConfirmError.Text = "";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showBrokenCratetModal();", true);
                }
            }
            catch(Exception ex)
            {
                lblCuttingConfirmError.Visible = true;
                lblCuttingConfirmError.Text = ex.Message.ToString();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showBrokenCratetModal();", true);
            }
        }
        #endregion

        #region Get item DetailFor Add ProcessPaint
        /// <summary>
        /// This Method is Used to Get ProcessPaint Details
        /// </summary>
        /// <returns></returns>
        private ProcessPaint GetProcessPaintDetailsForAdd( string IsWashingYesNo)
        {
            try
            {

                _objProcessPaint.item_master_id = _objProduction.item_master_id;
                _objProcessPaint.guid = System.Guid.NewGuid();

                _objProcessPaint.item_brand = _objProduction.item_brand;
                _objProcessPaint.item_model = _objProduction.item_model;
                _objProcessPaint.item_type_name = _objProduction.item_type_name;
                _objProcessPaint.item_glass_color = _objProduction.item_glass_color;
                _objProcessPaint.sale_header_master_id = _objProduction.sale_header_master_id.ToString();
                _objProcessPaint.party_master_id = _objProduction.party_master_id.ToString();
                _objProcessPaint.batch_number = _objProduction.batch_number;
                _objProcessPaint.production_quantity = _objProduction.production_quantity;

                _objProcessPaint.item_thickness = _objProcessCutting.item_thickness;
                _objProcessPaint.sheet_issued = _objProcessCutting.sheet_issued;
                _objProcessPaint.target_pcs_from_sheet_issued = _objProcessCutting.target_pcs_from_sheet_issued;
                _objProcessPaint.actual_pcs_from_sheet_issued = _objProcessCutting.actual_pcs_from_sheet_issued;
                _objProcessPaint.draft_size = _objProcessCutting.draft_size;

                _objProcessPaint.target_pcs_from_draft_size = _objProcessCutting.target_pcs_from_draft_size;
                _objProcessPaint.actual_pcs_from_draft_size = _objProcessCutting.actual_pcs_from_draft_size;
                _objProcessPaint.pcs_from_rejection = _objProcessCutting.pcs_from_rejection;
                _objProcessPaint.actual_pcs_from_rejection = _objProcessCutting.actual_pcs_from_rejection;

                _objProcessPaint.broken_sheets_in_crate = _objProcessCutting.broken_no_of_sheet;
                _objProcessPaint.broken_pcs_cut_from_sheet = _objProcessCutting.broken_pcs_cut_from_sheet;
                _objProcessPaint.broken_left_over_size = _objProcessCutting.broken_left_over_size;

                if (IsWashingYesNo == "false")
                {
                    if (_objProduction.hole_quantity == 0)
                    {
                        if (_objProduction.washing_one_quantity == 0)
                        {
                            _objProcessPaint.total_received = _objProduction.grinding_quantity;
                        }
                        else
                        {
                            _objProcessPaint.total_received = _objProduction.washing_one_quantity;
                        }
                    }
                    else
                    {
                        _objProcessPaint.total_received = _objProduction.hole_quantity;
                    }

                }
                else
                {
                    if (_objProduction.washing_quantity == 0)
                    {
                        if (_objProduction.hole_quantity == 0)
                        {
                            if (_objProduction.washing_one_quantity == 0)
                            {
                                _objProcessPaint.total_received = _objProduction.grinding_quantity;
                            }
                            else
                            {
                                _objProcessPaint.total_received = _objProduction.washing_one_quantity;
                            }
                        }
                        else
                        {
                            _objProcessPaint.total_received = _objProduction.hole_quantity;
                        }

                    }
                    
                    else
                    {
                        _objProcessPaint.total_received = _objProduction.washing_quantity;
                    }
                    
                }
               // _objProcessPaint.total_received = _objProduction.washing_quantity;
                //_objProcessPaint.total_received = 0;

                _objProcessPaint.total_broken =  _objProcessPaint.total_reject = _objProcessPaint.total_pcs_transferred =  _objProcessPaint.signature = 0;

                _objProcessPaint.paint_started_on =  _objProcessPaint.paint_ended_on = System.DateTime.Now;
                _objProcessPaint.paint_status = App.Helper.Utils.OrderStatus.production.ToString();


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objProcessPaint;
        }
        #endregion

        #region Get item DetailFor Add ProcessDfgPrint
        /// <summary>
        /// This Method is Used to Get ProcessDfgPrint Details
        /// </summary>
        /// <returns></returns>
        private ProcessDfgPrint GetProcessDfgPrintDetailsForAdd( string _paintYesNo)
        {
            try
            {
                string _paintStatus = _paintYesNo;
                _objProcessDfgPrint.item_master_id = _objProduction.item_master_id;
                _objProcessDfgPrint.guid = System.Guid.NewGuid();

                _objProcessDfgPrint.item_brand = _objProduction.item_brand;
                _objProcessDfgPrint.item_model = _objProduction.item_model;
                _objProcessDfgPrint.item_type_name = _objProduction.item_type_name;
                _objProcessDfgPrint.item_glass_color = _objProduction.item_glass_color;
                _objProcessDfgPrint.sale_header_master_id = _objProduction.sale_header_master_id.ToString();
                _objProcessDfgPrint.party_master_id = _objProduction.party_master_id.ToString();
                _objProcessDfgPrint.batch_number = _objProduction.batch_number;
                _objProcessDfgPrint.production_quantity = _objProduction.production_quantity;

                if (_paintStatus == "false")
                {
                    if (_objProduction.washing_quantity == 0)
                    {
                        if (_objProduction.hole_quantity == 0)
                        {
                            if (_objProduction.washing_one_quantity == 0)
                            {
                                _objProcessDfgPrint.total_received = _objProduction.grinding_quantity;
                            }
                            else
                            {
                                _objProcessDfgPrint.total_received = _objProduction.washing_one_quantity;
                            }
                        }
                        else
                        {
                            _objProcessDfgPrint.total_received = _objProduction.hole_quantity;
                        }
                    }
                    else
                    {
                        _objProcessDfgPrint.total_received = _objProduction.washing_quantity;
                    }
                }
                else
                {
                    _objProcessDfgPrint.total_received = _objProduction.paint_quantity;
                }
                
                //_objProcessDfgPrint.total_received = 0;

                _objProcessDfgPrint.total_broken = _objProcessDfgPrint.total_reject =  _objProcessDfgPrint.total_pcs_transferred =  _objProcessDfgPrint.signature = 0;

                _objProcessDfgPrint.dfg_print_started_on =  _objProcessDfgPrint.dfg_print_ended_on = System.DateTime.Now;
                _objProcessDfgPrint.dfg_status = App.Helper.Utils.OrderStatus.production.ToString();



            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objProcessDfgPrint;
        }
        #endregion

        #region Get item DetailFor Add ProcessTempering
        /// <summary>
        /// This Method is Used to Get ProcessTempering Details
        /// </summary>
        /// <returns></returns>
        private ProcessTempering GetProcessTemperingDetailsForAdd(string _dfgPrintYesNo)
        {
            try
            {
                string _dfgStatus = _dfgPrintYesNo;
                _objProcessTempering.item_master_id = _objProduction.item_master_id;
                _objProcessTempering.guid = System.Guid.NewGuid();

                _objProcessTempering.item_brand = _objProduction.item_brand;
                _objProcessTempering.item_model = _objProduction.item_model;
                _objProcessTempering.item_type_name = _objProduction.item_type_name;
                _objProcessTempering.item_glass_color = _objProduction.item_glass_color;
                _objProcessTempering.sale_header_master_id = _objProduction.sale_header_master_id.ToString();
                _objProcessTempering.party_master_id = _objProduction.party_master_id.ToString();
                _objProcessTempering.batch_number = _objProduction.batch_number;
                _objProcessTempering.production_quantity = _objProduction.production_quantity;

                if(_dfgStatus == "false")
                {
                    if (_objProduction.paint_quantity == 0)
                    {
                        if (_objProduction.washing_quantity == 0)
                        {
                            if (_objProduction.hole_quantity == 0)
                            {
                                if (_objProduction.washing_one_quantity == 0)
                                {
                                    _objProcessTempering.total_received = _objProduction.grinding_quantity;
                                }
                                else
                                {
                                    _objProcessTempering.total_received = _objProduction.washing_one_quantity;
                                }
                            }
                            else
                            {
                                _objProcessTempering.total_received = _objProduction.hole_quantity;
                            }
                        }
                        else
                        {
                            _objProcessTempering.total_received = _objProduction.washing_quantity;
                        }
                    }
                    else
                    {
                        _objProcessTempering.total_received = _objProduction.paint_quantity;
                    }
                }
                else
                {
                    _objProcessTempering.total_received = _objProduction.dfg_print_quantity;
                }

                
                //_objProcessTempering.total_received = 0;

                _objProcessTempering.total_broken =  _objProcessTempering.total_reject =  _objProcessTempering.total_pcs_transferred =   _objProcessTempering.signature = 0;

                _objProcessTempering.tempering_started_on =  _objProcessTempering.tempering_ended_on = System.DateTime.Now;
                _objProcessTempering.tempering_status = App.Helper.Utils.OrderStatus.production.ToString();




            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objProcessTempering;
        }
        #endregion

        #region Get item DetailFor Add ProcessTemperingReport
        /// <summary>
        /// This Method is Used to Get ProcessTemperingReport Details
        /// </summary>
        /// <returns></returns>
        private ProcessTemperingReport GetProcessTemperingReportDetailsForAdd(string _dfgPrintYesNo)
        {
            try
            {

                string _dfgStatus = _dfgPrintYesNo;
                _objProcessTemperingReport.guid = System.Guid.NewGuid();
                _objProcessTemperingReport.process_tempering_id = _objProcessTempering.process_tempering_id;

                _objProcessTemperingReport.item_master_id = _objProcessTempering.item_master_id;
                _objProcessTemperingReport.item_brand = _objProcessTempering.item_brand;
                _objProcessTemperingReport.item_model = _objProcessTempering.item_model;
                _objProcessTemperingReport.item_type_name = _objProcessTempering.item_type_name;
                _objProcessTemperingReport.item_glass_color = _objProcessTempering.item_glass_color;
                _objProcessTemperingReport.sale_header_master_id = _objProcessTempering.sale_header_master_id.ToString();
                _objProcessTemperingReport.party_master_id = _objProcessTempering.party_master_id.ToString();

                _objProcessTemperingReport.report_date = System.DateTime.Now;
                _objProcessTemperingReport.htf_shift_from = "";
                _objProcessTemperingReport.htf_shift_to = "";
                _objProcessTemperingReport.plant_number = _objProduction.production_plant;
                _objProcessTemperingReport.report_shift = _objProduction.production_shift;

                _objProcessTemperingReport.batch_number = _objProcessTempering.batch_number;
                if (_dfgStatus == "false")
                {
                    if (_objProduction.paint_quantity == 0)
                    {
                        if (_objProduction.washing_quantity == 0)
                        {
                            if (_objProduction.hole_quantity == 0)
                            {
                                if (_objProduction.washing_one_quantity == 0)
                                {
                                    _objProcessTemperingReport.quantity_in_pcs = _objProduction.grinding_quantity;
                                }
                                else
                                {
                                    _objProcessTemperingReport.quantity_in_pcs = _objProduction.washing_one_quantity;
                                }
                            }
                            else
                            {
                                _objProcessTemperingReport.quantity_in_pcs = _objProduction.hole_quantity;
                            }
                        }
                        else
                        {
                            _objProcessTemperingReport.quantity_in_pcs = _objProduction.washing_quantity;
                        }
                    }
                    else
                    {
                        _objProcessTemperingReport.quantity_in_pcs = _objProduction.paint_quantity;
                    }

                }
                else
                {
                    _objProcessTemperingReport.quantity_in_pcs = _objProduction.dfg_print_quantity;
                }
                
                _objProcessTemperingReport.production_target_in_pcs = _objProduction.production_quantity;

                // _objProcessTemperingReport.production_target_in_percentage = _objProduction.production_quantity;
                _objProcessTemperingReport.heating_on = System.DateTime.Now;
                _objProcessTemperingReport.furnace_meter_on_heating = _objProcessTemperingReport.big_blower_on_heating= _objProcessTemperingReport.small_blower_on_heating =  0;
               

                _objProcessTemperingReport.production_start = System.DateTime.Now;
                _objProcessTemperingReport.furnace_meter_start_production =  _objProcessTemperingReport.big_blower_start_production =  _objProcessTemperingReport.small_blower_start_production = 0;

                _objProcessTemperingReport.production_finish = System.DateTime.Now;
                _objProcessTemperingReport.furnace_meter_finish_production =  _objProcessTemperingReport.big_blower_finish_production =  _objProcessTemperingReport.small_blower_finish_production = 0;

                _objProcessTemperingReport.operator_name =  _objProcessTemperingReport.line_incharge =  _objProcessTemperingReport.helper_name =  _objProcessTemperingReport.supervisor_name = "";

                _objProcessTemperingReport.item_verify_status = "-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1";
                _objProcessTemperingReport.ok_total_pcs_in_hours =  _objProcessTemperingReport.breakage_total_pcs = _objProcessTemperingReport.reject_total_pcs =  _objProcessTemperingReport.signature = 0;

                _objProcessTemperingReport.item_average_hours_cost =  _objProcessTemperingReport.item_raw_balance = 0;


                _objProcessTemperingReport.total_received = _objProcessTemperingReport.quantity_in_pcs;
                _objProcessTemperingReport.total_broken =  _objProcessTemperingReport.total_reject =  _objProcessTemperingReport.total_pcs_transferred = 0;
                _objProcessTemperingReport.breakage_reason =  _objProcessTemperingReport.reject_reason =  _objProcessTemperingReport.remarks = "";

                




            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objProcessTemperingReport;
        }
        #endregion

        #region Get item DetailFor Add ProcessPackaging
        /// <summary>
        /// This Method is Used to Get ProcessPackaging Details
        /// </summary>
        /// <returns></returns>
        private ProcessPackaging GetProcessPackagingDetailsForAdd()
        {
            try
            {
                _objProcessPackaging.item_master_id = _objProduction.item_master_id;
                _objProcessPackaging.guid = System.Guid.NewGuid();

                _objProcessPackaging.item_brand = _objProduction.item_brand;
                _objProcessPackaging.item_model = _objProduction.item_model;
                _objProcessPackaging.item_type_name = _objProduction.item_type_name;
                _objProcessPackaging.item_glass_color = _objProduction.item_glass_color;
                _objProcessPackaging.sale_header_master_id = _objProduction.sale_header_master_id.ToString();
                _objProcessPackaging.party_master_id = _objProduction.party_master_id.ToString();
                _objProcessPackaging.batch_number = _objProduction.batch_number;
                _objProcessPackaging.batch_number = _objProduction.batch_number;
                _objProcessPackaging.production_quantity = _objProduction.production_quantity;
                _objProcessPackaging.total_received = _objProduction.tempering_quantity;
                //_objProcessPackaging.total_received = 0;
                _objProcessPackaging.total_broken =  _objProcessPackaging.total_reject = _objProcessPackaging.total_pcs_transferred =  _objProcessPackaging.signature = 0;
                _objProcessPackaging.packaging_started_on = _objProcessPackaging.packaging_ended_on = System.DateTime.Now;
                _objProcessPackaging.packaging_status = App.Helper.Utils.OrderStatus.production.ToString();

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objProcessPackaging;
        }
        #endregion

        #region Get item DetailFor Add ProcessStore
        /// <summary>
        /// This Method is Used to Get ProcessStore Details
        /// </summary>
        /// <returns></returns>
        private ProcessStore GetProcessStoreDetailsForAdd()
        {
            try
            {

                _objProcessStore.item_master_id = _objProduction.item_master_id;
                _objProcessStore.guid = System.Guid.NewGuid();

                _objProcessStore.item_brand = _objProduction.item_brand;
                _objProcessStore.item_model = _objProduction.item_model;
                _objProcessStore.item_type_name = _objProduction.item_type_name;
                _objProcessStore.item_glass_color = _objProduction.item_glass_color;
                _objProcessStore.sale_header_master_id = _objProduction.sale_header_master_id.ToString();
                _objProcessStore.party_master_id = _objProduction.party_master_id.ToString();
                _objProcessStore.batch_number = _objProduction.batch_number;
                _objProcessStore.production_quantity = _objProduction.production_quantity;

                _objProcessStore.total_received = _objProduction.packing_quantity;
                //_objProcessStore.total_received = 0;

                _objProcessStore.total_broken = 0;
                _objProcessStore.total_reject = 0;
                _objProcessStore.total_pcs_transferred = 0;
                _objProcessStore.signature = 0;

                _objProcessStore.store_started_on = System.DateTime.Now;
                _objProcessStore.store_ended_on = System.DateTime.Now;
                _objProcessStore.store_status = App.Helper.Utils.OrderStatus.production.ToString();


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objProcessStore;
        }
        #endregion

        /// <summary>
        /// This Method is Used to Get Procduction Details of All Items and Items Current Status Department Wise and Data in Repeater
        /// </summary>
        private void BindOnFloorOtherItemRptr(string _batchNumber, string _parentItemMasterId)
        {
            _objOnFloorItemMasterBL = new OnFloorItemMasterBL();
            _lstOnFloorItemMaster = _objOnFloorItemMasterBL.GetAllOnFloorItemMasterItems().Where(x => x.batch_number == _batchNumber && x.parent_item_master_id == Convert.ToInt32(_parentItemMasterId)).ToList();

            if (_lstOnFloorItemMaster != null)
            {
                if (_lstOnFloorItemMaster.Count > 0)
                {
                    rptrOnFloorOtherItemsList.DataSource = _lstOnFloorItemMaster;
                    rptrOnFloorOtherItemsList.DataBind();
                    divOnFloorOtherItemList.Visible = rptrOnFloorOtherItemsList.Visible = true;
                }
                else
                {
                    rptrOnFloorOtherItemsList.DataSource = null;
                    rptrOnFloorOtherItemsList.DataBind();
                    divOnFloorOtherItemList.Visible = rptrOnFloorOtherItemsList.Visible = false;
                }
            }
            else
            {
                rptrOnFloorOtherItemsList.DataSource = null;
                rptrOnFloorOtherItemsList.DataBind();
                divOnFloorOtherItemList.Visible = rptrOnFloorOtherItemsList.Visible = false;
            }
        }

        #endregion

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
                _objProductionTrail.user_name = Session[Constants.UserName].ToString() == null ? Session[Constants.LoginID].ToString(): Session[Constants.UserName].ToString();
                _objProductionTrail.heading = heading;
                _objProductionTrail.heading_class = heading_class;
                _objProductionTrail.activity = activity;
                _objProductionTrail.icon = icon;
                _objProductionTrail.icon_class = iconclass;

                // _objActivityLog.user_name = loginParams.UserName;
                //   _objActivityLog.IpAddress = UserIp;
                _objProductionTrail.created_on = Convert.ToDateTime(DateTime.Now);
                _objProductionTrail.modified_on = Convert.ToDateTime(DateTime.Now);
                _objProductionTrailBL.CreateProductionTrail(_objProductionTrail);

                //string id = Convert.ToString(Session[Constants.Id]);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        #endregion



        /// <summary>
        /// This Method is Used to Get PartyName Details For Show in Tooltip of Work-Order-Number
        /// </summary>
        /// <param name="_partyMasterId"></param>
        /// <returns></returns>
        public string getPartyFullNameForTooltip(string _partyMasterId)
        {
            string _partyNameBind = string.Empty;
            try
            {
                _objPartyMasterBL = new PartyMasterBL();
                if (!string.IsNullOrEmpty(_partyMasterId))
                {
                    string rejectPcsNumber = _partyMasterId;
                    string lasttmPcsNumber = rejectPcsNumber.TrimEnd(',');
                    arrOfProductionPartyId = lasttmPcsNumber.Split(',');

                    for (int _IndexofPartyMasterId = 0; _IndexofPartyMasterId < arrOfProductionPartyId.Length; _IndexofPartyMasterId++)
                    {

                        _objPartyMaster = _objPartyMasterBL.GetAllPartyMasterItems().Where(x => x.party_master_id == Convert.ToInt32(arrOfProductionPartyId[_IndexofPartyMasterId])).FirstOrDefault();
                        if (_objPartyMaster != null)
                        {
                            _partyNameBind = _partyNameBind + _objPartyMaster.party_name.ToString() + " ,";

                        }
                    }
                }
               
                //lblPartyNames.Text = string.Empty;

                
            }
            catch(Exception ex)
            {
                return _partyNameBind.TrimEnd(',').ToString();
            }

            return _partyNameBind.TrimEnd(',').ToString();
        }

    }
}