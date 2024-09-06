using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Adapter;
using FAS.SharedModel;

namespace FAS.Services
{
    public class CompanyService : ICompanyService
    {
        CountryAdapter countryadapter;
        CompanyAdapter companyAdapter;

        public CompanyService()
        {
            countryadapter = new CountryAdapter();
            companyAdapter = new CompanyAdapter();
        }

        public IEnumerable<CountryViewModel> GetCountry()
        {
            return countryadapter.GetCountry();
        }

        public IEnumerable<CompanyViewModel> GetAllCompany()
        {
            return companyAdapter.GetCompanies();
        }

        public CompanyViewModel GetAllCompanyUser(UserViewModel userViewModel)
        {
            return companyAdapter.GetCompaniesUser(userViewModel);
        }

        public void CreateComapny(CompanyViewModel companyViewModel)
        {
            companyAdapter.CreateCompany(companyViewModel);
        }

        public string CompanyCodeExsist(CompanyViewModel companyViewModel)
        {
            return companyAdapter.IsCompanyCodeExsist(companyViewModel);
        }

        public void DeleteCompany(int CompanyID)
        {
            companyAdapter.DeleteCompany(CompanyID);
        }

        public CompanyViewModel EditCompany(int CompanyID)
        {
            return companyAdapter.EditCompany(CompanyID);
        }

        public void EditCompany(CompanyViewModel companyViewModel)
        {
            companyAdapter.EditCompany(companyViewModel);
        }
    }

    public interface ICompanyService
    {
        IEnumerable<CountryViewModel> GetCountry();

        IEnumerable<CompanyViewModel> GetAllCompany();

        void CreateComapny(CompanyViewModel companyViewModel);

        CompanyViewModel EditCompany(int CompanyID);

        void EditCompany(CompanyViewModel companyViewModel);

        void DeleteCompany(int CompanyID);

        string CompanyCodeExsist(CompanyViewModel companyViewModel);

        CompanyViewModel GetAllCompanyUser(UserViewModel userViewModel);
    }
}
