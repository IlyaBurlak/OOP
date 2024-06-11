using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceShip.Moduls.SpaceEngine;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceShip.Ship;

public class Warship : Ship
{
    private readonly Engine _impulseEngine;
    private readonly Engine _jumpEngine;

    public Warship()
    {
        _impulseEngine = new EngineE(0.1);
        _jumpEngine = new AlphaJumpDrive();

        Engines = new List<Engine> { _impulseEngine, _impulseEngine }.AsReadOnly();

        Fuel = 1000;
        HullStrength = 1500;
        PhotonDeflectors = false;
        HasDeflectorsProperty = true;
        HasAntinitronEmitterProperty = false;
    }

    public new IReadOnlyCollection<Engine> Engines { get; }

    protected bool HasDeflectorsProperty { get; private set; }
    protected bool HasAntinitronEmitterProperty { get; private set; }
    protected bool PhotonDeflectors { get; private set; }
    protected int HullStrength { get; private set; }
    private new int Fuel { get; }

    public override double GetFuelUsage() => _impulseEngine.CalculateFuelUsage() + _jumpEngine.CalculateFuelUsage();

    public override int GetStrength() => HullStrength;

    public override int GetDeflectorStrength() => 3;

    public override int GetAntinitronEmitterStrength() => 0;

    public override bool HasDeflectors() => HasDeflectorsProperty;

    public override bool HasAntinitronEmitter() => HasAntinitronEmitterProperty;

    public override void TakeDamage(int damage)
    {
        HullStrength -= damage;
    }

    public override int GetJumpDriveRange() => _jumpEngine.MaxRange;
}
