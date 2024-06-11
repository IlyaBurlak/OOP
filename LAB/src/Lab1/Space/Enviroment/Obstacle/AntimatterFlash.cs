using System;
using Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceShip.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Enviroment.Obstacle;

public class AntimatterFlash : Obstacle
{
    public override int GetDamage(Ship ship)
    {
        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        if (ship.HasPhotonDeflectors)
        {
            return 0;
        }

        return ship.GetStrength();
    }
}