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
    public class LocationController : Controller
    {

        private ILocationService locationService;
        public LocationController()
            : this(new LocationService())
        {

        }
        public LocationController(ILocationService locationService)
        {
            this.locationService = locationService;
        }
        public ActionResult Section()
        {

            if (Session["UserName"] != null)
            {
                ViewBag.L1LocCode = Session["L1LocCode"];
                ViewBag.L1LocName = Session["L1LocName"];
                return View(ViewBag);
            }
            else
            {
                return RedirectToAction("Index", "Login/Index");
            }

        
        }
        public ActionResult RoomNumber()
        {

            if (Session["UserName"] != null)
            {
                ViewBag.L1LocCode = Session["L1LocCode"];
                ViewBag.L1LocName = Session["L1LocName"];
                return View(ViewBag);
            }
            else
            {
                return RedirectToAction("Index", "Login/Index");
            }

        }
        public ActionResult Index(LocationViewModel locationViewModel)
        {
            if (Session["UserName"] != null)
            {
                if ((string)Session["Role"] == "ADMIN" || (string)Session["Role"] == "UADMIN")
                {
                    CommonViewModel all = new CommonViewModel();
                    CompanyViewModel company = new CompanyViewModel();
                    all.CompanyList = locationService.GetAllCompany().ToList();
                    ViewBag.Location = all.LocationList;
                    ViewBag.Company = all.CompanyList;
                    ViewBag.Company1 = company;
                    return View(ViewBag);
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
        public ActionResult CreateLocation(LocationViewModel collection)
        {
            if (ModelState.IsValid)
            {
                locationService.CreateLocation(collection);
                return RedirectToAction("Index", "Company/Index");
            }
            else
            {
                CommonViewModel all = new CommonViewModel();
                //companyViewModel.CompanyID = CompanyID;
                all.CompanyList = locationService.GetAllCompany().ToList();
                LocationViewModel location = new LocationViewModel();
                CompanyViewModel Company1 = new CompanyViewModel();
                ViewBag.Company = all.CompanyList;
                ViewBag.Location = all.LocationList;
                LocationViewModel Location1 = new LocationViewModel();
                ViewBag.Company1 = Company1;
                return View("LocationPartial", Location1);
            }
        }


    }
}
