namespace FileManager.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        void Copy();
        void Create();
        void Delete();
        void Move();
        void Rename();
    }
}
