using System.Threading.Tasks;
using CovidStats.data.DTO;
using CovidStats.data.Implementations;
using CovidStats.data.Interfaces;
using CovidStats.logic.Reports.Implementations;
using CovidStats.logic.Reports.Interfaces;
using CovidStats.Tests.Mocks;
using Xunit;

namespace CovidStats.Tests
{
    public class ReportBuilderTests
    {
        [Fact]
        public async Task ExpectedValuesFromReport()
        {
            var reportConfig = new ReportConfig
            {
                Url = "https://covid-19-statistics.p.rapidapi.com/reports",
                ApiKey = "48c6ea5926msh35c92edffc8d551p130b01jsnb7aafad496a2",
                ApiHost = "covid-19-statistics.p.rapidapi.com",
            };
            var clientFactory = ClientBuilder.ReportClientFactory(ResponseBuilder.BuildOkResponse());
            IReportRetriever reportRetriever = new ReportRetriever(reportConfig, clientFactory);


            IReportBuilder regionReportBuilder = new ReportBuilder(reportRetriever);
            var report = await regionReportBuilder.GetReportData();

            Assert.Equal(1008, report[0].Cases);
            Assert.Equal(56044, report[1].Cases);
            Assert.Equal(119528, report[2].Cases);
        }
    }

    //TODO: Add more test scenarios not done due to time constraints.
}