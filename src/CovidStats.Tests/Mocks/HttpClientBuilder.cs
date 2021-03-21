using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;

namespace CovidStats.Tests.Mocks
{
    public class HttpClientBuilder
    {
        public static IHttpClientFactory ReportClientFactory(StringContent content, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            var handler = new Mock<HttpMessageHandler>();

            handler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = statusCode,
                    Content = content
                });

            var client = new HttpClient(handler.Object);
            var clientFactory = new Mock<IHttpClientFactory>();

            clientFactory.Setup(x => x.CreateClient(It.IsAny<string>()))
                .Returns(client);

            return clientFactory.Object;
        }
    }
}