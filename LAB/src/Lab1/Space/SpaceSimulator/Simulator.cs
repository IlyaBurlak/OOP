using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Space.Exception;
using Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceRoute;
using Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceShip.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceSimulator;

public class Simulator
{
    private List<Ship> ships = new List<Ship>();

    public IReadOnlyCollection<Ship> GetShips()
    {
        return ships.AsReadOnly();
    }

    public void AddShip(Ship ship)
    {
        if (ship == null)
            throw new ArgumentNullException(nameof(ship));

        if (!ships.Contains(ship))
        {
            ships.Add(ship);
        }
    }

    public Ship FindOptimalShip(Route route, out double travelTime, out double fuelSpent)
    {
        if (route == null)
            throw new ArgumentNullException(nameof(route));

        foreach (RouteSegment segment in route.Segments)
        {
            if (segment.Environment != null && segment.Environment.Distance < 0)
            {
                throw new ArgumentException("Distance can't be negative");
            }
        }

        Ship? optimalShip = null;
        double minTime = double.MaxValue;
        double minFuelSpent = double.MaxValue;

        foreach (Ship ship in ships)
        {
            double totalTime = 0;
            double currentFuel = ship.Fuel;

            fuelSpent = 0;

            foreach (RouteSegment segment in route.Segments)
            {
                double segmentFuelUsage = CalculateSegmentFuelUsage(ship);

                currentFuel -= segmentFuelUsage;
                fuelSpent += segmentFuelUsage;

                if (currentFuel < 0)
                {
                    break;
                }

                HandleSegmentObstacle(ship, segment);
                if (ship.GetStrength() <= 0)
                {
                    break;
                }

                double? timeSegment = CalculateTimeSegment(segment, ship);

                if (!timeSegment.HasValue)
                {
                    continue;
                }

                totalTime += timeSegment.Value;

                if (totalTime >= minTime)
                {
                    break;
                }

                if (totalTime < minTime)
                {
                    minTime = totalTime;
                    optimalShip = ship;
                    minFuelSpent = fuelSpent;
                }
            }
        }

        if (optimalShip == null)
        {
            throw new SuitableShipNotFoundException();
        }

        travelTime = minTime;
        fuelSpent = minFuelSpent;
        return optimalShip;
    }

    private static double CalculateSegmentFuelUsage(Ship ship)
    {
        return ship.Engines.Sum(e => e.CalculateFuelUsage());
    }

    private static void HandleSegmentObstacle(Ship ship, RouteSegment segment)
    {
        if (segment.Environment?.Obstacle != null)
        {
            ship.TakeDamage(segment.Environment.Obstacle.GetDamage(ship));
        }
    }

    private static double? CalculateTimeSegment(RouteSegment segment, Ship ship)
    {
        if (segment.Environment == null)
            return null;
        return segment.Environment.Distance / ship.Engines.Sum(e => (double)e.MaxRange);
    }
}
