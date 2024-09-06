using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Infrastructure.Common;
using FAS.Data;

namespace FAS.Infrastructure.Repository
{
    public class L3LocationRepository : RepositoryBase<L3Location>, IL3LocationRepository
    {
        public L3LocationRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }

    public interface IL3LocationRepository : IRepository<L3Location>
    {

    }
}
