using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects.RecipientObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.ProxyRecipientCorparate;

public class ProxyRecipientMessage : IRecipient
{
    private readonly int maxImportanceLevel = 5;
    private readonly IRecipient _recipient;
    private readonly List<Message> _messageList;

    public ProxyRecipientMessage(IRecipient inputRecipient, int importanceLevel)
    {
        _recipient = inputRecipient;
        ImportanceLevel = importanceLevel;
        _messageList = new List<Message>();
    }

    public int ImportanceLevel { get; private set; }

    public virtual void SendMessage(Message message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message), "Message cannot be null.");
        }

        if (message.ImportanceLevel <= maxImportanceLevel)
        {
            _recipient.SendMessage(message);
        }
        else
        {
            throw new InvalidOperationException("Не допустимый уровень!");
        }
    }

    public void MarkMessageAsRead(Message message)
    {
        _recipient.MarkMessageAsRead(message);
    }

    protected static IReadOnlyCollection<Message> FilterMessagesByImportance(IList<Message> messages, int importanceLevel)
    {
        return messages.Where(m => m.ImportanceLevel >= importanceLevel).ToList().AsReadOnly();
    }
}
