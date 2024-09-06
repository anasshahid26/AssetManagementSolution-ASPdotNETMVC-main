using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FAS.SharedModel
{
    public class CompanyViewModel
    {
        public int CompanyID { get; set; }
        [Required]
        public string CompanyCode { get; set; }
        [DisplayName("Company Name")]
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string MultipleDivision { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        [Required]
        public string City { get; set; }
        public string State_Province { get; set; }
        public string Zip_PostalCode { get; set; }
        [Required]
        public int CountryID { get; set; }
        public string Country { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactFax { get; set; }
        [DisplayName("Contact Email")]
        [Required]
        public string ContactEmail { get; set; }
        public string Logo { get; set; }
        public bool Active { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public int Locations { get; set; }
    }
}
