using FileManager.Services.Interfaces;

namespace FileManager.Actions
{
    public class DiskService : IDiskService, ISingleton<DiskService>
    {
        public IReadOnlyCollection<DriveInfo> GetCollectionDisks() => DriveInfo.GetDrives();
    }
}
