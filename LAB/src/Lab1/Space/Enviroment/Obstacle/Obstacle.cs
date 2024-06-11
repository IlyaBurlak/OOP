using Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceShip.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Enviroment.Obstacle;

public abstract class Obstacle
{
    public abstract int GetDamage(Ship ship);
}