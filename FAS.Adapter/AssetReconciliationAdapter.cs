using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Infrastructure.Common;
using FAS.Infrastructure.Repository;
using FAS.SharedModel;
using System.Data;

namespace FAS.Adapter
{

    public class AssetReconciliationAdapter
    {
        private IReconciliationRepository assetReconciliationRepository;
        private IL1CategoryRepository groupRepository;
        private IL2LocationRepository sectionRepository;
        private IL2CategoryRepository categoryRepository;
        private IL3CategoryRepository descriptionRepository;
        private IL3LocationRepository L3LocationRepository;
        private IL4LocationRepository L4LocationRepository;
        private IL5LocationRepository L5LocationRepository;
        private IUnityOfWork unityOfWork;

        public AssetReconciliationAdapter()
        {
            unityOfWork = new UnityOfWork(new DatabaseFactory());
            assetReconciliationRepository = new ReconciliationRepository(unityOfWork.instance);
            groupRepository = new L1CategoryRepository(unityOfWork.instance);
            sectionRepository = new L2LocationRepository(unityOfWork.instance);
            categoryRepository = new L2CategoryRepository(unityOfWork.instance);
            L3LocationRepository = new L3LocationRepository(unityOfWork.instance);
            L4LocationRepository = new L4LocationRepository(unityOfWork.instance);
            L5LocationRepository = new L5LocationRepository(unityOfWork.instance);
            descriptionRepository = new L3CategoryRepository(unityOfWork.instance);
        }

        public DashboardSharedModel Reconciliation(AssetViewModel collection)
        {
            //var NewAssets = (from asset in unityOfWork.db.Reconciliations where asset.L1LocCode == collection.L1LocCode && asset.RVerificationStatus != "MISSING" select asset).ToList();
            //var OldAssets = (from asset in unityOfWork.db.Reconciliations where asset.L1LocCode == collection.L1LocCode && asset.AssetDescription != null select asset).ToList();

            var NewAssets = (from asset in unityOfWork.db.AssetReverifications where asset.L1LocCode == collection.L1LocCode && asset.RVerificationStatus != "MISSING" && asset.RAssetNumber != null select asset).ToList();
            var OldAssets = (from asset in unityOfWork.db.AssetReverifications where asset.L1LocCode == collection.L1LocCode && asset.AssetDescription != null && asset.RAssetNumber != null select asset).ToList();

            ////var totalAssetsR = (from asset in unityOfWork.db.Assets where asset.L1LocCode == collection.L1LocCode select asset).ToList();
            var NewAssetsCount = NewAssets.Count();
            var OldAssetsCountR = OldAssets.Count();

            var totalCategory = categoryRepository.GetAll().Where(x => x.L1LocCode == collection.L1LocCode).GroupBy(x => x.L2CatName);

            List<CategorySharedModel> category = new List<CategorySharedModel>();
            foreach (var item in totalCategory)
            {
                category.Add(new CategorySharedModel
                {
                    CategoryCountNew = NewAssets.Where(x => x.L2Category.L2CatName == item.Key).Count(),
                    CategoryCountOld = OldAssets.Where(x => x.L2Category.L2CatName == item.Key).Count(),
                    CategoryCount = NewAssets.Where(x => x.L2Category.L2CatName == item.Key).Count() - OldAssets.Where(x => x.L2Category.L2CatName == item.Key).Count(),
                    CategoryName = item.Key
                });
            }

            DashboardSharedModel dashboard = new DashboardSharedModel();
            dashboard.TotalCategory = category;
            dashboard.AssetCount = OldAssetsCountR;
            dashboard.AssetCountR = NewAssetsCount;
            dashboard.AssetVaraince = NewAssetsCount - OldAssetsCountR;
            return dashboard;
        }

        public DashboardSharedModel ReconciliationByDescription(AssetViewModel collection)
        {
            //var NewAssets = (from asset in unityOfWork.db.Reconciliations where asset.L1LocCode == collection.L1LocCode && asset.RVerificationStatus != "MISSING" select asset).ToList();
            //var OldAssets = (from asset in unityOfWork.db.Reconciliations where asset.L1LocCode == collection.L1LocCode && asset.AssetDescription != null select asset).ToList();

            var NewAssets = (from asset in unityOfWork.db.AssetReverifications where asset.L1LocCode == collection.L1LocCode && asset.RVerificationStatus != "MISSING" && asset.RAssetNumber != null select asset).ToList();
            var OldAssets = (from asset in unityOfWork.db.AssetReverifications where asset.L1LocCode == collection.L1LocCode && asset.AssetDescription != null && asset.RAssetNumber != null select asset).ToList();

            var NewAssetsCount = NewAssets.Count();
            var OldAssetsCountR = OldAssets.Count();

            var totalDescription = descriptionRepository.GetAll().Where(x => x.L1LocCode == collection.L1LocCode).GroupBy(x => x.L3CatName);

            List<DescriptionViewModel> description = new List<DescriptionViewModel>();
            foreach (var item in totalDescription)
            {
                description.Add(new DescriptionViewModel
                {
                    DescriptionCountNew = NewAssets.Where(x => x.L3Category.L3CatName == item.Key).Count(),
                    DescriptionCountOld = OldAssets.Where(x => x.L3Category.L3CatName == item.Key).Count(),
                    DescriptionCount = NewAssets.Where(x => x.L3Category.L3CatName == item.Key).Count() - OldAssets.Where(x => x.L3Category.L3CatName == item.Key).Count(),
                    Description = item.Key
                });
            }

            DashboardSharedModel dashboard = new DashboardSharedModel();
            dashboard.TotalDescription = description;
            dashboard.AssetCount = OldAssetsCountR;
            dashboard.AssetCountR = NewAssetsCount;
            dashboard.AssetVaraince = NewAssetsCount - OldAssetsCountR;
            return dashboard;
        }

        public DashboardSharedModel ReconciliationByRoomNumber(AssetViewModel collection)
        {
            #region COMMENT
            /*
            //var NewAssets = (from asset in unityOfWork.db.Reconciliations where asset.L1LocCode == collection.L1LocCode && asset.RVerificationStatus != "MISSING" select asset).ToList();
            //var OldAssets = (from asset in unityOfWork.db.Reconciliations where asset.L1LocCode == collection.L1LocCode && asset.AssetDescription != null select asset).ToList();

            var NewAssets = (from asset in unityOfWork.db.AssetReverifications where asset.L1LocCode == collection.L1LocCode && asset.RVerificationStatus != "MISSING" && asset.RAssetNumber != null select asset).ToList();
            var OldAssets = (from asset in unityOfWork.db.AssetReverifications where asset.L1LocCode == collection.L1LocCode && asset.AssetNumber != null select asset).ToList(); //&& asset.AssetDescription != null && asset.RAssetNumber != null select asset).ToList();

            var NewAssetsCount = NewAssets.Count();
            var OldAssetsCountR = OldAssets.Count();

            var totalRooms = L3LocationRepository.GetAll().Where(x => x.L1LocCode == collection.L1LocCode).GroupBy(x => x.L3LocName);

            List<RoomViewModel> room = new List<RoomViewModel>();

            foreach (var item in totalRooms)
            {
                room.Add(new RoomViewModel
                {
                    RoomCountNew = NewAssets.Where(x => x.L3Location.L3LocName == item.Key).Count(),
                    RoomCountOld = OldAssets.Where(x => x.L3Location.L3LocName == item.Key).Count(),
                    RoomCount = NewAssets.Where(x => x.L3Location.L3LocName == item.Key).Count() - OldAssets.Where(x => x.L3Location.L3LocName == item.Key).Count(),
                    RoomNo = item.Key
                });
            }

            DashboardSharedModel dashboard = new DashboardSharedModel();
            dashboard.TotalRoom = room;
            dashboard.AssetCount = OldAssetsCountR;
            dashboard.AssetCountR = NewAssetsCount;
            dashboard.AssetVaraince = NewAssetsCount - OldAssetsCountR;
            return dashboard;
            */
            #endregion

            DashboardSharedModel dashboard = new DashboardSharedModel();
            clsAsset objAsset = new clsAsset();

            objAsset.L1LocCode = collection.L1LocCode;

            DataTable dt = objAsset.ReportAssetReconcilationByRoom();

            if (dt.Rows.Count > 0)
            {
                int OldAssetCount = 0, NewAssetCount = 0;

                List<RoomViewModel> room = new List<RoomViewModel>();

                foreach (DataRow dr in dt.Rows)
                {
                    OldAssetCount += int.Parse(dr["OLD_ASSET_COUNT"].ToString());
                    NewAssetCount += int.Parse(dr["NEW_ASSET_COUNT"].ToString());

                    room.Add(new RoomViewModel
                    {
                        RoomCountNew = int.Parse(dr["NEW_ASSET_COUNT"].ToString()),
                        RoomCountOld = int.Parse(dr["OLD_ASSET_COUNT"].ToString()),
                        RoomCount = int.Parse(dr["ASSET_DIFF"].ToString()),
                        RoomNo = dr["ROOM_NO"].ToString()
                    });
                }

                dashboard.TotalRoom = room;
                dashboard.AssetCount = OldAssetCount;
                dashboard.AssetCountR = NewAssetCount;
                dashboard.AssetVaraince = NewAssetCount - OldAssetCount;
            }
            return dashboard;
        }


        public ReconcilationByRoomNoSharedModel ReconciliationByRoomNo(AssetViewModel collection)
        {
            var NewAssets = (from asset in unityOfWork.db.AssetReverifications
                             where
                                asset.L1LocCode == collection.L1LocCode &&
                                asset.L2LocName == collection.L2LocName &&
                                asset.L3LocName == collection.L3LocName &&
                                asset.RVerificationStatus != "MISSING" &&
                                asset.RAssetNumber != null
                             select asset).ToList();

            var OldAssets = (from asset in unityOfWork.db.AssetReverifications
                             where
                                asset.L1LocCode == collection.L1LocCode &&
                                asset.L2LocName == collection.L2LocName &&
                                asset.L3LocName == collection.L3LocName &&
                                asset.AssetNumber != null
                             select asset).ToList();

            var NewAssetsCount = NewAssets.Count();
            var OldAssetsCountR = OldAssets.Count();

            var totalRooms = L3LocationRepository.GetAll()
                .Where(x => x.L1LocCode == collection.L1LocCode)
                .Where(x => x.L3LocName == collection.L3LocName)
                .GroupBy(x => x.L3LocName);

            int TotalReverifiedData = 0;
            List<RoomNoViewModel> room = new List<RoomNoViewModel>();
            List<RoomNoViewModel> roomReturn = new List<RoomNoViewModel>();
            foreach (var item in totalRooms)
            {
                var _RoomNo = item.Key.ToString();

                foreach (var item1 in item)
                {
                    foreach (var item2 in item1.Assets)
                    {

                        int _RoomCountNew = 0;
                        int _RoomCountOld = 0;
                        int _RoomCount = 0;

                        var _BarCode = "";
                        var _AssetDesc = "";

                        _BarCode = item2.AssetNumber.ToString();
                        _AssetDesc = item2.AssetDescription.ToString();

                        try
                        {
                            _RoomCountNew = NewAssets
                                .Where(x => x.AssetNumber == _BarCode)
                                .Count();
                        }
                        catch (Exception)
                        {
                            _RoomCountNew = 0;
                        }

                        try
                        {
                            _RoomCountOld = OldAssets
                                .Where(x => x.AssetNumber == _BarCode)
                                .Count();
                        }
                        catch (Exception)
                        {
                            _RoomCountOld = 0;
                        }

                        try
                        {
                            _RoomCount = _RoomCountNew - _RoomCountOld;
                        }
                        catch (Exception)
                        {
                            _RoomCount = 0;
                        }

                        if (_RoomCount == 0)
                        {
                            TotalReverifiedData++;
                        }

                        room.Add(new RoomNoViewModel
                        {
                            BarCode = _BarCode,
                            AssetDescription = _AssetDesc,
                            RoomCountNew = _RoomCount,
                            RoomCountOld = _RoomCountOld,
                            RoomCount = _RoomCount,
                            RoomNo = _RoomNo,
                            TotalPreviousData = NewAssetsCount,
                            TotalReverified = OldAssetsCountR,
                            TotalVariance = NewAssetsCount - OldAssetsCountR
                        });
                    }
                }
            }
            roomReturn = room.OrderBy(x => x.AssetDescription).ToList();

            ReconcilationByRoomNoSharedModel dashboard = new ReconcilationByRoomNoSharedModel();
            dashboard.TotalRoom = roomReturn;
            dashboard.AssetCount = OldAssetsCountR;
            dashboard.AssetCountR = TotalReverifiedData;//NewAssetsCount;
            dashboard.AssetVaraince = NewAssetsCount - OldAssetsCountR;
            return dashboard;
        }
    }
}
