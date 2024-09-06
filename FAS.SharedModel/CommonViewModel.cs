using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.SharedModel
{
     public class CommonViewModel
    {
        public List<LocationViewModel> LocationList { get; set; }
        public List<CompanyViewModel> CompanyList { get; set; }
        public List<SectionViewModel> SectionList{ get; set; }
    }
}
