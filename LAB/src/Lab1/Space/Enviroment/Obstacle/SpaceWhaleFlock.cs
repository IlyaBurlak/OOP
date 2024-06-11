using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceShip.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Enviroment.Obstacle;

public class SpaceWhaleFlock : Obstacle
{
    private List<SpaceWhale> _whales;

    public SpaceWhaleFlock(int flockSize, int density)
    {
        if (flockSize < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(flockSize), "Flock size cannot be less than 1");
        }

        _whales = new List<SpaceWhale>();
        for (int i = 0; i < flockSize; i++)
        {
            _whales.Add(new SpaceWhale(density));
        }
    }

    public override int GetDamage(Ship ship)
    {
        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        if (ship.HasAntinitronEmitter())
        {
            return 0;
        }

        int totalDamage = 0;
        foreach (SpaceWhale whale in _whales)
        {
            totalDamage += whale.IndividualDamage;
        }

        return totalDamage;
    }
}
