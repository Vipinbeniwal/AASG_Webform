using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
    public class UserRole : CommonProperties
    {
        public int user_role_id { get; set; }
        public System.Guid guid { get; set; }
        public string user_role_name { get; set; }
        public string assigned_menu_ids { get; set; }
    }
}
