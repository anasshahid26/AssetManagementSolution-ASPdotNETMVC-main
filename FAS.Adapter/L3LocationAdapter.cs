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
    public class L3LocationAdapter
    {
        private IL3LocationRepository l3LocationRepository;
        private IUnityOfWork unityOfWork;

        public L3LocationAdapter()
        {
            unityOfWork = new UnityOfWork(new DatabaseFactory());
            l3LocationRepository = new L3LocationRepository(unityOfWork.instance);
        }

        public IEnumerable<L3LocationViewModel> GetL3Location(L3LocationViewModel collection)
        {
            //var getL2Location = l2LocationRepository.GetAll().ToList();
            List<L3LocationViewModel> result = new List<L3LocationViewModel>();
            if (collection.L2LocCode != null && collection.CODELEVEL == null)
            {
                if (collection.L2CatCode != null)
                {
                    var locations = (from location
                               in unityOfWork.db.Assets
                                     join locationInfo
                                     in unityOfWork.db.L3Location
                                     on location.L3LocCode equals locationInfo.L3LocCode
                                     join l2 in unityOfWork.db.L2Location on locationInfo.L2LocCode equals l2.L2LocCode
                                     where location.L2LocCode == collection.L2LocCode && location.L2CatCode == collection.L2CatCode && location.L1CatCode == collection.L1CatCode && location.L1LocCode == collection.L1LocCode
                                     select locationInfo).Distinct().ToList();
                    if (locations.Count > 0)
                    {
                        foreach (var item in locations)
                        {
                            result.Add(new L3LocationViewModel
                            {
                                L3LocCode = item.L3LocCode,
                                L3LocName = item.L3LocName
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
                    var locations = (from l3 in unityOfWork.db.L3Location
                                     join l2 in unityOfWork.db.L2Location on l3.L2LocCode equals l2.L2LocCode
                                     where l3.L2LocCode == collection.L2LocCode && l2.L1LocCode == collection.L1LocCode
                                     select l3).ToList();
                    if (locations.Count > 0)
                    {
                        foreach (var item in locations)
                        {
                            result.Add(new L3LocationViewModel
                            {
                                L3LocCode = item.L3LocCode,
                                L3LocName = item.L3LocName
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
                if(collection.CODELEVEL != null)
                    {
                    var L3Locations = (from l3Location in unityOfWork.db.L3Location
                                       join l4Location in unityOfWork.db.L4Location on l3Location.L3LocCode equals l4Location.L3LocCode
                                       join l5Location in unityOfWork.db.L5Location on l4Location.L4LocCode equals l5Location.L4LocCode
                                       where l5Location.L1LocCode == collection.L1LocCode && l5Location.CODELEVEL == collection.CODELEVEL && l3Location.L2LocCode == collection.L2LocCode select new L3LocationViewModel {
                                           L3LocCode = l3Location.L3LocCode,
                                           L3LocName = l3Location.L3LocName,
                                           ROOMTYPECODE = l4Location.ROOMTYPECODE
                                       }).Distinct();
                    return L3Locations;
                }
                else
                {
                    var getL3Location = l3LocationRepository.GetAll().Where(x => x.L2Location.L1LocCode == collection.L1LocCode).GroupBy(x => x.L3LocName).Select(x => x.First()).OrderBy(x => x.L3LocName).ToList();
                    foreach (var item in getL3Location)
                    {
                        result.Add(new L3LocationViewModel
                        {
                            L3LocCode = item.L3LocCode,
                            L3LocName = item.L3LocName
                        });
                    }
                    return result;
                }
            }
        }

        public string isL3LocationAvailable (AssetViewModel collection)
        {
            var L3Loc = (from assetReverification in unityOfWork.db.AssetReverifications where assetReverification.L1LocCode == collection.L1LocCode && assetReverification.RL3LocCode == collection.L3LocCode select assetReverification).ToList();
            if(L3Loc.Count != 0)
            {
                return "Room Reverified";
            }
            else
            {
                return "Room not Reverified";
            }
        }

        public string CreateL3Location(AssetViewModel collection)
        {
            L3Location L3Loc = new L3Location()
            {
                L1LocCode = collection.L1LocCode,
                L2LocCode = collection.L2LocCode,
                LOCCODEASSET = collection.LOCCODEASSET,
                L3LocCode = collection.L2LocCode + collection.LOCCODEASSET,
                L3LocName = collection.L3LocName
            };
            l3LocationRepository.Add(L3Loc);
            var message = unityOfWork.Commit();
            return message;
          
        }
    }
}
