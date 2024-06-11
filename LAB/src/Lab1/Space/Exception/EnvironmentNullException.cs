namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Exception;

public class EnvironmentNullException : System.Exception
{
    public EnvironmentNullException()
        : base("Environment is null for one of the route segments")
    {
    }

    public EnvironmentNullException(string message)
        : base(message)
    {
    }

    public EnvironmentNullException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}