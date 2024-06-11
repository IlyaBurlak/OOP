using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemManagement.NullExeption;

public class NullCommandException : Exception
{
    public NullCommandException()
        : base("The command read from the console was null.") { }

    public NullCommandException(string message)
        : base(message)
    {
    }

    public NullCommandException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}