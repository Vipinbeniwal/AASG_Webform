using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BusinessModel
{
    public class ItemMaster : CommonProperties
    {
        public int item_master_id { get; set; }
        public System.Guid guid { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public string item_type_name { get; set; }
        public string glass_color { get; set; }
        public string hsn_code { get; set; }
        public string gst_rate { get; set; }
        public string item_height { get; set; }
        public string item_width { get; set; }
        public string actual_sqm { get; set; }
        public string used_sqm { get; set; }
        public string thickness { get; set; }
        public string perimeter { get; set; }
        public string plant_name { get; set; }
        public int plant_no { get; set; }
        public bool diamond_required { get; set; }
        public string diamond_in_rs { get; set; }
        public bool rg_required { get; set; }
        public string rg_in_rs { get; set; }
        public bool washing_one { get; set; }
        public bool hole_required { get; set; }
        public int number_of_holes { get; set; }
        public string diameter { get; set; }
        public bool washing_two { get; set; }
        public bool is_normal_paint { get; set; }
        public string normal_paint_quantity { get; set; }
        public string normal_paint_rs { get; set; }
        public bool is_black_paint { get; set; }
        public string black_paint_quantity { get; set; }
        public string black_paint_rs { get; set; }
        public bool is_dfg_paint { get; set; }
        public string dfg_paint_quantity { get; set; }
        public string dfg_paint_rs { get; set; }
        public bool is_thinner_paint { get; set; }
        public string thinner_paint_quantity { get; set; }
        public decimal thinner_paint_rs { get; set; }
        public int pre_processing_breakage_level { get; set; }
        public int processing_breakage_level { get; set; }
        public bool polish_required { get; set; }
        public string polish_in_rs { get; set; }
        public string connector_type { get; set; }
        public string connector_price { get; set; }
        public bool is_doorclip_required { get; set; }
        public string doorclip_type { get; set; }
        public string doorclip_rate { get; set; }
        public bool packing_polythin_required { get; set; }
        public string packing_in_rs { get; set; }
        public bool packing_paper_required { get; set; }
        public string packing_paper_quantity { get; set; }
        public int stock_max_level { get; set; }
        public string item_weight { get; set; }
        public string price { get; set; }
        public string price_2 { get; set; }
        public string price_type { get; set; }
        public string mm_sqm { get; set; }
        public string first_dop { get; set; }
        public string last_dop { get; set; }
        public string segment { get; set; }
        public string category { get; set; }
        public int priority { get; set; }
        public string clear_focus { get; set; }
        public string max_stock_level_apr_20 { get; set; }
        public string max_stock_level_may_21 { get; set; }
        public string max_stock_level_jan_21 { get; set; }
        public int q1_2021 { get; set; }
        public int q2_2021 { get; set; }
        public int q3_2021 { get; set; }
        public int q4_2021 { get; set; }
        public Nullable<int> pre_processing { get; set; }
        public Nullable<int> during_processing { get; set; }
        public int factory_ready_stock { get; set; }
       

    }
}
