using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.CommandForFile;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.LogConsoleWrite;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.Handler;

public class FileMoverHandler : IFileOperationHandler
{
    private readonly ILogger _logger;
    private IFileOperationHandler? _nextHandler;

    public FileMoverHandler(ILogger logger)
    {
        _logger = logger;
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
        if (command == "move")
        {
            var fileMover = new FileMover(_logger);
            if (argument != null) fileMover.Execute(argument, secondArgument);
        }
        else
        {
            _nextHandler?.Handle(command, argument, secondArgument, connectedFileStream);
        }
    }
}