using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computers.Components;

public record Chipset
{
    public Chipset(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("The chipset name should not be null or whitespace.");
        }

        Name = name;
    }

    public string Name { get; }
}