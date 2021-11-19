using FileManager.Services.Interfaces;
using System.Security;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;

namespace FileManager.Services
{
    public class DirectoryService : IDirectoryService, ISingleton<DirectoryService>
    {
        public void Copy()
        {
            throw new NotImplementedException();
        }

        public bool Create(StringBuilder path)
        {
            try
            {
                if (!Directory.Exists(path.ToString()))
                {
                    Directory.CreateDirectory(path.ToString());
                    return true;
                }

                return false;
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
            catch (ArgumentException ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            catch (NotSupportedException ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public bool Delete(StringBuilder path)
        {
            try
            {
                if (Directory.Exists(path.ToString()))
                {
                    Directory.Delete(path.ToString(), true);
                    return true;
                }

                return false;
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
            catch (ArgumentException ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public IReadOnlyCollection<string> GetDirectories(StringBuilder path)
        {
            try
            {
                return Directory.GetFileSystemEntries(path.ToString());
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
            catch (ArgumentException ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public void Move()
        {
            throw new NotImplementedException();
        }

        public void Rename()
        {
            throw new NotImplementedException();
        }
    }
}
