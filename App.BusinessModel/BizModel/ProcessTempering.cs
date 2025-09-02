using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
    public class ProcessTempering : CommonProperties
    {
        public int process_tempering_id { get; set; }
        public System.Guid guid { get; set; }
        public int item_master_id { get; set; }
        public string item_brand { get; set; }
        public string item_model { get; set; }
        public string item_type_name { get; set; }
        public string item_glass_color { get; set; }
        public string sale_header_master_id { get; set; }
        public string party_master_id { get; set; }
        public string batch_number { get; set; }
        public int production_quantity { get; set; }
        public System.DateTime tempering_started_on { get; set; }
        public System.DateTime tempering_ended_on { get; set; }
        public string item_thickness { get; set; }
        public string item_sheet_size { get; set; }
        public int sheet_issued { get; set; }
        public int target_pcs_from_sheet_issued { get; set; }
        public int actual_pcs_from_sheet_issued { get; set; }
        public string draft_size { get; set; }
        public int target_pcs_from_draft_size { get; set; }
        public int actual_pcs_from_draft_size { get; set; }
        public int pcs_from_rejection { get; set; }
        public int actual_pcs_from_rejection { get; set; }
        public int broken_sheets_in_crate { get; set; }
        public int broken_no_of_sheet { get; set; }
        public int broken_pcs_cut_from_sheet { get; set; }
        public string broken_left_over_size { get; set; }
        public int total_received { get; set; }
        public int total_broken { get; set; }
        public int total_reject { get; set; }
        public int total_pcs_transferred { get; set; }
        public int signature { get; set; }
        public string breakage_pcs_number { get; set; }
        public string breakage_reason { get; set; }
        public string reject_pcs_number { get; set; }
        public string reject_reason { get; set; }
        public string remarks { get; set; }
        public string tempering_status { get; set; }

    }
}
