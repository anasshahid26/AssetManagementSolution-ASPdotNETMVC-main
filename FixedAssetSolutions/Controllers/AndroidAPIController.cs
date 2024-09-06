using FAS.Services.V2;
using FAS.SharedModel;
using FAS.SharedModel.AndroidAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FixedAssetSolutions.Controllers
{
    public class AndroidAPIController : ApiController
    {
        private IAndroidAPIServices objService;
        public AndroidAPIController()
            : this(new AndroidAPIServices())
        {

        }
        public AndroidAPIController(IAndroidAPIServices objService)
        {
            this.objService = objService;
        }

        #region GET - WEB API

        /// <summary>Get All Assets of Particular Location
        /// </summary>
        [HttpPost]
        public ResponseObject GetAllAssetsByLocationId(clsAssetViewModel collections)
        {
            ResponseObject objResponse = new ResponseObject();
            objResponse.Message = "All Assets WRT Location ID";
            objResponse.statusMessage = "success";
            objResponse.status = true;

            try
            {
                IEnumerable<clsAssetViewModel> collection = objService.GetAllAssetsByLocationId(collections);

                objResponse.Data = collection;
            }
            catch (Exception ex)
            {
                objResponse.Data = null;
                objResponse.Message = "An error occured in fetching All Assets data by location id. <br />" + ex.Message;
                objResponse.statusMessage = "failed";
                objResponse.status = false;
            }

            return objResponse;
        }

        [HttpGet]
        public ResponseObject GetAllLocations(clsAssetViewModel collections)
        {
            ResponseObject objResponse = new ResponseObject();
            objResponse.Message = "All Locations";
            objResponse.statusMessage = "success";
            objResponse.status = true;

            try
            {
                //IEnumerable<clsAssetViewModel> collection = objService.GetSections(collections);
                IEnumerable<clsAssetViewModel> collection = objService.GetAllLocations();
                objResponse.Data = collection;
            }
            catch (Exception ex)
            {
                objResponse.Data = null;
                objResponse.Message = "An error occured in fetching locations data. <br />" + ex.Message;
                objResponse.statusMessage = "failed";
                objResponse.status = false;
            }


            return objResponse;
        }
        //[HttpGet]
        //public ResponseObject GetAllLocations()
        //{
        //    ResponseObject objResponse = new ResponseObject();
        //    objResponse.Message = "All Locations";
        //    objResponse.statusMessage = "success";
        //    objResponse.status = true;

        //    try
        //    {
        //        //IEnumerable<clsAssetViewModel> collection = objService.GetSections(collections);
        //        IEnumerable<clsAssetViewModel> collection = objService.GetAllLocations();
        //        objResponse.Data = collection;
        //    }
        //    catch (Exception ex)
        //    {
        //        objResponse.Data = null;
        //        objResponse.Message = "An error occured in fetching all locations data. <br />" + ex.Message;
        //        objResponse.statusMessage = "failed";
        //        objResponse.status = false;
        //    }


        //    return objResponse;
        //}
        [HttpPost]
        public ResponseObject GetSections(clsAssetViewModel collections)
        {
            ResponseObject objResponse = new ResponseObject();
            objResponse.Message = "All Sections";
            objResponse.statusMessage = "success";
            objResponse.status = true;

            try
            {
                //IEnumerable<clsAssetViewModel> collection = objService.GetSections(collections);
                IEnumerable<clsAssetViewModel> collection = objService.GetSectionsByLocationId(collections);
                objResponse.Data = collection;
            }
            catch (Exception ex)
            {
                objResponse.Data = null;
                objResponse.Message = "An error occured in fetching service data. <br />" + ex.Message;
                objResponse.statusMessage = "failed";
                objResponse.status = false;
            }


            return objResponse;
        }

        [HttpPost]
        public ResponseObject GetFloors(clsAssetViewModel collections)
        {
            ResponseObject objResponse = new ResponseObject();
            objResponse.Message = "All Floors";
            objResponse.statusMessage = "success";
            objResponse.status = true;

            try
            {
                //IEnumerable<clsAssetViewModel> collection = objService.GetFloors(collections);
                IEnumerable<clsAssetViewModel> collection = objService.GetFloorsByLocationId(collections);
                objResponse.Data = collection;
            }
            catch (Exception ex)
            {
                objResponse.Data = null;
                objResponse.Message = "An error occured in fetching floors data. <br />" + ex.Message;
                objResponse.statusMessage = "failed";
                objResponse.status = false;
            }
            return objResponse;
        }

        [HttpPost]
        public ResponseObject GetRooms(clsAssetViewModel collections)
        {
            ResponseObject objResponse = new ResponseObject();
            objResponse.Message = "All Rooms";
            objResponse.statusMessage = "success";
            objResponse.status = true;

            try
            {
                //IEnumerable<clsAssetViewModel> collection = objService.GetRooms(collections);
                IEnumerable<clsAssetViewModel> collection = objService.GetRoomsByLocationId(collections);
                objResponse.Data = collection;
            }
            catch (Exception ex)
            {
                objResponse.Data = null;
                objResponse.Message = "An error occured in fetching rooms data. <br />" + ex.Message;
                objResponse.statusMessage = "failed";
                objResponse.status = false;
            }

            return objResponse;
        }

        [HttpPost]
        public ResponseObject GetRoomTypes(clsAssetViewModel collections)
        {
            ResponseObject objResponse = new ResponseObject();
            objResponse.Message = "All Room Types";
            objResponse.statusMessage = "success";
            objResponse.status = true;

            try
            {
                //IEnumerable<clsAssetViewModel> collection = objService.GetRoomTypes(collections);
                IEnumerable<clsAssetViewModel> collection = objService.GetRoomTypesByLocationId(collections);
                objResponse.Data = collection;
            }
            catch (Exception ex)
            {
                objResponse.Data = null;
                objResponse.Message = "An error occured in fetching room types data. <br />" + ex.Message;
                objResponse.statusMessage = "failed";
                objResponse.status = false;
            }

            return objResponse;
        }

        [HttpPost]
        public ResponseObject GetAssetTaggingDataByLocationId(clsAssetViewModel collections)
        {
            ResponseObject objResponse = new ResponseObject();
            objResponse.Message = "All Assets tagging data WRT Location ID";
            objResponse.statusMessage = "success";
            objResponse.status = true;

            try
            {
                IEnumerable<clsAssetViewModel> collection = objService.GetAssetTaggingDataByLocationId(collections);

                objResponse.Data = collection;
            }
            catch (Exception ex)
            {
                objResponse.Data = null;
                objResponse.Message = "An error occured in fetching All Assets tagging data by location id. <br />" + ex.Message;
                objResponse.statusMessage = "failed";
                objResponse.status = false;
            }

            return objResponse;
        }

        [HttpPost]
        public ResponseObject GetReverificationDataByLocationId(clsAssetViewModel collections)
        {
            ResponseObject objResponse = new ResponseObject();
            objResponse.Message = "All Assets Reverification data WRT Location ID";
            objResponse.statusMessage = "success";
            objResponse.status = true;

            try
            {
                IEnumerable<clsAssetViewModel> collection = objService.GetReverificationDataByLocationId(collections);

                objResponse.Data = collection;
            }
            catch (Exception ex)
            {
                objResponse.Data = null;
                objResponse.Message = "An error occured in fetching All Assets Reverification data by location id. <br />" + ex.Message;
                objResponse.statusMessage = "failed";
                objResponse.status = false;
            }

            return objResponse;
        }

        #endregion

        #region PUT - WEB API

        [HttpPost]
        public ResponseObject UpdateAssetTaggingData(clsAssetTaggingDataUpdate collections)
        {
            ResponseObject objResponse = new ResponseObject();
            objResponse.Message = "Update Asset Tagging Data.";
            objResponse.statusMessage = "success";
            objResponse.status = true;

            try
            {
                int result = objService.UpdateAssetTaggingData(collections);
                objResponse.last_id = result.ToString();
                objResponse.Data = "";
            }
            catch (Exception ex)
            {
                objResponse.Data = null;
                objResponse.Message = "An error occured in updating asset tagging data. <br />" + ex.Message;
                objResponse.statusMessage = "failed";
                objResponse.status = false;
            }

            return objResponse;
        }

        #endregion
    }
}
