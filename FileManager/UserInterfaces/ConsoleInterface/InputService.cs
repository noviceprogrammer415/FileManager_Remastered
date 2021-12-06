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
        public void InputData(ref string currentDirrectory, out string command, out string path)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($">>[{currentDirrectory}] ");
            Console.ResetColor();

            var entryArray = Console.ReadLine()?.Split(" ");

            command = entryArray?[0]!;
            path = entryArray?.Length > 1 ? entryArray?[1]! : "";
        }
    }
}
