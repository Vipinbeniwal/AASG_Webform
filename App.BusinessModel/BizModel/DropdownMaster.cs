using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
     public class DropdownMaster : CommonProperties
    {
        public int dropdown_master_id { get; set; }
        public System.Guid guid { get; set; }
        public string dropdown_type { get; set; }
        public string dropdown_item_name { get; set; }
        public string dropdown_item_alias { get; set; }
    }
}
