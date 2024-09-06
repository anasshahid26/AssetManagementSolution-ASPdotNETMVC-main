using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.SharedModel
{
    public class UserActivityViewModel
    {
        public string UserName { get; set; }
        public string Activity { get; set; }
        public Nullable<System.DateTime> ActivityDateTime { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

    }
}
