using FAS.Infrastructure.Common;
using FAS.Infrastructure.Repository;
using FAS.SharedModel.AndroidAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.Adapter
{

    public class AndroidAPIAdapter
    {
        #region Variables

        private IUnityOfWork unityOfWork;
        //***************************************************
        // Asset Detail By Location id
        private clsAsset objAsset = new clsAsset();
        private clsAssetTagging objAssetTagging = new clsAssetTagging();
        //***************************************************
        // Sections / Get L2 Locations
        private IL2LocationRepository SectionsRepository;
        //***************************************************
        // Rooms / Get L3 Locations
        private IL3LocationRepository RoomsRepository;
        //***************************************************
        // Room Types / Get L4 Locations
        private IL4LocationRepository RoomTypesRepository;
        //***************************************************
        // Floors / Get L5 Locations
        private IL5LocationRepository FloorsRepository;
        //***************************************************
        private IAssetReverificationRepository AssetReverificationRepository;
        //***************************************************   

        #endregion

        #region Constructor

        public AndroidAPIAdapter()
        {
            unityOfWork = new UnityOfWork(new DatabaseFactory());
            SectionsRepository = new L2LocationRepository(unityOfWork.instance);
            RoomsRepository = new L3LocationRepository(unityOfWork.instance);
            RoomTypesRepository = new L4LocationRepository(unityOfWork.instance);
            FloorsRepository = new L5LocationRepository(unityOfWork.instance);
        }

        #endregion

        #region API GET Methods

        #region Assets

        //Get All Assets by Location Id
        public IEnumerable<clsAssetViewModel> GetAllAssetsByLocationId(string LocationId)
        {
            #region
            //List<clsAssetViewModel> room = new List<clsAssetViewModel>();
            //room.Add(new clsAssetViewModel
            //{
            //    _AssetNumber = "1",
            //    _AssetDescription = "abcd desc",
            //    _L1LocCode = "DEMO1",
            //    _L2LocCode = "DEMO1BH",
            //    _L3LocCode = "DEMO1BHGAR",
            //    _L4LocCode = "DEMO1BHGAR",
            //    _L5LocCode = "DEMO1BHGARG",
            //    _L1CatCode = "DEMO1AP",
            //    _L2CatCode = "DEMO1APLUG",
            //    _L3CatCode = "DEMO1APLUG3",
            //    _L4CatCode = "DEMO1APLUG3BH",
            //    _FLOOR = "G",
            //    _ROOMNO = "GAR"

            //});

            //return room;
            #endregion

            List<clsAssetViewModel> assetList = new List<clsAssetViewModel>();

            objAsset.L1LocCode = LocationId;
            DataTable dt = objAsset.GetAssetsByLocationId();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    assetList.Add(new clsAssetViewModel
                    {
                        asset_number = dr["AssetNumber"].ToString(),
                        asset_description = dr["AssetDescription"].ToString(),
                        location_code = dr["L1LocCode"].ToString(),
                        section_code = dr["L2LocCode"].ToString(),
                        room_code = dr["L3LocCode"].ToString(),
                        room_type_code = dr["L4LocCode"].ToString(),
                        floor_code = dr["L5LocCode"].ToString(),
                        group_code = dr["L1CatCode"].ToString(),
                        category_code = dr["L2CatCode"].ToString(),
                        _L3CatCode = dr["L3CatCode"].ToString(),
                        _L4CatCode = dr["L4CatCode"].ToString(),
                        floor_name = dr["FLOOR"].ToString(),
                        room_name = dr["ROOMNO"].ToString()
                    });
                }
            }
            return assetList;
        }

        #endregion

        #region Locations
        public IEnumerable<clsAssetViewModel> GetAllLocations()
        {
            List<clsAssetViewModel> locationList = new List<clsAssetViewModel>();

            DataTable dt = objAsset.GetAllLocations();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    locationList.Add(new clsAssetViewModel
                    {
                        location_code = dr["L1LocCode"].ToString(),
                        location_name = dr["L1LocName"].ToString()
                    });
                }
            }
            return locationList;
        }

        #endregion

        #region Sections
        public IEnumerable<clsAssetViewModel> GetSections(clsAssetViewModel collection)
        {
            //var getL2Location = l2LocationRepository.GetAll().ToList();
            List<clsAssetViewModel> result = new List<clsAssetViewModel>();
            if (collection.group_code != null)
            {
                var locations = (from location
                           in unityOfWork.db.Assets
                                 join locationInfo
                                 in unityOfWork.db.L2Location
                                 on location.L2LocCode
                                 equals locationInfo.L2LocCode
                                 where location.L2CatCode == collection.group_code && location.L1CatCode == collection.category_code
                                 select locationInfo).Distinct().ToList();
                if (locations.Count > 0)
                {
                    foreach (var item in locations)
                    {
                        result.Add(new clsAssetViewModel
                        {
                            location_code = item.L1LocCode,
                            section_code = item.L2LocCode,
                            section_name = item.L2LocName
                        });
                    }
                    return result;
                }
                else
                {
                    return result;
                }
            }
            else
            {
                var getL2Location = SectionsRepository.GetAll().Where(x => x.L1LocCode == collection.location_code).OrderBy(x => x.L2LocName).ToList();
                foreach (var item in getL2Location)
                {
                    result.Add(new clsAssetViewModel
                    {
                        location_code = item.L1LocCode,
                        section_code = item.L2LocCode,
                        section_name = item.L2LocName
                    });
                }
                return result;
            }
        }

        public IEnumerable<clsAssetViewModel> GetSectionsByLocationId(clsAssetViewModel collection)
        {
            List<clsAssetViewModel> sectionList = new List<clsAssetViewModel>();

            objAsset.L1LocCode = collection.location_code;
            DataTable dt = objAsset.GetSectionsByLocationId();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    sectionList.Add(new clsAssetViewModel
                    {
                        location_code = dr["L1LocCode"].ToString(),
                        section_code = dr["L2LocCode"].ToString(),
                        section_name = dr["L2LocName"].ToString()
                    });
                }
            }
            return sectionList;
        }

        #endregion

        #region Floors

        public IEnumerable<clsAssetViewModel> GetFloors(clsAssetViewModel collection)
        {
            List<clsAssetViewModel> result = new List<clsAssetViewModel>();
            if (collection.room_type_code != null)
            {
                if (collection.group_code != null)
                {
                    var locations = (from location in unityOfWork.db.Assets
                                     join locationInfo in unityOfWork.db.L5Location on location.L5LocCode
                                     equals locationInfo.L5LocCode
                                     where location.L4LocCode == collection.room_type_code
                                    && location.L3LocCode == collection.room_code
                                    && location.L2LocCode == collection.section_code
                                    && location.L2CatCode == collection.group_code
                                    && location.L1CatCode == collection.category_code
                                     select locationInfo).Distinct().ToList();
                    if (locations.Count > 0)
                    {
                        foreach (var item in locations)
                        {
                            result.Add(new clsAssetViewModel
                            {
                                location_code = collection.location_code,
                                section_code = collection.section_code,
                                floor_code = item.L5LocCode,
                                floor_name = item.CODELEVEL
                            });
                        }
                        return result;
                    }
                    else
                    {
                        return result;
                    }
                }
                else
                {

                    var locations = (from l5 in unityOfWork.db.L5Location
                                     join l4 in unityOfWork.db.L4Location on l5.L4LocCode equals l4.L4LocCode
                                     where l5.L4LocCode == collection.room_type_code
                                     select l5).ToList();
                    if (locations.Count > 0)
                    {
                        foreach (var item in locations)
                        {
                            result.Add(new clsAssetViewModel
                            {
                                location_code = collection.location_code,
                                section_code = collection.section_code,
                                floor_code = item.L5LocCode,
                                floor_name = item.L5LocName
                            });
                        }
                        return result;
                    }
                    else
                    {
                        return result;
                    }

                }
            }
            else
            {
                if (collection.section_code != null)
                {
                    var L5Locations = (from l5location in unityOfWork.db.L5Location
                                       join l4Location in unityOfWork.db.L4Location on l5location.L4LocCode equals l4Location.L4LocCode
                                       join l3Location in unityOfWork.db.L3Location on l4Location.L3LocCode equals l3Location.L3LocCode
                                       join l2Location in unityOfWork.db.L2Location on l3Location.L2LocCode equals l2Location.L2LocCode
                                       where l2Location.L2LocCode == collection.section_code && l5location.L1LocCode == collection.location_code
                                       select new clsAssetViewModel
                                       {
                                           location_code = collection.location_code,
                                           section_code = collection.section_code,
                                           floor_name = l5location.CODELEVEL
                                       }).Distinct();
                    return L5Locations;

                }
                else
                {
                    var getL5Location = FloorsRepository.GetAll().Where(x => x.L1LocCode == collection.location_code).GroupBy(x => x.CODELEVEL).Select(x => x.First()).OrderBy(x => x.CODELEVEL).ToList();
                    foreach (var item in getL5Location)
                    {
                        result.Add(new clsAssetViewModel
                        {
                            location_code = collection.location_code,
                            section_code = collection.section_code,
                            floor_code = item.L5LocCode,
                            floor_name = item.CODELEVEL
                        });
                    }
                    return result;
                }
            }
        }

        public IEnumerable<clsAssetViewModel> GetFloorsByLocationId(clsAssetViewModel collection)
        {
            List<clsAssetViewModel> floorList = new List<clsAssetViewModel>();

            objAsset.L1LocCode = collection.location_code;
            DataTable dt = objAsset.GetFloorsByLocationId();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    //L1LocCode, L2LocCode, L3LocCode, L4LocCode, L5LocCode, L5LocName 
                    floorList.Add(new clsAssetViewModel
                    {
                        location_code = dr["L1LocCode"].ToString(),
                        section_code = dr["L2LocCode"].ToString(),
                        room_code = dr["L3LocCode"].ToString(),
                        room_type_code = dr["L4LocCode"].ToString(),
                        floor_code = dr["L5LocCode"].ToString(),
                        floor_name = dr["L5LocName"].ToString()
                    });
                }
            }
            return floorList;
        }

        #endregion

        #region Rooms

        public IEnumerable<clsAssetViewModel> GetRooms(clsAssetViewModel collection)
        {
            //var getL2Location = l2LocationRepository.GetAll().ToList();
            List<clsAssetViewModel> result = new List<clsAssetViewModel>();
            if (collection.section_code != null && collection.floor_code == null)
            {
                if (collection.group_code != null)
                {
                    var locations = (from location
                               in unityOfWork.db.Assets
                                     join locationInfo
                                     in unityOfWork.db.L3Location
                                     on location.L3LocCode equals locationInfo.L3LocCode
                                     join l2 in unityOfWork.db.L2Location on locationInfo.L2LocCode equals l2.L2LocCode
                                     where location.L2LocCode == collection.section_code
                                     && location.L2CatCode == collection.group_code
                                     && location.L1CatCode == collection.category_code
                                     && location.L1LocCode == collection.location_code
                                     select locationInfo).Distinct().ToList();
                    if (locations.Count > 0)
                    {
                        foreach (var item in locations)
                        {
                            result.Add(new clsAssetViewModel
                            {
                                location_code = collection.location_code,
                                section_code = collection.section_code,
                                category_code = collection.category_code,
                                group_code = collection.group_code,
                                room_code = item.L3LocCode,
                                room_name = item.L3LocName
                            });
                        }
                        return result;
                    }
                    else
                    {
                        return result;
                    }
                }
                else
                {
                    //select * from dbo.L3Location l3 inner join L2Location l2 on l3.L2LocCode = l2.L2LocCode where l3.L2LocCode = 'RM' And l2.L1LocCode = 'PCCHE';
                    var locations = (from l3 in unityOfWork.db.L3Location
                                     join l2 in unityOfWork.db.L2Location on l3.L2LocCode equals l2.L2LocCode
                                     where l3.L2LocCode == collection.section_code
                                     && l2.L1LocCode == collection.location_code
                                     select l3).ToList();
                    if (locations.Count > 0)
                    {
                        foreach (var item in locations)
                        {
                            result.Add(new clsAssetViewModel
                            {
                                location_code = collection.location_code,
                                section_code = collection.section_code,
                                category_code = collection.category_code,
                                group_code = collection.group_code,
                                room_code = item.L3LocCode,
                                room_name = item.L3LocName
                            });
                        }
                        return result;
                    }
                    else
                    {
                        return result;
                    }

                }
            }
            else
            {
                if (collection.floor_code != null)
                {
                    var L3Locations = (from l3Location in unityOfWork.db.L3Location
                                       join l4Location in unityOfWork.db.L4Location on l3Location.L3LocCode equals l4Location.L3LocCode
                                       join l5Location in unityOfWork.db.L5Location on l4Location.L4LocCode equals l5Location.L4LocCode
                                       where l5Location.L1LocCode == collection.location_code
                                       && l5Location.CODELEVEL == collection.floor_code
                                       && l3Location.L2LocCode == collection.section_code
                                       select new clsAssetViewModel
                                       {
                                           location_code = collection.location_code,
                                           section_code = collection.section_code,
                                           category_code = collection.category_code,
                                           group_code = collection.group_code,
                                           room_code = l3Location.L3LocCode,
                                           room_name = l3Location.L3LocName,
                                           room_type_code = l4Location.ROOMTYPECODE
                                       }).Distinct();
                    return L3Locations;
                }
                else
                {
                    var getL3Location =
                        RoomsRepository
                        .GetAll()
                        .Where(x => x.L2Location.L1LocCode == collection.location_code)
                        .GroupBy(x => x.L3LocName)
                        .Select(x => x.First()).OrderBy(x => x.L3LocName).ToList();

                    foreach (var item in getL3Location)
                    {
                        result.Add(new clsAssetViewModel
                        {
                            location_code = collection.location_code,
                            section_code = collection.section_code,
                            category_code = collection.category_code,
                            group_code = collection.group_code,
                            room_code = item.L3LocCode,
                            room_name = item.L3LocName,
                        });
                    }
                    return result;
                }
            }
        }

        public IEnumerable<clsAssetViewModel> GetRoomsByLocationId(clsAssetViewModel collection)
        {
            List<clsAssetViewModel> roomList = new List<clsAssetViewModel>();

            objAsset.L1LocCode = collection.location_code;
            DataTable dt = objAsset.GetRoomsByLocationId();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    //L1LocCode, L2LocCode, L3LocCode, L3LocName
                    roomList.Add(new clsAssetViewModel
                    {
                        location_code = dr["L1LocCode"].ToString(),
                        section_code = dr["L2LocCode"].ToString(),
                        room_code = dr["L3LocCode"].ToString(),
                        room_name = dr["L3LocName"].ToString()
                    });
                }
            }
            return roomList;
        }

        #endregion

        #region Room Types

        public IEnumerable<clsAssetViewModel> GetRoomTypes(clsAssetViewModel collection)
        {
            List<clsAssetViewModel> result = new List<clsAssetViewModel>();

            if (collection.room_code != null)
            {
                if (collection.group_code != null)
                {
                    var locations = (from location
                           in unityOfWork.db.Assets
                                     join locationInfo
                                     in unityOfWork.db.L4Location
                                     on location.L4LocCode
                                     equals locationInfo.L4LocCode
                                     where location.L2LocCode == collection.section_code
                                     && location.L3LocCode == collection.room_code
                                     && location.L2CatCode == collection.group_code
                                     && location.L1CatCode == collection.category_code
                                     select locationInfo).Distinct().ToList();

                    if (locations.Count > 0)
                    {
                        foreach (var item in locations)
                        {
                            result.Add(new clsAssetViewModel
                            {
                                category_code = collection.category_code,
                                group_code = collection.group_code,
                                location_code = collection.location_code,
                                section_code = collection.section_code,
                                room_code = collection.room_code,
                                room_type_code = item.L4LocCode,
                                room_type_name = item.L4LocName
                            });
                        }
                        //return result;
                    }
                    //else
                    //{
                    //    return result;
                    //}
                }
                else
                {
                    //select * from dbo.L3Location l3 inner join L2Location l2 on l3.L2LocCode = l2.L2LocCode where l3.L2LocCode = 'RM' And l2.L1LocCode = 'PCCHE';
                    var locations = (from l4 in unityOfWork.db.L4Location
                                     join l3 in unityOfWork.db.L3Location on l4.L3LocCode equals l3.L3LocCode
                                     where l4.L3LocCode == collection.room_code
                                     select l4).ToList();
                    if (locations.Count > 0)
                    {
                        foreach (var item in locations)
                        {
                            if (item.L4LocName == null)
                            {
                                result.Add(new clsAssetViewModel
                                {
                                    category_code = collection.category_code,
                                    group_code = collection.group_code,
                                    location_code = collection.location_code,
                                    section_code = collection.section_code,
                                    room_code = collection.room_code,
                                    room_type_code = item.L4LocCode,
                                    room_type_name = "NONE"
                                });
                            }
                            else
                            {
                                result.Add(new clsAssetViewModel
                                {
                                    category_code = collection.category_code,
                                    group_code = collection.group_code,
                                    location_code = collection.location_code,
                                    section_code = collection.section_code,
                                    room_code = collection.room_code,
                                    room_type_code = item.L4LocCode,
                                    room_type_name = item.L4LocName
                                });
                            }

                        }
                        //return result;
                    }
                    //else
                    //{
                    //    return result;
                    //}

                }
            }
            else
            {
                //var getL4Location = l4LocationRepository.GetAll().OrderBy(x=>x.L4LocName).ToList();
                //var getL4Location = (from L4Location in unityOfWork.db.L4Location where L4Location.L1LocCode == collection.L1LocCode select L4Location).GroupBy(x=>x.L4LocName).OrderBy(x => x.L4LocName).ToList();
                var getL4Location =
                    RoomTypesRepository
                    .GetAll()
                    .Where(x => x.L3Location != null && x.L3Location.L2Location.L1LocCode == collection.location_code)
                    .GroupBy(x => x.L4LocName)
                    .Select(x => x.FirstOrDefault());

                if (getL4Location != null)
                {
                    ///<summary> COMMENTED BELOW LINE BY ZAIN ON 25/SEP/2018 
                    ///</summary> QUERY WAS TAKING A LOT OF TIME TO ORDER DATA, RESULTING IN TIME OUT

                    //getL4Location = getL4Location.OrderBy(x => x.L4LocName).ToList();

                    foreach (var item in getL4Location)
                    {
                        result.Add(new clsAssetViewModel
                        {
                            category_code = collection.category_code,
                            group_code = collection.group_code,
                            location_code = collection.section_code,
                            section_code = collection.location_code,
                            room_code = collection.room_code,
                            room_type_code = item.L4LocCode,
                            room_type_name = item.L4LocName
                        });
                    }
                }
                //return result;
            }
            return result;
        }

        public IEnumerable<clsAssetViewModel> GetRoomTypesByLocationId(clsAssetViewModel collection)
        {
            List<clsAssetViewModel> roomTypeList = new List<clsAssetViewModel>();

            objAsset.L1LocCode = collection.location_code;
            DataTable dt = objAsset.GetRoomTypesByLocationId();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    //L1LocCode, L2LocCode, L3LocCode, L4LocCode, L4LocName
                    roomTypeList.Add(new clsAssetViewModel
                    {
                        location_code = dr["L1LocCode"].ToString(),
                        section_code = dr["L2LocCode"].ToString(),
                        room_code = dr["L3LocCode"].ToString(),
                        room_type_code = dr["L4LocCode"].ToString(),
                        room_type_name = dr["L4LocName"].ToString()
                    });
                }
            }
            return roomTypeList;
        }

        #endregion

        #region Asset Tagging

        //Get All Assets by Location Id
        public IEnumerable<clsAssetViewModel> GetAssetTaggingDataByLocationId(clsAssetViewModel collection)
        {
            List<clsAssetViewModel> assetList = new List<clsAssetViewModel>();

            objAsset.L1LocCode = collection.location_code;
            objAsset.UniqueID = collection.unique_id;
            DataTable dt = objAsset.GetAssetTaggingDataByLocationId();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    assetList.Add(new clsAssetViewModel
                    {
                        tid = int.Parse(dr["TID"].ToString()),
                        unique_id = dr["uniqueID"].ToString(),
                        created_on = dr["CreatedOn"].ToString(),
                        asset_number = dr["AssetNumber"].ToString(),
                        asset_description = dr["AssetDescription"].ToString(),

                        location_code = dr["location_code"].ToString(),
                        section_code = dr["section_code"].ToString(),
                        room_code = dr["room_code"].ToString(),
                        room_type_code = dr["room_type"].ToString(),
                        floor_code = dr["floor_code"].ToString(),

                        location_name = dr["location_name"].ToString(),
                        section_name = dr["section_name"].ToString(),
                        floor_name = dr["floor_name"].ToString(),
                        room_name = dr["room_name"].ToString(),
                        room_type_name = dr["room_type_name"].ToString(),

                        category_code = dr["category_code"].ToString(),
                        group_code = dr["group_code"].ToString(),
                        _L3CatCode = dr["L3CatCode"].ToString(),
                        _L4CatCode = dr["L4CatCode"].ToString()
                    });
                }
            }
            return assetList;
        }
        public int UpdateAssetTaggingData(clsAssetTaggingDataUpdate collection)
        {
            int RowsAffected = 0;
            string TagData = collection.TagData;
            dynamic jObj = JsonConvert.DeserializeObject(TagData);

            foreach (var package in jObj)
            {
                objAsset.TID = package.TID;
                objAsset.AssetNumber = package.asset_number;

                int result = objAsset.UpdateAssetTaggingData();
                if (result > 0)
                {
                    RowsAffected = package.TID;
                }
            }

            return RowsAffected;
        }

        #endregion

        #region Asset Reverification

        //Get All Assets by Location Id
        public IEnumerable<clsAssetViewModel> GetReverificationDataByLocationId(clsAssetViewModel collection)
        {
            List<clsAssetViewModel> assetList = new List<clsAssetViewModel>();

            objAsset.L1LocCode = collection.location_code;
            objAsset.UniqueID = collection.unique_id;

            DataTable dt = objAsset.GetReverificationDataByLocationId();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    assetList.Add(new clsAssetViewModel
                    {
                        tid = int.Parse(dr["TID"].ToString()),
                        unique_id = dr["uniqueID"].ToString(),
                        created_on = dr["CreatedOn"].ToString(),
                        asset_number = dr["AssetNumber"].ToString(),
                        asset_description = dr["AssetDescription"].ToString(),

                        location_code = dr["location_code"].ToString(),
                        section_code = dr["section_code"].ToString(),
                        room_code = dr["room_code"].ToString(),
                        room_type_code = dr["room_type"].ToString(),
                        floor_code = dr["floor_code"].ToString(),

                        location_name = dr["location_name"].ToString(),
                        section_name = dr["section_name"].ToString(),
                        floor_name = dr["floor_name"].ToString(),
                        room_name = dr["room_name"].ToString(),
                        room_type_name = dr["room_type_name"].ToString(),

                        category_code = dr["category_code"].ToString(),
                        group_code = dr["group_code"].ToString(),
                        _L3CatCode = dr["L3CatCode"].ToString(),
                        _L4CatCode = dr["L4CatCode"].ToString()
                    });
                }
            }
            return assetList;
        }

        #endregion

        #endregion

        #region PUT



        #endregion
    }
}
