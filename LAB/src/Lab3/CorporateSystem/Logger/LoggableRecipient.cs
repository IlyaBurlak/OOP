using System;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects.RecipientObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.Logger;

public class LoggableRecipient : IRecipient
{
    private readonly IRecipient _recipient;
    private readonly ILogger _logger;

    public LoggableRecipient(IRecipient recipient, ILogger logger)
    {
        _recipient = recipient ?? throw new ArgumentNullException(nameof(recipient));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void SendMessage(Message message)
    {
        _logger.Log($"Trying to send message: \nTitle: {message?.Header}\nBody: {message?.Body}");
        try
        {
            if (message != null) _recipient.SendMessage(message);
            _logger.Log("Message sent successfully.");
        }
        catch (ArgumentNullException ex)
        {
            _logger.Log($"Failed to send message due ArgumentNullException: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            _logger.Log($"Failed to send message due InvalidOperationException: {ex.Message}");
        }
    }

    public void MarkMessageAsRead(Message message)
    {
        _logger.Log("Trying to mark message as read.");
        try
        {
            _recipient.MarkMessageAsRead(message);
            _logger.Log("Message has been marked as read.");
        }
        catch (ArgumentNullException ex)
        {
            _logger.Log($"Failed to mark message as read due ArgumentNullException: {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            _logger.Log($"Failed to mark message as read due InvalidOperationException: {ex.Message}");
        }
    }
}