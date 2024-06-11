using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computers.Components.TechnicalDimensions;

public record JedecVersion
{
    public JedecVersion(string version)
    {
        Version = version ?? throw new ArgumentNullException(nameof(version));
    }

    public string Version { get; }
}