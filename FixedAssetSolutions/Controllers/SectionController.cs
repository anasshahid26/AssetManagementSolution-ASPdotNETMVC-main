using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FixedAssetSolutions.Controllers
{
    public class SectionController : Controller
    {
        // GET: Section
        public ActionResult Index()
        {
            if (Session["UserName"] != null)
            {
                if ((string)Session["Role"] == "ADMIN" || (string)Session["Role"] == "UADMIN")
                {
                    return View();
                }
                else
                {

                    return View();
                    //return RedirectToAction("Unauthorized", "Home/Unauthorize");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login/Index");
            }
        }
    }
}