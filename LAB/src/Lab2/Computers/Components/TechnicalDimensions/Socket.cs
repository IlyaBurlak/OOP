using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computers.Components.TechnicalDimensions;

public record Socket
{
    public Socket(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("The socket value should not be null or whitespace.");

        Value = value;
    }

    public string Value { get; }
}
