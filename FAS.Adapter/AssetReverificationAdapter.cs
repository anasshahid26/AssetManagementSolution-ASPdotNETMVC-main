using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Infrastructure.Common;
using FAS.Infrastructure.Repository;
using FAS.SharedModel;
using FAS.Data;
using System.Text.RegularExpressions;

namespace FAS.Adapter
{
    public class AssetReverificationAdapter
    {
        private IAssetReverificationRepository assetReverificationRepository;
        private IL1CategoryRepository groupRepository;
        private IL2LocationRepository sectionRepository;
        private IL2CategoryRepository categoryRepository;
        private IL3LocationRepository L3LocationRepository;
        private IL4LocationRepository L4LocationRepository;
        private IL5LocationRepository L5LocationRepository;
        private IUnityOfWork unityOfWork;

        public AssetReverificationAdapter()
        {
            unityOfWork = new UnityOfWork(new DatabaseFactory());
            assetReverificationRepository = new AssetReverificationRepository(unityOfWork.instance);
            groupRepository = new L1CategoryRepository(unityOfWork.instance);
            sectionRepository = new L2LocationRepository(unityOfWork.instance);
            categoryRepository = new L2CategoryRepository(unityOfWork.instance);
            L3LocationRepository = new L3LocationRepository(unityOfWork.instance);
            L4LocationRepository = new L4LocationRepository(unityOfWork.instance);
            L5LocationRepository = new L5LocationRepository(unityOfWork.instance);
        }

        public IEnumerable<ReverificationViewModel> getOngoingReverificationDate(ReverificationViewModel collection)
        {
            var dateOfReverification = (from assetReverification in unityOfWork.db.AssetReverifications where assetReverification.L1LocCode == collection.L1LocCode select new ReverificationViewModel { RDateOfVerification = assetReverification.RDateOfVerification }).Distinct().ToList();
            if (dateOfReverification.Count != 0)
            {
                return dateOfReverification;
            }
            else
            {
                return dateOfReverification;
            }
        }

        public IEnumerable<ReverificationViewModel> ReverifiedAssetsByDateOfVerification(ReverificationViewModel collection)
        {
            var asset1 = (from assetReverification in unityOfWork.db.AssetReverifications
                          where assetReverification.L1LocCode == collection.L1LocCode
                          select assetReverification);
            var assets = (from assetReverification in unityOfWork.db.AssetReverifications
                          where assetReverification.L1LocCode == collection.L1LocCode && assetReverification.RL1LocCode != null
                          select new ReverificationViewModel
                          {
                              VerificationStatus = assetReverification.RVerificationStatus,
                              DateOfVerification = assetReverification.RDateOfVerification,
                              AssetNumber = assetReverification.RAssetNumber,
                              AssetDescription = assetReverification.RAssetDescription,
                              RL1CatCode = assetReverification.RL1CatCode,
                              RL2CatCode = assetReverification.RL2CatCode,
                              RL2LocCode = assetReverification.RL2LocCode,
                              RL3LocCode = assetReverification.RL3LocCode,
                              RL4LocCode = assetReverification.RL4LocCode,
                              RL5LocCode = assetReverification.RL5LocCode,
                              Count = asset1.Count()
        }).ToList();

            if (collection.VerificationStatus != null)
            {
                assets = assets.Where(x => x.VerificationStatus.Equals(collection.VerificationStatus)).ToList();
            }

            if (collection.RDateOfVerification != null)
            {
                assets = assets.Where(x => x.DateOfVerification.Equals(collection.RDateOfVerification)).ToList();
            }

            if (collection.L2LocCode != null)
            {
                assets = assets.Where(x => x.RL2LocCode.Equals(collection.RL2LocCode)).ToList();
            }

            if (collection.L3LocCode != null)
            {
                assets = assets.Where(x => x.RL3LocCode.Equals(collection.RL3LocCode)).ToList();
            }

            foreach (var item in assets)
            {
                item.Group = groupRepository.GetById(item.RL1CatCode).L1CatName;
                item.Category = categoryRepository.GetById(item.RL2CatCode).L2CatName;
                item.Section = sectionRepository.GetById(item.RL2LocCode).L2LocName;
                item.RoomNo = L3LocationRepository.GetById(item.RL3LocCode).L3LocName;
                item.RoomType = L4LocationRepository.GetById(item.RL4LocCode).L4LocName;
                item.Floor = L5LocationRepository.GetById(item.RL5LocCode).L5LocName;
            }
            return assets;
        }

        public IEnumerable<ReverificationViewModel> GetReverificationMobileData(ReverificationViewModel collection)
        {
            var getReverificationData = (from AssetRev in unityOfWork.db.AssetReverifications
                                         where AssetRev.L1LocCode == collection.L1LocCode
                                         select new ReverificationViewModel
                                         {

                                             AssetDescription = AssetRev.AssetDescription,
                                             AssetNumber = AssetRev.AssetNumber,
                                             L1LocCode = AssetRev.L1LocCode,
                                             L1LocName = AssetRev.L1LocName,
                                             L2LocCode = AssetRev.L2LocCode,
                                             Section = AssetRev.L2LocName,
                                             L3LocCode = AssetRev.L3LocCode,
                                             RoomNo = AssetRev.L3LocName,
                                             L4LocCode = AssetRev.L4LocCode,
                                             RoomType = AssetRev.L4LocName,
                                             L5LocCode = AssetRev.L5LocCode,
                                             Floor = AssetRev.L5LocName,
                                             RL1LocCode = AssetRev.RL1LocCode,
                                             RL2LocCode = AssetRev.RL2LocCode,
                                             RL3LocCode = AssetRev.RL3LocCode,
                                             RL4LocCode = AssetRev.RL4LocCode,
                                             RL5LocCode = AssetRev.RL5LocCode,
                                             L1CatCode = AssetRev.L1CatCode,
                                             L2CatCode = AssetRev.L2CatCode,
                                             L3CatCode = AssetRev.L3CatCode,
                                             L4CatCode = AssetRev.L4CatCode,
                                             RL1CatCode = AssetRev.RL1CatCode,
                                             RL2CatCode = AssetRev.RL2CatCode,
                                             RL3CatCode = AssetRev.RL3CatCode,
                                             RL4CatCode = AssetRev.RL4CatCode,
                                             CODELEVEL = AssetRev.CODELEVEL,
                                             CreatedOn = AssetRev.CreatedOn,
                                             DateOfVerification = AssetRev.DateOfVerification,
                                             Depreciated = AssetRev.Depreciated,
                                             DisposedOn = AssetRev.DisposedOn,
                                             ITC1 = AssetRev.ITC1,
                                             ITC2 = AssetRev.ITC2,
                                             ITC3 = AssetRev.ITC3,
                                             LOCCODEASSET = AssetRev.LOCCODEASSET,
                                             NetBookValue = AssetRev.NetBookValue,
                                             VerificationStatus = AssetRev.VerificationStatus,
                                             Status = AssetRev.Status,
                                             RCODELEVEL = AssetRev.CODELEVEL,
                                             RCreatedOn = AssetRev.CreatedOn,
                                             RDateOfVerification = AssetRev.DateOfVerification,
                                             RDepreciated = AssetRev.Depreciated,
                                             RDisposedOn = AssetRev.DisposedOn,
                                             RITC1 = AssetRev.ITC1,
                                             RITC2 = AssetRev.ITC2,
                                             RITC3 = AssetRev.ITC3,
                                             RLOCCODEASSET = AssetRev.LOCCODEASSET,
                                             RNetBookValue = AssetRev.NetBookValue,
                                             RVerificationStatus = AssetRev.VerificationStatus,
                                             RStatus = AssetRev.Status,
                                             RAssetDescription = AssetRev.AssetDescription,
                                             RAssetNumber = AssetRev.AssetNumber,
                                             ROOMTYPECODE = AssetRev.ROOMTYPECODE,
                                             RROOMTYPECODE = AssetRev.RROOMTYPECODE,
                                             RUniqueID = AssetRev.RUniqueID
                                         });
            return getReverificationData;
        }
    }
}
