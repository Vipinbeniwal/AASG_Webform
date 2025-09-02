using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
    public class OnFloorItemMaster : CommonProperties
    {
        public int on_floor_item_master_id { get; set; }
        public System.Guid guid { get; set; }
        public int production_id { get; set; }
        public string batch_number { get; set; }
        public int parent_item_master_id { get; set; }
        public int on_floor_items_master_id { get; set; }
        public string items_name { get; set; }
        public string items_type { get; set; }
        public string broken_sheet_size { get; set; }
        public int broken_sheet_quantity { get; set; }
        public int per_broken_sheet_quantity { get; set; }
        public int per_broken_sheet_quantity_expected { get; set; }
        public int items_pcs_quantity { get; set; }
        public bool left_over_size_availabel { get; set; }
        public string left_over_size { get; set; }
        public string remarks { get; set; }
       
    }
}
