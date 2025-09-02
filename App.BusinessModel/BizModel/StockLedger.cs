using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
     public class StockLedger : CommonProperties
    {
        public int stock_ledger_id { get; set; }
        public System.Guid guid { get; set; }
        public int purchase_header_id { get; set; }
        public string purchase_invoice_number { get; set; }
        public int item_master_id { get; set; }
        public string purchase_item_name { get; set; }
        public int purchase_item_quantity { get; set; }
        public int purchase_item_received_quantity { get; set; }
        public string purchase_item_remarks { get; set; }
    }
}
