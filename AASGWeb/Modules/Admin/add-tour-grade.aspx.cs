using App.Business;
using App.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AASGWeb.Modules.Admin
{
    public partial class add_tour_grade : System.Web.UI.Page
    {
        #region Global Properties
        ActivityLog _objActivityLog = new ActivityLog();
        ActivityLogBL _objActivityLogBL = null;
        List<ActivityLog> _lstActivityLog = new List<ActivityLog>();

        App.BusinessModel.TourGradeMaster _objTourGradeMaster = new App.BusinessModel.TourGradeMaster();
        App.Business.TourGradeMasterBL _objTourGradeMasterBL = null;
        List<App.BusinessModel.TourGradeMaster> _lstTourGradeMaster = new List<App.BusinessModel.TourGradeMaster>();


        string UserIp = string.Empty;
        
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTourGradeMasterGrid();
            }
        }
        private void BindTourGradeMasterGrid()
        {
            try
            {
                _objTourGradeMasterBL = new TourGradeMasterBL();
                _lstTourGradeMaster = _objTourGradeMasterBL.GetAllTourGradeMasterItems().OrderByDescending(x => x.created_on).ToList();

                rptrTourGradeType.DataSource = _lstTourGradeMaster;
                rptrTourGradeType.DataBind();

                Session["gradelist"] = _lstTourGradeMaster;
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearGeneralForm();
        }

        protected void btnAddTourGrade_Click(object sender, EventArgs e)
        {
            _objTourGradeMasterBL = new TourGradeMasterBL();
            try
            {
                _lstTourGradeMaster = _objTourGradeMasterBL.GetAllTourGradeMasterItems().Where(x => x.tourgrade_name.ToLower() == txtGradeName.Text.ToLower()).ToList();

                if (_lstTourGradeMaster.Count == 0)
                {
                    _objTourGradeMasterBL = new TourGradeMasterBL();
                    var response = _objTourGradeMasterBL.CreateTourGradeMaster(GetTourGradeMasterObject( false));

                    if (response.tourgrade_master_id != 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showSuccess();", true);
                        BindTourGradeMasterGrid();
                        ClearGeneralForm();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showAlreadyTourGradeMaster();", true);
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
        }
        private App.BusinessModel.TourGradeMaster GetTourGradeMasterObject(Boolean _isUpdate)
        {
            try
            {
                App.BusinessModel.TourGradeMaster _objTourGradeMaster = new App.BusinessModel.TourGradeMaster();

                if (_isUpdate == false)
                {
                    _objTourGradeMaster.guid = Guid.NewGuid();
                    _objTourGradeMaster.tourgrade_master_id = 0;
                }
                else
                {
                    Int32 TourGradeMasterId = Convert.ToInt32(hdfTourGradeMasterId.Value.ToString());

                    List<App.BusinessModel.TourGradeMaster> _lstTourGradeMaster = Session["gradelist"] as List<App.BusinessModel.TourGradeMaster>;

                    _objTourGradeMaster = _lstTourGradeMaster.Where(x => x.tourgrade_master_id == TourGradeMasterId).FirstOrDefault();


                    _objTourGradeMaster.tourgrade_master_id = TourGradeMasterId;


                }
                _objTourGradeMaster.tourgrade_name = txtGradeName.Text;
                _objTourGradeMaster.tourgrade_perday_transport = Convert.ToDecimal(txtTransportAllowance.Text);
                _objTourGradeMaster.tourgrade_perday_food = Convert.ToDecimal(txtFoodAllowance.Text);
                _objTourGradeMaster.tourgrade_perday_hotel = Convert.ToDecimal(txtHotelAllowance.Text);
                _objTourGradeMaster.tourgrade_perday_misc = Convert.ToDecimal(txtMiscAllowance.Text);


                return _objTourGradeMaster;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
            return _objTourGradeMaster;
        }
        private void ClearGeneralForm()
        {
            txtGradeName.Text = String.Empty;
            txtTransportAllowance.Text = txtFoodAllowance.Text = txtHotelAllowance.Text =txtMiscAllowance.Text= "0.0";
            btnAddTourGrade.Visible = true;
            btnUpdate.Visible = false;
        }

        protected void rptrTourGradeType_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string commandname = e.CommandName;
            string _tour_Grade_Master_Id = e.CommandArgument.ToString();
            hdfTourGradeMasterId.Value = _tour_Grade_Master_Id;

            switch (commandname)
            {
                case "active":
                    try
                    {
                       
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
                        GetTourGradeMasterDetailsById(Convert.ToInt32(hdfTourGradeMasterId.Value));
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

        protected void rptrTourGradeType_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {

                    //Label lblIsActive = (Label)e.Item.FindControl("lblIsActive");
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



        /// <summary>
        /// This Method is Used to get Tour Grade Master Details
        /// </summary>
        /// <param name="_tourMaster_Id">Uniqe Tour Grade Master Id</param>
        private void GetTourGradeMasterDetailsById(int _tourGradeMaster_Id)
        {
           
            //App.BusinessModel.TourGradeMaster _objTourGradeMaster = new App.BusinessModel.TourGradeMaster();
             _objTourGradeMasterBL = new App.Business.TourGradeMasterBL();
            _objTourGradeMaster = _objTourGradeMasterBL.GetTourGradeMasterItemsByID(_tourGradeMaster_Id).FirstOrDefault();

            if (_objTourGradeMaster != null)
            {
                txtGradeName.Text = _objTourGradeMaster.tourgrade_name;
                txtTransportAllowance.Text = _objTourGradeMaster.tourgrade_perday_transport.ToString();
                txtFoodAllowance.Text = _objTourGradeMaster.tourgrade_perday_food.ToString();
                txtHotelAllowance.Text = _objTourGradeMaster.tourgrade_perday_hotel.ToString();
                txtMiscAllowance.Text = _objTourGradeMaster.tourgrade_perday_misc.ToString();

                btnAddTourGrade.Visible = false;
                btnUpdate.Visible = true;
            }
            else
            {

            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            _objTourGradeMasterBL = new TourGradeMasterBL();
            try
            {
                _objTourGradeMaster = _objTourGradeMasterBL.GetAllTourGradeMasterItems().Where(x => x.tourgrade_name.ToLower() == txtGradeName.Text.ToLower()).FirstOrDefault();

                if(_objTourGradeMaster != null)
                {
                    if (_objTourGradeMaster.tourgrade_master_id > 0)
                    {
                        _objTourGradeMasterBL = new TourGradeMasterBL();
                        var response = _objTourGradeMasterBL.UpdateTourGradeMaster(GetTourGradeMasterObject(true));

                        if (response.tourgrade_master_id != 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showUpdate();", true);
                            BindTourGradeMasterGrid();
                            ClearGeneralForm();
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showUpdate();", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showNoRecordFound();", true);
                }
                

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showException();", true);
            }
        }
    }
}