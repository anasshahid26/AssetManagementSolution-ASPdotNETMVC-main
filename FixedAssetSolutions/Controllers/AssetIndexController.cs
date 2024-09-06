using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FixedAssetSolutions.Controllers
{
    public class AssetIndexController : Controller
    {
        public ActionResult Index()
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

        public ActionResult UpdateBarcode()
        {
            if (Session["UserName"] != null)
            {
                ViewBag.L1LocCode = Session["L1LocCode"];
                ViewBag.L1LocName = Session["L1LocName"];
            }
            else
            {
                return RedirectToAction("Index", "Login/Index");
            }
            return View(ViewBag);
        }

        [HttpPost]
        public JsonResult UpdateBarcode(string oldID, string newID)
        {
            JsonResult responseObject = new JsonResult();
            var result = FAS.Services.V2.AssetService.Instance.UpdateAsset(oldID, newID);
            responseObject.Data = result;
            return responseObject;
        }
    }
}