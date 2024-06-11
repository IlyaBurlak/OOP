using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.CommandForFile;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.LogConsoleWrite;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.Handler;

public class FileConnectorHandler : IFileOperationHandler
{
    private readonly ILogger _logger;
    private IFileOperationHandler? _nextHandler;
    public FileConnectorHandler(ILogger logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public static FileStream? ConnectedFileStream { get; set; }

    public IFileOperationHandler SetNext(IFileOperationHandler handler)
    {
        if (_nextHandler == null)
        {
            _nextHandler = handler;
        }
        else
        {
            _nextHandler.SetNext(handler);
        }

        return this;
    }

    public void Handle(string command, string? argument, string? secondArgument, FileStream? connectedFileStream)
    {
        if (command == "connect")
        {
            var fileConnector = new FileConnector(_logger);
            if (argument != null)
            {
                fileConnector.Execute(command, argument);
                if (fileConnector.IsSuccess)
                {
                    ConnectedFileStream = fileConnector.ConnectedFileStream;
                }
            }
        }
        else
        {
            _nextHandler?.Handle(command, argument, secondArgument, connectedFileStream);
        }
    }
}