using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computers.Components.ConnectionTypes;

public record ConnectionType
{
    public ConnectionType(string type)
    {
        if (string.IsNullOrEmpty(type))
        {
            throw new ArgumentNullException(nameof(type), "Connection Type cannot be null or empty.");
        }

        Type = type;
    }

    public string Type { get; }
}