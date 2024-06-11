using Itmo.ObjectOrientedProgramming.Lab2.Computers;
namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerConfigurator;

public interface IComputerConfigurator
{
    public bool CheckCompatibility(Computer computer);
}
