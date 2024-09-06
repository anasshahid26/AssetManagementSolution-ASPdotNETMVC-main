using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.Services.Helper
{
    public static class ExtensionHelper
    {
        public static string GetPrefix(this string value, int length)
        {
            if (value.Count() > length - 1)
                return value.Substring(0, length);
            else
                return value.Substring(0, value.Count() - 1);
        }
    }
}
