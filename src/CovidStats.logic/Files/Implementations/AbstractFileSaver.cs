using System.IO;
using System.Threading.Tasks;

namespace CovidStats.logic.Files.Implementations
{
    public class AbstractFileSaver
    {
        protected async Task CreateFile(string filePath, string fileName, string fileExtension, string data)
        {
            var finalPath = $"{filePath}\\{fileName}{fileExtension}";

            await using var writer = File.CreateText(finalPath);
            await writer.WriteAsync(data);
        }
    }
}