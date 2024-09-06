using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Data;

namespace FAS.Infrastructure.Common
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private MatrixFASEntities1 dataContext;
        public MatrixFASEntities1 Get()
        {
            return dataContext ?? (dataContext = new MatrixFASEntities1());
        }

        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext = null;
        }
    }
}
