using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.SharedModel
{
    public class PasswordViewModel
    {
        public int UserID { get; set; }
        public string Password { get; set; }
        public string OldPassword { get; set; }
    }
}
