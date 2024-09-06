using FAS.Data;
using FAS.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.Services.V2
{
    public class SupplierServices
    {
        #region Defined as Singleton
        private static SupplierServices instance;

        public static SupplierServices Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SupplierServices();
                }
                return instance;
            }
        }

        private SupplierServices() { }
        #endregion

        public string SupplierAddition(SupplierViewModel supplierViewModel)
        {
            string result = "";
            try
            {
                supplierViewModel.SupplierID = SupplierIDExist(supplierViewModel.L1LocCode);
                using (var context = DataContextHelper.GetMatrixFASDataContext())
                {
                    context.Suppliers.InsertOnSubmit(new DataModel.Supplier()
                    {
                        SupplierID = supplierViewModel.SupplierID,
                        CompanyID = supplierViewModel.CompanyID,
                        CountryID = supplierViewModel.CountryID,
                        SupplierAddress = supplierViewModel.SupplierAddress,
                        SupplierEmail = supplierViewModel.SupplierEmail,
                        SupplierName = supplierViewModel.SupplierName,
                        SupplierTelephone = supplierViewModel.SupplierTelephone
                    });
                    context.SubmitChanges();
                }
                result = "Supplier Added";
            }
            catch
            {
                result = "Supplier Can not be Added";
            }
            return result;
        }

        private string SupplierIDExist(string supplierId)
        {
            Random random = new Random();
            string number = Convert.ToString(random.Next(1000, 9999));
            string AssetPurchaseID = supplierId + number;

            using (var context = DataContextHelper.GetMatrixFASDataContext())
            {
                var AssetPurchases = (from AssetPurch in context.AssetPurchases
                                      where AssetPurch.AssetPurchase1 == AssetPurchaseID
                                      select AssetPurch).ToList();

                if (AssetPurchases.Count == 0)
                {
                    return AssetPurchaseID;
                }
            }
            return SupplierIDExist(supplierId);
        }
    }
}
