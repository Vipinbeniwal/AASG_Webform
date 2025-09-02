using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
     public class TourGradeMaster : CommonProperties
    {
        public int tourgrade_master_id { get; set; }
        public System.Guid guid { get; set; }
        public string tourgrade_name { get; set; }
        public decimal tourgrade_perday_transport { get; set; }
        public decimal tourgrade_perday_food { get; set; }
        public decimal tourgrade_perday_hotel { get; set; }
        public decimal tourgrade_perday_misc { get; set; }
    }
}
