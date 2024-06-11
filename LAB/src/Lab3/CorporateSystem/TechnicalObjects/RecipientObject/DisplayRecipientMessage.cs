using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects.ColorWrapper;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects.RecipientObject;

public class DisplayRecipientMessage : MessengerRecipient
{
    private readonly DisplayRecipientMessageDecorator _decorator;
    private Message? _message;
    private ConsoleColorWrapper _color;

    public DisplayRecipientMessage(DisplayRecipientMessageDecorator decorator)
    {
        _decorator = decorator;
        _color = new ConsoleColorWrapper(ConsoleColor.White);
    }

    public virtual void SendMessage(IList<Message>? messages)
    {
        if (messages == null)
        {
            _decorator.Log("Message cannot be null.");
            return;
        }

        foreach (Message message in messages)
        {
            SendMessage(message);
        }
    }

    public virtual void ClearMessage()
    {
        _message = null;
    }

    public virtual void SetColor(ConsoleColorWrapper color)
    {
        _color = color;
    }

    public override void SendMessage(Message message)
    {
        _message = message;
        WriteMessageWithColor();
    }

    private void WriteMessageWithColor()
    {
        if (_message == null)
        {
            return;
        }

        Console.ForegroundColor = _color.Color;

        _decorator.Log($"Title: {_message.Header}");
        _decorator.Log($"Message: {_message.Body}");

        Console.ForegroundColor = ConsoleColor.White;
    }
}