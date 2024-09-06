using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Infrastructure.Common;
using FAS.Data;

namespace FAS.Infrastructure.Repository
{
    public class LocationRepository : RepositoryBase<AssetLocation>, ILocationRepository
    {
        public LocationRepository(IDatabaseFactory databaseFactory)
            :base(databaseFactory)
        {

        }
    }

    public interface ILocationRepository : IRepository<AssetLocation>
    {

    }
}
