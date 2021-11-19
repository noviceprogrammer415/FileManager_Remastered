using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Services.Interfaces
{
    public interface IFileService : IService<FileService>
    {
        IReadOnlyCollection<DirectoryInfo> GetCollectionFiles();
    }
}
