using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using ApiDataLogger;

namespace ApiDataLogger.Tests
{
    public class FetchDataTests
    {
        [Fact]
        public async Task FetchAndFormatDataAsync_ReturnsCorrectMarkdown()
        {
            var handlerMock = new HttpClientHandlerMock();
            var httpClient = new HttpClient(handlerMock);
            var service = new ApiService(httpClient);
            string url = "https://jsonplaceholder.org/posts";

            string markdown = await service.FetchAndFormatDataAsync(url);

            // Verify the markdown contains the expected values
            Assert.Contains("| test-slug |", markdown);
            Assert.Contains("| active |", markdown);
            Assert.Contains("| publishedAt |", markdown);
            Assert.Contains("| updatedAt |", markdown);
        }
    }

    public class HttpClientHandlerMock : HttpClientHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("[{ \"slug\": \"test-slug\", \"status\": \"active\", \"publishedAt\": \"2023-01-01T00:00:00Z\", \"updatedAt\": \"2023-01-02T00:00:00Z\" }]")
            };

            return Task.FromResult(response);
        }
    }
}
