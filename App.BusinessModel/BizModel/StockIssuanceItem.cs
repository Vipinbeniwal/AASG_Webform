using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
     public class StockIssuanceItem : CommonProperties
    {
        public int stock_issuance_item_id { get; set; }
        public System.Guid guid { get; set; }
        public int stock_issuance_header_id { get; set; }
        public int item_master_id { get; set; }
        public string item_name { get; set; }
        public int item_quantity { get; set; }
        public decimal item_amount { get; set; }
    }
}
