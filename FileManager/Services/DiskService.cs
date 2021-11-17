using FileManager.Services.Interfaces;

namespace FileManager.Actions
{
    public class DiskService : IDiskService<DiskService>, ISingleton<DiskService>
    {
        public IReadOnlyCollection<DiskService> GetCollectionObjects()
        {
            throw new NotImplementedException();
        }
    }
}
