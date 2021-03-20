﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidStats.data.DTO;
using CovidStats.data.Interfaces;
using CovidStats.logic.DTO;
using CovidStats.logic.Interfaces;

namespace CovidStats.logic.Implementations
{
    public class ReportBuilder : IReportBuilder
    {
        private readonly IReportRetriever _reportRetriever;

        public ReportBuilder(IReportRetriever reportRetriever)
        {
            _reportRetriever = reportRetriever;
        }

        public async Task<List<ReportData>> GetReportData()
        {
            var regionDataFromApi = await _reportRetriever.RetrieveAllData();
            var topTenRegions = FilterTopTenRegions(regionDataFromApi).ToList();
            var reportData = new List<ReportData>();

            topTenRegions.ForEach(x =>
            {

                reportData.Add(new ReportData
                {
                    Cases = x.confirmed,
                    Deaths = x.deaths
                });

            });

            return reportData;
        }

        private IEnumerable<Datum> FilterTopTenRegions(ApiReportResponse apiResponse)
        {
            return apiResponse.data.OrderBy(x => x.confirmed).Take(10);
        }
    }
}