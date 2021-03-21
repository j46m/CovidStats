using System.Collections.Generic;
using CovidStats.logic.Files.Implementations;
using CovidStats.logic.Files.Interfaces;
using CovidStats.logic.Reports.DTO;
using Xunit;

namespace CovidStats.Tests
{
    public class JsonSerializerTests
    {
        [Fact]
        public void ExpectedValuesToSerialize()
        {
            var reportData = new List<ReportData>
            {
                new ReportData
                {
                    Cases = 1122,
                    Deaths = 1001,
                    ProvinceName = "Province test",
                    RegionName = "Region test"
                },
                new ReportData
                {
                    Cases = 2233,
                    Deaths = 1011,
                    ProvinceName = "Province test 2",
                    RegionName = "Region test 2"
                }
            };
            const string expectedValue = "[{\"RegionName\":\"Region test\",\"ProvinceName\":\"Province test\",\"Cases\":1122,\"Deaths\":1001},{\"RegionName\":\"Region test 2\",\"ProvinceName\":\"Province test 2\",\"Cases\":2233,\"Deaths\":1011}]";

            ISerializer serializer = new JsonSerializer();
            var sut = serializer.Serialize(reportData);

            Assert.Equal(expectedValue,sut);
        }
    }
}