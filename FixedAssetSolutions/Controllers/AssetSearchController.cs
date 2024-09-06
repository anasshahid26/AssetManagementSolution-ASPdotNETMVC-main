using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using FAS.SharedModel;
using System.Web.UI.WebControls;
using FAS.Services;

namespace FixedAssetSolutions.Controllers
{
    public class AssetSearchController : Controller
    {
        private IAssetService assetService;

        public AssetSearchController()
            : this(new AssetService())
        {

        }
        public AssetSearchController(IAssetService assetService)
        {
            this.assetService = assetService;
        }

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

        public void WriteTsv<T>(IEnumerable<T> data, TextWriter output)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            foreach (PropertyDescriptor prop in props)
            {
                output.Write(prop.DisplayName); // header
                output.Write("\t");
            }
            output.WriteLine();
            foreach (T item in data)
            {
                foreach (PropertyDescriptor prop in props)
                {
                    output.Write(prop.Converter.ConvertToString(
                         prop.GetValue(item)));
                    output.Write("\t");
                }
                output.WriteLine();
            }
        }
        public void ExportExcel(AssetViewModel assetViewModel)
        {
            IEnumerable<SearchViewModel> collection = assetService.GetAsset(assetViewModel);
            var grid = new GridView();
            grid.DataSource = from data in collection
                              select new ExportExcelFormatOne()
                              {
                                  BarcodeID = data.AssetNumber,
                                  AssetDescription = data.AssetDescription,
                                  Group = data.Group,
                                  Category = data.Category,
                                  Section = data.Section,
                                  Room_No = data.Room_No,
                                  Room_Type = data.Room_Type,
                                  Floor = data.Floor,
                                  DateofPurchase = data.DateOfPurchase,
                                  Status = data.Status
                              };

            grid.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-dispotation", "attachment; filename=Export.xlsx");
            Response.ContentType = "application/excel";

            StringWriter sw = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(sw);
            grid.RenderControl(htmlTextWriter);
            Response.Write(sw.ToString());
            Response.End();
        }
    }
}