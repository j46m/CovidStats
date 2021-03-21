using System;
using CovidStats.logic.Files.Interfaces;

namespace CovidStats.logic.Files.Implementations
{
    public class FileSaver : AbstractFileSaver, IFileSaver
    {
        public string SaveToFile(string filePath, string fileExtension, string dataToSave)
        {
            var fileName = $"{DateTime.Now.Year}{DateTime.Now.Month:D2}{DateTime.Now.Day:D2}{DateTime.Now.Hour}{DateTime.Now.Minute:D2}{DateTime.Now.Second:D2}";
            var fileToSave = $"{fileName}{fileExtension}";

            CreateFile(filePath, fileName, fileExtension, dataToSave);

            return fileToSave;
        }
    }
}