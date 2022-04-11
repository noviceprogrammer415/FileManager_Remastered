namespace FileManager.Services.Interfaces
{
    public interface IDiskService
    { 
        IEnumerable<DriveInfo> GetDisks();
    }
}
