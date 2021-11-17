using FileManager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.IOServices.Interfaces
{
    public interface IInputServices : ISingleton<InputService>
    {
        void InputData();
    }
}
