using System.Diagnostics;
using FileManager.Core.Services.Interfaces;
using Serilog;

namespace FileManager.Core.Services
{
    public class DirectoryService : IDirectoryService, ISingleton<DirectoryService>
    {
        private readonly string _error = "Internal error!";

        /// <summary> Копирует содержимое директории </summary>
        /// <param name="sourcePath">путь источника</param>
        /// <param name="destPath">путь цели</param>
        public void Copy(string sourcePath, string destPath)
        {
            var dirSource = new DirectoryInfo(sourcePath);
            var dirDest = new DirectoryInfo(destPath);

            CopyAll(dirSource, dirDest);
        }

        private void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            try
            {
                Directory.CreateDirectory(target.FullName);

                foreach (var fileInfo in source.GetFiles())
                {
                    fileInfo.CopyTo(Path.Combine(target.FullName, fileInfo.Name), overwrite: true);
                }

                foreach (var dirSourceSubDir in source.GetDirectories())
                {
                    DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(dirSourceSubDir.Name);
                    CopyAll(dirSourceSubDir, nextTargetSubDir);
                }
            }
            catch (IOException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine($"{_error}");
            }
            catch (ArgumentException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine($"{_error}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine($"{_error}");
            }
            catch (NotSupportedException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine($"{_error}");
            }
        }

        /// <summary> Создает директорию </summary>
        /// <param name="path">путь, по которому необходимо создать директорию</param>
        /// <returns>результат операции</returns>
        public bool Create(string path)
        {
            try
            {
                if (Directory.Exists(path))
                    Directory.Delete(path);

                Directory.CreateDirectory(path);
                return true;
            }
            catch (IOException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine($"{_error}");
                return false;
            }
            catch (UnauthorizedAccessException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine($"{_error}");
                return false;
            }
            catch (ArgumentException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine($"{_error}");
                return false;
            }
            catch (NotSupportedException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine($"{_error}");
                return false;
            }
        }

        /// <summary> Удаляет директорию и все ее поддиректории и файлы </summary>
        /// <param name="path">путь, по которому необходимо удалить директорию</param>
        /// <returns>результат операции</returns>
        public bool Delete(string path)
        {
            try
            {
                if (Directory.Exists(path))
                    Directory.Delete(path, recursive: true);

                return true;
            }
            catch (IOException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine($"{_error}");
                return false;
            }
            catch (UnauthorizedAccessException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine($"{_error}");
                return false;
            }
            catch (ArgumentException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine($"{_error}");
                return false;
            }
        }

        /// <summary> Получает все файлы и поддиректории, текущей директории </summary>
        /// <param name="path">путь текущей директории</param>
        /// <returns>коллекция с именами файлов и поддиректорий, текущей директории</returns>
        public IEnumerable<string> GetDirectories(string path)
        {
            try
            {
                return Directory.EnumerateFileSystemEntries(path);
            }
            catch (IOException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine($"{_error}");
                return Array.Empty<string>();
            }
            catch (UnauthorizedAccessException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine($"{_error}");
                return Array.Empty<string>();
            }
            catch (ArgumentException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine($"{_error}");
                return Array.Empty<string>();
            }
        }

        /// <summary> Получает размер директории в байтах </summary>
        /// <param name="name">имя директории</param>
        /// <returns>размер в байтах</returns>
        public void GetSize(string name, out long size)
        {
            try
            {
                var directoryInfo = new DirectoryInfo(name);
                size = directoryInfo.GetFiles("*.*", SearchOption.AllDirectories).Sum(f => f.Length);
            }
            catch (IOException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine($"{_error}");
                size = 0;
            }
        }
        
        /// <summary> Переименовывает каталог </summary>
        /// <param name="oldName">имя, которое нужно изменить</param>
        /// <param name="newName">имя, на которое нужно изменить</param>
        public void Move(string oldName, string newName)
        {
            try
            {
                if(Directory.Exists(newName))
                    Directory.Delete(newName);

                Directory.Move(oldName, newName);
            }
            catch (IOException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine($"{_error}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine($"{_error}");
            }
            catch (ArgumentException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine($"{_error}");
            }
        }
    }
}
