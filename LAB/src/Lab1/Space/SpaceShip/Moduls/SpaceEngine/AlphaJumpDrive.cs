namespace Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceShip.Moduls.SpaceEngine;

public class AlphaJumpDrive : Engine
{
    private int _range;

    public AlphaJumpDrive()
    {
        TimeNeeded = 10;
        FuelConsumption = 100;
        _range = 100;
    }

    public int TimeNeeded { get; }
    public override int FuelConsumption { get; }
    public override int MaxRange => _range;

    public override double CalculateFuelUsage()
    {
        return FuelConsumption;
    }
}