using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.SharedModel
{
    public class ExportExcelFormatOne
    {
        public string BarcodeID { get; set; }
        public string AssetDescription { get; set; }
        public string Group { get; set; }
        public string Category { get; set; }
        public string Section { get; set; }
        public string Room_No { get; set; }
        public string Room_Type { get; set; }
        public string Floor { get; set; }
        public DateTime DateofPurchase { get; set; }
        public string Status { get; set; }
    }
}
