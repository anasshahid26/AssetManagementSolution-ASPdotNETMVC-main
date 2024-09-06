using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Data;

namespace FAS.Infrastructure.Common
{
    public interface IDatabaseFactory : IDisposable
    {
        MatrixFASEntities1 Get();
    }
}
