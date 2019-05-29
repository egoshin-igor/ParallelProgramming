using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencySaver.Adapters;
using CurrencySaver.Adapters.Entities;
using CurrencySaver.ExternalQueries;
using CurrencySaver.Queries;

namespace CurrencySaver
{
    public class CurrencyUpdater
    {
        private readonly CurrencyInfoAdapter _currencyInfoAdapter;
        private readonly CurrencyNamesQuery _currencyNamesQuery;
        private readonly CurrencySaver _currencySaver;

        public CurrencyUpdater()
        {
            _currencyInfoAdapter = new CurrencyInfoAdapter( new ExternalCurrencyQuery() );
            _currencyNamesQuery = new CurrencyNamesQuery();
            _currencySaver = new CurrencySaver();
        }

        public void Update( string currencyNamesPath, string updatePath )
        {
            List<string> currencyNames = _currencyNamesQuery.GetAll( currencyNamesPath );
            List<CurrencyInfo> currencyInfos = _currencyInfoAdapter.Get();
            if ( currencyNames.Any() )
            {
                currencyInfos = currencyInfos.Where( ci => currencyNames.Contains( ci.CurrencyCode ) ).ToList();
            }

            _currencySaver.Save( updatePath, currencyInfos );
        }

        public async Task UpdateAsync( string currencyNamesPath, string updatePath )
        {
            Task<List<string>> currencyNamesTask = _currencyNamesQuery.GetAllAsync( currencyNamesPath );
            Task<List<CurrencyInfo>> currencyInfosTask = _currencyInfoAdapter.GetAsync();
            List<string> currencyNames = await currencyNamesTask;
            List<CurrencyInfo> currencyInfos = await currencyInfosTask;

            if ( currencyNames.Any() )
            {
                currencyInfos = currencyInfos.Where( ci => currencyNames.Contains( ci.CurrencyCode ) ).ToList();
            }

            await _currencySaver.SaveAsync( updatePath, currencyInfos );
        }
    }
}
