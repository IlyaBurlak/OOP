using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.Observable;

public interface IObservable
{
    void AddObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers(Message message);
}