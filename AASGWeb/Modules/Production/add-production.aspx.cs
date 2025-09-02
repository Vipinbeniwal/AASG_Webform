using App.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App.BusinessModel;

namespace AASGWeb.Modules.Production
{
    public partial class add_production : System.Web.UI.Page
    {
        #region Global Properties

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

                string ProductionId;
                if (RouteData.Values["id"] == null)
                {
                    // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "editorInit();", true);
                }
                else
                {
                    string _productionId = RouteData.Values["id"].ToString();
                    ProductionId = App.Core.DataSecurity.Decryptdata(_productionId);
                    if (ProductionId == "" || ProductionId == null)
                    {
                        Response.Redirect("/home", false);
                    }
                    else
                    {
                        hdnProductionId.Value = ProductionId;

                        if (hdnProductionId.Value == "")
                        {
                            Response.Redirect("/home", false);

                        }
                        else
                        {
                            PopulateData(ProductionId);
                        }
                    }
                }
                // PopulateData("1");
            }
        }
        private void PopulateData(string ProductionId)
        {
            try
            {
                hdnProductionId.Value = ProductionId;
                Int32 ProductionID = Convert.ToInt32(ProductionId);

                _objProductionBL = new ProductionBL();

                _objProduction = _objProductionBL.GetAllProductionItems().Where(x => x.production_id == Convert.ToInt32(ProductionId)).FirstOrDefault();

                if (_objProduction != null)
                {
                    //_objItemMasterBL = new ItemMasterBL();
                    //_objItemMaster = _objItemMasterBL.GetItemMasterItemsByID(_objProcessStore.item_master_id).FirstOrDefault();
                    //if (_objItemMaster.item_master_id > 0)
                    //{
                    //    txtthickness.Text = _objItemMaster.thickness;
                    //    txtsheetSize.Text = _objItemMaster.item_height + "x" + _objItemMaster.item_width;
                    //    txtItemName.Text = _objItemMaster.model + "|" + _objItemMaster.item_type_name + "|" + _objItemMaster.glass_color;

                    //}
                    txtPlantName.Text = _objProduction.production_plant;
                    ddlProductionShift.SelectedValue = _objProduction.production_shift;
                    txtBatchNumber.Text = _objProduction.batch_number;

                    txtItemName.Text = _objProduction.item_model + "|" + _objProduction.item_type_name + "|" + _objProduction.item_glass_color;
                    txtQuantityInPcs.Text = _objProduction.store_quantity.ToString();

                    txtProductionTargetInPcs.Text = _objProduction.production_quantity.ToString();
                    decimal percentage = Convert.ToInt32(txtQuantityInPcs.Text) / Convert.ToInt32(txtProductionTargetInPcs.Text) * 100;
                    txtProductionTargetInPercentage.Text = (Math.Round(percentage,2)).ToString();

                    txtProductionStartTime.Text = _objProduction.started_on.ToShortTimeString();
                    txtProductionEndTime.Text = _objProduction.modified_on.ToShortTimeString();

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
    }
}