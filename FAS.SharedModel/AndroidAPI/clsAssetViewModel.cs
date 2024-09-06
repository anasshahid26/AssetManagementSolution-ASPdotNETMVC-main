using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.SharedModel.AndroidAPI
{
    public class clsAssetViewModel
    {
        public int tid { get; set; }
        public string unique_id { get; set; }
        public string asset_number { get; set; }
        public string asset_description { get; set; }
        public string group_code { get; set; }
        public string category_code { get; set; }
        public string _L3CatCode { get; set; }
        public string _L4CatCode { get; set; }
        public string location_code { get; set; }
        public string section_code { get; set; }
        public string room_code { get; set; }
        public string room_code_debug { get; set; }
        public string room_type_code { get; set; }
        public string floor_code { get; set; }
        public string floor_code_debug { get; set; }
        public string location_name { get; set; }
        public string section_name { get; set; }
        public string room_name { get; set; }
        public string room_type_name { get; set; }
        public string floor_name { get; set; }
        public string created_on { get; set; }

    }
}
