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
    
    public partial class L2Location
    {
        public L2Location()
        {
            this.Assets = new HashSet<Asset>();
            this.AssetReverifications = new HashSet<AssetReverification>();
            this.L3Location = new HashSet<L3Location>();
            this.Reconciliations = new HashSet<Reconciliation>();
        }
    
        public string L2LocCode { get; set; }
        public string L1LocCode { get; set; }
        public string L2LocName { get; set; }
    
        public virtual ICollection<Asset> Assets { get; set; }
        public virtual AssetLocation AssetLocation { get; set; }
        public virtual ICollection<AssetReverification> AssetReverifications { get; set; }
        public virtual ICollection<L3Location> L3Location { get; set; }
        public virtual ICollection<Reconciliation> Reconciliations { get; set; }
    }
}
