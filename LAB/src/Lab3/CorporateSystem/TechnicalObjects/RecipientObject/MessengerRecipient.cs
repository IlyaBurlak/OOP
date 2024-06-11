using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects.RecipientObject;

public class MessengerRecipient : IRecipient
{
    public virtual void SendMessage(Message message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message), "Message cannot be null.");
        }
    }

    public void MarkMessageAsRead(Message message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message), "Message cannot be null.");
        }

        message.MarkAsRead();
    }
}