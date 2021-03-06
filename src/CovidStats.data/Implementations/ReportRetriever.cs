using System.Net.Http;
using System.Threading.Tasks;
using CovidStats.data.DTO;
using CovidStats.data.Interfaces;
using Newtonsoft.Json;

namespace CovidStats.data.Implementations
{
    public class ReportRetriever : IReportRetriever
    {
        private readonly ReportConfig _config;
        private readonly IHttpClientFactory _httpFactory;
        public ReportRetriever(ReportConfig config, IHttpClientFactory httpFactory)
        {
            _config = config;
            _httpFactory = httpFactory;
        }
        public async Task<ApiReportResponse> RetrieveAllData(string param = "")
        {
            var httpClient = _httpFactory.CreateClient("ReportDataClient");

            httpClient.DefaultRequestHeaders.Add("x-rapidapi-key", _config.ApiKey);
            httpClient.DefaultRequestHeaders.Add("x-rapidapi-host", _config.ApiHost);

            using var response = await httpClient.GetAsync($"{_config.Url}{param}");

            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();

            var allData = DeserializeData(apiResponse);

            return allData;
        }

        private ApiReportResponse DeserializeData(string apiResponse)
        {
            return JsonConvert.DeserializeObject<ApiReportResponse>(apiResponse);
        }
    }
}