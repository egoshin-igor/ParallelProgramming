using System.Threading.Tasks;
using CurrencySaver.ExternalQueries.Dtos;
using CurrencySaver.Utils;

namespace CurrencySaver.ExternalQueries
{
    public class ExternalCurrencyQuery
    {
        private const string Url = "https://www.cbr-xml-daily.ru/daily_json.js";

        public ExternalCurrencies GetAll()
        {
            return BaseClient.Get<ExternalCurrencies>( Url );
        }

        public async Task<ExternalCurrencies> GetAllAsync()
        {
            return await BaseClient.GetAsync<ExternalCurrencies>( Url );
        }
    }
}
