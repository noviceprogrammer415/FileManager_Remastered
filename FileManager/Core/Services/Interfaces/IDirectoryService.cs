using FileManager.Services.Interfaces;

namespace FileManager.Core.Services.Interfaces
{
    public interface IDirectoryService : IService<DirectoryService>
    {
        IEnumerable<string> GetDirectories(string path);
    }
}
