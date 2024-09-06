using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Data;
using FAS.Infrastructure.Common;

namespace FAS.Infrastructure.Repository
{

    public class ReconciliationRecordRepository : RepositoryBase<ReconciliationRecord>, IReconciliationRecordRepository
    {
        public ReconciliationRecordRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }

    public interface IReconciliationRecordRepository : IRepository<ReconciliationRecord>
    {

    }

}
