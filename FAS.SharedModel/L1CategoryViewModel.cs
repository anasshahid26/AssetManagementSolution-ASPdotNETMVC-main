using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FAS.SharedModel
{
    public class L1CategoryViewModel
    {
        public string L1LocCode { get; set; }
        public string L1CatCode { get; set; }
        public string L1CatName { get; set; }
        public string L3CatCode { get; set; }
    }
}
