using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
    [Serializable]
    public class SaleItem : CommonProperties
    {
        public int sale_item_id { get; set; }
        public System.Guid guid { get; set; }
        public int sale_header_id { get; set; }
        public int item_master_id { get; set; }
        public int party_master_id { get; set; }
        public int sale_item_type_id { get; set; }
        public string sale_item_type_title { get; set; }
        public string sale_item_name { get; set; }
        public int sale_item_quantity { get; set; }
        public decimal sale_item_price { get; set; }
        public decimal sale_item_price_2 { get; set; }
        public decimal sale_item_net_price { get; set; }
        public decimal item_weight { get; set; }
        public int item_gst_percentage { get; set; }
        public string item_unit { get; set; }
        public decimal item_discount_percentage { get; set; }
        public decimal item_discount_amount { get; set; }
        public decimal item_bill_percentage { get; set; }
        public decimal item_amount { get; set; }
        public decimal item_bill_rate { get; set; }
        public decimal item_bill_amount { get; set; }
        public decimal item_gst_amount { get; set; }
        public decimal item_final_amount { get; set; }
    }
}
