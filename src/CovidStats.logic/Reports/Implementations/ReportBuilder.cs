using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidStats.data.DTO;
using CovidStats.data.Interfaces;
using CovidStats.logic.Reports.DTO;
using CovidStats.logic.Reports.Interfaces;

namespace CovidStats.logic.Reports.Implementations
{
    public class ReportBuilder : IReportBuilder
    {
        private readonly IReportRetriever _reportRetriever;

        public ReportBuilder(IReportRetriever reportRetriever)
        {
            _reportRetriever = reportRetriever;
        }

        public async Task<List<ReportData>> GetReportData(string param = "")
        {
            var regionDataFromApi = await _reportRetriever.RetrieveAllData(param);
            var topTenRegions = FilterTopTenData(regionDataFromApi).ToList();
            var reportData = new List<ReportData>();

            var iD = 0;
            topTenRegions.ForEach(x =>
            {
                iD++;
                reportData.Add(new ReportData
                {
                    Id = iD,
                    RegionName = x.region.name,
                    ProvinceName = x.region.province,
                    Iso = x.region.iso,
                    Cases = x.confirmed,
                    Deaths = x.deaths
                });

            });

            return reportData;
        }

        private IEnumerable<Datum> FilterTopTenData(ApiReportResponse apiResponse)
        {
            return apiResponse.data
                .Where(x => x.confirmed > 0)
                .OrderByDescending(x => x.confirmed)
                .Take(10);
        }
    }
}