using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components.TechnicalDimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computers.Components;

public class Corps
{
    public Corps(int maxGpuHeight, IReadOnlyList<string> supportedMotherboardFormFactors, Dimension dimensions)
    {
        if (maxGpuHeight <= 0)
        {
            throw new ArgumentException("Max GPU height must be a positive number", nameof(maxGpuHeight));
        }

        if (supportedMotherboardFormFactors == null || !supportedMotherboardFormFactors.Any())
        {
            throw new ArgumentException("Supported motherboard form factors cannot be null or empty", nameof(supportedMotherboardFormFactors));
        }

        if (dimensions == null)
        {
            throw new ArgumentException("Dimensions cannot be null", nameof(dimensions));
        }

        MaxGPUHeight = maxGpuHeight;
        SupportedMotherboardFormFactors = supportedMotherboardFormFactors;
        Dimensions = dimensions;
    }

    public int MaxGPUHeight { get; }
    public IReadOnlyList<string> SupportedMotherboardFormFactors { get; }
    public Dimension Dimensions { get; }
}