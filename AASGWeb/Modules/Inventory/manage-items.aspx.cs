using App.Business;
using App.BusinessModel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace AASGWeb.Modules.Inventory
{
    public partial class manage_items : System.Web.UI.Page
    {
        #region Global Properties

        ActivityLog _objActivityLog = new ActivityLog();
        ActivityLogBL _objActivityLogBL = null;
        List<ActivityLog> _lstActivityLog = new List<ActivityLog>();

        ItemMaster _objItemMaster = new ItemMaster();
        ItemMasterBL _objItemMasterBL = null;
        List<ItemMaster> _lstItemMaster = new List<ItemMaster>();

        ProductionPlanning _objProductionPlanning = new ProductionPlanning();
        ProductionPlanningBL _objProductionPlanningBL = null;
        List<ProductionPlanning> _lstProductionPlanning = new List<ProductionPlanning>();

        App.BusinessModel.Production _objProduction = new App.BusinessModel.Production();
        ProductionBL _objProductionBL = null;
        List<App.BusinessModel.Production> _lstProduction = new List<App.BusinessModel.Production>();

        PartyMaster _objPartyMaster = new PartyMaster();
        PartyMasterBL _objPartyMasterBL = null;
        List<PartyMaster> _lstPartyMaster = new List<PartyMaster>();

        string UserIp = string.Empty;
        public static string _RandomBatchNumber, _RandomSaleHeaderId = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindItemsGrid();
            }
        }

        private void BindItemsGrid()
        {
            try
            {
                _objItemMasterBL = new ItemMasterBL();
                _lstItemMaster = _objItemMasterBL.GetAllItemMasterItems().OrderByDescending(x => x.created_on).ToList();

                rptrManageItems.DataSource = _lstItemMaster;
                rptrManageItems.DataBind();

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }

        protected void rptrManageItems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string commandname = e.CommandName;
            string id = e.CommandArgument.ToString();
            hdfdItemId.Value = id;

            Int32 ID = Convert.ToInt32(id);
            switch (commandname)
            {
                case "active":
                    try
                    {
                        // updateStatus(id);
                        
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

                        string url = "add-item/" + App.Core.DataSecurity.Encryptdata(id).ToString();

                        Response.Redirect(url, false);
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
                case "production":
                    try
                    {
                        try
                        {
                            _objItemMasterBL = new ItemMasterBL();
                            _objItemMaster = _objItemMasterBL.GetItemMasterItemsByID(Convert.ToInt32(id)).FirstOrDefault();
                            if (_objItemMaster.item_master_id >0)
                            {
                                 txtBrand.ReadOnly = txtModel.ReadOnly= txtItemType.ReadOnly = txtGlassColor.ReadOnly = txtFactoryStock.ReadOnly = txtStockMaxLevel.ReadOnly = true;

                                txtBrand.Text = _objItemMaster.brand.ToString();
                                txtModel.Text = _objItemMaster.model.ToString();
                                txtItemType.Text = _objItemMaster.item_type_name.ToString();
                                txtGlassColor.Text = _objItemMaster.glass_color.ToString();
                                txtFactoryStock.Text = _objItemMaster.factory_ready_stock.ToString();
                                txtStockMaxLevel.Text = _objItemMaster.stock_max_level.ToString();
                                txtProductionQuantity.Text = "0";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showOrderDetailsModal();", true);

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                            }

                        }
                        catch (Exception ex)
                        {
                            string error = ex.ToString();
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

        protected void rptrManageItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                   
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "notification('Something went wrong','danger');", true);
            }
        }

        protected void btnDownloadExcel_Click(object sender, EventArgs e)
        {
            //Response.Clear();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment;filename=ItemMaster.xls");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-excel";

            //using (StringWriter sw = new StringWriter())
            //{
            //    HtmlTextWriter hw = new HtmlTextWriter(sw);
            //    foreach (RepeaterItem item in rptrManageItems.Items)
            //    {
            //        List<Control> controls = new List<Control>();
            //        foreach (Control control in item.Controls)
            //        {
            //            if (control.GetType() == typeof(LinkButton))
            //            {
            //                controls.Add(control);
            //            }
            //        }
            //        foreach (Control control in controls)
            //        {
            //            switch (control.GetType().Name)
            //            {
            //                case "LinkButton":
            //                    //item.Controls.Add(new Literal { Text = (control as LinkButton).Text });
            //                    break;
            //            }
            //            item.Controls.Remove(control);
            //        }
            //    }
            //    rptrManageItems.RenderControl(hw);
            //    Response.Write(sw.ToString());
            //    Response.Flush();
            //    Response.End();
            //}

            _objItemMasterBL = new ItemMasterBL();
            _lstItemMaster = _objItemMasterBL.GetAllItemMasterItems();
            var data = _lstItemMaster;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Write headers
                worksheet.Cells["A1"].Value = "item_master_id";
                worksheet.Cells["B1"].Value = "brand";
                worksheet.Cells["C1"].Value = "model";
                worksheet.Cells["D1"].Value = "item_type_name";
                worksheet.Cells["E1"].Value = "glass_color";
                worksheet.Cells["F1"].Value = "hsn_code";
                worksheet.Cells["G1"].Value = "gst_rate";
                worksheet.Cells["H1"].Value = "item_height";
                worksheet.Cells["I1"].Value = "item_width";
                worksheet.Cells["J1"].Value = "actual_sqm";
                worksheet.Cells["K1"].Value = "used_sqm";
                worksheet.Cells["L1"].Value = "thickness";
                worksheet.Cells["M1"].Value = "perimeter";
                worksheet.Cells["N1"].Value = "plant_name";
                worksheet.Cells["O1"].Value = "plant_no";
                worksheet.Cells["P1"].Value = "diamond_required";
                worksheet.Cells["Q1"].Value = "diamond_in_rs";
                worksheet.Cells["R1"].Value = "rg_required";
                worksheet.Cells["S1"].Value = "rg_in_rs";
                worksheet.Cells["T1"].Value = "washing_one";
                worksheet.Cells["U1"].Value = "hole_required";
                worksheet.Cells["V1"].Value = "number_of_holes";
                worksheet.Cells["W1"].Value = "diameter";
                worksheet.Cells["X1"].Value = "washing_two";
                worksheet.Cells["Y1"].Value = "is_normal_paint";
                worksheet.Cells["Z1"].Value = "normal_paint_quantity";
                worksheet.Cells["AA1"].Value = "normal_paint_rs";
                worksheet.Cells["AB1"].Value = "is_black_paint";
                worksheet.Cells["AC1"].Value = "black_paint_quantity";
                worksheet.Cells["AD1"].Value = "black_paint_rs";
                worksheet.Cells["AE1"].Value = "is_dfg_paint";
                worksheet.Cells["AF1"].Value = "dfg_paint_quantity";
                worksheet.Cells["AG1"].Value = "dfg_paint_rs";
                worksheet.Cells["AH1"].Value = "is_thinner_paint";
                worksheet.Cells["AI1"].Value = "thinner_paint_quantity";
                worksheet.Cells["AJ1"].Value = "thinner_paint_rs";
                worksheet.Cells["AK1"].Value = "pre_processing_breakage_level";
                worksheet.Cells["AL1"].Value = "processing_breakage_level";
                worksheet.Cells["AM1"].Value = "polish_required";
                worksheet.Cells["AN1"].Value = "polish_in_rs";
                worksheet.Cells["AO1"].Value = "connector_type";
                worksheet.Cells["AP1"].Value = "connector_price";
                worksheet.Cells["AQ1"].Value = "is_doorclip_required";
                worksheet.Cells["AR1"].Value = "doorclip_type";
                worksheet.Cells["AS1"].Value = "doorclip_rate";
                worksheet.Cells["AT1"].Value = "packing_polythin_required";
                worksheet.Cells["AU1"].Value = "packing_in_rs";
                worksheet.Cells["AV1"].Value = "packing_paper_required";
                worksheet.Cells["AW1"].Value = "packing_paper_quantity";
                worksheet.Cells["AX1"].Value = "stock_max_level";
                worksheet.Cells["AY1"].Value = "item_width";
                worksheet.Cells["AZ1"].Value = "price";
                worksheet.Cells["BA1"].Value = "price_2";
                worksheet.Cells["BB1"].Value = "price_type";
                worksheet.Cells["BC1"].Value = "mm_sqm";
                worksheet.Cells["BD1"].Value = "first_dop";
                worksheet.Cells["BE1"].Value = "last_dop";
                worksheet.Cells["BF1"].Value = "segment";
                worksheet.Cells["BG1"].Value = "category";
                worksheet.Cells["BH1"].Value = "priority";
                worksheet.Cells["BI1"].Value = "clear_focus";
                worksheet.Cells["BJ1"].Value = "max_stock_level_apr_20";
                worksheet.Cells["BK1"].Value = "max_stock_level_may_21";
                worksheet.Cells["BL1"].Value = "max_stock_level_jan_21";
                worksheet.Cells["BM1"].Value = "q1_2021";
                worksheet.Cells["BN1"].Value = "q2_2021";
                worksheet.Cells["BO1"].Value = "q3_2021";
                worksheet.Cells["BP1"].Value = "q4_2021";
                worksheet.Cells["BQ1"].Value = "during_processing";
                worksheet.Cells["BR1"].Value = "factory_ready_stock";
          


                // Write data to the worksheet
                int row = 2;
                foreach (var item in data)
                {
                    worksheet.Cells[row, 1].Value = item.item_master_id;
                    worksheet.Cells[row, 2].Value = item.brand;
                    worksheet.Cells[row, 3].Value = item.model;
                    worksheet.Cells[row, 4].Value = item.item_type_name;
                    worksheet.Cells[row, 5].Value = item.glass_color;
                    worksheet.Cells[row, 6].Value = item.hsn_code;
                    worksheet.Cells[row, 7].Value = item.gst_rate;
                    worksheet.Cells[row, 8].Value = item.item_height;
                    worksheet.Cells[row, 9].Value = item.item_width;
                    worksheet.Cells[row, 10].Value = item.actual_sqm;
                    worksheet.Cells[row, 11].Value = item.used_sqm;
                    worksheet.Cells[row, 12].Value = item.thickness;
                    worksheet.Cells[row, 13].Value = item.perimeter;
                    worksheet.Cells[row, 14].Value = item.plant_name;
                    worksheet.Cells[row, 15].Value = item.plant_no;
                    worksheet.Cells[row, 16].Value = item.diamond_required;
                    worksheet.Cells[row, 17].Value = item.diamond_in_rs;
                    worksheet.Cells[row, 18].Value = item.rg_required;
                    worksheet.Cells[row, 19].Value = item.rg_in_rs;
                    worksheet.Cells[row, 20].Value = item.washing_one;
                    worksheet.Cells[row, 21].Value = item.hole_required;
                    worksheet.Cells[row, 22].Value = item.number_of_holes;
                    worksheet.Cells[row, 23].Value = item.diameter;
                    worksheet.Cells[row, 24].Value = item.washing_two;
                    worksheet.Cells[row, 25].Value = item.is_normal_paint;
                    worksheet.Cells[row, 26].Value = item.normal_paint_quantity;
                    worksheet.Cells[row, 27].Value = item.normal_paint_rs;
                    worksheet.Cells[row, 28].Value = item.is_black_paint;
                    worksheet.Cells[row, 29].Value = item.black_paint_quantity;
                    worksheet.Cells[row, 30].Value = item.black_paint_rs;
                    worksheet.Cells[row, 31].Value = item.is_dfg_paint;
                    worksheet.Cells[row, 32].Value = item.dfg_paint_quantity;
                    worksheet.Cells[row, 33].Value = item.dfg_paint_rs;
                    worksheet.Cells[row, 34].Value = item.is_thinner_paint;
                    worksheet.Cells[row, 35].Value = item.thinner_paint_quantity;
                    worksheet.Cells[row, 36].Value = item.thinner_paint_rs;
                    worksheet.Cells[row, 37].Value = item.pre_processing_breakage_level;
                    worksheet.Cells[row, 38].Value = item.processing_breakage_level;
                    worksheet.Cells[row, 39].Value = item.polish_required;
                    worksheet.Cells[row, 40].Value = item.polish_in_rs;
                    worksheet.Cells[row, 41].Value = item.connector_type;
                    worksheet.Cells[row, 42].Value = item.connector_price;
                    worksheet.Cells[row, 43].Value = item.is_doorclip_required;
                    worksheet.Cells[row, 44].Value = item.doorclip_type;
                    worksheet.Cells[row, 45].Value = item.doorclip_rate;
                    worksheet.Cells[row, 46].Value = item.packing_polythin_required;
                    worksheet.Cells[row, 47].Value = item.packing_in_rs;
                    worksheet.Cells[row, 48].Value = item.packing_paper_required;
                    worksheet.Cells[row, 49].Value = item.packing_paper_quantity;
                    worksheet.Cells[row, 50].Value = item.stock_max_level;
                    worksheet.Cells[row, 51].Value = item.item_width;
                    worksheet.Cells[row, 52].Value = item.price;
                    worksheet.Cells[row, 53].Value = item.price_2;
                    worksheet.Cells[row, 54].Value = item.price_type;
                    worksheet.Cells[row, 55].Value = item.mm_sqm;
                    worksheet.Cells[row, 56].Value = item.first_dop;
                    worksheet.Cells[row, 57].Value = item.last_dop;
                    worksheet.Cells[row, 58].Value = item.segment;
                    worksheet.Cells[row, 59].Value = item.category;
                    worksheet.Cells[row, 60].Value = item.priority;
                    worksheet.Cells[row, 61].Value = item.clear_focus;
                    worksheet.Cells[row, 62].Value = item.max_stock_level_apr_20;
                    worksheet.Cells[row, 63].Value = item.max_stock_level_may_21;
                    worksheet.Cells[row, 64].Value = item.max_stock_level_jan_21;
                    worksheet.Cells[row, 65].Value = item.q1_2021;
                    worksheet.Cells[row, 66].Value = item.q2_2021;
                    worksheet.Cells[row, 67].Value = item.q3_2021;
                    worksheet.Cells[row, 68].Value = item.q4_2021;
                    worksheet.Cells[row, 69].Value = item.during_processing;
                    worksheet.Cells[row, 70].Value = item.factory_ready_stock;
                    row++;
                }

                // Convert the Excel package to a byte array
                byte[] excelBytes = package.GetAsByteArray();

                // Set response headers for Excel download
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment; filename=data.xlsx");

                // Write the Excel file to the response stream
                Response.BinaryWrite(excelBytes);
                Response.End();
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtProductionQuantity.Text =="" || txtProductionQuantity.Text == "0" || txtProductionQuantity.Text == null)
                {
                    divError.Visible = true;
                    lblErrroMessage.Text = "Please Fill Production Quantity";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showOrderDetailsModal();", true);

                }
                else
                {
                    _objProductionBL = new ProductionBL();
                    App.BusinessModel.Production _objProductionForItem = new App.BusinessModel.Production();
                    _objProductionForItem = _objProductionBL.GetProductionItemsProductionStatusByID(Convert.ToInt32(hdfdItemId.Value)).FirstOrDefault();

                    if (_objProductionForItem !=null)
                    {
                        if (_objProductionForItem.production_id > 0)
                        {
                            divError.Visible = true;
                            lblErrroMessage.Visible = true;
                            lblErrroMessage.Text = "This Item is Already in Production";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showOrderDetailsModal();", true);
                        }
                        else
                        {
                            _objPartyMaster = new PartyMaster();
                            _objPartyMasterBL = new PartyMasterBL();
                            _objPartyMaster = _objPartyMasterBL.GetAllPartyMasterItems().Where(x => x.is_active == true && x.party_name.ToLower() == "self production").FirstOrDefault();

                            if(_objPartyMaster != null)
                            {
                                if(_objPartyMaster.party_master_id > 0)
                                {
                                    _RandomBatchNumber = GenerateRandomNo();
                                    _objProductionPlanningBL = new ProductionPlanningBL();

                                    _objProductionPlanning = new ProductionPlanning();
                                    _objProductionPlanning.guid = System.Guid.NewGuid();
                                    _objProductionPlanning.item_master_id = Convert.ToInt32(hdfdItemId.Value);
                                    _objProductionPlanning.item_brand = txtBrand.Text;
                                    _objProductionPlanning.item_model = txtModel.Text;
                                    _objProductionPlanning.item_type_name = txtItemType.Text;
                                    _objProductionPlanning.item_glass_color = txtGlassColor.Text;
                                   // _objProductionPlanning.party_master_id = 16; /* This is Static Value for Self Production  */
                                    _objProductionPlanning.party_master_id = _objPartyMaster.party_master_id; 

                                    _objProductionPlanning.order_quantity = 0;
                                    _objProductionPlanning.overall_total_item = 0;
                                    _objProductionPlanning.factory_stock = Convert.ToInt32(txtFactoryStock.Text);
                                    _objProductionPlanning.shortage = 0;
                                    _objProductionPlanning.stock_max_level = Convert.ToInt32(txtStockMaxLevel.Text);
                                    _objProductionPlanning.production_quantity = Convert.ToInt32(txtProductionQuantity.Text);

                                    _objProductionPlanning = _objProductionPlanningBL.CreateProductionPlanning(_objProductionPlanning);
                                    if (_objProductionPlanning.production_planning_id > 0)
                                    {
                                        _objProductionBL = new ProductionBL();
                                        // serach Here By using saleheaderid and PartyMasterid like ( Saleheaderid (1,2) and PatryMasterid (6,9) in where condition 
                                        _RandomSaleHeaderId = GenerateSaleHeaderRandomNo();
                                        App.BusinessModel.Production _objProduction = new App.BusinessModel.Production();
                                        _objProduction = _objProductionBL.GetAllProductionItems().Where(x => x.item_master_id == Convert.ToInt32(_objProductionPlanning.item_master_id) && x.sale_header_master_id == _RandomSaleHeaderId && x.party_master_id == _objProductionPlanning.party_master_id.ToString() && x.production_quantity == _objProductionPlanning.production_quantity).FirstOrDefault();
                                        if (_objProduction != null)
                                        {
                                            if (_objProduction.production_id != 0)
                                            {
                                                divError.Visible = true;
                                                lblErrroMessage.Visible = true;
                                                lblErrroMessage.Text = "This Item is Already in Production";
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showOrderDetailsModal();", true);
                                            }
                                            else
                                            {
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showOrderDetailsModal();", true);
                                            }
                                        }
                                        else
                                        {
                                            // Add Production When 0 Entry in Table
                                            _objProductionBL = new ProductionBL();
                                            _objProduction = _objProductionBL.CreateProduction(GetProductionDetailForSaveObject());
                                            if (_objProduction != null)
                                            {
                                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showProductionSubmitSuccess();", true);
                                            }
                                            else
                                            { }
                                        }
                                    }
                                }
                                else
                                {
                                    divError.Visible = true;
                                    lblErrroMessage.Visible = true;
                                    lblErrroMessage.Text = "Please Add Self Production Party for production";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showOrderDetailsModal();", true);
                                }
                            }
                            else
                            {
                                divError.Visible = true;
                                lblErrroMessage.Visible = true;
                                lblErrroMessage.Text = "Please Add Self Production Party for production";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showOrderDetailsModal();", true);
                            }
                           
                        }
                    }
                    else
                    {
                        _objPartyMaster = new PartyMaster();
                        _objPartyMasterBL = new PartyMasterBL();
                        _objPartyMaster = _objPartyMasterBL.GetAllPartyMasterItems().Where(x => x.is_active == true && x.party_name.ToLower() == "self production").FirstOrDefault();

                        if (_objPartyMaster != null)
                        {
                            if (_objPartyMaster.party_master_id > 0)
                            {
                                _RandomBatchNumber = GenerateRandomNo();
                                _objProductionPlanningBL = new ProductionPlanningBL();

                                _objProductionPlanning = new ProductionPlanning();
                                _objProductionPlanning.guid = System.Guid.NewGuid();
                                _objProductionPlanning.item_master_id = Convert.ToInt32(hdfdItemId.Value);
                                _objProductionPlanning.item_brand = txtBrand.Text;
                                _objProductionPlanning.item_model = txtModel.Text;
                                _objProductionPlanning.item_type_name = txtItemType.Text;
                                _objProductionPlanning.item_glass_color = txtGlassColor.Text;
                              //  _objProductionPlanning.party_master_id = 16; /* This is Static Value for Self Production  */
                                _objProductionPlanning.party_master_id = _objPartyMaster.party_master_id; 

                                _objProductionPlanning.order_quantity = 0;
                                _objProductionPlanning.overall_total_item = 0;
                                _objProductionPlanning.factory_stock = Convert.ToInt32(txtFactoryStock.Text);
                                _objProductionPlanning.shortage = 0;
                                _objProductionPlanning.stock_max_level = Convert.ToInt32(txtStockMaxLevel.Text);
                                _objProductionPlanning.production_quantity = Convert.ToInt32(txtProductionQuantity.Text);


                                _objProductionPlanning = _objProductionPlanningBL.CreateProductionPlanning(_objProductionPlanning);
                                if (_objProductionPlanning.production_planning_id > 0)
                                {
                                    _objProductionBL = new ProductionBL();
                                    // serach Here By using saleheaderid and PartyMasterid like ( Saleheaderid (1,2) and PatryMasterid (6,9) in where condition 

                                    _RandomSaleHeaderId = GenerateSaleHeaderRandomNo();

                                    App.BusinessModel.Production _objProduction = new App.BusinessModel.Production();
                                    _objProduction = _objProductionBL.GetAllProductionItems().Where(x => x.item_master_id == Convert.ToInt32(_objProductionPlanning.item_master_id) && x.sale_header_master_id == _RandomSaleHeaderId && x.party_master_id == _objProductionPlanning.party_master_id.ToString() && x.production_quantity == _objProductionPlanning.production_quantity).FirstOrDefault();
                                    if (_objProduction != null)
                                    {
                                        if (_objProduction.production_id != 0)
                                        {
                                            divError.Visible = true;
                                            lblErrroMessage.Visible = true;
                                            lblErrroMessage.Text = "This Item is Already in Production";
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showOrderDetailsModal();", true);
                                        }
                                        else
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showOrderDetailsModal();", true);
                                        }

                                    }
                                    else
                                    {
                                        // Add Production When 0 Entry in Table
                                        _objProductionBL = new ProductionBL();
                                        _objProduction = _objProductionBL.CreateProduction(GetProductionDetailForSaveObject());
                                        if (_objProduction != null)
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showProductionSubmitSuccess();", true);
                                        }
                                        else
                                        { }
                                    }
                                }
                            }
                            else
                            {
                                divError.Visible = true;
                                lblErrroMessage.Visible = true;
                                lblErrroMessage.Text = "Please Add Self Production Party for production";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showOrderDetailsModal();", true);
                            }
                        }
                        else
                        {
                            divError.Visible = true;
                            lblErrroMessage.Visible = true;
                            lblErrroMessage.Text = "Please Add Self Production Party for production";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showOrderDetailsModal();", true);
                        }

                       
                    }

                   
                    

                   // ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showOrderDetailsModal();", true);
                }

            }
            catch(Exception ex)
            {
                ex.Message.ToString();
                divError.Visible = true;
                lblErrroMessage.Visible = true;
                lblErrroMessage.Text = ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showOrderDetailsModal();", true);
            }
        }


        #region Get Production Planning Details 
        /// <summary>
        /// This Method is Used to Get Production Planning Details from ProductionPlanning  Object
        /// </summary>
        /// <returns></returns>
        private App.BusinessModel.Production GetProductionDetailForSaveObject()
        {
            try
            {

                _objProduction = new App.BusinessModel.Production();

                _objProduction.guid = System.Guid.NewGuid();
                _objProduction.item_master_id = _objProductionPlanning.item_master_id;

                _objProduction.item_brand = _objProductionPlanning.item_brand;
                _objProduction.item_model = _objProductionPlanning.item_model;
                _objProduction.item_glass_color = _objProductionPlanning.item_glass_color;
                _objProduction.item_type_name = _objProductionPlanning.item_type_name;

                _objProduction.sale_header_master_id = _RandomSaleHeaderId;
                // _objProduction.party_master_id = _objProductionPlanning.party_master_id;
                // _objProduction.sale_header_master_id = _particularSaleHeaderId;
                _objProduction.party_master_id = _objProductionPlanning.party_master_id.ToString();
                _objProduction.order_quantity = _objProductionPlanning.order_quantity;
                _objProduction.overall_total_item = _objProductionPlanning.overall_total_item;
                _objProduction.factory_stock = _objProductionPlanning.factory_stock;
                _objProduction.shortage = _objProductionPlanning.shortage;
                _objProduction.stock_max_level = _objProductionPlanning.stock_max_level;
                _objProduction.production_quantity = _objProductionPlanning.production_quantity;
                _objProduction.stock_max_level = _objProductionPlanning.stock_max_level;
                _objProduction.production_status = App.Helper.Utils.OrderStatus.added.ToString();
                _objProduction.batch_number = _RandomBatchNumber;
                _objProduction.batch_status = App.Helper.Utils.OrderStatus.added.ToString();
                _objProduction.production_planning_id = _objProductionPlanning.production_planning_id;

                _objProduction.started_on = _objProductionPlanning.created_on;
                _objProduction.planned_date = _objProductionPlanning.created_on;

                _objItemMasterBL = new ItemMasterBL();
                _objItemMaster = _objItemMasterBL.GetAllItemMasterItems().Where(x => x.item_master_id == Convert.ToInt32(_objProductionPlanning.item_master_id)).FirstOrDefault();
                if (_objItemMaster != null)
                {

                    _objProduction.is_under_cutting = Convert.ToBoolean(Convert.ToInt32("1"));
                    _objProduction.is_under_grinding = Convert.ToBoolean(Convert.ToInt32("1"));
                    _objProduction.is_under_washing_one = _objItemMaster.washing_one;
                    _objProduction.is_under_hole = _objItemMaster.hole_required;
                    _objProduction.is_under_washing = _objItemMaster.washing_two;
                    //Check Paint Status If Is_Normal_Paint True then Is_Normal_Paint else Is_Black_Paint
                    _objProduction.is_under_paint = _objItemMaster.is_normal_paint == Convert.ToBoolean(Convert.ToInt32("0")) ? _objItemMaster.is_black_paint : _objItemMaster.is_normal_paint;
                    _objProduction.is_under_dfg_print = _objItemMaster.is_dfg_paint;
                    _objProduction.is_under_tempering = Convert.ToBoolean(Convert.ToInt32("1"));
                    _objProduction.is_under_packing = Convert.ToBoolean(Convert.ToInt32("1"));
                    _objProduction.is_under_store = Convert.ToBoolean(Convert.ToInt32("1"));

                }
                else
                {
                    _objProduction.is_under_cutting = Convert.ToBoolean(Convert.ToInt32("0"));
                    _objProduction.is_under_grinding = Convert.ToBoolean(Convert.ToInt32("0"));
                    _objProduction.is_under_hole = Convert.ToBoolean(Convert.ToInt32("0"));
                    _objProduction.is_under_washing = Convert.ToBoolean(Convert.ToInt32("0"));
                    _objProduction.is_under_paint = Convert.ToBoolean(Convert.ToInt32("0"));
                    _objProduction.is_under_dfg_print = Convert.ToBoolean(Convert.ToInt32("0"));
                    _objProduction.is_under_tempering = Convert.ToBoolean(Convert.ToInt32("0"));
                    _objProduction.is_under_packing = Convert.ToBoolean(Convert.ToInt32("0"));
                    _objProduction.is_under_store = Convert.ToBoolean(Convert.ToInt32("0"));
                }






                //Convert.ToDateTime(_objStaffMaster.staff_joinning_date).ToString("MM/dd/yyyy");
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objProduction;
        }
        #endregion

        #region Generate Random Number

        public static string GenerateRandomNo()
        {
            int _min = 100000;
            int _max = 999999;
            Random _rdm = new Random();
            return Convert.ToString(_rdm.Next(_min, _max));
        }

        public static string GenerateSaleHeaderRandomNo()
        {
            int _min = 900001;
            int _max = 999999;
            Random _rdm = new Random();
            return Convert.ToString(_rdm.Next(_min, _max));
        }


        #endregion

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                txtProductionQuantity.Text = "0";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showOrderDetailsModal();", true);
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }
}