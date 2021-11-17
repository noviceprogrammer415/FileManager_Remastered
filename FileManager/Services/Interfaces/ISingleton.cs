using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Services.Interfaces
{
    public interface ISingleton<T> where T : new()
    {
        static T? _instance;
        static T Instance()
        {
            if (_instance is null) _instance = new();
            return _instance;
        }
    }
}
