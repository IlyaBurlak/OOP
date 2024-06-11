using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.Observable;
public interface IObserver
{
    void Update(Message message);
}