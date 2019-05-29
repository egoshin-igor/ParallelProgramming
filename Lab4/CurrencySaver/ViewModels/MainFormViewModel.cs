using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CurrencySaver.ViewModels
{
    public class MainFormViewModel : INotifyPropertyChanged
    {
        private const string UpdateTimesPropertyName = "_updateTimes";
        private const int UpdatesCount = 30;

        private readonly CurrencyUpdater _currencyUpdater;
        private List<long> _updateTimes;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<string> UpdateTimes => _updateTimes.ConvertAll( ut => $"{ut.ToString()} ms" );
        public string AvgUpdateTime => Math.Round( _updateTimes.DefaultIfEmpty( 0 ).Average( ut => ut ), 4 ).ToString();

        public MainFormViewModel()
        {
            _currencyUpdater = new CurrencyUpdater();
            _updateTimes = new List<long>();
            PropertyChanged += MainFormViewModel_PropertyChanged;
        }

        public void SaveCurrencyInfos( string currencyNamesPath, string updatePath )
        {
            _updateTimes.Clear();
            for ( int i = 0; i < UpdatesCount; i++ )
            {
                Stopwatch watch = Stopwatch.StartNew();
                _currencyUpdater.Update( currencyNamesPath, updatePath );
                watch.Stop();
                long updateTime = watch.ElapsedMilliseconds;
                bool isCorrectTime = _updateTimes.TrueForAll( ut => updateTime < ut * 2 && updateTime > ut / 2 ) || !_updateTimes.Any();
                if ( isCorrectTime )
                {
                    _updateTimes.Add( watch.ElapsedMilliseconds );
                }
            }
            OnPropertyChanged( UpdateTimesPropertyName );
        }

        public async Task SaveCurrencyInfosAsync( string currencyNamesPath, string updatePath )
        {
            _updateTimes.Clear();
            for ( int i = 0; i < UpdatesCount; i++ )
            {
                Stopwatch watch = Stopwatch.StartNew();
                await _currencyUpdater.UpdateAsync( currencyNamesPath, updatePath );
                watch.Stop();
                long updateTime = watch.ElapsedMilliseconds;
                bool isCorrectTime = _updateTimes.TrueForAll( ut => updateTime < ut * 2 && updateTime > ut / 2 ) || !_updateTimes.Any();
                if ( isCorrectTime )
                {
                    _updateTimes.Add( watch.ElapsedMilliseconds );
                }
            }
            OnPropertyChanged( UpdateTimesPropertyName );
        }

        private void MainFormViewModel_PropertyChanged( object sender, PropertyChangedEventArgs e )
        {
            if ( e.PropertyName == UpdateTimesPropertyName )
            {
                OnPropertyChanged( "UpdateTimes" );
                OnPropertyChanged( "AvgUpdateTime" );
            }
        }

        private void OnPropertyChanged( [CallerMemberName] string property = "" )
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( property ) );
        }
    }
}
