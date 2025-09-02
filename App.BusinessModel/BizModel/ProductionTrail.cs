using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
     public class ProductionTrail : CommonProperties
    {
        public int production_trail_id { get; set; }
        public System.Guid guid { get; set; }
        public int production_id { get; set; }
        public int item_master_id { get; set; }
        public string process_name { get; set; }
        public string user_name { get; set; }
        public string heading { get; set; }
        public string heading_class { get; set; }
        public string activity { get; set; }
        public string icon { get; set; }
        public string icon_class { get; set; }
    }
}
