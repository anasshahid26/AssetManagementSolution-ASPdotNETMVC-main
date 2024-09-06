using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FixedAssetSolutions.Controllers
{
    public class AssetReverificationController : Controller
    {
        // GET: AssetReverification
        public ActionResult Index()
        {
            return View();
        }

        // GET: AssetReverification
        public ActionResult Dash()
        {
            return View();
        }

        // GET: GatePass

        public ActionResult ManualReverification(string user_id, string role, string tagslist = null)
        {

            if (user_id != null)
            {
                if (tagslist != null)
                {
                    tagslist = tagslist.Replace('|', '\n');
                }
                ViewBag.tagslist = tagslist;
                ViewBag.user_id = user_id;
                ViewBag.role = role.ToUpper();

                return View(ViewBag);
            }
            else
            {
                //if (HttpContext.Session["UserID"].ToString() == "83")
                //{
                if (tagslist != null)
                {
                    tagslist = tagslist.Replace('|', '\n');
                }
                ViewBag.tagslist = "";
                ViewBag.user_id = HttpContext.Session["UserID"];
                ViewBag.role = "ADMIN";

                return View(ViewBag);
                //}
                //else
                //{
                //    return RedirectToAction("Index", "Login/Index");
                //}
            }
        }

        public ActionResult AssetReVerificationHHD(string user_id, string role, string tagslist = null)
        {

            if (user_id != null)
            {
                if (tagslist != null)
                {
                    tagslist = tagslist.Replace('|', '\n');
                }
                ViewBag.tagslist = tagslist;
                ViewBag.user_id = user_id;
                ViewBag.role = role;

                return View(ViewBag);
            }
            else
            {
                return RedirectToAction("Index", "Login/Index");
            }
        }

        public ActionResult NewAssetReverification()
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

        public ActionResult CloseReverification()
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

    }
}