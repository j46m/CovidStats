using System.Collections.Generic;
using CovidStats.logic.Reports.DTO;

namespace CovidStats.logic.Files.Interfaces
{
    public interface ISerializer
    {
        string Serialize(List<ReportData> reportData);
    }
}
