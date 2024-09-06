using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Data;
using FAS.Infrastructure.Common;

namespace FAS.Infrastructure.Repository
{
    public class AssetPermissionsRepository : RepositoryBase<AssetPermission>, IAssetPermissionsRepository
    {
        public AssetPermissionsRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }

    public interface IAssetPermissionsRepository : IRepository<AssetPermission>
    {

    }
}
