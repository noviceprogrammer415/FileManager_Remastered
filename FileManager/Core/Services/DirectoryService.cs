using FileManager.Services.Interfaces;
using System.Security;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;

namespace FileManager.Services
{
    public class DirectoryService : IDirectoryService, ISingleton<DirectoryService>
    {
        private string _error = "Internal Error! Code:";
        [Flags] private enum Errors { D1, D2, D3, D4 };

        /// <summary> Копирует содержимое директории </summary>
        /// <param name="sourcePath">путь источника</param>
        /// <param name="destPath">путь цели</param>
        public void Copy(StringBuilder sourcePath, StringBuilder destPath)
        {
            var dirSource = new DirectoryInfo(sourcePath.ToString());
            var dirDest = new DirectoryInfo(destPath.ToString());

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
                Debug.WriteLine(ex.Message);
                Console.WriteLine($"{_error} {Errors.D1}");
            }
            catch (ArgumentException ex)
            {
                Debug.WriteLine(ex.Message);
                Console.WriteLine($"{_error} {Errors.D2}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Debug.WriteLine(ex.Message);
                Console.WriteLine($"{_error} {Errors.D3}");
            }
            catch (NotSupportedException ex)
            {
                Debug.WriteLine(ex.Message);
                Console.WriteLine($"{_error} {Errors.D4}");
            }
        }

        /// <summary> Создает директорию </summary>
        /// <param name="path">путь, по которому необходимо создать директорию</param>
        /// <returns>результат операции</returns>
        public bool Create(StringBuilder path)
        {
            try
            {
                if (!Directory.Exists(path.ToString()))
                {
                    Directory.CreateDirectory(path.ToString());
                    return true;
                }

                return false;
            }
            catch (IOException ex)
            {
                Debug.WriteLine(ex.Message);
                Console.WriteLine($"{_error} {Errors.D1}");
                return false;
            }
            catch (UnauthorizedAccessException ex)
            {
                Debug.WriteLine(ex.Message);
                Console.WriteLine($"{_error} {Errors.D3}");
                return false;
            }
            catch (ArgumentException ex)
            {
                Debug.WriteLine(ex.Message);
                Console.WriteLine($"{_error} {Errors.D2}");
                return false;
            }
            catch (NotSupportedException ex)
            {
                Debug.WriteLine(ex.Message);
                Console.WriteLine($"{_error} {Errors.D4}");
                return false;
            }
        }

        /// <summary> Удаляет директорию и все ее поддиректории и файлы </summary>
        /// <param name="path">путь, по которому необходимо удалить директорию</param>
        /// <returns>результат операции</returns>
        public bool Delete(StringBuilder path)
        {
            try
            {
                if (Directory.Exists(path.ToString()))
                {
                    Directory.Delete(path.ToString(), true);
                    return true;
                }

                return false;
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"{_error} {Errors.D1}");
                return false;
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"{_error} {Errors.D3}");
                return false;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"{_error} {Errors.D2}");
                return false;
            }
        }

        /// <summary> Получает все файлы и поддиректории, текущей директории </summary>
        /// <param name="path">путь текущей директории</param>
        /// <returns>коллекция с именами файлов и поддиректорий, текущей директории</returns>
        public IReadOnlyCollection<string> GetDirectories(StringBuilder path)
        {
            try
            {
                return Directory.GetFileSystemEntries(path.ToString());
            }
            catch (IOException ex)
            {
                Debug.WriteLine(ex.Message);
                Console.WriteLine($"{_error} {Errors.D1}");
                return Array.Empty<string>();
            }
            catch (UnauthorizedAccessException ex)
            {
                Debug.WriteLine(ex.Message);
                Console.WriteLine($"{_error} {Errors.D3}");
                return Array.Empty<string>();
            }
            catch (ArgumentException ex)
            {
                Debug.WriteLine(ex.Message);
                Console.WriteLine($"{_error} {Errors.D2}");
                return Array.Empty<string>();
            }
        }

        /// <summary> Получает размер директории в байтах </summary>
        /// <param name="name">имя директории</param>
        /// <returns>размер в байтах</returns>
        public long GetSize(StringBuilder name)
        {
            try
            {
                var directoryInfo = new DirectoryInfo(name.ToString());
                return directoryInfo.GetFiles("*.*", SearchOption.AllDirectories).Sum(f => f.Length);
            }
            catch (IOException ex)
            {
                Debug.WriteLine(ex.Message);
                Console.WriteLine($"{_error} {Errors.D1}");
                return 0;
            }
        }

        /// <summary> Перемещает файл или каталог со всем его содержимым в новое местоположение </summary>
        /// <param name="sourceName">Путь к файлу или каталогу, который необходимо переместить</param>
        /// <param name="destName">Путь к новому местоположению</param>
        /// <returns>результат операции</returns>
        public bool Move(StringBuilder sourceName, StringBuilder destName)
        {
            try
            {
                if(!Directory.Exists(destName.ToString()))
                {
                    Directory.Move(sourceName.ToString(), destName.ToString());
                    return true;
                }

                return false;
            }
            catch (IOException ex)
            {
                Debug.WriteLine(ex.Message);
                Console.WriteLine($"{_error} {Errors.D1}");
                return false;
            }
            catch (UnauthorizedAccessException ex)
            {
                Debug.WriteLine(ex.Message);
                Console.WriteLine($"{_error} {Errors.D3}");
                return false;
            }
            catch (ArgumentException ex)
            {
                Debug.WriteLine(ex.Message);
                Console.WriteLine($"{_error} {Errors.D2}");
                return false;
            }
        }

        /// <summary> Переименовывает каталог </summary>
        /// <param name="oldName">имя, которое нужно изменить</param>
        /// <param name="newName">имя, на которое нужно изменить</param>
        public void Rename(StringBuilder oldName, StringBuilder newName)
        {
            try
            {
                if(!Directory.Exists(newName.ToString()))
                {
                    Directory.Move(oldName.ToString(), newName.ToString());
                }
            }
            catch (IOException ex)
            {
                Debug.WriteLine(ex.Message);
                Console.WriteLine($"{_error} {Errors.D1}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Debug.WriteLine(ex.Message);
                Console.WriteLine($"{_error} {Errors.D3}");
            }
            catch (ArgumentException ex)
            {
                Debug.WriteLine(ex.Message);
                Console.WriteLine($"{_error} {Errors.D2}");
            }
        }
    }
}
