using System.Net.Http;
using System.Net.Http.Json;

namespace WpfFe
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService(string baseUrl)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        public async Task<List<WeatherForecast>> GetForecastAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<WeatherForecast>>("weatherforecast");
        }
    }
}
