using System.Threading.Tasks;

namespace CovidStats.logic.Reports.Interfaces
{
    public interface IReportDownloader
    {
        Task<string> DownloadReport();
    }
}