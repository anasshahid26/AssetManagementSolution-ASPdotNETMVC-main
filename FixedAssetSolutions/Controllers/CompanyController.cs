using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FAS.Services;
using FAS.SharedModel;
using FAS.Data;

namespace FixedAssetSolutions.Controllers
{
    public class CompanyController : Controller
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

        public ActionResult Index(CompanyViewModel companyViewModel)
        {
            if (Session["UserName"] != null)
            {
                if ((string)Session["Role"] == "ADMIN")
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Unauthorized", "Home/Unauthorize");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login/Index");
            }
        }

        [HttpPost]
        public ActionResult CreateCompany(CompanyViewModel collection, HttpPostedFileBase file)
        {

            if (ModelState.IsValid)
            {

                companyService.CreateComapny(collection);
                return RedirectToAction("Index", "Company/Index");
            }
            else
            {
                CommonViewModel all = new CommonViewModel();
                //companyViewModel.CompanyID = CompanyID;
                all.CompanyList = companyService.GetAllCompany().ToList();
                LocationViewModel location = new LocationViewModel();
                CompanyViewModel Company1 = new CompanyViewModel();
                ViewBag.Company = all.CompanyList;
                ViewBag.Location = all.LocationList;
                ViewBag.Company1 = Company1;
                return View("CompanyPartial", Company1);
            }
        }
    }
}