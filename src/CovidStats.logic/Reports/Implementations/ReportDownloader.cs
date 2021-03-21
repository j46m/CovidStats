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
        private readonly string _filePath;

        public ReportDownloader(ISerializer serializer, IFileSaver fileSaver, IReportBuilder reportBuilder, string filePath)
        {
            _serializer = serializer;
            _fileSaver = fileSaver;
            _reportBuilder = reportBuilder;
            _filePath = filePath;
        }

        public async Task<string> DownloadReport(string fileExtension)
        {
            var reportData = await _reportBuilder.GetReportData();
            var dataSerialized = _serializer.Serialize(reportData);

            var fileSaved = await _fileSaver.SaveToFile(_filePath, fileExtension, dataSerialized);

            return fileSaved;
        }
    }
}