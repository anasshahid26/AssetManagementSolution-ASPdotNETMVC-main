using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FAS.Services;
using FAS.SharedModel;
using System.Web.Http.Cors;

namespace FixedAssetSolutions.Controllers.API
{
    [EnableCors(origins: "http://localhost:8100", headers: "*", methods: "*")]
    public class DashboardController : ApiController
    {
        private ILocationService locationServices;
        private IAssetService assetServices;
        public DashboardController()
            : this(new LocationService(), new AssetService())
        {

        }

        public DashboardController(ILocationService LocationServices, IAssetService AssetServices)
        {
            this.locationServices = LocationServices;
            this.assetServices = AssetServices;
        }

        [HttpPost]
        public ResponseObject UserAllLocation(UserViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            var locations = locationServices.ReturnAllLocationUser(collection);
            responseObject.Message = "Location Added Successfully";
            responseObject.Data = locations;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject DashboardAssets(AssetViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            var dashboard = assetServices.GetAssetDashboard(collection);
            responseObject.Message = "Dashboard Content";
            responseObject.Data = dashboard;
            return responseObject;
        }

    }
}
