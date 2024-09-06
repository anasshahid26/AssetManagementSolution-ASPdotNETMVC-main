using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FAS.Services;
using FAS.SharedModel;
using FAS.Data;
using System.Web;

namespace FixedAssetSolutions.Controllers.API
{
    public class CompanyController : ApiController
    {
        private ICompanyService companyService;
        public CompanyController()
            : this(new CompanyService())
        {

        }

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [HttpGet]
        public ResponseObject Index(CompanyViewModel companyViewModel)
        {
            ResponseObject response = new ResponseObject();
            var company = companyService.GetAllCompany();
            response.Message = "All Companies";
            response.Data = company;
            return response;
        }

        [HttpPost]
        public ResponseObject GetCompaniesUser(UserViewModel userViewModel)
        {
            ResponseObject response = new ResponseObject();
            var company = companyService.GetAllCompanyUser(userViewModel);
            response.Message = "All Companies";
            response.Data = company;
            return response;
        }

        [HttpGet]
        public ResponseObject AllCountries()
        {
            ResponseObject response = new ResponseObject();
            var country = companyService.GetCountry();
            response.Message = "All Countries";
            response.Data = country;
            return response;
        }

        //[HttpPost]
        //public ResponseObject Delete(int id)
        //{
        //    ResponseObject response = new ResponseObject();
        //    companyService.DeleteCompany(id);
        //    response.Message = "Company Deleted " + id;
        //    return response;
        //}

        [HttpPost]
        public ResponseObject EditCompany(CompanyViewModel collection)
        {
            ResponseObject response = new ResponseObject();
            int id = collection.CompanyID;
            var company = companyService.EditCompany(id);
            response.Message = "Company Data";
            response.Data = company;
            return response;
        }

        [HttpPost]
        public ResponseObject UpdateCompany(CompanyViewModel collection)
        {
            ResponseObject response = new ResponseObject();
            companyService.EditCompany(collection);
            response.Message = "Company Updated";
            response.Data = null;
            return response;
        }

        [HttpPost]
        public ResponseObject CreateCompany(CompanyViewModel collection)
        {
            ResponseObject addCompany = new ResponseObject();
            companyService.CreateComapny(collection);
            addCompany.Message = "Company Added Successfully";
            return addCompany;
            //if (ModelState.IsValid)
            //{

            //    companyService.CreateComapny(collection);
            //    return RedirectToAction("Index", "Company/Index");
            //}
            //else
            //{
            //    CommonViewModel all = new CommonViewModel();
            //    //companyViewModel.CompanyID = CompanyID;
            //    all.CompanyList = companyService.GetAllCompany().ToList();
            //    all.LocationList = companyService.ReturnAllLocation().ToList();
            //    LocationViewModel location = new LocationViewModel();
            //    CompanyViewModel Company1 = new CompanyViewModel();
            //    ViewBag.Company = all.CompanyList;
            //    ViewBag.Location = all.LocationList;
            //    ViewBag.Company1 = Company1;
            //    return View("CompanyPartial", Company1);
            //}
        }

        [HttpPost]
        public ResponseObject DeleteCompany(CompanyViewModel collection)
        {
            ResponseObject response = new ResponseObject();
            int id = collection.CompanyID;
            companyService.DeleteCompany(id);
            response.Message = "Company Deleted";
            response.Data = id;
            return response;
        }

        [HttpPost]
        public ResponseObject IsCompanyCodeExsist(CompanyViewModel companyViewModel)
        {
            var CompanyCode = companyService.CompanyCodeExsist(companyViewModel);
            ResponseObject companyCodeExsist = new ResponseObject();
            companyCodeExsist.Message = CompanyCode;
            companyCodeExsist.Data = null;
            return companyCodeExsist;
        }
    }
}

