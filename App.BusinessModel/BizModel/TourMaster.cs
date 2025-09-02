using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
     public class TourMaster : CommonProperties
    {
        public int tour_master_id { get; set; }
        public System.Guid guid { get; set; }
        public string tour_name { get; set; }
        public System.DateTime start_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public int staff_master_id { get; set; }
        public int tour_numberofdays { get; set; }
        public string tour_agenda { get; set; }
        public bool is_approved { get; set; }
        public string tour_status { get; set; }
        public string staff_name { get; set; }
    }
}
