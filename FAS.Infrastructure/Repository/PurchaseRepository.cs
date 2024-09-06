using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Infrastructure.Common;
using FAS.Data;

namespace FAS.Infrastructure.Repository
{
    public class PurchaseRepository : RepositoryBase<PurchaseDetail>, IPurchaseRepository
    {
        public PurchaseRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }

    public interface IPurchaseRepository : IRepository<PurchaseDetail>
    {

    }
}
