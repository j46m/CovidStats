using System.Collections.Generic;
using System.Threading.Tasks;
using CovidStats.logic.Reports.DTO;

namespace CovidStats.logic.Reports.Interfaces
{
    public interface IReportBuilder
    {
        Task<List<ReportData>> GetReportData();
    }
}