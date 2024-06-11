using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceShip.Moduls.SpaceEngine;

public class EngineE : Engine
{
    private double _accelerationTime;

    public EngineE(double accelerationTime)
    {
        _accelerationTime = accelerationTime;
        MaxRange = 0;
    }

    public double Speed => 3 * Math.Exp(_accelerationTime);
    public override int MaxRange { get; }

    public override int FuelConsumption => (int)(2 * Math.Pow(Speed, 2));

    public override double CalculateFuelUsage()
    {
        return (double)(FuelConsumption * _accelerationTime);
    }

    public void IncreaseTime(double deltaTime)
    {
        _accelerationTime += deltaTime;
    }
}