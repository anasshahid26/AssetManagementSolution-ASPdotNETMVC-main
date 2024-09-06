using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FixedAssetSolutions.Controllers
{
    public class UserLogController : Controller
    {
        // GET: UserLog
        public ActionResult Index()
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
    }
}