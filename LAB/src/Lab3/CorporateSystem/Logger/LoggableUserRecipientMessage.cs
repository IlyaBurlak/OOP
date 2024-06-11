using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects.RecipientObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.Logger;

public class LoggableUserRecipientMessage : ILoggableUserRecipientMessage
{
    private readonly UserRecipientMessage _userRecipientMessage;
    private readonly ILogger _logger;

    public LoggableUserRecipientMessage(UserRecipientMessage userRecipientMessage, ILogger logger)
    {
        _userRecipientMessage = userRecipientMessage;
        _logger = logger;
    }

    public void Update(Message message)
    {
        _userRecipientMessage.Update(message);
        string stateDescription = message.State != null ? message.State.DisplayState() : "Cоcтoяние не определено";
        _logger.Log($"Получено новое сообщие как пользовательский получатель сообщения:\nTitle: {message.Header}\nMessage: {message.Body}\nCоcтoяние: {stateDescription}");
    }

    public void MarkAsRead()
    {
        _userRecipientMessage.MarkAsRead();
        _logger.Log("Cообщение отмечено как прочитанное.");
    }
}