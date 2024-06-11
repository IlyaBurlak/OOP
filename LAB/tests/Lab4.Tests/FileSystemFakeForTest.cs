using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.Handler;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.LogConsoleWrite;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.SystemCommandReader;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class FileSystemFakeForTest
{
    private readonly ICommandReader _commandReader;
    private readonly ILogger _logger;
    private readonly IFileOperationHandler _operationHandlerChain;
    private FileStream? _connectedFileStream;

    public FileSystemFakeForTest(ICommandReader commandReader, ILogger logger, FileStream? connectedFileStream)
    {
        _commandReader = commandReader ?? throw new ArgumentNullException(nameof(commandReader));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _connectedFileStream = connectedFileStream;
        _operationHandlerChain = new FileConnectorHandler(logger)
            .SetNext(new FileCopierHandler(logger))
            .SetNext(new FileDeleterHandler(logger))
            .SetNext(new FileMoverHandler(logger))
            .SetNext(new FileReaderHandler(logger))
            .SetNext(new FileRenamerHandler(logger))
            .SetNext(new DirectoryTreeListerHandler(logger))
            .SetNext(new FileDisconnectorHandler(logger));
    }

    public void ProcessCommands()
    {
        {
            string? commandLine = _commandReader.ReadCommand();
            string[] commandParts = commandLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string command = commandParts[0];
            string? argument = commandParts.Length > 1 ? commandParts[1] : null;
            string? secondArgument = commandParts.Length > 2 ? commandParts[2] : null;

            _operationHandlerChain.Handle(command, argument, secondArgument, _connectedFileStream);
        }
    }
}
