using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
     public class ProductionPlanning : CommonProperties
    {
        public int production_planning_id { get; set; }
        public System.Guid guid { get; set; }
        public int item_master_id { get; set; }
        public string item_brand { get; set; }
        public string item_model { get; set; }
        public string item_type_name { get; set; }
        public string item_glass_color { get; set; }
        public int party_master_id { get; set; }
        public int order_quantity { get; set; }
        public int overall_total_item { get; set; }
        public int factory_stock { get; set; }
        public int shortage { get; set; }
        public int stock_max_level { get; set; }
        public int production_quantity { get; set; }
    }
}
