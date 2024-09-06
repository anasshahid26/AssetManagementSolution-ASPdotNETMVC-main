using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.SharedModel
{
    public class RoomNoViewModel
    {
        public string BarCode { get; set; }
        public string AssetDescription { get; set; }
        public string RoomNo { get; set; }
        //public string ReverificationStatus { get; set; }
        public int RoomCountOld { get; set; }
        public int RoomCountNew { get; set; }
        public int RoomCount { get; set; }
        public int TotalPreviousData { get; set; }
        public int TotalReverified { get; set; }
        public int TotalVariance { get; set; }
    }
}
