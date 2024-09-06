using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.SharedModel;
using FAS.Adapter;

namespace FAS.Services
{

    public class AssetReconciliationService : IAssetReconciliationService
    {
        AssetReconciliationAdapter assetReconciliationAdapter;

        public AssetReconciliationService()
        {
            assetReconciliationAdapter = new AssetReconciliationAdapter();
        }

        public DashboardSharedModel Reconciliation(AssetViewModel    collection)
        {
            return assetReconciliationAdapter.Reconciliation(collection);
        }

        public DashboardSharedModel ReconciliationByDescription(AssetViewModel collection)
        {
            return assetReconciliationAdapter.ReconciliationByDescription(collection);
        }

        public DashboardSharedModel ReconciliationByRoomNumber(AssetViewModel collection)
        {
            return assetReconciliationAdapter.ReconciliationByRoomNumber(collection);
        }
        public ReconcilationByRoomNoSharedModel ReconciliationByRoomNo(AssetViewModel collection)
        {
            return assetReconciliationAdapter.ReconciliationByRoomNo(collection);
        }
    }
    public interface IAssetReconciliationService
    {
        DashboardSharedModel Reconciliation(AssetViewModel collection);
        DashboardSharedModel ReconciliationByDescription(AssetViewModel collection);
        DashboardSharedModel ReconciliationByRoomNumber(AssetViewModel collection);
        ReconcilationByRoomNoSharedModel ReconciliationByRoomNo(AssetViewModel collection);
    }
}
