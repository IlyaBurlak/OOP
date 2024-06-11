using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computers.Components;

public record DDRVersion
{
    public DDRVersion(int majorVersion, int minorVersion)
    {
        if (majorVersion < 0 || minorVersion < 0)
        {
            throw new ArgumentException("Both major and minor version should be non-negative numbers.");
        }

        MajorVersion = majorVersion;
        MinorVersion = minorVersion;
    }

    public int MajorVersion { get; }
    public int MinorVersion { get; }
}