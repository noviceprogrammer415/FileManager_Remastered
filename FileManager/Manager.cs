using FileManager.Core.Report;
using FileManager.Core.Repository;
using FileManager.Services.Interfaces;
using FileManager.Core.Services.Interfaces;
using FileManager.UserInterfaces.ConsoleInterface.Interfaces;
using FileManager.Core.Enums;

namespace FileManager
{
    public sealed class Manager
    {
        private string _currentPath = Directory.GetCurrentDirectory();
        private readonly IDiskService _diskService;
        private readonly IDirectoryService _directoryService;
        private const string _fileName = "SavePath.txt";
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
            (_diskService, _directoryService, _fileService, _inputService, _outputService, _repository) 
                = (diskService, directoryService, fileService, inputServices, outputService, repository);
        }

        public void Run()
        {
            string command;

            if (File.Exists(_fileName))
                _repository.Read(_currentPath, out _currentPath);

            do
            {
                _inputService.InputData(ref _currentPath!, out command, out var sourcePath, out var destPath);
                if (!string.IsNullOrEmpty(command)) ExecuteCommands(ref command, ref sourcePath, ref destPath);
            } while (command is not nameof(Commands.Exit));
        }
                
        private void ExecuteCommands(ref string command, ref string sourcePath, ref string destPath)
        {
            switch (command)
            {
                case nameof(Commands.Back):
                    _currentPath = Directory.GetParent(_currentPath!)?.FullName!;
                    break;

                case nameof(Commands.Btr):
                    _currentPath = Directory.GetDirectoryRoot(_currentPath!);
                    break;

                case nameof(Commands.Crt):
                    if (Path.HasExtension(sourcePath)) _fileService.Create(Path.Combine(_currentPath!, sourcePath));
                    else _directoryService.Create(Path.Combine(_currentPath!, sourcePath));
                    break;

                case nameof(Commands.Cp):
                    if(Path.HasExtension(sourcePath)) _fileService.Copy(Path.Combine(_currentPath!, sourcePath), Path.Combine(destPath, sourcePath));
                    else _directoryService.Copy(Path.Combine(_currentPath!, sourcePath), Path.Combine(destPath, sourcePath));
                    break;

                case nameof(Commands.Dir):
                    var directories = _directoryService.GetDirectories(_currentPath!);
                    _outputService.PrintCollectionObjects(directories);
                    return;

                case nameof(Commands.Disk):
                    var disks = _diskService.GetDisks();
                    _outputService.PrintCollectionObjects(disks);
                    return;

                case nameof(Commands.Diskpart): _currentPath = sourcePath;
                    break;

                case nameof(Commands.Diskreport):
                    var reportService = ISingleton<ReportService>.Instance;
                    reportService?.GenerateReport(new("DiskReportTemplate.docx"), "DiskReport.docx");
                    break;

                case nameof(Commands.Cd): _currentPath = Path.Combine(_currentPath!, sourcePath);
                    break;

                case nameof(Commands.Cls): Console.Clear();
                    return;

                case nameof(Commands.Exit):
                    if (File.Exists(_fileName)) _repository.Update(_currentPath!); 
                    else _repository.Create(_currentPath!);
                    return;

                case nameof(Commands.Move):
                    if (Path.HasExtension(sourcePath)) _fileService.Move(Path.Combine(_currentPath!, sourcePath), Path.Combine(destPath, sourcePath));
                    else _directoryService.Move(Path.Combine(_currentPath!, sourcePath), Path.Combine(destPath, sourcePath));
                    break;

                case nameof(Commands.Rename):
                    if(Path.HasExtension(sourcePath)) _fileService.Move(Path.Combine(_currentPath!, sourcePath), Path.Combine(_currentPath!, destPath));
                    else _directoryService.Move(Path.Combine(_currentPath!, sourcePath), Path.Combine(_currentPath!, destPath));
                    break;

                case nameof(Commands.Rm):
                    if (Path.HasExtension(sourcePath)) _fileService.Delete(Path.Combine(_currentPath!, sourcePath));
                    else _directoryService.Delete(Path.Combine(_currentPath!, sourcePath));
                    break;

                case nameof(Commands.Size):
                    if (Path.HasExtension(sourcePath))
                    {
                        _fileService.GetSize(Path.Combine(_currentPath!, sourcePath), out long sizeFile);
                        _outputService.PrintSizeObject(ref sourcePath, ref sizeFile);
                    }
                    else
                    {
                        _directoryService.GetSize(Path.Combine(_currentPath!, sourcePath), out long sizeDirectory);
                        _outputService.PrintSizeObject(ref sourcePath, ref sizeDirectory);
                    }
                    break;

                case nameof(Commands.Help):
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Out.WriteLine($"{DateTime.Now:hh.mm.ss dd.MM.yyyy} Команда не найдена!");
                    Console.ResetColor();
                    return;
            }
        }
    }
}
