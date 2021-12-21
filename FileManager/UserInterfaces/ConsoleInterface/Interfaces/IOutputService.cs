using FileManager.Core.Services.Interfaces;

namespace FileManager.UserInterfaces.ConsoleInterface.Interfaces
{
    public interface IOutputService : ISingleton<OutputService>
    {
        void PrintCollectionObjects<T>(IEnumerable<T> collection);
    }
}
