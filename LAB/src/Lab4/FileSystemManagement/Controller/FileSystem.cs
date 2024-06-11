using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.Handler;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.LogConsoleWrite;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.SystemCommandReader;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.Controller;

public class FileSystem
{
    private readonly ICommandReader _commandReader;
    private readonly ILogger _logger;
    private IFileOperationHandler _operationHandlerChain;
    private FileStream? _connectedFileStream;

    public FileSystem(ICommandReader commandReader, ILogger logger, FileStream? connectedFileStream)
    {
        _commandReader = commandReader ?? throw new ArgumentNullException(nameof(commandReader));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _connectedFileStream = connectedFileStream;

        _operationHandlerChain = ConfigureHandlerChain();
    }

    public void ProcessCommands()
    {
        while (true)
        {
            string? commandLine = _commandReader.ReadCommand();
            if (string.IsNullOrEmpty(commandLine))
            {
                _logger.Log("Invalid command: empty command");
                continue;
            }

            string[] commandParts = commandLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string command = commandParts[0];
            string? argument = commandParts.Length > 1 ? commandParts[1] : null;
            string? secondArgument = commandParts.Length > 2 ? commandParts[2] : null;

            _operationHandlerChain.Handle(command, argument, secondArgument, _connectedFileStream);
        }
    }

    private IFileOperationHandler ConfigureHandlerChain()
    {
        var handlerConfigurator = new HandlerChainConfigurator(new FileConnectorHandler(_logger));

        handlerConfigurator.AddHandler(new FileCopierHandler(_logger));
        handlerConfigurator.AddHandler(new FileDeleterHandler(_logger));
        handlerConfigurator.AddHandler(new FileMoverHandler(_logger));
        handlerConfigurator.AddHandler(new FileReaderHandler(_logger));
        handlerConfigurator.AddHandler(new FileRenamerHandler(_logger));
        handlerConfigurator.AddHandler(new DirectoryTreeListerHandler(_logger));
        handlerConfigurator.AddHandler(new FileDisconnectorHandler(_logger));

        return handlerConfigurator.OperationHandlerChain;
    }
}
