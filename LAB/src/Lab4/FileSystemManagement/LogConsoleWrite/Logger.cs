using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.LogConsoleWrite;

public class Logger : ILogger
{
    private static Logger? _instance;
    private Logger() { }

    public static Logger Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Logger();
            }

            return _instance;
        }
    }

    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}