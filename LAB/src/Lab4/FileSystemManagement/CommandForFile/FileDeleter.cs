using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.LogConsoleWrite;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.CommandForFile;

public class FileDeleter : IFileOperation
{
    private readonly ILogger _logger;
    private string? _currentDirectory;

    public FileDeleter(ILogger logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void SetCurrentDirectory(string currentDirectory)
    {
        _currentDirectory = currentDirectory;
    }

    public void Execute(string source, string? destination)
    {
        File.Delete(source);
        _logger.Log("File has been successfully delete");
    }
}