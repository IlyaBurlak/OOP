using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.Observable;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.Logger;

public interface ILoggableUserRecipientMessage : IObserver
{
    void MarkAsRead();
}