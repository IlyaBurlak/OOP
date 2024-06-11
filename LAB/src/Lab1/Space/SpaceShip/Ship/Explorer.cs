using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceShip.Moduls.SpaceEngine;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceShip.Ship;

public class Explorer : Ship
{
    private readonly Engine _impulseEngine;
    private readonly Engine _jumpEngine;
    private readonly List<Engine> _engines;

    public Explorer()
    {
        _impulseEngine = new EngineE(0.1);
        _jumpEngine = new GammaJumpDrive();
        _engines = new List<Engine> { _impulseEngine, _jumpEngine };

        Fuel = 1000;
        HullStrength = 250;
        PhotonDeflectors = true;
        HasDeflectorsProperty = true;
        HasAntinitronEmitterProperty = false;
    }

    protected internal new int Fuel { get; }
    protected internal override bool HasPhotonDeflectors
    {
        get => PhotonDeflectors;
        protected set => PhotonDeflectors = value;
    }

    protected bool HasDeflectorsProperty { get; private set; }
    protected bool HasAntinitronEmitterProperty { get;  private set; }
    protected bool PhotonDeflectors { get; private set; }
    protected int HullStrength { get; private set; }

    public override void TakeDamage(int damage)
    {
        HullStrength -= damage;
        if (HullStrength < 0)
        {
            HullStrength = 0;
        }
    }

    public override double GetFuelUsage() => _impulseEngine.CalculateFuelUsage() + _jumpEngine.CalculateFuelUsage();
    public override int GetStrength() => HullStrength;
    public override int GetDeflectorStrength() => 1;
    public override int GetAntinitronEmitterStrength() => 0;
    public override bool HasDeflectors() => HasDeflectorsProperty;
    public override bool HasAntinitronEmitter() => HasAntinitronEmitterProperty;
    public override int GetJumpDriveRange() => _jumpEngine.MaxRange;
}
