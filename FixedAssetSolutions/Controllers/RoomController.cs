using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FixedAssetSolutions.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room
        public ActionResult Room1()
        {
            return View();
        }

        // GET: Room
        public ActionResult Room2()
        {
            return View();
        }

        // GET: Room
        public ActionResult Room3()
        {
            return View();
        }
        public ActionResult RoomType()
        {
            return View();
        }
        public ActionResult RoomNumberByRoomType()
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