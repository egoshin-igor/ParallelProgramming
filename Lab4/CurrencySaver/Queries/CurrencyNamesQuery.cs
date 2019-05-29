using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencySaver.Queries
{
    public class CurrencyNamesQuery
    {
        public List<string> GetAll( string path )
        {
            try
            {
                using ( var sr = new StreamReader( path ) )
                {
                    string line = sr.ReadLine() ?? "";
                    return line.Split( ' ' ).ToList();
                }
            }
            catch
            {
                return new List<string>();
            }
        }

        public async Task<List<string>> GetAllAsync( string path )
        {
            try
            {
                using ( var sr = new StreamReader( path ) )
                {
                    string line = ( await sr.ReadLineAsync() ) ?? "";
                    return line.Split( ' ' ).ToList();
                }
            }
            catch
            {
                return new List<string>();
            }
        }
    }
}
