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
    
    public partial class AssetLocation
    {
        public AssetLocation()
        {
            this.Assets = new HashSet<Asset>();
            this.AssetDisposals = new HashSet<AssetDisposal>();
            this.AssetPurchases = new HashSet<AssetPurchase>();
            this.AssetReverifications = new HashSet<AssetReverification>();
            this.GatePassTransactions = new HashSet<GatePassTransaction>();
            this.L1Category = new HashSet<L1Category>();
            this.L2Category = new HashSet<L2Category>();
            this.L2Location = new HashSet<L2Location>();
            this.L3Category = new HashSet<L3Category>();
            this.L3Location = new HashSet<L3Location>();
            this.L4Category = new HashSet<L4Category>();
            this.L4Location = new HashSet<L4Location>();
            this.L5Location = new HashSet<L5Location>();
            this.PurchaseDetails = new HashSet<PurchaseDetail>();
            this.Reconciliations = new HashSet<Reconciliation>();
            this.UserCompanies = new HashSet<UserCompany>();
        }
    
        public string L1LocCode { get; set; }
        public int CompanyID { get; set; }
        public string L1LocName { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string State_Province { get; set; }
        public string Zip_PostalCode { get; set; }
        public string Country { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactFax { get; set; }
        public string ContactEmail { get; set; }
        public string Logo { get; set; }
        public bool Active { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string MachineCreated { get; set; }
        public string AssetDisposal { get; set; }
        public string AssetMovement { get; set; }
        public int CountryID { get; set; }
    
        public virtual ICollection<Asset> Assets { get; set; }
        public virtual AssetCompany AssetCompany { get; set; }
        public virtual ICollection<AssetDisposal> AssetDisposals { get; set; }
        public virtual Country Country1 { get; set; }
        public virtual ICollection<AssetPurchase> AssetPurchases { get; set; }
        public virtual ICollection<AssetReverification> AssetReverifications { get; set; }
        public virtual ICollection<GatePassTransaction> GatePassTransactions { get; set; }
        public virtual ICollection<L1Category> L1Category { get; set; }
        public virtual ICollection<L2Category> L2Category { get; set; }
        public virtual ICollection<L2Location> L2Location { get; set; }
        public virtual ICollection<L3Category> L3Category { get; set; }
        public virtual ICollection<L3Location> L3Location { get; set; }
        public virtual ICollection<L4Category> L4Category { get; set; }
        public virtual ICollection<L4Location> L4Location { get; set; }
        public virtual ICollection<L5Location> L5Location { get; set; }
        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
        public virtual ICollection<Reconciliation> Reconciliations { get; set; }
        public virtual ICollection<UserCompany> UserCompanies { get; set; }
    }
}
