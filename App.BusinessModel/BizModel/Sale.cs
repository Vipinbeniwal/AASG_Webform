using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
     public class Sale : SaleHeader
    {
        public List<SaleItem> sale_items { get; set; }
    }
}
