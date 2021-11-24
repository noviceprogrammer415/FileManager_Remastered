using FileManager.IOServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.IOServices
{
    public class InputService : IInputService
    {
        public void InputData(out StringBuilder command, out StringBuilder path)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($">>[] ");
            Console.ResetColor();

            var str = Console.ReadLine();
            var Command = str?.ToString().Split(" ")[0];
            var Path = str?.ToString().Remove(0, Command!.Length);

            command = new(Command, Command!.Length);
            path = new(Path, Path!.Length);
        }
    }
}
