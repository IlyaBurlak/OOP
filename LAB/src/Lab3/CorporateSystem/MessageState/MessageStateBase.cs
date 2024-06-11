using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.MessageState;

public abstract class MessageStateBase : IMessageState
{
    protected MessageStateBase(ILogger logger)
    {
        Logger = logger;
    }

    protected ILogger Logger { get; private set; }

    public abstract string DisplayState();

    public abstract IMessageState GetNextState();
}