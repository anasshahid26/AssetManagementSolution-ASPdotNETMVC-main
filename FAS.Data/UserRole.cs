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
    
    public partial class UserRole
    {
        public int UserRoleID { get; set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public int PermissionID { get; set; }
        public bool IsEdit { get; set; }
        public bool IsView { get; set; }
    
        public virtual AssetPermission AssetPermission { get; set; }
        public virtual AssetRole AssetRole { get; set; }
        public virtual User User { get; set; }
    }
}
