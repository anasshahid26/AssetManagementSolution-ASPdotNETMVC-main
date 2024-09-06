using FAS.Services;
using FAS.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace FixedAssetSolutions.Controllers.API
{
    public class AssetAdditionController : ApiController
    {
        private IAssetService assetService;
        private IL3CategoryService l3CategoryService;
        private ISupplierService supplierService;
        public HttpResponse Response;

        public AssetAdditionController()
            : this(new AssetService(), new L3CategoryService(), new SupplierService())
        {

        }

        public AssetAdditionController(IAssetService assetService, IL3CategoryService l3CategoryService, ISupplierService supplierService)
        {
            this.assetService = assetService;
            this.l3CategoryService = l3CategoryService;
            this.supplierService = supplierService;
        }

        [HttpPost]
        public ResponseObject GetL3Category(L3CategoryViewModel l3categoryViewModel)
        {
            ResponseObject responseObject = new ResponseObject();
            IEnumerable<L3CategoryViewModel> collection = assetService.GetL3Category(l3categoryViewModel);
            responseObject.Message = "All Description";
            responseObject.Data = collection;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject AssetAddition(AssetAdditionViewModel assetAddition)
        {
            ResponseObject responseObject = new ResponseObject();
            string Add = assetService.AssetAddition(assetAddition);
            responseObject.Message = Add;
            return responseObject;
        }

        public ResponseObject L3CategoryAddition(L3CategoryViewModel L3CatgeoryViewModel)
        {
            ResponseObject responseObject = new ResponseObject();
            var result = l3CategoryService.AddL3Category(L3CatgeoryViewModel);
            responseObject.Message = result;
            return responseObject;
        }

        public ResponseObject SupplierAddition(SupplierViewModel supplierViewModel)
        {
            ResponseObject responseObject = new ResponseObject();
            var result = FAS.Services.V2.SupplierServices.Instance.SupplierAddition(supplierViewModel);
            responseObject.Message = result;
            return responseObject;
        }

        public ResponseObject IsL3CategoryExist(L3CategoryViewModel L3CatgeoryViewModel)
        {
            ResponseObject responseObject = new ResponseObject();
            var result = l3CategoryService.IsL3CategoryExist(L3CatgeoryViewModel);
            responseObject.Message = result;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject UploadFiles()
        {
            ResponseObject responseObject = new ResponseObject();
            return responseObject;
        }

            public ResponseObject IsBarcodeExsist(AssetViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            var result = assetService.IsBarcodeExsist(collection);
            responseObject.Message = result;
            return responseObject;
        }

        public ResponseObject IsBarcodeExsistRev(AssetViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            var result = assetService.IsBarcodeExsistRev(collection);
            responseObject.Message = result;
            return responseObject;
        }

        public ResponseObject IsAssetPurchaseDeatilExist(AssetViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            var result = assetService.IsAssetPurchaseDeatilExist(collection);
            responseObject.Message = result;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject AssetAdditionReverification(AssetAdditionViewModel assetAddition)
        {
            ResponseObject responseObject = new ResponseObject();
            string Add = assetService.AssetAdditionReverification(assetAddition);
            responseObject.Message = Add;
            return responseObject;
        }
    }
}
