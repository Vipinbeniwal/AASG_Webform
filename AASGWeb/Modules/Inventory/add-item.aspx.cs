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
using App.BusinessModel;
using App.Business;

namespace AASGWeb.Modules.Inventory
{
    public partial class add_item : System.Web.UI.Page
    {
        #region Global Properties
        ActivityLog _objActivityLog = new ActivityLog();
        ActivityLogBL _objActivityLogBL = null;
        List<ActivityLog> _lstActivityLog = new List<ActivityLog>();

        ItemMaster _objItemMaster = new ItemMaster();
        ItemMasterBL _objItemMasterBL = null;
        List<ItemMaster> _lstItemMaster = new List<ItemMaster>();


        string UserIp = string.Empty;
        
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
               // BindDropdownMaster();
                BindConnectionType();
                BindDoorClipType();
                string _itemid;
                if (RouteData.Values["id"] == null)
                {
                    // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "editorInit();", true);
                }
                else
                {

                    string item_master_id = RouteData.Values["id"].ToString();
                    _itemid = App.Core.DataSecurity.Decryptdata(item_master_id);
                    if (_itemid == "" || _itemid == "")
                    {
                        Response.Redirect("/home", false);
                    }
                    else
                    {
                        hdnfItemId.Value = _itemid;

                        if (hdnfItemId.Value == "")
                        {
                            Response.Redirect("/home", false);

                        }
                        else
                        {
                            PopulateData(_itemid);
                        }

                    }


                }
            }
        }


        #region Page Load Method

        #region
        private void PopulateData(string _Itemid)
        {
            try
            {
                Int32 ITEMID = Convert.ToInt32(_Itemid);

                _objItemMasterBL = new ItemMasterBL();
                _objItemMaster = _objItemMasterBL.GetItemMasterItemsByID(Convert.ToInt32(ITEMID)).FirstOrDefault();
                if (_objItemMaster.item_master_id > 0)
                {
                    btnAddItem.Visible = false;
                    btnUpdate.Visible = true;

                    txtBrand.Text = _objItemMaster.brand;
                    txtModel.Text = _objItemMaster.model;

                    // ddlItemType.SelectedValue = _objItemMaster.itemtype_id.ToString();
                    //ddlItemType.SelectedValue = _objItemMaster.item_type_name.ToString();
                    txtItemType.Text = _objItemMaster.item_type_name;
                    txtGlassColor.Text = _objItemMaster.glass_color;

                    txtItemHeight.Text = _objItemMaster.item_height;
                    txtItemWidth.Text = _objItemMaster.item_width;
                    txtThickness.Text = _objItemMaster.thickness;

                    txtActualSQM.Text = _objItemMaster.actual_sqm;
                    txtUsedSQM.Text = _objItemMaster.used_sqm;
                    txtPerimeter.Text = _objItemMaster.perimeter;
                    ddlPlant.SelectedValue = _objItemMaster.plant_name.ToString();
                    ddlPlantNumber.SelectedValue = _objItemMaster.plant_no.ToString();

                    

                    if (_objItemMaster.diamond_required == true)
                    {
                        ddlDiamondYesNo.SelectedValue = "1";
                        txtDiamondInRs.Enabled = true;
                        txtDiamondInRs.Text = _objItemMaster.diamond_in_rs;
                    }
                    else
                    {
                        ddlDiamondYesNo.SelectedValue = "0";
                        txtDiamondInRs.Text = "";
                    }

                    if (_objItemMaster.rg_required == true)
                    {
                        ddlRGYesNo.SelectedValue = "1";
                        txtRGInRs.Enabled = true;
                        txtRGInRs.Text = _objItemMaster.rg_in_rs;
                    }
                    else
                    {
                        ddlRGYesNo.SelectedValue = "0";
                        txtRGInRs.Text = "";
                    }

                    if(_objItemMaster.washing_one==true)
                    {
                        ddlWashingOneYesNo.SelectedValue = "1";
                    }
                    else
                    {
                        ddlWashingOneYesNo.SelectedValue = "0";
                    }
                   
                    if (_objItemMaster.hole_required== true)
                    {
                        ddlHoleYesNo.SelectedValue = "1";
                        txtNumberOfHole.Enabled = true;
                        txtDiameter.Enabled = true;
                        txtNumberOfHole.Text = _objItemMaster.number_of_holes.ToString();
                        txtDiameter.Text = _objItemMaster.diameter;

                    }
                    else
                    {
                        ddlHoleYesNo.SelectedValue = "0";
                        txtNumberOfHole.Text = "";
                        txtDiameter.Text = "";
                    }

                    if (_objItemMaster.washing_two == true)
                    {
                        ddlWashingTwoYesNo.SelectedValue = "1";
                    }
                    else
                    {
                        ddlWashingTwoYesNo.SelectedValue = "0";
                    }


                    txtNumberOfHole.Text = _objItemMaster.number_of_holes.ToString();
                    txtDiameter.Text = _objItemMaster.diameter.ToString();
                    txtDiamondInRs.Text = _objItemMaster.diamond_in_rs.ToString();
                    if (_objItemMaster.is_normal_paint == true)
                    {
                        ddlNormalPaintYesNo.SelectedValue = "1";
                        txtNormalPaintQTYGM.Enabled = true;
                        txtNormalPaintInRs.Enabled = true;
                        txtNormalPaintQTYGM.Text = _objItemMaster.normal_paint_quantity.ToString();
                        txtNormalPaintInRs.Text = _objItemMaster.normal_paint_rs.ToString();

                    }
                    else
                    {
                        ddlNormalPaintYesNo.SelectedValue = "0";
                        txtNormalPaintInRs.Text = "";
                        txtNormalPaintQTYGM.Text = "";
                    }
                   
                    if (_objItemMaster.is_black_paint == true)
                    {
                        ddlBlackPaintYesNo.SelectedValue = "1";
                        txtBlackPaintQTYGM.Enabled = true;
                        txtBlackPaintQTYGM.Text = _objItemMaster.black_paint_quantity.ToString() == null ? "0" : _objItemMaster.black_paint_quantity.ToString();
                        //txtBlackPaintQTYGM.Text = _objItemMaster.black_paint_quantity.ToString();
                        txtBlackPaintInRs.Enabled = true;

                        txtBlackPaintInRs.Text = _objItemMaster.black_paint_rs.ToString()==null ? "0": _objItemMaster.black_paint_rs.ToString();
                       // txtBlackPaintInRs.Text = _objItemMaster.black_paint_rs.ToString();
                    }
                    else
                    {
                        ddlBlackPaintYesNo.SelectedValue = "0";
                        txtBlackPaintQTYGM.Text = "";
                        txtBlackPaintInRs.Text = "";
                    }

                    if (_objItemMaster.is_dfg_paint == true)
                    {
                        ddlDFGPaintYesNo.SelectedValue = "1";
                        txtDFGPaintQTYGM.Enabled = true;
                        txtDFGPaintQTYGM.Text = _objItemMaster.dfg_paint_quantity.ToString();
                        txtDFGPaintInRs.Enabled = true;
                        txtDFGPaintInRs.Text = _objItemMaster.dfg_paint_rs.ToString() == null ? "0" : _objItemMaster.dfg_paint_rs.ToString();
                       // txtDFGPaintInRs.Text = _objItemMaster.dfg_paint_rs.ToString();
                    }
                    else
                    {
                        ddlDFGPaintYesNo.SelectedValue = "0";
                        txtDFGPaintQTYGM.Text = "";
                        txtDFGPaintInRs.Text = "";
                    }
                    
                    if (_objItemMaster.is_thinner_paint == true)
                    {
                        ddlThinnerPaintYesNo.SelectedValue = "1";
                        txtThinnerPaintQTYGM.Enabled = true;
                        txtThinnerPaintQTYGM.Text = _objItemMaster.thinner_paint_quantity.ToString();
                        txtThinnerPaintInRs.Enabled = true;
                        txtThinnerPaintInRs.Text = _objItemMaster.thinner_paint_rs.ToString();
                    }
                    else
                    {
                        ddlThinnerPaintYesNo.SelectedValue = "0";
                        txtThinnerPaintQTYGM.Text = "";
                        txtThinnerPaintInRs.Text = "";
                    }

                    txtPreProcessingBreakageLevel.Text = _objItemMaster.pre_processing_breakage_level.ToString();
                    txtProcessingBreakageLevel.Text = _objItemMaster.processing_breakage_level.ToString();

                    if (_objItemMaster.polish_required == true)
                    {
                        ddlPolishYesNo.SelectedValue = "1";
                        txtPolishInRs.Enabled = true;
                        txtPolishInRs.Text = _objItemMaster.polish_in_rs.ToString();
                    }
                    else
                    {
                        ddlPolishYesNo.SelectedValue = "0";
                        txtPolishInRs.Text = "";
                    }

                    ddlConnectorType.SelectedValue = _objItemMaster.connector_type;
                    txtConnectorInRs.Text = _objItemMaster.connector_price.ToString();

                    
                    if (_objItemMaster.is_doorclip_required == true)
                    {
                        ddlDoorClipYesNo.SelectedValue = "1";
                        txtDoorClipRate.Enabled = true;
                        txtDoorClipRate.Text = _objItemMaster.doorclip_rate.ToString();
                        ddlDoorClipType.SelectedValue = _objItemMaster.doorclip_type.ToString();
                    }
                    else
                    {
                        ddlDoorClipYesNo.SelectedValue = "0";
                        txtDoorClipRate.Text = "";
                    }

                    if (_objItemMaster.packing_polythin_required == true)
                    {
                        ddlPackingPolythinYesNo.SelectedValue = "1";
                        txtPackingPolythinInRs.Enabled = true;
                        txtPackingPolythinInRs.Text = _objItemMaster.packing_in_rs.ToString();
                    }
                    else
                    {
                        ddlPackingPolythinYesNo.SelectedValue = "0";
                        txtPackingPolythinInRs.Text = "";
                    }

                    if (_objItemMaster.packing_paper_required == true)
                    {
                        ddlPackingPaperYesNo.SelectedValue = "1";
                        txtPackingPaperQuantityInRs.Enabled = true;
                        txtPackingPaperQuantityInRs.Text = _objItemMaster.packing_paper_quantity.ToString();
                    }
                    else
                    {
                        ddlPackingPaperYesNo.SelectedValue = "0";
                        txtPackingPaperQuantityInRs.Text = "";
                    }
                    txtStockMaxLevel.Text = _objItemMaster.stock_max_level.ToString();
                    txtItemWeight.Text = _objItemMaster.item_weight.ToString();
                    txtPrice.Text = _objItemMaster.price.ToString();
                    txtprice2.Text = _objItemMaster.price_2.ToString();
                    ddlPriceType.SelectedValue = _objItemMaster.price_type.ToString();

                    txtMMSQM.Text = _objItemMaster.mm_sqm.ToString();
                    txtFirstDop.Text = _objItemMaster.first_dop.ToString();
                    txtLastDop.Text = _objItemMaster.last_dop.ToString();
                    ddlSegment.Text = _objItemMaster.segment.ToString();
                    ddlCategory.Text = _objItemMaster.category.ToString();
                    txtPriority.Text = _objItemMaster.priority.ToString();
                    txtClearFocus.Text = _objItemMaster.clear_focus.ToString();
                    txtMaxStockLevelApr20.Text = _objItemMaster.max_stock_level_apr_20.ToString();
                    txtMaxStockLevelMay21.Text = _objItemMaster.max_stock_level_may_21.ToString();
                    txtMaxStockLevelJan21.Text = _objItemMaster.max_stock_level_jan_21.ToString();
                    txtQ12021.Text = _objItemMaster.q1_2021.ToString();
                    txtQ22021.Text = _objItemMaster.q2_2021.ToString();
                    txtQ32021.Text = _objItemMaster.q3_2021.ToString();
                    txtQ42021.Text = _objItemMaster.q4_2021.ToString();
                    txtPreProcessing.Text = _objItemMaster.pre_processing.ToString() == null ? "0" : _objItemMaster.pre_processing.ToString();
                   // txtPreProcessing.Text = _objItemMaster.pre_processing.ToString();
                    txtDuringProcessing.Text = _objItemMaster.during_processing.ToString();
                    txtFactoryReadyStock.Text = _objItemMaster.factory_ready_stock.ToString();
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
        #endregion

        #region Bind DropDown

        //private void BindDropdownMaster()
        //{
        //    try
        //    {
        //        List<DropdownMaster> _lstDropdownMaster = new List<DropdownMaster>();
        //        DropdownMasterBL _objDropdownMasterBL = new DropdownMasterBL();

        //        _lstDropdownMaster = _objDropdownMasterBL.GetAllDropdownMasterItems().Where(x => x.dropdown_type == "Item Type").OrderByDescending(x => x.created_on).ToList();


        //        ddlItemType.DataSource = _lstDropdownMaster;
        //        ddlItemType.DataTextField = "dropdown_item_name";
        //        ddlItemType.DataValueField = "dropdown_master_id";
        //        ddlItemType.DataBind();




        //    }
        //    catch (Exception ex)
        //    {
        //        string error = ex.ToString();
        //    }
        //}

        private void BindConnectionType()
        {
            try
            {
                List<DropdownMaster> _lstDropdownMaster = new List<DropdownMaster>();
                DropdownMasterBL _objDropdownMasterBL = new DropdownMasterBL();

                _lstDropdownMaster = _objDropdownMasterBL.GetAllDropdownMasterItems().Where(x => x.dropdown_type == "Connection Type").ToList();

                ddlConnectorType.DataSource = _lstDropdownMaster;
                ddlConnectorType.DataTextField = "dropdown_item_name";
                ddlConnectorType.DataValueField = "dropdown_master_id";
                ddlConnectorType.DataBind();
                ddlConnectorType.Items.Insert(0, new ListItem("Select", "Select"));

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }

        private void BindDoorClipType()
        {
            try
            {
                List<DropdownMaster> _lstDropdownMaster = new List<DropdownMaster>();
                DropdownMasterBL _objDropdownMasterBL = new DropdownMasterBL();

                _lstDropdownMaster = _objDropdownMasterBL.GetAllDropdownMasterItems().Where(x => x.dropdown_type == "DoorClip Type").ToList();
                
                ddlDoorClipType.DataSource = _lstDropdownMaster;
                ddlDoorClipType.DataTextField = "dropdown_item_name";
                ddlDoorClipType.DataValueField = "dropdown_master_id";
                ddlDoorClipType.DataBind();
                ddlDoorClipType.Items.Insert(0, new ListItem("Select", "Select"));
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }

        #endregion

        #endregion

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
          
            _objItemMasterBL = new ItemMasterBL();
            try
            {
                //_lstItemMaster = _objItemMasterBL.GetAllItemMasterItems().Where(x => x.brand.ToLower() == txtBrand.Text.ToLower() && x.model.ToLower() ==txtModel.Text.ToLower() && x.itemtype_id == Convert.ToInt32(ddlItemType.SelectedValue)).ToList();
                //_lstItemMaster = _objItemMasterBL.GetAllItemMasterItems().Where(x => x.brand.ToLower() == txtBrand.Text.ToLower() && x.model.ToLower() == txtModel.Text.ToLower() && x.item_type_name == ddlItemType.SelectedValue).ToList();
                _lstItemMaster = _objItemMasterBL.GetAllItemMasterItems().Where(x => x.brand.ToLower() == txtBrand.Text.ToLower() && x.model.ToLower() == txtModel.Text.ToLower() && x.item_type_name == txtItemType.Text).ToList();
                if (_lstItemMaster.Count == 0)
                {
                    _objItemMasterBL = new ItemMasterBL();
                    var response = _objItemMasterBL.CreateItemMaster(GetItemMasterObject());

                    if (response.item_master_id != 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccess();", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlreadyItemMaster();", true);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }

        }

        #region Get Item Master Input Fields Details For Save
        /// <summary>
        /// This Method Is Used to get Item Master Input Fields Values
        /// </summary>
        /// <returns></returns>
        private ItemMaster GetItemMasterObject()
        {
            try
            {
                _objItemMaster.guid = Guid.NewGuid();
                _objItemMaster.brand = txtBrand.Text;
                _objItemMaster.model = txtModel.Text;
                //_objItemMaster.item_type_name = ddlItemType.SelectedValue;
                _objItemMaster.item_type_name = txtItemType.Text;
                _objItemMaster.glass_color = txtGlassColor.Text;
                
                _objItemMaster.item_height = txtItemHeight.Text == "" ? "0" : txtItemHeight.Text;
                _objItemMaster.item_width = txtItemWidth.Text == "" ? "0" : txtItemWidth.Text;
                _objItemMaster.thickness = txtThickness.Text == "" ? "0" : txtThickness.Text;
                _objItemMaster.actual_sqm = txtActualSQM.Text == ""? "0" : txtActualSQM.Text;
                _objItemMaster.used_sqm = txtUsedSQM.Text == "" ? "0" : txtUsedSQM.Text;
                _objItemMaster.perimeter = txtPerimeter.Text == "" ? "0" : txtPerimeter.Text;
                _objItemMaster.plant_name = ddlPlant.SelectedItem.Text;
                _objItemMaster.plant_no = Convert.ToInt32(ddlPlantNumber.SelectedValue);

                _objItemMaster.diamond_required = Convert.ToBoolean(Convert.ToInt32(ddlDiamondYesNo.SelectedValue));
                txtDiamondInRs.Text = txtDiamondInRs.Text == "" ? "0" : txtDiamondInRs.Text;
                _objItemMaster.diamond_in_rs = txtDiamondInRs.Text == "" ? "0" : txtDiamondInRs.Text;

                _objItemMaster.rg_required = Convert.ToBoolean(Convert.ToInt32(ddlRGYesNo.SelectedValue));
                txtRGInRs.Text = txtRGInRs.Text == "" ? "0" : txtRGInRs.Text;
                _objItemMaster.rg_in_rs = txtRGInRs.Text == "" ? "0" : txtRGInRs.Text;
                _objItemMaster.washing_one = Convert.ToBoolean(Convert.ToInt32(ddlWashingOneYesNo.SelectedValue));

                _objItemMaster.hole_required = Convert.ToBoolean(Convert.ToInt32(ddlHoleYesNo.SelectedValue));
                txtNumberOfHole.Text = txtNumberOfHole.Text == "" ? "0" : txtNumberOfHole.Text;
                _objItemMaster.number_of_holes = Convert.ToInt32(txtNumberOfHole.Text == "" ? "0" : txtNumberOfHole.Text);
                _objItemMaster.diameter = txtDiameter.Text == "" ? "0" : txtDiameter.Text;
                _objItemMaster.washing_two = Convert.ToBoolean(Convert.ToInt32(ddlWashingTwoYesNo.SelectedValue));

                _objItemMaster.is_normal_paint = Convert.ToBoolean(Convert.ToInt32(ddlNormalPaintYesNo.SelectedValue));
                _objItemMaster.normal_paint_quantity = txtNormalPaintQTYGM.Text == "" ? "0" : txtNormalPaintQTYGM.Text;
                _objItemMaster.normal_paint_rs = txtNormalPaintInRs.Text == "" ? "0" : txtNormalPaintInRs.Text;

                _objItemMaster.is_black_paint = Convert.ToBoolean(Convert.ToInt32(ddlBlackPaintYesNo.Text));
                _objItemMaster.black_paint_quantity = txtBlackPaintQTYGM.Text == "" ? "0" : txtBlackPaintQTYGM.Text;
                _objItemMaster.black_paint_rs = txtBlackPaintInRs.Text == "" ? "0" : txtBlackPaintInRs.Text;

                _objItemMaster.is_dfg_paint = Convert.ToBoolean(Convert.ToInt32(ddlDFGPaintYesNo.Text));
                _objItemMaster.dfg_paint_quantity = txtDFGPaintQTYGM.Text == "" ? "0" : txtDFGPaintQTYGM.Text;

                txtDFGPaintInRs.Text = txtDFGPaintInRs.Text == "" ? "0" : txtDFGPaintInRs.Text;
                _objItemMaster.dfg_paint_rs = txtDFGPaintInRs.Text == "" ? "0" : txtDFGPaintInRs.Text;
                // _objItemMaster.thinner_title = txtThinner.Text;
                _objItemMaster.is_thinner_paint = Convert.ToBoolean(Convert.ToInt32(ddlThinnerPaintYesNo.SelectedValue));
                _objItemMaster.thinner_paint_quantity = txtThinnerPaintQTYGM.Text == "" ? "0" : txtDFGPaintQTYGM.Text;
                txtThinnerPaintInRs.Text = txtThinnerPaintInRs.Text == "" ? "0.0" : txtThinnerPaintInRs.Text;
                if(ddlThinnerPaintYesNo.SelectedValue=="True")
                {
                    _objItemMaster.thinner_paint_rs = Convert.ToDecimal(txtThinnerPaintInRs.Text);
                }
                else
                {
                    _objItemMaster.thinner_paint_rs = 0;
                }

                _objItemMaster.pre_processing_breakage_level = Convert.ToInt32(txtPreProcessingBreakageLevel.Text);
                _objItemMaster.processing_breakage_level = Convert.ToInt32(txtProcessingBreakageLevel.Text);
                _objItemMaster.polish_required = Convert.ToBoolean(Convert.ToInt32(ddlPolishYesNo.SelectedValue == "Select" ? "0" : ddlConnectorType.SelectedValue));
                _objItemMaster.polish_in_rs = txtPolishInRs.Text == "" ? "0" : txtPolishInRs.Text;

                _objItemMaster.connector_type = ddlConnectorType.SelectedValue == "Select" ? "0" : ddlConnectorType.SelectedValue;
                _objItemMaster.connector_price = txtConnectorInRs.Text == "" ? "0" : txtConnectorInRs.Text;
                _objItemMaster.is_doorclip_required = Convert.ToBoolean(Convert.ToInt32(ddlDoorClipYesNo.Text == "Select" ? "0" : ddlDoorClipYesNo.SelectedValue));
                _objItemMaster.doorclip_type = ddlDoorClipType.SelectedValue == "Select" ? "0" : ddlDoorClipType.SelectedValue;
                _objItemMaster.doorclip_rate = txtDoorClipRate.Text == "" ? "0" : txtDoorClipRate.Text;

                _objItemMaster.packing_polythin_required = Convert.ToBoolean(Convert.ToInt32(ddlPackingPolythinYesNo.Text == "Select" ? "0" : ddlPackingPolythinYesNo.SelectedValue));
                _objItemMaster.packing_in_rs = txtPackingPolythinInRs.Text == "" ? "0" : txtPackingPolythinInRs.Text;
                _objItemMaster.packing_paper_required = Convert.ToBoolean(Convert.ToInt32(ddlPackingPaperYesNo.Text == "Select" ? "0" : ddlPackingPaperYesNo.SelectedValue));
                _objItemMaster.packing_paper_quantity = txtPackingPaperQuantityInRs.Text == "" ? "0" : txtPackingPaperQuantityInRs.Text;
                _objItemMaster.stock_max_level = Convert.ToInt32(txtStockMaxLevel.Text == "" ? "0" : txtStockMaxLevel.Text);
                
                _objItemMaster.item_weight = txtItemWeight.Text == "" ? "0" : txtItemWeight.Text;
                _objItemMaster.price = txtPrice.Text == "" ? "0" : txtPrice.Text;
                _objItemMaster.price_2 = txtprice2.Text == "" ? "0" : txtprice2.Text;
                _objItemMaster.price_type = ddlPriceType.Text == "Select" ? "Cash" : ddlPriceType.SelectedValue;
                _objItemMaster.mm_sqm = txtMMSQM.Text == "" ? "0" : txtMMSQM.Text;
                _objItemMaster.first_dop = txtFirstDop.Text == "" ? "0" : txtFirstDop.Text;
                _objItemMaster.last_dop = txtLastDop.Text == "" ? "0" : txtLastDop.Text;

                _objItemMaster.segment = ddlSegment.Text == "Select" ? "0" : ddlSegment.SelectedValue;
                _objItemMaster.category = ddlCategory.Text == "Select" ? "0" : ddlCategory.SelectedValue;
                _objItemMaster.priority = txtPriority.Text==""?0 : Convert.ToInt32(txtPriority.Text);
                _objItemMaster.clear_focus = txtClearFocus.Text;

                _objItemMaster.max_stock_level_apr_20 = txtMaxStockLevelApr20.Text == "" ? "0" : txtMaxStockLevelApr20.Text;
                _objItemMaster.max_stock_level_may_21 = txtMaxStockLevelMay21.Text == "" ? "0" : txtMaxStockLevelMay21.Text;
                _objItemMaster.max_stock_level_jan_21 = txtMaxStockLevelJan21.Text == "" ? "0" : txtMaxStockLevelJan21.Text;

                _objItemMaster.q1_2021 = txtQ12021.Text == "" ? 0 : Convert.ToInt32(txtQ12021.Text);
                _objItemMaster.q2_2021 = txtQ22021.Text == "" ? 0 : Convert.ToInt32(txtQ22021.Text);
                _objItemMaster.q3_2021 = txtQ32021.Text == "" ? 0 : Convert.ToInt32(txtQ32021.Text);
                _objItemMaster.q4_2021 = txtQ42021.Text == "" ? 0 : Convert.ToInt32(txtQ42021.Text);
                _objItemMaster.pre_processing =txtPreProcessing.Text==""?0: Convert.ToInt32(txtPreProcessing.Text);
                _objItemMaster.during_processing = txtDuringProcessing.Text == "" ? 0 : Convert.ToInt32(txtDuringProcessing.Text);
                _objItemMaster.factory_ready_stock = txtFactoryReadyStock.Text == "" ? 0 : Convert.ToInt32(txtFactoryReadyStock.Text);
                
                return _objItemMaster;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objItemMaster;
        }

        #endregion 
        #region Get Item Master Input Fields Details For Update
        /// <summary>
        /// This Method is Used to Get Item Master Details for Update
        /// </summary>
        /// <returns></returns>
        private ItemMaster GetItemMasterObjectForUpdate()
        {
            try
            {
                
                _objItemMaster.guid = _objItemMaster.guid;
                _objItemMaster.item_master_id = Convert.ToInt32(hdnfItemId.Value);
                _objItemMaster.brand = txtBrand.Text;
                _objItemMaster.model = txtModel.Text;
                //_objItemMaster.itemtype_id = Convert.ToInt32(ddlItemType.SelectedValue);
                
                _objItemMaster.glass_color = txtGlassColor.Text;

                _objItemMaster.item_height = txtItemHeight.Text == "" ? "0" : txtItemHeight.Text;
                _objItemMaster.item_width = txtItemWidth.Text == "" ? "0" : txtItemWidth.Text;
                _objItemMaster.thickness = txtThickness.Text == "" ? "0" : txtThickness.Text;
                _objItemMaster.actual_sqm = txtActualSQM.Text == "" ? "0" : txtActualSQM.Text;
                _objItemMaster.used_sqm = txtUsedSQM.Text == "" ? "0" : txtUsedSQM.Text;
                _objItemMaster.perimeter = txtPerimeter.Text == "" ? "0" : txtPerimeter.Text;
                _objItemMaster.plant_name = ddlPlant.SelectedItem.Text;
                _objItemMaster.plant_no = Convert.ToInt32(ddlPlantNumber.SelectedValue);

                _objItemMaster.diamond_required = Convert.ToBoolean(Convert.ToInt32(ddlDiamondYesNo.SelectedValue));
                txtDiamondInRs.Text = txtDiamondInRs.Text == "" ? "0" : txtDiamondInRs.Text;
                _objItemMaster.diamond_in_rs = txtDiamondInRs.Text == "" ? "0" : txtDiamondInRs.Text;
                //_objItemMaster.diamond_required = Convert.ToBoolean(Convert.ToInt32(txtDiamondInRs.Text == "0" ? "0" : "1"));

                _objItemMaster.rg_required = Convert.ToBoolean(Convert.ToInt32(ddlRGYesNo.SelectedValue));
                txtRGInRs.Text = txtRGInRs.Text == "" ? "0" : txtRGInRs.Text;
                _objItemMaster.rg_in_rs = txtRGInRs.Text == "" ? "0" : txtRGInRs.Text;
                _objItemMaster.washing_one = Convert.ToBoolean(Convert.ToInt32(ddlWashingOneYesNo.SelectedValue));

                _objItemMaster.hole_required = Convert.ToBoolean(Convert.ToInt32(ddlHoleYesNo.SelectedValue));
                txtNumberOfHole.Text = txtNumberOfHole.Text == "" ? "0" : txtNumberOfHole.Text;
                txtNumberOfHole.Text = txtNumberOfHole.Text == "" ? "0" : txtNumberOfHole.Text;
                _objItemMaster.number_of_holes = Convert.ToInt32(txtNumberOfHole.Text);
                _objItemMaster.diameter = txtDiameter.Text == "" ? "0" : txtDiameter.Text;
                _objItemMaster.washing_two = Convert.ToBoolean(Convert.ToInt32(ddlWashingTwoYesNo.SelectedValue));

                _objItemMaster.is_normal_paint = Convert.ToBoolean(Convert.ToInt32(ddlNormalPaintYesNo.SelectedValue));
                _objItemMaster.normal_paint_quantity = txtNormalPaintQTYGM.Text == "" ? "0" : txtNormalPaintQTYGM.Text;
                _objItemMaster.normal_paint_rs = txtNormalPaintInRs.Text == "" ? "0" : txtNormalPaintInRs.Text;

                _objItemMaster.is_black_paint = Convert.ToBoolean(Convert.ToInt32(ddlBlackPaintYesNo.Text));
                _objItemMaster.black_paint_quantity = txtBlackPaintQTYGM.Text == "" ? "0" : txtBlackPaintQTYGM.Text;
                _objItemMaster.black_paint_rs = txtBlackPaintInRs.Text == "" ? "0" : txtBlackPaintInRs.Text;

                _objItemMaster.is_dfg_paint = Convert.ToBoolean(Convert.ToInt32(ddlDFGPaintYesNo.Text));
                _objItemMaster.dfg_paint_quantity = txtDFGPaintQTYGM.Text == "" ? "0" : txtDFGPaintQTYGM.Text;

                txtDFGPaintInRs.Text = txtDFGPaintInRs.Text == "" ? "0" : txtDFGPaintInRs.Text;
                _objItemMaster.dfg_paint_rs = txtDFGPaintInRs.Text == "" ? "0" : txtDFGPaintInRs.Text;
                // _objItemMaster.thinner_title = txtThinner.Text;
                _objItemMaster.is_thinner_paint = Convert.ToBoolean(Convert.ToInt32(ddlThinnerPaintYesNo.SelectedValue));
                _objItemMaster.thinner_paint_quantity = txtThinnerPaintQTYGM.Text == "" ? "0" : txtDFGPaintQTYGM.Text;
                txtThinnerPaintInRs.Text = txtThinnerPaintInRs.Text == "" ? "0.0" : txtThinnerPaintInRs.Text;
                if (ddlThinnerPaintYesNo.SelectedValue == "True")
                {
                    _objItemMaster.thinner_paint_rs = Convert.ToDecimal(txtThinnerPaintInRs.Text);
                }
                else
                {
                    _objItemMaster.thinner_paint_rs = 0;
                }

                _objItemMaster.pre_processing_breakage_level = Convert.ToInt32(txtPreProcessingBreakageLevel.Text);
                _objItemMaster.processing_breakage_level = Convert.ToInt32(txtProcessingBreakageLevel.Text);
                _objItemMaster.polish_required = Convert.ToBoolean(Convert.ToInt32(ddlPolishYesNo.SelectedValue));
                _objItemMaster.polish_in_rs = txtPolishInRs.Text == "" ? "0" : txtPolishInRs.Text;

                _objItemMaster.connector_type = ddlConnectorType.SelectedValue == "Select" ? "0" : ddlConnectorType.SelectedValue;
                _objItemMaster.connector_price = txtConnectorInRs.Text == "" ? "0" : txtConnectorInRs.Text;
                _objItemMaster.is_doorclip_required = Convert.ToBoolean(Convert.ToInt32(ddlDoorClipYesNo.SelectedValue));
                _objItemMaster.doorclip_type = ddlDoorClipType.SelectedValue == "Select" ? "0" : ddlDoorClipType.SelectedValue;
                _objItemMaster.doorclip_rate = txtDoorClipRate.Text == "" ? "0" : txtDoorClipRate.Text;

                _objItemMaster.packing_polythin_required = Convert.ToBoolean(Convert.ToInt32(ddlPackingPolythinYesNo.SelectedValue));
                _objItemMaster.packing_in_rs = txtPackingPolythinInRs.Text == "" ? "0" : txtPackingPolythinInRs.Text;
                _objItemMaster.packing_paper_required = Convert.ToBoolean(Convert.ToInt32(ddlPackingPaperYesNo.SelectedValue));
                _objItemMaster.packing_paper_quantity = txtPackingPaperQuantityInRs.Text == "" ? "0" : txtPackingPaperQuantityInRs.Text;
                _objItemMaster.stock_max_level = Convert.ToInt32(txtStockMaxLevel.Text == "" ? "0" : txtStockMaxLevel.Text);

                _objItemMaster.item_weight = txtItemWeight.Text == "" ? "0" : txtItemWeight.Text;
                _objItemMaster.price = txtPrice.Text == "" ? "0" : txtPrice.Text;
                _objItemMaster.price_2 = txtprice2.Text == "" ? "0" : txtprice2.Text;
                _objItemMaster.price_type = ddlPriceType.Text == "Select" ? "Cash" : ddlPriceType.SelectedValue;
                _objItemMaster.mm_sqm = txtMMSQM.Text == "" ? "0" : txtMMSQM.Text;
                _objItemMaster.first_dop = txtFirstDop.Text == "" ? "0" : txtFirstDop.Text;
                _objItemMaster.last_dop = txtLastDop.Text == "" ? "0" : txtLastDop.Text;

                _objItemMaster.segment = ddlSegment.Text == "Select" ? "0" : ddlSegment.SelectedValue;
                _objItemMaster.category = ddlCategory.Text == "Select" ? "0" : ddlCategory.SelectedValue;
                _objItemMaster.priority = txtPriority.Text == "" ? 0 : Convert.ToInt32(txtPriority.Text);
                _objItemMaster.clear_focus = txtClearFocus.Text;

                _objItemMaster.max_stock_level_apr_20 = txtMaxStockLevelApr20.Text == "" ? "0" : txtMaxStockLevelApr20.Text;
                _objItemMaster.max_stock_level_may_21 = txtMaxStockLevelMay21.Text == "" ? "0" : txtMaxStockLevelMay21.Text;
                _objItemMaster.max_stock_level_jan_21 = txtMaxStockLevelJan21.Text == "" ? "0" : txtMaxStockLevelJan21.Text;

                _objItemMaster.q1_2021 = txtQ12021.Text == "" ? 0 : Convert.ToInt32(txtQ12021.Text);
                _objItemMaster.q2_2021 = txtQ22021.Text == "" ? 0 : Convert.ToInt32(txtQ22021.Text);
                _objItemMaster.q3_2021 = txtQ32021.Text == "" ? 0 : Convert.ToInt32(txtQ32021.Text);
                _objItemMaster.q4_2021 = txtQ42021.Text == "" ? 0 : Convert.ToInt32(txtQ42021.Text);
                _objItemMaster.pre_processing = txtPreProcessing.Text == "" ? 0 : Convert.ToInt32(txtPreProcessing.Text);
                _objItemMaster.during_processing = txtDuringProcessing.Text == "" ? 0 : Convert.ToInt32(txtDuringProcessing.Text);
                _objItemMaster.factory_ready_stock = txtFactoryReadyStock.Text == "" ? 0 : Convert.ToInt32(txtFactoryReadyStock.Text);


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objItemMaster;
        }
        #endregion


        #region Clear Item Master Form
        /// <summary>
        /// This Method is Used to Clear Item Master Form Fields
        /// </summary>
        private void ClearItemMasterForm()
        {

            btnAddItem.Visible = true;
            btnUpdate.Visible = false;

            txtBrand.Text =
            txtModel.Text =

            txtItemHeight.Text = txtItemWidth.Text = txtActualSQM.Text = txtUsedSQM.Text =
            txtThickness.Text = txtGlassColor.Text =
            txtPerimeter.Text =
            txtNumberOfHole.Text =
            
            txtDiamondInRs.Text =
            txtNormalPaintQTYGM.Text =
            txtBlackPaintQTYGM.Text =  txtDFGPaintQTYGM.Text = txtThinnerPaintQTYGM.Text = txtConnectorInRs.Text =
            txtStockMaxLevel.Text = txtDoorClipRate.Text = txtItemWeight.Text = txtPrice.Text = txtprice2.Text = txtPreProcessingBreakageLevel.Text = txtProcessingBreakageLevel.Text = string.Empty;

            ddlPlantNumber.SelectedValue = "0";
            ddlDiamondYesNo.SelectedIndex = 0;
            ddlRGYesNo.SelectedIndex = 0;
            ddlWashingOneYesNo.SelectedIndex = 0;
            ddlWashingTwoYesNo.SelectedIndex = 0;
            txtDiameter.Text = txtRGInRs.Text = txtNormalPaintInRs.Text = txtBlackPaintInRs.Text = txtDFGPaintInRs.Text = txtThinnerPaintInRs.Text = "0";

            hdnfItemId.Value = "0";

            //txtThinner.Text = "";
            // BindDropdownMaster();

            ddlDoorClipYesNo.SelectedIndex = 0;
            txtItemType.Text = "";
            //ddlItemType.SelectedIndex = 0;
            ddlPlant.SelectedIndex = 0;
            ddlHoleYesNo.SelectedIndex = 0;
            ddlNormalPaintYesNo.SelectedIndex = 0;
            ddlBlackPaintYesNo.SelectedIndex = 0;
            ddlThinnerPaintYesNo.SelectedIndex = 0;
            ddlDFGPaintYesNo.SelectedIndex = 0;
            txtDiameter.Text = txtRGInRs.Text = "";
            txtThinnerPaintInRs.Text = txtNormalPaintInRs.Text = txtBlackPaintInRs.Text = txtDFGPaintInRs.Text = txtPolishInRs.Text = "";
            ddlPolishYesNo.SelectedIndex = 0;
            ddlPackingPaperYesNo.SelectedIndex = ddlPackingPolythinYesNo.SelectedIndex = 0;
            txtPackingPolythinInRs.Text = txtPackingPaperQuantityInRs.Text = "";
            ddlCategory.SelectedIndex = 0;
            ddlPriceType.SelectedIndex = 0; ddlSegment.SelectedIndex = 0;
            txtMMSQM.Text = txtFirstDop.Text = txtLastDop.Text = txtPriority.Text=txtClearFocus.Text="";
            txtMaxStockLevelApr20.Text = txtMaxStockLevelJan21.Text = txtMaxStockLevelMay21.Text = "";
            txtQ12021.Text = txtQ22021.Text = txtQ32021.Text = txtQ42021.Text = "";
            txtPreProcessing.Text = txtDuringProcessing.Text = txtFactoryReadyStock.Text = "";
            BindConnectionType();
            BindDoorClipType();
            

        }
        #endregion



        protected void BtnReset_Click(object sender, EventArgs e)
        {
            ClearItemMasterForm();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
             try
            {
                _objItemMasterBL = new ItemMasterBL();

                _objItemMaster = _objItemMasterBL.GetAllItemMasterItems().Where(x => x.item_master_id == Convert.ToInt32(hdnfItemId.Value)).FirstOrDefault();
                if (_objItemMaster.item_master_id != 0)
                {
                    _objItemMaster = _objItemMasterBL.UpdateItemMaster(GetItemMasterObjectForUpdate());

                    if (_objItemMaster.item_master_id > 0)
                    {
                        ClearItemMasterForm();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showItemUpdate();", true);
                        
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
        }

        
    }
}