using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects.RecipientObject;

public abstract class Recipient : IRecipient
{
    public abstract void SendMessage(Message message);
    public abstract void MarkMessageAsRead(Message message);
    public abstract IReadOnlyCollection<Message> FilterMessagesByImportance(IList<Message> messages, int importanceLevel);
}
