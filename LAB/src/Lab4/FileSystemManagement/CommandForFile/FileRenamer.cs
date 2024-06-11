using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.LogConsoleWrite;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.CommandForFile;

public class FileRenamer : IFileOperation
{
    private readonly ILogger _logger;

    public FileRenamer(ILogger logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void Execute(string source, string? destination)
    {
        if (destination != null)
        {
            string newPath = Path.Combine(Path.GetDirectoryName(source) ?? throw new InvalidOperationException("Source file path is incorrect."), destination);

            try
            {
                File.Move(source, newPath);
                _logger.Log("File has been successfully renamed");
            }
            catch (IOException ex)
            {
                _logger.Log($"I/O error renaming the file: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.Log($"Access error renaming the file: {ex.Message}");
            }
        }
    }
}