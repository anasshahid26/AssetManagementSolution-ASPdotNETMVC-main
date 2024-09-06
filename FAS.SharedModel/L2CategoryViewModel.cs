using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FAS.SharedModel
{
    public class L2CategoryViewModel
    {
        public string L3CatCode { get; set; }
        public string L2CatCode { get; set; }
        public string L1CatCode { get; set; }
        public string L1LocCode { get; set; }
        public string ITC1 { get; set; }
        public string L2CatName { get; set; }
    }
}
