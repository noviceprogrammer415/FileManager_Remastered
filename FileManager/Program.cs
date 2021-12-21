using FileManager;
using FileManager.Core.Repository;
using FileManager.Core.Services;
using FileManager.Core.Services.Interfaces;
using FileManager.UserInterfaces.ConsoleInterface;

var directoryService = ISingleton<DirectoryService>.Instance;
var diskService = ISingleton<DiskService>.Instance;
var fileService = ISingleton<FileService>.Instance;
var inputService = ISingleton<InputService>.Instance;
var outputService = ISingleton<OutputService>.Instance;
var repository = ISingleton<Repository>.Instance;

Console.Title = "FileManager";

var manager = new Manager(diskService, directoryService, fileService, inputService, outputService, repository);
manager.Run();
