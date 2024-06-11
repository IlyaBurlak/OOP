using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.Observable;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.Manager;

public class ObserverManager
{
    private Topic _topic;
    private ILogger _logger;

    public ObserverManager(ILogger logger, int importanceLevel, bool logInvalidImpLevel = false)
    {
        _logger = logger;
        _topic = new Topic(_logger, importanceLevel, logInvalidImpLevel);
    }

    public void AttachObserver(IObserver observer)
    {
        _topic.AddObserver(observer);
    }

    public void DetachObserver(IObserver observer)
    {
        _topic.RemoveObserver(observer);
    }
}