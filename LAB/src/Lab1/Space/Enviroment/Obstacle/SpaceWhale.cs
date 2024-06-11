using System;
using Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceShip.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Enviroment.Obstacle;

public class SpaceWhale : Obstacle
{
    private int _density;

    public SpaceWhale(int density)
    {
        if (density < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(density), "Density cannot be negative");
        }

        _density = density;
    }

    public int IndividualDamage
    {
        get { return _density * 100; }
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

        return IndividualDamage;
    }
}