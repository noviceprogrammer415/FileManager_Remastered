using FileManager.Services.Interfaces;
using System.Text;

namespace FileManager.Services
{
    public class FileService : IFileService, ISingleton<FileService>
    {
        /// <summary> Копирует существующий файл в новый файл </summary>
        /// <param name="sourceName">копируемый файл</param>
        /// <param name="destName">имя целевого файла</param>
        public void Copy(StringBuilder sourceName, StringBuilder destName)
        {
            try
            {
                File.Copy(sourceName.ToString(), destName.ToString());
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
        public bool Create(StringBuilder name)
        {
            try
            {
                if(!File.Exists(name.ToString()))
                {
                    using var fileStream = File.Create(name.ToString());
                    return true;
                }

                return false;
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
        public bool Delete(StringBuilder name)
        {
            try
            {
                if (File.Exists(name.ToString()))
                {
                    File.Delete(name.ToString());
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
        public long GetSize(StringBuilder name)
        {
            try
            {
                var fileInfo = new FileInfo(name.ToString());
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
        public bool Move(StringBuilder sourcePath, StringBuilder destPath)
        {
            try
            {
                if(!File.Exists(destPath.ToString()))
                {
                    File.Move(sourcePath.ToString(), destPath.ToString());
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
        public void Rename(StringBuilder oldName, StringBuilder newName)
        {
            try
            {
                File.Move(oldName.ToString(), newName.ToString());
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
