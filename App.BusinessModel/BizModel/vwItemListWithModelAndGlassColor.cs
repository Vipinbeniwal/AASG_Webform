using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
     public class vwItemListWithModelAndGlassColor : CommonProperties
    {
        public int item_master_id { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string modelwithglass { get; set; }
        public string item_type_name { get; set; }
        public string thickness { get; set; }
        public string plant_name { get; set; }
        public int plant_no { get; set; }
        public string category { get; set; }
        public string segment { get; set; }
        public int stock_max_level { get; set; }
        public string price { get; set; }
        public string price_2 { get; set; }
        public int factory_ready_stock { get; set; }

    }
}
