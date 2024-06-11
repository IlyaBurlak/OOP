namespace Itmo.ObjectOrientedProgramming.Lab2.Computers.Components;

public class HDD
{
    public HDD(
        int capacity,
        int spindleSpeed,
        int powerConsumption)
    {
        Capacity = capacity;
        SpindleSpeed = spindleSpeed;
        PowerConsumption = powerConsumption;
    }

    public int Capacity { get; private set; }
    public int SpindleSpeed { get; private set; }
    public int PowerConsumption { get; private set; }
}
