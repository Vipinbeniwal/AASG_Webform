using App.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core
{
    public class LoginParams
    {
        public long id { get; set; }
        public string user_name { get; set; }
        public string user_type { get; set; }
        public string login_id { get; set; }
        public string password { get; set; }
        public int role_id { get; set; }
        public bool is_verified { get; set; }
        public bool is_active { get; set; }
        public bool is_password_changed { get; set; }

        public List<StaffMaster> UserList { get; set; }
    }
}
