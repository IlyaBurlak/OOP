using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computers.Components;

public record SupportedMemoryFrequency
{
    public SupportedMemoryFrequency(int maxValue)
    {
        if (maxValue <= 0)
        {
            throw new ArgumentException("Both frequency values should be positive numbers.");
        }

        MaxValue = maxValue;
    }

    public int MaxValue { get; }
}
