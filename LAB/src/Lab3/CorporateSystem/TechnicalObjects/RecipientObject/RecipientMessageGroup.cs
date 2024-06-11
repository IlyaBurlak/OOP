using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects.RecipientObject;

public class RecipientMessageGroup : IRecipient
{
    private List<IRecipient> recipients;

    public RecipientMessageGroup(int importanceLevel, bool logInvalidImpLevel)
    {
        ImportanceLevel = importanceLevel;
        LogInvalidImpLevel = logInvalidImpLevel;
        recipients = new List<IRecipient>();
    }

    public int ImportanceLevel { get; private set; }
    public bool LogInvalidImpLevel { get; private set; }

    public IReadOnlyCollection<IRecipient> Recipients => recipients.AsReadOnly();

    public void AddRecipient(IRecipient recipient)
    {
        recipients.Add(recipient);
    }

    public void SendMessage(Message message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        foreach (IRecipient recipient in recipients)
        {
            recipient.SendMessage(message);
        }
    }

    public void SendMessage(IList<Message> messages)
    {
        if (messages == null)
        {
            throw new ArgumentNullException(nameof(messages));
        }

        foreach (Message message in messages)
        {
            this.SendMessage(message);
        }
    }

    public void MarkMessageAsRead(Message message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        foreach (IRecipient recipient in recipients)
        {
            recipient.MarkMessageAsRead(message);
        }
    }
}
