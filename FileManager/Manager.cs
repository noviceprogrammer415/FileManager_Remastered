using FileManager.Core.Services;
using FileManager.IOServices.Interfaces;
using FileManager.Services.Interfaces;
using System.Text;

namespace FileManager
{ 
    public class Manager
    {
        private readonly IDiskService _diskService;
        private readonly IDirectoryService _directoryService;
        private readonly IFileService _fileService;
        private readonly IInputService _inputService;

        public Manager(IDiskService diskService,
            IDirectoryService directoryService,
            IFileService fileService,
            IInputService inputServices)
        {
            _diskService = diskService;
            _directoryService = directoryService;
            _fileService = fileService;
            _inputService = inputServices;
        }

        public void Run()
        {
            StringBuilder command, path;

            do
            {
                _inputService.InputData(out command, out path);
                if(!string.IsNullOrEmpty(command.ToString())) ManageDirectory(command, path);
            } while (!command.Equals(Commands.exit.ToString()));
        }

        private void ManageDirectory(StringBuilder command, StringBuilder path)
        {
            switch (command.ToString())
            {
                case nameof(Commands.dir):
                    _directoryService.GetDirectories(path);
                    break;
                case nameof(Commands.disk):
                    _diskService.GetDisks();
                    break;
                case nameof(Commands.exit):
                    return;
                default:
                    Console.WriteLine("Сommand not found!");
                    break;
            }
        }
    }
}
