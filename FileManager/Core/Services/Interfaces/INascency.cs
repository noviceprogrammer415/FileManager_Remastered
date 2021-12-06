namespace FileManager.Services.Interfaces
{
    public interface INascency<T> where T : new()
    {
        static T? _instance;
        static T Instance()
        {
            if (_instance is null) _instance = new();
            return _instance;
        }
    }
}
