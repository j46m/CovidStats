using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CovidStats.data.DTO;
using CovidStats.data.Implementations;
using CovidStats.data.Interfaces;
using CovidStats.Tests.Mocks;
using Xunit;

namespace CovidStats.Tests
{
    public class ReportRetrieverTests
    {
        [Fact]
        public async Task ExpectedValuesFromReportApi()
        {
            var reportConfig = new ReportConfig
            {
                Url = "https://covid-19-statistics.p.rapidapi.com/reports",
                ApiKey = "48c6ea5926msh35c92edffc8d551p130b01jsnb7aafad496a2",
                ApiHost = "covid-19-statistics.p.rapidapi.com",
            };
            var clientFactory = HttpClientBuilder.ReportClientFactory(ResponseBuilder.BuildOkResponse());
            

            IReportRetriever reportRetriever = new ReportRetriever(reportConfig,clientFactory);
            var response = await reportRetriever.RetrieveAllData();


            Assert.Equal("AFG",response.data[0].region.iso);
            Assert.Equal("ALB", response.data[1].region.iso);
        }

        [Fact]
        public async Task InternalErrorFromReportApi()
        {
            var reportConfig = new ReportConfig
            {
                Url = "https://covid-19-statistics.p.rapidapi.com/reports",
                ApiKey = "48c6ea5926msh35c92edffc8d551p130b01jsnb7aafad496a2",
                ApiHost = "covid-19-statistics.p.rapidapi.com",
            };

            var clientFactory = HttpClientBuilder.ReportClientFactory(ResponseBuilder.BuildInternalErrorResponse(),HttpStatusCode.InternalServerError);
            

            IReportRetriever reportRetriever = new ReportRetriever(reportConfig, clientFactory);

            await Assert.ThrowsAsync<HttpRequestException>(() => reportRetriever.RetrieveAllData());
        }

        //TODO: Add more test scenarios not done due to time constraints.
    }
}
