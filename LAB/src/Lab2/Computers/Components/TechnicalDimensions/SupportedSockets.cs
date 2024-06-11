using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computers.Components;

public record SupportedSockets
{
    public SupportedSockets(IReadOnlyList<string> values)
    {
        if (values == null || !values.Any())
        {
            throw new ArgumentException("Supported sockets cannot be null or empty.", nameof(values));
        }

        Values = values;
    }

    public IReadOnlyList<string> Values { get; }
}