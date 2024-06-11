using System;
using Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceShip.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Enviroment.Obstacle;

public class Meteorit : Obstacle
{
    private int _mass;

    public Meteorit(int mass)
    {
        _mass = mass;
    }

    public override int GetDamage(Ship ship)
    {
        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship), "Ship cannot be null");
        }

        int damage = (int)(_mass * 2);
        ship.TakeDamage(damage);
        return damage;
    }
}
