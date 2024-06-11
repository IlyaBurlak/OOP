using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.LogConsoleWrite;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.CommandForFile;

public class FileCopier : IFileOperation
{
    private readonly ILogger _logger;

    public FileCopier(ILogger logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void Execute(string source, string? destination)
    {
        if (destination != null)
        {
            File.Copy(source, destination);
            _logger.Log($"Файл скопирован из {source} в {destination}");
        }
    }
}