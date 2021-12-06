namespace FileManager.Core.Services
{
    [Flags]
    public enum Commands
    {
        dir,
        disk,
        diskpart,
        exit,
        cd,
        clr,
        cp,
        crt,
        help,
        info,
        rm
    }
}