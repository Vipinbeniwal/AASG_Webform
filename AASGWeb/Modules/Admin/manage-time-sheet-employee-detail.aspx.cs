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

namespace AASGWeb.Modules.Admin
{
    public partial class manage_time_sheet_employee_detail : System.Web.UI.Page
    {
        #region Global Properties

        xp_TimeSheetChild _objxp_TimeSheetChild = new xp_TimeSheetChild();
        xp_TimeSheetChildBL _objxp_TimeSheetChildBL = null;
        List<xp_TimeSheetChild> _lstxp_TimeSheetChild = new List<xp_TimeSheetChild>();



        string UserIp = string.Empty;
        string[] FileNameFile;
        
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string _timeSheetHeaderId;
                if (RouteData.Values["id"] == null)
                {
                    // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "editorInit();", true);
                }
                else
                {
                    
                    string _time_Sheet_header_id = RouteData.Values["id"].ToString();
                    _timeSheetHeaderId = App.Core.DataSecurity.Decryptdata(_time_Sheet_header_id);
                    hdfdTimeSheetHeaderId.Value = _timeSheetHeaderId;
                    if (_timeSheetHeaderId == "" || _timeSheetHeaderId == null)
                    {
                        Response.Redirect("/home", false);
                    }
                    else
                    {
                         BindTimeSheetHeaderrptr(_timeSheetHeaderId);

                    }


                }
            }
        }

        #region Pageload method

        private void BindTimeSheetHeaderrptr(string _timesheetHeaderId)
        {
            Int32 _timesheetheaderId = Convert.ToInt32(_timesheetHeaderId);
            _objxp_TimeSheetChildBL = new xp_TimeSheetChildBL();

            //_lstStockLedger = _objStockLedgerBL.GetAllStockLedgerItems().OrderByDescending(x => x.purchase_header_id == _pONumber).ToList(); ;

            _lstxp_TimeSheetChild = _objxp_TimeSheetChildBL.GetAllxp_TimeSheetChildItems().Where(x => x.time_sheet_header_id == _timesheetheaderId).ToList();

            rptrTimeSheetDetailEmployee.DataSource = _lstxp_TimeSheetChild;
            rptrTimeSheetDetailEmployee.DataBind();


        }

        //private void GetInvoiceNumber()
        //{
        //    Int32 _pONumber = Convert.ToInt32(hdfdPurchaseNumber.Value);

        //    _objStockLedger = _lstStockLedger.Where(x => x.purchase_header_id == _pONumber).FirstOrDefault();
        //}
        #endregion


        protected void rptrTimeSheetDetailEmployee_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void rptrTimeSheetDetailEmployee_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    Label lblProjectName = (Label)e.Item.FindControl("lblProjectName");
                    
                    //LinkButton btnstatusactive = (LinkButton)e.Item.FindControl("btnstatusactive");
                    //LinkButton btnstatusdeactive = (LinkButton)e.Item.FindControl("btnstatusdeactive");
                    ////CheckBox chkActive=(CheckBox)e.Item.FindControl("chkActive");
                    //string isactive = lblIsActive.Text;
                    //if (isactive == "True")
                    //{
                    //    btnstatusactive.Visible = true;
                    //    btnstatusdeactive.Visible = false;
                    //    //chkActive.Checked=true;

                    //}
                    //else
                    //{
                    //    btnstatusactive.Visible = false;
                    //    btnstatusdeactive.Visible = true;
                    //    //chkActive.Checked = false;

                    //}
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