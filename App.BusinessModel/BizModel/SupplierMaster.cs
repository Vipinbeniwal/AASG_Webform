using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
     public class SupplierMaster : CommonProperties
    {
        public int supplier_master_id { get; set; }
        public System.Guid guid { get; set; }
        public string supplier_name { get; set; }
        public string supplier_contact_person { get; set; }
        public string supplier_phoneno { get; set; }
        public string supplier_email { get; set; }
        public string supplier_gst { get; set; }
        public string supplier_address { get; set; }
        public string supplier_state { get; set; }
        public string supplier_city { get; set; }
        public string supplier_pincode { get; set; }
        public string supplier_region { get; set; }
    }
}
