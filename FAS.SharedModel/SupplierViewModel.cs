using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.SharedModel
{
    public class SupplierViewModel
    {
        public string L1LocCode { get; set; }
        public string SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierTelephone { get; set; }
        public string SupplierEmail { get; set; }
        public int CountryID { get; set; }
        public int CompanyID { get; set; }
        public int UserID { get; set; }
    }
}
