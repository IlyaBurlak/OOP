using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.Manager;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.Observable;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects.RecipientObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.MessageSystemCorparate;

public class MessageSystem : IRecipient
{
    private RecipientManager _recipientManager;
    private ObserverManager _observerManager;
    private ILogger _logger;

    private int _importanceLevel;
    private bool _logInvalidImpLevel;

    public MessageSystem(IRecipient recipient, int importanceLevel, ILogger logger, bool logInvalidImpLevel = false)
    {
        _logger = logger;
        _importanceLevel = importanceLevel;
        _logInvalidImpLevel = logInvalidImpLevel;

        _recipientManager = new RecipientManager(_logger, recipient, _importanceLevel, _logInvalidImpLevel);
        _observerManager = new ObserverManager(_logger, _importanceLevel, _logInvalidImpLevel);
    }

    public void AddRecipient(IRecipient recipient)
    {
        _recipientManager.AddRecipient(recipient);
    }

    public void SendMessage(Message message)
    {
        _recipientManager.SendMessage(message);
    }

    public void AttachObserver(IObserver observer)
    {
        _observerManager.AttachObserver(observer);
    }

    public void DetachObserver(IObserver observer)
    {
        _observerManager.DetachObserver(observer);
    }

    public void MarkMessageAsRead(Message message)
    {
        if (message != null)
        {
            message.MarkAsRead();
            _logger.Log("Message has been marked as read.");
        }
        else
        {
            _logger.Log("Message cannot be null.");
        }
    }
}
