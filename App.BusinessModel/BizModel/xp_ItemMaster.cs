using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
    public class xp_ItemMaster : CommonProperties
    {
        public int xp_item_master_id { get; set; }
        public System.Guid guid { get; set; }
        public string item_serial_number { get; set; }
        public string item_brand { get; set; }
        public string item_name { get; set; }
        public string item_specification { get; set; }
        public int item_quantity { get; set; }
        public decimal item_price { get; set; }
    }
}
