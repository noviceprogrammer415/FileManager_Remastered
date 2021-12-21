using FileManager.UserInterfaces.ConsoleInterface.Interfaces;

namespace FileManager.UserInterfaces.ConsoleInterface
{
    public class OutputService : IOutputService
    {
        public void PrintCollectionObjects<T>(IEnumerable<T> collection)
        {
            if(collection is null) return;

            foreach (var item in collection)
            {
                if(Path.HasExtension(item?.ToString()))
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(Path.GetFileName(item?.ToString()));
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(item?.ToString());
                    Console.ResetColor();
                }
            }
        }
    }
}
