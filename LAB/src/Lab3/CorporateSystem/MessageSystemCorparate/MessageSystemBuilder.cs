using System;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects.RecipientObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.MessageSystemCorparate;

public class MessageSystemBuilder
{
    private IRecipient? _recipient;
    private int _importanceLevel;
    private bool _logInvalidImpLevel;
    private ILogger _logger;

    public MessageSystemBuilder(ILogger logger)
    {
        _logger = logger;
    }

    public MessageSystemBuilder SetRecipient(IRecipient recipient)
    {
        _recipient = recipient;
        return this;
    }

    public MessageSystemBuilder SetImportanceLevel(int importanceLevel)
    {
        _importanceLevel = importanceLevel;
        return this;
    }

    public MessageSystemBuilder SetLogInvalidImpLevel(bool logInvalidImpLevel)
    {
        _logInvalidImpLevel = logInvalidImpLevel;
        return this;
    }

    public MessageSystem Build()
    {
        if (_recipient == null)
        {
            throw new InvalidOperationException("RecipientMessage must be set.");
        }

        return new MessageSystem(_recipient, _importanceLevel, _logger, _logInvalidImpLevel);
    }
}