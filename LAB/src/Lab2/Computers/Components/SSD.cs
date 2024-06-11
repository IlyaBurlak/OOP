using System;
using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components.ConnectionTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computers.Components;

public class SSD
{
    public SSD(
        ConnectionType connectionType,
        int capacity,
        int maxSpeed,
        int powerConsumption)
    {
        ConnectionType = connectionType ?? throw new ArgumentNullException(nameof(connectionType));
        Capacity = capacity;
        MaxSpeed = maxSpeed;
        PowerConsumption = powerConsumption;
    }

    public ConnectionType ConnectionType { get; private set; }
    public int Capacity { get; private set; }
    public int MaxSpeed { get; private set; }
    public int PowerConsumption { get; private set; }
}