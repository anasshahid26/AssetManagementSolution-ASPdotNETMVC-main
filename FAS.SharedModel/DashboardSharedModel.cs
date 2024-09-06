using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.SharedModel
{
    public class DashboardSharedModel
    {
        public List<SectionSharedModel> TotalSection { get; set; }
        public List<GroupSharedModel> TotalGroup { get; set; }
        public List<CategorySharedModel> TotalCategory { get; set; }
        public List<DescriptionViewModel> TotalDescription { get; set; }
        public List<RoomViewModel> TotalRoom { get; set; }
        public int AssetCount { get; set; }
        public int AssetCountR { get; set; }
        public int AssetVaraince { get; set; }
    }
}
