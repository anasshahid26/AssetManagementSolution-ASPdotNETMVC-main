using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.SharedModel
{
    public class ReverificationViewModel
    {
        public string AssetNumber { get; set; }
        public string AssetDescription { get; set; }
        public string Group { get; set; }
        public string Category { get; set; }
        public string Section { get; set; }
        public string Floor { get; set; }
        public string RoomNo { get; set; }
        public string RoomType { get; set; }
        //*************************************
        public string CatCode { get; set; }
        public string L1CatName { get; set; }
        //*************************************
        public string L1CatCode { get; set; }
        public string L2CatCode { get; set; }
        public string L3CatCode { get; set; }
        public string L4CatCode { get; set; }
        //*************************************
        public string L1LocCode { get; set; }
        public string L2LocCode { get; set; }
        public string L3LocCode { get; set; }
        public string L4LocCode { get; set; }
        public string L5LocCode { get; set; }
        //*************************************
        public string L1LocName { get; set; }
        public string L2LocName { get; set; }
        public string L3LocName { get; set; }
        public string L4LocName { get; set; }
        public string L5LocName { get; set; }
        //*************************************
        public string ITC1 { get; set; }
        public string ITC2 { get; set; }
        public string ITC3 { get; set; }
        //*************************************
        public string LOCCODEASSET { get; set; }
        public string ROOMTYPECODE { get; set; }
        public string CODELEVEL { get; set; }
        //*************************************
        public string Status { get; set; }
        public string DisposedOn { get; set; }
        public string VerificationStatus { get; set; }
        public string DateOfVerification { get; set; }
        public string CreatedOn { get; set; }
        public string Depreciated { get; set; }
        public string NetBookValue { get; set; }
        //*************************************
        public string RUniqueID { get; set; }
        public string RAssetNumber { get; set; }
        public string RAssetDescription { get; set; }
        //*************************************
        public string RCatCode { get; set; }
        public string RL1CatName { get; set; }
        //*************************************
        public string RL1CatCode { get; set; }
        public string RL2CatCode { get; set; }
        public string RL3CatCode { get; set; }
        public string RL4CatCode { get; set; }
        //*************************************
        public string RL1LocName { get; set; }
        public string RL2LocName { get; set; }
        public string RL3LocName { get; set; }
        public string RL4LocName { get; set; }
        public string RL5LocName { get; set; }

        //*************************************
        public string RL1LocCode { get; set; }
        public string RL2LocCode { get; set; }
        public string RL3LocCode { get; set; }
        public string RL4LocCode { get; set; }
        public string RL5LocCode { get; set; }
        //*************************************
        public string RITC1 { get; set; }
        public string RITC2 { get; set; }
        public string RITC3 { get; set; }
        //*************************************
        public string RLOCCODEASSET { get; set; }
        public string RROOMTYPECODE { get; set; }
        public string RCODELEVEL { get; set; }
        //*************************************
        public string RStatus { get; set; }
        public string RDisposedOn { get; set; }
        public string RVerificationStatus { get; set; }
        public string RDateOfVerification { get; set; }
        public string RCreatedOn { get; set; }
        public string RDepreciated { get; set; }
        public string RNetBookValue { get; set; }
        public string NewBarcode { get; set; }
        public string OldBarcode { get; set; }
        public IList<AssetViewModel> Assets { get; set; }
        public List<SearchViewModel> VerifiedAssets { get; set; }
        public List<SearchViewModel> UnverifiedAssets { get; set; }
        public int Count { get; set; }
        public List<string> ongoingRevericationDates { get; set; }

    }
}
