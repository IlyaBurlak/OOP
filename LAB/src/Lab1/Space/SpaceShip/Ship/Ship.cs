using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceShip.Moduls.SpaceEngine;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceShip.Ship;

public abstract class Ship
{
    private List<Engine> _engines;

    protected Ship()
    {
        _engines = new List<Engine>();
    }

    public IReadOnlyList<Engine> Engines => _engines.AsReadOnly();
    protected internal int Fuel { get; private set; }
    protected internal virtual bool HasPhotonDeflectors { get; protected set; }

    public abstract bool HasDeflectors();
    public abstract bool HasAntinitronEmitter();
    public abstract double GetFuelUsage();
    public abstract int GetJumpDriveRange();

    public abstract int GetStrength();
    public abstract int GetDeflectorStrength();
    public abstract int GetAntinitronEmitterStrength();
    public abstract void TakeDamage(int damage);
}