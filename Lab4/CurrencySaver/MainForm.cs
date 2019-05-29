using System;
using System.Windows.Forms;
using CurrencySaver.ViewModels;

namespace CurrencySaver
{
    public partial class MainForm : Form
    {
        private readonly MainFormViewModel _viewModel;

        public MainForm( MainFormViewModel mainFormViewModel )
        {
            InitializeComponent();
            _viewModel = mainFormViewModel;
            _updateTimesList.DataBindings.Add( "DataSource", _viewModel, "UpdateTimes", true, DataSourceUpdateMode.OnPropertyChanged );
            _avgUpdateTimeLabel.DataBindings.Add( "Text", _viewModel, "AvgUpdateTime", true, DataSourceUpdateMode.OnPropertyChanged );
            _asyncUsingRadioButton.Checked = true;
        }

        private void _asyncUsingRadioButton_CheckedChanged( object sender, System.EventArgs e )
        {
            _saveCurrenciesButton.Click -= _saveCurrenciesButton_ClickAsync;
            _saveCurrenciesButton.Click -= _saveCurrenciesButton_Click;
            _saveCurrenciesButton.Click += new EventHandler( _saveCurrenciesButton_ClickAsync );
        }

        private void _syncUsingRadioButton_CheckedChanged( object sender, EventArgs e )
        {
            _saveCurrenciesButton.Click -= _saveCurrenciesButton_ClickAsync;
            _saveCurrenciesButton.Click -= _saveCurrenciesButton_Click;
            _saveCurrenciesButton.Click += new EventHandler( _saveCurrenciesButton_Click );
        }

        private async void _saveCurrenciesButton_ClickAsync( object sender, EventArgs e )
        {
            _saveCurrenciesButton.Enabled = false;
            await _viewModel.SaveCurrencyInfosAsync( _currencyNamesUriBox.Text, _currencyInfosUriBox.Text );
            _saveCurrenciesButton.Enabled = true;
        }

        private void _saveCurrenciesButton_Click( object sender, EventArgs e )
        {
            _saveCurrenciesButton.Enabled = false;
            _viewModel.SaveCurrencyInfos( _currencyNamesUriBox.Text, _currencyInfosUriBox.Text );
            _saveCurrenciesButton.Enabled = true;
        }
    }
}
