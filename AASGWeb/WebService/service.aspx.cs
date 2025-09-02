using App.BusinessModel;
using App.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace AASGWeb.WebService
{
    public partial class service : System.Web.UI.Page
    {
        #region Global Properties
        //ActivityLog _objActivityLog = new ActivityLog();
        //ActivityLogBL _objActivityLogBL = null;
        //List<ActivityLog> _lstActivityLog = new List<ActivityLog>();

        App.BusinessModel.SaleHeader _objSaleHeader = new App.BusinessModel.SaleHeader();
        App.Business.SaleHeaderBL _objSaleHeaderBL = null;
        List<App.BusinessModel.SaleHeader> _lstSaleHeader = new List<App.BusinessModel.SaleHeader>();

        DataTable _dataTableItemsList = new DataTable();
        string UserIp = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod(enableSession: true)]
        public static string AuthenticateUser(string UserName, string Password)
        {
            App.BusinessModel.StaffMaster _objStaffMaster = new App.BusinessModel.StaffMaster();
            StaffMaster _appStaffObject = new StaffMaster();
            App.Business.StaffMasterBL _objStaffMasterBL = null;
            _objStaffMasterBL = new App.Business.StaffMasterBL();
            var _JavaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            try
            {
                _objStaffMaster = _objStaffMasterBL.GetAllStaffMasterItems().Where(x => x.staff_email.ToLower() == UserName.ToLower() && x.staff_password == Password && x.is_active == true).FirstOrDefault();

                if (_objStaffMaster != null)
                {
                    return  JsonConvert.SerializeObject(_objStaffMaster);
                }
                else
                {
                    _objStaffMaster = new StaffMaster();
                    _objStaffMaster.staff_master_id = 0;
                    return JsonConvert.SerializeObject(_objStaffMaster);
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                _objStaffMaster = new StaffMaster();
                _objStaffMaster.staff_master_id = 0;
                return JsonConvert.SerializeObject(_objStaffMaster);
            }
            //return _JavaScriptSerializer.Serialize(_objStaffMaster);
        }

        #region Sale Order Method Add/Delete/Get etc..

        #region Add Sale Order
        
        [WebMethod(enableSession: true)]
        public static string AddSaleOrder(Sale _objSaleJson) 
        {
            App.BusinessModel.Sale _objSale = new App.BusinessModel.Sale();
           // _objSale = Newtonsoft.Json.JsonConvert.DeserializeObject<Sale>(_objSaleJson);
            
            App.BusinessModel.SaleHeader _objSaleHeader = new App.BusinessModel.SaleHeader();
            //_objSaleHeader = Newtonsoft.Json.JsonConvert.DeserializeObject<SaleHeader>(_objSaleJson);
          //  _objSale = _objSaleJson;
            App.Business.SaleHeaderBL _objSaleHeaderBL = null;
            _objSaleHeaderBL = new App.Business.SaleHeaderBL();

            App.BusinessModel.SaleItem _objSaleItem = new App.BusinessModel.SaleItem();
            App.Business.SaleItemBL _objSaleItemBL = null;
            _objSaleItemBL = new App.Business.SaleItemBL();

            var _JavaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(_objSaleJson);
            try
            {
              
                    _objSaleHeader = new SaleHeader();
                    _objSaleHeader.party_master_id = _objSale.party_master_id;
                    _objSaleHeader.total_items = _objSale.total_items;
                    _objSaleHeader.sale_item_date = _objSale.sale_item_date;
                    _objSaleHeader = _objSaleHeaderBL.CreateSaleHeader(_objSaleHeader);

                    if (_objSaleHeader.sale_header_id !=0)
                    {
                        
                        foreach (SaleItem _saleItem in _objSale.sale_items)
                        {
                        _objSaleItem.sale_item_name = _saleItem.sale_item_name;
                            //_objSaleItem.sale_header_id = _objSaleHeader.sale_header_id;
                            //_objSaleItem.item_master_id = Convert.ToInt32(_saleItem.[i]["item_id"].ToString());
                            //_objSaleItem.party_master_id = _objSaleHeader.party_master_id;
                            //_objSaleItem.sale_item_type_id = Convert.ToInt32(_dataTableItemsList.Rows[i]["item_id"].ToString());
                            //_objSaleItem.sale_item_id = Convert.ToInt32(_dataTableItemsList.Rows[i]["item_id"].ToString());
                            //_objSaleItem.sale_item_name = _dataTableItemsList.Rows[i]["item_name"].ToString();
                            //_objSaleItem.sale_item_quantity = Convert.ToInt32(_dataTableItemsList.Rows[i]["item_quantity"].ToString());
                            //_objSaleItem.sale_item_price = Convert.ToInt32(_dataTableItemsList.Rows[i]["item_price"].ToString());

                        //_objSaleItem.sale_header_id = _objSaleHeader.sale_header_id;
                        //_objSaleItem = _objSaleItemBL.CreateSaleItem(_objSaleItem);
                    }
                    }

                    return JsonConvert.SerializeObject(_objSale);
               
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                _objSale = new Sale();
                _objSale.sale_header_id = 0;
                return JsonConvert.SerializeObject(_objSale);
            }
            //return _JavaScriptSerializer.Serialize(_objStaffMaster);
        }

        #endregion

        #endregion



    }
}