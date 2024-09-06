using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FAS.Services;
using FAS.SharedModel;
using System.Web;

namespace FixedAssetSolutions.Controllers.API
{
    

    public class AssetReconciliationController : ApiController
    {

        private IAssetReconciliationService assetReconciliationService;
        public HttpResponse Response;

        public AssetReconciliationController()
            : this(new AssetReconciliationService())
        {

        }

        public AssetReconciliationController(IAssetReconciliationService assetReconciliationService)
        {
            this.assetReconciliationService = assetReconciliationService;
        }

        [HttpPost]
        public ResponseObject Reconciliation(AssetViewModel collection)
        {
            ResponseObject response = new ResponseObject();
            response.Data = assetReconciliationService.Reconciliation(collection);
            return response;
        }

        [HttpPost]
        public ResponseObject ReconciliationByDescription(AssetViewModel collection)
        {
            ResponseObject response = new ResponseObject();
            response.Data = assetReconciliationService.ReconciliationByDescription(collection);
            return response;
        }

        [HttpPost]
        public ResponseObject ReconciliationByRoomNumber(AssetViewModel collection)
        {
            ResponseObject response = new ResponseObject();
            response.Data = assetReconciliationService.ReconciliationByRoomNumber(collection);
            return response;
        }


        [HttpPost]
        public ResponseObject ReconciliationByRoomNo(AssetViewModel collection)
        {
            ResponseObject response = new ResponseObject();
            response.Data = assetReconciliationService.ReconciliationByRoomNo(collection);
            return response;
        }
    }
}
