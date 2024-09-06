using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FAS.SharedModel;
using FAS.Services;
using FAS.Data;

namespace FixedAssetSolutions.Controllers.API
{
    public class GatePassController : ApiController
    {
        private IGatePassService gatePassService;
        public GatePassController()
            : this(new GatePassService())
        {

        }

        public GatePassController(IGatePassService gatePassService)
        {
            this.gatePassService = gatePassService;
        }

        [HttpPost]
        public ResponseObject Processing(GatePassViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            responseObject.Message =  gatePassService.Processing(collection);
            return responseObject;
        }

        [HttpPost]
        public ResponseObject Approval(GatePassViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            var result = gatePassService.Approval(collection);
            responseObject.Message = result;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject GPNumberList(GatePassViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            IEnumerable<GatePassViewModel> GPNumbers =  gatePassService.GPTransactionNo(collection);
            responseObject.Message = "GP Number List";
            responseObject.Data = GPNumbers;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject GetGatePass(GatePassViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            GatePassViewModel GatePass = gatePassService.GatePAss(collection);
            responseObject.Message = "Gate Pass";
            responseObject.Data = GatePass;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject GatePassApprovalDeclined(GatePassViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            string GatePass = gatePassService.GatePassApprovalDeclined(collection);
            responseObject.Message = "Gate Pass Approval Denied";
            responseObject.Data = GatePass;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject GatePassReProcessing(GatePassViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            gatePassService.GatePassReProcessing(collection);
            responseObject.Message = "Gate Pass ReProcess";
            return responseObject;
        }

        [HttpPost]
        public ResponseObject GatePassRelease(GatePassViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            gatePassService.GatePassRelease(collection);
            responseObject.Message = "Gate Pass ReProcess";
            return responseObject;
        }

        [HttpPost]
        public ResponseObject GatePassReturn(GatePassViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            var mes = gatePassService.GatePassReturn(collection);
            responseObject.Message = mes;
            return responseObject;
        }

        [HttpPost]
        public ResponseObject GatePass(GatePassViewModel collection)
        {
            ResponseObject responseObject = new ResponseObject();
            var data = gatePassService.GatePass(collection);
            responseObject.Data = data;
            return responseObject;
        }
    }
}
