using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.SharedModel
{
    public class GetAssetByLocationIdViewModel
    {
        public string UniqueID { get; set; }
        public string AssetNumber { get; set; }
        public string L1CatCode { get; set; }
        public string L1CatName { get; set; }
        public string L2CatCode { get; set; }
        public string L2CatName { get; set; }
        public string L3CatCode { get; set; }
        public string L1LocCode { get; set; }
        public string L1LocName { get; set; }
        public string L2LocCode { get; set; }
        public string L2LocName { get; set; }
        public string L3LocCode { get; set; }
        public string L3LocName { get; set; }
        public string L4LocCode { get; set; }
        public string L4LocName { get; set; }
        public string L5LocCode { get; set; }
        public string L5LocName { get; set; }
        public string AssetDescription { get; set; }
        public string LOCCODEASSET { get; set; }
        public string CODELEVEL { get; set; }
        public string BookValue { get; set; }
        public string Status { get; set; }
        public string DisposedOn { get; set; }
        public string Depreciated { get; set; }
        public string VerificationStatus { get; set; }
        public string DateOfVerification { get; set; }
        public string CreatedOn { get; set; }
        public string NetbookValue { get; set; }
        public DateTime DateOfDepreciation { get; set; }
        public L4LocationViewModel L4Location { get; set; }
        public IList<AssetNumberViewModel> Assets { get; set; }
        public IList<DepreciationViewModel> DepreciationSetupList { get; set; }
    }
}
