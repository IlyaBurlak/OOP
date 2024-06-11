using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceShip.Moduls.SpaceEngine;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceShip.Ship;

public class Diplomat : Ship
{
    private readonly Engine _impulseEngine;
    private readonly Engine _jumpEngine;
    public Diplomat()
    {
        _impulseEngine = new EngineC();
        _jumpEngine = new OmegaJumpDrive();

        Engines = new List<Engine> { _impulseEngine, _jumpEngine }.AsReadOnly();

        Fuel = 1000;
        HullStrength = 100;
        PhotonDeflectors = true;
        HasDeflectorsProperty = true;
        HasAntinitronEmitterProperty = false;
    }

    public new IReadOnlyCollection<Engine> Engines { get; }

    protected new int Fuel { get; }

    protected bool HasDeflectorsProperty { get; private set; }
    protected bool HasAntinitronEmitterProperty { get;  private set; }
    protected bool PhotonDeflectors { get; private set; }
    protected int HullStrength { get; private set; }

    public override double GetFuelUsage() => _impulseEngine.CalculateFuelUsage() + _jumpEngine.CalculateFuelUsage();

    public override int GetStrength() => HullStrength;

    public override int GetDeflectorStrength() => 1;
    public override bool HasDeflectors() => HasDeflectorsProperty;
    public override bool HasAntinitronEmitter() => HasAntinitronEmitterProperty;

    public override int GetAntinitronEmitterStrength() => 0;

    public override void TakeDamage(int damage)
    {
        HullStrength -= damage;
    }

    public void SetPhotonDeflectorsStatus(bool status)
    {
        PhotonDeflectors = status;
        HasDeflectorsProperty = status;
    }

    public override int GetJumpDriveRange() => _jumpEngine.MaxRange;
}