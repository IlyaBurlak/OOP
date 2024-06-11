using Lab5.BisnesLogic;

namespace Lab5.UserInterface.UserModeHandler;

public abstract class BaseUserModeHandler : IUserModeHandler
{
    private ATMSystem _atmSystem;
    private IUserModeHandler? _nextHandler;

    protected BaseUserModeHandler(ATMSystem atmSystem)
    {
        _atmSystem = atmSystem;
    }

    protected ATMSystem AtmSystem => _atmSystem;

    protected IUserModeHandler? NextHandler => _nextHandler;

    public void SetNext(IUserModeHandler handler)
    {
        _nextHandler = handler;
    }

    public abstract void Handle(int entryOption);
}