using FileManager;
using FileManager.Actions;
using FileManager.IOServices;
using FileManager.Services;
using FileManager.Services.Interfaces;

var diskService = ISingleton<DiskService>.Instance();
var directoryService = ISingleton<DirectoryService>.Instance();
var fileService = ISingleton<FileService>.Instance();
var inputService = ISingleton<InputService>.Instance();
var outputService = ISingleton<OutputService>.Instance();

Console.Title = "FileManager";

var manager = new Manager(diskService, directoryService, fileService, inputService, outputService);
manager.Run();
