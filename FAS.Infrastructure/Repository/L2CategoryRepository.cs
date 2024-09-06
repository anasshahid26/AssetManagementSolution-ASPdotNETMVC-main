using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Infrastructure.Common;
using FAS.Data;

namespace FAS.Infrastructure.Repository
{
    public class L2CategoryRepository : RepositoryBase<L2Category>, IL2CategoryRepository
    {
        public L2CategoryRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }

    public interface IL2CategoryRepository : IRepository<L2Category>
    {

    }
}
