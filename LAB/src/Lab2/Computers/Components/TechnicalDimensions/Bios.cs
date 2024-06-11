using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computers.Components.TechnicalDimensions;

public record Bios
{
    public Bios(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("The BIOS info should not be null or whitespace.");

        Value = value;
    }

    public string Value { get; }
}