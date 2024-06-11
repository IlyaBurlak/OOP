namespace Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceShip.Moduls.SpaceEngine;

public abstract class Engine
{
    public abstract int MaxRange { get; }
    public abstract int FuelConsumption { get; }
    public abstract double CalculateFuelUsage();
}