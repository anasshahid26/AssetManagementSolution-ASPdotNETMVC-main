using FAS.Adapter;
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
    public class AssetTaggingController : ApiController
    {
        // GET: AssetTagging
       private IAssetService assetService;
      // private AssetService assetService_;
       // private IL3CategoryService l3CategoryService;
      //  private ISupplierService supplierService;
      //  public HttpResponse Response;

        public AssetTaggingController()
            : this(new AssetService())
        {

        }

        public AssetTaggingController(IAssetService assetService)
        {
            this.assetService = assetService;
           
        }     
        public ResponseObject AssetTagging(AssetAdditionViewModel assetAddition)
        {
            ResponseObject responseObject = new ResponseObject();
            string Add = assetService.AssetTagging(assetAddition);
            responseObject.Message = Add;
            return responseObject;
        }
        //[HttpPost]
        //public ResponseObject GetAssetTagging(AssetViewModel assetViewModel)
        //{
        //    ResponseObject responseObject = new ResponseObject();
        //    try
        //    {
        //       // IEnumerable<SearchViewModel> collection = assetService.getall(assetViewModel);
        //        IEnumerable<SearchViewModel> collection = FAS.Services.V2.AssetService.Instance.GetAssetTagging(assetViewModel); //assetService.GetAsset(assetViewModel);
        //        responseObject.Data = collection;
        //    }
        //    catch (Exception e)
        //    {
        //        responseObject.Message = "Exception";
        //        responseObject.Data = e;
        //    }
        //    return responseObject;
        //} 

        [HttpPost]
        public ResponseObject GetAssetTagging(clsAssetTagging assetViewModel)
        {
            ResponseObject responseObject = new ResponseObject();
            try
            {
                //IEnumerable<SearchViewModel> collection = FAS.Services.V2.AssetService.Instance.GetAssetTagging(assetViewModel); //assetService.GetAsset(assetViewModel);
                //IEnumerable<SearchViewModel> collection = FAS.Services.V2.AssetService.Instance.GetAsset(assetViewModel); //assetService.GetAsset(assetViewModel);
                IEnumerable<clsAssetTagging> collection = assetService.GetAllAssetTaggingByLocationId(assetViewModel);

                responseObject.Data = collection;
            }
            catch (Exception e)
            {
                responseObject.Message = "Exception";
                responseObject.Data = e;
            }
            return responseObject;
        }

    }
}