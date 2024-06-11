using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceShip.Moduls.SpaceEngine;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceShip.Ship;

public class Miner : Ship
{
    private readonly Engine _engine;

    public Miner()
    {
        _engine = new EngineE(0.1);
        Engines = new List<Engine> { _engine }.AsReadOnly();
        Fuel = 1000;
        HullStrength = 250;
        PhotonDeflectors = true;
        HasDeflectorsProperty = true;
        HasAntinitronEmitterProperty = true;
    }

    public new IReadOnlyCollection<Engine> Engines { get; }
    protected internal override bool HasPhotonDeflectors
    {
        get => PhotonDeflectors;
        protected set => PhotonDeflectors = value;
    }

    protected bool HasDeflectorsProperty { get; private set; }
    protected bool HasAntinitronEmitterProperty { get; private set; }
    protected int HullStrength { get; private set; }
    protected bool PhotonDeflectors { get; private set; }
    private int StrengthDeflector { get; } = 2;
    private int StrengthAntinitronEmitter { get; } = 1;
    private int RangeJumpDrive { get; }

    private new int Fuel { get; }

    public override double GetFuelUsage() => _engine.CalculateFuelUsage();
    public override int GetStrength() => HullStrength;
    public override int GetDeflectorStrength() => StrengthDeflector;
    public override int GetAntinitronEmitterStrength() => StrengthAntinitronEmitter;
    public override bool HasDeflectors() => HasDeflectorsProperty;
    public override bool HasAntinitronEmitter() => HasAntinitronEmitterProperty;
    public override void TakeDamage(int damage)
    {
        HullStrength -= damage;
    }

    public override int GetJumpDriveRange() => RangeJumpDrive;
}
