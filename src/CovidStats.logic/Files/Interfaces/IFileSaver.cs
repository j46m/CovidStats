namespace CovidStats.logic.Files.Interfaces
{
    public interface IFileSaver
    {
        string SaveToFile(string filePath, string fileExtension, string dataToSave);
    }
}