using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CovidStats.logic.Files.Implementations;
using CovidStats.logic.Files.Interfaces;
using CovidStats.logic.Reports.DTO;
using Newtonsoft.Json;
using Xunit;

namespace CovidStats.Tests
{
    public class FileSaverTests
    {
        [Fact]
        public async Task ExpectedValuesToSave()
        {
            const string filePath = "C://tests//";
            const string fileExtension = ".json";

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
            var dataToSave = JsonConvert.SerializeObject(reportData);
            var expectedFileName = $"{DateTime.Now.Year}{DateTime.Now.Month:D2}{DateTime.Now.Day:D2}{DateTime.Now.Hour}{DateTime.Now.Minute:D2}{DateTime.Now.Second:D2}";
            
            IFileSaver fileSaver = new FileSaver();
            var actualFileName = await fileSaver.SaveToFile(filePath, fileExtension, dataToSave);

            Assert.Equal($"{expectedFileName}{fileExtension}", actualFileName);
        }
    }
}