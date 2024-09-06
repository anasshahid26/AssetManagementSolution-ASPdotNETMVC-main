using FAS.Services.DataModel;
using FAS.SharedModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Services.Helper;

namespace FAS.Services.V2
{
    public class AssetService
    {
        #region Defined as Singleton
        private static AssetService instance;

        public static AssetService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AssetService();
                }
                return instance;
            }
        }

        private AssetService() { }
        #endregion

        public IEnumerable<SearchViewModel> GetAsset(AssetViewModel assetViewModel)
        {
            using (var context = DataContextHelper.GetMatrixFASDataContext())
            {
                //var query1 = (from asset in context.GetAssetsWithPurchases(
                //                assetViewModel.L1LocCode,
                //                assetViewModel.AssetDescription == "Asset Description" ? null : assetViewModel.AssetDescription,
                //                string.IsNullOrEmpty(assetViewModel.AssetNumber) ? null : assetViewModel.AssetNumber,
                //                assetViewModel.L1CatName == "Asset Group" ? null : assetViewModel.L1CatName,
                //                assetViewModel.L2CatName == "Asset Category" ? null : assetViewModel.L2CatName,
                //                assetViewModel.L2LocName == "Asset Section" ? null : assetViewModel.L2LocName,
                //                assetViewModel.L3LocName == "Asset Room No" ? null : assetViewModel.L3LocName,
                //                assetViewModel.L4LocName == "Asset Room Type" ? null : assetViewModel.L4LocName,
                //                assetViewModel.CODELEVEL == "Asset Floor" ? null : assetViewModel.CODELEVEL,
                //                assetViewModel.Status == "ALL" ? null : assetViewModel.Status)
                //              select new SearchViewModel
                //              {
                //                  AssetNumber = asset.AssetNumber,
                //                  AssetDescription = asset.AssetDescription,
                //                  Group = asset.L1CatName,
                //                  Category = asset.L2CatName,
                //                  Image = asset.L3CatCode,
                //                  Location = asset.L1LocName,
                //                  Section = asset.L2LocName,
                //                  Room_No = asset.L3LocName,
                //                  Room_Type = asset.L4LocName,
                //                  Floor = asset.L5LocName,
                //                  BookValue = "Not Available",
                //                  Status = asset.Status,
                //                  Brand = asset.Brand,
                //                  SerialNumber = asset.SerialNumber,
                //                  Size = asset.Size,
                //                  Color = asset.Color,
                //                  DisposedOn = asset.DisposedOn,
                //                  VerificationStatus = asset.VerificationStatus,
                //                  DateOfVerification = asset.DateOfVerification,
                //                  Depreciated = asset.Depreciated,
                //                  NetbookValue = asset.NetBookValue,
                //                  ValueDate = "Not Available",
                //                  DateOfPurchase = asset.DateofPurchase.Value,
                //                  UnitPrice = asset.UnitPrice

                //              }).ToList();

                //if (query1.Count == 0)
                //{
                var query1 = (from asset in context.GetAssets(
                    assetViewModel.L1LocCode,
                    assetViewModel.AssetDescription == "Asset Description" ? null : assetViewModel.AssetDescription,
                    string.IsNullOrEmpty(assetViewModel.AssetNumber) ? null : assetViewModel.AssetNumber,
                    assetViewModel.L1CatName == "Asset Group" ? null : assetViewModel.L1CatName,
                    assetViewModel.L2CatName == "Asset Category" ? null : assetViewModel.L2CatName,
                    assetViewModel.L2LocName == "Asset Section" ? null : assetViewModel.L2LocName,
                    assetViewModel.L3LocName == "Asset Room No" ? null : assetViewModel.L3LocName,
                    assetViewModel.L4LocName == "Asset Room Type" ? null : assetViewModel.L4LocName,
                    assetViewModel.CODELEVEL == "Asset Floor" ? null : assetViewModel.CODELEVEL,
                    assetViewModel.Status == "ALL" ? null : assetViewModel.Status)
                              select new SearchViewModel
                              {
                                  AssetNumber = asset.AssetNumber,
                                  AssetDescription = asset.AssetDescription,
                                  Group = asset.L1CatName,
                                  Category = asset.L2CatName,
                                  Image = asset.L3CatCode,
                                  Location = asset.L1LocName,
                                  Section = asset.L2LocName,
                                  Room_No = asset.L3LocName,
                                  Room_Type = asset.L4LocName,
                                  Floor = asset.L5LocName,
                                  BookValue = "Not Available",
                                  Status = asset.Status,
                                  Brand = asset.Brand,
                                  SerialNumber = asset.SerialNumber,
                                  Size = asset.Size,
                                  Color = asset.Color,
                                  DisposedOn = asset.DisposedOn,
                                  VerificationStatus = asset.VerificationStatus,
                                  DateOfVerification = asset.DateOfVerification,
                                  Depreciated = asset.Depreciated,
                                  NetbookValue = asset.NetBookValue,
                                  ValueDate = "Not Available",
                                  UnitPrice = "NONE"

                              }).ToList();

                return query1;
            }
        }

        public IEnumerable<SearchViewModel> GetAssetTagging(AssetViewModel assetViewModel)
        {
            using (var context = DataContextHelper.GetMatrixFASDataContext())
            {
                //var query1 = (from asset in context.GetAssetsWithPurchases(
                //                assetViewModel.L1LocCode,
                //                assetViewModel.AssetDescription == "Asset Description" ? null : assetViewModel.AssetDescription,
                //                string.IsNullOrEmpty(assetViewModel.AssetNumber) ? null : assetViewModel.AssetNumber,
                //                assetViewModel.L1CatName == "Asset Group" ? null : assetViewModel.L1CatName,
                //                assetViewModel.L2CatName == "Asset Category" ? null : assetViewModel.L2CatName,
                //                assetViewModel.L2LocName == "Asset Section" ? null : assetViewModel.L2LocName,
                //                assetViewModel.L3LocName == "Asset Room No" ? null : assetViewModel.L3LocName,
                //                assetViewModel.L4LocName == "Asset Room Type" ? null : assetViewModel.L4LocName,
                //                assetViewModel.CODELEVEL == "Asset Floor" ? null : assetViewModel.CODELEVEL,
                //                assetViewModel.Status == "ALL" ? null : assetViewModel.Status)
                //              select new SearchViewModel
                //              {
                //                  AssetNumber = asset.AssetNumber,
                //                  AssetDescription = asset.AssetDescription,
                //                  Group = asset.L1CatName,
                //                  Category = asset.L2CatName,
                //                  Image = asset.L3CatCode,
                //                  Location = asset.L1LocName,
                //                  Section = asset.L2LocName,
                //                  Room_No = asset.L3LocName,
                //                  Room_Type = asset.L4LocName,
                //                  Floor = asset.L5LocName,
                //                  BookValue = "Not Available",
                //                  Status = asset.Status,
                //                  Brand = asset.Brand,
                //                  SerialNumber = asset.SerialNumber,
                //                  Size = asset.Size,
                //                  Color = asset.Color,
                //                  DisposedOn = asset.DisposedOn,
                //                  VerificationStatus = asset.VerificationStatus,
                //                  DateOfVerification = asset.DateOfVerification,
                //                  Depreciated = asset.Depreciated,
                //                  NetbookValue = asset.NetBookValue,
                //                  ValueDate = "Not Available",
                //                  DateOfPurchase = asset.DateofPurchase.Value,
                //                  UnitPrice = asset.UnitPrice

                //              }).ToList();

                //if (query1.Count == 0)
                //{
                    var query1 = (from assettagging in context.GetAssets(
                        assetViewModel.L1LocCode, 
                      
                       
                       
                        assetViewModel.L2LocName == "Asset Section" ? null : assetViewModel.L2LocName, 
                        assetViewModel.L3LocName == "Asset Room No" ? null : assetViewModel.L3LocName 
                   
                    
                       )
                              select new SearchViewModel
                              {

                                  TID = assettagging.TID,
                                  AssetNumber = assettagging.AssetNumber,
                                  AssetDescription = assettagging.AssetDescription,
                                  Group = assettagging.L1CatName,
                                  Category = assettagging.L2CatName,
                                  Image = assettagging.L3CatCode,
                                  Location = assettagging.L1LocName,
                                  Section = assettagging.L2LocName,
                                  Room_No = assettagging.L3LocName,
                                  Room_Type = assettagging.L4LocName,
                                  Floor = assettagging.L5LocName,
                                  BookValue = "Not Available",
                                  Status = assettagging.Status,
                                  Brand = assettagging.Brand,
                                  SerialNumber = assettagging.SerialNumber,
                                  Size = assettagging.Size,
                                  Color = assettagging.Color,
                                  DisposedOn = assettagging.DisposedOn,
                                  VerificationStatus = assettagging.VerificationStatus,
                                  DateOfVerification = assettagging.DateOfVerification,
                                  Depreciated = assettagging.Depreciated,
                                  NetbookValue = assettagging.NetBookValue,
                                  ValueDate = "Not Available",
                                  UnitPrice = "NONE"

                              }).ToList();

                return query1;
            }
        }

        public string AddL2Category (L2CategoryViewModel data)
        {
            using (var context = DataContextHelper.GetMatrixFASDataContext())
            {
                string l2CatCode = data.L1CatCode + data.L2CatName.GetPrefix(3);
                context.L2Categories.InsertOnSubmit(new L2Category()
                {
                    L1CatCode = data.L1CatCode,
                    L1LocCode = data.L1LocCode,
                    L2CatName = data.L2CatName,
                    ITC1 = data.L2CatName.GetPrefix(3),
                    L2CatCode = l2CatCode
                });
                context.SubmitChanges();
                return l2CatCode;
            }
        }

        public string UpdateAsset(string oldId, string newID)
        {
            using (var context = DataContextHelper.GetMatrixFASDataContext())
            {
                try
                {
                    var assetNumberExist = (from ass in context.Assets
                                            where ass.AssetNumber == newID
                                            select ass)
                                            .FirstOrDefault();
                    if (assetNumberExist == null)
                    {
                        var asset = (from ass in context.Assets
                                     where ass.AssetNumber == oldId
                                     select ass)
                                     .FirstOrDefault();
                        asset.AssetNumber = newID;
                        context.SubmitChanges();
                        return "Updated";
                    }
                    else
                    {
                        return "New Barcode Already Exist.";
                    }
                }
                catch
                {
                    return "Error";
                }
            }
        }

    }

    

}
