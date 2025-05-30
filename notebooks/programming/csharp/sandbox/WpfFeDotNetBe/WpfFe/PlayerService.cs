using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using SharedLibrary;

namespace WpfFe
{
    internal class PlayerService
    {
        private readonly HttpClient _httpClient;

        public PlayerService(string baseUrl)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        public async Task<List<Player>> GetPlayersAsync()
        {
            await _httpClient.GetAsync("Players/LoadFromGitlab");
            return await _httpClient.GetFromJsonAsync<List<Player>>("players");
        }
    }
}
