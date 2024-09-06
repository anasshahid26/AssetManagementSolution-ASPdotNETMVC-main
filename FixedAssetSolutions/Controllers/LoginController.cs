using FAS.Services;
using FAS.SharedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FixedAssetSolutions.Controllers
{
    public class LoginController : Controller
    {
        private ILoginService loginService;
        public LoginController()
            : this(new LoginService())
        {

        }

        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }


        public ActionResult Index()
        {
            if (Session["UserName"] == null)
            {
                int b = 0;
                bool a = false;
                while (a)
                {
                    b++;
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home/Index");
            }
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel loginViewModel)
        {
            if (Session["UserName"] == null)
            {
                if (ModelState.IsValid)
                {
                    LoginViewModel viewModel = loginService.Authenticate(loginViewModel);
                    if (viewModel.UserID == 0)
                    {
                        ModelState.AddModelError("", "Invalid username or password");
                        return View(viewModel);
                    }
                    else if (viewModel.Role == "USER" || viewModel.Role == "UADMIN")
                    {
                        if (viewModel.CompanyActive == true)
                        {
                            if (viewModel.LocationActive == true)
                            {
                                if (viewModel.Active == true)
                                {
                                    //Session["LoginSession"] = viewModel;
                                   HttpContext.Session["UserName"] = viewModel.UserName;
                                    Session["Role"] = viewModel.Role;
                                    Session["L1LocCode"] = viewModel.L1LocCode;
                                    Session["L1LocName"] = viewModel.L1LocName;
                                    Session["CompanyID"] = viewModel.CompanyID;
                                    Session["CompanyName"] = viewModel.CompanyName;
                                    HttpContext.Session["UserID"] = viewModel.UserID;
                                    return RedirectToAction("Index", "Home/Index");
                                }
                                else
                                {
                                    return RedirectToAction("Unauthorized", "Home/Unauthorize");
                                }
                            }
                            else
                            {
                                ModelState.AddModelError("", "Location not active please contact Administator");
                                return View(viewModel);
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Company not active please contact Administator");
                            return View(viewModel);
                        }
                    }
                    else
                    {
                        //Session["LoginSession"] = viewModel;
                        HttpContext.Session["UserName"] = viewModel.UserName;
                        HttpContext.Session["Role"] = viewModel.Role;
                        HttpContext.Session["UserID"] = viewModel.UserID;
                        if (viewModel.Role == "ADMIN")
                        {
                            return RedirectToAction("Index", "Home/Index");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home/Index");
                        }


                    }
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Index", "Login/Index");
            }
        }

        public ActionResult Logout()
        {
            LoginViewModel logout = new LoginViewModel();
            logout.UserID = Convert.ToInt16(Session["UserID"]);
            loginService.Logout(logout);
            HttpContext.Session["LoginSession"] = null;
            HttpContext.Session["UserName"] = null;
            HttpContext.Session["Role"] = null;
            HttpContext.Session["L1LocCode"] = null;
            HttpContext.Session["CompanyID"] = null;
            HttpContext.Session["UserID"] = null;
            return RedirectToAction("Index", "Login/Index");
        }

    }
}