using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.SharedModel
{
    public class DepreciationViewModel
    {
        public string L1CatCode { get; set; }
        public string UniqueID { get; set; }
        public string AssetDescription { get; set; }
        public string ValueDate { get; set; }
        public string BookValue { get; set; }
        public string DepreciationRate { get; set; }
        public Nullable<System.DateTime> DepreciationDate { get; set; }
        public Nullable<int> DepreciationDays { get; set; }
        public string DepreciationAmount { get; set; }
        public string NetBookValue { get; set; }
        public string L1LocCode { get; set; }
        public int DepreciatedValue { get; set; }
    }
}
