namespace Itmo.ObjectOrientedProgramming.Lab2.Computers.Components;

public class PowerSupply
{
    public PowerSupply(int peakPower)
    {
        PeakPower = peakPower;
    }

    public int PeakPower { get; private set; }
}