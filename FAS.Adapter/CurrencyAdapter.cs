using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FAS.Infrastructure.Repository;
using FAS.Infrastructure.Common;
using FAS.SharedModel;

namespace FAS.Adapter
{
    public class CurrencyAdapter
    {
        private ICurrencyRepository CurrencyRepository;
        private IUnityOfWork UnitofWork;

        public CurrencyAdapter()
        {
            UnitofWork = new UnityOfWork(new DatabaseFactory());
            CurrencyRepository = new CurrencyRepository(UnitofWork.instance);
        }

        public IEnumerable<CurrencyViewModel> GetCurrency()
        {
            List<CurrencyViewModel> result = new List<CurrencyViewModel>();
            var currency = CurrencyRepository.GetAll().ToList();
            if (currency.Count > 0)
            {
                foreach (var item in currency)
                {
                    result.Add(new CurrencyViewModel
                    {
                        iso = item.iso,
                        name = item.name
                    });
                }
                return result;
            }
            else
            {
                return result;
            }
        }
    }
}
