using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Infrastructure.Common;
using FAS.Infrastructure.Repository;
using FAS.SharedModel;
using FAS.Data;

namespace FAS.Adapter
{
    public class GatePassAdapter
    {
        IGatePassRepository gatePassRepository;
        IAssetRepository assetRepository;
        IUserRepository userRepository;
        IUnityOfWork unityOfWork;

        public GatePassAdapter()
        {
            unityOfWork = new UnityOfWork(new DatabaseFactory());
            gatePassRepository = new GatePassRepository(unityOfWork.instance);
            assetRepository = new AssetRepository(unityOfWork.instance);
            userRepository = new UserRepository(unityOfWork.instance);
        }

        public string GatePassProcessing(GatePassViewModel collection)
        {
            var user = userRepository.GetById(collection.ProcessedBy);
            if (user.Password == collection.Password)
            {
                string GatePassTransactionCode = IsGatePassCodeExsist(collection.L1LocCode);

                GatePassTransaction Process = new GatePassTransaction()
                {
                    L1LocCode = collection.L1LocCode,
                    ProcessedBy = collection.ProcessedBy,
                    DateOfProcessing = collection.DateOfProcessing,
                    ReturnDate = collection.ReturnDate,
                    ReasonForMaintanence = collection.ReasonForMaintanence,
                    OtherReason = collection.OtherReason,
                    SupplierID = collection.SupplierID,
                    CostOfRepair = collection.CostOfRepair,
                    GatePassTransactionCode = GatePassTransactionCode,
                    UniqueID = collection.L1LocCode + collection.AssetNumber,
                    ApprovedBy = collection.ProcessedBy,
                    ReleasedBy = collection.ProcessedBy,
                    RecievedBy = collection.ProcessedBy

                };
                gatePassRepository.Add(Process);
                string Status = unityOfWork.Commit();
                var asset = (from a in unityOfWork.db.Assets where a.AssetNumber == collection.AssetNumber && a.L1LocCode == collection.L1LocCode select a).FirstOrDefault();
                Asset updateAsset = new Asset();
                asset.UniqueID = asset.UniqueID;
                asset.Status = "GP PROCESS";
                assetRepository.Update(asset);
                unityOfWork.Commit();
                return Status;
            }
            return "Password Incorrect";
        }

        public void GatePassReProcessing(GatePassViewModel collection)
        {
            var user = userRepository.GetById(collection.ProcessedBy);
            if (user.Password == collection.Password)
            {
                var GP = (from gatepass in unityOfWork.db.GatePassTransactions where gatepass.GatePassTransactionCode == collection.GatePassTransactionCode && gatepass.L1LocCode == collection.L1LocCode select gatepass).FirstOrDefault();

                GP.SupplierID = collection.SupplierID;
                GP.ReasonForMaintanence = collection.ReasonForMaintanence;
                GP.OtherReason = collection.OtherReason;
                GP.CostOfRepair = collection.CostOfRepair;
                GP.DateOfProcessing = collection.DateOfProcessing;
                GP.ReturnDate = collection.ReturnDate;
                GP.ProcessComment = collection.ProcessComment;
                gatePassRepository.Update(GP);
                unityOfWork.Commit();
                var asset = (from a in unityOfWork.db.Assets where a.AssetNumber == collection.AssetNumber && a.L1LocCode == collection.L1LocCode select a).FirstOrDefault();
                Asset updateAsset = new Asset();
                asset.UniqueID = asset.UniqueID;
                asset.Status = "GP REPROCESS";
                assetRepository.Update(asset);
                unityOfWork.Commit();
            }
        }

        public string GatePassApproval(GatePassViewModel collection)
        {
            var user = userRepository.GetById(collection.ApprovedBy);
            if (user.Password == collection.Password)
            {
                var GP = (from gatePass in unityOfWork.db.GatePassTransactions where gatePass.L1LocCode == collection.L1LocCode && gatePass.GatePassTransactionCode == collection.GatePassTransactionCode select gatePass).FirstOrDefault();
                GP.ApprovedBy = collection.ApprovedBy;
                GP.DateOfApproval = collection.DateOfApproval;
                gatePassRepository.Update(GP);
                unityOfWork.Commit();

                var asset = (from a in unityOfWork.db.Assets where a.AssetNumber == collection.AssetNumber && a.L1LocCode == collection.L1LocCode select a).FirstOrDefault();
                Asset updateAsset = new Asset();
                asset.UniqueID = asset.UniqueID;
                asset.Status = "GP APPROVED";
                assetRepository.Update(asset);
                unityOfWork.Commit();
                return "Asset in Approval";
            }
            return "Password Incorrect";
        }

        public string GatePassApprovalDeclined(GatePassViewModel collection)
        {
            var user = userRepository.GetById(collection.ApprovedBy);
            if (user.Password == collection.Password)
            { 
                var GP = (from gpt in unityOfWork.db.GatePassTransactions where gpt.GatePassTransactionCode == collection.GatePassTransactionCode && gpt.L1LocCode == collection.L1LocCode select gpt).FirstOrDefault();
            GP.ApprovalComment = collection.ApprovalComment;
            GP.ApprovedBy = collection.ApprovedBy;
            GP.DateOfApproval = collection.DateOfApproval;
            gatePassRepository.Update(GP);
            unityOfWork.Commit();

            var asset = (from a in unityOfWork.db.Assets where a.AssetNumber == collection.AssetNumber && a.L1LocCode == collection.L1LocCode select a).FirstOrDefault();
            Asset updateAsset = new Asset();
            asset.UniqueID = asset.UniqueID;
            asset.Status = "GP APPROVAL DENIED";
            assetRepository.Update(asset);
            unityOfWork.Commit();

            return "GP Approval Denied";
            }
            return "Password Incorrect";
        }

        public string GatePassRelease(GatePassViewModel collection)
        {
            var user = userRepository.GetById(collection.ReleasedBy);
            if (user.Password == collection.Password)
            {
                var GP = (from gatePass in unityOfWork.db.GatePassTransactions where gatePass.L1LocCode == collection.L1LocCode && gatePass.GatePassTransactionCode == collection.GatePassTransactionCode select gatePass).FirstOrDefault();
                GP.ReleasedBy = collection.ReleasedBy;
                GP.DateOfRelease = collection.DateOfRelease;
                gatePassRepository.Update(GP);
                unityOfWork.Commit();

                var asset = (from a in unityOfWork.db.Assets where a.AssetNumber == collection.AssetNumber && a.L1LocCode == collection.L1LocCode select a).FirstOrDefault();
                Asset updateAsset = new Asset();
                asset.UniqueID = asset.UniqueID;
                asset.Status = "GP RELEASED";
                assetRepository.Update(asset);
                unityOfWork.Commit();
                return "Asset Released";
            }
            return "Password Incorrect";
        }

        public IEnumerable<GatePassViewModel> GatePass(GatePassViewModel collection)
        {
            var GatePass = (from GP in unityOfWork.db.GatePassTransactions where GP.L1LocCode == collection.L1LocCode select new GatePassViewModel() {
                GatePassTransactionCode = GP.GatePassTransactionCode,
                AssetDescription = GP.Asset.AssetDescription,
                DateOfProcessing = GP.DateOfProcessing,
                DateOfApproval = GP.DateOfApproval,
                DateOfRelease = GP.DateOfRelease,
                ReturnDate = GP.ReturnDate,
                SupplierName = GP.Supplier.SupplierName,
                CostOfRepair = GP.CostOfRepair,
                ReasonForMaintanence = GP.ReasonForMaintanence,
                OtherReason = GP.OtherReason,
                Status = GP.Asset.Status
            }).ToList();

            if(collection.Status != null)
            {
                GatePass = GatePass.Where(x => x.Status.Equals(collection.Status)).ToList();
            }

            return GatePass;
        }

        public string GatePassReturn(GatePassViewModel collection)
        {
            var user = userRepository.GetById(collection.ReceievedBy);
            if (user.Password == collection.Password)
            {
                var GP = (from gpt in unityOfWork.db.GatePassTransactions where gpt.GatePassTransactionCode == collection.GatePassTransactionCode && gpt.L1LocCode == collection.L1LocCode select gpt).FirstOrDefault();
                GP.RecievedBy = collection.ReceievedBy;
                GP.ReceivedDate = collection.ReceivedDate;
                gatePassRepository.Update(GP);
                unityOfWork.Commit();

                var asset = (from a in unityOfWork.db.Assets where a.AssetNumber == collection.AssetNumber && a.L1LocCode == collection.L1LocCode select a).FirstOrDefault();
                Asset updateAsset = new Asset();
                asset.UniqueID = asset.UniqueID;
                asset.Status = "ACTIVE";
                assetRepository.Update(asset);
                unityOfWork.Commit();

                return "GP RETURNED";
            }
            return "Password Incorrect";
        }

        public IEnumerable<GatePassViewModel> GPTransactionNumber(GatePassViewModel collection)
        {
            var GPNumber = (from GPT in unityOfWork.db.GatePassTransactions where GPT.L1LocCode == collection.L1LocCode select new GatePassViewModel { GatePassTransactionCode = GPT.GatePassTransactionCode, Status = GPT.Asset.Status }).ToList();
            return GPNumber;
        }

        public string IsGatePassCodeExsist(string L1LocCode)
        {
            Random random = new Random();
            string number = Convert.ToString(random.Next(1000, 9999));
            string GatePassTransactionCode = L1LocCode + number;

            var transactionNumber = (from gatePass in unityOfWork.db.GatePassTransactions
                                     where gatePass.GatePassTransactionCode == GatePassTransactionCode
                                     select gatePass).ToList();
            if (transactionNumber.Count == 0)
            {
                return GatePassTransactionCode;
            }
            return IsGatePassCodeExsist(L1LocCode);
        }

        public GatePassViewModel GetGatePass(GatePassViewModel collection)
        {
            var GatePass = (from GP in unityOfWork.db.GatePassTransactions
                            where GP.GatePassTransactionCode == collection.GatePassTransactionCode && GP.L1LocCode == collection.L1LocCode
                            select new GatePassViewModel
                            {
                                GatePassTransactionCode = GP.GatePassTransactionCode,
                                AssetNumber = GP.Asset.AssetNumber,
                                AssetDescription = GP.Asset.AssetDescription,
                                L1CatName = GP.Asset.L1Category.L1CatName,
                                L2CatName = GP.Asset.L2Category.L2CatName,
                                L2LocName = GP.Asset.L2Location.L2LocName,
                                L3LocName = GP.Asset.L3Location.L3LocName,
                                L4LocName = GP.Asset.L4Location.L4LocName,
                                L5LocName = GP.Asset.L5Location.L5LocName,
                                L3CatCode = GP.Asset.L3CatCode,
                                SupplierName = GP.Supplier.SupplierName,
                                SupplierID = GP.SupplierID,
                                ReturnDate = GP.ReturnDate,
                                ApprovalComment = GP.ApprovalComment,
                                ReasonForMaintanence = GP.ReasonForMaintanence,
                                OtherReason = GP.OtherReason,
                                CostOfRepair = GP.CostOfRepair,
                                DateOfProcessing = GP.DateOfProcessing,
                                ProcessedByName = GP.User.UserName,
                                ProcessedBy = GP.ProcessedBy
                            }).FirstOrDefault();
            return GatePass;
        }
    }
}
