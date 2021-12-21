using FileManager.UserInterfaces.ConsoleInterface.Interfaces;

namespace FileManager.UserInterfaces.ConsoleInterface
{
    public class InputService : IInputService
    {
        public void InputData(ref string currentDirectory, out string command, out string path)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($">>[{currentDirectory}] ");
            Console.ResetColor();

            var entryArray = Console.ReadLine()?.Split(" ");

            command = entryArray?[0]!;
            path = entryArray?.Length > 1 ? entryArray?[1]! : "";
        }
    }
}
