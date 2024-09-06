using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Adapter;
using FAS.SharedModel;
using FAS.Data;

namespace FAS.Services
{
    public class LocationService : ILocationService
    {
        LocationAdapter locationAdapter;
        CompanyAdapter companyAdapter;
        CountryAdapter countryAdapter;
        L2LocationAdapter l2locationAdapter;

        public LocationService()
        {
            locationAdapter = new LocationAdapter();
            companyAdapter = new CompanyAdapter();
            countryAdapter = new CountryAdapter();
            l2locationAdapter = new L2LocationAdapter();
        }

        public IEnumerable<LocationViewModel> ReturnAllLocation(LocationViewModel locationViewModel)
        {
            return locationAdapter.ReturnAllLocation(locationViewModel);
        }

        public void CreateLocation(LocationViewModel locationViewModel)
        {
            locationAdapter.CreateLocation(locationViewModel);
        }

        public IEnumerable<CompanyViewModel> GetAllCompany()
        {
            return companyAdapter.GetCompanies();
        }

        public Country Country(int CountryID)
        {
            return countryAdapter.Country(CountryID);
        }

        public void DeleteLocation(string L1LocCode)
        {
            locationAdapter.DeleteLocation(L1LocCode);
        }

        public string LocationCodeExsist(LocationViewModel locationViewModel)
        {
            return locationAdapter.IsLocationCodeExsist(locationViewModel);
        }

        public LocationViewModel EditLocation(string L1LocCode)
        {
            return locationAdapter.EditLocation(L1LocCode);
        }

        public string UpdateLocation(LocationViewModel locationViewModel)
        {
            return locationAdapter.EditLocation(locationViewModel);
        }

        public IEnumerable<LocationViewModel>ReturnAllLocationUser(UserViewModel userViewModel)
        {
            return locationAdapter.ReturnLocationUser(userViewModel);
        }

        public string isL2LocationAvailable(AssetViewModel collection)
        {
            return l2locationAdapter.isL2LocationAvailable(collection);
        }
    }

    public interface ILocationService
    {
        IEnumerable<LocationViewModel> ReturnAllLocation(LocationViewModel locationViewModel);

        void CreateLocation(LocationViewModel locationViewModel);

        IEnumerable<CompanyViewModel> GetAllCompany();

        void DeleteLocation(string L1LocCode);

        Country Country(int CountryID);

        string LocationCodeExsist(LocationViewModel locationViewModel);

        LocationViewModel EditLocation(string L1LocCode);

        string UpdateLocation(LocationViewModel locationViewModel);

        IEnumerable<LocationViewModel>ReturnAllLocationUser(UserViewModel userViewModel);

        string isL2LocationAvailable(AssetViewModel collection);

    }
}
