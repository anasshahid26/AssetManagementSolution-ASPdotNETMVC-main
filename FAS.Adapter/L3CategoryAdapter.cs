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
    public class L3CategoryAdapter
    {
        private IL3CategoryRepository L3CategoryRepository;
        private IActivityLogRepository ActivityLogRepository;
        private IUnityOfWork unityOfWork;

        public L3CategoryAdapter()
        {
            unityOfWork = new UnityOfWork(new DatabaseFactory());
            L3CategoryRepository = new L3CategoryRepository(unityOfWork.instance);
            ActivityLogRepository = new ActivityLogRepository(unityOfWork.instance);
        }

        public IEnumerable<L3CategoryViewModel> GetL3Category(L3CategoryViewModel L3CategoryViewModel)
        {
            var getL3Category = L3CategoryRepository.GetAll().Where(x=>x.L1LocCode == L3CategoryViewModel.L1LocCode).Distinct().ToList();
            List<L3CategoryViewModel> result = new List<L3CategoryViewModel>();

            foreach (var item in getL3Category)
            {
                result.Add(new L3CategoryViewModel
                {
                    L3CatCode = item.L3CatCode,
                    L3CatName = item.L3CatName
                });
            }
            return result;
        }

        public string AddL3Category(L3CategoryViewModel L3CategoryViewModel)
        {
            var ITC = (from L3 in unityOfWork.db.L3Category where
                       L3.L2CatCode == L3CategoryViewModel.L2CatCode && L3.L1LocCode == L3CategoryViewModel.L1LocCode
                       select L3.ITC2).ToList();

            var list = new List<int>();// ITC.Select(int.Parse).ToList();
            foreach (var item in ITC)
            {
                int a = 0;
                int.TryParse(item, out a);
                if (a > 0)
                list.Add(a);
            }

            int ITC2 = list.Count > 0 ? list.Max() : 0;
            ITC2 = ITC2 + 1;
            var L3CatCode = L3CategoryViewModel.L2CatCode + ITC2;

            L3Category L3Category = new L3Category()
            {
                L3CatName = L3CategoryViewModel.L3CatName,
                L2CatCode = L3CategoryViewModel.L2CatCode,
                L1LocCode = L3CategoryViewModel.L1LocCode,
                ITC2 = (ITC2).ToString(),
                L3CatCode = L3CatCode
            };
                L3CategoryRepository.Add(L3Category);
                unityOfWork.Commit();

            User_Activity Activity = new User_Activity()
            {
                UserID = L3CategoryViewModel.UserID,
                Activity = "Asset Description Addition",
                ActivityTime = DateTime.Now
            };
            ActivityLogRepository.Add(Activity);
            unityOfWork.Commit();

            return "Asset description added "+L3Category.L3CatName;
        }

        public string IsL3CategoryExist(L3CategoryViewModel L3CategoryViewModel)
        {
            var L3CategoryName = (from L3C in unityOfWork.db.L3Category where L3C.L3CatName == L3CategoryViewModel.L3CatName && L3C.L1LocCode == L3CategoryViewModel.L1LocCode select L3C).ToList();

            if (L3CategoryName.Count != 0)
            {
                return "Asset Description Exist";
            }
            else
            {
                return "Asset Description Does Not Exist";
            }
        }
    }
}
