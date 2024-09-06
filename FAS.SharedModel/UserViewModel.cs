using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.SharedModel
{
    public class UserViewModel
    {
        public int UserID { get; set; }
        public int CompanyID { get; set; }
        public string L1LocCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Language { get; set; }
        public string Note { get; set; }
        public bool Active { get; set; }
        public IEnumerable<LocationViewModel> Locations { get; set; }
        public IEnumerable<PermissionSharedModel> Permissions { get; set; }
        public PermissionSharedModel Permission { get; set; }
        

        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string Description { get; set; }
    }
}
