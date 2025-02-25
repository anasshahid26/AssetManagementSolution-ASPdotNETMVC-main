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
    
    public partial class L4Category
    {
        public L4Category()
        {
            this.Assets = new HashSet<Asset>();
            this.AssetReverifications = new HashSet<AssetReverification>();
            this.Reconciliations = new HashSet<Reconciliation>();
        }
    
        public string L4CatCode { get; set; }
        public string L1LocCode { get; set; }
        public string L3CatCode { get; set; }
        public string ITC3 { get; set; }
    
        public virtual ICollection<Asset> Assets { get; set; }
        public virtual AssetLocation AssetLocation { get; set; }
        public virtual ICollection<AssetReverification> AssetReverifications { get; set; }
        public virtual L3Category L3Category { get; set; }
        public virtual ICollection<Reconciliation> Reconciliations { get; set; }
    }
}
