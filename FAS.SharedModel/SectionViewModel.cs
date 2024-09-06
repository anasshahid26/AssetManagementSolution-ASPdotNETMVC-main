using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.SharedModel
{
    public class SectionViewModel
    {
        public int SectionID { get; set; }
        public int CompanyID { get; set; }
        public int LocationID { get; set; }
        public string SectionCode { get; set; }
        public string SectionName { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State_Province { get; set; }
        public string Zip_PostalCode { get; set; }
        public string Country { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactFax { get; set; }
        public string ContactEmail { get; set; }
        public bool Active { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
