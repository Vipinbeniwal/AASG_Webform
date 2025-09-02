using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
     public class sp_tourdetail_Result
    {
        public System.DateTime reqdate { get; set; }
        public int tour_master_id { get; set; }
        public string tour_name { get; set; }
        public System.DateTime start_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public int staff_master_id { get; set; }
        public string staff_name { get; set; }
        public int tour_numberofdays { get; set; }
        public string tourgrade_name { get; set; }
        public decimal tourgrade_perday_food { get; set; }
        public decimal tourgrade_perday_hotel { get; set; }
        public decimal tourgrade_perday_transport { get; set; }
        public int expense_total { get; set; }
    }
}
