using System;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects.RecipientObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.Logger;

public class ProxyRecipientMessageDecorator : IRecipient
{
    private readonly IRecipient _recipient;
    private readonly ILogger _logger;

    public ProxyRecipientMessageDecorator(IRecipient recipient, ILogger logger)
    {
        _recipient = recipient;
        _logger = logger;
    }

    public virtual void SendMessage(Message message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message), "Message cannot be null.");
        }

        _recipient.SendMessage(message);
    }

    public void MarkMessageAsRead(Message message)
    {
        _recipient.MarkMessageAsRead(message);
    }
}