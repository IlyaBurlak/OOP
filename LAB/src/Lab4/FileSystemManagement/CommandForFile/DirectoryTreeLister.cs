using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.LogConsoleWrite;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.CommandForFile;

public class DirectoryTreeLister : IFileOperation
{
    private readonly ILogger _logger;

    public DirectoryTreeLister(ILogger logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void Execute(string source, string? destination)
    {
        if (!int.TryParse(destination, out int depth))
        {
            _logger.Log($"must be convertible to an integer.");
            return;
        }

        ListDirectory(source, depth);
    }

    private void ListDirectory(string path, int depth, int currentDepth = 0)
    {
        try
        {
            foreach (string directory in Directory.GetDirectories(path))
            {
                _logger.Log($"{Path.GetFileName(directory)}");

                if (currentDepth < depth)
                {
                    ListDirectory(directory, depth, currentDepth + 1);
                }
            }

            foreach (string file in Directory.GetFiles(path))
            {
                _logger.Log($"{new string('*', currentDepth)}{Path.GetFileName(file)}");
            }
        }
        catch (UnauthorizedAccessException e)
        {
            _logger.Log($"Access to the path '{path}' is denied: {e.Message}");
        }
        catch (DirectoryNotFoundException e)
        {
            _logger.Log($"Cannot find a part of the path '{path}': {e.Message}");
        }
        catch (IOException e)
        {
            _logger.Log($"An error occurred while working with directory '{path}': {e.Message}");
        }
    }
}