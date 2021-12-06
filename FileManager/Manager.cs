using FileManager.Core.Repository;
using FileManager.Core.Services;
using FileManager.IOServices.Interfaces;
using FileManager.Services.Interfaces;
using System.Text;

namespace FileManager
{ 
    public class Manager
    {
        private string? _currentDirectory;
        private readonly IDiskService _diskService;
        private readonly IDirectoryService _directoryService;
        private readonly IFileService _fileService;
        private readonly IInputService _inputService;
        private readonly IOutputService _outputService;
        private readonly IRepository _repository;

        public Manager(IDiskService diskService,
            IDirectoryService directoryService,
            IFileService fileService,
            IInputService inputServices,
            IOutputService outputService,
            IRepository repository)
        {
            _diskService = diskService;
            _directoryService = directoryService;
            _fileService = fileService;
            _inputService = inputServices;
            _outputService = outputService;
            _repository = repository;
        }

        public void Run()
        {
            string command;

            do
            {
                _inputService.InputData(ref _currentDirectory!, out command, out string path);
                if(!string.IsNullOrEmpty(command.ToString())) ManageDirectory(command, path);
            } while (!command.Equals(Commands.exit.ToString()));
        }

        private void ManageDirectory(string command, string path)
        {
            switch (command.ToString())
            {
                case nameof(Commands.back):
                    
                    break;
                case nameof(Commands.dir):
                    var directories = _directoryService.GetDirectories(_currentDirectory!);
                    _outputService.PrintCollectionObjects(directories);
                    return;
                case nameof(Commands.disk):
                    var disks = _diskService.GetDisks();
                    _outputService.PrintCollectionObjects(disks);
                    return;
                case nameof(Commands.diskpart): _currentDirectory = path;
                    break;
                case nameof(Commands.cd): _currentDirectory = Path.Combine(_currentDirectory!, path);
                    break;
                case nameof(Commands.clr): Console.Clear();
                    return;
                case nameof(Commands.exit): return;
                default:
                    Console.WriteLine("Сommand not found!");
                    return;
            }
        }
    }
}
