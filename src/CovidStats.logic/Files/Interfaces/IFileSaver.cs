using System.Threading.Tasks;

namespace CovidStats.logic.Files.Interfaces
{
    public interface IFileSaver
    {
        Task<string> SaveToFile(string filePath, string fileExtension, string dataToSave);
    }
}