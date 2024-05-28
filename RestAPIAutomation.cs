using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ApiDataLogger
{
    class RestAPIAutomation
    {
        static async Task Main(string[] args)
        {
            string url = "https://jsonplaceholder.org/posts";

            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                ProcessResponse(responseBody);
            }
            else
            {
                Console.WriteLine($"Failed to retrieve data. Status code: {response.StatusCode}");
            }
        }

        private static void ProcessResponse(string responseBody)
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

            // Log the markdown string to the console
            Console.WriteLine(markdown);

            // Save the markdown string to a file
            try
            {
                File.WriteAllText("api_data.md", markdown.ToString());
            }
            catch (IOException e)
            {
                Console.WriteLine("Failed to save file: " + e.Message);
            }
        }
    }
}
