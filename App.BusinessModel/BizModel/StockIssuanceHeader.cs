using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
     public class StockIssuanceHeader : CommonProperties
    {
        public int stock_issuance_header_id { get; set; }
        public System.Guid guid { get; set; }
        public int items_total_quantity { get; set; }
        public decimal items_total_amount { get; set; }
        public string item_remarks { get; set; }
        public System.DateTime item_require_date { get; set; }
    }
}
