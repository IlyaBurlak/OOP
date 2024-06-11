using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.SystemCommandReader;

public class ConsoleCommandReader : ICommandReader
{
    public string ReadCommand()
    {
        string command = Console.ReadLine() ?? throw new InvalidOperationException();
        return command.Trim();
    }
}