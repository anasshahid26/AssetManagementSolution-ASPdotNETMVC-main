using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FAS.Services;
using FAS.SharedModel;
namespace FixedAssetSolutions.Controllers.API
{
    public class DisposalController : ApiController
    {
        private IDisposalService disposalService;

        public DisposalController()
            : this(new DisposalService())
        {

        }

        public DisposalController(IDisposalService disposalService)
        {
            this.disposalService = disposalService;
        }

        [HttpPost]
        public ResponseObject Processing(DisposalViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            responseObject.Message = disposalService.Processing(collection);
            return responseObject;
        }

        [HttpPost]
        public ResponseObject Review(DisposalViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            string message = disposalService.Review(collection);
            responseObject.Message = message;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject Verification(DisposalViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            string message = disposalService.Verification(collection);
            responseObject.Message = message;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject Agreement(DisposalViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            string message = disposalService.Agreement(collection);
            responseObject.Message = message;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject Validation(DisposalViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            string message = disposalService.Validation(collection);
            responseObject.Message = message;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject Approval(DisposalViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            string message = disposalService.Approval(collection);
            responseObject.Message = message;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject ApprovalAM(DisposalViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            string message = disposalService.ApprovalAM(collection);
            responseObject.Message = message;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject DisposalNumberList(DisposalViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            var List = disposalService.DisposalNumberList(collection);
            responseObject.Message = "Disposal Number List";
            responseObject.Data = List;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject DateOfDisposalList(DisposalViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            var List = disposalService.DateOfDisposalList(collection);
            responseObject.Message = "Date Of Disposal List";
            responseObject.Data = List;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject AssetNumberList(DisposalViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            var List = disposalService.AssetNumberList(collection);
            responseObject.Message = "Asset Number List";
            responseObject.Data = List;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject DisposalTransaction(DisposalViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            var Transaction = disposalService.DisposalTransaction(collection);
            responseObject.Message = "Disposal Transaction";
            responseObject.Data = Transaction;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject DisposalDenied(DisposalViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            string message = disposalService.DisposalDenied(collection);
            responseObject.Message = message;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject Reprocessing(DisposalViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            string message = disposalService.ReProccessing(collection);
            responseObject.Message = message;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject ListOfValidators(AssetViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            var validators = disposalService.ListOfValidators(collection);
            responseObject.Message = "List of Validators";
            responseObject.Data = validators;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject ListofReveiwer(AssetViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            var validators = disposalService.ListOfReveiwer(collection);
            responseObject.Message = "List of Reveiwer";
            responseObject.Data = validators;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject ListofVerifier(AssetViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            var validators = disposalService.ListOfVerifier(collection);
            responseObject.Message = "List of Verifier";
            responseObject.Data = validators;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject ListofAgreed_GM(AssetViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            var validators = disposalService.ListofAgreed_GM(collection);
            responseObject.Message = "List of Agreed GM";
            responseObject.Data = validators;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject ListofApproval_HO_Finance(AssetViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            var validators = disposalService.ListofApproval_HO_Finance(collection);
            responseObject.Message = "List of Approval HO Finance";
            responseObject.Data = validators;
            return responseObject;
        }
        [HttpPost]
        public ResponseObject ListofApproval_HO_AM_Finance(AssetViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            var validators = disposalService.ListofApproval_HO_AM_Finance(collection);
            responseObject.Message = "List of Approval HO AM Finance";
            responseObject.Data = validators;
            return responseObject;
        }
    }
}
