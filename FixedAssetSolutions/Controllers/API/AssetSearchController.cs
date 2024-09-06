using FAS.Services;
using FAS.SharedModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using System.Web.Http.Cors;
using System.Web;


namespace FixedAssetSolutions.Controllers.API
{
    [EnableCors(origins: "http://localhost:8100", headers: "*", methods: "*")]
    public class AssetSearchController : ApiController
    {
        private IAssetService assetService;
        private IUserService userService;
        public HttpResponse Response;

        public AssetSearchController()
            : this(new AssetService(), new UserService())
        {

        }
        public AssetSearchController(IAssetService assetService, IUserService userService)
        {
            this.assetService = assetService;
            this.userService = userService;
        }

        [HttpPost]
        public ResponseObject GetL1Category(L1CategoryViewModel l1categoryViewModel)
        {
            ResponseObject responseObject = new ResponseObject();
            IEnumerable<L1CategoryViewModel> collection = assetService.GetL1Category(l1categoryViewModel);
            responseObject.Message = "All Groups";
            responseObject.Data = collection;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject SetDepreciationRate(AssetViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            string message = assetService.SetDepreciationRate(collection);
            responseObject.Message = message;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject ComputeDepreciation(AssetViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            responseObject.Data = assetService.ComputeDepreciation(collection);
            return responseObject;
        }

        [HttpPost]
        public ResponseObject SaveDepreciation(AssetViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            responseObject.Message = assetService.SaveDepreciation(collection);
            return responseObject;
        }

        [HttpPost]
        public ResponseObject ReturnDepreciationDates(AssetViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            responseObject.Data = assetService.ReturnDepreciationDates(collection);
            return responseObject;
        }

        [HttpPost]
        public ResponseObject ReturnDepreciation(AssetViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            responseObject.Data = assetService.ReturnDepreciation(collection);
            return responseObject;
        }


        [HttpPost]
        public ResponseObject GetL2Category(L2CategoryViewModel l2categoryViewModel)
        {
            ResponseObject responseObject = new ResponseObject();
            IEnumerable<L2CategoryViewModel> collection = assetService.GetL2Category(l2categoryViewModel);
            responseObject.Message = "All Categories";
            responseObject.Data = collection;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject GetL2CategoryOnly(L2CategoryViewModel l2categoryViewModel)
        {
            ResponseObject responseObject = new ResponseObject();
            IEnumerable<L2CategoryViewModel> collection = assetService.GetL2CategoryOnly(l2categoryViewModel);
            responseObject.Message = "All Categories";
            responseObject.Data = collection;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject GetL2Location(AssetViewModel collections)
        {
            ResponseObject responseObject = new ResponseObject();
            IEnumerable<L2LocationViewModel> collection = assetService.GetL2Location(collections);
            responseObject.Message = "All Sections";
            responseObject.Data = collection;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject GetL3Location(L3LocationViewModel l3categoryViewModel)
        {
            ResponseObject responseObject = new ResponseObject();
            IEnumerable<L3LocationViewModel> collection = assetService.GetL3Location(l3categoryViewModel);
            responseObject.Message = "All Rooms";
            responseObject.Data = collection;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject GetL4Location(L4LocationViewModel l4LocationViewModel)
        {
            ResponseObject responseObject = new ResponseObject();
            IEnumerable<L4LocationViewModel> collection = assetService.GetL4Location(l4LocationViewModel);
            responseObject.Message = "All Room Types";
            responseObject.Data = collection;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject GetL5Location(L5LocationViewModel l5LocationViewModel)
        {
            ResponseObject responseObject = new ResponseObject();
            IEnumerable<L5LocationViewModel> collection = assetService.GetL5Location(l5LocationViewModel);
            responseObject.Message = "All Floors";
            responseObject.Data = collection;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject GetAsset(AssetViewModel assetViewModel)
        {
            ResponseObject responseObject = new ResponseObject();
            try
            {
                IEnumerable<SearchViewModel> collection = FAS.Services.V2.AssetService.Instance.GetAsset(assetViewModel); //assetService.GetAsset(assetViewModel);
                responseObject.Data = collection;
            }
            catch (Exception e)
            {
                responseObject.Message = "Exception";
                responseObject.Data = e;
            }
            return responseObject;
        }

       


        [HttpPost]
        public ResponseObject GetAssetBC(AssetViewModel assetViewModel)
        {
            ResponseObject responseObject = new ResponseObject();
           IEnumerable<SearchViewModel> collection = assetService.GetAssetBC(assetViewModel);
            responseObject.Data = collection;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject GetAssetDscption(AssetViewModel assetViewModel)
        {
            ResponseObject responseObject = new ResponseObject();
            IEnumerable<AssetViewModel> collection = assetService.GetAssetDscption(assetViewModel);
            responseObject.Data = collection;
            return responseObject;
        }

        [HttpGet]
        public ResponseObject GetAllLocationAdmin()
        {
            ResponseObject responseObject = new ResponseObject();
            IEnumerable<LocationViewModel> collection = assetService.ReturnLocationAdmin();
            responseObject.Data = collection;
            return responseObject;
        }

        [HttpGet]
        public ResponseObject GetAllAssetsByLocationId()
        {
            ResponseObject responseObject = new ResponseObject();
            IEnumerable<LocationViewModel> collection = assetService.ReturnLocationAdmin();
            responseObject.Data = collection;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject GetPermissions(UserViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            IEnumerable<PermissionSharedModel> permission = userService.GetPermissions(collection); 
            responseObject.Data = permission;
            responseObject.Message = "All Privilages";
            return responseObject;
        }

        [HttpPost]
        public ResponseObject AssetMovement(AssetMovementViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            string AssetMovement = assetService.AssetMovement(collection);
            responseObject.Data = null;
            responseObject.Message = AssetMovement;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject GetCurrency()
        {
            ResponseObject responseObject = new ResponseObject();
            IEnumerable<CurrencyViewModel> collection = assetService.GetCurrency();
            responseObject.Data = collection;
            responseObject.Message = "All Currency";
            return responseObject;
        }

        [HttpPost]
        public ResponseObject GetSupplier(SupplierViewModel supplierViewModel)
        {
            ResponseObject responseObject = new ResponseObject();
            IEnumerable<SupplierViewModel> collection = assetService.GetSuppliers(supplierViewModel);
            responseObject.Data = collection;
            responseObject.Message = "All Suppliers";
            return responseObject;
        }

        [HttpPost]
        public ResponseObject PurchaseDetails(AssetViewModel Collection)
        {
            ResponseObject responseObject = new ResponseObject();
            //PurchaseViewModel collection = assetService.PurchaseDetails(Collection);
            responseObject.Data = FAS.Services.V2.PurchaseServices.Instance.PurchaseDetails(Collection);
            responseObject.Message = "Purchase Detail";
            return responseObject;
        }

        [HttpPost]
        public ResponseObject AssetNumberList (AssetViewModel Collection)
        {
            ResponseObject responseObject = new ResponseObject();
            IEnumerable<SearchViewModel> collection = assetService.AssetNumberList(Collection);
            responseObject.Data = collection;
            responseObject.Message = "Asset Number List";
            return responseObject;
        }

        [HttpPost]
        public ResponseObject DateOfDisposalList(AssetViewModel Collection)
        {
            ResponseObject responseObject = new ResponseObject();
            IEnumerable<SearchViewModel> collection = assetService.DateOfDisposalList(Collection);
            responseObject.Data = collection;
            responseObject.Message = "Date of Disposal List";
            return responseObject;
        }

        [HttpPost]
        public ResponseObject CreatedOnList(AssetViewModel Collection)
        {
            ResponseObject responseObject = new ResponseObject();
            IEnumerable<SearchViewModel> collection = assetService.CreatedOnList(Collection);
            responseObject.Data = collection;
            responseObject.Message = "Created On List";
            return responseObject;
        }

        [HttpPost]
        public ResponseObject AssetDispose(AssetMovementViewModel Collection)
        {
            ResponseObject responseObject = new ResponseObject();
            string collection = assetService.AssetDispose(Collection);
            responseObject.Data = collection;
            responseObject.Message = collection;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject AssetReverification(AssetViewModel Collection)
        {
            ResponseObject responseObject = new ResponseObject();
            var collection = assetService.Reverification(Collection);
            responseObject.Data = collection;
            responseObject.Message = null;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject ReplaceBarcode(ReverificationViewModel Collection)
        {
            ResponseObject responseObject = new ResponseObject();
            string message = assetService.ReplaceBarcode(Collection);
            responseObject.Data = null;
            responseObject.Message = message;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject ReverifiedAssets(ReverificationViewModel Collection)
        {
            ResponseObject responseObject = new ResponseObject();
            assetService.ReverifiedAssets(Collection);
            responseObject.Data = null;
            responseObject.Message = null;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject ManualReverifiedAssets(ReverificationViewModel Collection)
        {
            ResponseObject responseObject = new ResponseObject();
            assetService.ManualReverifiedAssets(Collection);
            responseObject.Data = null;
            responseObject.Message = null;
            return responseObject;
        }

        //[HttpPost]
        //public ResponseObject Reconciliation(AssetViewModel Collection)
        //{
        //    ResponseObject responseObject = new ResponseObject();
        //    var data = assetService.Reconciliation(Collection);
        //    responseObject.Data = data;
        //    responseObject.Message = null;
        //    return responseObject;
        //}

        [HttpPost]
        public ResponseObject ReverificationSchedule(AssetViewModel Collection)
        {
            ResponseObject responseObject = new ResponseObject();
            var message = assetService.ReverificationSchedule(Collection);
            responseObject.Data = null;
            responseObject.Message = message;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject isL3LocationAvailable(AssetViewModel Collection)
        {
            ResponseObject responseObject = new ResponseObject();
            var message = assetService.isL3LocationAvailable(Collection);
            responseObject.Data = null;
            responseObject.Message = message;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject CloseReverification(AssetViewModel Collection)
        {
            ResponseObject responseObject = new ResponseObject();
            var message = assetService.CloseReverification(Collection);
            responseObject.Data = null;
            responseObject.Message = message;
            return responseObject;
        }
    }
}
