using System;
using Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceShip.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Enviroment.Obstacle;

public class SmallObstacle : Obstacle
{
    private int _mass;
    private int _size;

    public SmallObstacle(int mass, int size)
    {
        _mass = mass;
        _size = size;
    }

    public override int GetDamage(Ship ship)
    {
        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship), "Ship cannot be null");
        }

        int damage = (int)(_mass * (_size * _size));
        ship.TakeDamage(damage);
        return damage;
    }
}
