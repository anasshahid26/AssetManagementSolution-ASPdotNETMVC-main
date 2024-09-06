using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FAS.SharedModel
{
    public class L3CategoryViewModel
    {
        public string L1LocCode { get; set; }
        public string L3CatCode { get; set; }
        public string L3CatName { get; set; }
        public string L2CatCode { get; set; }
        public string ITC2 { get; set; }
        public string ITC3 { get; set; }
        public int UserID { get; set; }
    }
}
