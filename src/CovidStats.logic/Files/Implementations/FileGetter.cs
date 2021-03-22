using System.IO;
using System.Threading.Tasks;
using CovidStats.logic.Files.Interfaces;
using CovidStats.logic.Reports.Interfaces;

namespace CovidStats.logic.Files.Implementations
{
    public class FileGetter : IFileGetter
    {
        private readonly IFileSaver _fileSaver;
        private readonly IReportBuilder _reportBuilder;
        private readonly ISerializer _serializer;

        public FileGetter(IFileSaver fileSaver, IReportBuilder reportBuilder, ISerializer serializer)
        {
            _fileSaver = fileSaver;
            _reportBuilder = reportBuilder;
            _serializer = serializer;
        }

        public async Task<(string fileType, MemoryStream fileData, string fileName)> GetFile(string filePath, string fileExtension)
        {
            var model = await _reportBuilder.GetReportData();
            var serializedData = _serializer.Serialize(model);

            var fileName = await _fileSaver.SaveToFile(filePath, fileExtension, serializedData);
            var fullName = $"{filePath}\\{fileName}";

            var memory = new MemoryStream();

            await using (var stream = new FileStream(fullName, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return ("application/json", memory, fileName);
        }
    }
}