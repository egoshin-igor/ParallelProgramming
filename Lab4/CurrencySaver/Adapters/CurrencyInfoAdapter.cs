using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencySaver.Adapters.Entities;
using CurrencySaver.ExternalQueries;
using CurrencySaver.ExternalQueries.Dtos;

namespace CurrencySaver.Adapters
{
    public class CurrencyInfoAdapter
    {
        private readonly ExternalCurrencyQuery _externalCurrencyQuery;

        public CurrencyInfoAdapter( ExternalCurrencyQuery externalCurrencyQuery )
        {
            _externalCurrencyQuery = externalCurrencyQuery;
        }

        public List<CurrencyInfo> Get()
        {
            return Convert( _externalCurrencyQuery.GetAll() );
        }

        public async Task<List<CurrencyInfo>> GetAsync()
        {
            return Convert( await _externalCurrencyQuery.GetAllAsync() );
        }

        private List<CurrencyInfo> Convert( ExternalCurrencies externalCurrencies )
        {
            return externalCurrencies.Valute.Values
                .Select( e => new CurrencyInfo
                {
                    CurrencyCode = e.CharCode,
                    Nominal = e.Nominal,
                    Value = e.Value
                } )
                .ToList();
        }
    }
}
