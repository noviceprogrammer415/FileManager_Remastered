namespace FileManager.Core.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        void Copy(string sourcePath, string destPath);
        bool Create(string path);
        bool Delete(string path);
        void GetSize(string name, out long size);
        void Move(string sourcePath, string destPath);
    }
}
