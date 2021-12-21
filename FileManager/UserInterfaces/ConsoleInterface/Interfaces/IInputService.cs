using FileManager.Core.Services.Interfaces;

namespace FileManager.UserInterfaces.ConsoleInterface.Interfaces
{
    public interface IInputService : ISingleton<InputService>
    {
        void InputData(ref string currentDirectory, out string command, out string path);
    }
}
