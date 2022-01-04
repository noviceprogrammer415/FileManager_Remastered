using System.Text;
using FileManager.Core.Services.Interfaces;
using FileManager.Services.Interfaces;

namespace FileManager.Core.Services
{
    public class FileService : IFileService, ISingleton<FileService>
    {
        /// <summary> Копирует существующий файл в новый файл </summary>
        /// <param name="sourceName">копируемый файл</param>
        /// <param name="destName">имя целевого файла</param>
        public void Copy(string sourceName, string destName)
        {
            try
            {
                File.Copy(sourceName, destName);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }   
            catch (NotSupportedException ex)
            {   
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary> Создает файлы </summary>
        /// <param name="name">имя файла</param>
        /// <returns>результат выполнения</returns>
        public bool Create(string name)
        {
            try
            {
                if(File.Exists(name))
                    File.Delete(name);

                using var fileStream = File.Create(name);
                return true;
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary> Удаляет файл </summary>
        /// <param name="name">имя файла</param>
        /// <returns>результат выполнения</returns>
        public bool Delete(string name)
        {
            try
            {
                if (File.Exists(name))
                {
                    File.Delete(name);
                    return true;
                }

                return false;
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary> Получает размер файла в байтах </summary>
        /// <param name="name">имя файла</param>
        /// <returns>размер файла в байтах</returns>
        public long GetSize(string name)
        {
            try
            {
                var fileInfo = new FileInfo(name);
                return fileInfo.Length;
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        /// <summary> Перемещает файл </summary>
        /// <param name="sourcePath">начальный путь</param>
        /// <param name="destPath">конечный путь</param>
        /// <returns>результат операции</returns>
        public bool Move(string sourcePath, string destPath)
        {
            try
            {
                if(!File.Exists(destPath))
                {
                    File.Move(sourcePath, destPath);
                    return true;
                }

                return false;
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary> Переименовывает файл </summary>
        /// <param name="oldName">имя файла, которое нужно изменить</param>
        /// <param name="newName">имя, на которое нужно изменить</param>
        public void Rename(string oldName, string newName)
        {
            try
            {
                File.Move(oldName, newName);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NotSupportedException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
