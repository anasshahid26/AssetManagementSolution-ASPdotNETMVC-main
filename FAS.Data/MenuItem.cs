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
    
    public partial class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string Url { get; set; }
        public Nullable<int> ParentMenu_Id { get; set; }
    
        public virtual Menu Menu { get; set; }
    }
}
