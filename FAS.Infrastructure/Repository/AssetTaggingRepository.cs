using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Infrastructure.Common;
using FAS.Data;

namespace FAS.Infrastructure.Repository
{

    public class AssetTaggingRepository : RepositoryBase<AssetTagging>, IAssetTaggingRepository
    {
        public AssetTaggingRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }

    public interface IAssetTaggingRepository : IRepository<AssetTagging>
    {

    }


}
