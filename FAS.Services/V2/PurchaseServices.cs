using FAS.Services.DataModel;
using FAS.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FAS.Services.V2
{
    public class PurchaseServices
    {
        #region Defined as Singleton
        private static PurchaseServices instance;

        public static PurchaseServices Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PurchaseServices();
                }
                return instance;
            }
        }

        private PurchaseServices() { }
        #endregion

        public string AddMultipleAssetsPurchaseDetail(PurchaseViewModel assetAddition, List<string> assetNumbers)
        {
            string purchaseID = GetPurchaseDetailID(assetAddition.L1LocCode);
            using (var context = DataContextHelper.GetMatrixFASDataContext())
            {
                var availableAssets = (from asset in context.Assets
                                       where assetNumbers.Contains(asset.AssetNumber)
                                       select asset)
                                       .ToList();

                context.PurchaseDetails.InsertOnSubmit(new PurchaseDetail()
                {
                    PurchaseID = purchaseID,
                    SupplierID = assetAddition.SupplierID,
                    InvoiceNumber = assetAddition.InvoiceNumber,
                    PONumber = assetAddition.PONumber,
                    DateofPO = Convert.ToDateTime(assetAddition.DateofPO),
                    iso = assetAddition.iso,
                    InvoiceImage = assetAddition.InvoiceImage,
                    UnitPrice = assetAddition.UnitPrice,
                    PurchaseOrderImage = assetAddition.PurchaseOrderImage,
                    L1LocCode = assetAddition.L1LocCode,
                    DateofPurchase = Convert.ToDateTime(assetAddition.DateofPurchase),
                });
                context.SubmitChanges();

                foreach (var item in availableAssets)
                {
                    context.AssetPurchases.InsertOnSubmit(new AssetPurchase()
                    {
                        AssetPurchase1 = GetAssetPurchaseID(assetAddition.L1LocCode),
                        L1LocCode = assetAddition.L1LocCode,
                        PurchaseID = purchaseID,
                        UniqueID = item.UniqueID
                    });
                    context.SubmitChanges();
                }
            }
            return purchaseID;
        }

        public PurchaseViewModel PurchaseDetails(AssetViewModel Collection)
        {
            using (var context = DataContextHelper.GetMatrixFASDataContext())
            {
                var purchaseDetails = (from purchase in context.PurchaseDetails
                                       join assetPurc in context.AssetPurchases on purchase.PurchaseID
                                       equals assetPurc.PurchaseID
                                       where assetPurc.UniqueID == Collection.UniqueID
                                       select purchase).FirstOrDefault();

                PurchaseViewModel result = new PurchaseViewModel();
                if (purchaseDetails != null)
                {
                    result.PurchaseID = purchaseDetails.PurchaseID;
                    result.SupplierName = purchaseDetails.Supplier.SupplierName;
                    result.InvoiceNumber = purchaseDetails.InvoiceNumber;
                    result.DateofPurchase = purchaseDetails.DateofPurchase.ToString();
                    result.iso = purchaseDetails.Currency.name;
                    result.UnitPrice = purchaseDetails.UnitPrice;
                    result.PONumber = purchaseDetails.PONumber;
                    //result.DateOfPO = purchaseDetails.DateofPO.ToString();
                    result.SupplierEmail = purchaseDetails.Supplier.SupplierEmail;
                    result.InvoiceImage = string.IsNullOrEmpty(purchaseDetails.InvoiceImage) ? string.Empty : purchaseDetails.InvoiceImage.ToLower().Contains("not available") ? string.Empty : purchaseDetails.InvoiceImage;
                    result.PurchaseOrderImage = string.IsNullOrEmpty(purchaseDetails.PurchaseOrderImage) ? string.Empty : purchaseDetails.PurchaseOrderImage.ToLower().Contains("not available") ? string.Empty : purchaseDetails.PurchaseOrderImage;
                }

                return result;
            }
        }

        public PurchaseViewModel GetPurchaseDetailbyID(string l1LocCode, string purchaseID, string assetNumber)
        {
            using (var context = DataContextHelper.GetMatrixFASDataContext())
            {
                var purchaseDetails = (from purchase in context.PurchaseDetails
                                       where purchase.PurchaseID == purchaseID && purchase.L1LocCode == l1LocCode
                                       select new PurchaseViewModel()
                                       {
                                           L1LocCode = purchase.L1LocCode,
                                           LocationName = purchase.AssetLocation.L1LocName,
                                           PurchaseID = purchase.PurchaseID,
                                           SupplierName = purchase.Supplier.SupplierName,
                                           SupplierID = purchase.SupplierID,
                                           AssetNumber = assetNumber,
                                           InvoiceNumber = purchase.InvoiceNumber,
                                           CurrencyName = purchase.Currency.name,
                                           DateofPurchase1 = purchase.DateofPurchase.HasValue ? purchase.DateofPurchase.Value : (DateTime?)null,
                                           DateofPO = purchase.DateofPO.HasValue ? purchase.DateofPO.Value : (DateTime?)null,
                                           iso = purchase.iso,
                                           UnitPrice = purchase.UnitPrice,
                                           PONumber = purchase.PONumber,
                                           SupplierEmail = purchase.Supplier.SupplierEmail,
                                           InvoiceImage = string.IsNullOrEmpty(purchase.InvoiceImage) ? string.Empty : purchase.InvoiceImage.ToLower().Contains("not available") ? string.Empty : purchase.InvoiceImage,
                                           PurchaseOrderImage = string.IsNullOrEmpty(purchase.PurchaseOrderImage) ? string.Empty : purchase.PurchaseOrderImage.ToLower().Contains("not available") ? string.Empty : purchase.PurchaseOrderImage
                                       }).FirstOrDefault();

                purchaseDetails.DateofPurchase = purchaseDetails.DateofPurchase1.HasValue ? purchaseDetails.DateofPurchase1.Value.ToString("MM/dd/yyyy") : string.Empty;

                return purchaseDetails;
            }
        }

        public string UpdatePurchaseDetailsByID(PurchaseViewModel data)
        {
            using (var context = DataContextHelper.GetMatrixFASDataContext())
            {
                try
                {
                    var purchaseDetails = (from purchase in context.PurchaseDetails
                                           where purchase.PurchaseID == data.PurchaseID && purchase.L1LocCode == data.L1LocCode
                                           select purchase).FirstOrDefault();

                    purchaseDetails.SupplierID = data.SupplierID;
                    purchaseDetails.InvoiceNumber = data.InvoiceNumber;
                    purchaseDetails.PONumber = data.PONumber;
                    purchaseDetails.DateofPO = data.DateofPO;
                    purchaseDetails.DateofPurchase = Convert.ToDateTime(data.DateofPurchase);
                    purchaseDetails.iso = data.iso;
                    purchaseDetails.UnitPrice = data.UnitPrice;
                    purchaseDetails.InvoiceImage = data.InvoiceImage;
                    purchaseDetails.PurchaseOrderImage = data.PurchaseOrderImage;

                    context.SubmitChanges();
                    return "Success";
                }
                catch (Exception e)
                {
                    return "Fail - Error" + e.Message;
                }
            }
        }

        private string GetPurchaseDetailID(string L1LocCode)
        {
            Random random = new Random();
            string number = Convert.ToString(random.Next(1000, 9999));
            string PurchaseID = L1LocCode + number;
            using (var context = DataContextHelper.GetMatrixFASDataContext())
            {
                var Purchase = (from purchaseID in context.PurchaseDetails
                                where purchaseID.PurchaseID == PurchaseID
                                select purchaseID).ToList();

                if (Purchase.Count == 0)
                {
                    return PurchaseID;
                }
            }
            return GetPurchaseDetailID(L1LocCode);
        }

        private string GetAssetPurchaseID(string L1LocCode)
        {
            Random random = new Random();
            string number = Convert.ToString(random.Next(1000, 99999));
            string AssetPurchaseID = "AP" + L1LocCode + number;
            using (var context = DataContextHelper.GetMatrixFASDataContext())
            {
                var Purchase = (from ap in context.AssetPurchases
                                where ap.AssetPurchase1 == AssetPurchaseID
                                select ap.AssetPurchase1).ToList();

                if (Purchase.Count == 0)
                {
                    return AssetPurchaseID;
                }
            }
            return GetAssetPurchaseID(L1LocCode);
        }
    }
}

