using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
     public class xp_TimeSheetHeader : CommonProperties
    {
        public int time_sheet_header_id { get; set; }
        public System.Guid guid { get; set; }
        public int staff_master_id { get; set; }
        public string staff_name { get; set; }
        public string total_hours { get; set; }
        public string remarks { get; set; }
        public bool is_approved { get; set; }
        public string status { get; set; }
        public string approved_by { get; set; }
        public System.DateTime approved_date { get; set; }
        
    }
}
