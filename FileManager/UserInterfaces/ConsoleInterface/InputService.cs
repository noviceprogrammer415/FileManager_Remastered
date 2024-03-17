using FileManager.Core.Services;
using FileManager.UserInterfaces.ConsoleInterface.Interfaces;

namespace FileManager.UserInterfaces.ConsoleInterface
{
    public sealed class InputService : IInputService
    {
        private string _datePattern = $"{DateTime.Now:HH.mm.ss dd.MM.yyyy}";

        public void InputData(ref string currentDirectory, out string command, out string sourcePath, out string destPath)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Out.Write($">>[{currentDirectory}] ");
                Console.ResetColor();

                var entryArray = Console.In.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (entryArray is null or { Length: 0 })
                    throw new IndexOutOfRangeException($"{_datePattern} Введено пустое значение");

                if (entryArray.Length > 1)
                    if (!Directory.Exists(entryArray[1]))
                        throw new ArgumentException($"{_datePattern} Директория не существует");

                command = entryArray[0].Replace(entryArray[0][0], char.ToUpper(entryArray[0][0]));
                sourcePath = entryArray.Length > 1 ? entryArray[1] : "";
                destPath = entryArray.Length > 2 ? entryArray[2] : "";
            }
            catch (Exception ex) 
            {
                PaintText(() => Console.Out.WriteLine(ex.Message), ConsoleColor.DarkRed);
                Logger.Log.Error(ex.Message);
                command = string.Empty;
                sourcePath = string.Empty;
                destPath = string.Empty;
            }
        }

        private void PaintText(Action act, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            act.Invoke();
            Console.ResetColor();
        }
    }
}
