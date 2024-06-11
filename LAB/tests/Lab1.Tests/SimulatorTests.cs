using Itmo.ObjectOrientedProgramming.Lab1.Space.Exception;
using Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceRoute;
using Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceShip.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceSimulator;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class SimulatorTests
{
    [Fact]
    public void DenseNebulaMidRouteTest()
    {
        var simulator = new Simulator();
        var route = new Route();

        var shuttle = new Shuttle();
        var augur = new Warship();

        simulator.AddShip(shuttle);
        simulator.AddShip(augur);

        Assert.Throws<SuitableShipNotFoundException>(() => simulator.FindOptimalShip(route, out _, out _));
    }

    [Fact]
    public void AntimatterFlashTest()
    {
        var simulator = new Simulator();
        var route = new Route();

        var vaklasWithoutDeflectors = new Diplomat();
        var vaklasWithDeflectors = new Diplomat();
        vaklasWithDeflectors.SetPhotonDeflectorsStatus(true);

        simulator.AddShip(vaklasWithoutDeflectors);
        simulator.AddShip(vaklasWithDeflectors);

        Assert.Throws<SuitableShipNotFoundException>(() => simulator.FindOptimalShip(route, out _, out _));
    }

    [Fact]
    public void SpaceWhaleTest()
    {
        var simulator = new Simulator();
        var route = new Route();

        var vaklas = new Diplomat();
        var augur = new Warship();
        var meridian = new Miner();

        simulator.AddShip(vaklas);
        simulator.AddShip(augur);
        simulator.AddShip(meridian);

        Assert.Throws<SuitableShipNotFoundException>(() => simulator.FindOptimalShip(route, out _, out _));
    }
}
