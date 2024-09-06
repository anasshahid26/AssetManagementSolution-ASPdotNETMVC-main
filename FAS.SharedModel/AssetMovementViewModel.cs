using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.SharedModel
{
    public class AssetMovementViewModel
    {
        public int UserID { get; set; }
        public string Password { get; set; }
        public string L1LocCode { get; set; }
        public string L2LocCode { get; set; }
        public string L3LocCode { get; set; }
        public string L4LocCode { get; set; }
        public string L5LocCode { get; set; }
        public string AssetNumber { get; set; }
        public string DisposedOn { get; set; }
    }
}
