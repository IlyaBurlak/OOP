using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computers.Components.TechnicalDimensions;

public record FormFactor
{
    public FormFactor(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("The form factor info should not be null or whitespace.");

        Value = value;
    }

    public string Value { get; }
}