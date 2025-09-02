using App.Business;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AASGWeb.Modules.Admin
{
    public partial class my_tour : System.Web.UI.Page
    {
        #region Global Properties
        //App.BusinessModel.TourMaster _objTourMaster = new App.BusinessModel.TourMaster();
        //App.Business.TourMasterBL _objTourMasterBL = null;
        //List<App.BusinessModel.TourMaster> _lstTourMaster = new List<App.BusinessModel.TourMaster>();

        App.BusinessModel.sp_tourdetail_Result _objTourDetailMaster = new App.BusinessModel.sp_tourdetail_Result();
        App.Business.sp_tourdetail_ResultBL _objTourDetailMasterBL = null;
        List<App.BusinessModel.sp_tourdetail_Result> _lstTourDetailMaster = new List<App.BusinessModel.sp_tourdetail_Result>();

        string UserIp = string.Empty;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTourMasterGrid();
            }
        }

        protected void rptrManageTour_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string commandname = e.CommandName;
            string id = e.CommandArgument.ToString();
            hdfdtourId.Value = id;

            Int32 ID = Convert.ToInt32(id);
            switch (commandname)
            {
                
                case "view":
                    try
                    {

                        string url = "view-tour-expense/" + App.Core.DataSecurity.Encryptdata(id).ToString();

                        Response.Redirect(url, false);
                    }
                    catch (Exception ex)
                    {
                        ex.Message.ToString();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
                    }
                    break;
            }
        }
        private void BindTourMasterGrid()
        {
            try
            {
                //_objTourMasterBL = new TourMasterBL();
                //_lstTourMaster = _objTourMasterBL.GetAllTourMasterItems().OrderByDescending(x => x.created_on).ToList();

                //rptrManageTour.DataSource = _lstTourMaster;
                //rptrManageTour.DataBind();

                _objTourDetailMasterBL = new sp_tourdetail_ResultBL();
                int tour_master_id = 0;
                int staff_master_id = 0;
                string FromDate = "";
                string ToDate = "";

                _lstTourDetailMaster = _objTourDetailMasterBL.GetAllsp_tourdetail_ResultItems(tour_master_id, staff_master_id, FromDate, ToDate).ToList();

                rptrManageTour.DataSource = _lstTourDetailMaster;
                rptrManageTour.DataBind();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }
    }
}