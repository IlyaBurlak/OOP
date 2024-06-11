using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.Controller;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.LogConsoleWrite;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.SystemCommandReader;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.ProgramLaunch;

public static class ConsoleApp
{
    public static void Run()
    {
        var fs = new FileSystem(new ConsoleCommandReader(), Logger.Instance, null);
        fs.ProcessCommands();
    }
}