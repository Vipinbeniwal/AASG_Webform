using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
     public class LeadHeader : CommonProperties
    {
        public int lead_header_id { get; set; }
        public System.Guid guid { get; set; }
        public int party_master_id { get; set; }
        public string party_name { get; set; }
        public string party_contact_person { get; set; }
        public string party_phoneno { get; set; }
        public System.DateTime followup_date { get; set; }
        public string lead_remarks { get; set; }
    }
}
