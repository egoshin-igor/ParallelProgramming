using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CurrencySaver.Utils
{
    class BaseClient
    {
        public static async Task<R> GetAsync<R>( string url )
        {
            var result = default( R );
            WebClient client = new WebClient();
            Stream stream = null;
            try
            {
                stream = await client.OpenReadTaskAsync( url );
                StreamReader sr = new StreamReader( stream );
                string json = await sr.ReadToEndAsync();
                if ( !string.IsNullOrWhiteSpace( json ) )
                {
                    result = JsonConvert.DeserializeObject<R>( json );
                }
            }
            finally
            {
                stream?.Close();
            }

            return result;
        }

        public static R Get<R>( string url )
        {
            var result = default( R );
            WebClient client = new WebClient();
            Stream stream = null;
            try
            {
                stream = client.OpenRead( url );
                StreamReader sr = new StreamReader( stream );
                string json = sr.ReadToEnd();
                if ( !string.IsNullOrWhiteSpace( json ) )
                {
                    result = JsonConvert.DeserializeObject<R>( json );
                }
            }
            finally
            {
                stream?.Close();
            }

            return result;
        }
    }
}
