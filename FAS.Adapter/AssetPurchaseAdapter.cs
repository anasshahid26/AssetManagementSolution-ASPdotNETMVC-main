using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Infrastructure.Repository;
using FAS.Infrastructure.Common;
using FAS.SharedModel;
using FAS.Data;

namespace FAS.Adapter
{
    public class AssetPurchaseAdapter
    {
        private IAssetPurchaseRepository AssetPurchaseRepository;
        private IUnityOfWork UnityofWork;

        public AssetPurchaseAdapter()
        {
            UnityofWork = new UnityOfWork(new DatabaseFactory());
            AssetPurchaseRepository = new AssetPurchaseRepository(UnityofWork.instance);
        }

        public string AddAssetPurchases(string PurchaseID, string UniqueID, string L1LocCode)
        {
            string AssetPurchaseID = IsAssetPurchaseCodeExsist(L1LocCode);
            AssetPurchase AssetPurchase = new AssetPurchase()
            {
                AssetPurchase1 = AssetPurchaseID,
                PurchaseID = PurchaseID,
                UniqueID = UniqueID,
                L1LocCode = L1LocCode
            };
            AssetPurchaseRepository.Add(AssetPurchase);
            UnityofWork.Commit();
            return "Asset Purchase Recorded";
        }

        public string IsAssetPurchaseCodeExsist(string L1LocCode)
        {
            Random random = new Random();
            string number = Convert.ToString(random.Next(1000, 9999));
            string AssetPurchaseID = "AP"+L1LocCode + number;

            var AssetPurchases = (from AssetPurch in UnityofWork.db.AssetPurchases
                            where AssetPurch.AssetPurchase1 == AssetPurchaseID
                            select AssetPurch).ToList();
            if (AssetPurchases.Count == 0)
            {
                return AssetPurchaseID;
            }
            return IsAssetPurchaseCodeExsist(L1LocCode);
        }

        public string IsAssetPurchaseDeatilExist(AssetViewModel collection)
        {
            var AssetPurchase = (from assetPurchase in UnityofWork.db.AssetPurchases where assetPurchase.L1LocCode == collection.L1LocCode && assetPurchase.UniqueID == collection.L1LocCode + collection.AssetNumber select assetPurchase).ToList();
            if(AssetPurchase.Count != 0)
            {
                return "Asset Purchase Detail Already Exist";
            }else
            {
                return "Asset Purchase Detail Not Exist";
            }
        }
    }
}
