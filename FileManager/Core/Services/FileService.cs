using FileManager.Services.Interfaces;
using System.Diagnostics;
using System.Text;

namespace FileManager.Services
{
    public class FileService : IFileService, ISingleton<FileService>
    {
        public void Copy(StringBuilder sourceName, StringBuilder destName)
        {
            throw new NotImplementedException();
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
                Debug.WriteLine(ex.Message);
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            catch (ArgumentException ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
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
                Debug.WriteLine(ex.Message);
                throw;
            }
            catch (ArgumentException ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            catch (NotSupportedException ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
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
                Debug.WriteLine(ex.Message);
                throw;
            }
            catch (ArgumentException ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            catch (UnauthorizedAccessException ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            catch (NotSupportedException ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public void Rename(StringBuilder oldName, StringBuilder newName)
        {
            throw new NotImplementedException();
        }
    }
}
