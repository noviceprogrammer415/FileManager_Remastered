using FileManager.Core.Services.Interfaces;

namespace FileManager.Core.Services
{
    public class FileService : IFileService, ISingleton<FileService>
    {
        private readonly string _error = "Internal error!";

        /// <summary> Копирует существующий файл в новый файл </summary>
        /// <param name="sourceName">копируемый файл</param>
        /// <param name="destName">имя целевого файла</param>
        public void Copy(string sourceName, string destName)
        {
            try
            {
                if(File.Exists(destName))
                    File.Delete(destName);

                File.Copy(sourceName, destName);
            }
            catch (IOException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine(_error);
            }
            catch (UnauthorizedAccessException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine(_error);
            }
            catch (ArgumentException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine(_error);
            }   
            catch (NotSupportedException ex)
            {  
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine(_error);
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
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine(_error);
                return false;
            }
            catch (UnauthorizedAccessException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine(_error);
                return false;
            }
            catch (ArgumentException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine(_error);
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
                    File.Delete(name);

                return true;
            }
            catch (IOException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine(_error);
                return false;
            }
            catch (ArgumentException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine(_error);
                return false;
            }
            catch (UnauthorizedAccessException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine(_error);
                return false;
            }
            catch (NotSupportedException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine(_error);
                return false;
            }
        }

        /// <summary> Получает размер файла в байтах </summary>
        /// <param name="name">имя файла</param>
        /// <returns>размер файла в байтах</returns>
        public void GetSize(string name, out long size)
        {
            try
            {
                var fileInfo = new FileInfo(name);
                size = fileInfo.Length;
            }
            catch (IOException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine(_error);
                size = 0;
            }
        }

        /// <summary> Перемещает файл </summary>
        /// <param name="sourcePath">начальный путь</param>
        /// <param name="destPath">конечный путь</param>
        /// <returns>результат операции</returns>
        public void Move(string sourcePath, string destPath)
        {
            try
            {
                if(!File.Exists(destPath))
                    File.Delete(destPath);

                File.Move(sourcePath, destPath);
            }
            catch (IOException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine(_error);
            }
            catch (ArgumentException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine(_error);
            }
            catch (UnauthorizedAccessException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine(_error);
            }
            catch (NotSupportedException ex)
            {
                Logger.Log.Error(ex, "{0}", ex.Message);
                Console.WriteLine(_error);
            }
        }
    }
}
