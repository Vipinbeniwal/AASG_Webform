using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
    public partial class sp_StockLedgerDetail_Result : CommonProperties
    {
        public Nullable<int> purchase_header_id { get; set; }
        public string purchase_invoice_number { get; set; }
        public Nullable<int> purchase_item_quantity { get; set; }
        public Nullable<int> purchase_item_received_quantity { get; set; }
       
    }
}
