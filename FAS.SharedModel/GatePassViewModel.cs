using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.SharedModel
{
    public class GatePassViewModel
    {
        public string GatePassTransactionCode { get; set; }
        public string AssetNumber { get; set; }
        public string UniqueID { get; set; }
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public int ProcessedBy { get; set; }
        public int ApprovedBy { get; set; }
        public int ReleasedBy { get; set; }
        public int ReceievedBy { get; set; }
        public string ReasonForMaintanence { get; set; }
        public string L1CatName { get; set; }
        public string L2CatName { get; set; }
        public string L2LocName { get; set; }
        public  string L4LocName { get; set; }
        public string L5LocName { get; set; }
        public string CostOfRepair { get; set; }
        public string DateOfProcessing { get; set; }
        public string DateOfApproval { get; set; }
        public string DateOfRelease { get; set; }
        public string ReceivedDate { get; set; }
        public string ApprovalComment { get; set; }
        public string ProcessComment { get; set; }
        public string ReleaseComment { get; set; }
        public string Status { get; set; }
        public string L1LocCode { get; set; }
        public string OtherReason { get; set; }
        public string ReturnDate { get; set; }
        public string Password { get; set; }
        public string AssetDescription { get; set; }
        public string L3LocName { get; set; }
        public string L3CatCode { get; set; }
        public string ProcessedByName { get; set; }
    }
}
