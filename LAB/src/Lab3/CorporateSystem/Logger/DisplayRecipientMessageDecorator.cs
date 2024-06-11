using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects.ColorWrapper;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects.RecipientObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.Logger;

public class DisplayRecipientMessageDecorator : MessengerRecipient
{
    private readonly DisplayRecipientMessage _recipientMessage;
    private readonly ILogger _logger;

    public DisplayRecipientMessageDecorator(DisplayRecipientMessage recipientMessage, ILogger logger)
    {
        _recipientMessage = recipientMessage;
        _logger = logger;
    }

    public void SendMessage(IList<Message> messages)
    {
        _recipientMessage.SendMessage(messages);
    }

    public void ClearMessage()
    {
        _recipientMessage.ClearMessage();
    }

    public void SetColor(ConsoleColorWrapper color)
    {
        _recipientMessage.SetColor(color);
    }

    public void Log(string message)
    {
        _logger.Log(message);
    }

    public override void SendMessage(Message message)
    {
        if (message == null)
        {
            throw new ArgumentNullException(nameof(message), "Message cannot be null.");
        }

        _recipientMessage.SendMessage(message);
        Log($"Sent a message: {message.Header} - {message.Body}");
    }
}