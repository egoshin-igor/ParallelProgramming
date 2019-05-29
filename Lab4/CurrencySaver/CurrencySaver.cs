using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using CurrencySaver.Adapters.Entities;

namespace CurrencySaver
{
    public class CurrencySaver
    {
        public void Save( string path, List<CurrencyInfo> currencies )
        {
            using ( var sw = new StreamWriter( path ) )
            {
                foreach ( CurrencyInfo currency in currencies )
                {
                    sw.WriteLine( currency.ToString() );
                }
            }
        }

        public async Task SaveAsync( string path, List<CurrencyInfo> currencies )
        {
            using ( var sw = new StreamWriter( path ) )
            {
                foreach ( CurrencyInfo currency in currencies )
                {
                    await sw.WriteLineAsync( currency.ToString() );
                }
            }
        }
    }
}
