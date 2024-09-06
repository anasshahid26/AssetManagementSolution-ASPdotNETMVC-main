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
    public class CountryAdapter
    {
        private ICountriesRepository countryRepository;
        private IUnityOfWork unitOfWork;

        public CountryAdapter()
        {
            unitOfWork = new UnityOfWork(new DatabaseFactory());
            countryRepository = new CountriesRepository(unitOfWork.instance);

        }

        public IEnumerable<CountryViewModel> GetCountry()
        {
            var getCountry = countryRepository.GetAll().ToList();
            List<CountryViewModel> result = new List<CountryViewModel>();

            foreach (var item in getCountry)
            {
                result.Add(new CountryViewModel
                {

                    CountryID = item.CountryID,
                    Name = item.Name
                });
            }
            return result;
        }

        public Country Country(int CountryID)
        {
            var getCountryName = countryRepository.GetById(CountryID);
            return getCountryName;
        }
    }
}
