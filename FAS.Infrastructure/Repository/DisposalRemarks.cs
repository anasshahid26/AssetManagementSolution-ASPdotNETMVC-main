using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Infrastructure.Common;
namespace FAS.Infrastructure.Repository
{

    public class DisposalRemarks : RepositoryBase<DisposalRemarks>, IDisposalRemarks
    {
        public DisposalRemarks(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }

    public interface IDisposalRemarks : IRepository<DisposalRemarks>
    {

    }
}
