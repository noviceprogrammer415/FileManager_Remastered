namespace FileManager.Core.Repository
{
    public interface IRepository
    {
        void Create(string path);
        void Read();
        void Update(string path);
    }
}
