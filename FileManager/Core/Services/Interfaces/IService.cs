namespace FileManager.Core.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        void Copy(string sourcePath, string destPath);
        bool Create(string path);
        bool Delete(string path);
        long GetSize(string name);
        bool Move(string sourcePath, string destPath);
        void Rename(string oldName, string newName);
    }
}
