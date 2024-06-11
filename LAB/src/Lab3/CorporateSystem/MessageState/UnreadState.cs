using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.MessageState;

public class UnreadState : MessageStateBase
{
    public UnreadState(ILogger logger)
        : base(logger) { }

    public override string DisplayState()
    {
        string message = "Сообщение не прочитано.";
        Logger.Log(message);
        return message;
    }

    public override IMessageState GetNextState()
    {
        return new ReadState(Logger);
    }
}