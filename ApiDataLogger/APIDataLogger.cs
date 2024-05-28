using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ApiDataLogger
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            string url = "https://jsonplaceholder.org/posts";
            var service = new ApiService(new HttpClient());

            try
            {
                string markdown = await service.FetchAndFormatDataAsync(url);
                Console.WriteLine(markdown);
                System.IO.File.WriteAllText("api_data.md", markdown);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    public class ApiService
    {
        private readonly HttpClient _client;

        public ApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task<string> FetchAndFormatDataAsync(string url)
        {
            HttpResponseMessage response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Failed to retrieve data. Status code: {response.StatusCode}");

            string responseBody = await response.Content.ReadAsStringAsync();
            return ProcessResponse(responseBody);
        }

        public string ProcessResponse(string responseBody)
        {
            JArray data = JArray.Parse(responseBody);

            // Create a markdown string
            var markdown = new System.Text.StringBuilder();
            markdown.AppendLine("# Posts values");
            markdown.AppendLine();
            markdown.AppendLine("| slug | status | publishedAt | updatedAt |");
            markdown.AppendLine("|------|--------|-------------|-----------|");

            foreach (var item in data)
            {
                markdown.AppendLine($"| {item["slug"]} | {item["status"]} | {item["publishedAt"]} | {item["updatedAt"]} |");
            }

            return markdown.ToString();
        }
    }
}