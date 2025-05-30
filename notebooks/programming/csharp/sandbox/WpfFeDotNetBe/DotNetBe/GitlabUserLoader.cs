using System.Net.Http.Headers;
using System.Text.Json;

namespace DotNetBe
{
    public class GitLabUser
    {
        public int id { get; set; }
        public string name { get; set; } = "";
    }

    public static class GitLabUserLoader
    {
        private readonly static string _baseUrl = "https://gitlab.rz.htw-berlin.de/api/v4";

        public static async Task<List<GitLabUser>> FetchUsersAsync(int projectId)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("secrets.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", configuration["Gitlab:AccessToken"]);

            var url = $"{_baseUrl}/projects/{projectId}/members/all";
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<List<GitLabUser>>(json);

            return users ?? new List<GitLabUser>();
        }
    }
}
