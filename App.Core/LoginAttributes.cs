using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;
using App.BusinessModel;

namespace App.Core
{
    public class LoginAttributes
    {
        public void SetLoginParam(ILogin loginModule, HttpSessionState session, HttpResponse response)
        {
            List<StaffMaster> userList = (List<StaffMaster>)(session[Constants.SessionUserList]);

            if (session == null || response == null || userList == null)
            {
                response.Redirect(Constants.LoginPage);
            }
            else
            {

                loginModule.loginParams = new LoginParams();
                loginModule.loginParams.id = userList[0].staff_master_id;
                loginModule.loginParams.user_name = userList[0].staff_name;
                loginModule.loginParams.user_type ="";
                loginModule.loginParams.login_id = userList[0].staff_phoneNo.ToString();
                loginModule.loginParams.password = userList[0].staff_password;
                loginModule.loginParams.role_id = userList[0].user_role_id;
                loginModule.loginParams.is_verified = false;
                loginModule.loginParams.is_active = Convert.ToBoolean(userList[0].is_active);
                loginModule.loginParams.is_password_changed = false;

                loginModule.loginParams.UserList = userList;
            }

        }
    }
}
