namespace Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceShip.Moduls.SpaceEngine;

public class OmegaJumpDrive : Engine
{
    private int _range;

    public OmegaJumpDrive()
    {
        TimeNeeded = 20;
        FuelConsumption = 200;
        _range = 250;
    }

    public int TimeNeeded { get; }
    public override int FuelConsumption { get; }

    public override int MaxRange => _range;

    public override double CalculateFuelUsage()
    {
        return FuelConsumption;
    }
}