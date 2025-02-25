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
    
    public partial class L1Category
    {
        public L1Category()
        {
            this.Assets = new HashSet<Asset>();
            this.AssetReverifications = new HashSet<AssetReverification>();
            this.L2Category = new HashSet<L2Category>();
            this.Reconciliations = new HashSet<Reconciliation>();
        }
    
        public string L1CatCode { get; set; }
        public string L1LocCode { get; set; }
        public string L1CatName { get; set; }
        public Nullable<int> DepreciationRate { get; set; }
    
        public virtual ICollection<Asset> Assets { get; set; }
        public virtual AssetLocation AssetLocation { get; set; }
        public virtual ICollection<AssetReverification> AssetReverifications { get; set; }
        public virtual ICollection<L2Category> L2Category { get; set; }
        public virtual ICollection<Reconciliation> Reconciliations { get; set; }
    }
}
