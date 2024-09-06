using System.Collections.Generic;
using FAS.Adapter;
using FAS.SharedModel;
using FAS.Data;
using System.Web;

namespace FAS.Services
{
    public class AssetService : IAssetService
    {
        AssetAdapter assetAdapter;
        L1CategoryAdapter L1CategoryAdapter;
        L2CategoryAdapter L2CategoryAdapter;
        L3CategoryAdapter L3CategoryAdatpter;
        L2LocationAdapter l2LocAdapter;
        L3LocationAdapter l3LocAdapter;
        L4LocationAdapter l4LocAdapter;
        L5LocationAdapter l5LocAdapter;
        LocationAdapter l1LocAdapter;
        CurrencyAdapter currencyAdapter;
        SupplierAdapter supplierAdapter;
        AssetPurchaseAdapter assetPurchaseAdapter;
        PurchaseAdapter purchaseAdadpter;

        public AssetService()
        {
            assetAdapter = new AssetAdapter();
            L1CategoryAdapter = new L1CategoryAdapter();
            L2CategoryAdapter = new L2CategoryAdapter();
            L3CategoryAdatpter = new L3CategoryAdapter();
            l2LocAdapter = new L2LocationAdapter();
            l3LocAdapter = new L3LocationAdapter();
            l4LocAdapter = new L4LocationAdapter();
            l5LocAdapter = new L5LocationAdapter();
            l1LocAdapter = new LocationAdapter();
            currencyAdapter = new CurrencyAdapter();
            supplierAdapter = new SupplierAdapter();
            assetPurchaseAdapter = new AssetPurchaseAdapter();
            purchaseAdadpter = new PurchaseAdapter();
        }


        public IEnumerable<SearchViewModel> GetAsset(AssetViewModel assetViewModel)
        {
            return assetAdapter.GetAsset(assetViewModel);
        }

        public IEnumerable<SearchViewModel> GetAssetBC(AssetViewModel assetViewModel)
        {
            return assetAdapter.GetAssetByBC(assetViewModel);
        }

        public IEnumerable<AssetViewModel> GetAssetDscption(AssetViewModel assetViewModel)
        {
            return assetAdapter.GetAssetByDscrption(assetViewModel);
        }

        public IEnumerable<L1CategoryViewModel> GetL1Category(L1CategoryViewModel l1categoryViewModel)
        {
            return L1CategoryAdapter.GetL1Category(l1categoryViewModel);
        }

        public string SetDepreciationRate(AssetViewModel collection)
        {
            return L1CategoryAdapter.SetDepreciationRate(collection);
        }

        public IEnumerable<SearchViewModel> ComputeDepreciation(AssetViewModel collection)
        {
            return assetAdapter.ComputeDepreciation(collection);
        }

        public string SaveDepreciation(AssetViewModel collection)
        {
            return assetAdapter.SaveDepreciation(collection);
        }

        public IEnumerable<DepreciationViewModel> ReturnDepreciationDates(AssetViewModel collection)
        {
            return assetAdapter.ReturnDepreciationDates(collection);
        }

        public IEnumerable<DepreciationViewModel> ReturnDepreciation(AssetViewModel collection)
        {
            return assetAdapter.ReturnDepreciation(collection);
        }

        public IEnumerable<L2CategoryViewModel> GetL2Category(L2CategoryViewModel l2categoryViewModel)
        {
            return L2CategoryAdapter.GetL2Category(l2categoryViewModel);
        }

        public IEnumerable<L2CategoryViewModel> GetL2CategoryOnly(L2CategoryViewModel l2categoryViewModel)
        {
            return L2CategoryAdapter.GetL2CategoryOnly(l2categoryViewModel);
        }

        public IEnumerable<L3CategoryViewModel> GetL3Category(L3CategoryViewModel l3categoryViewModel)
        {
            return L3CategoryAdatpter.GetL3Category(l3categoryViewModel);
        }

        public IEnumerable<L2LocationViewModel> GetL2Location(AssetViewModel collection)
        {
            return l2LocAdapter.GetL2Location(collection);
        }

        public IEnumerable<L3LocationViewModel> GetL3Location(L3LocationViewModel l3LocationViewModel)
        {
            return l3LocAdapter.GetL3Location(l3LocationViewModel);
        }

        public IEnumerable<L4LocationViewModel> GetL4Location(L4LocationViewModel l4LocationViewModel)
        {
            return l4LocAdapter.GetL4Location(l4LocationViewModel);
        }

        public IEnumerable<L5LocationViewModel> GetL5Location(L5LocationViewModel l5LocationViewModel)
        {
            return l5LocAdapter.GetL5Location(l5LocationViewModel);
        }

        public DashboardSharedModel GetAssetDashboard(AssetViewModel assetViewModel)
        {
            return assetAdapter.GetAssetDashboard(assetViewModel);
        }

        public IEnumerable<LocationViewModel> ReturnLocationAdmin()
        {
            return l1LocAdapter.ReturnLocationAdmin();
        }

        public IEnumerable<LocationViewModel> ReturnAssetsByLocationId()
        {
            return l1LocAdapter.ReturnAssetsByLocationId();
        }

        public string AssetMovement(AssetMovementViewModel collection)
        {
            return assetAdapter.AssetMovement(collection);
        }

        public IEnumerable<CurrencyViewModel> GetCurrency()
        {
            return currencyAdapter.GetCurrency();
        }

        public IEnumerable<SupplierViewModel> GetSuppliers(SupplierViewModel supplierViewModel)
        {
            return supplierAdapter.GetAllSuplier(supplierViewModel);
        }

        public string AssetAddition(AssetAdditionViewModel assetAddition)
        {
            return assetAdapter.AssetAddition(assetAddition);
        }

        public string AssetTagging(AssetAdditionViewModel assetAddition)
        {
            return assetAdapter.AssetTagging(assetAddition);
        }

         public IEnumerable<clsAssetTagging> GetAllAssetTaggingByLocationId(clsAssetTagging paramAssetTag)

        {

            return assetAdapter.GetAllAssetTaggingByLocationId(paramAssetTag);

        }
        public PurchaseViewModel PurchaseDetails(AssetViewModel Collection)
        {
            return assetAdapter.PurchaseDetails(Collection);
        }

        public string AddPurchaseDetail(PurchaseDetail Collection)
        {
            return purchaseAdadpter.AddPurchaseDetail(Collection);
        }

        //public string AssetImageAddition(HttpPostedFileBase file)
        //{
        //    return AssetAddition.FileUpload(file);
        //}

        public IEnumerable<SearchViewModel> AssetNumberList(AssetViewModel assetViewModel)
        {
            return assetAdapter.AssetNumberList(assetViewModel);
        }

        public string AssetDispose(AssetMovementViewModel collection)
        {
            return assetAdapter.AssetDisposal(collection);
        }

        public IEnumerable<SearchViewModel> DateOfDisposalList(AssetViewModel collection)
        {
            return assetAdapter.DateOfDisposalList(collection);
        }

        public IEnumerable<SearchViewModel> CreatedOnList(AssetViewModel collection)
        {
            return assetAdapter.CreatedOnList(collection);
        }

        public string IsBarcodeExsist(AssetViewModel collection)
        {
            return assetAdapter.IsBarcodeExsist(collection);
        }

        public string IsBarcodeExsistRev(AssetViewModel collection)
        {
            return assetAdapter.IsBarcodeExsistRev(collection);
        }

        public string IsAssetPurchaseDeatilExist(AssetViewModel collection)
        {
            return assetPurchaseAdapter.IsAssetPurchaseDeatilExist(collection);
        }

        public ReverificationAPIViewModel Reverification(AssetViewModel assetViewModel)
        {
            return assetAdapter.Reverification(assetViewModel);
        }

        public string ReplaceBarcode(ReverificationViewModel collection)
        {
            return assetAdapter.ReplaceBarcode(collection);
        }

        public void ReverifiedAssets(ReverificationViewModel collection)
        {
            assetAdapter.ReverifiedAssets(collection);
        }

        public void ManualReverifiedAssets(ReverificationViewModel collection)
        {
            assetAdapter.ManualReverifiedAssets(collection);
        }
        //public DashboardSharedModel Reconciliation(AssetViewModel collection)
        //{
        //    return assetAdapter.Reconciliation(collection);
        //}
        public string ReverificationSchedule(AssetViewModel collection)
        {
            return assetAdapter.ReverificationSchedule(collection);
        }

        public string AssetAdditionReverification(AssetAdditionViewModel collection)
        {
            return assetAdapter.AssetAdditionReverification(collection);
        }

        public string isL3LocationAvailable(AssetViewModel collection)
        {
            return l3LocAdapter.isL3LocationAvailable(collection);
        }

        public string CloseReverification(AssetViewModel collection)
        {
            return assetAdapter.CloseReverification(collection);
        }

        public string CreateL2Location(AssetViewModel collection)
        {
            return l2LocAdapter.CreateL2Location(collection);
        }

        public string CreateL3Location(AssetViewModel collection)
        {
            return l3LocAdapter.CreateL3Location(collection);
        }
    }

    public interface IAssetService
    {
        string AssetAddition(AssetAdditionViewModel assetAddition);
         IEnumerable<clsAssetTagging> GetAllAssetTaggingByLocationId(clsAssetTagging paramAssetTag);

        string AssetTagging(AssetAdditionViewModel assetAddition);

        IEnumerable<SearchViewModel> GetAsset(AssetViewModel assetViewModel);

        IEnumerable<L1CategoryViewModel> GetL1Category(L1CategoryViewModel l1categoryViewModel);

        IEnumerable<L2CategoryViewModel> GetL2Category(L2CategoryViewModel l2categoryViewModel);

        IEnumerable<L2CategoryViewModel> GetL2CategoryOnly(L2CategoryViewModel l2categoryViewModel);

        IEnumerable<L3CategoryViewModel> GetL3Category(L3CategoryViewModel l3categoryViewModel);

        IEnumerable<L2LocationViewModel> GetL2Location(AssetViewModel collection);

        IEnumerable<L3LocationViewModel> GetL3Location(L3LocationViewModel l3LocationViewModel);

        IEnumerable<L4LocationViewModel> GetL4Location(L4LocationViewModel l4LocationViewModel);

        IEnumerable<L5LocationViewModel> GetL5Location(L5LocationViewModel l5LocationViewModel);

        IEnumerable<SearchViewModel> GetAssetBC(AssetViewModel assetViewModel);

        IEnumerable<AssetViewModel> GetAssetDscption(AssetViewModel assetViewModel);

        DashboardSharedModel GetAssetDashboard(AssetViewModel assetViewModel);

        IEnumerable<LocationViewModel> ReturnLocationAdmin();
        IEnumerable<LocationViewModel> ReturnAssetsByLocationId();

        string AssetMovement(AssetMovementViewModel collection);

        IEnumerable<SupplierViewModel> GetSuppliers(SupplierViewModel supplierViewModel);

        IEnumerable<CurrencyViewModel> GetCurrency();

        PurchaseViewModel PurchaseDetails(AssetViewModel Collection);

        IEnumerable<SearchViewModel> AssetNumberList(AssetViewModel assetViewModel);

        string AssetDispose(AssetMovementViewModel collection);

        IEnumerable<SearchViewModel> DateOfDisposalList(AssetViewModel collection);

        IEnumerable<SearchViewModel> CreatedOnList(AssetViewModel collection);

        string IsBarcodeExsist(AssetViewModel collection);

        string IsBarcodeExsistRev(AssetViewModel collection);

        string IsAssetPurchaseDeatilExist(AssetViewModel collection);

        ReverificationAPIViewModel Reverification(AssetViewModel assetViewModel);

        string ReplaceBarcode(ReverificationViewModel collection);

        void ReverifiedAssets(ReverificationViewModel collection);
        void ManualReverifiedAssets(ReverificationViewModel collection);

        string ReverificationSchedule(AssetViewModel collection);

        //DashboardSharedModel Reconciliation(AssetViewModel collection);

        string AssetAdditionReverification(AssetAdditionViewModel collection);

        string isL3LocationAvailable(AssetViewModel collection);

        string CloseReverification(AssetViewModel collection);

        string SetDepreciationRate(AssetViewModel collection);

        IEnumerable<SearchViewModel> ComputeDepreciation(AssetViewModel collection);

        string SaveDepreciation(AssetViewModel collection);

        IEnumerable<DepreciationViewModel> ReturnDepreciationDates(AssetViewModel collection);

        IEnumerable<DepreciationViewModel> ReturnDepreciation(AssetViewModel collection);

        string CreateL2Location(AssetViewModel collection);

        string CreateL3Location(AssetViewModel collection);
    }
}
