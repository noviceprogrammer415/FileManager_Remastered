using FileManager;
using FileManager.Actions;
using FileManager.Core.Repository;
using FileManager.IOServices;
using FileManager.Services;
using FileManager.Services.Interfaces;

var directoryService = INascency<DirectoryService>.Instance();
var diskService = INascency<DiskService>.Instance();
var fileService = INascency<FileService>.Instance();
var inputService = INascency<InputService>.Instance();
var outputService = INascency<OutputService>.Instance();
var repository = INascency<Repository>.Instance();

Console.Title = "FileManager";

var manager = new Manager(diskService, directoryService, fileService, inputService, outputService, repository);
manager.Run();
