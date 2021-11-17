using FileManager.IOServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.IOServices
{
    public class InputService : IInputServices
    {
        public void InputData()
        {
            Console.ReadLine();
        }
    }
}
