using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
     public class TourExpenseItem : CommonProperties
    {
        public int tour_expense_item_id { get; set; }
        public int tour_expense_header_id { get; set; }
        public int tour_master_id { get; set; }
        public System.Guid guid { get; set; }
        public System.DateTime expense_date { get; set; }
        public int expense_food { get; set; }
        public int expense_hotel { get; set; }
        public int expense_conveyance { get; set; }
        public int expense_misc { get; set; }
        public int expense_total_item { get; set; }
        public int expense_total_approved_item { get; set; }
        public int approved_by { get; set; }
    }
}
