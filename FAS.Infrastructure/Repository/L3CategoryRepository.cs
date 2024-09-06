using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Infrastructure.Common;
using FAS.Data;

namespace FAS.Infrastructure.Repository
{
    public class L3CategoryRepository : RepositoryBase<L3Category>, IL3CategoryRepository
    {
        public L3CategoryRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }

    public interface IL3CategoryRepository : IRepository<L3Category>
    {

    }
}
