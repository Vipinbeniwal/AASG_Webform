using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
    public partial class vwSaleOrderDashboardData
    {
        public string Attribute { get; set; }
        public Nullable<int> Value { get; set; }
        public decimal Total_Amount { get; set; }
    }
}
