using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.LogConsoleWrite;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.CommandForFile;

public class FileReader : IFileOperation
{
    private readonly ILogger _logger;

    public FileReader(ILogger logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void Execute(string source, string? destination)
    {
        string content = File.ReadAllText(source);
        _logger.Log(content);
    }
}