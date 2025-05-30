using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfFe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly WeatherService _weatherService;
        private readonly PlayerService _playerService;

        public MainWindow()
        {
            InitializeComponent();
            string baseUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
            _weatherService = new WeatherService(baseUrl);
            _playerService = new PlayerService(baseUrl);
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                var data = await _weatherService.GetForecastAsync();
                WeatherGrid.ItemsSource = data;
                var data2 = await _playerService.GetPlayersAsync();
                PlayerGrid.ItemsSource = data2;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching data: {ex.Message}");
            }
        }
    }
}