using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Services.Interfaces
{
    public interface ISingleton<T> where T : new()
    {
        static T Instance()
        {
            T? instance = default;
            if (instance is null) instance = new();
            return instance;
        }
    }
}
