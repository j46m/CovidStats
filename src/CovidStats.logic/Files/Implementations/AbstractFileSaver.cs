namespace CovidStats.logic.Files.Implementations
{
    public class AbstractFileSaver
    {
        protected void CreateFile(string filePath, string fileName, string fileExtension, string data)
        {
            var finalPath = $"{fileName}{fileExtension}";
            using var streamWriter = System.IO.File.CreateText(finalPath);
            streamWriter.WriteLine(data);
        }
    }
}