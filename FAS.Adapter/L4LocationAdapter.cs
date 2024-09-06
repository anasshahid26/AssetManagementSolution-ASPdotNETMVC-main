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
    public class L4LocationAdapter
    {
        private IL4LocationRepository l4LocationRepository;
        private IUnityOfWork unityOfWork;

        public L4LocationAdapter()
        {
            unityOfWork = new UnityOfWork(new DatabaseFactory());
            l4LocationRepository = new L4LocationRepository(unityOfWork.instance);
        }

        public IEnumerable<L4LocationViewModel> GetL4Location(L4LocationViewModel collection)
        {
            //var getL2Location = l2LocationRepository.GetAll().ToList();
            List<L4LocationViewModel> result = new List<L4LocationViewModel>();
            if (collection.L3LocCode != null)
            {
                if (collection.L2CatCode != null)
                {
                    var locations = (from location
                           in unityOfWork.db.Assets
                                     join locationInfo
                                     in unityOfWork.db.L4Location
                                     on location.L4LocCode
                                     equals locationInfo.L4LocCode
                                     where location.L2LocCode == collection.L2LocCode
                                     && location.L3LocCode == collection.L3LocCode
                                     && location.L2CatCode == collection.L2CatCode
                                     && location.L1CatCode == collection.L1CatCode
                                     select locationInfo).Distinct().ToList();
                    if (locations.Count > 0)
                    {
                        foreach (var item in locations)
                        {
                            result.Add(new L4LocationViewModel
                            {
                                L4LocCode = item.L4LocCode,
                                L4LocName = item.L4LocName
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
                    //select * from dbo.L3Location l3 inner join L2Location l2 on l3.L2LocCode = l2.L2LocCode where l3.L2LocCode = 'RM' And l2.L1LocCode = 'PCCHE';
                    var locations = (from l4 in unityOfWork.db.L4Location
                                     join l3 in unityOfWork.db.L3Location on l4.L3LocCode equals l3.L3LocCode
                                     where l4.L3LocCode == collection.L3LocCode
                                     select l4).ToList();
                    if (locations.Count > 0)
                    {
                        foreach (var item in locations)
                        {
                            if (item.L4LocName == null)
                            {
                                result.Add(new L4LocationViewModel
                                {
                                    L4LocCode = item.L4LocCode,
                                    L4LocName = "NONE"
                                });
                            }
                            else
                            {
                                result.Add(new L4LocationViewModel
                                {
                                    L4LocCode = item.L4LocCode,
                                    L4LocName = item.L4LocName
                                });
                            }

                        }
                        return result;
                    }
                    else
                    {
                        return result;
                    }

                }
            }
            else
            {
                //var getL4Location = l4LocationRepository.GetAll().OrderBy(x=>x.L4LocName).ToList();
                //var getL4Location = (from L4Location in unityOfWork.db.L4Location where L4Location.L1LocCode == collection.L1LocCode select L4Location).GroupBy(x=>x.L4LocName).OrderBy(x => x.L4LocName).ToList();
                var getL4Location = l4LocationRepository.GetAll().Where(x => x.L3Location != null && x.L3Location.L2Location.L1LocCode == collection.L1LocCode).GroupBy(x => x.L4LocName).Select(x => x.FirstOrDefault());
                if (getL4Location != null)
                {
                    getL4Location = getL4Location.OrderBy(x => x.L4LocName).ToList();
                    foreach (var item in getL4Location)
                    {
                        result.Add(new L4LocationViewModel
                        {
                            L4LocCode = item.L4LocCode,
                            L4LocName = item.L4LocName
                        });
                    }
                }
                return result;
            }
        }


        public IEnumerable<L4LocationViewModel> L4LocationWithRespectToL2Location(L4LocationViewModel collection)
        {
            var L4Locations = (from l4location in unityOfWork.db.L4Location
                               join l3Location in unityOfWork.db.L3Location on l4location.L3LocCode equals l3Location.L3LocCode
                               join l2Location in unityOfWork.db.L2Location on l3Location.L2LocCode equals l2Location.L2LocCode
                               where l2Location.L2LocCode == collection.L2LocCode select new L4LocationViewModel {
                                   L4LocCode = l4location.L4LocCode,
                                   L4LocName = l4location.L4LocName
                               });
            return L4Locations;
        }

    }
}
