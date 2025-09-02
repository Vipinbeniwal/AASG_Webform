using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App.Business;

namespace AASGWeb.Modules.Admin
{
    public partial class manage_tour_expense : System.Web.UI.Page
    {
        #region Global Properties

        App.BusinessModel.TourExpenseHeader _objTourExpenseHeaderLedger = new App.BusinessModel.TourExpenseHeader();
        TourExpenseHeaderBL _objTourExpenseHeaderBL = null;
        List<App.BusinessModel.TourExpenseHeader> _lstTourExpenseHeader = new List<App.BusinessModel.TourExpenseHeader>();



        string UserIp = string.Empty;
        
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    BindPurchaseOrderrptr();
            //}
            if (!IsPostBack)
            {
                string _partyid;
                if (RouteData.Values["id"] == null)
                {
                    // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "editorInit();", true);
                }
                else
                {

                    string lid = RouteData.Values["id"].ToString();
                   
                    _partyid = App.Core.DataSecurity.Decryptdata(lid);
                    if (_partyid == "" || _partyid == null)
                    {
                        Response.Redirect("/home", false);
                    }
                    else
                    {
                        hdnId.Value = _partyid;

                        if (hdnId.Value == "")
                        {
                            Response.Redirect("/home", false);

                        }
                        else
                        {
                            PopulateData(_partyid);
                        }

                    }


                }
                }
        }
        #region Pageload method

        private void PopulateData(string _partyid)
        {
            try
            {
                Int32 PartyID = Convert.ToInt32(_partyid);
                BindPurchaseOrderrptr(PartyID);
                //_objPartyMasterBL = new PartyMasterBL();
                //_objPartyMaster = _objPartyMasterBL.GetPartyMasterItemsByID(Convert.ToInt32(PartyID)).FirstOrDefault();
                //if (_objPartyMaster.party_master_id != 0)
                //{
                //    btnAddParty.Visible = false;
                //    BtnUpdate.Visible = true;
                //}
                //else
                //{

                //}

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void BindPurchaseOrderrptr( int id)
        {
            _objTourExpenseHeaderBL = new TourExpenseHeaderBL();

            _lstTourExpenseHeader = _objTourExpenseHeaderBL.GetAllTourExpenseHeaderItems().Where(x=>x.tour_master_id==id).ToList();
            rptrTotalTourExpense.DataSource = _lstTourExpenseHeader;
            rptrTotalTourExpense.DataBind();
        }
        #endregion

        protected void rptrTotalTourExpense_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //string commandname = e.CommandName;
            //string id = e.CommandArgument.ToString();
            //hdfdPurchaseItemId.Value = id;

            //Int32 ID = Convert.ToInt32(id);
            //switch (commandname)
            //{
            //    case "active":
            //        try
            //        {
            //            //  updateStatus(id);
            //        }
            //        catch (Exception ex)
            //        {
            //            ex.Message.ToString();
            //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            //        }
            //        break;
            //    case "edit":
            //        try
            //        {

            //            string url = "view_stock-ledger-order-details/" + App.Core.DataSecurity.Encryptdata(id).ToString();
            //            // string url = "view-purchase-order-bill";

            //            Response.Redirect(url, false);
            //        }
            //        catch (Exception ex)
            //        {
            //            ex.Message.ToString();
            //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            //        }
            //        break;
            //    case "delete":
            //        try
            //        {
            //            // DeleteArticle(ID);

            //        }
            //        catch (Exception ex)
            //        {
            //            ex.Message.ToString();
            //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            //        }
            //        break;

            //}
        }

        protected void rptrTotalTourExpense_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //try
            //{
            //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //    {

            //        Label lblIsActive = (Label)e.Item.FindControl("lblIsActive");
            //        LinkButton btnstatusactive = (LinkButton)e.Item.FindControl("btnstatusactive");
            //        LinkButton btnstatusdeactive = (LinkButton)e.Item.FindControl("btnstatusdeactive");
            //        //CheckBox chkActive=(CheckBox)e.Item.FindControl("chkActive");
            //        string isactive = lblIsActive.Text;
            //        if (isactive == "True")
            //        {
            //            btnstatusactive.Visible = true;
            //            btnstatusdeactive.Visible = false;
            //            //chkActive.Checked=true;

            //        }
            //        else
            //        {
            //            btnstatusactive.Visible = false;
            //            btnstatusdeactive.Visible = true;
            //            //chkActive.Checked = false;

            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ex.Message.ToString();
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "notification('Something went wrong','danger');", true);
            //}
        }
    }
}