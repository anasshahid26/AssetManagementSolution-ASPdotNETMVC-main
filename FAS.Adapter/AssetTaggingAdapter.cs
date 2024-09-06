using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Infrastructure.Repository;
using FAS.Infrastructure.Common;
using FAS.SharedModel;
using FAS.Adapter;
using FAS.Data;
using System.Text.RegularExpressions;
using System.IO;
//using Excel = Microsoft.Office.Interop.Excel;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace FAS.Adapter
{
   public  class AssetTaggingAdapter
    {
        private IAssetTaggingRepository assettaggingRepository;
        private IAssetRepository assetRepository;
        private IL1CategoryRepository groupRepository;
        private IL2LocationRepository sectionRepository;
        private IL2CategoryRepository categoryRepository;
        private IL3CategoryRepository L3CategoryRepository;
        private IL4CategoryRepository L4CategoryRepository;
        private IL3LocationRepository L3LocationRepository;
        private IL4LocationRepository L4LocationRepository;
        private IL5LocationRepository L5LocationRepository;
        private ActivityLogRepository ActivityLogRepository;
        private IAssetReverificationRepository AssetReverificationRepository;
        private IReconciliationRepository ReconciliationRepository;
        private IReconciliationRecordRepository ReconciliationRecordRepository;
        private PurchaseAdapter PurchaseAdapter;
        private AssetPurchaseAdapter AssetPurchaseAdapter;
        private IUserRepository userRepository;
        private AssetDepreciationRepository assetDescriptionRepository;
        private IUnityOfWork unityOfWork;
        public string message;

       public AssetTaggingAdapter()
        {
            unityOfWork = new UnityOfWork(new DatabaseFactory());
            assetRepository = new AssetRepository(unityOfWork.instance);
            assettaggingRepository = new AssetTaggingRepository(unityOfWork.instance);

            groupRepository = new L1CategoryRepository(unityOfWork.instance);
            categoryRepository = new L2CategoryRepository(unityOfWork.instance);
            sectionRepository = new L2LocationRepository(unityOfWork.instance);
            L3CategoryRepository = new L3CategoryRepository(unityOfWork.instance);
            L4CategoryRepository = new L4CategoryRepository(unityOfWork.instance);
            userRepository = new UserRepository(unityOfWork.instance);
            L3LocationRepository = new L3LocationRepository(unityOfWork.instance);
            L4LocationRepository = new L4LocationRepository(unityOfWork.instance);
            L5LocationRepository = new L5LocationRepository(unityOfWork.instance);
            ActivityLogRepository = new ActivityLogRepository(unityOfWork.instance);
            PurchaseAdapter = new PurchaseAdapter();
            AssetReverificationRepository = new AssetReverificationRepository(unityOfWork.instance);
            AssetPurchaseAdapter = new AssetPurchaseAdapter();
            ReconciliationRecordRepository = new ReconciliationRecordRepository(unityOfWork.instance);
            ReconciliationRepository = new ReconciliationRepository(unityOfWork.instance);
            assetDescriptionRepository = new AssetDepreciationRepository(unityOfWork.instance);
        }

       public string AssetTagging(AssetAdditionViewModel assetAddition)
       {
           /* var L2Cat = categoryRepository.GetById(assetAddition.L2CatCode);
            var L3Cat = L3CategoryRepository.GetById(assetAddition.L3CatCode);
            var L3Loc = L3LocationRepository.GetById(assetAddition.L3LocCode);
            var L4Loc = L4LocationRepository.GetById(assetAddition.L4LocCode);
            var L5Loc = L5LocationRepository.GetById(assetAddition.L5LocCode);
            var ITC3 = assetAddition.L2LocCode.Substring(assetAddition.L2LocCode.Length - 2); ;
            var L4Cat = assetAddition.L3CatCode + ITC3;
            var isL4Isist = L4CategoryRepository.GetById(L4Cat); */

           string barcode = assetAddition.bcode;



           //   dynamic jsonObj = JsonConvert.DeserializeObject(barcode);
           //    int i=0;
           //  string a=jsonObj.barcode; 
           //  int i= jsonObj.base.Count;

           dynamic jObj = JsonConvert.DeserializeObject(barcode);

           foreach (var package in jObj)
           {
               string new_barcode = package.barcode;
               string assetnumber = package.AssetNumber;

               var asset = (from move in unityOfWork.db.AssetTaggings where move.AssetNumber == assetnumber select move).FirstOrDefault();
               if (asset != null)
               {
                   asset.AssetNumber = new_barcode;

                   assettaggingRepository.Update(asset);


                   // assettaggingRepository.Add(AssetBarcodeTest);
                   message = unityOfWork.Commit();
               }
               else
               {
                   message = "brcode:" + assetnumber + " not exist";
               }
           }




           //  string abc = yourOjbect["0"]["value"];
           //  string abc = yo;

           // JavaScriptSerializer ser = new JavaScriptSerializer();

           // var r = ser.Deserialize<PersonList>(barcode);
           /*  L4Category L4 = new L4Category()
             {
                 L1LocCode = assetAddition.L1LocCode,
                 ITC3 = ITC3,
                 L3CatCode = assetAddition.L3CatCode,
                 L4CatCode = L4Cat
              */

           /* if (isL4Isist == null)
            {
                L4CategoryRepository.Add(L4);
                unityOfWork.Commit();
            }

            string[] lines = Regex.Split(assetAddition.AssetNumber, "\r\n"); */
           /*  foreach (var item in barcode)
             {
                 if (item != "")
                 { */

           // }
           // }

           /*  if (lines.Count() > 1)
             {
                 User_Activity Activity = new User_Activity()
                 {
                     UserID = assetAddition.UserID,
                     Activity = "Bulk Asset Addition",
                     ActivityTime = DateTime.Now
                 };
                 ActivityLogRepository.Add(Activity);
                 unityOfWork.Commit();
             }
             else
             {
                 User_Activity Activity = new User_Activity()
                 {
                     UserID = assetAddition.UserID,
                     Activity = "Single Asset Addition",
                     ActivityTime = DateTime.Now
                 };
                 ActivityLogRepository.Add(Activity);
                 unityOfWork.Commit();
             } */




           return message;



       }

    }
}
