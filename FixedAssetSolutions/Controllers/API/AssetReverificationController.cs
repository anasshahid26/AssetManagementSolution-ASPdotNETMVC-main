using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FAS.Services;
using System.Web.Http.Cors;
using FAS.SharedModel;
using System.Web;

namespace FixedAssetSolutions.Controllers.API
{
    [EnableCors(origins: "http://localhost:8100", headers: "*", methods: "*")]
    public class AssetReverificationController : ApiController
    {

        private IAssetReverificationService assetReverificationService;
        public HttpResponse Response;

        public AssetReverificationController()
            :this(new AssetReverificationService())
        {

        }

        public AssetReverificationController(IAssetReverificationService assetReverificationService)
        {
            this.assetReverificationService = assetReverificationService;
        }

        [HttpPost]
        public ResponseObject ongoingReverificationDate(ReverificationViewModel collection)
        {
            ResponseObject response = new ResponseObject();
            response.Data = assetReverificationService.getOngoingReverificationDate(collection);
            return response; 
        }
        
        [HttpPost]
        public ResponseObject ReverifiedAssetsByDateOfVerification(ReverificationViewModel collection)
        {
            ResponseObject response = new ResponseObject();
            response.Data = assetReverificationService.ReverifiedAssetsByDateOfVerification(collection);
            return response;
        }

        [HttpPost]
        public ResponseObject GetReverificationMobileData(ReverificationViewModel collection)
        {
            ResponseObject response = new ResponseObject();
            response.Data = assetReverificationService.GetReverificationMobileData(collection);
            return response;
        }
    }
}
