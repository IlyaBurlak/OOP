using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Enviroment;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Enviroment.Obstacle;
using Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceShip.Moduls.SpaceEngine;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceRoute;

public class RouteSegment
{
    public RouteSegment(
        IReadOnlyList<Engine> engines,
        EnvironmentType? environmentType,
        Obstacle? obstacle,
        double distance)
    {
        Engines = engines;
        Obstacle = obstacle;
        Environment = new Environment(environmentType ?? EnvironmentType.NormalSpace, obstacle, distance);
    }

    protected internal Environment? Environment { get; private set; }
    private IReadOnlyList<Engine> Engines { get; }
    private Obstacle? Obstacle { get; }
}