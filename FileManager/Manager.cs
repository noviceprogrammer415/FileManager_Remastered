﻿using FileManager.Core.Report;
using FileManager.Core.Repository;
using FileManager.Core.Services;
using FileManager.Services.Interfaces;
using FileManager.Core.Services.Interfaces;
using FileManager.UserInterfaces.ConsoleInterface.Interfaces;

namespace FileManager
{ 
    public sealed class Manager
    {
        private string? _currentPath;
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

            if(File.Exists(_fileName))
                _repository.Read(out _currentPath);

            do
            {
                _inputService.InputData(ref _currentPath!, out command, out var path);
                if(!string.IsNullOrEmpty(command)) ExecuteCommands(command, path);
            } while (!command.Equals(Commands.exit.ToString()));
        }

        private void ExecuteCommands(string command, string path)
        {
            switch (command)
            {
                case nameof(Commands.back):
                    _currentPath = Directory.GetParent(_currentPath!)?.FullName;
                    break;
                case nameof(Commands.btr):
                    _currentPath = Directory.GetDirectoryRoot(_currentPath!);
                    break;
                case nameof(Commands.crt):
                    if (Path.HasExtension(path)) _fileService.Create(Path.Combine(_currentPath!, path));
                    else _directoryService.Create(Path.Combine(_currentPath!, path));
                    break;
                case nameof(Commands.dir):
                    var directories = _directoryService.GetDirectories(_currentPath!);
                    _outputService.PrintCollectionObjects(directories);
                    return;
                case nameof(Commands.disk):
                    var disks = _diskService.GetDisks();
                    _outputService.PrintCollectionObjects(disks);
                    return;
                case nameof(Commands.diskpart): _currentPath = path;
                    break;
                case nameof(Commands.diskreport):
                    var reportService = ISingleton<ReportService>.Instance;
                    reportService?.GenerateReport(new("DiskReportTemplate.docx"), "DiskReport.docx");
                    break;
                case nameof(Commands.cd): _currentPath = Path.Combine(_currentPath!, path);
                    break;
                case nameof(Commands.clr): Console.Clear();
                    return;
                case nameof(Commands.exit):
                    if (File.Exists(_fileName)) _repository.Update(_currentPath!); 
                    else _repository.Create(_currentPath!);
                    return;
                case nameof(Commands.rm):
                    if (Path.HasExtension(path)) _fileService.Delete(Path.Combine(_currentPath!, path));
                    else _directoryService.Delete(Path.Combine(_currentPath!, path));
                    break;
                default:
                    Console.WriteLine("Command not found!");
                    return;
            }
        }
    }
}
