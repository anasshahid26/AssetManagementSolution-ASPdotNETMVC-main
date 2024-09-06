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
using System.Data;

namespace FAS.Adapter
{
   
    public class ObjectList
    {
        public string barcode { get; set; }

    }

    public class RootObj
    {
        public string objectType { get; set; }
        public List<ObjectList> objectList { get; set; }
    }
    public class AssetAdapter
    {
        clsAssetTagging objAssetTagging = new clsAssetTagging();
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
        public string message = "";

        public AssetAdapter()
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

        public DashboardSharedModel GetAssetDashboard(AssetViewModel assetViewModel)
        {
            var totalAssets = (from asset in unityOfWork.db.Assets where asset.L1LocCode == assetViewModel.L1LocCode && asset.Status == "ACTIVE" select asset).ToList();
            var totalAssetsCount = totalAssets.Count();
            var totalGroup = groupRepository.GetAll().Where(x => x.L1LocCode == assetViewModel.L1LocCode);
            var totalSection = sectionRepository.GetAll().Where(x => x.L1LocCode == assetViewModel.L1LocCode).GroupBy(x => x.L2LocName);
            var totalCategory = categoryRepository.GetAll().Where(x => x.L1LocCode == assetViewModel.L1LocCode).GroupBy(x => x.L2CatName);

            List<GroupSharedModel> group = new List<GroupSharedModel>();
            foreach (var item in totalGroup)
            {
                group.Add(new GroupSharedModel
                {
                    AssetGroupCount = totalAssets.Where(x => x.L1CatCode == item.L1CatCode).Count(),
                    GroupName = item.L1CatName
                });
            }

            List<CategorySharedModel> category = new List<CategorySharedModel>();
            foreach (var item in totalCategory)
            {
                category.Add(new CategorySharedModel
                {

                    CategoryCount = totalAssets.Where(x => x.L2Category.L2CatName == item.Key).Count(),
                    CategoryName = item.Key
                });
            }

            List<SectionSharedModel> section = new List<SectionSharedModel>();
            foreach (var item in totalSection)
            {
                section.Add(new SectionSharedModel
                {
                    SectionCount = totalAssets.Where(x => x.L2Location.L2LocName == item.Key).Count(),
                    SectionName = item.Key
                });
            }
            DashboardSharedModel dashboard = new DashboardSharedModel();
            dashboard.AssetCount = totalAssetsCount;
            dashboard.TotalGroup = group;
            dashboard.TotalSection = section;
            dashboard.TotalCategory = category;

            //Create COM Objects. Create a COM object for everything that is referenced
            //Excel.Application xlApp = new Excel.Application();
            //Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\Shahraiz\Desktop\Location Data\Data -- 2017\IDCC\NEWIMAGE.xlsx");
            //Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            //Excel.Range xlRange = xlWorksheet.UsedRange;

            //for (int i = 1; i <= 189; i++)
            //{
            //    for (int j = 1; j <= 2; j++)
            //    {
            //        //new line
            //        if (j == 1)
            //            Console.Write("\r\n");

            //        //write the value to the console
            //        if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
            //            string L3 = xlRange.Cells[i, j].Value2.ToString();

            //        //add useful things here!   
            //    }
            //}


            //DirectoryInfo d = new DirectoryInfo(@"C:\DirectoryToAccess");
            //DirectoryInfo p = new DirectoryInfo(@"C:\test");
            //FileInfo[] infos = d.GetFiles();
            //FileInfo[] ex = p.GetFiles();
            //int len = infos.Length;
            //string FilePath = @"D:\test.txt";
            //var text = new StringBuilder();
            //var file = new StreamWriter(File.Create(FilePath));
            //for (int i = 0; i < len; i++)
            //{
            //    char[] delimiterChars = { '.', '"' };
            //    string bcd = infos[i].Name;
            //    string[] barc = bcd.Split(delimiterChars);
            //    string finalbrc = barc[0];
            //    var asset = (from assets in unityOfWork.db.Assets where assets.AssetNumber == finalbrc && assets.L1LocCode == "HGMOE" select assets).ToList();

            //    //string img = Convert.ToString(i);
            //    if (asset.Count > 0)
            //    {
            //        if (!File.Exists(@"C:\test\" + asset.FirstOrDefault().L3CatCode + ".jpg"))
            //        {
            //            File.Move(infos[i].FullName, @"C:\test\" + asset.FirstOrDefault().L3CatCode + ".jpg");

            //            file.Write(asset.FirstOrDefault().L3CatCode);
            //        }
            //    }
            //}
            //file.Close();
            return dashboard;
        }

        public IEnumerable<SearchViewModel> GetAsset(AssetViewModel assetViewModel)
        {
            var query1 = (from asset in unityOfWork.db.Assets
                          join assetPurchase in unityOfWork.db.AssetPurchases on asset.UniqueID equals assetPurchase.UniqueID
                          join purchases in unityOfWork.db.PurchaseDetails on assetPurchase.PurchaseID equals purchases.PurchaseID
                          where asset.L1LocCode == assetViewModel.L1LocCode
                          select new SearchViewModel
                          {
                              AssetNumber = asset.AssetNumber,
                              AssetDescription = asset.AssetDescription,
                              Group = asset.L1Category.L1CatName,
                              Category = asset.L2Category.L2CatName,
                              Image = asset.L3CatCode,
                              Location = asset.AssetLocation.L1LocName,
                              Section = asset.L2Location.L2LocName,
                              Room_No = asset.L3Location.L3LocName,
                              Room_Type = asset.L4Location.L4LocName,
                              Floor = asset.L5Location.L5LocName,
                              BookValue = "Not Available",
                              Status = asset.Status,
                              Brand = asset.Brand,
                              SerialNumber = asset.SerialNumber,
                              Size = asset.Size,
                              Color = asset.Color,
                              DisposedOn = asset.DisposedOn,
                              VerificationStatus = asset.VerificationStatus,
                              DateOfVerification = asset.DateOfVerification,
                              Depreciated = asset.Depreciated,
                              NetbookValue = asset.NetBookValue,
                              ValueDate = "Not Available",
                              DateOfPurchase = purchases.DateofPurchase.Value,
                              UnitPrice = purchases.UnitPrice

                          }).ToList();

            if (query1.Count == 0)
            {
                query1 = (from asset in unityOfWork.db.Assets
                          where asset.L1LocCode == assetViewModel.L1LocCode
                          select new SearchViewModel
                          {
                              AssetNumber = asset.AssetNumber,
                              AssetDescription = asset.AssetDescription,
                              Group = asset.L1Category.L1CatName,
                              Category = asset.L2Category.L2CatName,
                              Image = asset.L3CatCode,
                              Location = asset.AssetLocation.L1LocName,
                              Section = asset.L2Location.L2LocName,
                              Room_No = asset.L3Location.L3LocName,
                              Room_Type = asset.L4Location.L4LocName,
                              Floor = asset.L5Location.L5LocName,
                              BookValue = "Not Available",
                              Status = asset.Status,
                              Brand = asset.Brand,
                              SerialNumber = asset.SerialNumber,
                              Size = asset.Size,
                              Color = asset.Color,
                              DisposedOn = asset.DisposedOn,
                              VerificationStatus = asset.VerificationStatus,
                              DateOfVerification = asset.DateOfVerification,
                              Depreciated = asset.Depreciated,
                              NetbookValue = asset.NetBookValue,
                              ValueDate = "Not Available",
                              UnitPrice = "NONE"

                          }).ToList();

                if (assetViewModel.VerificationStatus != null)
                {
                    query1 = query1.Where(x => x.VerificationStatus.Equals(assetViewModel.VerificationStatus)).ToList();
                }

                if (assetViewModel.DisposedOn != null)
                {
                    query1 = query1.Where(x => x.DisposedOn.Equals(assetViewModel.DisposedOn)).ToList();
                }

                if (assetViewModel.CreatedOn != null)
                {
                    query1 = query1.Where(x => x.CreatedOn.Equals(assetViewModel.CreatedOn)).ToList();
                }

                if (assetViewModel.Status != null && assetViewModel.Status != "ALL")
                {
                    query1 = query1.Where(x => x.Status.Contains(assetViewModel.Status)).ToList();
                }

                if (assetViewModel.AssetDescription != null && assetViewModel.AssetDescription != "Asset Description")
                {
                    query1 = query1.Where(x => x.AssetDescription.Contains(assetViewModel.AssetDescription)).ToList();
                }

                if (assetViewModel.L1CatName != "Asset Group" && assetViewModel.L1CatName != null)
                {
                    query1 = query1.Where(x => x.Group.Equals(assetViewModel.L1CatName)).ToList();
                }

                if (assetViewModel.L2CatName != "Asset Category" && assetViewModel.L2CatName != null)
                {
                    query1 = query1.Where(x => x.Category.Equals(assetViewModel.L2CatName)).ToList();
                }

                if (assetViewModel.L2LocName != "Asset Section" && assetViewModel.L2LocName != null)
                {
                    query1 = query1.Where(x => x.Section.Equals(assetViewModel.L2LocName)).ToList();
                }

                if (assetViewModel.L3LocName != "Asset Room No" && assetViewModel.L3LocName != null)
                {
                    query1 = query1.Where(x => x.Room_No.Equals(assetViewModel.L3LocName)).ToList();
                }

                if (assetViewModel.L4LocName != "Asset Room Type" && assetViewModel.L4LocName != null)
                {
                    query1 = query1.Where(x => x.Room_Type.Equals(assetViewModel.L4LocName)).ToList();
                }

                if (assetViewModel.CODELEVEL != "Asset Floor" && assetViewModel.CODELEVEL != null)
                {
                    query1 = query1.Where(x => x.Floor.Equals(assetViewModel.CODELEVEL)).ToList();
                }
            }
            else
            {
                if (assetViewModel.VerificationStatus != null)
                {
                    query1 = query1.Where(x => x.VerificationStatus.Equals(assetViewModel.VerificationStatus)).ToList();
                }

                if (assetViewModel.DisposedOn != null)
                {
                    query1 = query1.Where(x => x.DisposedOn.Equals(assetViewModel.DisposedOn)).ToList();
                }

                if (assetViewModel.CreatedOn != null)
                {
                    query1 = query1.Where(x => x.CreatedOn.Equals(assetViewModel.CreatedOn)).ToList();
                }

                if (assetViewModel.Status != null && assetViewModel.Status != "ALL")
                {
                    query1 = query1.Where(x => x.Status.Contains(assetViewModel.Status)).ToList();
                }

                if (assetViewModel.AssetDescription != null && assetViewModel.AssetDescription != "Asset Description")
                {
                    query1 = query1.Where(x => x.AssetDescription.Contains(assetViewModel.AssetDescription)).ToList();
                }

                if (assetViewModel.L1CatName != "Asset Group" && assetViewModel.L1CatName != null)
                {
                    query1 = query1.Where(x => x.Group.Equals(assetViewModel.L1CatName)).ToList();
                }

                if (assetViewModel.L2CatName != "Asset Category" && assetViewModel.L2CatName != null)
                {
                    query1 = query1.Where(x => x.Category.Equals(assetViewModel.L2CatName)).ToList();
                }

                if (assetViewModel.L2LocName != "Asset Section" && assetViewModel.L2LocName != null)
                {
                    query1 = query1.Where(x => x.Section.Equals(assetViewModel.L2LocName)).ToList();
                }

                if (assetViewModel.L3LocName != "Asset Room No" && assetViewModel.L3LocName != null)
                {
                    query1 = query1.Where(x => x.Room_No.Equals(assetViewModel.L3LocName)).ToList();
                }

                if (assetViewModel.L4LocName != "Asset Room Type" && assetViewModel.L4LocName != null)
                {
                    query1 = query1.Where(x => x.Room_Type.Equals(assetViewModel.L4LocName)).ToList();
                }

                if (assetViewModel.CODELEVEL != "Asset Floor" && assetViewModel.CODELEVEL != null)
                {
                    query1 = query1.Where(x => x.Floor.Equals(assetViewModel.CODELEVEL)).ToList();
                }
            }

            return query1;
        }

        public IEnumerable<SearchViewModel> GetAssetByBC(AssetViewModel assetViewModel)
        {
            List<SearchViewModel> result = new List<SearchViewModel>();
            var asset = (from assets in unityOfWork.db.Assets
                         join assetPurchase in unityOfWork.db.AssetPurchases on assets.UniqueID equals assetPurchase.UniqueID
                         join purchases in unityOfWork.db.PurchaseDetails on assetPurchase.PurchaseID equals purchases.PurchaseID
                         where assets.AssetNumber == assetViewModel.AssetNumber && assets.L1LocCode == assetViewModel.L1LocCode
                         select new SearchViewModel
                         {
                             UniqueID = assets.UniqueID,
                             AssetNumber = assets.AssetNumber,
                             AssetDescription = assets.AssetDescription,
                             Group = assets.L1Category.L1CatName,
                             Category = assets.L2Category.L2CatName,
                             Image = assets.L3CatCode,
                             Location = assets.AssetLocation.L1LocName,
                             Section = assets.L2Location.L2LocName,
                             Room_No = assets.L3Location.L3LocName,
                             Room_Type = assets.L4Location.L4LocName,
                             Floor = assets.L5Location.L5LocName,
                             BookValue = "Not Available",
                             Status = assets.Status,
                             NetbookValue = assets.NetBookValue,
                             Depreciated = assets.Depreciated,
                             UnitPrice = purchases.UnitPrice,
                             DateOfPurchase = purchases.DateofPurchase.Value
                         });
            if (asset.FirstOrDefault() == null)
            {
                asset = (from assets in unityOfWork.db.Assets
                         where assets.AssetNumber == assetViewModel.AssetNumber && assets.L1LocCode == assetViewModel.L1LocCode
                         select new SearchViewModel
                         {
                             UniqueID = assets.UniqueID,
                             AssetNumber = assets.AssetNumber,
                             AssetDescription = assets.AssetDescription,
                             Group = assets.L1Category.L1CatName,
                             Category = assets.L2Category.L2CatName,
                             Image = assets.L3CatCode,
                             Location = assets.AssetLocation.L1LocName,
                             Section = assets.L2Location.L2LocName,
                             Room_No = assets.L3Location.L3LocName,
                             Room_Type = assets.L4Location.L4LocName,
                             Floor = assets.L5Location.L5LocName,
                             BookValue = "Not Available",
                             Status = assets.Status,
                             Brand = assets.Brand,
                             SerialNumber = assets.SerialNumber,
                             Size = assets.Size,
                             Color = assets.Color,
                             DisposedOn = assets.DisposedOn,
                             VerificationStatus = assets.VerificationStatus,
                             DateOfVerification = assets.DateOfVerification,
                             Depreciated = assets.Depreciated,
                             NetbookValue = assets.NetBookValue,
                             ValueDate = "Not Available",
                             UnitPrice = "NONE"

                         });
            }
            return asset;
        }

        public IEnumerable<AssetViewModel> GetAssetByDscrption(AssetViewModel assetViewModel)
        {
            var asset = (from assets in unityOfWork.db.Assets
                         where assets.AssetDescription == assetViewModel.AssetDescription
                         select assets).ToList();

            List<AssetViewModel> result = new List<AssetViewModel>();

            if (asset.Count > 0)
            {
                foreach (var item in asset)
                {
                    result.Add(new AssetViewModel
                    {
                        AssetNumber = item.AssetNumber,
                        AssetDescription = item.AssetDescription,
                        L1CatCode = item.L1CatCode,
                        L1CatName = item.L1Category.L1CatName,
                        L2CatCode = item.L2CatCode,
                        L2CatName = item.L2Category.L2CatName,
                        L1LocCode = item.L1LocCode,
                        L1LocName = item.AssetLocation.L1LocName,
                        L2LocCode = item.L2LocCode,
                        L2LocName = item.L2Location.L2LocName,
                        L3LocCode = item.L3LocCode,
                        L3LocName = item.L3Location.L3LocName,
                        L4LocCode = item.L4LocCode,
                        L4LocName = item.L4Location.L4LocName,
                        L5LocCode = item.L5LocCode,
                        L5LocName = item.L5Location.L5LocName,
                        BookValue = "Not Available"

                    });
                }

                return result;
            }

            return result;
        }

        public string AssetMovement(AssetMovementViewModel assetMovement)
        {
            var user = userRepository.GetById(assetMovement.UserID);
            if (user.Password == assetMovement.Password)
            {
                string[] assets = Regex.Split(assetMovement.AssetNumber, ",");
                foreach (var item in assets)
                {
                    var asset = (from move in unityOfWork.db.Assets where move.L1LocCode == assetMovement.L1LocCode && move.AssetNumber == item select move).FirstOrDefault();
                    asset.L2LocCode = assetMovement.L2LocCode;
                    asset.L3LocCode = assetMovement.L3LocCode;
                    asset.L4LocCode = assetMovement.L4LocCode;
                    asset.L5LocCode = assetMovement.L5LocCode;
                    assetRepository.Update(asset);
                }

                unityOfWork.Commit();
                User_Activity activity = new User_Activity()
                {
                    UserID = assetMovement.UserID,
                    Activity = "single asset movement",
                    ActivityTime = DateTime.Now
                };
                ActivityLogRepository.Add(activity);
                unityOfWork.Commit();
                return "Asset Moved Succefully";
            }
            else
            {
                return "Incorrect Password";
            }

        }



        public IEnumerable<clsAssetTagging> GetAllAssetTaggingByLocationId(clsAssetTagging paramAssetTag)
        {

            List<clsAssetTagging> asset_tag_list = new List<clsAssetTagging>();



            objAssetTagging.location_code = paramAssetTag.location_code;

            objAssetTagging.section_code = paramAssetTag.section_code;

            objAssetTagging.room_code = paramAssetTag.room_code;



            DataTable dt = objAssetTagging.GetAllAssetTaggingByLocationId();

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow dr in dt.Rows)
                {

                    asset_tag_list.Add(new clsAssetTagging

                    {
                        TID =int.Parse(dr["TID"].ToString()),
                        AssetNumber = dr["AssetNumber"].ToString(),

                        AssetDescription = dr["AssetDescription"].ToString(),

                        location_code = dr["location_code"].ToString(),

                        section_code = dr["section_code"].ToString(),

                        room_code = dr["room_code"].ToString(),

                        room_type = dr["room_type"].ToString(),

                        floor_code = dr["floor_code"].ToString(),



                        category_code = dr["category_code"].ToString(),

                        group_code = dr["group_code"].ToString(),

                        L3CatCode = dr["L3CatCode"].ToString(),

                        L4CatCode = dr["L4CatCode"].ToString(),



                        location_name = dr["location_name"].ToString(),

                        section_name = dr["section_name"].ToString(),

                        Room_name = dr["Room_name"].ToString(),

                        Room_type_name = dr["Room_type_name"].ToString(),

                        floor_name = dr["floor_name"].ToString(),





                        Sequence = int.Parse(dr["Sequence"].ToString()),

                        ColorType = int.Parse(dr["ColorType"].ToString()),



                        //CreatedOn = Convert.ToDateTime((dr["CreatedOn"].ToString()))

                    });

                }

            }

            return asset_tag_list;



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
            string locationCode= assetAddition.L1LocCode;

      

         //   dynamic jsonObj = JsonConvert.DeserializeObject(barcode);
        //    int i=0;
          //  string a=jsonObj.barcode; 
          //  int i= jsonObj.base.Count;

            dynamic jObj = JsonConvert.DeserializeObject(barcode);

            foreach (var package in jObj)
                {
                    string new_barcode = package.barcode;
                    int TID = package.AssetNumber;

                    var asset = (from move in unityOfWork.db.AssetTaggings where move.TID == TID  select move).FirstOrDefault();

                    var assettag = (from move in unityOfWork.db.AssetTaggings where move.AssetNumber == new_barcode && move.location_code == locationCode select move).FirstOrDefault();

                    if (asset != null)
                    {
                        if (assettag != null && assettag.AssetNumber == new_barcode)
                        {
                            message += unityOfWork.Commit() + "barcode: " + new_barcode + "Already Exist! \n";
                        }
                        if(assettag == null) { 
                        asset.AssetNumber = new_barcode;

                        assettaggingRepository.Update(asset);


                        // assettaggingRepository.Add(AssetBarcodeTest);
                        message += unityOfWork.Commit() + "barcode: " + new_barcode + "Updated! \n";
                        }
                    }
                    else {
                        message += "brcode: " + new_barcode + "Not exist \n";
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
        public string AssetAddition(AssetAdditionViewModel assetAddition)
        {
            var L2Cat = categoryRepository.GetById(assetAddition.L2CatCode);
            var L3Cat = L3CategoryRepository.GetById(assetAddition.L3CatCode);
            var L3Loc = L3LocationRepository.GetById(assetAddition.L3LocCode);
            var L4Loc = L4LocationRepository.GetById(assetAddition.L4LocCode);
            var L5Loc = L5LocationRepository.GetById(assetAddition.L5LocCode);
            var ITC3 = assetAddition.L2LocCode.Substring(assetAddition.L2LocCode.Length - 2); ;
            var L4Cat = assetAddition.L3CatCode + ITC3;
            var isL4Isist = L4CategoryRepository.GetById(L4Cat);

            L4Category L4 = new L4Category()
            {
                L1LocCode = assetAddition.L1LocCode,
                ITC3 = ITC3,
                L3CatCode = assetAddition.L3CatCode,
                L4CatCode = L4Cat
            };

            if (isL4Isist == null)
            {
                L4CategoryRepository.Add(L4);
                unityOfWork.Commit();
            }

            string[] lines = Regex.Split(assetAddition.AssetNumber, "\r\n");
            foreach (var item in lines)
            {
                if (item != "")
                {
                    Asset asset = new Asset()
                    {
                        UniqueID = assetAddition.L1LocCode + item,
                        AssetNumber = item,
                        AssetDescription = L3Cat.L3CatName,
                        L1CatCode = assetAddition.L1CatCode,
                        L2CatCode = assetAddition.L2CatCode,
                        L3CatCode = assetAddition.L3CatCode,
                        L4CatCode = assetAddition.L3CatCode + ITC3,
                        L1LocCode = assetAddition.L1LocCode,
                        L2LocCode = assetAddition.L2LocCode,
                        L3LocCode = assetAddition.L3LocCode,
                        L4LocCode = assetAddition.L4LocCode,
                        L5LocCode = assetAddition.L5LocCode,
                        ITC1 = L2Cat.ITC1,
                        ITC2 = L3Cat.ITC2,
                        ITC3 = ITC3,
                        LOCCODEASSET = L3Loc.LOCCODEASSET,
                        ROOMTYPECODE = L4Loc.ROOMTYPECODE,
                        CODELEVEL = L5Loc.CODELEVEL,
                        Status = "ACTIVE",
                        DisposedOn = "NULL",
                        CreatedOn = Convert.ToString(DateTime.Now)
                    };
                    assetRepository.Add(asset);
                    message = unityOfWork.Commit();
                }
            }

            if (lines.Count() > 1)
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
            }

            return message;
        }

        public string AssetAdditionReverification(AssetAdditionViewModel assetAddition)
        {
            var L2Cat = categoryRepository.GetById(assetAddition.L2CatCode);
            var L3Cat = L3CategoryRepository.GetById(assetAddition.L3CatCode);
            var L3Loc = L3LocationRepository.GetById(assetAddition.L3LocCode);
            var L4Loc = L4LocationRepository.GetById(assetAddition.L4LocCode);
            var L5Loc = L5LocationRepository.GetById(assetAddition.L5LocCode);
            var ITC3 = assetAddition.L2LocCode.Substring(assetAddition.L2LocCode.Length - 2); ;
            var L4Cat = assetAddition.L3CatCode + ITC3;
            var isL4Isist = L4CategoryRepository.GetById(L4Cat);
            L4Category L4 = new L4Category() { L1LocCode = assetAddition.L1LocCode, ITC3 = ITC3, L3CatCode = assetAddition.L3CatCode, L4CatCode = L4Cat };
            if (isL4Isist == null)
            {
                L4CategoryRepository.Add(L4);
                unityOfWork.Commit();
            }
            string[] lines = Regex.Split(assetAddition.AssetNumber, "\r\n");
            foreach (var item in lines)
            {
                if (item != "")
                {

                    var UID = assetAddition.L1LocCode + item;
                    var messageString = isUniqueIDExsist(UID, assetAddition.L1LocCode);

                    if (messageString == "UniqueID Exist")
                    {
                        UID = GenerateUID(assetAddition.L1LocCode);
                    }
                    AssetReverification asset = new AssetReverification()
                    {
                        RUniqueID = UID,
                        RAssetNumber = item,
                        AssetNumber = item,
                        RAssetDescription = L3Cat.L3CatName,
                        RL1CatCode = assetAddition.L1CatCode,
                        RL2CatCode = assetAddition.L2CatCode,
                        RL3CatCode = assetAddition.L3CatCode,
                        RL4CatCode = assetAddition.L3CatCode + ITC3,
                        RL1LocCode = assetAddition.L1LocCode,
                        RL2LocCode = assetAddition.L2LocCode,
                        RL3LocCode = assetAddition.L3LocCode,
                        RL4LocCode = assetAddition.L4LocCode,
                        RL5LocCode = assetAddition.L5LocCode,
                        RITC1 = L2Cat.ITC1,
                        RITC2 = L3Cat.ITC2,
                        RITC3 = ITC3,
                        RLOCCODEASSET = L3Loc.LOCCODEASSET,
                        RROOMTYPECODE = L4Loc.ROOMTYPECODE,
                        RCODELEVEL = L5Loc.CODELEVEL,
                        RStatus = "ACTIVE",
                        RDisposedOn = "NULL",
                        RCreatedOn = Convert.ToString(DateTime.Now),
                        L1CatCode = assetAddition.L1CatCode,
                        L2CatCode = assetAddition.L2CatCode,
                        L3CatCode = assetAddition.L3CatCode,
                        L4CatCode = assetAddition.L3CatCode + ITC3,
                        L1LocCode = assetAddition.L1LocCode,
                        L2LocCode = assetAddition.L2LocCode,
                        L3LocCode = assetAddition.L3LocCode,
                        L4LocCode = assetAddition.L4LocCode,
                        L5LocCode = assetAddition.L5LocCode,
                        ITC1 = L2Cat.ITC1,
                        ITC2 = L3Cat.ITC2,
                        ITC3 = ITC3,
                        LOCCODEASSET = L3Loc.LOCCODEASSET,
                        ROOMTYPECODE = L4Loc.ROOMTYPECODE,
                        CODELEVEL = L5Loc.CODELEVEL,
                        Status = "ACTIVE",
                        DisposedOn = "NULL",
                        CreatedOn = Convert.ToString(DateTime.Now)
                    };
                    AssetReverificationRepository.Add(asset);
                    message = unityOfWork.Commit();
                }
            }
            return message;
        }

        public PurchaseViewModel PurchaseDetails(AssetViewModel Collection)
        {
            var purchaseDetails = (from purchase in unityOfWork.db.PurchaseDetails
                                   join assetPurc in unityOfWork.db.AssetPurchases on purchase.PurchaseID
                                   equals assetPurc.PurchaseID
                                   where assetPurc.UniqueID == Collection.UniqueID
                                   select purchase).FirstOrDefault();

            PurchaseViewModel result = new PurchaseViewModel();
            if (purchaseDetails != null)
            {
                result.SupplierName = purchaseDetails.Supplier.SupplierName;
                result.InvoiceNumber = purchaseDetails.InvoiceNumber;
                result.DateofPurchase = purchaseDetails.DateofPurchase.ToString();
                result.iso = purchaseDetails.Currency.name;
                result.UnitPrice = purchaseDetails.UnitPrice;
                result.PONumber = purchaseDetails.PONumber;
                //result.DateOfPO = purchaseDetails.DateofPO.ToString();
                result.SupplierEmail = purchaseDetails.Supplier.SupplierEmail;
                result.InvoiceImage = purchaseDetails.InvoiceImage;
                result.PurchaseOrderImage = purchaseDetails.PurchaseOrderImage;
            }

            return result;
        }

        public IEnumerable<SearchViewModel> AssetNumberList(AssetViewModel collection)
        {
            var query1 = (from asset in unityOfWork.db.Assets
                          where asset.L1LocCode == collection.L1LocCode
                          select new SearchViewModel
                          {
                              AssetNumber = asset.AssetNumber,
                              Status = asset.Status
                          }).ToList();
            return query1;
        }

        public string AssetDisposal(AssetMovementViewModel assetMovement)
        {
            var user = userRepository.GetById(assetMovement.UserID);
            if (user.Password == assetMovement.Password)
            {
                string[] assets = Regex.Split(assetMovement.AssetNumber, ",");
                foreach (var item in assets)
                {
                    var asset = (from move in unityOfWork.db.Assets where move.L1LocCode == assetMovement.L1LocCode && move.AssetNumber == item select move).FirstOrDefault();
                    asset.Status = "DISPOSED";
                    asset.DisposedOn = assetMovement.DisposedOn;
                    assetRepository.Update(asset);
                }

                unityOfWork.Commit();
                User_Activity activity = new User_Activity()
                {
                    UserID = assetMovement.UserID,
                    Activity = "Single Asset Disposed",
                    ActivityTime = DateTime.Now
                };
                ActivityLogRepository.Add(activity);
                unityOfWork.Commit();
                return "Asset Disposed Succefully";
            }
            else
            {
                return "Incorrect Password";
            }

        }

        public IEnumerable<SearchViewModel> DateOfDisposalList(AssetViewModel collection)
        {
            var query1 = (from asset in unityOfWork.db.Assets
                          where asset.L1LocCode == collection.L1LocCode && asset.DisposedOn != "NULL"
                          select new SearchViewModel
                          {
                              DisposedOn = asset.DisposedOn
                          }).Distinct().ToList();
            return query1;
        }

        public IEnumerable<SearchViewModel> CreatedOnList(AssetViewModel collection)
        {
            var query1 = (from asset in unityOfWork.db.Assets
                          where asset.L1LocCode == collection.L1LocCode && asset.CreatedOn != "NULL"
                          select new SearchViewModel
                          {
                              DisposedOn = asset.DisposedOn
                          }).Distinct().ToList();
            return query1;
        }

        public string IsBarcodeExsist(AssetViewModel collection)
        {
            var barcodeExist = (from asset in unityOfWork.db.Assets where asset.L1LocCode == collection.L1LocCode && asset.AssetNumber == collection.AssetNumber select asset).ToList();
            if (barcodeExist.Count != 0)
            {
                return "Barcode Exist";
            }
            else
            {
                return "Barcode does not Exist";
            }
        }

        public string IsBarcodeExsistRev(AssetViewModel collection)
        {
            var barcodeExist = (from asset in unityOfWork.db.AssetReverifications where asset.L1LocCode == collection.L1LocCode && asset.AssetNumber == collection.AssetNumber select asset).ToList();
            if (barcodeExist.Count != 0)
            {
                return "Barcode Exist";
            }
            else
            {
                return "Barcode does not Exist";
            }
        }

        public ReverificationAPIViewModel Reverification(AssetViewModel assetViewModel)
        {
            ReverificationAPIViewModel ReturnReverification = new ReverificationAPIViewModel();
            List<ReverificationDataViewModel> VerifiedAssets = new List<ReverificationDataViewModel>();
            List<ReverificationDataViewModel> FoundAssets = new List<ReverificationDataViewModel>();
            List<ReverificationDataViewModel> UnverifiedAssets = new List<ReverificationDataViewModel>();
            List<AssetNumberViewModel> Assets = new List<AssetNumberViewModel>();
            List<ReverificationDataViewModel> MissingAssets = new List<ReverificationDataViewModel>();

            var query1 = (from asset in unityOfWork.db.AssetReverifications
                          where asset.L1LocCode == assetViewModel.L1LocCode
                          orderby asset.AssetDescription
                          select new ReverificationDataViewModel
                          {
                              AssetNumber = asset.AssetNumber,
                              AssetDescription = asset.AssetDescription,
                              Section = asset.L2Location.L2LocName,
                              Room_No = asset.L3Location.L3LocName,
                              Floor = asset.L5Location.L5LocName,
                              VerificationStatus = asset.VerificationStatus,
                              DateOfVerification = asset.DateOfVerification

                          }).ToList();

            if (assetViewModel.L2LocName != "Asset Section" && assetViewModel.L2LocName != null)
            {
                query1 = query1.Where(x => x.Section.Equals(assetViewModel.L2LocName)).ToList();
            }

            if (assetViewModel.L3LocName != "SELECT ROOM NUMBER" && assetViewModel.L3LocName != null)
            {
                query1 = query1.Where(x => x.Room_No.Equals(assetViewModel.L3LocName)).ToList();
            }

            if (assetViewModel.CODELEVEL != "SELECT FLOOR" && assetViewModel.CODELEVEL != null)
            {
                query1 = query1.Where(x => x.Floor.Equals(assetViewModel.CODELEVEL)).ToList();
            }

            foreach (var item2 in assetViewModel.Assets)
            {
                Assets.Add(item2);
            }

            foreach (var item9 in query1)
            {
                item9.Status = "MISSING";
                item9.VerificationStatus = "MISSING";
                MissingAssets.Add(item9);
            }

            foreach (var item in assetViewModel.Assets)
            {
                foreach (var item1 in query1)
                {
                    if (item.AssetNumber == item1.AssetNumber)
                    {
                        item1.Status = "VERIFIED";
                        item1.VerificationStatus = "VERIFIED";
                        VerifiedAssets.Add(item1);
                        Assets.Remove(item);
                        MissingAssets.Remove(item1);
                    }
                    //else
                    //{
                    //    item1.Status = "MISSING";
                    //}
                    //VerifiedAssets.Add(item1);
                }
            }

            foreach (var item6 in Assets)
            {
                var unverifiedAssets = (from assets in unityOfWork.db.Assets where assets.L1LocCode == assetViewModel.L1LocCode && assets.AssetNumber == item6.AssetNumber select assets).ToList();
                if (unverifiedAssets.Count != 0)
                {
                    VerifiedAssets.Add(new ReverificationDataViewModel { AssetNumber = unverifiedAssets.FirstOrDefault().AssetNumber, AssetDescription = unverifiedAssets.FirstOrDefault().AssetDescription, Status = "MOVED FROM " + unverifiedAssets.FirstOrDefault().L3Location.L3LocName, VerificationStatus = "MOVED FROM " + unverifiedAssets.FirstOrDefault().L3Location.L3LocName });
                }
                else
                {
                    VerifiedAssets.Add(new ReverificationDataViewModel { AssetNumber = item6.AssetNumber, AssetDescription = null, Status = "NO NAME", VerificationStatus = "NO NAME" });
                }
            }

            foreach (var item8 in MissingAssets)
            {
                VerifiedAssets.Add(item8);
            }

            var newList = VerifiedAssets.OrderBy(x => x.AssetDescription).ToList();

            ReturnReverification.VerifiedAssets = newList;
            ReturnReverification.Count = query1.Count();

            return ReturnReverification;
        }

        public void ReverifiedAssets(ReverificationViewModel collection)
        {
            var date = DateTime.Now.ToString("dd-MM-yyyy");
            foreach (var item in collection.Assets)
            {
                var assets = (from asset in unityOfWork.db.AssetReverifications
                              where asset.L1LocCode == collection.L1LocCode && asset.AssetNumber == item.AssetNumber
                              select asset).FirstOrDefault();

                #region COMMENT 26-JULY-2018 by Zain
                /// summary
                /// Below code was changed to update assets that are manually verified by selecting from checkboxes
                /// 

                //if (item.VerificationStatus == "VERIFIED" || item.VerificationStatus == "MISSING")
                //{
                //    assets.RAssetDescription = assets.AssetDescription;
                //    assets.RAssetNumber = assets.AssetNumber;
                //    assets.RCODELEVEL = assets.CODELEVEL;
                //    assets.RCreatedOn = assets.CreatedOn;
                //    assets.RDateOfVerification = assets.DateOfVerification;
                //    assets.RITC1 = assets.ITC1;
                //    assets.RITC2 = assets.ITC2;
                //    assets.RITC3 = assets.ITC3;
                //    assets.RDepreciated = assets.Depreciated;
                //    assets.RDisposedOn = assets.DisposedOn;
                //    assets.RL1CatCode = assets.L1CatCode;
                //    assets.RL1LocCode = assets.L1LocCode;
                //    assets.RL2CatCode = assets.L2CatCode;
                //    assets.RL2LocCode = assets.L2LocCode;
                //    assets.RL3CatCode = assets.L3CatCode;
                //    assets.RL3LocCode = assets.L3LocCode;
                //    assets.RL4CatCode = assets.L4CatCode;
                //    assets.RL4LocCode = assets.L4LocCode;
                //    assets.RL5LocCode = assets.L5LocCode;
                //    assets.RLOCCODEASSET = assets.LOCCODEASSET;
                //    assets.RNetBookValue = assets.NetBookValue;
                //    assets.RROOMTYPECODE = assets.ROOMTYPECODE;
                //    assets.RStatus = assets.Status;
                //    assets.RVerificationStatus = item.VerificationStatus;
                //    assets.RDateOfVerification = date;
                //    AssetReverificationRepository.Update(assets);
                //}
                //else if (item.VerificationStatus == "VERIFIED DESCP")
                //{
                //    assets.RAssetNumber = assets.AssetNumber;
                //    assets.RL1CatCode = assets.L1CatCode;
                //    assets.RL2CatCode = assets.L2CatCode;
                //    assets.RL3CatCode = assets.L3CatCode;
                //    assets.RL4CatCode = assets.L4CatCode;
                //    assets.RVerificationStatus = item.VerificationStatus;
                //    assets.RITC1 = assets.ITC1;
                //    assets.RITC2 = assets.ITC2;
                //    assets.RITC3 = assets.ITC3;
                //    assets.VerificationStatus = "UNVERIFIED";
                //    assets.RDateOfVerification = date;
                //    assets.RL2LocCode = collection.L2LocCode;
                //    var LOCCODEASSET = L3LocationRepository.GetById(collection.L3LocCode);
                //    assets.RL3LocCode = collection.L3LocCode;
                //    assets.RLOCCODEASSET = assets.LOCCODEASSET;
                //    var ROOMTYPECODE = L4LocationRepository.GetById(collection.L4LocCode);
                //    assets.RL4LocCode = collection.L4LocCode;
                //    assets.RROOMTYPECODE = ROOMTYPECODE.ROOMTYPECODE;
                //    var CODELEVEL = L5LocationRepository.GetById(collection.L5LocCode);
                //    assets.RL5LocCode = collection.L5LocCode;
                //    assets.RCODELEVEL = CODELEVEL.CODELEVEL;
                //    assets.RL1LocCode = assets.L1LocCode;

                //    AssetReverificationRepository.Update(assets);
                //}
                //else
                //{
                //    assets.RAssetNumber = assets.AssetNumber;
                //    assets.RAssetDescription = assets.AssetDescription;
                //    assets.RL1CatCode = assets.L1CatCode;
                //    assets.RL2CatCode = assets.L2CatCode;
                //    assets.RL3CatCode = assets.L3CatCode;
                //    assets.RL4CatCode = assets.L4CatCode;
                //    assets.RVerificationStatus = item.VerificationStatus;
                //    assets.RITC1 = assets.ITC1;
                //    assets.RITC2 = assets.ITC2;
                //    assets.RITC3 = assets.ITC3;
                //    assets.VerificationStatus = "UNVERIFIED";
                //    assets.RDateOfVerification = date;
                //    assets.RL2LocCode = collection.L2LocCode;
                //    var LOCCODEASSET = L3LocationRepository.GetById(collection.L3LocCode);
                //    assets.RL3LocCode = collection.L3LocCode;
                //    assets.RLOCCODEASSET = LOCCODEASSET.LOCCODEASSET;
                //    var ROOMTYPECODE = L4LocationRepository.GetById(collection.L4LocCode);
                //    assets.RL4LocCode = collection.L4LocCode;
                //    assets.RROOMTYPECODE = ROOMTYPECODE.ROOMTYPECODE;
                //    var CODELEVEL = L5LocationRepository.GetById(collection.L5LocCode);
                //    assets.RL5LocCode = collection.L5LocCode;
                //    assets.RCODELEVEL = CODELEVEL.CODELEVEL;
                //    assets.RL1LocCode = assets.L1LocCode;
                //    assets.RStatus = assets.Status;
                //    assets.RCreatedOn = assets.CreatedOn;
                //    assets.RDepreciated = assets.Depreciated;
                //    assets.RNetBookValue = assets.NetBookValue;


                //    AssetReverificationRepository.Update(assets);
                //}
                #endregion

                if (item.VerificationStatus == "VERIFIED")
                {
                    #region Check Checkbox (CHECKED OR UN-CHECKED)

                    if (Convert.ToBoolean(item.Status) == true)
                    {
                        assets.RStatus = assets.Status;
                        assets.RVerificationStatus = "VERIFIED";
                        assets.VerificationStatus = "VERIFIED";
                        assets.RDateOfVerification = date;

                        assets.RAssetDescription = assets.AssetDescription;
                        assets.RAssetNumber = assets.AssetNumber;
                        assets.RCODELEVEL = assets.CODELEVEL;
                        assets.RCreatedOn = assets.CreatedOn;
                        assets.RDateOfVerification = assets.DateOfVerification;
                        assets.RITC1 = assets.ITC1;
                        assets.RITC2 = assets.ITC2;
                        assets.RITC3 = assets.ITC3;
                        assets.RDepreciated = assets.Depreciated;
                        assets.RDisposedOn = assets.DisposedOn;
                        assets.RL1CatCode = assets.L1CatCode;
                        assets.RL1LocCode = assets.L1LocCode;
                        assets.RL2CatCode = assets.L2CatCode;
                        assets.RL2LocCode = assets.L2LocCode;
                        assets.RL3CatCode = assets.L3CatCode;
                        assets.RL3LocCode = assets.L3LocCode;
                        assets.RL4CatCode = assets.L4CatCode;
                        assets.RL4LocCode = assets.L4LocCode;
                        assets.RL5LocCode = assets.L5LocCode;
                        assets.RLOCCODEASSET = assets.LOCCODEASSET;
                        assets.RNetBookValue = assets.NetBookValue;
                        assets.RROOMTYPECODE = assets.ROOMTYPECODE;
                    }
                    else
                    {
                        assets.RStatus = assets.Status;
                        assets.RVerificationStatus = "";
                        assets.VerificationStatus = "UNVERIFIED";

                        assets.RAssetDescription = "";
                        assets.RAssetNumber = "";
                        assets.RCODELEVEL = "";
                        assets.RCreatedOn = "";
                        assets.RDateOfVerification = "";
                        assets.RITC1 = "";
                        assets.RITC2 = "";
                        assets.RITC3 = "";
                        assets.RDepreciated = "";
                        assets.RDisposedOn = "";
                        assets.RL1CatCode = "";
                        assets.RL1LocCode = "";
                        assets.RL2CatCode = "";
                        assets.RL2LocCode = "";
                        assets.RL3CatCode = "";
                        assets.RL3LocCode = "";
                        assets.RL4CatCode = "";
                        assets.RL4LocCode = "";
                        assets.RL5LocCode = "";
                        assets.RLOCCODEASSET = "";
                        assets.RNetBookValue = "";
                        assets.RROOMTYPECODE = "";
                    }

                    #endregion

                    AssetReverificationRepository.Update(assets);
                }
                else if (item.VerificationStatus == "MISSING")
                {
                    #region Check Checkbox (CHECKED OR UN-CHECKED)

                    if (Convert.ToBoolean(item.Status) == true)
                    {
                        assets.RStatus = assets.Status;
                        assets.RVerificationStatus = "VERIFIED";
                        assets.VerificationStatus = "VERIFIED";

                        assets.RAssetDescription = assets.AssetDescription;
                        assets.RAssetNumber = assets.AssetNumber;
                        assets.RCODELEVEL = assets.CODELEVEL;
                        assets.RCreatedOn = assets.CreatedOn;
                        assets.RDateOfVerification = date;
                        assets.RITC1 = assets.ITC1;
                        assets.RITC2 = assets.ITC2;
                        assets.RITC3 = assets.ITC3;
                        assets.RDepreciated = assets.Depreciated;
                        assets.RDisposedOn = assets.DisposedOn;
                        assets.RL1CatCode = assets.L1CatCode;
                        assets.RL1LocCode = assets.L1LocCode;
                        assets.RL2CatCode = assets.L2CatCode;
                        assets.RL2LocCode = assets.L2LocCode;
                        assets.RL3CatCode = assets.L3CatCode;
                        assets.RL3LocCode = assets.L3LocCode;
                        assets.RL4CatCode = assets.L4CatCode;
                        assets.RL4LocCode = assets.L4LocCode;
                        assets.RL5LocCode = assets.L5LocCode;
                        assets.RLOCCODEASSET = assets.LOCCODEASSET;
                        assets.RNetBookValue = assets.NetBookValue;
                        assets.RROOMTYPECODE = assets.ROOMTYPECODE;
                    }
                    else
                    {
                        assets.RStatus = assets.Status;
                        assets.RVerificationStatus = item.VerificationStatus;
                        assets.VerificationStatus = item.VerificationStatus;

                        assets.RAssetDescription = "";
                        assets.RAssetNumber = "";
                        assets.RCODELEVEL = "";
                        assets.RCreatedOn = "";
                        assets.RDateOfVerification = "";
                        assets.RITC1 = "";
                        assets.RITC2 = "";
                        assets.RITC3 = "";
                        assets.RDepreciated = "";
                        assets.RDisposedOn = "";
                        assets.RL1CatCode = "";
                        assets.RL1LocCode = "";
                        assets.RL2CatCode = "";
                        assets.RL2LocCode = "";
                        assets.RL3CatCode = "";
                        assets.RL3LocCode = "";
                        assets.RL4CatCode = "";
                        assets.RL4LocCode = "";
                        assets.RL5LocCode = "";
                        assets.RLOCCODEASSET = "";
                        assets.RNetBookValue = "";
                        assets.RROOMTYPECODE = "";
                    }

                    #endregion

                    AssetReverificationRepository.Update(assets);
                }
                else if (item.VerificationStatus == "VERIFIED DESCP")
                {
                    #region Check Checkbox (CHECKED OR UN-CHECKED)

                    if (Convert.ToBoolean(item.Status) == true)
                    {
                        assets.RVerificationStatus = "VERIFIED";
                        assets.VerificationStatus = "VERIFIED";

                        assets.RAssetNumber = assets.AssetNumber;
                        assets.RL1CatCode = assets.L1CatCode;
                        assets.RL2CatCode = assets.L2CatCode;
                        assets.RL3CatCode = assets.L3CatCode;
                        assets.RL4CatCode = assets.L4CatCode;
                        assets.RITC1 = assets.ITC1;
                        assets.RITC2 = assets.ITC2;
                        assets.RITC3 = assets.ITC3;
                        assets.RDateOfVerification = date;
                        assets.RL2LocCode = collection.L2LocCode;
                        var LOCCODEASSET = L3LocationRepository.GetById(collection.L3LocCode);
                        assets.RL3LocCode = collection.L3LocCode;
                        assets.RLOCCODEASSET = assets.LOCCODEASSET;
                        var ROOMTYPECODE = L4LocationRepository.GetById(collection.L4LocCode);
                        assets.RL4LocCode = collection.L4LocCode;
                        assets.RROOMTYPECODE = ROOMTYPECODE.ROOMTYPECODE;
                        var CODELEVEL = L5LocationRepository.GetById(collection.L5LocCode);
                        assets.RL5LocCode = collection.L5LocCode;
                        assets.RCODELEVEL = CODELEVEL.CODELEVEL;
                        assets.RL1LocCode = assets.L1LocCode;
                    }
                    else
                    {
                        assets.RVerificationStatus = item.VerificationStatus;
                        assets.VerificationStatus = "UNVERIFIED";

                        assets.RAssetDescription = "";
                        assets.RAssetNumber = "";
                        assets.RCODELEVEL = "";
                        assets.RCreatedOn = "";
                        assets.RDateOfVerification = "";
                        assets.RITC1 = "";
                        assets.RITC2 = "";
                        assets.RITC3 = "";
                        assets.RDepreciated = "";
                        assets.RDisposedOn = "";
                        assets.RL1CatCode = "";
                        assets.RL1LocCode = "";
                        assets.RL2CatCode = "";
                        assets.RL2LocCode = "";
                        assets.RL3CatCode = "";
                        assets.RL3LocCode = "";
                        assets.RL4CatCode = "";
                        assets.RL4LocCode = "";
                        assets.RL5LocCode = "";
                        assets.RLOCCODEASSET = "";
                        assets.RNetBookValue = "";
                        assets.RROOMTYPECODE = "";
                    }

                    #endregion

                    AssetReverificationRepository.Update(assets);
                }
                else
                {
                    #region Check Checkbox (CHECKED OR UN-CHECKED)

                    if (Convert.ToBoolean(item.Status) == true)
                    {
                        assets.RStatus = assets.Status;
                        assets.RVerificationStatus = "VERIFIED";
                        assets.VerificationStatus = "VERIFIED";

                        assets.RAssetNumber = assets.AssetNumber;
                        assets.RAssetDescription = assets.AssetDescription;
                        assets.RL1CatCode = assets.L1CatCode;
                        assets.RL2CatCode = assets.L2CatCode;
                        assets.RL3CatCode = assets.L3CatCode;
                        assets.RL4CatCode = assets.L4CatCode;

                        assets.RITC1 = assets.ITC1;
                        assets.RITC2 = assets.ITC2;
                        assets.RITC3 = assets.ITC3;

                        assets.RDateOfVerification = date;
                        assets.RL2LocCode = collection.L2LocCode;

                        var LOCCODEASSET = L3LocationRepository.GetById(collection.L3LocCode);
                        assets.RL3LocCode = collection.L3LocCode;
                        assets.RLOCCODEASSET = LOCCODEASSET.LOCCODEASSET;

                        var ROOMTYPECODE = L4LocationRepository.GetById(collection.L4LocCode);
                        assets.RL4LocCode = collection.L4LocCode;
                        assets.RROOMTYPECODE = ROOMTYPECODE.ROOMTYPECODE;

                        var CODELEVEL = L5LocationRepository.GetById(collection.L5LocCode);
                        assets.RL5LocCode = collection.L5LocCode;
                        assets.RCODELEVEL = CODELEVEL.CODELEVEL;
                        assets.RL1LocCode = assets.L1LocCode;
                        assets.RCreatedOn = assets.CreatedOn;
                        assets.RDepreciated = assets.Depreciated;
                        assets.RNetBookValue = assets.NetBookValue;
                    }
                    else
                    {
                        assets.RStatus = assets.Status;
                        assets.RVerificationStatus = "UNVERIFIED";
                        assets.VerificationStatus = "UNVERIFIED";

                        assets.RAssetDescription = "";
                        assets.RAssetNumber = "";
                        assets.RCODELEVEL = "";
                        assets.RCreatedOn = "";
                        assets.RDateOfVerification = "";
                        assets.RITC1 = "";
                        assets.RITC2 = "";
                        assets.RITC3 = "";
                        assets.RDepreciated = "";
                        assets.RDisposedOn = "";
                        assets.RL1CatCode = "";
                        assets.RL1LocCode = "";
                        assets.RL2CatCode = "";
                        assets.RL2LocCode = "";
                        assets.RL3CatCode = "";
                        assets.RL3LocCode = "";
                        assets.RL4CatCode = "";
                        assets.RL4LocCode = "";
                        assets.RL5LocCode = "";
                        assets.RLOCCODEASSET = "";
                        assets.RNetBookValue = "";
                        assets.RROOMTYPECODE = "";
                    }

                    #endregion

                    AssetReverificationRepository.Update(assets);
                }
            }
            unityOfWork.Commit();
        }

        public void ManualReverifiedAssets(ReverificationViewModel collection)
        {
            var date = DateTime.Now.ToString("dd-MM-yyyy");
            foreach (var item in collection.Assets)
            {
                var assets = (from asset in unityOfWork.db.AssetReverifications where asset.L1LocCode == collection.L1LocCode && asset.AssetNumber == item.AssetNumber select asset).FirstOrDefault();
                if (item.VerificationStatus == "VERIFIED" || item.VerificationStatus == "MISSING")
                {
                    assets.RAssetDescription = assets.AssetDescription;
                    assets.RAssetNumber = assets.AssetNumber;

                    assets.RCODELEVEL = assets.CODELEVEL;
                    assets.RCreatedOn = assets.CreatedOn;
                    assets.RDateOfVerification = assets.DateOfVerification;

                    assets.RITC1 = assets.ITC1;
                    assets.RITC2 = assets.ITC2;
                    assets.RITC3 = assets.ITC3;

                    assets.RDepreciated = assets.Depreciated;
                    assets.RDisposedOn = assets.DisposedOn;

                    assets.CatCode = assets.CatCode;

                    assets.RL1CatCode = assets.L1CatCode;
                    assets.RL1LocCode = assets.L1LocCode;

                    assets.RL2CatCode = assets.L2CatCode;
                    assets.RL2LocCode = assets.L2LocCode;

                    assets.RL3CatCode = assets.L3CatCode;
                    assets.RL3LocCode = assets.L3LocCode;

                    assets.RL4CatCode = assets.L4CatCode;
                    assets.RL4LocCode = assets.L4LocCode;

                    assets.RL5LocCode = assets.L5LocCode;

                    assets.RLOCCODEASSET = assets.LOCCODEASSET;
                    assets.RNetBookValue = assets.NetBookValue;
                    assets.RROOMTYPECODE = assets.ROOMTYPECODE;
                    assets.RStatus = assets.Status;
                    assets.RVerificationStatus = item.VerificationStatus;
                    assets.RDateOfVerification = date;
                    AssetReverificationRepository.Update(assets);
                }
                else if (item.VerificationStatus == "VERIFIED DESCP")
                {
                    assets.RAssetNumber = assets.AssetNumber;

                    assets.RL1CatCode = assets.L1CatCode;
                    assets.RL2CatCode = assets.L2CatCode;
                    assets.RL3CatCode = assets.L3CatCode;
                    assets.RL4CatCode = assets.L4CatCode;

                    assets.RVerificationStatus = item.VerificationStatus;

                    assets.RITC1 = assets.ITC1;
                    assets.RITC2 = assets.ITC2;
                    assets.RITC3 = assets.ITC3;

                    assets.VerificationStatus = "UNVERIFIED";
                    assets.RDateOfVerification = date;

                    assets.RL2LocCode = collection.L2LocCode;

                    var LOCCODEASSET = L3LocationRepository.GetById(collection.L3LocCode);
                    assets.RL3LocCode = collection.L3LocCode;
                    assets.RLOCCODEASSET = assets.LOCCODEASSET;

                    var ROOMTYPECODE = L4LocationRepository.GetById(collection.L4LocCode);
                    assets.RL4LocCode = collection.L4LocCode;
                    assets.RROOMTYPECODE = ROOMTYPECODE.ROOMTYPECODE;

                    var CODELEVEL = L5LocationRepository.GetById(collection.L5LocCode);
                    assets.RL5LocCode = collection.L5LocCode;
                    assets.RCODELEVEL = CODELEVEL.CODELEVEL;
                    assets.RL1LocCode = assets.L1LocCode;

                    AssetReverificationRepository.Update(assets);
                }
                else
                {
                    assets.RAssetNumber = assets.AssetNumber;
                    assets.RAssetDescription = assets.AssetDescription;

                    assets.RL1CatCode = assets.L1CatCode;
                    assets.RL2CatCode = assets.L2CatCode;
                    assets.RL3CatCode = assets.L3CatCode;
                    assets.RL4CatCode = assets.L4CatCode;

                    assets.RVerificationStatus = item.VerificationStatus;

                    assets.RITC1 = assets.ITC1;
                    assets.RITC2 = assets.ITC2;
                    assets.RITC3 = assets.ITC3;

                    assets.VerificationStatus = "UNVERIFIED";
                    assets.RDateOfVerification = date;
                    assets.RL2LocCode = collection.L2LocCode;

                    var LOCCODEASSET = L3LocationRepository.GetById(collection.L3LocCode);
                    assets.RL3LocCode = collection.L3LocCode;
                    assets.RLOCCODEASSET = LOCCODEASSET.LOCCODEASSET;

                    var ROOMTYPECODE = L4LocationRepository.GetById(collection.L4LocCode);
                    assets.RL4LocCode = collection.L4LocCode;
                    assets.RROOMTYPECODE = ROOMTYPECODE.ROOMTYPECODE;

                    var CODELEVEL = L5LocationRepository.GetById(collection.L5LocCode);
                    assets.RL5LocCode = collection.L5LocCode;
                    assets.RCODELEVEL = CODELEVEL.CODELEVEL;

                    assets.RL1LocCode = assets.L1LocCode;
                    assets.RStatus = assets.Status;
                    assets.RCreatedOn = assets.CreatedOn;
                    assets.RDepreciated = assets.Depreciated;
                    assets.RNetBookValue = assets.NetBookValue;

                    AssetReverificationRepository.Update(assets);
                }
            }
            unityOfWork.Commit();
        }

        public string ReplaceBarcode(ReverificationViewModel collection)
        {
            var Replacer = (from assets in unityOfWork.db.AssetReverifications where assets.L1LocCode == collection.L1LocCode && assets.AssetNumber == collection.OldBarcode select assets).FirstOrDefault();
            Replacer.RAssetNumber = collection.NewBarcode;
            Replacer.RAssetDescription = Replacer.AssetDescription;
            Replacer.RL1CatCode = Replacer.L1CatCode;
            Replacer.RL2CatCode = Replacer.L2CatCode;
            Replacer.RL3CatCode = Replacer.L3CatCode;
            Replacer.RL4CatCode = Replacer.L4CatCode;
            Replacer.RL1LocCode = Replacer.L1LocCode;
            Replacer.RL2LocCode = Replacer.L2LocCode;
            Replacer.RL3LocCode = Replacer.L3LocCode;
            Replacer.RL4LocCode = Replacer.L4LocCode;
            Replacer.RL5LocCode = Replacer.L5LocCode;
            Replacer.RITC1 = Replacer.ITC1;
            Replacer.RITC2 = Replacer.ITC2;
            Replacer.RITC3 = Replacer.ITC3;
            Replacer.RLOCCODEASSET = Replacer.LOCCODEASSET;
            Replacer.RROOMTYPECODE = Replacer.ROOMTYPECODE;
            Replacer.RCODELEVEL = Replacer.CODELEVEL;
            Replacer.RStatus = Replacer.Status;
            Replacer.RDisposedOn = Replacer.DisposedOn;
            Replacer.RDateOfVerification = Replacer.DateOfVerification;
            Replacer.RCreatedOn = Replacer.CreatedOn;
            Replacer.RDepreciated = Replacer.Depreciated;
            Replacer.RNetBookValue = Replacer.NetBookValue;
            Replacer.VerificationStatus = "UNVERIFIED";
            Replacer.RVerificationStatus = "VERIFIED BARCODE";
            AssetReverificationRepository.Update(Replacer);
            var message = unityOfWork.Commit();
            return message;
        }

        public string ReverificationSchedule(AssetViewModel collection)
        {
            List<AssetReverification> Schedule = new List<AssetReverification>();
            var assets = (from asset in unityOfWork.db.Assets
                          where asset.L1LocCode == collection.L1LocCode
                          select new SearchViewModel
                          {
                              AssetNumber = asset.AssetNumber,
                              AssetDescription = asset.AssetDescription,
                              Group = asset.L1Category.L1CatName,
                              Category = asset.L2Category.L2CatName,
                              Image = asset.L3CatCode,
                              Location = asset.AssetLocation.L1LocName,
                              Section = asset.L2Location.L2LocName,
                              Room_No = asset.L3Location.L3LocName,
                              Room_Type = asset.L4Location.L4LocName,
                              Floor = asset.L5Location.L5LocName,
                              BookValue = "Not Available",
                              Status = asset.Status,
                              DisposedOn = asset.DisposedOn,
                              VerificationStatus = asset.VerificationStatus,
                              DateOfVerification = asset.DateOfVerification,
                              Depreciated = asset.Depreciated,
                              NetbookValue = asset.NetBookValue,
                              L1CatCode = asset.L1CatCode,
                              L2CatCode = asset.L2CatCode,
                              L3CatCode = asset.L3CatCode,
                              L4CatCode = asset.L4CatCode,
                              L1LocCode = asset.L1LocCode,
                              L2LocCode = asset.L2LocCode,
                              L3LocCode = asset.L3LocCode,
                              L4LocCode = asset.L4LocCode,
                              L5LocCode = asset.L5LocCode,
                              ITC1 = asset.ITC1,
                              ITC2 = asset.ITC2,
                              ITC3 = asset.ITC3,
                              CODELEVEL = asset.CODELEVEL,
                              CreatedOn = asset.CreatedOn,
                              LOCCODEASSET = asset.LOCCODEASSET,
                              ROOMTYPECODE = asset.ROOMTYPECODE,
                              NetBookValue = asset.NetBookValue,
                              UniqueID = asset.UniqueID
                          }).ToList();

            foreach (var item in assets)
            {
                Schedule.Add(new AssetReverification
                {
                    RUniqueID = item.UniqueID,
                    AssetDescription = item.AssetDescription,
                    AssetNumber = item.AssetNumber,
                    CODELEVEL = item.CODELEVEL,
                    DateOfVerification = item.DateOfVerification,
                    CreatedOn = item.CreatedOn,
                    Depreciated = item.Depreciated,
                    DisposedOn = item.DisposedOn,
                    ITC1 = item.ITC1,
                    ITC2 = item.ITC2,
                    ITC3 = item.ITC3,
                    L1CatCode = item.L1CatCode,
                    L2CatCode = item.L2CatCode,
                    L3CatCode = item.L3CatCode,
                    L4CatCode = item.L4CatCode,
                    L1LocCode = item.L1LocCode,
                    L2LocCode = item.L2LocCode,
                    L3LocCode = item.L3LocCode,
                    L4LocCode = item.L4LocCode,
                    L5LocCode = item.L5LocCode,

                    L1LocName = item.Location,
                    L2LocName = item.Section,
                    L3LocName = item.Room_No,
                    L4LocName = item.Room_Type,
                    L5LocName = item.Floor,

                    LOCCODEASSET = item.LOCCODEASSET,
                    NetBookValue = item.NetBookValue,
                    ROOMTYPECODE = item.ROOMTYPECODE,
                    VerificationStatus = item.VerificationStatus,
                    Status = item.Status
                });
            }

            foreach (var item2 in Schedule)
            {
                AssetReverificationRepository.Add(item2);
                string message = unityOfWork.Commit();
                if (message != "Success")
                {
                    AssetReverificationRepository.Update(item2);
                    unityOfWork.Commit();
                }
            }

            return Convert.ToString(Schedule.Count());
        }

        public string GenerateUID(string L1LocCode)
        {
            Random random = new Random();
            string number = Convert.ToString(random.Next(1000, 9999));
            string UID = L1LocCode + number;
            var message = isUniqueIDExsist(UID, L1LocCode);
            if (message == "UniqueID Exist")
            {
                return GenerateUID(L1LocCode);
            }
            else
            {
                return UID;
            }
        }

        public string isUniqueIDExsist(string UID, string L1LocCode)
        {
            var UniqueIDExsist = (from asset in unityOfWork.db.AssetReverifications where asset.L1LocCode == L1LocCode && asset.RUniqueID == UID select asset).ToList();
            if (UniqueIDExsist.Count != 0)
            {
                return "UniqueID Exist";
            }
            else
            {
                return "UniqueID does not Exist";
            }
        }

        public string CloseReverification(AssetViewModel collection)
        {
            var GenReconCode = GenerateReconciliationCode(collection.L1LocCode);
            var date = DateTime.Now.ToString("dd-MM-yyyy");
            ReconciliationRecord AddRecociliation = new ReconciliationRecord();

            AddRecociliation.ReconciliationCode = GenReconCode;
            AddRecociliation.DateOfClosing = date;
            ReconciliationRecordRepository.Add(AddRecociliation);
            unityOfWork.Commit();

            List<Reconciliation> Closing = new List<Reconciliation>();
            List<Asset> UpdateAsset = new List<Asset>();
            var assets = (from asset in unityOfWork.db.AssetReverifications
                          where asset.L1LocCode == collection.L1LocCode
                          select new ReverificationViewModel
                          {
                              AssetNumber = asset.AssetNumber,
                              AssetDescription = asset.AssetDescription,
                              RL1CatCode = asset.RL1CatCode,
                              RL2CatCode = asset.RL2CatCode,
                              RL3CatCode = asset.RL3CatCode,
                              RL4CatCode = asset.RL4CatCode,
                              RL1LocCode = asset.RL1LocCode,
                              RL2LocCode = asset.RL2LocCode,
                              RL3LocCode = asset.RL3LocCode,
                              RL4LocCode = asset.RL4LocCode,
                              RL5LocCode = asset.RL5LocCode,
                              RStatus = asset.RStatus,
                              RDisposedOn = asset.RDisposedOn,
                              RITC1 = asset.RITC1,
                              RITC2 = asset.RITC2,
                              RITC3 = asset.RITC3,
                              RCODELEVEL = asset.RCODELEVEL,
                              RCreatedOn = asset.RCreatedOn,
                              RLOCCODEASSET = asset.RLOCCODEASSET,
                              RROOMTYPECODE = asset.RROOMTYPECODE,
                              RVerificationStatus = asset.RVerificationStatus,
                              RDateOfVerification = asset.RDateOfVerification,
                              RDepreciated = asset.RDepreciated,
                              RNetBookValue = asset.RNetBookValue,
                              RAssetNumber = asset.RAssetNumber,
                              RAssetDescription = asset.RAssetDescription,
                              L1CatCode = asset.L1CatCode,
                              L2CatCode = asset.L2CatCode,
                              L3CatCode = asset.L3CatCode,
                              L4CatCode = asset.L4CatCode,
                              L1LocCode = asset.L1LocCode,
                              L2LocCode = asset.L2LocCode,
                              L3LocCode = asset.L3LocCode,
                              L4LocCode = asset.L4LocCode,
                              L5LocCode = asset.L5LocCode,
                              Status = asset.Status,
                              DisposedOn = asset.DisposedOn,
                              ITC1 = asset.ITC1,
                              ITC2 = asset.ITC2,
                              ITC3 = asset.ITC3,
                              CODELEVEL = asset.CODELEVEL,
                              CreatedOn = asset.CreatedOn,
                              LOCCODEASSET = asset.LOCCODEASSET,
                              ROOMTYPECODE = asset.ROOMTYPECODE,
                              VerificationStatus = asset.VerificationStatus,
                              DateOfVerification = asset.DateOfVerification,
                              Depreciated = asset.Depreciated,
                              NetBookValue = asset.NetBookValue,
                              RUniqueID = asset.RUniqueID
                          }).ToList();

            foreach (var item in assets)
            {
                Closing.Add(new Reconciliation
                {
                    ReconciliationCode = GenReconCode,
                    RUniqueID = item.RUniqueID,
                    AssetDescription = item.AssetDescription,
                    AssetNumber = item.AssetNumber,
                    CODELEVEL = item.CODELEVEL,
                    DateOfVerification = item.DateOfVerification,
                    CreatedOn = item.CreatedOn,
                    Depreciated = item.Depreciated,
                    DisposedOn = item.DisposedOn,
                    ITC1 = item.ITC1,
                    ITC2 = item.ITC2,
                    ITC3 = item.ITC3,
                    L1CatCode = item.L1CatCode,
                    L2CatCode = item.L2CatCode,
                    L3CatCode = item.L3CatCode,
                    L4CatCode = item.L4CatCode,
                    L1LocCode = item.L1LocCode,
                    L2LocCode = item.L2LocCode,
                    L3LocCode = item.L3LocCode,
                    L4LocCode = item.L4LocCode,
                    L5LocCode = item.L5LocCode,
                    LOCCODEASSET = item.LOCCODEASSET,
                    NetBookValue = item.NetBookValue,
                    ROOMTYPECODE = item.ROOMTYPECODE,
                    VerificationStatus = item.VerificationStatus,
                    Status = item.Status,
                    RAssetDescription = item.RAssetDescription,
                    RAssetNumber = item.RAssetNumber,
                    RCODELEVEL = item.RCODELEVEL,
                    RDateOfVerification = item.RDateOfVerification,
                    RCreatedOn = item.RCreatedOn,
                    RDepreciated = item.RDepreciated,
                    RDisposedOn = item.RDisposedOn,
                    RITC1 = item.RITC1,
                    RITC2 = item.RITC2,
                    RITC3 = item.RITC3,
                    RL1CatCode = item.RL1CatCode,
                    RL2CatCode = item.RL2CatCode,
                    RL3CatCode = item.RL3CatCode,
                    RL4CatCode = item.RL4CatCode,
                    RL1LocCode = item.RL1LocCode,
                    RL2LocCode = item.RL2LocCode,
                    RL3LocCode = item.RL3LocCode,
                    RL4LocCode = item.RL4LocCode,
                    RL5LocCode = item.RL5LocCode,
                    RLOCCODEASSET = item.RLOCCODEASSET,
                    RNetBookValue = item.RNetBookValue,
                    RROOMTYPECODE = item.RROOMTYPECODE,
                    RVerificationStatus = item.RVerificationStatus,
                    RStatus = item.RStatus
                });

                UpdateAsset.Add(new Asset
                {
                    UniqueID = item.RUniqueID,
                    AssetDescription = item.RAssetDescription,
                    AssetNumber = item.RAssetNumber,
                    CODELEVEL = item.RCODELEVEL,
                    DateOfVerification = item.RDateOfVerification,
                    CreatedOn = item.RCreatedOn,
                    Depreciated = item.RDepreciated,
                    DisposedOn = item.RDisposedOn,
                    ITC1 = item.RITC1,
                    ITC2 = item.RITC2,
                    ITC3 = item.RITC3,
                    L1CatCode = item.RL1CatCode,
                    L2CatCode = item.RL2CatCode,
                    L3CatCode = item.RL3CatCode,
                    L4CatCode = item.RL4CatCode,
                    L1LocCode = item.RL1LocCode,
                    L2LocCode = item.RL2LocCode,
                    L3LocCode = item.RL3LocCode,
                    L4LocCode = item.RL4LocCode,
                    L5LocCode = item.RL5LocCode,
                    LOCCODEASSET = item.RLOCCODEASSET,
                    NetBookValue = item.RNetBookValue,
                    ROOMTYPECODE = item.RROOMTYPECODE,
                    VerificationStatus = item.RVerificationStatus,
                    Status = item.RStatus
                });
            }

            foreach (var item2 in Closing)
            {
                ReconciliationRepository.Add(item2);
            }

            string message = unityOfWork.Commit();

            if (message == "Success")
            {
                foreach (var item2 in UpdateAsset)
                {
                    assetRepository.Update(item2);
                    message = unityOfWork.Commit();
                    if (message != "Success")
                    {
                        assetRepository.Add(item2);
                    }
                }
            }

            return Convert.ToString(Closing.Count());
        }

        public string GenerateReconciliationCode(string L1LocCode)
        {
            Random random = new Random();
            string number = Convert.ToString(random.Next(1000, 9999));
            string ReconciliationCode = "RECONCILE" + L1LocCode + number;

            var Reconciliation = (from reconciliationRecord in unityOfWork.db.ReconciliationRecords
                                  where reconciliationRecord.ReconciliationCode == ReconciliationCode
                                  select reconciliationRecord).ToList();
            if (Reconciliation.Count == 0)
            {
                return ReconciliationCode;
            }
            return GenerateReconciliationCode(L1LocCode);
        }

        public IEnumerable<SearchViewModel> ComputeDepreciation(AssetViewModel collection)
        {
            var query1 = (from asset in unityOfWork.db.Assets
                          join assetPurchase in unityOfWork.db.AssetPurchases on asset.UniqueID equals assetPurchase.UniqueID
                          join purchases in unityOfWork.db.PurchaseDetails on assetPurchase.PurchaseID equals purchases.PurchaseID
                          where asset.L1LocCode == collection.L1LocCode
                          select new SearchViewModel
                          {
                              AssetNumber = asset.AssetNumber,
                              AssetDescription = asset.AssetDescription,
                              Group = asset.L1Category.L1CatName,
                              DepreciationRate = asset.L1Category.DepreciationRate,
                              Room_No = asset.L3Location.L3LocName,
                              BookValue = "Not Available",
                              NetbookValue = purchases.NetbookValue,
                              ValueDate = "Not Available",
                              DateOfPurchase = purchases.DateofPurchase.Value,
                              UnitPrice = purchases.UnitPrice,
                              DepreciationDays = System.Data.Entity.DbFunctions.DiffDays(purchases.DateofPurchase.Value, collection.DateOfDepreciation),
                              DepreciationAmount = 0,
                              DateOfDepreciation = collection.DateOfDepreciation,
                              NewNetBookValue = 0

                          }).ToList();

            foreach (var item in query1)
            {
                var days = item.DepreciationDays;
                var itemRate = Convert.ToDouble(item.DepreciationRate);
                double completeDays = (100 / itemRate);
                double finalDay = completeDays * 365;
                if (item.DepreciationDays > finalDay)
                {
                    item.DepreciationDays = Convert.ToInt32(finalDay);
                    var valex = Convert.ToInt32(item.UnitPrice) * item.DepreciationRate / 100;
                    double valep = Convert.ToDouble(item.DepreciationDays) / 365;
                    var val = valex * valep;
                    item.DepreciationAmount = Convert.ToInt32(val);
                    item.NewNetBookValue = Convert.ToInt32(Convert.ToInt32(item.NetbookValue) - val);
                }
                else
                {
                    var valex = Convert.ToInt32(item.UnitPrice) * item.DepreciationRate / 100;
                    double valep = Convert.ToDouble(item.DepreciationDays) / 365;
                    var val = valex * valep;
                    item.DepreciationAmount = Convert.ToInt32(val); ;
                    item.NewNetBookValue = Convert.ToInt32(Convert.ToInt32(item.NetbookValue) - val);
                }
            }

            if (query1.Count == 0)
            {
                query1 = (from asset in unityOfWork.db.Assets
                          where asset.L1LocCode == collection.L1LocCode
                          select new SearchViewModel
                          {
                              AssetNumber = asset.AssetNumber,
                              AssetDescription = asset.AssetDescription,
                              Group = asset.L1Category.L1CatName,
                              DepreciationRate = asset.L1Category.DepreciationRate,
                              Room_No = asset.L3Location.L3LocName,
                              BookValue = "Not Available",
                              NetbookValue = asset.NetBookValue,
                              ValueDate = "Not Available",
                              UnitPrice = "NONE",
                              DepreciationDays = 0,
                              DepreciationAmount = 0,
                              DateOfDepreciation = collection.DateOfDepreciation

                          }).ToList();

                return query1;
            }
            return query1;
        }

        public string SaveDepreciation(AssetViewModel collection)
        {
            var query1 = (from asset in unityOfWork.db.Assets
                          join assetPurchase in unityOfWork.db.AssetPurchases on asset.UniqueID equals assetPurchase.UniqueID
                          join purchases in unityOfWork.db.PurchaseDetails on assetPurchase.PurchaseID equals purchases.PurchaseID
                          where asset.L1LocCode == collection.L1LocCode
                          select new SearchViewModel
                          {
                              L1LocCode = collection.L1LocCode,
                              UniqueID = asset.UniqueID,
                              AssetNumber = asset.AssetNumber,
                              AssetDescription = asset.AssetDescription,
                              Group = asset.L1Category.L1CatName,
                              DepreciationRate = asset.L1Category.DepreciationRate,
                              Room_No = asset.L3Location.L3LocName,
                              BookValue = "Not Available",
                              NetbookValue = purchases.NetbookValue,
                              ValueDate = "Not Available",
                              DateOfPurchase = purchases.DateofPurchase.Value,
                              UnitPrice = purchases.UnitPrice,
                              DepreciationDays = System.Data.Entity.DbFunctions.DiffDays(purchases.DateofPurchase.Value, collection.DateOfDepreciation),
                              DepreciationAmount = 0,
                              DateOfDepreciation = collection.DateOfDepreciation,
                              NewNetBookValue = 0

                          }).ToList();

            foreach (var item in query1)
            {
                var days = item.DepreciationDays;
                var itemRate = Convert.ToDouble(item.DepreciationRate);
                double completeDays = (100 / itemRate);
                double finalDay = completeDays * 365;
                if (item.DepreciationDays > finalDay)
                {
                    item.DepreciationDays = Convert.ToInt32(finalDay);
                    var valex = Convert.ToInt32(item.UnitPrice) * item.DepreciationRate / 100;
                    double valep = Convert.ToDouble(item.DepreciationDays) / 365;
                    var val = valex * valep;
                    item.DepreciationAmount = Convert.ToInt32(val);
                    item.NewNetBookValue = Convert.ToInt32(Convert.ToInt32(item.NetbookValue) - val);
                }
                else
                {
                    var valex = Convert.ToInt32(item.UnitPrice) * item.DepreciationRate / 100;
                    double valep = Convert.ToDouble(item.DepreciationDays) / 365;
                    var val = valex * valep;
                    item.DepreciationAmount = Convert.ToInt32(val); ;
                    item.NewNetBookValue = Convert.ToInt32(Convert.ToInt32(item.NetbookValue) - val);
                }
            }

            if (query1.Count != 0)
            {
                AssetDepreciation Saving = new AssetDepreciation();
                foreach (var item in query1)
                {

                    Saving.UniqueID = decimal.Parse(item.UniqueID);
                    Saving.L1LocCode = item.L1LocCode;
                    Saving.DepreciationDate = collection.DateOfDepreciation;
                    Saving.DepreciationRate = (item.DepreciationRate).ToString();
                    Saving.DepreciationAmount = null;
                    Saving.DepreciationDays = item.DepreciationDays;
                    Saving.NetBookValue = item.NewNetBookValue.ToString();
                    Saving.BookValue = item.NetbookValue;
                    Saving.ValueDate = Convert.ToDateTime(item.DateOfDepreciation);
                    assetDescriptionRepository.Add(Saving);
                    message = unityOfWork.Commit();
                }
                return message;
            }
            return message = "Not Added";
        }

        public IEnumerable<DepreciationViewModel> ReturnDepreciationDates(AssetViewModel collection)
        {
            var dates = (from date in unityOfWork.db.AssetDepreciations where date.L1LocCode == collection.L1LocCode select new DepreciationViewModel() { DepreciationDate = date.DepreciationDate }).Distinct();
            return dates;

        }

        //public IEnumerable<DepreciationViewModel> ReturnDepreciation(AssetViewModel collection)
        //{
        //   // AssetDepreciation depp = new AssetDepreciation();
        //    var getDepreciation = (from dep in unityOfWork.db.AssetDepreciations
        //                           where dep.L1LocCode == collection.L1LocCode
        //                           select new DepreciationViewModel()
        //                           {
        //                               DepreciationDate = dep.DepreciationDate,
        //                               AssetDescription = dep.Asset.AssetDescription,
        //                               L1LocCode = dep.L1LocCode,
        //                               BookValue = dep.BookValue,
        //                               DepreciationAmount = dep.DepreciationAmount,
        //                               DepreciationDays = dep.DepreciationDays,
        //                               DepreciationRate = dep.DepreciationRate,
        //                               NetBookValue = dep.NetBookValue,
        //                               ValueDate = dep.ValueDate,
        //                               UniqueID = dep.Asset.AssetNumber
        //                           });
        //    return getDepreciation;
        //}


        public IEnumerable<DepreciationViewModel> ReturnDepreciation(AssetViewModel collection)
        {
            throw new NotImplementedException();
        }
    }
}
