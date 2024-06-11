using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceShip.Moduls.SpaceEngine;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceShip.Ship;

public class Shuttle : Ship
{
    private readonly Engine _engine;

    public Shuttle()
    {
        _engine = new EngineC();

        Engines = new List<Engine> { _engine }.AsReadOnly();
        Fuel = 500;
        HullStrength = 100;
        PhotonDeflectors = false;
        HasDeflectorsProperty = false;
        HasAntinitronEmitterProperty = false;
    }

    public new IReadOnlyCollection<Engine> Engines { get; }

    protected bool HasDeflectorsProperty { get; private set; }
    protected bool HasAntinitronEmitterProperty { get; private set; }
    protected bool PhotonDeflectors { get; private set; }
    protected int HullStrength { get; private set; }
    private new int Fuel { get; }

    public override double GetFuelUsage() => _engine.CalculateFuelUsage();
    public override int GetStrength() => HullStrength;
    public override int GetDeflectorStrength() => 0;
    public override int GetAntinitronEmitterStrength() => 0;
    public override bool HasDeflectors() => HasDeflectorsProperty;
    public override bool HasAntinitronEmitter() => HasAntinitronEmitterProperty;

    public override void TakeDamage(int damage)
    {
        HullStrength -= damage;
    }

    public override int GetJumpDriveRange() => 0;
}
