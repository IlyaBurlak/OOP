using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.LogConsoleWrite;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.CommandForFile;

public class FileMover : IFileOperation
{
    private readonly ILogger _logger;

    public FileMover(ILogger logger)
    {
        _logger = logger;
    }

    public void Execute(string source, string? destination = null)
    {
        Apply(source, destination);
    }

    public void Apply(string source, string? destination)
    {
        if (source != null && destination != null && File.Exists(source))
        {
            File.Move(source, destination);
            _logger.Log($"File moved to {destination}");
        }
        else
        {
            _logger.Log($"Failed to {destination}");
        }
    }
}