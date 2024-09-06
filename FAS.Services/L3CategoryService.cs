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
    public class L3CategoryService : IL3CategoryService
    {
        L3CategoryAdapter L3CategoryAdapter;

        public L3CategoryService()
        {
            L3CategoryAdapter = new L3CategoryAdapter();
        }

        public string AddL3Category(L3CategoryViewModel L3CategoryViewModel)
        {
            return L3CategoryAdapter.AddL3Category(L3CategoryViewModel);
        }

        public string IsL3CategoryExist(L3CategoryViewModel L3CategoryViewModel)
        {
            return L3CategoryAdapter.IsL3CategoryExist(L3CategoryViewModel);
        }
    }

    public interface IL3CategoryService
    {
        string AddL3Category(L3CategoryViewModel L3CategoryViewModel);
        string IsL3CategoryExist(L3CategoryViewModel L3CategoryViewModel);
    }
}
