using App.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AASGWeb.Modules.Admin
{
    public partial class view_tour_expense : System.Web.UI.Page
    {
        #region Global Properties

        App.BusinessModel.sp_tourdetail_Result _objTourDetailMaster = new App.BusinessModel.sp_tourdetail_Result();
        App.Business.sp_tourdetail_ResultBL _objTourDetailMasterBL = null;
        List<App.BusinessModel.sp_tourdetail_Result> _lstTourDetailMaster = new List<App.BusinessModel.sp_tourdetail_Result>();



        App.BusinessModel.TourExpenseItem _objTourExpenseItemLedger = new App.BusinessModel.TourExpenseItem();
        TourExpenseItemBL _objTourExpenseItemBL = null;
        List<App.BusinessModel.TourExpenseItem> _lstTourExpenseItem = new List<App.BusinessModel.TourExpenseItem>();

        App.BusinessModel.TourExpenseHeader _objTourExpenseHeaderLedger = new App.BusinessModel.TourExpenseHeader();
        TourExpenseHeaderBL _objTourExpenseHeaderBL = null;
        List<App.BusinessModel.TourExpenseHeader> _lstTourExpenseHeader = new List<App.BusinessModel.TourExpenseHeader>();

        App.BusinessModel.TourGradeMaster _objTourGradeMaster = new App.BusinessModel.TourGradeMaster();
        App.Business.TourGradeMasterBL _objTourGradeMasterBL = null;
        List<App.BusinessModel.TourGradeMaster> _lstTourGradeMaster = new List<App.BusinessModel.TourGradeMaster>();


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

        private void PopulateData(string _partyid)
        {
            try
            {
                Int32 PartyID = Convert.ToInt32(_partyid);
                BindViewTourExpenserptr(PartyID);
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
        #region Pageload method

        private void BindViewTourExpenserptr(int id)
        {

            _objTourDetailMasterBL = new sp_tourdetail_ResultBL();
            int tour_master_id = id;
            int staff_master_id = 0;
            string FromDate = "";
            string ToDate = "";

            _objTourDetailMaster = _objTourDetailMasterBL.GetAllsp_tourdetail_ResultItems(tour_master_id, staff_master_id, FromDate, ToDate).FirstOrDefault();

            if(_objTourDetailMaster != null)
            {
                lblTourName.Text = _objTourDetailMaster.tour_name;
                lblGrade.Text = _objTourDetailMaster.tourgrade_name;
                lblStaffName.Text = _objTourDetailMaster.staff_name;
                lblTourDays.Text = _objTourDetailMaster.tour_numberofdays.ToString();
            }

            
            _objTourExpenseItemBL = new TourExpenseItemBL();

            _lstTourExpenseItem = _objTourExpenseItemBL.GetAllTourExpenseItemItems().Where(x => x.tour_master_id == id).ToList();
            if(_lstTourExpenseItem!=null)
            {
                rptrTotalTourExpenseDetail.DataSource = _lstTourExpenseItem;
                rptrTotalTourExpenseDetail.DataBind();
            }

            _objTourExpenseHeaderBL = new TourExpenseHeaderBL();

            _objTourExpenseHeaderLedger = _objTourExpenseHeaderBL.GetAllTourExpenseHeaderItems().Where(x => x.tour_master_id == id).FirstOrDefault();
            Control FooterTemplate = rptrTotalTourExpenseDetail.Controls[rptrTotalTourExpenseDetail.Controls.Count - 1].Controls[0];
            if (_lstTourExpenseHeader!=null)
            {
               
                Label lblTotalFoodPrice = FooterTemplate.FindControl("lblTotalFoodPrice") as Label;
                Label lblTotalHotelPrice = FooterTemplate.FindControl("lblTotalHotelPrice") as Label;
                Label lblTotalConveyancePrice = FooterTemplate.FindControl("lblTotalConveyancePrice") as Label;
                Label lblTotalMiscPrice = FooterTemplate.FindControl("lblTotalMiscPrice") as Label;
                Label lblTotal = FooterTemplate.FindControl("lblTotal") as Label;

                lblTotalFoodPrice.Text = _objTourExpenseHeaderLedger.expense_food_total.ToString();
                lblTotalHotelPrice.Text = _objTourExpenseHeaderLedger.expense_hotel_total.ToString();
                lblTotalConveyancePrice.Text = _objTourExpenseHeaderLedger.expense_conveyance_total.ToString();
                lblTotalMiscPrice.Text = _objTourExpenseHeaderLedger.expense_misc_total.ToString();
                lblTotal.Text = _objTourExpenseHeaderLedger.expense_total.ToString();

               
                if(_objTourExpenseHeaderLedger.expense_total_approved>0)
                {
                    txtApprovedAmount.Enabled = false;
                    txtApprovedAmount.Text = _objTourExpenseHeaderLedger.expense_total_approved.ToString();
                    btnApprovedAmount.Enabled = false;
                }
                else
                {
                    txtApprovedAmount.Enabled = true;
                    txtApprovedAmount.Text = lblTotal.Text;
                    btnApprovedAmount.Enabled = true;
                }
            }

            _objTourGradeMasterBL = new TourGradeMasterBL();
            _objTourGradeMaster = _objTourGradeMasterBL.GetAllTourGradeMasterItems().Where(x=>x.tourgrade_name== _objTourDetailMaster.tourgrade_name).FirstOrDefault();
            if(_objTourGradeMaster!=null)
            {
                int tourExpenseItem = _lstTourExpenseItem.Count;
                if( tourExpenseItem>0)
                {

                    Label lblApprovedFoodExp = FooterTemplate.FindControl("lblApprovedFoodExp") as Label;
                    Label lblApprovedHotelExp = FooterTemplate.FindControl("lblApprovedHotelExp") as Label;
                    Label lblApprovedConveyanceExp = FooterTemplate.FindControl("lblApprovedConveyanceExp") as Label;
                    Label lblApprovedMiscExp = FooterTemplate.FindControl("lblApprovedMiscExp") as Label;
                    Label lblApprovedExp = FooterTemplate.FindControl("lblApprovedExp") as Label;
                    Label lblApproved = FooterTemplate.FindControl("lblApprovedExp") as Label;

                    lblApprovedFoodExp.Text = (tourExpenseItem * _objTourGradeMaster.tourgrade_perday_food).ToString();
                    lblApprovedHotelExp.Text = (tourExpenseItem * _objTourGradeMaster.tourgrade_perday_hotel).ToString();
                    lblApprovedConveyanceExp.Text = (tourExpenseItem * _objTourGradeMaster.tourgrade_perday_transport).ToString();
                    lblApprovedMiscExp.Text = (tourExpenseItem * _objTourGradeMaster.tourgrade_perday_misc).ToString();

                    decimal lblApprovedTotal = Convert.ToDecimal(lblApprovedFoodExp.Text) + Convert.ToDecimal(lblApprovedHotelExp.Text) + Convert.ToDecimal(lblApprovedConveyanceExp.Text) + Convert.ToDecimal(lblApprovedMiscExp.Text);
                    lblApproved.Text = lblApprovedTotal.ToString();
                }

                

            }
            Label lblTourGradeName = FooterTemplate.FindControl("lblTourGradeName") as Label;
            lblTourGradeName.Text = _objTourDetailMaster.tourgrade_name;

            

        }
        #endregion

        protected void rptrTotalTourExpenseDetail_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void rptrTotalTourExpenseDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void btnApprovedAmount_Click(object sender, EventArgs e)
        {
            //Control FooterTemplate = rptrTotalTourExpenseDetail.Controls[rptrTotalTourExpenseDetail.Controls.Count - 1].Controls[0];
            //Label lblTotal = FooterTemplate.FindControl("lblTotal") as Label;
            //if(Convert.ToDecimal(txtApprovedAmount.Text) <= Convert.ToDecimal(lblTotal.Text))
            //{

            //}
            if(Convert.ToDecimal(txtApprovedAmount.Text)>0)
            {
                int tourmasterid = Convert.ToInt32(hdnId.Value);
                _objTourExpenseHeaderBL = new TourExpenseHeaderBL();

                _objTourExpenseHeaderLedger = _objTourExpenseHeaderBL.GetAllTourExpenseHeaderItems().Where(x => x.tour_master_id == tourmasterid).FirstOrDefault();
                if(_objTourExpenseHeaderLedger!=null)
                {
                    _objTourExpenseHeaderLedger.expense_total_approved = Convert.ToInt32(txtApprovedAmount.Text);
                    _objTourExpenseHeaderLedger.status = "approved";
                    var response = _objTourExpenseHeaderBL.UpdateTourExpenseHeader(_objTourExpenseHeaderLedger);
                    if (response.tour_expense_header_id != 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccess();", true);
                        txtApprovedAmount.Enabled = false;
                        btnApprovedAmount.Enabled = false;
                    }
                }
            }
        }
    }
}