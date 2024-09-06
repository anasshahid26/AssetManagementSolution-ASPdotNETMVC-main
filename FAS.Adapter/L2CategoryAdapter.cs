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
    public class L2CategoryAdapter
    {
        private IL2CategoryRepository L2CategoryRepository;
        private IUnityOfWork unityOfWork;

        public L2CategoryAdapter()
        {
            unityOfWork = new UnityOfWork(new DatabaseFactory());
            L2CategoryRepository = new L2CategoryRepository(unityOfWork.instance);
        }

        public IEnumerable<L2CategoryViewModel> GetL2Category(L2CategoryViewModel l2CategoryViewModel)
        {
            List<L2CategoryViewModel> result = new List<L2CategoryViewModel>();
            if (l2CategoryViewModel.L1CatCode != null)
            {
                var getL2Category = (from l2Category in unityOfWork.db.L2Category join asset in unityOfWork.db.Assets on l2Category.L2CatCode equals asset.L2CatCode
                                     where l2Category.L1CatCode == l2CategoryViewModel.L1CatCode
                                     select l2Category).Distinct().ToList();

                foreach (var item in getL2Category)
                {
                    result.Add(new L2CategoryViewModel
                    {
                        L2CatCode = item.L2CatCode,
                        L2CatName = item.L2CatName
                    });
                }
                return result;
            }

            else
            {
                if(l2CategoryViewModel.L3CatCode == null)
                {

                var getL2Category = L2CategoryRepository.GetAll().Where(x=>x.L1Category.L1LocCode == l2CategoryViewModel.L1LocCode).GroupBy(x => x.L2CatName).Select(x => x.First()).OrderBy(x => x.L2CatName).ToList();
                foreach (var item in getL2Category)
                {
                    result.Add(new L2CategoryViewModel
                    {
                        L2CatCode = item.L2CatCode,
                        L2CatName = item.L2CatName
                    });
                }
                return result;
                }
                else
                {
                    var getL2Category = (from L2Cat in unityOfWork.db.L2Category join L3Cat in unityOfWork.db.L3Category on L2Cat.L2CatCode equals L3Cat.L2CatCode where L3Cat.L3CatCode == l2CategoryViewModel.L3CatCode && L3Cat.L1LocCode == l2CategoryViewModel.L1LocCode select L2Cat).ToList();
                    foreach (var item in getL2Category)
                    {
                        result.Add(new L2CategoryViewModel
                        {
                            L2CatCode = item.L2CatCode,
                            L2CatName = item.L2CatName
                        });
                    }
                    return result;
                }
            }
        }

        public IEnumerable<L2CategoryViewModel> GetL2CategoryOnly(L2CategoryViewModel l2CatgeoryViewModel)
        {
            List<L2CategoryViewModel> result = new List<L2CategoryViewModel>();
            //select l2.L2CatCode, l2.L2CatName from dbo.L2Category l2 inner join L1Category l1 on l2.L1CatCode = l1.L1CatCode where l2.L1CatCode = 'PCCHEFF' AND l1.L1LocCode = 'PCCHE'
            var getL2Category = (from l2 in unityOfWork.db.L2Category join l1 in unityOfWork.db.L1Category on l2.L1CatCode equals l1.L1CatCode where l2.L1CatCode == l2CatgeoryViewModel.L1CatCode && l1.L1LocCode == l2CatgeoryViewModel.L1LocCode select l2).ToList();
            foreach (var item in getL2Category)
            {
                result.Add(new L2CategoryViewModel
                {
                    L2CatCode = item.L2CatCode,
                    L2CatName = item.L2CatName
                });
            }
            return result;
        }
    }
}
