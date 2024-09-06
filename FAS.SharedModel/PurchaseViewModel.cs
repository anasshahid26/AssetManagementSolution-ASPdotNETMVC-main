using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FAS.SharedModel
{
    public class PurchaseViewModel
    {
        public string L1LocCode { get; set; }
        public string LocationName { get; set; }
        public string PurchaseID { get; set; }
        public string SupplierName { get; set; }
        public string DateofPurchase { get; set; }
        public DateTime? DateofPurchase1 { get; set; }
        //public string DateOfPO { get; set; }
        public string SupplierEmail { get; set; }
        public string SupplierID { get; set; }
        public string InvoiceNumber { get; set; }
        public string PONumber { get; set; }
        public Nullable<System.DateTime> DateofPO { get; set; }
        public string iso { get; set; }
        public string CurrencyName { get; set; }
        public string UnitPrice { get; set; }
        public string InvoiceImage { get; set; }
        public string PurchaseOrderImage { get; set; }
        public string NetbookValue { get; set; }
        public string AssetNumber { get; set; }
    }
}
