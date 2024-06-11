using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exeption;

public class IncompatibleConfigurationException : Exception
{
    public IncompatibleConfigurationException()
    {
    }

    public IncompatibleConfigurationException(string message)
        : base(message)
    {
    }

    public IncompatibleConfigurationException(string message, Exception inner)
        : base(message, inner)
    {
    }
}