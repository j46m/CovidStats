using System.Collections.Generic;
using CovidStats.logic.Files.Interfaces;
using CovidStats.logic.Reports.DTO;

namespace CovidStats.logic.Files.Implementations
{
    public class XmlSerializer : ISerializer
    {
        public string Serialize(List<ReportData> reportData)
        {
            //TODO: same as JSON serializer
            throw new System.NotImplementedException();
        }
    }
}