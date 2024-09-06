using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Data;
using FAS.Infrastructure.Common;
using FAS.Infrastructure.Repository;
using FAS.SharedModel;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;

namespace FAS.Adapter
{
    public class DisposalAdapter
    {
        private IDisposalRepository disposableRepository;
        private IDisposalNumberRepository disposalNumberRepository;
        private IUserRepository userRepository;
        private IAssetRepository assetRepository;
        private IDisposalRemarks remarksRepository;
        private IUnityOfWork unityOfWork;

        public DisposalAdapter()
        {
            unityOfWork = new UnityOfWork(new DatabaseFactory());
            disposableRepository = new DisposalRepository(unityOfWork.instance);
            disposalNumberRepository = new DisposalNumberRepository(unityOfWork.instance);
            userRepository = new UserRepository(unityOfWork.instance);
            assetRepository = new AssetRepository(unityOfWork.instance);
            remarksRepository = new DisposalRemarks(unityOfWork.instance);
        }

        public string Processing(DisposalViewModel collection)
        {
            var user = userRepository.GetById(collection.ProcessedBy);
            if (user.Password == collection.Password)
            {
                string DisposalNumber = IsDisposalNumberExsist(collection.L1LocCode);
                AssetDisposal Process = new AssetDisposal()
                {
                    DisposalNumber = DisposalNumber,
                    L1LocCode = collection.L1LocCode,
                    DateOfProcessing = collection.DateOfProcessing,
                    ProcessingRemarks = collection.ProcessingRemarks,
                    ProcessedBy = collection.ProcessedBy,
                    ReviewedBy = collection.ProcessedBy,
                    VerifiedBy = collection.ProcessedBy,
                    AgreedBy = collection.ProcessedBy,
                    ValidatedBy = collection.ProcessedBy,
                    ApprovedAMBy = collection.ProcessedBy,
                    ApprovedBy = collection.ProcessedBy,
                    ReProcessedBy = collection.ProcessedBy,
                    DateOfDisposal = collection.DateOfDisposal,
                    DeniedBy = collection.ProcessedBy,
                    Status = "PROCESS",
                    DisposalSaleValue = collection.DisposalSaleValue
                };
                disposableRepository.Add(Process);
                //string[] assets = Regex.Split(collection.AssetNumber, ",");

                foreach (var item in collection.Assets)
                {
                    DisposalNumber Add = new DisposalNumber()
                    {
                        AssetDisposalCode = DisposalNumber + item.AssetNumber,
                        UniqueID = item.AssetNumber,
                        DisposalNumber1 = DisposalNumber
                    };
                    disposalNumberRepository.Add(Add);
                    var asset = (from a in unityOfWork.db.Assets where a.UniqueID == item.AssetNumber && a.L1LocCode == collection.L1LocCode select a).FirstOrDefault();
                    asset.UniqueID = item.AssetNumber;
                    asset.Depreciated = item.Depreciated;
                    asset.NetBookValue = item.NetbookValue;
                    asset.Status = "DISPOSAL PROCESS";
                    asset.DisposedOn = collection.DateOfDisposal;
                    assetRepository.Update(asset);
                }

                DisposalRemark Remarks = new DisposalRemark()
                {
                    RemarkLevel = "PROCESSING",
                    DisposalNumber = DisposalNumber,
                    Date = collection.DateOfDisposal,

                };

                string message = unityOfWork.Commit();

                //DisposalViewModel EmailParam = new DisposalViewModel();
                //EmailParam.ACTOR = "Validator";
                //EmailParam.DisposalNumber = DisposalNumber;
                //EmailParam.ValidEmail = collection.ValidEmail;
                //Email(EmailParam);

                collection.ACTOR = "Validator";
                collection.DisposalNumber = DisposalNumber;
                Email(collection);

                return DisposalNumber;
            }
            return "Incorrect Password";
        }

        public string ReProcessing(DisposalViewModel collection)
        {
            var user = userRepository.GetById(collection.ProcessedBy);
            if (user.Password == collection.Password)
            {
                var DisposalAsset = (from DA in unityOfWork.db.AssetDisposals where DA.DisposalNumber == collection.DisposalNumber select DA).FirstOrDefault();
                DisposalAsset.DateOfReProcessing = Convert.ToString(DateTime.Now.Date);
                DisposalAsset.ReprocessingRemarks = collection.ReprocessingRemarks;
                DisposalAsset.ReProcessedBy = collection.ProcessedBy;
                DisposalAsset.Status = "REPROCESS";
                disposableRepository.Update(DisposalAsset);

                List<string> AssetDelete = new List<string>();

                //string[] assetC = Regex.Split(collection.AssetNumber, ",");

                var assetS = (from DN in unityOfWork.db.DisposalNumbers where DN.DisposalNumber1 == collection.DisposalNumber select DN).ToList();

                foreach (var i in assetS)
                {
                    AssetDelete.Add(i.UniqueID);
                }

                foreach (var assets in assetS)
                {
                    foreach (var assetc in collection.Assets)
                    {
                        if (assets.UniqueID == assetc.AssetNumber)
                        {
                            AssetDelete.Remove(assets.UniqueID);
                        }
                    }
                }

                if (AssetDelete.Count != 0)
                {
                    foreach (var item in AssetDelete)
                    {
                        var delete = (from DN in unityOfWork.db.DisposalNumbers where DN.DisposalNumber1 == collection.DisposalNumber && DN.UniqueID == item select DN).FirstOrDefault();
                        unityOfWork.db.DisposalNumbers.Remove(delete);
                        var asset = (from a in unityOfWork.db.Assets where a.UniqueID == item && a.L1LocCode == collection.L1LocCode select a).FirstOrDefault();
                        asset.UniqueID = asset.UniqueID;
                        asset.Status = "ACTIVE";
                        assetRepository.Update(asset);
                    }
                }

                foreach (var item in collection.Assets)
                {
                    var asset = (from a in unityOfWork.db.Assets where a.UniqueID == item.AssetNumber && a.L1LocCode == collection.L1LocCode select a).FirstOrDefault();
                    asset.UniqueID = asset.UniqueID;
                    asset.Status = "DISPOSAL REPROCESSING";
                    asset.Depreciated = item.Depreciated;
                    asset.NetBookValue = item.NetbookValue;
                    assetRepository.Update(asset);
                }
                string message = unityOfWork.Commit();
                return message;
            }
            return "Incorrect Password";
        }

        public string IsDisposalNumberExsist(string L1LocCode)
        {
            Random random = new Random();
            DateTime dt = DateTime.Now;
            string Year = dt.Year.ToString();
            string number = Convert.ToString(random.Next(1000, 9999));
            string DisposalNumber = L1LocCode + number + Year;

            var Number = (from disposal in unityOfWork.db.AssetDisposals
                          where disposal.DisposalNumber == DisposalNumber
                          select disposal).ToList();
            if (Number.Count == 0)
            {
                return DisposalNumber;
            }
            return IsDisposalNumberExsist(L1LocCode);
        }

        public string Review(DisposalViewModel collection)
        {
            var user = userRepository.GetById(collection.ReviewedBy);
            if (user.Password == collection.Password)
            {
                var DisposalAsset = (from DA in unityOfWork.db.AssetDisposals where DA.DisposalNumber == collection.DisposalNumber select DA).FirstOrDefault();
                DisposalAsset.DateOfReview = collection.DateOfReview;
                DisposalAsset.ReviewRemarks = collection.ReviewRemarks;
                DisposalAsset.ReviewedBy = collection.ReviewedBy;
                DisposalAsset.Status = "REVIEW";
                disposableRepository.Update(DisposalAsset);

                var AssetNum = (from DN in unityOfWork.db.DisposalNumbers where DN.DisposalNumber1 == collection.DisposalNumber select DN).ToList();

                foreach (var item in AssetNum)
                {
                    var asset = (from a in unityOfWork.db.Assets where a.UniqueID == item.UniqueID && a.L1LocCode == collection.L1LocCode select a).FirstOrDefault();
                    asset.UniqueID = asset.UniqueID;
                    asset.Status = "DISPOSAL REVIEW";
                    assetRepository.Update(asset);
                }
                string message = unityOfWork.Commit();

                collection.ACTOR = "Reviewer";
                Email(collection);

                return message;
            }
            return "Incorrect Password";
        }

        public string Verification(DisposalViewModel collection)
        {
            var user = userRepository.GetById(collection.VerifiedBy);
            if (user.Password == collection.Password)
            {
                var DisposalAsset = (from DA in unityOfWork.db.AssetDisposals where DA.DisposalNumber == collection.DisposalNumber select DA).FirstOrDefault();
                DisposalAsset.DateOfVerification = collection.DateOfVerification;
                DisposalAsset.VerificationRemarks = collection.VerificationRemarks;
                DisposalAsset.VerifiedBy = collection.VerifiedBy;
                DisposalAsset.Status = "VERIFIED";
                disposableRepository.Update(DisposalAsset);

                var AssetNum = (from DN in unityOfWork.db.DisposalNumbers where DN.DisposalNumber1 == collection.DisposalNumber select DN).ToList();

                foreach (var item in AssetNum)
                {
                    var asset = (from a in unityOfWork.db.Assets where a.UniqueID == item.UniqueID && a.L1LocCode == collection.L1LocCode select a).FirstOrDefault();
                    asset.UniqueID = asset.UniqueID;
                    asset.Status = "DISPOSAL VERIFICATION";
                    assetRepository.Update(asset);
                }
                string message = unityOfWork.Commit();

                var Verifier = (from Users in unityOfWork.db.Users
                                join UserRoles in unityOfWork.db.UserRoles on Users.UserID equals UserRoles.UserID
                                join UserCompany in unityOfWork.db.UserCompanies on Users.UserID equals UserCompany.UserID
                                where UserRoles.PermissionID == 41 && UserCompany.L1LocCode == collection.L1LocCode
                                select new UserViewModel()
                                {
                                    Email = Users.Email
                                });

                if (Verifier != null)
                {
                    //DisposalViewModel EmailParam = new DisposalViewModel();
                    //EmailParam.ACTOR = "Verifier";
                    //EmailParam.DisposalNumber = collection.DisposalNumber;
                    //foreach (var item in Verifier)
                    //{
                    //    EmailParam.ValidEmail = item.Email;
                    //    Email(EmailParam);
                    //}

                    collection.ACTOR = "Verifier";
                    Email(collection);

                }

                return message;
            }
            return "Incorrect Password";
        }

        public string Agreement(DisposalViewModel collection)
        {
            var user = userRepository.GetById(collection.AgreedBy);
            if (user.Password == collection.Password)
            {
                var DisposalAsset = (from DA in unityOfWork.db.AssetDisposals where DA.DisposalNumber == collection.DisposalNumber select DA).FirstOrDefault();
                DisposalAsset.DateOfAgreement = collection.DateOfAgreement;
                DisposalAsset.AgreementRemarks = collection.AgreementRemarks;
                DisposalAsset.AgreedBy = collection.AgreedBy;
                DisposalAsset.Status = "AGREED";
                disposableRepository.Update(DisposalAsset);

                var AssetNum = (from DN in unityOfWork.db.DisposalNumbers where DN.DisposalNumber1 == collection.DisposalNumber select DN).ToList();

                foreach (var item in AssetNum)
                {
                    var asset = (from a in unityOfWork.db.Assets where a.UniqueID == item.UniqueID && a.L1LocCode == collection.L1LocCode select a).FirstOrDefault();
                    asset.UniqueID = asset.UniqueID;
                    asset.Status = "DISPOSAL AGREEMENT";
                    assetRepository.Update(asset);
                }
                string message = unityOfWork.Commit();

                var Agreement = (from Users in unityOfWork.db.Users
                                 join UserRoles in unityOfWork.db.UserRoles on Users.UserID equals UserRoles.UserID
                                 join UserCompany in unityOfWork.db.UserCompanies on Users.UserID equals UserCompany.UserID
                                 where UserRoles.PermissionID == 41 && UserCompany.L1LocCode == collection.L1LocCode
                                 select new UserViewModel()
                                 {
                                     Email = Users.Email
                                 });

                if (Agreement != null)
                {
                    //DisposalViewModel EmailParam = new DisposalViewModel();
                    //EmailParam.ACTOR = "Agree";
                    //EmailParam.DisposalNumber = collection.DisposalNumber;
                    //foreach (var item in Agreement)
                    //{
                    //    EmailParam.ValidEmail = item.Email;
                    //    Email(EmailParam);
                    //}

                    collection.ACTOR = "Agree";
                    Email(collection);

                }

                return message;
            }
            return "Incorrect Password";
        }

        public string Validation(DisposalViewModel collection)
        {
            var user = userRepository.GetById(collection.ValidatedBy);
            if (user.Password == collection.Password)
            {
                var DisposalAsset = (from DA in unityOfWork.db.AssetDisposals where DA.DisposalNumber == collection.DisposalNumber select DA).FirstOrDefault();
                DisposalAsset.DateOfValidation = collection.DateOfValidation;
                DisposalAsset.ValidationRemarks = collection.ValidationRemarks;
                DisposalAsset.ValidatedBy = collection.ValidatedBy;
                DisposalAsset.Status = "VALIDATE";
                disposableRepository.Update(DisposalAsset);

                //var AssetNum = (from DN in unityOfWork.db.DisposalNumbers where DN.DisposalNumber1 == collection.DisposalNumber select DN).ToList();

                List<string> AssetDelete = new List<string>();

                //string[] assetC = Regex.Split(collection.AssetNumber, ",");

                var assetS = (from DN in unityOfWork.db.DisposalNumbers where DN.DisposalNumber1 == collection.DisposalNumber select DN).ToList();

                foreach (var i in assetS)
                {
                    AssetDelete.Add(i.UniqueID);
                }

                foreach (var assets in assetS)
                {
                    foreach (var assetc in collection.Assets)
                    {
                        if (assets.UniqueID == assetc.AssetNumber)
                        {
                            AssetDelete.Remove(assets.UniqueID);
                        }
                    }
                }

                if (AssetDelete.Count != 0)
                {
                    foreach (var item in AssetDelete)
                    {
                        var delete = (from DN in unityOfWork.db.DisposalNumbers where DN.DisposalNumber1 == collection.DisposalNumber && DN.UniqueID == item select DN).FirstOrDefault();
                        unityOfWork.db.DisposalNumbers.Remove(delete);
                        var asset = (from a in unityOfWork.db.Assets where a.UniqueID == item && a.L1LocCode == collection.L1LocCode select a).FirstOrDefault();
                        asset.UniqueID = asset.UniqueID;
                        asset.Status = "ACTIVE";
                        assetRepository.Update(asset);
                    }
                }

                foreach (var item in collection.Assets)
                {
                    var asset = (from a in unityOfWork.db.Assets where a.UniqueID == item.AssetNumber && a.L1LocCode == collection.L1LocCode select a).FirstOrDefault();
                    asset.UniqueID = asset.UniqueID;
                    asset.Status = "DISPOSAL VALIDATION";
                    asset.Depreciated = item.Depreciated;
                    asset.NetBookValue = item.NetbookValue;
                    assetRepository.Update(asset);
                }
                string message = unityOfWork.Commit();

                var Reviewer = (from Users in unityOfWork.db.Users
                                join UserRoles in unityOfWork.db.UserRoles on Users.UserID equals UserRoles.UserID
                                join UserCompany in unityOfWork.db.UserCompanies on Users.UserID equals UserCompany.UserID
                                where UserRoles.PermissionID == 40 && UserCompany.L1LocCode == collection.L1LocCode
                                select new UserViewModel()
                                {
                                    Email = Users.Email
                                });

                if (Reviewer != null)
                {
                    //DisposalViewModel EmailParam = new DisposalViewModel();
                    //EmailParam.ACTOR = "Reviewer";
                    //EmailParam.DisposalNumber = collection.DisposalNumber;
                    //foreach (var item in Reviewer)
                    //{
                    //    EmailParam.ValidEmail = item.Email;
                    //    Email(EmailParam);
                    //}

                    collection.ACTOR = "Reviewer";
                    Email(collection);

                }

                return message;
            }
            return "Incorrect Password";
        }

        public string Approval(DisposalViewModel collection)
        {
            var user = userRepository.GetById(collection.ApprovedBy);
            if (user.Password == collection.Password)
            {
                var DisposalAsset = (from DA in unityOfWork.db.AssetDisposals where DA.DisposalNumber == collection.DisposalNumber select DA).FirstOrDefault();
                DisposalAsset.DateOfApproval = collection.DateOfApproval;
                DisposalAsset.ApprovalRemarks = collection.ApprovalRemarks;
                DisposalAsset.ApprovedBy = collection.ApprovedBy;
                DisposalAsset.Status = "APPROVE";
                disposableRepository.Update(DisposalAsset);

                var AssetNum = (from DN in unityOfWork.db.DisposalNumbers where DN.DisposalNumber1 == collection.DisposalNumber select DN).ToList();

                foreach (var item in AssetNum)
                {
                    var asset = (from a in unityOfWork.db.Assets where a.UniqueID == item.UniqueID && a.L1LocCode == collection.L1LocCode select a).FirstOrDefault();
                    asset.UniqueID = asset.UniqueID;
                    asset.Status = "DISPOSAL APPROVAL";
                    assetRepository.Update(asset);
                }
                string message = unityOfWork.Commit();

                var Approver = (from Users in unityOfWork.db.Users
                                join UserRoles in unityOfWork.db.UserRoles on Users.UserID equals UserRoles.UserID
                                join UserCompany in unityOfWork.db.UserCompanies on Users.UserID equals UserCompany.UserID
                                where UserRoles.PermissionID == 41 && UserCompany.L1LocCode == collection.L1LocCode
                                select new UserViewModel()
                                {
                                    Email = Users.Email
                                });

                if (Approver != null)
                {
                    //DisposalViewModel EmailParam = new DisposalViewModel();
                    //EmailParam.ACTOR = "Approver";
                    //EmailParam.DisposalNumber = collection.DisposalNumber;
                    //foreach (var item in Approver)
                    //{
                    //    EmailParam.ValidEmail = item.Email;
                    //    Email(EmailParam);
                    //}

                    collection.ACTOR = "Approver";
                    Email(collection);

                }

                return message;
            }
            return "Incorrect Password";
        }

        public string ApprovalAM(DisposalViewModel collection)
        {
            var user = userRepository.GetById(collection.ApprovedAMBy);
            if (user.Password == collection.Password)
            {
                var DisposalAsset = (from DA in unityOfWork.db.AssetDisposals where DA.DisposalNumber == collection.DisposalNumber select DA).FirstOrDefault();
                DisposalAsset.DateOfApprovalAM = collection.DateOfApprovalAM;
                DisposalAsset.ApprovalAMRemarks = collection.ApprovalAMRemarks;
                DisposalAsset.ApprovedAMBy = collection.ApprovedAMBy;
                DisposalAsset.Status = "APPROVE AM";
                disposableRepository.Update(DisposalAsset);

                var AssetNum = (from DN in unityOfWork.db.DisposalNumbers where DN.DisposalNumber1 == collection.DisposalNumber select DN).ToList();

                foreach (var item in AssetNum)
                {
                    var asset = (from a in unityOfWork.db.Assets where a.UniqueID == item.UniqueID && a.L1LocCode == collection.L1LocCode select a).FirstOrDefault();
                    asset.UniqueID = asset.UniqueID;
                    asset.Status = "DISPOSED";//"DISPOSAL APPROVAL AM";
                    assetRepository.Update(asset);
                }
                string message = unityOfWork.Commit();

                collection.ACTOR = "APPROVE AM";
                Email(collection);

                return message;
            }
            return "Incorrect Password";
        }

        public IEnumerable<DisposalViewModel> DisposalNumberList(DisposalViewModel collection)
        {
            var DisposalNumber1 = (from DN in unityOfWork.db.AssetDisposals
                                   where DN.L1LocCode == collection.L1LocCode
                                   select new DisposalViewModel
                                   {
                                       DisposalNumber = DN.DisposalNumber,
                                       Status = DN.Status,
                                       DateOfProcessing = DN.DateOfProcessing,
                                       DateOfDisposal = DN.DateOfDisposal
                                   }).ToList();

            return DisposalNumber1;
        }

        public IEnumerable<DisposalViewModel> DateOfDisposalList(DisposalViewModel collection)
        {
            var DateOfDisposal = (from DN in unityOfWork.db.AssetDisposals where DN.L1LocCode == collection.L1LocCode select new DisposalViewModel { DateOfDisposal = DN.DateOfDisposal, Status = DN.Status }).ToList();
            return DateOfDisposal;
        }

        public IEnumerable<DisposalViewModel> AssetNumberList(DisposalViewModel collection)
        {
            var AssetNumbers = (from DN in unityOfWork.db.DisposalNumbers where DN.DisposalNumber1 == collection.DisposalNumber select new DisposalViewModel { AssetNumber = DN.Asset.AssetNumber }).ToList();
            return AssetNumbers;
        }

        public DisposalViewModel DisposalTransaction(DisposalViewModel collection)
        {
            if (collection.DisposalNumber != null)
            {
                var AssetNumbers = (from DN in unityOfWork.db.DisposalNumbers join As in unityOfWork.db.Assets on DN.UniqueID equals As.UniqueID where DN.DisposalNumber1 == collection.DisposalNumber select new AssetNumberViewModel { AssetNumber = DN.Asset.AssetNumber, Depreciated = As.Depreciated, NetbookValue = As.NetBookValue }).ToList();
                var Transaction = (from dp in unityOfWork.db.AssetDisposals
                                   where dp.DisposalNumber == collection.DisposalNumber
                                   select new DisposalViewModel
                                   {
                                       DisposalNumber = dp.DisposalNumber,
                                       DateOfDisposal = dp.DateOfDisposal,
                                       DateOfProcessing = dp.DateOfProcessing,
                                       AgreedBy = dp.AgreedBy,
                                       AgreementRemarks = dp.AgreementRemarks,
                                       ApprovalRemarks = dp.ApprovalRemarks,
                                       ApprovedBy = dp.ApprovedBy,
                                       DateOfAgreement = dp.DateOfAgreement,
                                       DateOfApproval = dp.DateOfApproval,
                                       DateOfReview = dp.DateOfReview,
                                       DateOfValidation = dp.DateOfValidation,
                                       DateOfVerification = dp.DateOfVerification,
                                       DeniedReason = dp.DeniedReason,
                                       ProcessedBy = dp.ProcessedBy,
                                       ProcessingRemarks = dp.ProcessingRemarks,
                                       VerifiedBy = dp.VerifiedBy,
                                       VerificationRemarks = dp.VerificationRemarks,
                                       ValidationRemarks = dp.ValidationRemarks,
                                       ValidatedBy = dp.ValidatedBy,
                                       ReviewedBy = dp.ReviewedBy,
                                       ReviewRemarks = dp.ReviewRemarks,
                                       Status = dp.Status,
                                       DeniedBy = dp.User6.UserName,
                                       ReProcessedBy = dp.ReProcessedBy,
                                       ReprocessingRemarks = dp.ReprocessingRemarks,
                                       DateOfReProcessing = dp.DateOfReProcessing,
                                       ProcessedByName = dp.User.FirstName + " " + dp.User.LastName,
                                       ReviewedByName = dp.User1.FirstName + " " + dp.User1.LastName,
                                       VerifiedByName = dp.User2.FirstName + " " + dp.User2.LastName,
                                       AgreedByName = dp.User3.FirstName + " " + dp.User3.LastName,
                                       ValidatedByName = dp.User4.FirstName + " " + dp.User4.LastName,
                                       ApprovedByName = dp.User5.FirstName + " " + dp.User5.LastName,
                                       DisposalSaleValue = dp.DisposalSaleValue
                                   }).FirstOrDefault();
                Transaction.Assets = AssetNumbers;
                List<SearchViewModel> result = new List<SearchViewModel>();
                foreach (var item in AssetNumbers)
                {
                    var disposedAsset = (from DA in unityOfWork.db.Assets
                                         join AP in unityOfWork.db.AssetPurchases on DA.UniqueID equals AP.UniqueID
                                         join PD in unityOfWork.db.PurchaseDetails on AP.PurchaseID equals PD.PurchaseID
                                         where DA.L1LocCode == collection.L1LocCode && DA.AssetNumber == item.AssetNumber
                                         select new SearchViewModel
                                         {
                                             Status = DA.Status,
                                             AssetNumber = DA.AssetNumber,
                                             DisposalNumber = collection.DisposalNumber,
                                             AssetDescription = DA.AssetDescription,
                                             Group = DA.L1Category.L1CatName,
                                             Category = DA.L2Category.L2CatName,
                                             Section = DA.L2Location.L2LocName,
                                             Room_No = DA.L3Location.L3LocName,
                                             DisposedOn = DA.DisposedOn,
                                             Image = DA.L3CatCode,
                                             UnitPrice = PD.UnitPrice,
                                             Depreciated = DA.Depreciated,
                                             NetbookValue = DA.NetBookValue

                                         }).FirstOrDefault();
                    result.Add(disposedAsset);
                }
                Transaction.Asset = result.ToList();

                return Transaction;
            }
            else
            {
                var AssetNumbers = (from DN in unityOfWork.db.DisposalNumbers
                                    join AS in unityOfWork.db.Assets on DN.UniqueID equals AS.UniqueID
                                    join AD in unityOfWork.db.AssetDisposals on DN.DisposalNumber1 equals AD.DisposalNumber
                                    where AS.L1LocCode == collection.L1LocCode
                                    select new SearchViewModel
                                    {
                                        Status = AS.Status,
                                        DisposalNumber = AD.DisposalNumber,
                                        DateOfDisposal = AD.DateOfDisposal,
                                        AssetNumber = DN.Asset.AssetNumber,
                                        AssetDescription = AS.AssetDescription,
                                        Group = AS.L1Category.L1CatName,
                                        Category = AS.L2Category.L2CatName,
                                        Section = AS.L2Location.L2LocName,
                                        Room_No = AS.L3Location.L3LocName,
                                        Room_Type = AS.L4Location.L4LocName,
                                        Floor = AS.L5Location.L5LocName,
                                        Image = AS.L3CatCode,
                                        Depreciated = AS.Depreciated,
                                        NetbookValue = AS.NetBookValue,
                                        DisposedOn = AS.DisposedOn
                                    }).ToList();
                DisposalViewModel Transaction = new DisposalViewModel();
                Transaction.Asset = AssetNumbers;
                return Transaction;
            }
        }

        public string DisposalDenied(DisposalViewModel collection)
        {
            var user = userRepository.GetById(collection.UserID);
            if (user.Password == collection.Password)
            {
                var DisposalAsset = (from DA in unityOfWork.db.AssetDisposals where DA.DisposalNumber == collection.DisposalNumber select DA).FirstOrDefault();

                if (collection.DateOfReview != null)
                {
                    DisposalAsset.DateOfReview = collection.DateOfReview;
                    DisposalAsset.ReviewRemarks = collection.ReviewRemarks;
                    DisposalAsset.ReviewedBy = collection.ReviewedBy;
                    DisposalAsset.DeniedBy = collection.ReviewedBy;
                    DisposalAsset.DeniedReason = collection.DeniedReason;
                    DisposalAsset.Status = "REVIEW DECLINED";
                }
                else if (collection.DateOfVerification != null)
                {
                    DisposalAsset.DateOfVerification = collection.DateOfVerification;
                    DisposalAsset.VerificationRemarks = collection.VerificationRemarks;
                    DisposalAsset.VerifiedBy = collection.VerifiedBy;
                    DisposalAsset.DeniedBy = collection.VerifiedBy;
                    DisposalAsset.DeniedReason = collection.DeniedReason;
                    DisposalAsset.Status = "VERIFICATION DECLINED";
                }
                else if (collection.DateOfAgreement != null)
                {
                    DisposalAsset.DateOfAgreement = collection.DateOfAgreement;
                    DisposalAsset.AgreementRemarks = collection.AgreementRemarks;
                    DisposalAsset.AgreedBy = collection.AgreedBy;
                    DisposalAsset.DeniedBy = collection.AgreedBy;
                    DisposalAsset.DeniedReason = collection.DeniedReason;
                    DisposalAsset.Status = "AGREE DECLINED";
                }
                else if (collection.DateOfValidation != null)
                {
                    List<string> AssetDelete = new List<string>();

                    //string[] assetC = Regex.Split(collection.AssetNumber, ",");

                    var assetS = (from DN in unityOfWork.db.DisposalNumbers where DN.DisposalNumber1 == collection.DisposalNumber select DN).ToList();

                    foreach (var i in assetS)
                    {
                        AssetDelete.Add(i.UniqueID);
                    }

                    foreach (var assets in assetS)
                    {
                        foreach (var assetc in collection.Assets)
                        {
                            if (assets.UniqueID == assetc.AssetNumber)
                            {
                                AssetDelete.Remove(assets.UniqueID);
                            }
                        }
                    }

                    if (AssetDelete.Count != 0)
                    {
                        foreach (var item in AssetDelete)
                        {
                            var delete = (from DN in unityOfWork.db.DisposalNumbers where DN.DisposalNumber1 == collection.DisposalNumber && DN.UniqueID == item select DN).FirstOrDefault();
                            unityOfWork.db.DisposalNumbers.Remove(delete);
                            var asset = (from a in unityOfWork.db.Assets where a.UniqueID == item && a.L1LocCode == collection.L1LocCode select a).FirstOrDefault();
                            asset.UniqueID = asset.UniqueID;
                            asset.Status = "ACTIVE";
                            assetRepository.Update(asset);
                        }
                    }

                    DisposalAsset.DateOfValidation = collection.DateOfValidation;
                    DisposalAsset.ValidationRemarks = collection.ValidationRemarks;
                    DisposalAsset.ValidatedBy = collection.ValidatedBy;
                    DisposalAsset.DeniedBy = collection.ValidatedBy;
                    DisposalAsset.DeniedReason = collection.DeniedReason;
                    DisposalAsset.Status = "VALIDATION DECLINED";
                }
                else if (collection.DateOfApproval != null)
                {
                    DisposalAsset.DateOfApproval = collection.DateOfApproval;
                    DisposalAsset.ApprovalRemarks = collection.ApprovalRemarks;
                    DisposalAsset.ApprovedBy = collection.ApprovedBy;
                    DisposalAsset.DeniedBy = collection.ApprovedBy;
                    DisposalAsset.DeniedReason = collection.DeniedReason;
                    DisposalAsset.Status = "APPROVAL DECLINED";
                }
                else if (collection.DateOfApprovalAM != null)
                {
                    DisposalAsset.DateOfApproval = collection.DateOfApprovalAM;
                    DisposalAsset.ApprovalRemarks = collection.ApprovalAMRemarks;
                    DisposalAsset.ApprovedBy = collection.ApprovedAMBy;
                    DisposalAsset.DeniedBy = collection.ApprovedAMBy;
                    DisposalAsset.DeniedReason = collection.DeniedReason;
                    DisposalAsset.Status = "APPROVAL AM DECLINED";
                }

                disposableRepository.Update(DisposalAsset);

                var AssetNum = (from DN in unityOfWork.db.DisposalNumbers
                                where DN.DisposalNumber1 == collection.DisposalNumber
                                select new DisposalViewModel()
                                {
                                    AssetDisposalCode = DN.AssetDisposalCode,
                                    DisposalNumber = DN.DisposalNumber1,
                                    UniqueID = DN.UniqueID
                                }).ToList();

                foreach (var item in AssetNum)
                {
                    var asset = (from a in unityOfWork.db.Assets where a.UniqueID == item.UniqueID && a.L1LocCode == collection.L1LocCode select a).FirstOrDefault();
                    asset.UniqueID = asset.UniqueID;
                    asset.Status = "DISPOSAL DECLINED";
                    assetRepository.Update(asset);
                }

                string message = unityOfWork.Commit();
                return message;
            }
            return "Incorrect Password";
        }

        public IEnumerable<UserViewModel> ListofValidators(AssetViewModel collection)
        {
            //select* from Users inner join UserRoles on Users.UserID = UserRoles.UserID inner join UserCompany on Users.UserID = UserCompany.UserID where PermissionID = 43 and L1LocCode = 'DEMO1'
            int CompanyID = 0;
            if (collection.L2LocCode != "true")
            {
                CompanyID = int.Parse(collection.L2LocCode);
            }
            var validators = (from Users in unityOfWork.db.Users
                              join UserRoles in unityOfWork.db.UserRoles on Users.UserID equals UserRoles.UserID
                              join UserCompany in unityOfWork.db.UserCompanies on Users.UserID equals UserCompany.UserID
                              where 
                                UserCompany.L1LocCode == collection.L1LocCode 
                                && UserRoles.PermissionID == 42 
                                && UserRoles.IsEdit == true                                 
                                && UserCompany.CompanyID == CompanyID 
                              select new UserViewModel()
                              {
                                  Email = Users.Email
                              });

            return validators;

        }

        public IEnumerable<UserViewModel> ListofReveiwer(AssetViewModel collection)
        {
            //select* from Users inner join UserRoles on Users.UserID = UserRoles.UserID inner join UserCompany on Users.UserID = UserCompany.UserID where PermissionID = 43 and L1LocCode = 'DEMO1'
            int CompanyID = 0;
            if (collection.L2LocCode != "true")
            {
                CompanyID = int.Parse(collection.L2LocCode);
            }
            var validators = (from Users in unityOfWork.db.Users
                              join UserRoles in unityOfWork.db.UserRoles on Users.UserID equals UserRoles.UserID
                              join UserCompany in unityOfWork.db.UserCompanies on Users.UserID equals UserCompany.UserID
                              where 
                                UserCompany.L1LocCode == collection.L1LocCode
                                && UserRoles.PermissionID == 39 
                                && UserRoles.IsEdit == true 
                                && UserCompany.CompanyID == CompanyID
                              select new UserViewModel()
                              {
                                  Email = Users.Email
                              });

            return validators;
        }
        public IEnumerable<UserViewModel> ListofVerifier(AssetViewModel collection)
        {
            //select* from Users inner join UserRoles on Users.UserID = UserRoles.UserID inner join UserCompany on Users.UserID = UserCompany.UserID where PermissionID = 43 and L1LocCode = 'DEMO1'
            int CompanyID = 0;
            if (collection.L2LocCode != "true")
            {
                CompanyID = int.Parse(collection.L2LocCode);
            }
            var validators = (from Users in unityOfWork.db.Users
                              join UserRoles in unityOfWork.db.UserRoles on Users.UserID equals UserRoles.UserID
                              join UserCompany in unityOfWork.db.UserCompanies on Users.UserID equals UserCompany.UserID
                              where 
                                UserCompany.L1LocCode == collection.L1LocCode 
                                && UserRoles.PermissionID == 40 
                                && UserRoles.IsEdit == true 
                                && UserCompany.CompanyID == CompanyID
                              select new UserViewModel()
                              {
                                  Email = Users.Email
                              });

            return validators;
        }
        public IEnumerable<UserViewModel> ListofAgreed_GM(AssetViewModel collection)
        {
            //select* from Users inner join UserRoles on Users.UserID = UserRoles.UserID inner join UserCompany on Users.UserID = UserCompany.UserID where PermissionID = 43 and L1LocCode = 'DEMO1'
            int CompanyID = 0;
            if (collection.L2LocCode != "true")
            {
                CompanyID = int.Parse(collection.L2LocCode);
            }
            var validators = (from Users in unityOfWork.db.Users
                              join UserRoles in unityOfWork.db.UserRoles on Users.UserID equals UserRoles.UserID
                              join UserCompany in unityOfWork.db.UserCompanies on Users.UserID equals UserCompany.UserID
                              where 
                                UserRoles.PermissionID == 41 
                                && UserRoles.IsEdit == true 
                                && UserCompany.L1LocCode == collection.L1LocCode 
                                && UserCompany.CompanyID == CompanyID
                              select new UserViewModel()
                              {
                                  Email = Users.Email
                              });

            return validators;
        }
        public IEnumerable<UserViewModel> ListofApproval_HO_Finance(AssetViewModel collection)
        {
            //select* from Users inner join UserRoles on Users.UserID = UserRoles.UserID inner join UserCompany on Users.UserID = UserCompany.UserID where PermissionID = 43 and L1LocCode = 'DEMO1'
            int CompanyID = 0;
            if (collection.L2LocCode != "true")
            {
                CompanyID = int.Parse(collection.L2LocCode);
            }
            var validators = (from Users in unityOfWork.db.Users
                              join UserRoles in unityOfWork.db.UserRoles on Users.UserID equals UserRoles.UserID
                              join UserCompany in unityOfWork.db.UserCompanies on Users.UserID equals UserCompany.UserID
                              where 
                                UserRoles.PermissionID == 43 
                                && UserRoles.IsEdit == true 
                                && UserCompany.L1LocCode == collection.L1LocCode 
                                && UserCompany.CompanyID == CompanyID
                              select new UserViewModel()
                              {
                                  Email = Users.Email
                              });

            return validators;
        }
        public IEnumerable<UserViewModel> ListofApproval_HO_AM_Finance(AssetViewModel collection)
        {
            //select* from Users inner join UserRoles on Users.UserID = UserRoles.UserID inner join UserCompany on Users.UserID = UserCompany.UserID where PermissionID = 43 and L1LocCode = 'DEMO1'
            int CompanyID = 0;
            if (collection.L2LocCode != "true")
            {
                CompanyID = int.Parse(collection.L2LocCode);
            }
            var validators = (from Users in unityOfWork.db.Users
                              join UserRoles in unityOfWork.db.UserRoles on Users.UserID equals UserRoles.UserID
                              join UserCompany in unityOfWork.db.UserCompanies on Users.UserID equals UserCompany.UserID
                              where 
                                UserRoles.PermissionID == 47 
                                && UserRoles.IsEdit == true 
                                && UserCompany.L1LocCode == collection.L1LocCode 
                                && UserCompany.CompanyID == CompanyID
                              select new UserViewModel()
                              {
                                  Email = Users.Email
                              });

            return validators;
        }

        public void Email(DisposalViewModel collection)
        {
            if (collection.ValidEmail != null)
            {
                var body = "<p>Dear {0}</p><p>You have a Disposal Document Ref # {1} awaiting your approval.</p><br><br><p>Please login to www.matrix-fas.com using <b>FIREFOX</b> and complete your transaction Approval.</p><br><br><p>Thank you</p><br><br><p>System Administrator</p><br><br><p>Matrix Fixed Asset Management Solution</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress(collection.ValidEmail));
                message.From = new MailAddress("support.fas@matrix-ams.com");
                message.Subject = "DISPOSAL APPROVAL";
                message.Body = string.Format(body, collection.ACTOR, collection.DisposalNumber);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "support.fas@matrix-ams.com",
                        Password = "Matass#5279"
                        //UserName = "zain.k@matrix-ams.com",
                        //Password = "Matrixam#2681"
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.1and1.com";
                    smtp.Port = 587;

                    try
                    {
                        smtp.Send(message);
                    }
                    catch (Exception e) { }
                }
            }
        }
    }
}
