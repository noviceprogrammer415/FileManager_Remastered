using FileManager.Services.Interfaces;
using System.Text;

namespace FileManager.Services
{
    public class FileService : IFileService, ISingleton<FileService>
    {
        public void Copy(StringBuilder sourceName, StringBuilder destName)
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

        public bool Move(StringBuilder sourceName, StringBuilder destName)
        {
            throw new NotImplementedException();
        }

        public void Rename(StringBuilder oldName, StringBuilder newName)
        {
            throw new NotImplementedException();
        }
    }
}
