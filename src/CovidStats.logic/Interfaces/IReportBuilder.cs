using System.Collections.Generic;
using System.Threading.Tasks;
using CovidStats.logic.DTO;

namespace CovidStats.logic.Interfaces
{
    public interface IReportBuilder
    {
        Task<List<ReportData>> GetReportData();
    }
}