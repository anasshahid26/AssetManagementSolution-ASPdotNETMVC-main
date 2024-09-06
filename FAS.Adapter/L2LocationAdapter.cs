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
    public class L2LocationAdapter
    {
        private IL2LocationRepository l2LocationRepository;
        private IUnityOfWork unityOfWork;

        public L2LocationAdapter()
        {
            unityOfWork = new UnityOfWork(new DatabaseFactory());
            l2LocationRepository = new L2LocationRepository(unityOfWork.instance);
        }

        public IEnumerable<L2LocationViewModel> GetL2Location(AssetViewModel collection)
        {
            //var getL2Location = l2LocationRepository.GetAll().ToList();
            List<L2LocationViewModel> result = new List<L2LocationViewModel>();
            if (collection.L2CatCode != null)
            {
                var locations = (from location
                           in unityOfWork.db.Assets
                                 join locationInfo
                                 in unityOfWork.db.L2Location
                                 on location.L2LocCode
                                 equals locationInfo.L2LocCode
                                 where location.L2CatCode == collection.L2CatCode && location.L1CatCode == collection.L1CatCode
                                 select locationInfo).Distinct().ToList();
                if (locations.Count > 0)
                {
                    foreach (var item in locations)
                    {
                        result.Add(new L2LocationViewModel
                        {
                            L2LocCode = item.L2LocCode,
                            L2LocName = item.L2LocName
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
                var getL2Location = l2LocationRepository.GetAll().Where(x => x.L1LocCode == collection.L1LocCode).OrderBy(x=>x.L2LocName).ToList();
                foreach (var item in getL2Location)
                {
                    result.Add(new L2LocationViewModel
                    {
                        L2LocCode = item.L2LocCode,
                        L2LocName = item.L2LocName
                    });
                }
                return result;
            }
        }

        public string CreateL2Location(AssetViewModel collection)
        {
            L2Location L2Loccation = new L2Location()
            {
                L1LocCode = collection.L1LocCode,
                L2LocCode = collection.L2LocCode,
                L2LocName = collection.L2LocName,
            };
            l2LocationRepository.Add(L2Loccation);
            var message = unityOfWork.Commit();
            return message;
        }

        public string isL2LocationAvailable(AssetViewModel collection)
        {
            var L2Loc = (from l2location in unityOfWork.db.L2Location where l2location.L1LocCode == collection.L1LocCode && l2location.L2LocCode == collection.L2LocCode select l2location).ToList();
            if (L2Loc.Count != 0)
            {
                return "Section Code Already Exist !";
            }
            else
            {
                return "Section Code Dosent Exist !";
            }
        }
    }

}
