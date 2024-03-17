namespace FileManager.Core.Repository
{
    public interface IRepository
    {
        void Create(string savedPath);
        void Read(string currentPath, out string readPath);
        void Update(string updatedPath);
    }
}
