using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Services.Interfaces
{
    public interface IDirectoryService : IService<DirectoryService>
    {
        IEnumerable<string> GetDirectories(string path);
    }
}
