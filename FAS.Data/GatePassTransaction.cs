//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FAS.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class GatePassTransaction
    {
        public string GatePassTransactionCode { get; set; }
        public string L1LocCode { get; set; }
        public string UniqueID { get; set; }
        public string SupplierID { get; set; }
        public int ProcessedBy { get; set; }
        public int ApprovedBy { get; set; }
        public int RecievedBy { get; set; }
        public int ReleasedBy { get; set; }
        public string ReceivedDate { get; set; }
        public string OtherReason { get; set; }
        public string ReasonForMaintanence { get; set; }
        public string CostOfRepair { get; set; }
        public string ReturnDate { get; set; }
        public string DateOfProcessing { get; set; }
        public string DateOfApproval { get; set; }
        public string DateOfRelease { get; set; }
        public string ApprovalComment { get; set; }
        public string ReleaseComment { get; set; }
        public string ProcessComment { get; set; }
    
        public virtual Asset Asset { get; set; }
        public virtual AssetLocation AssetLocation { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        public virtual User User2 { get; set; }
        public virtual User User3 { get; set; }
    }
}
