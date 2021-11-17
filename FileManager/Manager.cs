using FileManager.Actions;
using FileManager.Services;
using FileManager.Services.Interfaces;

namespace FileManager
{ 
    public class Manager
    {
        private readonly IDiskService<DiskService> _diskService;
        private readonly IDirectoryService _directoryService;
        private readonly IFileService _fileService;

        public Manager(IDiskService<DiskService> diskService,
            IDirectoryService directoryService,
            IFileService fileService)
        {
            _diskService = diskService;
            _directoryService = directoryService;
            _fileService = fileService;
        }



        public void GetDisks()
        {
            _diskService.GetCollectionObjects();
        }
    }
}
