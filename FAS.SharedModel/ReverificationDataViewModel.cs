using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.SharedModel
{
    public class ReverificationDataViewModel
    {
        public string Status { get; set; }
        public string AssetNumber { get; set; }
        public string AssetDescription { get; set; }
        public string Section { get; set; }
        public string Room_No { get; set; }
        public string Floor { get; set; }
        public string VerificationStatus { get; set; }
        public string DateOfVerification { get; set; }
    }
}
