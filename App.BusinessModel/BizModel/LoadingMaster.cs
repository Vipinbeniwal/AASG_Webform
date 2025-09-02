using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
     public class LoadingMaster : CommonProperties
    {
        public int loading_master_id { get; set; }
        public System.Guid guid { get; set; }
        public int sale_header_id { get; set; }
        public string order_number { get; set; }
        public int item_master_id { get; set; }
        public int party_master_id { get; set; }
        public int sale_item_type_id { get; set; }
        public string sale_item_type_title { get; set; }
        public string sale_item_name { get; set; }
        public int sale_item_quantity { get; set; }
        public decimal sale_item_price { get; set; }
        public decimal item_weight { get; set; }
       
    }
}
