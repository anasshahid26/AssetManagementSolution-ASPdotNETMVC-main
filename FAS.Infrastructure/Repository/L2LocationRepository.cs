using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Infrastructure.Common;
using FAS.Data;

namespace FAS.Infrastructure.Repository
{
    public class L2LocationRepository : RepositoryBase<L2Location>, IL2LocationRepository
    {
        public L2LocationRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }

    public interface IL2LocationRepository : IRepository<L2Location>
    {

    }
}
