namespace Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceShip.Moduls.SpaceEngine;

public class EngineC : Engine
{
    private int _range;

    public EngineC()
    {
        Speed = 10;
        FuelConsumption = 10;
        _range = 0;
    }

    public int Speed { get; }
    public override int FuelConsumption { get; }
    public override int MaxRange => _range;

    public override double CalculateFuelUsage()
    {
        return FuelConsumption;
    }
}