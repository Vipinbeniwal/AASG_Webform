using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
     public class xp_TimeSheetChild : CommonProperties
    {
        public int time_sheet_child_id { get; set; }
        public System.Guid guid { get; set; }
        public int staff_master_id { get; set; }
        public string staff_name { get; set; }
        public int project_id { get; set; }
        public string project_name { get; set; }
        public System.DateTime time_sheet_date { get; set; }
        public int time_sheet_header_id { get; set; }
        public string hours { get; set; }
        public string remarks { get; set; }
    }
}
