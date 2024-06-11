using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computers.Components.TechnicalDimensions;

public record SupportedDdr
{
    public SupportedDdr(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("The DDR support info should not be null or whitespace.");

        Value = value;
    }

    public string Value { get; }
}