using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects.RecipientObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.Logger;

public class LoggableRecipientMessageGroup : IRecipient
{
    private readonly RecipientMessageGroup _target;
    private readonly ILogger _logger;

    public LoggableRecipientMessageGroup(ILogger logger, int importanceLevel, bool logInvalidImpLevel)
    {
        _logger = logger;
        _target = new RecipientMessageGroup(importanceLevel, logInvalidImpLevel);
    }

    public IReadOnlyCollection<IRecipient> Recipients => _target.Recipients;
    public void AddRecipient(IRecipient recipient)
    {
        if (recipient == null)
        {
            throw new ArgumentNullException(nameof(recipient), "Message cannot be null.");
        }

        _logger.Log($"Adding recipient: {recipient.ToString()}");
        _target.AddRecipient(recipient);
    }

    public void SendMessage(Message message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message), "Message cannot be null.");
        }

        _logger.Log($"Sending message: {message.ToString()}");
        _target.SendMessage(message);
    }

    public void SendMessage(IList<Message> messages)
    {
        if (messages == null)
        {
            throw new ArgumentNullException(nameof(messages), "Message cannot be null.");
        }

        _logger.Log($"Sending multiple messages...");
        _target.SendMessage(messages);
    }

    public void MarkMessageAsRead(Message message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message), "Message cannot be null.");
        }

        _logger.Log($"Marking message as read: {message.ToString()}");
        _target.MarkMessageAsRead(message);
    }
}
