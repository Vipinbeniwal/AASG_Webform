using App.Business;
using App.BusinessModel;
using App.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AASGWeb.Modules.Admin
{
    public partial class add_tour : System.Web.UI.Page
    {
        #region Global Properties
        ActivityLog _objActivityLog = new ActivityLog();
        ActivityLogBL _objActivityLogBL = null;
        List<ActivityLog> _lstActivityLog = new List<ActivityLog>();

        TourMaster _objTourMaster = new TourMaster();
        TourMasterBL _objTourMasterBL = null;
        List<TourMaster> _lstTourMaster = new List<TourMaster>();


        string UserIp = string.Empty;
        
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
           // Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {
                BindEmployeeMaster();
                BindTourMasterrptr();
            }
        }

        #region

        /// <summary>
        /// This Method is Used to Get All Staff/Employee List /Details
        /// </summary>
        private void BindEmployeeMaster()
        {
            try
            {
                List<StaffMaster> _lstStaffMaster = new List<StaffMaster>();
                StaffMasterBL _objStaffMasterBL = new StaffMasterBL();

                _lstStaffMaster = _objStaffMasterBL.GetAllStaffMasterItems().ToList();

                ddlEmployee.DataSource = _lstStaffMaster;
                ddlEmployee.DataTextField = "staff_name";
                ddlEmployee.DataValueField = "staff_master_id";
                ddlEmployee.DataBind();
                ddlEmployee.Items.Insert(0, new ListItem("Select", "Select"));

            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }

        /// <summary>
        /// This Method is Used to Get Tour List/Details
        /// </summary>
        private void BindTourMasterrptr()
        {
            _objTourMasterBL = new TourMasterBL();

            _lstTourMaster = _objTourMasterBL.GetAllTourMasterItems().OrderByDescending(x => x.tour_master_id).ToList();
            rptrTourMaster.DataSource = _lstTourMaster;
            rptrTourMaster.DataBind();
        }


        private void GetTourMasterDetailsById( int _tourMaster_Id)
        {
            _objTourMasterBL = new TourMasterBL();

            _objTourMaster = _objTourMasterBL.GetAllTourMasterItems().OrderByDescending(x => x.tour_master_id == _tourMaster_Id).FirstOrDefault();

            if (_objTourMaster != null)
            {
                txtTourName.Text = _objTourMaster.tour_name;
                txtStartDate.Text = _objTourMaster.start_date.ToShortDateString();
                txtEndDate.Text = Convert.ToDateTime(_objTourMaster.end_date.ToString()).ToShortDateString();
                ddlEmployee.SelectedValue = _objTourMaster.staff_master_id.ToString();
                txtTourAgenda.Text = _objTourMaster.tour_agenda.ToString();
                txtStartDate.Text = _objTourMaster.start_date.ToShortDateString();
            }
            else
            {

            }
           
        }

        #endregion
        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearGeneralForm();
        }

        protected void btnAddTour_Click(object sender, EventArgs e)
        {
            _objTourMasterBL = new TourMasterBL();
            try
            {
                _lstTourMaster = _objTourMasterBL.GetAllTourMasterItems().Where(x => x.tour_name.ToLower() == txtTourName.Text.ToLower() && x.start_date.ToShortDateString()==Convert.ToDateTime(txtStartDate.Text).ToShortDateString() && x.staff_master_id==Convert.ToInt32(ddlEmployee.SelectedValue)).ToList();

                if (_lstTourMaster.Count == 0)
                {
                    _objTourMasterBL = new TourMasterBL();
                    var response = _objTourMasterBL.CreateTourMaster(GetTourMasterObject());

                    if (response.tour_master_id != 0)
                    {
                        
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccess();", true);

                        BindTourMasterrptr();
                        ClearGeneralForm();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlreadyTourMaster();", true);
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
        }
        private App.BusinessModel.TourMaster GetTourMasterObject()
        {
            try
            {
                String _tourstartDate = string.Empty; String _tourenddate = string.Empty;
                DateTime timestartdate;
                if (txtStartDate.Text != null && txtEndDate.Text != null)
                {
                   // DateTime date = DateTime.ParseExact(txtStartDate.Text, "dd/MM/yyyy", null);
                    DateTime _startDate = DateTime.ParseExact(txtStartDate.Text, "dd/MM/yyyy", null);
                     timestartdate = (_startDate);
                     _tourstartDate = timestartdate.ToString("yyyy-MM-dd");


                    DateTime _endDate = DateTime.ParseExact(txtEndDate.Text, "dd/MM/yyyy", null);
                    DateTime timeendsdate = (_endDate);
                     _tourenddate = timeendsdate.ToString("yyyy-MM-dd");

                  
                    DateTime _StartDate = Convert.ToDateTime(_tourstartDate);
                    DateTime _EndDate = Convert.ToDateTime(_tourenddate);

                    var _diffrence = _EndDate - _StartDate;
                    int days = Convert.ToInt32(_diffrence.Days) + 1;

                    txtNumberOfDays.Text = days.ToString();
                   
                }
                else
                {
                    txtNumberOfDays.Text = "0";

                 }
                _objTourMaster.guid = Guid.NewGuid();
                _objTourMaster.tour_name = txtTourName.Text;
                _objTourMaster.start_date = DateTime.ParseExact(txtStartDate.Text, "dd/MM/yyyy", null);
                _objTourMaster.end_date = DateTime.ParseExact(txtEndDate.Text, "dd/MM/yyyy", null);
                _objTourMaster.staff_master_id = Convert.ToInt32(ddlEmployee.SelectedValue);
                _objTourMaster.tour_agenda = txtTourAgenda.Text;
                _objTourMaster.tour_numberofdays = Convert.ToInt32(txtNumberOfDays.Text);
                //_objTourMaster.tour_status = App.Helper.Utils.OrderStatus.pending.ToString();
                //_objTourMaster.staff_name = Session[Constants.UserName].ToString();

                return _objTourMaster;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objTourMaster;
        }
        private void ClearGeneralForm()
        {
            txtTourName.Text = txtStartDate.Text = txtEndDate.Text = txtTourAgenda.Text = String.Empty;
            BindEmployeeMaster();
        }

        protected void txtEndDate_TextChanged(object sender, EventArgs e)
        {
            //if (txtEndDate.Text != null && txtStartDate.Text != null)
            //{
            //    DateTime _startDate = System.Convert.ToDateTime(txtStartDate.Text.Trim());
            //    DateTime timestartdate = (_startDate);
            //    String _tourstartDate = timestartdate.ToString("yyyy-MM-dd");

            //    DateTime _endDate = System.Convert.ToDateTime(txtStartDate.Text.Trim());
            //    DateTime timeendsdate = (_endDate);
            //    String _tourenddate = timeendsdate.ToString("yyyy-MM-dd");

            //    DateTime _StartDate = Convert.ToDateTime(_tourstartDate);
            //    DateTime _EndDate = Convert.ToDateTime(_tourenddate);

            //    var _diffrence = _EndDate - _StartDate;
            //    int days = Convert.ToInt32(_diffrence.Days) + 1;

            //    txtNumberOfDays.Text = days.ToString();
            //}
            //else
            //{
            //    txtNumberOfDays.Text = "0";
            //}
        }

        protected void rptrTourMaster_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string commandname = e.CommandName;
            string _tour_Master_Id = e.CommandArgument.ToString();
            hdfdTourId.Value = _tour_Master_Id;

            switch (commandname)
            {
                case "active":
                    try
                    {
                        updateStatus(_tour_Master_Id);
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
                        GetTourMasterDetailsById( Convert.ToInt32(hdfdTourId.Value));


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

        protected void rptrTourMaster_ItemDataBound(object sender, RepeaterItemEventArgs e)
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


        #region Tour Status Update Method

        private void updateStatus(string tour_master_id)
        {
            Int64 _tour_master_id = Convert.ToInt64(tour_master_id);
            _objTourMasterBL = new TourMasterBL();
            _objTourMaster = _objTourMasterBL.GetAllTourMasterItems().Where(x => x.tour_master_id == _tour_master_id).FirstOrDefault();
            if (_objTourMaster.is_active == true)
            {
                _objTourMaster.is_active = false;
            }
            else
            {
                _objTourMaster.is_active = true;
            }

            _objTourMaster = _objTourMasterBL.UpdateTourMaster(_objTourMaster);
            if (_objTourMaster != null)
            {
                //string description = "Article  <b>" + _objArticle.title + "</b> status has been updated By " + loginParams.UserName;
                //Logs("Article status Updated", "fa fa-user", "timeline-icon themed-background-fire themed-border-fire", "push-bit text-danger", description);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showTourUpdate();", true);
                BindTourMasterrptr();
            }
        }

        #endregion

    }
}