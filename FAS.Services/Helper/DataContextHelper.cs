using FAS.Services.DataModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.Services
{
    public static class DataContextHelper
    {
        public static MatrixFASDataContext GetMatrixFASDataContext()
        {
            return (new MatrixFASDataContext(ConfigurationManager.ConnectionStrings["MatrixFASServices"].ConnectionString));
        }
    }
}
