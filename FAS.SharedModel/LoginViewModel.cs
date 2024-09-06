using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace FAS.SharedModel
{
    public class LoginViewModel
    {

        public int AdminID { get; set; }

        public int UserID { get; set; }
        [Required]
        public int CompanyID { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public string Email { get; set; }

        public string L1LocCode { get; set; }

        public string L1LocName { get; set; }

        public string Role { get; set; }

        public string CompanyName { get; set; }

        public bool Active { get; set; }

        public bool CompanyActive { get; set; }

        public bool LocationActive { get; set; }

        public DateTime CreatedOnCreatedBy { get; set; }
        public IEnumerable<PermissionSharedModel> Permissions { get; set; }
    }
}
