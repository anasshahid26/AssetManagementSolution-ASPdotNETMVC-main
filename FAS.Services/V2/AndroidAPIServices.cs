using FAS.Adapter;
using FAS.SharedModel.AndroidAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.Services.V2
{
    public class AndroidAPIServices : IAndroidAPIServices
    {
        #region API Adapter Object

        AndroidAPIAdapter apiAdapter;

        #endregion

        #region COMMENT - Defined as Singleton

        //private static AndroidAPIServices instance;

        //public static AndroidAPIServices Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            instance = new AndroidAPIServices();
        //        }
        //        return instance;
        //    }
        //}
        //private AndroidAPIServices() {
        //    apiAdapter = new AndroidAPIAdapter();
        //}

        public AndroidAPIServices()
        {
            apiAdapter = new AndroidAPIAdapter();
        }

        #endregion

        #region Assets Tagging Data
        public IEnumerable<clsAssetViewModel> GetAssetTaggingDataByLocationId(clsAssetViewModel collection)
        {
            return apiAdapter.GetAssetTaggingDataByLocationId(collection);
        }

        public int UpdateAssetTaggingData(clsAssetTaggingDataUpdate collection)
        {
            return apiAdapter.UpdateAssetTaggingData(collection);
        }

        #endregion

        #region SETUP 

        #region Assets
        public IEnumerable<clsAssetViewModel> GetAllAssetsByLocationId(clsAssetViewModel collection)
        {
            return apiAdapter.GetAllAssetsByLocationId(collection.location_code);
        }

        #endregion

        #region Locations
        public IEnumerable<clsAssetViewModel> GetAllLocations()
        {
            return apiAdapter.GetAllLocations();
        }

        #endregion

        #region Section
        public IEnumerable<clsAssetViewModel> GetSections(clsAssetViewModel collection)
        {
            return apiAdapter.GetSections(collection);
        }

        public IEnumerable<clsAssetViewModel> GetSectionsByLocationId(clsAssetViewModel collection)
        {
            return apiAdapter.GetSectionsByLocationId(collection);
        }

        #endregion

        #region Floor
        public IEnumerable<clsAssetViewModel> GetFloors(clsAssetViewModel collection)
        {
            return apiAdapter.GetFloors(collection);
        }

        public IEnumerable<clsAssetViewModel> GetFloorsByLocationId(clsAssetViewModel collection)
        {
            return apiAdapter.GetFloorsByLocationId(collection);
        }

        #endregion

        #region Rooms
        public IEnumerable<clsAssetViewModel> GetRooms(clsAssetViewModel collection)
        {
            return apiAdapter.GetRooms(collection);
        }

        public IEnumerable<clsAssetViewModel> GetRoomsByLocationId(clsAssetViewModel collection)
        {
            return apiAdapter.GetRoomsByLocationId(collection);
        }

        #endregion

        #region Room Types
        public IEnumerable<clsAssetViewModel> GetRoomTypes(clsAssetViewModel collection)
        {
            return apiAdapter.GetRoomTypes(collection);
        }

        public IEnumerable<clsAssetViewModel> GetRoomTypesByLocationId(clsAssetViewModel collection)
        {
            return apiAdapter.GetRoomTypesByLocationId(collection);
        }

        #endregion

        #endregion

        #region Assets Reverification Data

        #region GET REVERIFICATION DATA
        public IEnumerable<clsAssetViewModel> GetReverificationDataByLocationId(clsAssetViewModel collection)
        {
            return apiAdapter.GetReverificationDataByLocationId(collection);
        }
        #endregion
        
        #endregion

    }
    public interface IAndroidAPIServices
    {
        IEnumerable<clsAssetViewModel> GetAllAssetsByLocationId(clsAssetViewModel collection);
        IEnumerable<clsAssetViewModel> GetAllLocations();
        IEnumerable<clsAssetViewModel> GetSections(clsAssetViewModel collection);
        IEnumerable<clsAssetViewModel> GetSectionsByLocationId(clsAssetViewModel collection);
        IEnumerable<clsAssetViewModel> GetFloors(clsAssetViewModel collection);
        IEnumerable<clsAssetViewModel> GetFloorsByLocationId(clsAssetViewModel collection);
        IEnumerable<clsAssetViewModel> GetRooms(clsAssetViewModel collection);
        IEnumerable<clsAssetViewModel> GetRoomsByLocationId(clsAssetViewModel collection);
        IEnumerable<clsAssetViewModel> GetRoomTypes(clsAssetViewModel collection);
        IEnumerable<clsAssetViewModel> GetRoomTypesByLocationId(clsAssetViewModel collection);
        int UpdateAssetTaggingData(clsAssetTaggingDataUpdate collection);
        IEnumerable<clsAssetViewModel> GetAssetTaggingDataByLocationId(clsAssetViewModel collection);
        IEnumerable<clsAssetViewModel> GetReverificationDataByLocationId(clsAssetViewModel collection);

    }
}
