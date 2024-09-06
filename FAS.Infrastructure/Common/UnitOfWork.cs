using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Data;
using System.Data.Entity.Infrastructure;

namespace FAS.Infrastructure.Common
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly IDatabaseFactory databaseFactory;
        private MatrixFASEntities1 dataContext;

        public UnityOfWork(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        protected MatrixFASEntities1 DataContext
        {
            get { return dataContext ?? (dataContext = databaseFactory.Get()); }
        }

        public string Commit()
        {
            try { 
                DataContext.SaveChanges();
                return "Success";
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }

        public IDatabaseFactory instance
        {
            get
            {
                return databaseFactory;
            }
        }

        public MatrixFASEntities1 db
        {
            get { return dataContext ?? (dataContext = databaseFactory.Get()); }
        }
    }
}
