using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App.Business;
using App.BusinessModel;

namespace AASGWeb.Modules.Production
{
    public partial class item_complete_detail : System.Web.UI.Page
    {
        #region Global Properties

        sp_ItemProcessDetail_Result _objsp_ItemProcessDetail_Result = new sp_ItemProcessDetail_Result();
        sp_ItemProcessDetail_ResultBL _objsp_ItemProcessDetail_ResultBL = null;
        List<sp_ItemProcessDetail_Result> _lstsp_ItemProcessDetail_Result = new List<sp_ItemProcessDetail_Result>();

        App.BusinessModel.Production _objProduction = new App.BusinessModel.Production();
        ProductionBL _objProductionBL = null;
        List<App.BusinessModel.Production> _lstProduction = new List<App.BusinessModel.Production>();


        string UserIp = string.Empty;
       
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                string BatchNumber;
                string ItemMasterId;
                if (RouteData.Values["id"] == null)
                {
                    // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "editorInit();", true);
                }
                else
                {
                    string _itemMasterid = RouteData.Values["id"].ToString();
                    string _batchNumber = RouteData.Values["batchid"].ToString();
                    ItemMasterId = App.Core.DataSecurity.Decryptdata(_itemMasterid);
                    BatchNumber = App.Core.DataSecurity.Decryptdata(_batchNumber);
                    if (ItemMasterId == "" || ItemMasterId == null)
                    {
                        Response.Redirect("/home", false);
                    }
                    else
                    {
                        hdnItemMasterId.Value = ItemMasterId;
                        hdnBatchNumber.Value = BatchNumber;

                        if (hdnItemMasterId.Value == "")
                        {
                            Response.Redirect("/home", false);

                        }
                        else
                        {
                            PopulateRecord(BatchNumber, ItemMasterId);
                        }

                    }
                }
              
            }
        }

        private void PopulateRecord(string BatchNumber,string ItemMasterId)
        {
            try
            {
                //hdnItemMasterId.Value = ItemMasterId;
                //hdnBatchNumber.Value = BatchNumber;

                IEnumerable<sp_ItemProcessDetail_Result> lstItemProcessDetail = new List<sp_ItemProcessDetail_Result>();
                Int32 sp_ItemProcessDetail_ResultID = Convert.ToInt32(ItemMasterId);

                _objsp_ItemProcessDetail_ResultBL = new sp_ItemProcessDetail_ResultBL();

                lstItemProcessDetail = _objsp_ItemProcessDetail_ResultBL.GetAllsp_ItemProcessDetail_ResultItems(BatchNumber, ItemMasterId).ToList();

                //_objsp_ItemProcessDetail_ResultBL = new sp_ItemProcessDetail_ResultBL();
                //sp_ItemProcessDetail_Result _objsp_ItemProcessDetail_Result = new sp_ItemProcessDetail_Result();
                //_lstsp_ItemProcessDetail_Result = _objsp_ItemProcessDetail_ResultBL.GetAllsp_ItemProcessDetail_ResultItems().Where(x=>x.process_cutting_id==Convert.ToInt32(_sp_ItemProcessDetail_Resultid)).ToList();
                if (lstItemProcessDetail != null)
                {
                    rptrManageItemProcess.DataSource = lstItemProcessDetail;
                    rptrManageItemProcess.DataBind();

                    _objsp_ItemProcessDetail_Result = lstItemProcessDetail.Where(x => x.item_master_id == Convert.ToInt32(ItemMasterId)).FirstOrDefault();

                    if (_objsp_ItemProcessDetail_Result !=null)
                    {
                        lblItemFullDetail.Text = _objsp_ItemProcessDetail_Result.item_brand + " | " + _objsp_ItemProcessDetail_Result.item_model + " | " + _objsp_ItemProcessDetail_Result.item_type_name + " | " + _objsp_ItemProcessDetail_Result.item_glass_color;
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

        protected void rptrManageItemProcess_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void rptrManageItemProcess_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    Label lblTotalTime = (Label)e.Item.FindControl("lblTotalTime");
                    
                    Label lblStartDate = (Label)e.Item.FindControl("lblStartDate");
                    Label lblEndDate = (Label)e.Item.FindControl("lblEndDate");

                    Label NameofProcess = (Label)e.Item.FindControl("NameofProcess");
                    Label ProcessStatusClass = (Label)e.Item.FindControl("ProcessStatusClass");
                    string _processName = NameofProcess.Text;

                    Label lblReceived = (Label)e.Item.FindControl("lblReceived");
                    Label lblTransfered = (Label)e.Item.FindControl("lblTransfered");
                    Label lblItemAverageCost = (Label)e.Item.FindControl("lblItemAverageCost");
                    Label lblRawBalance = (Label)e.Item.FindControl("lblRawBalance");

                    int _received_item_quantity = Convert.ToInt32(lblReceived.Text);
                    int _transfered_item_quantity = Convert.ToInt32(lblTransfered.Text);
                    decimal _item_average_cost = Convert.ToDecimal(lblItemAverageCost.Text);
                    int _item_Raw_Balance = Convert.ToInt32(lblRawBalance.Text);
                    
                    if (_transfered_item_quantity > 0 )
                    {
                        ProcessStatusClass.CssClass = "text-success fa fa-fw fa-check";
                    }
                    else if (_received_item_quantity == 0 && _processName == "Cutting")
                    {
                        ProcessStatusClass.CssClass = "text-primary fa fa-refresh fa-spin";
                    }
                    else if (_received_item_quantity > 0 && _processName != "Cutting")
                    {
                        ProcessStatusClass.CssClass = "text-primary fa fa-refresh fa-spin";
                    }
                    else
                    {
                        ProcessStatusClass.CssClass = "";
                        ProcessStatusClass.Text = "--";
                    }
                    Label lblSignatueId = (Label)e.Item.FindControl("lblSignatueId");
                    Label lblSignature = (Label)e.Item.FindControl("lblSignature");
                    int _signatureId = Convert.ToInt32(lblSignatueId.Text);
                    if(_signatureId == 1)
                    {
                        lblSignature.Text = "Supervisor"; 
                    }
                    else if (_signatureId == 2)
                    {
                        lblSignature.Text = "In-charge"; 
                    }
                    else
                    {

                    }
                    if (_item_average_cost > 0)
                    {
                        lblItemAverageCost.Visible = true;
                    }
                    else
                    {
                        lblItemAverageCost.Visible = false;
                    }
                    if (_item_Raw_Balance > 0)
                    {
                        lblRawBalance.Visible = true;
                    }
                    else
                    {
                        lblRawBalance.Visible = false;
                    }

                    DateTime _StartDate = DateTime.Parse(lblStartDate.Text, CultureInfo.CreateSpecificCulture("fr-FR"));
                    DateTime _EndDate = DateTime.Parse(lblEndDate.Text, CultureInfo.CreateSpecificCulture("fr-FR"));
                    var _diffrence = _EndDate - _StartDate;
                    lblTotalTime.Text = _diffrence.ToString();
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "notification('Something went wrong','danger');", true);
            }
        }

        protected void btnItemProductionActivity_Click(object sender, EventArgs e)
        {

            GetItemProductionId( hdnItemMasterId.Value.ToString(), hdnBatchNumber.Value.ToString());
        }

        #region  Get Item Production Id Method

        /// <summary>
        /// This Method is Used to Get Item Production Id Method
        /// </summary>
        /// <param name="_item_Id"></param>
        /// <param name="_batchNumber"></param>
        private void GetItemProductionId(string _item_Id, string _batchNumber)
        {
           // Int64 id = Convert.ToInt64(_productionId);
            _objProductionBL = new ProductionBL();

            _objProduction = _objProductionBL.GetAllProductionItems().Where(x => x.batch_number == _batchNumber && x.item_master_id ==  Convert.ToInt32(_item_Id)).FirstOrDefault();

            if (_objProduction != null)
            {
                if (_objProduction.production_id > 0)
                {

                    string url = "/production/item-summary/" + App.Core.DataSecurity.Encryptdata(_objProduction.item_master_id.ToString()).ToString() + "/" + App.Core.DataSecurity.Encryptdata(_objProduction.production_id.ToString()).ToString();

                    Response.Redirect(url, false);
                    //Response.Redirect("production/item-summary/" + App.Core.DataSecurity.Encryptdata(_objProduction.item_master_id.ToString()).ToString() + "/" + App.Core.DataSecurity.Encryptdata(_objProduction.production_id.ToString()).ToString(), false);
                }
                else
                { }
            
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "notification('Something went wrong','danger');", true);
            }


        }

        #endregion

    }
}