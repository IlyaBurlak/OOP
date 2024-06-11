using Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.Handler;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.Controller;

public class HandlerChainConfigurator
{
    private IFileOperationHandler _operationHandlerChain;

    public HandlerChainConfigurator(IFileOperationHandler initialHandler)
    {
        _operationHandlerChain = initialHandler;
    }

    public IFileOperationHandler OperationHandlerChain => _operationHandlerChain;

    public void AddHandler(IFileOperationHandler handler)
    {
        _operationHandlerChain.SetNext(handler);
    }
}