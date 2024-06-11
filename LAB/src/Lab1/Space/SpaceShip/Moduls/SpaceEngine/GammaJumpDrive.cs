namespace Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceShip.Moduls.SpaceEngine;

public class GammaJumpDrive : Engine
{
    private int _range;

    public GammaJumpDrive()
    {
        TimeNeeded = 30;
        FuelConsumption = 300;
        _range = 400;
    }

    public int TimeNeeded { get; }
    public override int FuelConsumption { get; }
    public override int MaxRange => _range;

    public override double CalculateFuelUsage()
    {
        return FuelConsumption;
    }
}