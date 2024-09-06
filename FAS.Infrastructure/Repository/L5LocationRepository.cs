using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Infrastructure.Common;
using FAS.Data;

namespace FAS.Infrastructure.Repository
{

    public class L5LocationRepository : RepositoryBase<L5Location>, IL5LocationRepository
    {
        public L5LocationRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }

    public interface IL5LocationRepository : IRepository<L5Location>
    {

    }
}
