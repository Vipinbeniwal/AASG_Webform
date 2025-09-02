using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
     public class PurchaseHeader : CommonProperties
    {
        public int purchase_header_id { get; set; }
        public System.Guid guid { get; set; }
        public int supplier_master_id { get; set; }
        public int purchase_items_quantity { get; set; }
        public decimal purchase_items_total_amount { get; set; }
        public string purchase_items_payment_by { get; set; }
        public string purchase_items_reference_number { get; set; }
        public decimal purchase_items_pay_amount { get; set; }
        public decimal purchase_items_pending_amount { get; set; }
        public Nullable<decimal> purchase_item_discount { get; set; }
        public string purchase_item_remarks { get; set; }
        public System.DateTime purchase_item_date { get; set; }


    }
}
