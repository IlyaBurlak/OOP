using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects.RecipientObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.Manager;

public class RecipientManager
{
    private IRecipient _mainRecipient;
    private RecipientMessageGroup _recipientGroup;
    private ILogger _logger;

    private int _importanceLevel;
    private bool _logInvalidImpLevel;

    public RecipientManager(ILogger logger, IRecipient initialRecipient, int importanceLevel, bool logInvalidImpLevel = false)
    {
        _logger = logger;
        _mainRecipient = initialRecipient;

        _importanceLevel = importanceLevel;
        _logInvalidImpLevel = logInvalidImpLevel;

        _recipientGroup = new RecipientMessageGroup(_importanceLevel, _logInvalidImpLevel);
        _recipientGroup.AddRecipient(_mainRecipient);
    }

    public void AddRecipient(IRecipient recipient)
    {
        _recipientGroup.AddRecipient(recipient);
    }

    public void SendMessage(Message message)
    {
        _recipientGroup.SendMessage(message);
    }
}