﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAS.SharedModel
{
    public class ReverificationAPIViewModel
    {
        public List<ReverificationDataViewModel> VerifiedAssets { get; set; }
        public int Count { get; set; }
    }
}
