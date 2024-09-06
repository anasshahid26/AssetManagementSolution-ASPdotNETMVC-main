using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FAS.Services;
using FAS.SharedModel;
using FAS.Data;


namespace FixedAssetSolutions.Controllers.API
{
    public class LocationController : ApiController
    {
        private ILocationService locationService;
        private IAssetService assetService;

        public LocationController()
            : this(new LocationService(), new AssetService())
        {

        }


        public LocationController(ILocationService locationService, IAssetService assetService)
        {
            this.locationService = locationService;
            this.assetService = assetService;
        }

        [HttpPost]
        public ResponseObject CreateLocation(LocationViewModel collection)
        {
            ResponseObject addLocation = new ResponseObject();
            
            
            collection.ContactEmail = "null";
            collection.Country = "null";
            collection.CreatedOn = DateTime.Now;
            locationService.CreateLocation(collection);
            addLocation.Message = "Location Added Successfully";
            return addLocation;
            
          
        }

        [HttpPost]
        public ResponseObject AllLocation(LocationViewModel collection)
        {
            if(collection != null) { 
            ResponseObject AllLocation = new ResponseObject();
            IEnumerable<LocationViewModel> location = locationService.ReturnAllLocation(collection);
            var countryName =locationService.Country(collection.CountryID);
            collection.Country = Convert.ToString( countryName);
            AllLocation.Message = "Location Added Successfully";
            AllLocation.Data = location;
            return AllLocation;
            }
            ResponseObject NoLocation = new ResponseObject();
            return NoLocation;
        }

        [HttpPost]
        public ResponseObject DeleteLocation(LocationViewModel collection)
        {
            ResponseObject response = new ResponseObject();
            string id = collection.L1LocCode;
            locationService.DeleteLocation(id);
            response.Message = "Location Deleted";
            response.Data = id;
            return response;
        }

        [HttpPost]
        public ResponseObject IsLocationCodeExsist(LocationViewModel locationViewModel)
        {
            var LocationCode = locationService.LocationCodeExsist(locationViewModel);
            ResponseObject locationCodeExsist = new ResponseObject();
            locationCodeExsist.Message = LocationCode;
            locationCodeExsist.Data = null;
            return locationCodeExsist;
        }

        [HttpPost]
        public ResponseObject EditLocation(LocationViewModel locationViewModel)
        {
            ResponseObject responseObject = new ResponseObject();
            string L1LocCode = locationViewModel.L1LocCode;
            var data = locationService.EditLocation(L1LocCode);
            responseObject.Data = data;
            responseObject.Message = "Location Edit Info";
            return responseObject;
        }

        [HttpPost]
        public ResponseObject UpdateLocation(LocationViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            var res = locationService.UpdateLocation(collection);
            responseObject.Data = res;
            responseObject.Message = "Location Updated";
            return responseObject;
        }

        [HttpPost]
        public ResponseObject CreateL2Location(AssetViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            var res = assetService.CreateL2Location(collection);
            responseObject.Data = res;
            responseObject.Message = "L2Location";
            return responseObject;
        }

        [HttpPost]
        public ResponseObject CreateL3Location(AssetViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            var res = assetService.CreateL3Location(collection);
            responseObject.Data = res;
            responseObject.Message = "L3Location";
            return responseObject;
        }

        [HttpPost]
        public ResponseObject isL2LocationAvailable(AssetViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            var res = locationService.isL2LocationAvailable(collection);
            responseObject.Data = res;
            responseObject.Message = "L2Location";
            return responseObject;
        }
    }
}
