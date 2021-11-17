using FileManager;
using FileManager.Actions;
using FileManager.Services;
using FileManager.Services.Interfaces;

var diskService = ISingleton<DiskService>.Instance();
var directoryService = ISingleton<DirectoryService>.Instance();
var fileService = ISingleton<FileService>.Instance();

var manager = new Manager(diskService, directoryService, fileService);

