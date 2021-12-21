using System.Diagnostics;
using System.Text;
using FileManager.Core.Services.Interfaces;
using FileManager.Services.Interfaces;

namespace FileManager.Core.Services
{
    public class DiskService : IDiskService, ISingleton<DiskService>
    {
        private readonly StringBuilder _error = new("Internal Error! Code: ");
        [Flags] private enum Errors { D1v, D2v };

        public IEnumerable<DriveInfo> GetDisks()
        {
            try
            {
                return DriveInfo.GetDrives();
            }
            catch (IOException ex)
            {
                Debug.WriteLine(ex.Message);
                Console.WriteLine(_error.Append(Errors.D1v));
                return Array.Empty<DriveInfo>();
            }
            catch (UnauthorizedAccessException ex)
            {
                Debug.WriteLine(ex.Message);
                Console.WriteLine(_error.Append(Errors.D2v));
                return Array.Empty<DriveInfo>();
            }
        }
    }
}
