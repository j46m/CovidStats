using System.Collections.Generic;
using CovidStats.logic.Files.Interfaces;
using CovidStats.logic.Reports.DTO;
using Newtonsoft.Json;

namespace CovidStats.logic.Files.Implementations
{
    public class JsonSerializer : ISerializer
    {
        public string Serialize(List<ReportData> reportData)
        {
            return JsonConvert.SerializeObject(reportData);
        }
    }
}