using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Adapter;
using FAS.SharedModel;
using FAS.Data;

namespace FAS.Services
{
    public class AssetReverificationService : IAssetReverificationService
    {
        AssetReverificationAdapter assetReverificationAdapter;

        public AssetReverificationService()
        {
            assetReverificationAdapter = new AssetReverificationAdapter();
        }

        public IEnumerable<ReverificationViewModel> getOngoingReverificationDate(ReverificationViewModel collection)
        {
            return assetReverificationAdapter.getOngoingReverificationDate(collection);
        }

        public IEnumerable<ReverificationViewModel> ReverifiedAssetsByDateOfVerification(ReverificationViewModel collection)
        {
            return assetReverificationAdapter.ReverifiedAssetsByDateOfVerification(collection);
        }

        public IEnumerable<ReverificationViewModel> GetReverificationMobileData (ReverificationViewModel collection)
        {
            return assetReverificationAdapter.GetReverificationMobileData(collection);
        }
    }
    public interface IAssetReverificationService
    {
        IEnumerable<ReverificationViewModel> getOngoingReverificationDate(ReverificationViewModel collection);
        IEnumerable<ReverificationViewModel> ReverifiedAssetsByDateOfVerification(ReverificationViewModel collection);
        IEnumerable<ReverificationViewModel> GetReverificationMobileData(ReverificationViewModel L1LocCode);
    }
}
