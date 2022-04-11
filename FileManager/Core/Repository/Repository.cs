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

        public void Read(out string readPath)
        {
            using var streamReader = _fileInfo.OpenText();
            readPath = streamReader.ReadLine()!;
        }

        public void Update(string updatedPath) => Create(updatedPath);
    }
}
