using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
    public class DrawingMaster : CommonProperties
    {
        public int drawing_master_id { get; set; }
        public System.Guid guid { get; set; }
        public string selected_item_master_id { get; set; }
        public string drawing_name { get; set; }
        public string drawing_type { get; set; }
        public string drawing_alias { get; set; }
        public string drawing_description { get; set; }
        public string drawing_image { get; set; }
       
    }
}
