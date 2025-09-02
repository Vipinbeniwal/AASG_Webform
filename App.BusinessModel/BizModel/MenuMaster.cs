using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
     public class MenuMaster : CommonProperties
    {
        public int menu_master_id { get; set; }
        public System.Guid guid { get; set; }
        public string display_name { get; set; }
        public string page_url { get; set; }
        public int parent_id { get; set; }
        public Nullable<int> parent_order { get; set; }
        public Nullable<int> child_order { get; set; }
        public string cssclass { get; set; }
    }
}
