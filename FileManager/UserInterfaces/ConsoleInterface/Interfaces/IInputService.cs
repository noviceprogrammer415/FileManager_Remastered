using FileManager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.IOServices.Interfaces
{
    public interface IInputService : INascency<InputService>
    {
        void InputData(ref string currentDirrectory, out string command, out string path);
    }
}
