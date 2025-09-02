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
using System.Data.SqlClient;

namespace AASGWeb.Modules.Production
{
    public partial class plan_production_party : System.Web.UI.Page
    {
        #region Global Properties
        ActivityLog _objActivityLog = new ActivityLog();
        ActivityLogBL _objActivityLogBL = null;
        List<ActivityLog> _lstActivityLog = new List<ActivityLog>();

        ItemMaster _objItemMaster = new ItemMaster();
        ItemMasterBL _objItemMasterBL = null;
        List<ItemMaster> _lstItemMaster = new List<ItemMaster>();

        PartyMaster _objPartyMaster = new PartyMaster();
        PartyMasterBL _objPartyMasterBL = null;
        List<PartyMaster> _lstPartyMaster = new List<PartyMaster>();

        ProductionPlanning _objProductionPlanning = new ProductionPlanning();
        ProductionPlanningBL _objProductionPlanningBL = null;
        List<ProductionPlanning> _lstProductionPlanning = new List<ProductionPlanning>();

        App.BusinessModel.Production _objProduction = new App.BusinessModel.Production();
        ProductionBL _objProductionBL = null;
        List<App.BusinessModel.Production> _lstProduction = new List<App.BusinessModel.Production>();

        SaleHeader _objSaleHeader = new SaleHeader();
        SaleHeaderBL _objSaleHeaderBL = null;
        List<SaleHeader> _lstSaleHeader = new List<SaleHeader>();


        string UserIp = string.Empty;
        
        public static int _particularSaleHeaderId = 0;
        public static string _RandomBatchNumber = string.Empty;
        string[] arrOfProductionPartyNameForWorkOrderNumber, arrofPartyWiseFirstChar;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            // Page.MaintainScrollPositionOnPostBack = true;
            //if (!IsPostBack)
            //{

            //    string _saleOrderid, _salepartyId;
            //    if (RouteData.Values["id"] == null)
            //    {
            //        // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "editorInit();", true);
            //    }
            //    else
            //    {

            //        string saleOrderId = RouteData.Values["id"].ToString();
            //        //string salepartyId = RouteData.Values["partyid"].ToString();
            //        _saleOrderid = App.Core.DataSecurity.Decryptdata(saleOrderId);
            //        //_salepartyId = App.Core.DataSecurity.Decryptdata(salepartyId);
            //        if (_saleOrderid == "" || _saleOrderid == null)
            //        {
            //            Response.Redirect("/home", false);
            //        }
            //        else
            //        {
            //            hdnfSaleOrderId.Value = _saleOrderid;

            //            if (hdnfSaleOrderId.Value == "")
            //            {
            //                Response.Redirect("/home", false);

            //            }
            //            else
            //            {
            //                //PopulateData(_itemid);
            //            }

            //        }


            //    }
            //}

            foreach(GridViewRow row in grdPlanProductions.Rows)
            {
                Boolean _chkSelectedItemcount = ((CheckBox)row.FindControl("chkSelectedItem")).Checked;
                if(_chkSelectedItemcount == true)
                {
                    int itemMasterId = Convert.ToInt32(row.Cells[2].Text);

                    _objProductionBL = new ProductionBL();
                    _lstProduction = _objProductionBL.GetAllProductionItems().OrderByDescending(x => x.production_id).ToList();

                    var masterId = _lstProduction.Where(x => x.item_master_id == itemMasterId).FirstOrDefault();
                    var iscomplete = _lstProduction.Where(x => x.production_status == "complete" && x.item_master_id == itemMasterId).FirstOrDefault();
                    var isCopAndIsPro = _lstProduction.Where(x => x.production_status == "complete" && x.production_status == "production" && x.item_master_id == itemMasterId).FirstOrDefault();

                    if(masterId != null)
                    {
                        row.ForeColor = System.Drawing.Color.Red;
                        if (iscomplete != null)
                        {
                            row.ForeColor = System.Drawing.Color.Black;
                            if(isCopAndIsPro != null)
                            {
                                row.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                    }
                }
            }


            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                string _saleorderid, _salepartyid;
                if (RouteData.Values["id"] == null)
                {
                    // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "editorInit();", true);
                }
                else
                {
                    string SaleHeaderIds = RouteData.Values["id"].ToString();
                    string SalePartyIds = RouteData.Values["partyid"].ToString();
                    _saleorderid = App.Core.DataSecurity.Decryptdata(SaleHeaderIds);
                    _salepartyid = App.Core.DataSecurity.Decryptdata(SalePartyIds);
                    hdnfPartyMasterIds.Value = _salepartyid.ToString();
                    if (_saleorderid == "" || _saleorderid == null)
                    {
                        Response.Redirect("/home", false);
                    }
                    else
                    {
                        hdnSaleOrderIds.Value = _saleorderid;

                        if (hdnSaleOrderIds.Value == "")
                        {
                            Response.Redirect("/home", false);

                        }
                        else
                        {
                            _RandomBatchNumber = string.Empty;
                            PopulateGrid(_saleorderid, _salepartyid);
                        }
                    }

                }
            }


        }

        private void PopulateGrid(string SaleHeaderIds, string PartyMasterIds)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);

            using (SqlCommand cmd2 = new SqlCommand("sp_PlanPartyPartyProduction", con))
            {
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@SaleHeaderId", SaleHeaderIds);
                cmd2.Parameters.AddWithValue("@PartyMasterId", PartyMasterIds);  //"8"

                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                sda.Fill(dt);


                //grdPlanProductions.Columns.Clear();

                if (dt.Rows.Count > 0)
                {
                    //dt.Columns.Add("MyTextBoxColumn", typeof(TextBox));
                    //DataTable dt2 = new DataTable();
                    //dt2 = dt;
                    grdPlanProductions.DataSource = dt;
                    grdPlanProductions.DataBind();
                    //grdPlanProductions.Columns.Add();
                    //foreach (DataControlField coloumn in grdPlanProductions.Columns)
                    //{

                    //    //dt.Columns.Add(coloumn);
                    //}


                }
            }
        }


        private string GetLatestWorkOrderNumber()
        {
            string _workOrderNumber = string.Empty;
            try
            {

                string _connectionstring = (ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                using (SqlConnection _sqlConnection = new SqlConnection(_connectionstring))
                {
                    string _query = "select RANK() OVER (order by batch_number) as batch_number from Production  group by batch_number";
                    _sqlConnection.Open();
                    using (SqlCommand _sqlCommand = new SqlCommand(_query, _sqlConnection))
                    {

                        _sqlCommand.CommandTimeout = 600;
                        SqlDataAdapter _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
                        DataTable _datatable = new DataTable();
                        _sqlDataAdapter.Fill(_datatable);
                        if (_datatable.Rows.Count > 0)
                        {

                            return _workOrderNumber = (_datatable.Rows.Count+1).ToString();
                        }
                        else
                        {

                            return _workOrderNumber="1";
                        }

                        _sqlConnection.Close();
                    }
                }

                return _workOrderNumber = "1";
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
                return _workOrderNumber = "1";
            }
        }





        protected void btnProceedToProduction_Click(object sender, EventArgs e)
        {
            try
            {
                string production_quantity_check = string.Empty;
                int _selectedItemQuantity = 0;
                _objPartyMasterBL = new PartyMasterBL();
                foreach (GridViewRow row in grdPlanProductions.Rows)
                {
                    //production_quantity_check = ((TextBox)row.FindControl("txtProductQuantity")).Text;
                    //int totalindexid = GetColumnIndex("Total");


                    Boolean _chkSelectedItemcount = ((CheckBox)row.FindControl("chkSelectedItem")).Checked;

                    if (_chkSelectedItemcount == true)
                    {
                        production_quantity_check = ((TextBox)row.FindControl("txtProductQuantity")).Text;
                        if (production_quantity_check == "")
                        {
                            production_quantity_check = "0";

                        }
                        else
                        {

                        }
                        _selectedItemQuantity = _selectedItemQuantity + 1;
                    }
                    else
                    {

                    }


                }

                if (_selectedItemQuantity != 0 && _selectedItemQuantity > 0)
                {
                    if (production_quantity_check == "0")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showProductionQuantityAlert();", true);
                    }
                    else
                    {
                        if (hdnfPartyMasterIds.Value == null)
                        {
                        }
                        else
                        {
                            string partymasterid = hdnfPartyMasterIds.Value;
                            string partyFirstChar = partymasterid.TrimEnd(',');
                            arrOfProductionPartyNameForWorkOrderNumber = partyFirstChar.Split(',');
                        }
                        _RandomBatchNumber = string.Empty;
                        string _partyNameBind = string.Empty;
                        for (int _IndexofPartyMasterId = 0; _IndexofPartyMasterId < arrOfProductionPartyNameForWorkOrderNumber.Length; _IndexofPartyMasterId++)
                        {

                            _objPartyMaster = _objPartyMasterBL.GetAllPartyMasterItems().Where(x => x.party_master_id == Convert.ToInt32(arrOfProductionPartyNameForWorkOrderNumber[_IndexofPartyMasterId])).FirstOrDefault();
                            if (_objPartyMaster != null)
                            {


                                arrofPartyWiseFirstChar = _objPartyMaster.party_name.ToString().Split(' ');

                                for (int _subName = 0; _subName < arrofPartyWiseFirstChar.Length; _subName++)
                                {
                                    _partyNameBind = _partyNameBind + arrofPartyWiseFirstChar[_subName].Substring(0, 1).ToUpper();

                                }

                                _partyNameBind = _partyNameBind + '-';

                            }
                        }

                        _RandomBatchNumber = _partyNameBind + GetLatestWorkOrderNumber();


                        // _RandomBatchNumber = GenerateRandomNo();


                        //Response.Redirect("production/plan-productions-detail");
                        int count = 0;
                        foreach (GridViewRow row in grdPlanProductions.Rows)
                        {
                            _objProductionPlanning = new ProductionPlanning();

                            _objProductionPlanning.guid = Guid.NewGuid();

                            Boolean _chkSelectedItem = ((CheckBox)row.FindControl("chkSelectedItem")).Checked;

                            if (_chkSelectedItem == true)
                            {
                                string production_quantity = ((TextBox)row.FindControl("txtProductQuantity")).Text;
                                if (production_quantity == "")
                                {
                                    //production_quantity = "0";
                                    _objProductionPlanning.production_quantity = 0;
                                }
                                else
                                {
                                    int numeric;
                                    if (int.TryParse(production_quantity, out numeric) == true)
                                    {
                                        //production_quantity = numeric.ToString();
                                        _objProductionPlanning.production_quantity = numeric;
                                    }
                                    else
                                    {
                                        //production_quantity = "0";
                                        _objProductionPlanning.production_quantity = 0;
                                    }
                                }

                                _objProductionPlanning.item_master_id = Convert.ToInt32(row.Cells[2].Text);

                                //int item_master_id = Convert.ToInt32(row.Cells[1].Text);

                                _objProductionPlanning.item_brand = row.Cells[4].Text;



                                //string brand = row.Cells[2].Text;
                                _objProductionPlanning.item_model = row.Cells[5].Text;

                                //string model = row.Cells[3].Text;
                                _objProductionPlanning.item_type_name = row.Cells[6].Text;
                                //string item_type_name = row.Cells[4].Text;

                                _objProductionPlanning.item_glass_color = row.Cells[7].Text;

                                string party_name = string.Empty;
                                int party_order_quantity = 0;

                                //List<string> party = new List<string>();
                                //List<string> party_quantity = new List<string>();


                                int totalindexid = GetColumnIndex("Total");

                                _objProductionPlanning.overall_total_item = Convert.ToInt32(row.Cells[totalindexid + 1].Text);
                                //string overalltotal = row.Cells[totalindexid + 1].Text;

                                _objProductionPlanning.factory_stock = Convert.ToInt32(row.Cells[totalindexid + 2].Text);
                                //string factorystock = row.Cells[totalindexid + 2].Text;

                                _objProductionPlanning.shortage = Convert.ToInt32(row.Cells[totalindexid + 3].Text);
                                //string shortage = row.Cells[totalindexid + 3].Text;

                                _objProductionPlanning.stock_max_level = Convert.ToInt32(row.Cells[totalindexid + 4].Text);
                                //string stock_max_level = row.Cells[totalindexid + 4].Text;


                                for (int i = 8; i < totalindexid; i++)
                                {
                                    int party_master_id = 0;
                                    party_name = GetColumnName(i);
                                    _objPartyMasterBL = new PartyMasterBL();
                                    _objPartyMaster = _objPartyMasterBL.GetAllPartyMasterItems().Where(x => x.party_name == party_name).FirstOrDefault();
                                    if (_objPartyMaster.party_master_id > 0)
                                    {
                                        party_master_id = _objPartyMaster.party_master_id;
                                        //party.Add(party_master_id.ToString());

                                        _objProductionPlanning.party_master_id = party_master_id;

                                        party_order_quantity = Convert.ToInt32(row.Cells[i].Text);
                                        //party_quantity.Add(party_order_quantity.ToString());
                                        _objProductionPlanning.order_quantity = party_order_quantity;
                                    }
                                    else
                                    {
                                        //party_master_id = 0;
                                        //party_order_quantity = 0;
                                        _objProductionPlanning.party_master_id = 0;
                                        _objProductionPlanning.order_quantity = 0;
                                    }
                                    _objProductionPlanningBL = new ProductionPlanningBL();
                                    _objProductionPlanning = _objProductionPlanningBL.CreateProductionPlanning(_objProductionPlanning);
                                    if (_objProductionPlanning.production_planning_id > 0)
                                    {
                                        count++;

                                        if (_objProductionPlanning.order_quantity > 0)
                                        {
                                            _objProductionBL = new ProductionBL();

                                            // serach Here By using saleheaderid and PartyMasterid like ( Saleheaderid (1,2) and PatryMasterid (6,9) in where condition

                                            App.BusinessModel.Production _objProduction = new App.BusinessModel.Production();
                                            _objProduction = _objProductionBL.GetAllProductionItems().Where(x => x.item_master_id == Convert.ToInt32(_objProductionPlanning.item_master_id) && x.sale_header_master_id == hdnSaleOrderIds.Value && x.party_master_id == hdnfPartyMasterIds.Value && x.production_quantity == _objProductionPlanning.production_quantity).FirstOrDefault();
                                            if (_objProduction != null)
                                            {
                                                if (_objProduction.production_id != 0)
                                                {

                                                }
                                                else
                                                {

                                                }

                                            }
                                            else
                                            {
                                                // Add Production When 0 Entry in Table


                                                _objProductionBL = new ProductionBL();
                                                _objProduction = _objProductionBL.CreateProduction(GetProductionDetailForSaveObject());
                                                if (_objProduction != null)
                                                {

                                                }
                                                else
                                                {

                                                }
                                                //if (!string.IsNullOrEmpty(_saleorderid))
                                                //{
                                                //    string lasttm = _saleorderid.TrimEnd(',');
                                                //    string[] arrOfSelections = lasttm.Split(',');
                                                //    for (int _sale_Order_Id = 0; _sale_Order_Id == 0; _sale_Order_Id++)
                                                //    {
                                                //        _particularSaleHeaderId = Convert.ToInt32(arrOfSelections[_sale_Order_Id]);
                                                //    }

                                                //}
                                                //else
                                                //{

                                                //}
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

                            }



                            //foreach (string str in party)
                            //{

                            //}




                            //Foreach Loop End Here

                        }
                        if (count > 0)
                        {

                            _objSaleHeaderBL = new SaleHeaderBL();
                            string _saleorderid = hdnSaleOrderIds.Value;

                            if (!string.IsNullOrEmpty(_saleorderid))
                            {
                                string lasttm = _saleorderid.TrimEnd(',');
                                string[] arrOfSelections = lasttm.Split(',');
                                foreach (string saleheaderid in arrOfSelections)
                                {
                                    _objSaleHeaderBL = new SaleHeaderBL();
                                    _objSaleHeader = _objSaleHeaderBL.GetAllSaleHeaderItems().Where(x => x.sale_header_id == Convert.ToInt32(saleheaderid)).FirstOrDefault();
                                    {
                                        if (_objSaleHeader.sale_header_id > 0)
                                        {

                                            //_objSaleHeader.order_status = "In production";
                                            _objSaleHeader.order_status = App.Helper.Utils.OrderStatus.production.ToString();
                                            _objSaleHeader = _objSaleHeaderBL.UpdateSaleHeader(_objSaleHeader);
                                        }
                                    }
                                }
                            }

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showProductionSubmitSuccess();", true);
                            btnProceedToProduction.Visible = false;
                            _particularSaleHeaderId = 0;
                            _RandomBatchNumber = string.Empty;
                        }

                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "notification('Please Select Any Item for Production !','danger');", true);
                }
            }
            catch(Exception ex)
            {
                ex.Message.ToString();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
           
           



        }

        #region Generate Random Number

        public static string GenerateRandomNo()
        {
            int _min = 100000;
            int _max = 999999;
            Random _rdm = new Random();
            return Convert.ToString(_rdm.Next(_min, _max));
        }
        #endregion

        private int GetColumnIndex(string columnName)
        {
            int colindex = 0;
            for (int i = 0; i < grdPlanProductions.HeaderRow.Cells.Count; i++)
            {
                string colname = grdPlanProductions.HeaderRow.Cells[i].Text;
                if (colname == columnName)
                {
                    colindex = i;
                    break;
                }
            }
            return colindex;
        }

        private string GetColumnName(int id)
        {
            string colname=string.Empty;
            for (int i = 0; i < grdPlanProductions.HeaderRow.Cells.Count; i++)
            {
                colname = grdPlanProductions.HeaderRow.Cells[id].Text;
                break;
            }
            return colname;
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

                _objProduction.sale_header_master_id = hdnSaleOrderIds.Value;
               // _objProduction.party_master_id = _objProductionPlanning.party_master_id;
               // _objProduction.sale_header_master_id = _particularSaleHeaderId;
                 _objProduction.party_master_id = hdnfPartyMasterIds.Value;
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
                    _objProduction.is_under_paint = _objItemMaster.is_normal_paint== Convert.ToBoolean(Convert.ToInt32("0"))? _objItemMaster.is_black_paint: _objItemMaster.is_normal_paint;
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
    }
}