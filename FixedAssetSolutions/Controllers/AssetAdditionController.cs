using FAS.Data;
using FAS.Services;
using FAS.SharedModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace FixedAssetSolutions.Controllers
{
    public class AssetAdditionController : Controller
    {


        //ASSET DETAIL ADDITION

        public ActionResult DetailAddition_AssetGroup()
        {
            return View();
        }
        public ActionResult DetailAddition_AssetCategory()
        {
            return View();
        }
        public ActionResult DetailAddition_AssetDescription_RoomsType()
        {
            return View();
        }
        public ActionResult DetailAddition_AssetDescription_Others()
        {
            return View();
        }


        public ActionResult Report()
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

      

        // GET: AssetAddition
        public ActionResult Single()
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

        // GET: AssetAddition
        public ActionResult Bulk()
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

        // GET: AssetAddition
      

        // GET: AssetAddition
        public ActionResult PurchaseDetail()
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

        [HttpPost]
        public ActionResult EditPurchaseDetail(string l1LocCode, string purchaseID, string assetNumber)
        {
            PurchaseViewModel model = new PurchaseViewModel();
            model = FAS.Services.V2.PurchaseServices.Instance.GetPurchaseDetailbyID(l1LocCode, purchaseID, assetNumber);
            return View("EditPurchaseDetail", model);
        }

        [HttpPost]
        public string AddPurchaseDetail (PurchaseViewModel Collection)
        {
            List<string> assetnumbers = Regex.Split(Collection.AssetNumber, "\n").ToList().Where(a => !string.IsNullOrEmpty(a)).ToList();
            return FAS.Services.V2.PurchaseServices.Instance.AddMultipleAssetsPurchaseDetail(Collection, assetnumbers);
        }

        [HttpPost]
        public string UpdatePurchaseDetail(PurchaseViewModel Collection)
        {
            return FAS.Services.V2.PurchaseServices.Instance.UpdatePurchaseDetailsByID(Collection);
        }

        [HttpPost]
        public JsonResult AddL2Category(L2CategoryViewModel data)
        {
            JsonResult responseObject = new JsonResult();
            responseObject.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            try
            {
                var result = FAS.Services.V2.AssetService.Instance.AddL2Category(data);
                responseObject.Data = result;
            }
            catch (Exception ex)
            {
                responseObject.Data = "Error";
            }
            return responseObject;
        }

        [HttpPost]
        public ActionResult UploadFiles()
        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];
                        string fname;

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }

                        // Get the complete folder path and store the file inside it.  
                        fname = Path.Combine(Server.MapPath("~/Content/img"), fname);
                        file.SaveAs(fname);
                    }
                    // Returns message that successfully uploaded  
                    return Json("File Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }

        [HttpPost]
        public JsonResult FileUpload(string filename)
        {
            var result = new JsonResult();
            try
            {
                if (!string.IsNullOrEmpty(filename))
                {
                    HttpFileCollectionBase files = Request.Files;
                    HttpPostedFileBase file = files[0];
                    if (file != null)
                    {
                        //string pic = System.IO.Path.GetFileName(file.FileName);
                        string path = System.IO.Path.Combine(
                                               Server.MapPath("~/Content/img"), filename + ".jpg");
                        // file is uploaded
                        try
                        {
                            System.IO.File.Delete(path);

                            file.SaveAs(path);
                            result.Data = "Success";

                            HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        }
                        catch (Exception ex)
                        {

                            result.Data = "failed to upload image. Try again.";
                        }

                        // save the image path path to the database or you can send image 
                        // directly to database
                        // in-case if you want to store byte[] ie. for DB
                        //using (MemoryStream ms = new MemoryStream())
                        //{
                        //    file.InputStream.CopyTo(ms);
                        //    byte[] array = ms.GetBuffer();
                        //}

                    }
                    // after successfully uploading redirect the user
                }
                else
                {
                    result.Data = "Select Asset Description to upload image.";
                }
            }
            catch (Exception e)
            {
                result.Data = "Fail";
            }
            return result;
        }

        [HttpPost]
        public JsonResult FileUploadWithDestination(string filename, string extendedDestinationURL)
        {
            var result = new JsonResult();
            try
            {
                if (!string.IsNullOrEmpty(filename))
                {
                    HttpFileCollectionBase files = Request.Files;
                    HttpPostedFileBase file = files[0];
                    if (file != null)
                    {
                        Guid id = new Guid();
                        //string pic = System.IO.Path.GetFileName(file.FileName);
                        string path = System.IO.Path.Combine(
                                               Server.MapPath("~/Content/img"), extendedDestinationURL, id + filename);
                        // file is uploaded
                        file.SaveAs(path);
                        result.Data = "/Content/img/" + extendedDestinationURL + "/" + id + filename;
                    }
                }
                else
                {
                    result.Data = "Add file name.";
                }
            }
            catch (Exception e)
            {
                result.Data = "Fail";
            }
            return result;
        }

    }
}