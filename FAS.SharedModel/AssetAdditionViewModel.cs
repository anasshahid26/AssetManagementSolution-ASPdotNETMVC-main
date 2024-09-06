using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Data;

namespace FAS.SharedModel
{
    public class AssetAdditionViewModel
    {
        public string AssetNumber { get; set; }

        public string bcode { get; set; }
        
        public string L1CatCode { get; set; }
        public string L2CatCode { get; set; }
        public string L3CatCode { get; set; }
        public string L1LocCode { get; set; }
        public string L2LocCode { get; set; }
        public string L3LocCode { get; set; }
        public string L4LocCode { get; set; }
        public string L5LocCode { get; set; }
        public string SupplierID { get; set; }
        public string InvoiceNumber { get; set; }
        public string PONumber { get; set; }
        public string DateofPurchase { get; set; }
        public string DateofPO { get; set; }
        public string iso { get; set; }
        public string UnitPrice { get; set; }
        public string InvoiceImage { get; set; }
        public string PurchaseOrderImage { get; set; }
        public int UserID { get; set; }
    }
}
