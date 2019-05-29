using System.Collections.Generic;

namespace CurrencySaver.ExternalQueries.Dtos
{
    public class ExternalCurrencies
    {
        public Dictionary<string, ExternalCurrencyInfo> Valute { get; set; }
    }
}
