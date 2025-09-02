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
    public partial class challan_slip : System.Web.UI.Page
    {
        #region Global Properties

        SaleItem _objSaleItem = new SaleItem();
        SaleItemBL _objSaleItemBL = null;
        List<SaleItem> _lstSaleItem = new List<SaleItem>();

        vwSaleHeaderPartyDetail _objvwSaleHeader = new vwSaleHeaderPartyDetail();
        SaleHeader _objSaleHeader = new SaleHeader();
        SaleHeaderBL _objSaleHeaderBL = null;
        List<SaleHeader> _lstSaleHeader = new List<SaleHeader>();

        List<vwSaleHeaderPartyDetail> _lstSaleHeaderPartyDetail = new List<vwSaleHeaderPartyDetail>();

        ItemMaster _objItemMaster = new ItemMaster();
        ItemMasterBL _objItemMasterBL = null;
        List<ItemMaster> _lstItemMaster = new List<ItemMaster>();

        string UserIp = string.Empty;
        public static Decimal _totalAmount = 0;
        public static int _itemTotalCount = 0;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _sale_header_id;
                if (RouteData.Values["id"] == null)
                {
                    // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "editorInit();", true);
                }
                else
                {
                    
                    string sale_header_id = RouteData.Values["id"].ToString();
                    _sale_header_id = App.Core.DataSecurity.Decryptdata(sale_header_id);
                    hdfdSaleOrderId.Value = _sale_header_id;
                    if (_sale_header_id == "" || _sale_header_id == null)
                    {
                        Response.Redirect("/home", false);
                    }
                    else
                    {
                        _totalAmount = 0;_itemTotalCount = 0;
                        GetSaleOrderPartyDetails(_sale_header_id);

                    }


                }
            }

        }

        protected void rptrOrder_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    Label lblUserName = e.Item.FindControl("lblUserName") as Label;
                    Label lblUserPhone = e.Item.FindControl("lblUserPhone") as Label;
                    Label lblPartyName = e.Item.FindControl("lblPartyName") as Label;
                   // Label lblDeliveryTime = e.Item.FindControl("lblDeliveryTime") as Label;
                    Label lblTotalOrder = e.Item.FindControl("lblTotalOrder") as Label;
                    Label lblOrderId = e.Item.FindControl("lblOrderId") as Label;
                    Label lblsaleid = e.Item.FindControl("lblsaleid") as Label;
                    Label lblOrderDate = e.Item.FindControl("lblOrderDate") as Label;
                   // Label lblDeliveryDate = e.Item.FindControl("lblDeliveryDate") as Label;
                    Label lblwords = e.Item.FindControl("lblwords") as Label;

                    Label lblTotalItem = e.Item.FindControl("lblTotalItem") as Label;
                    Label lbltotalWeight = e.Item.FindControl("lbltotalWeight") as Label;

                    Repeater rptItem = e.Item.FindControl("rptItem") as Repeater;
                    string saleid = lblsaleid.Text;

                    // Item Repeater Code Start Here
                    Int32 _SaleHeader_id = Convert.ToInt32(hdfdSaleOrderId.Value);
                    _objSaleItemBL = new SaleItemBL();
                    _lstSaleItem = _objSaleItemBL.GetAllSaleItemItems().Where(x => x.sale_header_id == _SaleHeader_id).OrderBy(x => x.sale_item_net_price).ToList();//   _objsp_GetSaleDetail_Result = _objsp_GetSaleDetail_ResultBL.GetAllsp_GetSaleDetail_ResultItems().Where(x => x.sale_header_id == Convert.ToInt32(saleid)).FirstOrDefault();
                    
                    rptItem.DataSource = _lstSaleItem;
                    rptItem.DataBind();

                    //string _numberToWord = NumberToWord(Convert.ToInt32(_totalAmount)).ToString();
                    //lblwords.Text = _numberToWord;
                    lblTotalItem.Text = _itemTotalCount.ToString();
                    lbltotalWeight.Text = _totalAmount.ToString();

                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "errorToast();", true);
            }
        }


        #region Get Sale Order Party Details
        /// <summary>
        /// This Method Is Use to Get Party Billing Details
        /// </summary>
        /// <param name="_saleHeader_id"></param>
        private void GetSaleOrderPartyDetails(string _saleHeader_id)
        {
            Int32 _SaleHeader_id = Convert.ToInt32(_saleHeader_id);
            _objSaleHeaderBL = new SaleHeaderBL();

            _lstSaleHeaderPartyDetail = _objSaleHeaderBL.GetAllSaleHeaderItemsWithPatryDetails().Where(x => x.sale_header_id == _SaleHeader_id).ToList();

            rptrOrder.DataSource = _lstSaleHeaderPartyDetail;
            rptrOrder.DataBind();
            
           // _objvwSaleHeader = _lstSaleHeaderPartyDetail.Where(x => x.sale_header_id == _SaleHeader_id).FirstOrDefault();

        }

        #endregion

        protected void rptItem_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    
                    Label lblItemQuantity = e.Item.FindControl("lblItemQuantity") as Label;

                    Label lblItemMasterId = e.Item.FindControl("lblItemMasterId") as Label;
                   
                    Label lblTotalItemWeight = e.Item.FindControl("lblTotalItemWeight") as Label;

                    int _itemMasterId = Convert.ToInt32(lblItemMasterId.Text);
                    int _itemQuanity = Convert.ToInt32(lblItemQuantity.Text);
                    
                    if(lblTotalItemWeight.Text == "0" || lblTotalItemWeight.Text == "0.00" | lblTotalItemWeight.Text == null)
                    {
                        _objItemMasterBL = new ItemMasterBL();
                        _objItemMaster = _objItemMasterBL.GetItemMasterItemsByID(_itemMasterId).FirstOrDefault();

                        if(_objItemMaster != null)
                        {
                            lblTotalItemWeight.Text = _objItemMaster.item_weight.ToString();
                        }
                        else
                        { }

                    }
                    else
                    {

                    }
                   
                    _totalAmount = _totalAmount + Convert.ToDecimal(lblTotalItemWeight.Text);
                    _itemTotalCount = _itemTotalCount + Convert.ToInt32(_itemQuanity);

                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "errorToast();", true);
            }
        }

        /// <summary>
        /// This Method is Used to Convert a Amount Number to Word 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        static string NumberToWord(int num)
        {
            if (num == 0)
                return "Zero";

            if (num < 0)
                return "Not supported";

            var words = "";
            string[] strones = { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            string[] strtens = { "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };


            int crore = 0, lakhs = 0, thousands = 0, hundreds = 0, tens = 0, single = 0;


            crore = num / 10000000; num = num - crore * 10000000;
            lakhs = num / 100000; num = num - lakhs * 100000;
            thousands = num / 1000; num = num - thousands * 1000;
            hundreds = num / 100; num = num - hundreds * 100;
            if (num > 19)
            {
                tens = num / 10; num = num - tens * 10;
            }
            single = num;

            if (crore > 0)
            {
                if (crore > 19)
                    words += NumberToWord(crore) + "Crore ";
                else
                    words += strones[crore - 1] + " Crore ";
            }

            if (lakhs > 0)
            {
                if (lakhs > 19)
                    words += NumberToWord(lakhs) + "Lakh ";
                else
                    words += strones[lakhs - 1] + " Lakh ";
            }

            if (thousands > 0)
            {
                if (thousands > 19)
                    words += NumberToWord(thousands) + "Thousand ";
                else
                    words += strones[thousands - 1] + " Thousand ";
            }

            if (hundreds > 0)
                words += strones[hundreds - 1] + " Hundred ";

            if (tens > 0)
                words += strtens[tens - 2] + " ";

            if (single > 0)
                words += strones[single - 1] + " ";

            return words;
        }

    }
}