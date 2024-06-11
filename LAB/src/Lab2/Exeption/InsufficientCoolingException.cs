using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exeption;

public class InsufficientCoolingException : Exception
{
    public InsufficientCoolingException()
    {
    }

    public InsufficientCoolingException(string message)
        : base(message)
    {
    }

    public InsufficientCoolingException(string message, Exception inner)
        : base(message, inner)
    {
    }
}