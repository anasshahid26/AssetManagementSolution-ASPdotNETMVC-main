//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FAS.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class User_Activity
    {
        public int LogID { get; set; }
        public int UserID { get; set; }
        public string Activity { get; set; }
        public Nullable<System.DateTime> ActivityTime { get; set; }
    
        public virtual User User { get; set; }
    }
}
