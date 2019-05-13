using System.Text;

namespace Lab3.Util
{
    public class ArgumentsParser
    {
        private int _index = 0;

        private string[] _arguments;

        public bool HasNext { get => _index != _arguments.Length; }

        public int NextArgumentsCount { get => _arguments.Length - _index; }

        public ArgumentsParser( string arguments )
        {
            if ( arguments != null )
            {
                _arguments = arguments.Split( ' ' );
            }
            else
            {
                _arguments = new string[ 0 ];
            }
        }

        public ArgumentsParser( string[] arguments )
        {
            _arguments = arguments.Length != 0 ? arguments : new string[ 0 ];
        }

        public string GetNextAsString()
        {
            return _arguments[ _index++ ];
        }

        public int? GetNextAsInt()
        {
            int result;
            if ( int.TryParse( GetNextAsString(), out result ) )
            {
                return result;
            }

            return null;
        }

        public string GetNextsAsString( char delimiter )
        {
            var resultBuilder = new StringBuilder();

            while ( HasNext )
            {
                resultBuilder.Append( GetNextAsString() );
                if ( HasNext )
                {
                    resultBuilder.Append( delimiter );
                }
            }

            return resultBuilder.ToString();
        }
    }
}
