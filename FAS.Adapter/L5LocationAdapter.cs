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
    public class L5LocationAdapter
    {
        private IL5LocationRepository l5LocationRepository;
        private IUnityOfWork unityOfWork;

        public L5LocationAdapter()
        {
            unityOfWork = new UnityOfWork(new DatabaseFactory());
            l5LocationRepository = new L5LocationRepository(unityOfWork.instance);
        }

        public IEnumerable<L5LocationViewModel> GetL5Location(L5LocationViewModel collection)
        {
            List<L5LocationViewModel> result = new List<L5LocationViewModel>();
            if (collection.L4LocCode != null)
            {
                if (collection.L2CatCode != null)
                {
                    var locations = (from location in unityOfWork.db.Assets
                                     join locationInfo in unityOfWork.db.L5Location on location.L5LocCode
                                     equals locationInfo.L5LocCode
                                     where location.L4LocCode == collection.L4LocCode
                                    && location.L3LocCode == collection.L3LocCode
                                    && location.L2LocCode == collection.L2LocCode
                                    && location.L2CatCode == collection.L2CatCode
                                    && location.L1CatCode == collection.L1CatCode
                                     select locationInfo).Distinct().ToList();
                    if (locations.Count > 0)
                    {
                        foreach (var item in locations)
                        {
                            result.Add(new L5LocationViewModel
                            {
                                L5LocCode = item.L5LocCode,
                                L5LocName = item.CODELEVEL
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

                    var locations = (from l5 in unityOfWork.db.L5Location
                                     join l4 in unityOfWork.db.L4Location on l5.L4LocCode equals l4.L4LocCode
                                     where l5.L4LocCode == collection.L4LocCode
                                     select l5).ToList();
                    if (locations.Count > 0)
                    {
                        foreach (var item in locations)
                        {
                            result.Add(new L5LocationViewModel
                            {
                                L5LocCode = item.L5LocCode,
                                L5LocName = item.L5LocName
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
            else
            {
                if(collection.L2LocCode != null)
                {
                    var L5Locations = (from l5location in unityOfWork.db.L5Location
                                       join l4Location in unityOfWork.db.L4Location on l5location.L4LocCode equals l4Location.L4LocCode
                                       join l3Location in unityOfWork.db.L3Location on l4Location.L3LocCode equals l3Location.L3LocCode
                                       join l2Location in unityOfWork.db.L2Location on l3Location.L2LocCode equals l2Location.L2LocCode
                                       where l2Location.L2LocCode == collection.L2LocCode && l5location.L1LocCode == collection.L1LocCode
                                       select new L5LocationViewModel
                                       {
                                           CODELEVEL = l5location.CODELEVEL
                                       }).Distinct();
                    return L5Locations;

                }
                else
                {
                    var getL5Location = l5LocationRepository.GetAll().Where(x => x.L1LocCode == collection.L1LocCode).GroupBy(x => x.CODELEVEL).Select(x => x.First()).OrderBy(x => x.CODELEVEL).ToList();
                    foreach (var item in getL5Location)
                    {
                        result.Add(new L5LocationViewModel
                        {
                            L5LocCode = item.L5LocCode,
                            L5LocName = item.CODELEVEL
                        });
                    }
                    return result;
                }
            }
        }
    }
}
