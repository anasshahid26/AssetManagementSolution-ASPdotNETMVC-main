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
    public class CompanyAdapter
    {
        private ICompanyRepository companyRepository;
        private IUnityOfWork unityOfWork;

        public CompanyAdapter()
        {
            unityOfWork = new UnityOfWork(new DatabaseFactory());
            companyRepository = new CompanyRepository(unityOfWork.instance);
        }

        public void CreateCompany(CompanyViewModel CompanyViewModel)
        {
            AssetCompany Company = new AssetCompany()
            {
                CompanyID = CompanyViewModel.CompanyID,
                CompanyCode = CompanyViewModel.CompanyCode,
                CompanyName = CompanyViewModel.CompanyName,
                MultipleDivision = CompanyViewModel.MultipleDivision,
                Address = CompanyViewModel.Address,
                Address2 = CompanyViewModel.Address2,
                Address3 = CompanyViewModel.Address2,
                City = CompanyViewModel.City,
                State_Province = CompanyViewModel.State_Province,
                Zip_PostalCode = CompanyViewModel.Zip_PostalCode,
                CountryID = CompanyViewModel.CountryID,
                ContactName = CompanyViewModel.ContactName,
                ContactPhone = CompanyViewModel.ContactPhone,
                ContactFax = CompanyViewModel.ContactFax,
                ContactEmail = CompanyViewModel.ContactEmail,
                Active = CompanyViewModel.Active,
                CreatedOn = CompanyViewModel.CreatedOn,
                CreatedBy = CompanyViewModel.CreatedBy
            };
            companyRepository.Add(Company);
            unityOfWork.Commit();
        }

        //public CompanyViewModel GetCompanies(CompanyViewModel companyViewModel)
        //{
        //    var result = (from company in unityOfWork.db.AssetCompanies
        //                  where company.CompanyID == companyViewModel.CompanyID
        //                  select company).ToList();

        //    if (result.Count > 0)
        //    {
        //        var model = result.FirstOrDefault();

        //        CompanyViewModel viewModel = new CompanyViewModel()
        //        {
        //            CompanyID = model.CompanyID,
        //            CompanyName = model.CompanyName,
        //        };

        //        return viewModel;
        //    }

        //    return new CompanyViewModel();

        //}

        public string IsCompanyCodeExsist(CompanyViewModel companyViewModel)
        {
            var getCompanyCode = (from company in unityOfWork.db.AssetCompanies
                                   where company.CompanyCode == companyViewModel.CompanyCode
                                   select company.CompanyCode).ToList();

            if (getCompanyCode.Count > 0)
            {
                return "Company code Exsist";
            }
            else
            {
                return "Company code does not Exsist";
            }
        }

        public CompanyViewModel GetCompaniesUser(UserViewModel userViewModel)
        {
            //select * from AssetCompanies ac inner join UserCompany uc on ac.CompanyID = uc.CompanyID where UserID =106;
            var getCompanies = (from ac in unityOfWork.db.AssetCompanies join uc in unityOfWork.db.UserCompanies on ac.CompanyID equals uc.CompanyID where uc.UserID == userViewModel.UserID select ac).FirstOrDefault();
            CompanyViewModel result = new CompanyViewModel();
            result.CompanyID = getCompanies.CompanyID;
            result.CompanyName = getCompanies.CompanyName;
            result.Active = getCompanies.Active;
            //List<CompanyViewModel> result = new List<CompanyViewModel>();
            //foreach (var item in getCompanies.FirstOrDefault())
            //{
            //    result.Add(new CompanyViewModel
            //    {

            //        CompanyID = item.CompanyID,
            //        CompanyName = item.CompanyName,
            //        CompanyCode = item.CompanyCode,
            //        MultipleDivision = item.MultipleDivision,
            //        Locations = item.AssetLocations.Count(),
            //        Active = item.Active
            //    });
            //}
            return result;
        }
        public IEnumerable<CompanyViewModel> GetCompanies()
        {
            var getCompany = companyRepository.GetAll().ToList();
            List<CompanyViewModel> result = new List<CompanyViewModel>();

            foreach (var item in getCompany)
            {
                result.Add(new CompanyViewModel
                {

                    CompanyID = item.CompanyID,
                    CompanyName = item.CompanyName,
                    CompanyCode = item.CompanyCode,
                    MultipleDivision = item.MultipleDivision,
                    Locations = item.AssetLocations.Count(),
                    Active = item.Active
                });
            }
            return result;
        }

        public CompanyViewModel EditCompany(int CompanyID)
        {
            var getcompany = companyRepository.GetById(CompanyID);
            CompanyViewModel company = new CompanyViewModel();
            company.CompanyID = getcompany.CompanyID;
            company.CompanyCode = getcompany.CompanyCode;
            company.CompanyName = getcompany.CompanyName;
            company.Address = getcompany.Address;
            company.Address2 = getcompany.Address2;
            company.Address3 = getcompany.Address3;
            company.City = getcompany.City;
            company.MultipleDivision = getcompany.MultipleDivision;
            company.State_Province = getcompany.State_Province;
            company.Zip_PostalCode = getcompany.Zip_PostalCode;
            company.CountryID = getcompany.CountryID;
            company.ContactName = getcompany.ContactName;
            company.ContactPhone = getcompany.ContactPhone;
            company.ContactFax = getcompany.ContactFax;
            company.ContactEmail = getcompany.ContactEmail;
            company.Active = getcompany.Active;

            return company;
        }

        public void EditCompany(CompanyViewModel companyViewModel)
        {
            var CompanyID = companyViewModel.CompanyID;
            var getCompany = companyRepository.GetById(CompanyID);
            getCompany.CompanyID = CompanyID;
            getCompany.CompanyCode = companyViewModel.CompanyCode;
            getCompany.CompanyName = companyViewModel.CompanyName;
            getCompany.Address = companyViewModel.Address;
            getCompany.Address2 = companyViewModel.Address2;
            getCompany.Address3 = companyViewModel.Address3;
            getCompany.City = companyViewModel.City;
            getCompany.MultipleDivision = companyViewModel.MultipleDivision;
            getCompany.State_Province = companyViewModel.State_Province;
            getCompany.Zip_PostalCode = companyViewModel.Zip_PostalCode;
            getCompany.CountryID = companyViewModel.CountryID;
            getCompany.ContactName = companyViewModel.ContactName;
            getCompany.ContactPhone = companyViewModel.ContactPhone;
            getCompany.ContactFax = companyViewModel.ContactFax;
            getCompany.ContactEmail = companyViewModel.ContactEmail;
            getCompany.Active = companyViewModel.Active;
            companyRepository.Update(getCompany);
            unityOfWork.Commit();
        }

        public void DeleteCompany(int CompanyID)
        {
            companyRepository.Delete(companyRepository.GetById(CompanyID));
            unityOfWork.Commit();
        }
    }
}
