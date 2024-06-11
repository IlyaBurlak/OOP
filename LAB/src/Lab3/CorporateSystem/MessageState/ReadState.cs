using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.MessageState;

public class ReadState : MessageStateBase
{
    public ReadState(ILogger logger)
        : base(logger) { }

    public override string DisplayState()
    {
        string message = "Сообщение прочитано.";
        Logger.Log(message);
        return message;
    }

    public override IMessageState GetNextState()
    {
        return this;
    }
}
