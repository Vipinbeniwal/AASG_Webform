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

namespace AASGWeb.Modules.GRN
{
    public partial class manage_grn : System.Web.UI.Page
    {
        #region Global Properties

        StockLedger _objStockLedger = new StockLedger();
        StockLedgerBL _objStockLedgerBL = null;
        List<StockLedger> _lstStockLedger = new List<StockLedger>();

        sp_StockLedgerDetail_Result _objsp_StockLedgerDetail_Result = new sp_StockLedgerDetail_Result();
        sp_StockLedgerDetail_ResultBL _objsp_StockLedgerDetail_ResultBL = null;
        List<sp_StockLedgerDetail_Result> _lstsp_StockLedgerDetail_Result = new List<sp_StockLedgerDetail_Result>();


        string UserIp = string.Empty;
        
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                BindPurchaseOrderrptr();
            }
        }
        #region Pageload method

        private void BindPurchaseOrderrptr()
        {
            _objStockLedgerBL = new StockLedgerBL();
            _objsp_StockLedgerDetail_ResultBL = new sp_StockLedgerDetail_ResultBL();

            _lstsp_StockLedgerDetail_Result = _objsp_StockLedgerDetail_ResultBL.GetAllsp_StockLedgerDetail_ResultItems().OrderByDescending(x => x.purchase_header_id).ToList();
            rptrStockLedger.DataSource = _lstsp_StockLedgerDetail_Result;
            rptrStockLedger.DataBind();
        }
        #endregion

        protected void rptrStockLedger_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string commandname = e.CommandName;
            string id = e.CommandArgument.ToString();
            hdfdPurchaseItemId.Value = id;

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

                        string url = "view_stock-ledger-order-details/" + App.Core.DataSecurity.Encryptdata(id).ToString();
                       // string url = "view-purchase-order-bill";

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

            }
        }

        protected void rptrStockLedger_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    Label lblIsActive = (Label)e.Item.FindControl("lblIsActive");
                    LinkButton btnstatusactive = (LinkButton)e.Item.FindControl("btnstatusactive");
                    LinkButton btnstatusdeactive = (LinkButton)e.Item.FindControl("btnstatusdeactive");
                    //CheckBox chkActive=(CheckBox)e.Item.FindControl("chkActive");
                    string isactive = lblIsActive.Text;
                    if (isactive == "True")
                    {
                        btnstatusactive.Visible = true;
                        btnstatusdeactive.Visible = false;
                        //chkActive.Checked=true;

                    }
                    else
                    {
                        btnstatusactive.Visible = false;
                        btnstatusdeactive.Visible = true;
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
    }
}