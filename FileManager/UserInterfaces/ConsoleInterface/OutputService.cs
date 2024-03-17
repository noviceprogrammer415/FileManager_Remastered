using FileManager.UserInterfaces.ConsoleInterface.Interfaces;

namespace FileManager.UserInterfaces.ConsoleInterface
{
    public sealed class OutputService : IOutputService
    {
        public void PrintCollectionObjects<T>(IEnumerable<T> collection)
        {
            IEnumerable<string> files = Enumerable.Empty<string>();
            IEnumerable<string> directories = Enumerable.Empty<string>();

            foreach (var item in collection)
            {
                if(Path.HasExtension(item?.ToString()))
                    files = files.Append(Path.GetFileName(item.ToString())!)
                                 .OrderBy(f => f[0]);
                else
                    directories = directories.Append(item!.ToString()!.Split(@"\", StringSplitOptions.RemoveEmptyEntries)[^1])
                                             .OrderBy(d => d[0]);
            }

            var files_directories = directories.Concat(files);

            foreach(var item in files_directories)
            {
                if (Path.HasExtension(item))
                    Paint(() => Console.Out.WriteLine(item), ConsoleColor.DarkMagenta);
                else
                    Paint(() => Console.Out.WriteLine(item), ConsoleColor.DarkYellow);
            }
        }

        public void PrintSizeObject(ref string name, ref long size) 
            => Console.Out.WriteLine($"Размер объекта {name} {size} байт(а)");

        private void Paint(Action act, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            act.Invoke();
            Console.ResetColor();
        }
    }
}
