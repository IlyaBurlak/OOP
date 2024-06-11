using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computers.Components;

public record PCIeVersion
{
    public PCIeVersion(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("PCIe version cannot be null or empty", nameof(value));
        }

        if (!VersionValueIsValid(value))
        {
            throw new ArgumentException("Invalid PCIe version format", nameof(value));
        }

        Value = value;
    }

    public string Value { get; }

    private static bool VersionValueIsValid(string value)
    {
        return value.StartsWith("PCIe ", StringComparison.InvariantCulture);
    }
}