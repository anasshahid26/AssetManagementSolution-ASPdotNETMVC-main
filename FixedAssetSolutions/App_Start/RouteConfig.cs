using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FixedAssetSolutions
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "AddPurchaseDetail",
                url: "add-purchase-detail/{Collection}",
                defaults: new { controller = "AssetAddition", action = "AddPurchaseDetail", Collection = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "UpdatePurchaseDetail",
                url: "update-purchase-detail/{Collection}",
                defaults: new { controller = "AssetAddition", action = "UpdatePurchaseDetail", Collection = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EditPurchaseDetail",
                url: "edit-purchase-detail/",
                defaults: new { controller = "AssetAddition", action = "EditPurchaseDetail"}
            );

            routes.MapRoute(
                name: "AddL2Category",
                url: "add-L2Cat/{data}",
                defaults: new { controller = "AssetAddition", action = "AddL2Category", data = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "UpdateBarcode",
                url: "update-barcode",
                defaults: new {
                    controller = "AssetIndex",
                    action = "UpdateBarcode"
                }
            );

            routes.MapRoute(
                name: "UpdateBarcodeJSON",
                url: "update-barcode/{oldID}/{newID}",
                defaults: new { controller = "AssetIndex", action = "UpdateBarcode", oldID = UrlParameter.Optional, newID = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
