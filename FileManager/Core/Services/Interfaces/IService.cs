using System.Text;

namespace FileManager.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        void Copy();
        bool Create(StringBuilder path);
        bool Delete(StringBuilder path);
        void Move();
        void Rename();
    }
}
