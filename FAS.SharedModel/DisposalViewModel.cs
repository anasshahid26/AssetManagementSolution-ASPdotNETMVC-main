using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.SharedModel
{
    public class DisposalViewModel
    {
        public string ACTOR { get; set; }
        public string DisposalNumber { get; set; }
        public string L1LocCode { get; set; }
        public string DateOfDisposal { get; set; }
        public string DateOfProcessing { get; set; }
        public string DateOfReview { get; set; }
        public string DateOfVerification { get; set; }
        public string DateOfAgreement { get; set; }
        public string DateOfValidation { get; set; }
        public string DateOfApproval { get; set; }
        public string ProcessingRemarks { get; set; }
        public string ReviewRemarks { get; set; }
        public string VerificationRemarks { get; set; }
        public string AgreementRemarks { get; set; }
        public string ValidationRemarks { get; set; }
        public string ApprovalRemarks { get; set; }
        public int ProcessedBy { get; set; }
        public int ReviewedBy { get; set; }
        public int VerifiedBy { get; set; }
        public int AgreedBy { get; set; }
        public int ValidatedBy { get; set; }
        public int ApprovedBy { get; set; }
        public string ProcessedByName { get; set; }
        public string ReviewedByName { get; set; }
        public string VerifiedByName { get; set; }
        public string AgreedByName { get; set; }
        public string ValidatedByName { get; set; }
        public string ApprovedByName { get; set; }
        public string AssetNumber { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
        public int UserID { get; set; }
        public string DeniedReason { get; set; }
        public string DeniedBy { get; set; }
        public string DateOfReProcessing { get; set; }
        public string ReprocessingRemarks { get; set; }
        public int ReProcessedBy { get; set; }
        public string AssetDisposalCode { get; set; }
        public string UniqueID { get; set; }
        public string DisposalSaleValue { get; set; }
        public string DateOfApprovalAM { get; set; }
        public string ApprovalAMRemarks { get; set; }
        public int ApprovedAMBy { get; set; }
        public string ValidEmail { get; set; }

        public IList<AssetNumberViewModel> Assets { get; set; }
        public IEnumerable<SearchViewModel> Asset { get; set; }
        public IEnumerable<DisposalViewModel> TotalDisposalGenerated { get; set; }
    }
}
