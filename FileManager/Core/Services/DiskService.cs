using FileManager.Services.Interfaces;
using System.Diagnostics;

namespace FileManager.Actions
{
    public class DiskService : IDiskService, ISingleton<DiskService>
    {
        /// <summary> Получает список дисков </summary>
        /// <returns>возвращает коллекцию дисков</returns>
        public IReadOnlyCollection<DriveInfo> GetDisks() 
        {
            try
            {
               return DriveInfo.GetDrives();
            }
            catch (IOException ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
