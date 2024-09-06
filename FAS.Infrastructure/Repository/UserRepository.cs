using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Infrastructure.Common;
using FAS.Data;

namespace FAS.Infrastructure.Repository
{
    public class UserRepository : RepositoryBase<User> , IUserRepository
    {
        public UserRepository(IDatabaseFactory databaseFactory)
            :base(databaseFactory)
        {

        }
    }

    public interface IUserRepository : IRepository<User>
    {

    }
}
