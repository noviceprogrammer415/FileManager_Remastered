namespace FileManager.Core.Repository
{
    public class Repository : IRepository
    {
        private readonly FileInfo _fileInfo = new("SavePath.txt");

        public void Create(string savedPath)
        {
            using var streamWriter = _fileInfo.CreateText();
            streamWriter.WriteLine(savedPath);
        }

        public void Read(string currentPath, out string readPath)
        {
            using var streamReader = _fileInfo.OpenText();
            var result = streamReader.ReadLine();
            readPath = !string.IsNullOrEmpty(result) 
                       ? result
                       : currentPath;
        }

        public void Update(string updatedPath) => Create(updatedPath);
    }
}
