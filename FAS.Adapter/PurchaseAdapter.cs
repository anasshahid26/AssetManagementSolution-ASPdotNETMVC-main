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
    public class PurchaseAdapter
    {
        private IPurchaseRepository PurchaseRepository;
        private IUnityOfWork UnitofWork;
        //private MatrixFASEntities dataContext;

        public PurchaseAdapter()
        {
            UnitofWork = new UnityOfWork(new DatabaseFactory());
            PurchaseRepository = new PurchaseRepository(UnitofWork.instance);
        }
        
        public string AddPurchaseDetail (PurchaseDetail assetAddition)
        {
            string PurchaseIDS = IsPurchaseCodeExsist(assetAddition.L1LocCode);
            PurchaseDetail Purchase = new PurchaseDetail()
            {
                PurchaseID = PurchaseIDS,
                SupplierID = assetAddition.SupplierID,
                InvoiceNumber = assetAddition.InvoiceNumber,
                PONumber = assetAddition.PONumber,
                DateofPO = Convert.ToDateTime(assetAddition.DateofPO),

                iso = assetAddition.iso,
                InvoiceImage = assetAddition.InvoiceImage,
                UnitPrice = assetAddition.UnitPrice,
                PurchaseOrderImage = assetAddition.PurchaseOrderImage,
                L1LocCode = assetAddition.L1LocCode,
                DateofPurchase = Convert.ToDateTime(assetAddition.DateofPurchase),
                AssetNumber = assetAddition.AssetNumber
            };

            PurchaseRepository.Add(Purchase);
            UnitofWork.Commit();
            return PurchaseIDS;
        }

        public string IsPurchaseCodeExsist(string L1LocCode)
        {
            Random random = new Random();
            string number = Convert.ToString(random.Next(1000, 9999));
            string PurchaseID = L1LocCode + number;

            var Purchase = (from purchaseID in UnitofWork.db.PurchaseDetails
                                     where purchaseID.PurchaseID== PurchaseID
                                     select purchaseID).ToList();
            if (Purchase.Count == 0)
            {
                return PurchaseID;
            }
            return IsPurchaseCodeExsist(L1LocCode);
        }
    }
}
