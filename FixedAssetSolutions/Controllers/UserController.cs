using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FAS.SharedModel;
using FAS.Services;

namespace FixedAssetSolutions.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService;
        public UserController()
            : this(new UserService())
        {

        }
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Index(CompanyViewModel companyViewModel)
        {
            if (Session["UserName"] != null)
            {
                if ((string)Session["Role"] == "ADMIN" || (string)Session["Role"] == "UADMIN")
                {
                    var CompanyID = Convert.ToInt16(Session["CompanyID"]);
                    //IEnumerable<UserViewModel> viewModel = userService.ReturnALLUsers(CompanyID);
                    UserViewModel userViewModel = new UserViewModel();
                    //ViewBag.User = viewModel;
                    //ViewBag.AddUser = userViewModel;
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
        public ActionResult CreateUser(UserViewModel collection)
        {
            collection.CompanyID = Convert.ToInt16(Session["CompanyID"]);
            userService.CreateUser(collection);
            return RedirectToAction("Index", "User/Index");
        }

        public ActionResult Delete(int UserID)
        {
            userService.DeleteUser(UserID);
            return RedirectToAction("Index");
        }
    }
}