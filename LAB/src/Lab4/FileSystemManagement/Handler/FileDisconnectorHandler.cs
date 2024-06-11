using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.CommandForFile;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.LogConsoleWrite;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.Handler;

public class FileDisconnectorHandler : IFileOperationHandler
{
    private readonly ILogger _logger;
    private IFileOperationHandler? _nextHandler;

    public FileDisconnectorHandler(ILogger logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

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
        if (command == "disconnect")
        {
            var fileDisconnector = new FileDisconnector(_logger, connectedFileStream);
            fileDisconnector.Execute(command, argument);
            if (fileDisconnector.IsSuccess)
            {
                FileConnectorHandler.ConnectedFileStream = fileDisconnector.ConnectedFileStream;
            }
        }
        else
        {
            _nextHandler?.Handle(command, argument, secondArgument, connectedFileStream);
        }
    }
}