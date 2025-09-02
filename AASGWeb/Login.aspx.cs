using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App.Business;
using App.BusinessModel;
using App.Core;
namespace AASGWeb
{
    public partial class Login : System.Web.UI.Page
    {
        #region Global Properties

        StaffMaster _objStaffMaster = new StaffMaster();
        StaffMasterBL _objStaffMasterBL = new StaffMasterBL("admin");
        List<StaffMaster> _lstStaffMaster = new List<StaffMaster>();

        UserRole _objUserRole = new UserRole();
        UserRoleBL _objUserRoleBL = new UserRoleBL("admin");
        List<UserRole> _lstUserRole = new List<UserRole>();

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            Scriptcall();
        }


        #region Page load methods

        private void Scriptcall()
        {
            if (Session["Password"] != null)
            {
                
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "PasswordChanged();", true);
                 ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('password changed succesfully!')", true);
                Session["Password"] = null;
            }
            if (Session["WrongOTP"] != null)
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "OTPExpired();", true);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('OTP not matched!')", true);
                Session["WrongOTP"] = null;
            }
            if (Session["Passworderror"] != null)
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "OTPExpired();", true);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong...Please try again!')", true);
                Session["Passworderror"] = null;
            }
        }

        #endregion

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Get the current date and time
            DateTime currentDate = DateTime.Now;

            // Assuming you have your start and end dates (replace these with your actual dates)
            DateTime startDate = DateTime.Parse("2023-09-18");
            DateTime endDate = DateTime.Parse("2023-11-7");

            // Check if the current date is within the specified range
            if (currentDate >= startDate && currentDate <= endDate)
            {
                try
                {
                    if (val_terms.Checked == true)
                    {
                        if (Context.Request.Form["user"].ToString() == "" || Context.Request.Form["user"].ToString() == null)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showError();", true);
                        }
                        else if (Context.Request.Form["password"].ToString() == "" || Context.Request.Form["password"].ToString() == null)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertmessage", "showError();", true);
                        }
                        else
                        {
                            _lstStaffMaster = _objStaffMasterBL.GetAllStaffMasterItems().Where(x => x.staff_phoneNo == Context.Request.Form["user"].ToString() && x.staff_password == Context.Request.Form["password"].ToString()).ToList();

                            if (_lstStaffMaster.Count > 0)
                            {
                                lblError.Visible = false;
                                //Set the User Attributes To A session to further fill the Attribute Class
                                SetUserAttributes(_lstStaffMaster);

                                _lstUserRole = _objUserRoleBL.GetUserRoleItemsByID(_lstStaffMaster[0].user_role_id).ToList();

                                if (_lstUserRole.Count > 0)
                                {
                                    Response.Redirect("/Home", false);
                                }

                                //else  
                                //{
                                //    Response.Redirect("~/Dashboard.aspx", false);
                                //}
                            }

                            else
                            {
                                lblError.Visible = true;
                                lblError.Text = "User name or password Incorrect !";
                                Response.Redirect("/Login.aspx");
                            }
                        }


                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('accept all terms and condition first')", true);
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            

        }

        private void SetUserAttributes(List<App.BusinessModel.StaffMaster> userList)
        {
            Session[Constants.SessionUserList] = userList;
            Session[Constants.UserName] = userList[0].staff_name;
            Session[Constants.LoginID] = userList[0].staff_phoneNo;
            Session[Constants.RoleId] = userList[0].user_role_id;
            Session[Constants.Id] = userList[0].staff_master_id;
        }

        protected void val_terms_CheckedChanged(object sender, EventArgs e)
        {
            if (!val_terms.Checked)
            {
                btnLogin.Enabled = false;
            }
            else
            {
                btnLogin.Enabled = true;
            }

        }
    }
}