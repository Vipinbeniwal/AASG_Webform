using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
     public class xp_ProcurementItem : CommonProperties
    {
        public int xp_procurement_item_id { get; set; }
        public System.Guid guid { get; set; }
        public int supplier_master_id { get; set; }
        public int xp_procurement_header_id { get; set; }
        public int item_master_id { get; set; }
        public string purchase_item_brand { get; set; }
        public string purchase_item_name { get; set; }
        public int purchase_item_quantity { get; set; }
        public int purchase_item_price { get; set; }
       
    }
}
