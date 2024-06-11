using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.Handler;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.LogConsoleWrite;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.CommandForFile;

public class FileDisconnector : IFileOperation
{
    private readonly ILogger _logger;

    public FileDisconnector(ILogger logger, FileStream? connectedFileStream)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        ConnectedFileStream = connectedFileStream;
    }

    public FileStream? ConnectedFileStream { get; private set; }
    public bool IsSuccess { get; private set; }

    public void Execute(string source, string? destination)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        IsSuccess = false;

        if (source != "disconnect")
        {
            _logger.Log("Unsupported command format.");
            return;
        }

        if (FileConnectorHandler.ConnectedFileStream != null)
        {
            FileConnectorHandler.ConnectedFileStream.Close();
            FileConnectorHandler.ConnectedFileStream = null;
            _logger.Log("File successfully disconnected.");
            IsSuccess = true;
        }
        else
        {
            _logger.Log("No connected file to disconnect.");
        }
    }
}