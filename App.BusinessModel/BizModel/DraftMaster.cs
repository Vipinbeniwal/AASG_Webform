using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
    public class DraftMaster : CommonProperties
    {
        public int draft_master_id { get; set; }
        public System.Guid guid { get; set; }
        public int production_id { get; set; }
        public string batch_number { get; set; }
        public int parent_item_master_id { get; set; }
        public string items_name { get; set; }
        public bool left_over_size_availabel { get; set; }
        public string left_over_size { get; set; }
        public int draft_quantity { get; set; }
        public string draft_status { get; set; }
        public string remarks { get; set; }

    }
}
