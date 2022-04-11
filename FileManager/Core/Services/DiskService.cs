using System.Diagnostics;
using System.Text;
using FileManager.Core.Services.Interfaces;
using FileManager.Services.Interfaces;

namespace FileManager.Core.Services
{
    public class DiskService : IDiskService, ISingleton<DiskService>
    {
        private readonly string _error = "Internal error!";

        public IEnumerable<DriveInfo> GetDisks()
        {
            try
            {
                return DriveInfo.GetDrives();
            }
            catch (IOException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine(_error);
                return Array.Empty<DriveInfo>();
            }
            catch (UnauthorizedAccessException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine(_error);
                return Array.Empty<DriveInfo>();
            }
        }
    }
}
