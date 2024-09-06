using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Data;
using FAS.Infrastructure.Common;

namespace FAS.Infrastructure.Repository
{
    public class L4CategoryRepository : RepositoryBase<L4Category>, IL4CategoryRepository
    {
        public L4CategoryRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }

    public interface IL4CategoryRepository : IRepository<L4Category>
    {

    }
}
