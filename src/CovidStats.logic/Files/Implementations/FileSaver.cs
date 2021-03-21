using System;
using System.Threading.Tasks;
using CovidStats.logic.Files.Interfaces;

namespace CovidStats.logic.Files.Implementations
{
    public class FileSaver : AbstractFileSaver, IFileSaver
    {
        public async Task<string> SaveToFile(string filePath, string fileExtension, string dataToSave)
        {
            var fileName = $"{DateTime.Now.Year}{DateTime.Now.Month:D2}{DateTime.Now.Day:D2}{DateTime.Now.Hour}{DateTime.Now.Minute:D2}{DateTime.Now.Second:D2}";
            var fileToSave = $"{fileName}{fileExtension}";

            await CreateFile(filePath, fileName, fileExtension, dataToSave);

            return fileToSave;
        }
    }
}