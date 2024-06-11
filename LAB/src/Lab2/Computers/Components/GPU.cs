using System;
using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components.TechnicalDimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computers.Components;

public class GPU
{
    public GPU(
        Dimension size,
        int videoMemorySize,
        PCIeVersion pcIeVersion,
        int chipFrequency,
        int powerConsumption)
    {
        if (videoMemorySize <= 0)
        {
            throw new ArgumentException("Video memory size must be a positive number", nameof(videoMemorySize));
        }

        if (chipFrequency <= 0)
        {
            throw new ArgumentException("Chip frequency must be a positive number", nameof(chipFrequency));
        }

        if (powerConsumption <= 0)
        {
            throw new ArgumentException("Power consumption must be a positive number", nameof(powerConsumption));
        }

        Size = size;
        VideoMemorySize = videoMemorySize;
        PCIeVersion = pcIeVersion;
        ChipFrequency = chipFrequency;
        PowerConsumption = powerConsumption;
    }

    public Dimension Size { get; }
    public int VideoMemorySize { get; }
    public PCIeVersion PCIeVersion { get; }
    public int ChipFrequency { get; }
    public int PowerConsumption { get; }
}