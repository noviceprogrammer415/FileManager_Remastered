using System.Text;

namespace FileManager.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        void Copy(StringBuilder sourcePath, StringBuilder destPath);
        bool Create(StringBuilder path);
        bool Delete(StringBuilder path);
        long GetSize(StringBuilder name);
        bool Move(StringBuilder sourcePath, StringBuilder destPath);
        void Rename(StringBuilder oldName, StringBuilder newName);
    }
}
