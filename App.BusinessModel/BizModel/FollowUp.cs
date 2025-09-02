using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
     public class FollowUp : CommonProperties
    {
        public int followup_id { get; set; }
        public System.Guid guid { get; set; }
        public int lead_header_id { get; set; }
        public System.DateTime followup_date { get; set; }
        public string followup_text { get; set; }
        public System.DateTime next_followup_date { get; set; }
        public string special_remarks { get; set; }
    }
}
