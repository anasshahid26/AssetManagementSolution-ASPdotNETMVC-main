using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.SharedModel;
using FAS.Adapter;

namespace FAS.Services
{
    public class DisposalService : IDisposalService
    {
        DisposalAdapter disposableAdapter;

        public DisposalService()
        {
            disposableAdapter = new DisposalAdapter();
        }

        public string Processing(DisposalViewModel collection)
        {
            return disposableAdapter.Processing(collection);
        }

        public string Review(DisposalViewModel collection)
        {
            return disposableAdapter.Review(collection);
        }

        public string Verification(DisposalViewModel collection)
        {
            return disposableAdapter.Verification(collection);
        }

        public string Agreement(DisposalViewModel collection)
        {
            return disposableAdapter.Agreement(collection);
        }

        public string Validation(DisposalViewModel collection)
        {
            return disposableAdapter.Validation(collection);
        }

        public string Approval(DisposalViewModel collection)
        {
            return disposableAdapter.Approval(collection);
        }

        public string ApprovalAM(DisposalViewModel collection)
        {
            return disposableAdapter.ApprovalAM(collection);
        }

        public IEnumerable<DisposalViewModel> DisposalNumberList(DisposalViewModel collection)
        {
            return disposableAdapter.DisposalNumberList(collection);
        }

        public IEnumerable<DisposalViewModel> DateOfDisposalList(DisposalViewModel collection)
        {
            return disposableAdapter.DateOfDisposalList(collection);
        }

        public IEnumerable<DisposalViewModel> AssetNumberList(DisposalViewModel collection)
        {
            return disposableAdapter.AssetNumberList(collection);
        }

        public DisposalViewModel DisposalTransaction(DisposalViewModel collection)
        {
            return disposableAdapter.DisposalTransaction(collection);
        }

        public string DisposalDenied(DisposalViewModel collection)
        {
            return disposableAdapter.DisposalDenied(collection);
        }

        public string ReProccessing(DisposalViewModel collection)
        {
            return disposableAdapter.ReProcessing(collection);
        }

        public IEnumerable<UserViewModel> ListOfValidators(AssetViewModel collection)
        {
            return this.disposableAdapter.ListofValidators(collection);
        }

        public IEnumerable<UserViewModel> ListOfReveiwer(AssetViewModel collection)
        {
            return this.disposableAdapter.ListofReveiwer(collection);
        }

        public IEnumerable<UserViewModel> ListOfVerifier(AssetViewModel collection)
        {
            return this.disposableAdapter.ListofVerifier(collection);
        }

        public IEnumerable<UserViewModel> ListofAgreed_GM(AssetViewModel collection)
        {
            return this.disposableAdapter.ListofAgreed_GM(collection);
        }

        public IEnumerable<UserViewModel> ListofApproval_HO_Finance(AssetViewModel collection)
        {
            return this.disposableAdapter.ListofApproval_HO_Finance(collection);
        }
        public IEnumerable<UserViewModel> ListofApproval_HO_AM_Finance(AssetViewModel collection)
        {
            return this.disposableAdapter.ListofApproval_HO_AM_Finance(collection);
        }
    }

    public interface IDisposalService
    {
        string Processing(DisposalViewModel collection);

        string Review(DisposalViewModel collection);

        string Verification(DisposalViewModel collection);

        string Agreement(DisposalViewModel collection);

        string Validation(DisposalViewModel collection);

        string Approval(DisposalViewModel collection);

        IEnumerable<DisposalViewModel> DisposalNumberList(DisposalViewModel collection);

        IEnumerable<DisposalViewModel> DateOfDisposalList(DisposalViewModel collection);

        IEnumerable<DisposalViewModel> AssetNumberList(DisposalViewModel collection);

        DisposalViewModel DisposalTransaction(DisposalViewModel collection);

        string DisposalDenied(DisposalViewModel collection);

        string ReProccessing(DisposalViewModel collection);

        string ApprovalAM(DisposalViewModel collection);

        IEnumerable<UserViewModel> ListOfValidators(AssetViewModel collection);

        IEnumerable<UserViewModel> ListOfReveiwer(AssetViewModel collection);

        IEnumerable<UserViewModel> ListOfVerifier(AssetViewModel collection);

        IEnumerable<UserViewModel> ListofAgreed_GM(AssetViewModel collection);

        IEnumerable<UserViewModel> ListofApproval_HO_Finance(AssetViewModel collection);
        IEnumerable<UserViewModel> ListofApproval_HO_AM_Finance(AssetViewModel collection);
    }
}
