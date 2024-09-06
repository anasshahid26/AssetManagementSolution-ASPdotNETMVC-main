using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Adapter;
using FAS.SharedModel;
using FAS.Data;

namespace FAS.Services
{
    public class GatePassService : IGatePassService
    {
        GatePassAdapter gatePassAdapter;

        public GatePassService()
        {
           gatePassAdapter = new GatePassAdapter();
        }

        public string Processing(GatePassViewModel collection)
        {
            return gatePassAdapter.GatePassProcessing(collection);
        }

        public void GatePassReProcessing(GatePassViewModel collection)
        {
            gatePassAdapter.GatePassReProcessing(collection);
        }

        public string Approval(GatePassViewModel collection)
        {
            return gatePassAdapter.GatePassApproval(collection);
        }

        public IEnumerable<GatePassViewModel> GPTransactionNo(GatePassViewModel collection)
        {
            return gatePassAdapter.GPTransactionNumber(collection);
        }

        public GatePassViewModel GatePAss(GatePassViewModel collection)
        {
            return gatePassAdapter.GetGatePass(collection);
        }

        public string GatePassApprovalDeclined(GatePassViewModel collection)
        {
            return gatePassAdapter.GatePassApprovalDeclined(collection);
        }

        public string GatePassRelease(GatePassViewModel collection)
        {
            return gatePassAdapter.GatePassRelease(collection);
        }

        public string GatePassReturn(GatePassViewModel collection)
        {
            return gatePassAdapter.GatePassReturn(collection);
        }

        public IEnumerable<GatePassViewModel> GatePass(GatePassViewModel collection)
        {
            return gatePassAdapter.GatePass(collection);
        }
    }

    public interface IGatePassService
    {
        string Processing(GatePassViewModel collection);
        IEnumerable<GatePassViewModel> GPTransactionNo(GatePassViewModel collection);
        GatePassViewModel GatePAss(GatePassViewModel collection);
        string Approval(GatePassViewModel collection);
        string GatePassApprovalDeclined(GatePassViewModel collection);
        void GatePassReProcessing(GatePassViewModel collection);
        string GatePassRelease(GatePassViewModel collection);
        string GatePassReturn(GatePassViewModel collection);
        IEnumerable<GatePassViewModel> GatePass(GatePassViewModel collection);
    }
}
