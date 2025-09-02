using App.Business;
using App.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AASGWeb.Modules.Production
{
    public partial class item_summary : System.Web.UI.Page
    {
        #region Global Properties
        ProductionTrail _objProductionTrail = new ProductionTrail();
        ProductionTrailBL _objProductionTrailBL = null;
        List<ProductionTrail> _lstProductionTrail = new List<ProductionTrail>();

        ItemMaster _objItemMaster = new ItemMaster();
        ItemMasterBL _objItemMasterBL = null;
        List<ItemMaster> _lstItemMaster = new List<ItemMaster>();

        string UserIp = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
           

            if (!IsPostBack)
            {
                string _itemMasterId;
                string _itemProductionId;
                if (RouteData.Values["id"] == null)
                {
                    // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "editorInit();", true);
                }
                else
                {

                    string itemMasterid = RouteData.Values["id"].ToString();
                    string itemProductionid = RouteData.Values["productionid"].ToString();
                    _itemMasterId = App.Core.DataSecurity.Decryptdata(itemMasterid);
                    _itemProductionId = App.Core.DataSecurity.Decryptdata(itemProductionid);
                    if (_itemMasterId == "" || _itemMasterId == null)
                    {
                        Response.Redirect("/home", false);
                    }
                    else
                    {
                        hdnId.Value = _itemMasterId;

                        if (hdnId.Value == "")
                        {
                            Response.Redirect("/home", false);

                        }
                        else
                        {
                            BindItemSummary(_itemMasterId, _itemProductionId);
                        }

                    }


                }
            }

        }
        private void BindItemSummary(string itemMasterid,string itemProductionid)
        {
            try
            {
                _objItemMasterBL = new ItemMasterBL();
                _objItemMaster = _objItemMasterBL.GetItemMasterItemsByID(Convert.ToInt32(itemMasterid)).FirstOrDefault();
                if(_objItemMaster.item_master_id>0)
                {
                    lblItemName.Text = _objItemMaster.brand + " " + _objItemMaster.model + " " + _objItemMaster.item_type_name;
                }

                _objProductionTrailBL = new ProductionTrailBL();
                _lstProductionTrail = _objProductionTrailBL.GetAllProductionTrailItems().Where(x=>x.item_master_id==Convert.ToInt32(itemMasterid) && x.production_id== Convert.ToInt32(itemProductionid)).OrderByDescending(x => x.production_trail_id).ToList();

                rptrProductionItemSummary.DataSource = _lstProductionTrail;
                rptrProductionItemSummary.DataBind();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }

        protected void rptrProductionItemSummary_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {

                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    

                    Label lblProcessName = (Label)e.Item.FindControl("lblProcessName");
                    Label lblActivity = (Label)e.Item.FindControl("lblActivity");
                    if (lblProcessName.Text=="Cutting")
                    {
                        lblProcessName.CssClass = "label label-primary";
                        lblActivity.CssClass = "text-primary";   
                    }
                    if(lblProcessName.Text == "Grinding")
                    {
                        lblProcessName.CssClass = "label label-success";
                        lblActivity.CssClass = "text-success";
                    }
                    if (lblProcessName.Text == "Hole")
                    {
                        lblProcessName.CssClass = "label label-warning";
                        lblActivity.CssClass = "text-warning";
                    }
                    if (lblProcessName.Text == "Washing")
                    {
                        lblProcessName.CssClass = "label label-default";
                        lblActivity.CssClass = "text-default";
                    }
                    if (lblProcessName.Text== "Paint")
                    {
                        lblProcessName.CssClass = "label label-default";
                        lblActivity.CssClass = "text-default";
                    }
                    else if (lblProcessName.Text == "DFG")
                    {
                        lblProcessName.CssClass = "label label-primary";
                        lblActivity.CssClass = "text-primary";
                    }
                    if (lblProcessName.Text == "Tempring")
                    {
                        lblProcessName.CssClass = "label label-primary";
                        lblActivity.CssClass = "text-primary";
                    }
                    if (lblProcessName.Text == "Packing")
                    {
                        lblProcessName.CssClass = "label label-success";
                        lblActivity.CssClass = "text-success";
                    }
                    if (lblProcessName.Text == "Store")
                    {
                        lblProcessName.CssClass = "label label-success";
                        lblActivity.CssClass = "text-success";
                    }
                    

                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }
}