namespace FileManager.Core.Enums
{
    [Flags]
    public enum Commands
    {
        ///<summary>переход к родительской директории</summary>
        Back = 0x0000001,
        /// <summary>переход к главному каталогу</summary>
        Btr = 0x0000002,
        /// <summary>переход к поддиректории</summary>
        Cd = 0x0000004,
        /// <summary>чистка консоли</summary>
        Cls = 0x0000008,
        /// <summary>копирование файла/папки</summary>
        Cp = 0x0000010,
        /// <summary>создание файла/папки</summary>
        Crt = 0x0000020,
        /// <summary>показать список файлов и папок текущей директории</summary>
        Dir = 0x0000040,
        /// <summary>показать список дисков системы</summary>
        Disk = 0x0000080,
        /// <summary>переключить диск</summary>
        Diskpart = 0x0000100,
        /// <summary>отчет по дискам системы</summary>
        Diskreport = 0x0000200,
        /// <summary>выход из программы</summary>
        Exit = 0x0000400,
        /// <summary>помощь</summary>
        Help = 0x0000800,
        Info = 0x0001000,
        /// <summary>перемещение файла/папки</summary>
        Move = 0x0002000,
        /// <summary>переименование файла/папки</summary>
        Rename = 0x0004000,
        /// <summary>удаление файлов/папок</summary>
        Rm = 0x0008000,
        /// <summary>размер файла/папки</summary>
        Size = 0x0010000
    }
}