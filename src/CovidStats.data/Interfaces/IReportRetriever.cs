using System.Threading.Tasks;
using CovidStats.data.DTO;

namespace CovidStats.data.Interfaces
{
    public interface IReportRetriever
    {
        Task<ApiReportResponse> RetrieveAllData();
    }
}