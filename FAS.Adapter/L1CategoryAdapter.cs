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
    public class L1CategoryAdapter
    {
        private IL1CategoryRepository L1CategoryRepository;
        private IUnityOfWork unityOfWork;

        public L1CategoryAdapter()
        {
            unityOfWork = new UnityOfWork(new DatabaseFactory());
            L1CategoryRepository = new L1CategoryRepository(unityOfWork.instance);
        }

        public IEnumerable<L1CategoryViewModel> GetL1Category(L1CategoryViewModel l1categoryViewModel)
        {
            List<L1CategoryViewModel> result = new List<L1CategoryViewModel>();
            if (l1categoryViewModel.L3CatCode == null)
            {
            var getL1Category = L1CategoryRepository.GetAll().Where(x=>x.L1LocCode == l1categoryViewModel.L1LocCode).ToList();

            foreach (var item in getL1Category)
            {
                result.Add(new L1CategoryViewModel
                {
                    L1CatCode = item.L1CatCode,
                    L1CatName = item.L1CatName
                });
            }
            return result;
            }
            else
            {
                var getL1Category = (from L1Cat in unityOfWork.db.L1Category join
                                     L2Cat in unityOfWork.db.L2Category on L1Cat.L1CatCode equals L2Cat.L1CatCode join
                                     L3Cat in unityOfWork.db.L3Category on L2Cat.L2CatCode equals L3Cat.L2CatCode where
                                     L3Cat.L3CatCode == l1categoryViewModel.L3CatCode && L1Cat.L1LocCode == l1categoryViewModel.L1LocCode select L1Cat
                                     ).ToList();

                foreach (var item in getL1Category)
                {
                    result.Add(new L1CategoryViewModel
                    {
                        L1CatCode = item.L1CatCode,
                        L1CatName = item.L1CatName
                    });
                }
                return result;
            }
        }

        public string SetDepreciationRate(AssetViewModel collection)
        {
            var groups = collection.DepreciationSetupList;
            foreach(var item in groups)
            {
                var group = (from L1Cat in unityOfWork.db.L1Category where L1Cat.L1LocCode == collection.L1LocCode && L1Cat.L1CatCode == item.L1CatCode select L1Cat).FirstOrDefault();
                group.DepreciationRate = item.DepreciatedValue;
                L1CategoryRepository.Update(group);
            }
           var message = unityOfWork.Commit();
            return message;
        }
    }
}
