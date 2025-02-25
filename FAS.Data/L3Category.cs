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
    
    public partial class L3Category
    {
        public L3Category()
        {
            this.Assets = new HashSet<Asset>();
            this.AssetReverifications = new HashSet<AssetReverification>();
            this.L4Category = new HashSet<L4Category>();
            this.Reconciliations = new HashSet<Reconciliation>();
        }
    
        public string L3CatCode { get; set; }
        public string L1LocCode { get; set; }
        public string L2CatCode { get; set; }
        public string L3CatName { get; set; }
        public string ITC2 { get; set; }
    
        public virtual ICollection<Asset> Assets { get; set; }
        public virtual AssetLocation AssetLocation { get; set; }
        public virtual ICollection<AssetReverification> AssetReverifications { get; set; }
        public virtual L2Category L2Category { get; set; }
        public virtual ICollection<L4Category> L4Category { get; set; }
        public virtual ICollection<Reconciliation> Reconciliations { get; set; }
    }
}
