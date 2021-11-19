using FileManager.Services.Interfaces;

namespace FileManager.Services
{
    public class FileService : IFileService, ISingleton<FileService>
    {
        public void Copy()
        {
            throw new NotImplementedException();
        }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<DirectoryInfo> GetCollectionFiles()
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
