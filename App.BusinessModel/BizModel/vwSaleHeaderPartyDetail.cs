using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
     public class vwSaleHeaderPartyDetail : CommonProperties
    {
        public int sale_header_id { get; set; }
        public System.Guid guid { get; set; }
        public int party_master_id { get; set; }
        public int total_items { get; set; }
        public Nullable<decimal> total_amount_billed { get; set; }
        public Nullable<decimal> total_amount_cash { get; set; }
        public Nullable<decimal> tough_discount { get; set; }
        public Nullable<decimal> htf_discount { get; set; }
        public Nullable<decimal> lami_discount { get; set; }
        public string sale_item_remarks { get; set; }
        public System.DateTime sale_item_date { get; set; }
        public string price_list { get; set; }
        public Nullable<decimal> total_net_rate { get; set; }
        public string made_by { get; set; }
        public string approved_by { get; set; }
        public string order_status { get; set; }
        public string party_name { get; set; }
        public string party_contact_person { get; set; }
        public string party_phoneno { get; set; }
        public string party_email { get; set; }
        public string party_gst { get; set; }
        public string party_address { get; set; }
        public string party_city { get; set; }
        public string party_state { get; set; }
        public string party_pincode { get; set; }
        public string party_region { get; set; }
        public decimal tough_discount_precentage { get; set; }
        public Nullable<decimal> tough_billing_amount { get; set; }
        public int tough_billing_precentage { get; set; }
        public decimal lami_discount_precentage { get; set; }
        public int lami_billing_precentage { get; set; }
        public Nullable<decimal> lami_billing_amount { get; set; }
        public Nullable<decimal> total_amount { get; set; }
        public int netrate_billing_precentage { get; set; }
        public Nullable<decimal> netrate_billing_amount { get; set; }
        public Nullable<decimal> gst_amount { get; set; }
        public Nullable<decimal> billing_grand_total { get; set; }
        public string order_number { get; set; }
        public string rejection_remarks { get; set; }
        public decimal tough_discount_precentage_party { get; set; }
        public int tough_billing_precentage_party { get; set; }
        public decimal lami_discount_precentage_party { get; set; }
        public int lami_billing_precentage_party { get; set; }
        public int netrate_billing_precentage_party { get; set; }
        public decimal total_weight { get; set; }
        public string staff_name { get; set; }

    }
}
