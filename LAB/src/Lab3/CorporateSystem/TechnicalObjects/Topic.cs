using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.Observable;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects.RecipientObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects;

public class Topic : IObservable
{
    private List<IObserver> observers;
    private ILogger _logger;

    public Topic(ILogger logger, int importanceLevel, bool logInvalidImpLevel = false)
    {
        observers = new List<IObserver>();
        _logger = logger;
        RecipientMessage = new RecipientMessageGroup(importanceLevel, logInvalidImpLevel);
    }

    public string Name { get; private set; } = string.Empty;
    public RecipientMessageGroup RecipientMessage { get; private set; }

    public void SetName(string name)
    {
        Name = name;
    }

    public void SetRecipient(RecipientMessageGroup recipientMessage)
    {
        RecipientMessage = recipientMessage;
    }

    public void SendMessage(Message message)
    {
        RecipientMessage.SendMessage(message);
        NotifyObservers(message);
    }

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers(Message message)
    {
        foreach (IObserver observer in observers)
        {
            observer.Update(message);
        }
    }
}