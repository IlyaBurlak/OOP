using System;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.MessageState;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects.RecipientObject;

public class UserRecipientMessage : ProxyRecipientMessageDecorator, ILoggableUserRecipientMessage
{
    private Message? _currentMessage;

    public UserRecipientMessage(string identity, int importanceLevel)
        : base(new MessengerRecipient(), new ConsoleLogger())
    {
        Identity = identity;
        ImportanceLevel = importanceLevel;
    }

    public string Identity { get; private set; }
    public int ImportanceLevel { get; private set; }
    public bool IsMessageRead
    {
        get
        {
            return _currentMessage != null && _currentMessage.State is ReadState;
        }
    }

    public void Update(Message message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message), "Сообщение не может быть null.");
        }

        _currentMessage = message;
    }

    public void MarkAsRead()
    {
        if (_currentMessage == null)
        {
            throw new InvalidOperationException("Нет сообщений для пометки как прочитанных.");
        }
        else
        {
            _currentMessage.MarkAsRead();
        }
    }
}