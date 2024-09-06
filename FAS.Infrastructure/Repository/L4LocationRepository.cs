using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Infrastructure.Common;
using FAS.Data;

namespace FAS.Infrastructure.Repository
{
    public class L4LocationRepository : RepositoryBase<L4Location>, IL4LocationRepository
    {
        public L4LocationRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }

    public interface IL4LocationRepository : IRepository<L4Location>
    {

    }
}
