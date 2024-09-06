using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Data;
using FAS.Infrastructure.Common;

namespace FAS.Infrastructure.Repository
{
    public class DisposalNumberRepository : RepositoryBase<DisposalNumber>, IDisposalNumberRepository
    {
        public DisposalNumberRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }

    public interface IDisposalNumberRepository : IRepository<DisposalNumber>
    {

    }
}
