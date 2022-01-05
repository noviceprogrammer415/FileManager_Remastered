namespace FileManager.Core.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        void Copy(string sourcePath, string destPath);
        bool Create(string path);
        bool Delete(string path);
        long GetSize(string name);
        void Move(string sourcePath, string destPath);
    }
}
