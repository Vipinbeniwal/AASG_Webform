using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace App.BusinessModel
{
     public class CommonProperties
    {
        public System.DateTime created_on { get; set; }
        public int created_by { get; set; }
        public System.DateTime modified_on { get; set; }
        public int modified_by { get; set; }
        public string user_ip { get; set; }
        public bool is_active { get; set; }

        public static decimal FormatDecimalNumber(decimal value, int precision)
        {
            //return Math.Truncate(value * 100) / 100;
            return Convert.ToDecimal(decimal.Round(value, precision, MidpointRounding.AwayFromZero).ToString("#.00"));
        }
    }

    
}
