namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.MessageState;

public interface IMessageState
{
    string DisplayState();
    IMessageState GetNextState();
}