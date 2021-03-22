using System.IO;
using System.Threading.Tasks;

namespace CovidStats.logic.Files.Interfaces
{
    public interface IFileGetter
    {
        Task<(string fileType, MemoryStream fileData, string fileName)> GetFile(string filePath, string fileExtension);
    }
}