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
    public class SupplierAdapter
    {
        private ISupplierRepository SupplierRepository;
        private IActivityLogRepository ActivityLogRepository;
        private IUnityOfWork UnitofWork;

        public SupplierAdapter()
        {
            UnitofWork = new UnityOfWork(new DatabaseFactory());
            SupplierRepository = new SupplierRepository(UnitofWork.instance);
            ActivityLogRepository = new ActivityLogRepository(UnitofWork.instance);
        }

        public IEnumerable<SupplierViewModel> GetAllSuplier(SupplierViewModel supplierViewModel)
        {
            List<SupplierViewModel> result = new List<SupplierViewModel>();
            if(supplierViewModel != null)
            {
                var supplier = SupplierRepository.GetAll().Where(x => x.CompanyID == supplierViewModel.CompanyID).ToList();
                if (supplier.Count > 0)
                {
                    foreach (var item in supplier)
                    {
                        result.Add(new SupplierViewModel
                        {
                            SupplierName = item.SupplierName,
                            SupplierID = item.SupplierID
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
                var supplier = SupplierRepository.GetAll().ToList();
                if (supplier.Count > 0)
                {
                    foreach (var item in supplier)
                    {
                        result.Add(new SupplierViewModel
                        {
                            SupplierName = item.SupplierName,
                            SupplierID = item.SupplierID
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

        public int RandomNumber(int min=1, int max=1000)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public string SupplierAddition(SupplierViewModel supplierViewModel)
        {
            supplierViewModel.SupplierID = "DEMO17100000";//RandomNumber().ToString();
            
            Supplier Supplier = new Supplier()
            {
                
                SupplierID = supplierViewModel.SupplierID,
                CompanyID = supplierViewModel.CompanyID,
                CountryID = supplierViewModel.CountryID,
                SupplierAddress = supplierViewModel.SupplierAddress,
                SupplierEmail = supplierViewModel.SupplierEmail,
                SupplierName = supplierViewModel.SupplierName,
                SupplierTelephone = supplierViewModel.SupplierTelephone
            };


            //Supplier Supplier = new Supplier()
            //{
            //    SupplierID = "asdasd",
            //    AssetCompany = new AssetCompany(),
            //    GatePassTransactions = new List<GatePassTransaction>(),
            //    PurchaseDetails = new List<PurchaseDetail>(),
            //    CompanyID = 1,// supplierViewModel.CompanyID,
            //    CountryID = 1,//supplierViewModel.CountryID,
            //    SupplierAddress = "dasfads",//supplierViewModel.SupplierAddress,
            //    SupplierEmail = "adf",//supplierViewModel.SupplierEmail,
            //    SupplierName = "asdasdasd",//supplierViewModel.SupplierName,
            //    SupplierTelephone = "sddsfsdf",//supplierViewModel.SupplierTelephone
            //};


            SupplierRepository.Add(Supplier);
            var res = UnitofWork.Commit();

            User_Activity Activity = new User_Activity()
            {
                UserID = supplierViewModel.UserID,
                Activity = "Added Supplier",
                ActivityTime = DateTime.Now
            };
            ActivityLogRepository.Add(Activity);
            UnitofWork.Commit();

            if (Supplier.SupplierID != null)
            {
                return "Supplier Added";

            }
            else
            {
                return "Supplier Can not be Added";
            }
        }

    }
}
