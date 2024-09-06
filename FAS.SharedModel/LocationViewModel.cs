using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.SharedModel
{
    public class LocationViewModel
    {
        public string L1LocCode { get; set; }
        [Required]
        public int CompanyID { get; set; }
        [Required]
        
        public string L1LocName { get; set; }
        
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
        [Required]
        public string ContactEmail { get; set; }
        //public string temp = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Content/img/Matrix-AMS-Logo.png");
        public string Logo { get; set; }
        //public string Photo { get { return Logo == null ? temp : Logo; } }
        [Required]
        public bool Active { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string MachineCreated { get; set; }
        public string AssetDisposal { get; set; }
        public string AssetMovement { get; set; }
    }
}
