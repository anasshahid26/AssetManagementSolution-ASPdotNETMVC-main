using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using FAS.SharedModel;
using FAS.Services;
using System.Threading.Tasks;
using System.Collections;

namespace FixedAssetSolutions.Controllers
{
    public class HomeController : Controller
    {
        private IUserService userServices;
        public HomeController()
            : this(new UserService())
        {

        }
        public HomeController(IUserService userService)
        {
            this.userServices = userService;
        }
        public ActionResult Index()
        {
            if (HttpContext.Session["UserName"] != null)
            {
                ClearCacheItems();
                //if ((string)Session["Role"] == "USER" && (string)Session["Role"] == "ADMIN")
                //{
                ViewBag.CompanyID = HttpContext.Session["CompanyID"];
                return View(ViewBag);
                //}
                //else
                //{
                //    return RedirectToAction("Unauthorized", "Home/Unauthorize");
                //}
            }
            else
            {
                return RedirectToAction("Index", "Login/Index");
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public async Task<ActionResult> Help(QueryViewModel collection)
        {
            if (collection.EmailAddress != null)
            {
                var body = "<p>Email From: {0}</p><p>Message:</p><br><br><p><label>Email Address:</label> {1}<br><br><label>Name:</label> {2}<br><br><label>Location:</label>{3}<br><br><label>Subject:</label>{4}<br><br><label>Query:</label>{5}</p>";
                var message = new MailMessage();
                //message.To.Add(new MailAddress("support.fas@matrix-ams.com"));
                message.To.Add(new MailAddress("support.fas@matrix-ams.com"));
                message.From = new MailAddress("support.fas@matrix-ams.com");
                message.Subject = collection.Subject;
                message.Body = string.Format(body, collection.EmailAddress, collection.EmailAddress, collection.Name, collection.LocationName, collection.Subject, collection.Queries);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "support.fas@matrix-ams.com",
                        Password = "Matass#5279"
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.1and1.com";
                    smtp.Port = 587;

                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Index", "Home/Index");
                }
            }
            return View(collection);
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        public async Task<ActionResult> ForgotPassword(LoginViewModel loginViewModel)
        {
            if (loginViewModel.Email != null)
            {
                UserViewModel userViewModel = new UserViewModel();
                userViewModel.Email = loginViewModel.Email;
                var user = userServices.ForgetPassword(userViewModel);
                if (user.UserName != null)
                {
                    var body = "<p>Email From: {0}</p><p>Message:</p><p>You recently requested a forget password request<br> To log on the Matrix FAS application, use the following credentials<br><br><label>Username:</label> {1}<br> <label>Password:</label>{2}</p>";
                    var message = new MailMessage();
                    message.To.Add(new MailAddress(user.Email));
                    //message.To.Add(new MailAddress("zain.k@matrix-ams.com")); 
                    message.From = new MailAddress("support.fas@matrix-ams.com");  
                    message.Subject = "Forget Password Request";
                    message.Body = string.Format(body, "Matrix FAS", user.UserName, user.Password);
                    message.IsBodyHtml = true;

                    using (var smtp = new SmtpClient("smtp.1and1.com", 587))
                    {
                        var credential = new NetworkCredential
                        {
                            UserName = "support.fas@matrix-ams.com",
                            Password = "Matass#5279"//Matass#5279
                        };
                        smtp.Credentials = credential;
                        //smtp.Host = "smtp.1and1.com";
                        //smtp.Port = 587;

                        //await smtp.SendMailAsync(message);

                        try
                        {
                            smtp.Send(message);
                        }
                        catch (Exception e) { }

                        return RedirectToAction("Index", "Login/Index");
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Login/Index");
                }
            }
            return View(loginViewModel);
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Unauthorize()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public void ClearCacheItems()
        {
            var enumerator = HttpRuntime.Cache.GetEnumerator();
            Dictionary<string, object> cacheItems = new Dictionary<string, object>();

            while (enumerator.MoveNext())
                cacheItems.Add(enumerator.Key.ToString(), enumerator.Value);

            foreach (string key in cacheItems.Keys)
                HttpRuntime.Cache.Remove(key);
        } 
    }
}