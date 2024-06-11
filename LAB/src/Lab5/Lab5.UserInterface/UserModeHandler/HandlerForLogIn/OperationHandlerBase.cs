using Lab5.BisnesLogic;

namespace Lab5.UserInterface.UserModeHandler.HandlerForLogIn;

public abstract class OperationHandlerBase
{
    private readonly ATMSystem _atmSystem;
    private OperationHandlerBase? _nextHandler;

    protected OperationHandlerBase(ATMSystem atmSystem)
    {
        _atmSystem = atmSystem;
    }

    protected ATMSystem AtmSystem => _atmSystem;

    protected OperationHandlerBase NextHandler => _nextHandler ?? throw new InvalidOperationException();

    public OperationHandlerBase SetNextHandler(OperationHandlerBase handler)
    {
        _nextHandler = handler;
        return handler;
    }

    public abstract bool HandleRequest(OperationRequest request);
}