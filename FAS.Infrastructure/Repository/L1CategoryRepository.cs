using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Infrastructure.Common;
using FAS.Data;

namespace FAS.Infrastructure.Repository
{
    public class L1CategoryRepository : RepositoryBase<L1Category>, IL1CategoryRepository
    {
        public L1CategoryRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }

    public interface IL1CategoryRepository : IRepository<L1Category>
    {

    }
}
