using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Adapter;
using FAS.SharedModel;
using FAS.Services;
using FAS.Data;

namespace FAS.Services
{
    public class SupplierService : ISupplierService
    {
        SupplierAdapter SuppplierAdapter;

        public SupplierService()
        {
            SuppplierAdapter = new SupplierAdapter();
        }

        public string AddSupplier(SupplierViewModel supplierViewModel)
        {
            return SuppplierAdapter.SupplierAddition(supplierViewModel);
        }
    }

    public interface ISupplierService
    {
        string AddSupplier(SupplierViewModel supplierViewModel);
    }
}