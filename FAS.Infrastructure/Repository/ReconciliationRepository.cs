using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Data;
using FAS.Infrastructure.Common;

namespace FAS.Infrastructure.Repository
{

    public class ReconciliationRepository : RepositoryBase<Reconciliation>, IReconciliationRepository
    {
        public ReconciliationRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }

    public interface IReconciliationRepository : IRepository<Reconciliation>
    {

    }
}
