using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Infrastructure.Repository;
using FAS.Infrastructure.Common;
using FAS.Data;
using FAS.SharedModel;

namespace FAS.Adapter
{
    public class LocationAdapter
    {
        private IUnityOfWork unitOfWork;
        private ILocationRepository locationRepositroy;

        public LocationAdapter()
        {
            unitOfWork = new UnityOfWork(new DatabaseFactory());
            locationRepositroy = new LocationRepository(unitOfWork.instance);
        }

        public void CreateLocation(LocationViewModel LocationViewModel)
        {
            AssetLocation Location = new AssetLocation()
            {
                CompanyID = LocationViewModel.CompanyID,
                L1LocCode = LocationViewModel.L1LocCode,
                L1LocName = LocationViewModel.L1LocName,
                Address = LocationViewModel.Address,
                Country = LocationViewModel.Country,
                ContactEmail = LocationViewModel.ContactEmail,
                City = LocationViewModel.City,
                CountryID = LocationViewModel.CountryID,
                Active = LocationViewModel.Active,
                CreatedOn = LocationViewModel.CreatedOn,
                CreatedBy = LocationViewModel.CreatedBy
            };
            locationRepositroy.Add(Location);
            unitOfWork.Commit();
            //select * from dbo.Users u inner join dbo.UserRoles ur on u.UserID = ur.UserID inner join dbo.UserCompany uc on u.UserID = uc.UserID where ur.RoleID =4 AND uc.CompanyID =5;
            
        }

        public IEnumerable<LocationViewModel> ReturnLocationUser(UserViewModel user)
        {
            var getLocation = (from loc in unitOfWork.db.AssetLocations join userCompany in unitOfWork.db.UserCompanies on loc.L1LocCode equals userCompany.L1LocCode where userCompany.UserID == user.UserID select loc).ToList();
            List<LocationViewModel> locations = new List<LocationViewModel>();
            foreach (var item in getLocation)
            {
                locations.Add(new LocationViewModel
                {
                    L1LocCode = item.L1LocCode,
                    L1LocName = item.L1LocName,
                    Active = item.Active
                });
            }
            return locations;
        }

        public IEnumerable<LocationViewModel> ReturnLocationAdmin()
        {
            var getLocation = locationRepositroy.GetAll().ToList();
            List<LocationViewModel> locations = new List<LocationViewModel>();
            foreach (var item in getLocation)
            {
                locations.Add(new LocationViewModel
                {
                    L1LocCode = item.L1LocCode,
                    L1LocName = item.L1LocName
                });
            }
            return locations;
        }

        public IEnumerable<LocationViewModel> ReturnAssetsByLocationId()
        {
            var getLocation = locationRepositroy.GetAll().ToList();
            List<LocationViewModel> locations = new List<LocationViewModel>();
            foreach (var item in getLocation)
            {
                locations.Add(new LocationViewModel
                {
                    L1LocCode = item.L1LocCode,
                    L1LocName = item.L1LocName
                });
            }
            return locations;
        }

        public IEnumerable<LocationViewModel> ReturnAllLocation(LocationViewModel locationViewModel)
        {
            if (locationViewModel == null)
            {
                List<LocationViewModel> None = new List<LocationViewModel>();
                return None;
            }
            else
            {

                var getLocation = (from location in unitOfWork.db.AssetLocations
                                   where location.CompanyID == locationViewModel.CompanyID
                                   select location).ToList();

                List<LocationViewModel> result = new List<LocationViewModel>();

                foreach (var item in getLocation)
                {
                    result.Add(new LocationViewModel
                    {

                        L1LocCode = item.L1LocCode,
                        L1LocName = item.L1LocName,
                        Active = item.Active,
                        Address = item.Address,
                        City = item.City,
                        CountryID = item.CountryID,
                        Country = item.Country
                    });
                }
                return result;
            }
        }

        public string IsLocationCodeExsist(LocationViewModel locationViewModel)
        {
            var getLocationCode = (from location in unitOfWork.db.AssetLocations
                                   where location.L1LocCode == locationViewModel.L1LocCode
                                   select location.L1LocCode).ToList();

            if (getLocationCode.Count > 0)
            {
                return "Location code Exsist";
            }
            else
            {
                return "Location code does not Exsist";
            }
        }

        public LocationViewModel EditLocation(string L1LocCode)
        {
            var getlocation = locationRepositroy.GetById(L1LocCode);
            LocationViewModel location = new LocationViewModel();
            location.CompanyID = getlocation.CompanyID;
            location.L1LocCode = getlocation.L1LocCode;
            location.L1LocName = getlocation.L1LocName;
            location.Address = getlocation.Address;
            location.City = getlocation.City;
            location.CountryID = getlocation.CountryID;
            location.Active = getlocation.Active;

            return location;
        }

        public string EditLocation(LocationViewModel locationViewModel)
        {
            var L1LocCode = locationViewModel.L1LocCode;
            var getLocation = locationRepositroy.GetById(L1LocCode);
            getLocation.L1LocCode = L1LocCode;
            getLocation.L1LocName = locationViewModel.L1LocName;
            getLocation.Address = locationViewModel.Address;
            getLocation.City = locationViewModel.City;
            getLocation.Country = "Country";
            getLocation.CountryID = locationViewModel.CountryID;
            getLocation.ContactEmail = "Contact Email";
            getLocation.Active = locationViewModel.Active;
            locationRepositroy.Update(getLocation);
            unitOfWork.Commit();
            return "Updated Successfully";
        }


        public void DeleteLocation(string L1LocCode)
        {
            locationRepositroy.Delete(locationRepositroy.GetById(L1LocCode));
            unitOfWork.Commit();
        }
    }
}
