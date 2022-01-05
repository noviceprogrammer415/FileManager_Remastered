﻿namespace FileManager.Core.Services
{
    [Flags]
    public enum Commands
    {
        back, //переход к родительской директории
        btr, //переход к главному каталогу
        cd, //переход к поддиректории
        clr, //чистка консоли
        cp, //копирование файла/папки
        crt, //создание файла/папки
        dir, //показать список файлов и папок текущей директории
        disk, //показать список дисков системы
        diskpart, //переход к диску
        diskreport, //отчет по дискам системы
        exit, //выход из программы
        help,
        info,
        rm //удаление файлов/папок
    }
}