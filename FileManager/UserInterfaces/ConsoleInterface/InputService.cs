using FileManager.UserInterfaces.ConsoleInterface.Interfaces;

namespace FileManager.UserInterfaces.ConsoleInterface
{
    public class InputService : IInputService
    {
        public void InputData(ref string currentDirectory, out string command, out string sourcePath, out string destPath)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($">>[{currentDirectory}] ");
                Console.ResetColor();

                var entryArray = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                command = entryArray?[0]!;
                sourcePath = entryArray?.Length > 1 ? entryArray[1] : "";
                destPath = entryArray?.Length > 2 ? entryArray[2] : "";
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
