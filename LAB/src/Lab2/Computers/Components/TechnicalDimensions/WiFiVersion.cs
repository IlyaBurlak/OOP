using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computers.Components.WiFiVersions;

public record WiFiVersion
{
    public WiFiVersion(string versionNumber, double frequency, double maxTransferSpeed)
    {
        if (string.IsNullOrWhiteSpace(versionNumber))
        {
            throw new ArgumentNullException(nameof(versionNumber));
        }

        if (frequency <= 0)
        {
            throw new ArgumentException($"{nameof(frequency)} should be a positive number.");
        }

        if (maxTransferSpeed <= 0)
        {
            throw new ArgumentException($"{nameof(maxTransferSpeed)} should be a positive number.");
        }

        VersionNumber = versionNumber;
        Frequency = frequency;
        MaxTransferSpeed = maxTransferSpeed;
    }

    public string VersionNumber { get; }
    public double Frequency { get; }
    public double MaxTransferSpeed { get; }
}