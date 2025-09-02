using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App.Core;
using App.Business;
using App.BusinessModel;

namespace AASGWeb.Modules.Billing
{
    public partial class challan : System.Web.UI.Page
    {
        #region Global Properties

        App.BusinessModel.SaleHeader _objSaleHeader = new App.BusinessModel.SaleHeader();
        App.Business.SaleHeaderBL _objSaleHeaderBL = null;
        List<App.BusinessModel.SaleHeader> _lstSaleHeader = new List<App.BusinessModel.SaleHeader>();

        List<App.BusinessModel.vwSaleHeaderPartyDetail> _lstSaleHeaderPartyDetail = new List<App.BusinessModel.vwSaleHeaderPartyDetail>();

        List<App.BusinessModel.vwSaleOrderDashboardData> _lstvwSaleOrderDashboardDetail = new List<App.BusinessModel.vwSaleOrderDashboardData>();
        App.BusinessModel.vwSaleOrderDashboardData _objvwSaleOrderDashboardDetail = new App.BusinessModel.vwSaleOrderDashboardData();

        LoadingMaster _objLoadingMaster = new LoadingMaster();
        LoadingMasterBL _objLoadingMasterBL = null;
        List<LoadingMaster> _lstLoadingMaster = new List<LoadingMaster>();

        SaleItem _objSaleItem = new SaleItem();
        SaleItemBL _objSaleItemBL = null;
        List<SaleItem> _lstSaleItem = new List<SaleItem>();

        ChallanHeader _objChallanHeader = new ChallanHeader();
        ChallanHeaderBL _objChallanHeaderBL = null;
        List<ChallanHeader> _lstChallanHeader = new List<ChallanHeader>();

        ItemMaster _objItemMaster = new ItemMaster();
        ItemMasterBL _objItemMasterBL = null;
        List<ItemMaster> _lstItemMaster = new List<ItemMaster>();

        string UserIp = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindSaleOrderrptr();
               
            }
        }

        #region Pageload method

        private void BindSaleOrderrptr()
        {
            _objSaleHeaderBL = new SaleHeaderBL();
            //order Status Should be complete, Replace After Code done and Dynamic 
            _lstSaleHeaderPartyDetail = _objSaleHeaderBL.GetAllSaleHeaderItemsWithPatryDetails().OrderByDescending(x => x.sale_header_id).ToList();
            rptrSaleOrder.DataSource = _lstSaleHeaderPartyDetail;
            rptrSaleOrder.DataBind();
        }



        #endregion

        protected void rptrSaleOrder_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                string commandname = e.CommandName;
                string id = e.CommandArgument.ToString();
                hdfdSaleOrderId.Value = id;

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
                            _objSaleHeaderBL = new SaleHeaderBL();

                            _objSaleHeader = _objSaleHeaderBL.GetSaleHeaderItemsByID(Convert.ToInt32(hdfdSaleOrderId.Value)).FirstOrDefault();

                            if(_objSaleHeader != null)
                            {
                                _objLoadingMasterBL = new LoadingMasterBL();
                                _objLoadingMaster = _objLoadingMasterBL.GetLoadingMasterItemsByOrderNumber(_objSaleHeader.order_number).FirstOrDefault();

                                if(_objLoadingMaster != null)
                                {
                                    string url = "challan-details/" + App.Core.DataSecurity.Encryptdata(id).ToString();

                                    Response.Redirect(url, false);
                                }
                                else
                                {
                                    _lstSaleItem = new List<SaleItem>();
                                    _objSaleItemBL = new SaleItemBL();
                                    _lstSaleItem = _objSaleItemBL.GetAllSaleItemItems().Where(x => x.sale_header_id == Convert.ToInt32(hdfdSaleOrderId.Value)).ToList();

                                    int _loadingItemCount = 0;
                                    if(_lstSaleItem != null)
                                    {
                                        _objLoadingMaster = new LoadingMaster();

                                        foreach (var _saleItemIndex in _lstSaleItem)
                                        {
                                            _objLoadingMaster.order_number = _objSaleHeader.order_number;

                                            _objLoadingMaster = _objLoadingMasterBL.CreateLoadingMaster(GetLoadingMasterDetailsObject(_saleItemIndex));

                                            if (_objLoadingMaster != null)
                                            {
                                                _loadingItemCount = _loadingItemCount + 1;
                                            }
                                            else
                                            { }

                                        }
                                        
                                    }
                                    else { }

                                    if(_loadingItemCount > 0)
                                    {
                                        string url = "challan-details/" + App.Core.DataSecurity.Encryptdata(id).ToString();

                                        Response.Redirect(url, false);
                                    }
                                    else  { }
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
                        break;
                    case "challan":
                        try
                        {
                            _objSaleHeaderBL = new SaleHeaderBL();

                            _objSaleHeader = _objSaleHeaderBL.GetSaleHeaderItemsByID(Convert.ToInt32(hdfdSaleOrderId.Value)).FirstOrDefault();

                            if (_objSaleHeader != null)
                            {
                                _objLoadingMasterBL = new LoadingMasterBL();
                                _objLoadingMaster = _objLoadingMasterBL.GetLoadingMasterItemsByOrderNumber(_objSaleHeader.order_number).FirstOrDefault();

                                if (_objLoadingMaster != null)
                                {
                                    string url = "add-challan/" + App.Core.DataSecurity.Encryptdata(id).ToString() + "/" + App.Core.DataSecurity.Encryptdata(_objLoadingMaster.loading_master_id.ToString()).ToString();
                                    Response.Redirect(url, false);

                                    //_objChallanHeaderBL = new ChallanHeaderBL();
                                    //_lstChallanHeader = _objChallanHeaderBL.GetChallanHeaderItemsByOrderNumber(_objLoadingMaster.order_number).ToList();

                                    //if (_lstChallanHeader != null)
                                    //{
                                    //    if(_lstChallanHeader.Count > 1)
                                    //    {
                                    //        string url = "challan-print/" + App.Core.DataSecurity.Encryptdata(id).ToString();
                                    //        Response.Redirect(url, false);
                                    //    }
                                    //    else
                                    //    {
                                    //        string url = "add-challan/" + App.Core.DataSecurity.Encryptdata(id).ToString() + "/" + App.Core.DataSecurity.Encryptdata(_objLoadingMaster.loading_master_id.ToString()).ToString();
                                    //        Response.Redirect(url, false);
                                    //    }

                                    //}
                                    //else
                                    //{   
                                    //    string url = "add-challan/" + App.Core.DataSecurity.Encryptdata(id).ToString() + "/" + App.Core.DataSecurity.Encryptdata(_objLoadingMaster.loading_master_id.ToString()).ToString();
                                    //    Response.Redirect(url, false);
                                    //}


                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlertGenerateLoadingSlip();", true);
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
            catch(Exception ex)
            {
                ex.Message.ToString();
            }

        }

        protected void rptrSaleOrder_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {


                    Label lblOrderStatus = (Label)e.Item.FindControl("lblOrderStatus");
                    //CheckBox chkActive=(CheckBox)e.Item.FindControl("chkActive");
                    string isOrder_status = lblOrderStatus.Text;
                    if (isOrder_status == "pending")
                    {

                        lblOrderStatus.CssClass = "label label-primary";
                        //chkActive.Checked=true;

                    }
                    else if (isOrder_status == "approved")
                    {
                        lblOrderStatus.CssClass = "label label-success";
                    }
                    else if (isOrder_status == "complete")
                    {
                        lblOrderStatus.CssClass = "label label-success";
                    }
                    else
                    {
                        lblOrderStatus.CssClass = "label label-danger";
                        //chkActive.Checked = false;

                    }

                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "notification('Something went wrong','danger');", true);
            }
        }

        #region Get Loading Details From SaleHeader Object
        /// <summary>
        /// This Method is Used to Get Loading Details From SaleHeader Object
        /// </summary>
        /// <returns></returns>
        private LoadingMaster GetLoadingMasterDetailsObject( SaleItem _objSaleItem)
        {
            try
            {
               // _objLoadingMaster = new LoadingMaster();

                _objLoadingMaster.guid = Guid.NewGuid();
                _objLoadingMaster.sale_header_id = _objSaleItem.sale_header_id;
                _objLoadingMaster.item_master_id = _objSaleItem.item_master_id;
                _objLoadingMaster.party_master_id = _objSaleItem.party_master_id;
                _objLoadingMaster.sale_item_type_id = _objSaleItem.sale_item_type_id;
                _objLoadingMaster.sale_item_type_title = _objSaleItem.sale_item_type_title;
                _objLoadingMaster.sale_item_name = _objSaleItem.sale_item_name;
                _objLoadingMaster.sale_item_quantity = _objSaleItem.sale_item_quantity;
                _objLoadingMaster.sale_item_price = _objSaleItem.sale_item_price;

                if(_objSaleItem.item_weight > 0)
                {
                    _objLoadingMaster.item_weight = _objSaleItem.item_weight;
                }
                else
                {
                    _objItemMasterBL = new ItemMasterBL();
                    _objItemMaster = _objItemMasterBL.GetItemMasterItemsByID(_objSaleItem.item_master_id).FirstOrDefault();

                    if (_objItemMaster != null)
                    {
                        _objLoadingMaster.item_weight = Convert.ToDecimal(_objItemMaster.item_weight.ToString());
                    }
                    else
                    {
                        _objLoadingMaster.item_weight = Convert.ToDecimal(0);
                    }

                }
                
               

                //Convert.ToDateTime(_objStaffMaster.staff_joinning_date).ToString("MM/dd/yyyy");


            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objLoadingMaster;
        }

        #endregion

    }
}