using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.SharedModel
{
    public class SearchViewModel
    {

        public int TID { get; set; }
        public string Status { get; set; }
        public string DateOfDisposal { get; set; }
        public string UniqueID { get; set; }
        public string AssetNumber { get; set; }
        public string AssetDescription { get; set; }
        public string Group { get; set; }
        public string Category { get; set; }
        public string L1CatCode { get; set; }
        public string L2CatCode { get; set; }
        public string L3CatCode { get; set; }
        public string L4CatCode { get; set; }
        public string L1LocCode { get; set; }
        public string L2LocCode { get; set; }
        public string L3LocCode { get; set; }
        public string L4LocCode { get; set; }
        public string L5LocCode { get; set; }
        public string CODELEVEL { get; set; }
        public string LOCCODEASSET { get; set; }
        public string NetBookValue { get; set; }
        public string ROOMTYPECODE { get; set; }
        public string ITC1 { get; set; }
        public string ITC2 { get; set; }
        public string ITC3 { get; set; }
        public string Location { get; set; }
        public string Section { get; set; }
        public string Room_No { get; set; }
        public string Room_Type { get; set; }
        public string Floor { get; set; }
        public string Image { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Size { get; set; }
        public string SerialNumber { get; set; }
        public string BookValue { get; set; }
        public string DisposedOn { get; set; }
        public string VerificationStatus { get; set; }
        public string DateOfVerification { get; set; }
        public string CreatedOn { get; set; }
        public string Depreciated { get; set; }
        public string NetbookValue { get; set; }
        public string UnitPrice{ get; set; }
        public string DisposalNumber { get; set; }
        public string ValueDate { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public DateTime DateOfDepreciation { get; set; }
        public Nullable<int> DepreciationDays { get; set; }
        public Nullable<double> DepreciationAmount { get; set; }
        public Nullable<int> DepreciationRate { get; set; }
        public Nullable<double> NewNetBookValue { get; set; }
    }
}
