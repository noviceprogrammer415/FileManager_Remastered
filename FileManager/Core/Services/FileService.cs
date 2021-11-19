using FileManager.Services.Interfaces;
using System.Text;

namespace FileManager.Services
{
    public class FileService : IFileService, ISingleton<FileService>
    {
        public void Copy()
        {
            throw new NotImplementedException();
        }

        public bool Create(StringBuilder name)
        {
            throw new NotImplementedException();
        }

        public bool Delete(StringBuilder name)
        {
            throw new NotImplementedException();
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
