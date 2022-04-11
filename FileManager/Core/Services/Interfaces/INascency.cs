namespace FileManager.Core.Services.Interfaces
{
    public interface ISingleton<T> where T : class, new()
    {
        static T? _instance;
        static T? Instance => _instance ??= new T();
    }
}
