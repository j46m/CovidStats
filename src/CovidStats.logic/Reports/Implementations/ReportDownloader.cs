using System.Threading.Tasks;
using CovidStats.logic.Files.Interfaces;
using CovidStats.logic.Reports.Interfaces;

namespace CovidStats.logic.Reports.Implementations
{
    public class ReportDownloader : IReportDownloader
    {
        private readonly ISerializer _serializer;
        private readonly IFileSaver _fileSaver;
        private readonly IReportBuilder _reportBuilder;

        public ReportDownloader(ISerializer serializer, IFileSaver fileSaver, IReportBuilder reportBuilder)
        {
            _serializer = serializer;
            _fileSaver = fileSaver;
            _reportBuilder = reportBuilder;
        }

        public async Task<string> DownloadReport()
        {
            var reportData = await _reportBuilder.GetReportData();
            var dataSerialized = _serializer.Serialize(reportData);

            var fileSaved = _fileSaver.SaveToFile("","", dataSerialized);

            return fileSaved;
        }
    }
}