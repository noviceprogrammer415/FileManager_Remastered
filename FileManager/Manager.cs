using FileManager.Actions;
using FileManager.IOServices.Interfaces;
using FileManager.Services;
using FileManager.Services.Interfaces;
using System.Text;

namespace FileManager
{ 
    public class Manager
    {
        private readonly IDiskService _diskService;
        private readonly IDirectoryService _directoryService;
        private readonly IFileService _fileService;
        private readonly IInputServices _inputService;

        public Manager(IDiskService diskService,
            IDirectoryService directoryService,
            IFileService fileService,
            IInputServices inputServices)
        {
            _diskService = diskService;
            _directoryService = directoryService;
            _fileService = fileService;
            _inputService = inputServices;
        }

        public void Run()
        {
            var path = new StringBuilder("c:\\Test\\Changes");
            var path_2 = new StringBuilder("c:\\Test\\Changes\\Test2\\88881.txt");
            var result = _directoryService.GetSize(path);
        }
    }
}
