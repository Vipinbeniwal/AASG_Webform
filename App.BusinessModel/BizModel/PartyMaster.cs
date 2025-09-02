using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
     public class PartyMaster : CommonProperties
    {
        public int party_master_id { get; set; }
        public System.Guid guid { get; set; }
        public string party_name { get; set; }
        public string party_contact_person { get; set; }
        public string party_phoneno { get; set; }
        public string party_email { get; set; }
        public string party_gst { get; set; }
        public string party_address { get; set; }
        public string party_state { get; set; }
        public string party_city { get; set; }
        public string party_pincode { get; set; }
        public string party_region { get; set; }
        public decimal tough_discount_precentage { get; set; }
        public int tough_billing_precentage { get; set; }
        public decimal lami_discount_precentage { get; set; }
        public int lami_billing_precentage { get; set; }
        public int netrate_billing_precentage { get; set; }
    }
}
