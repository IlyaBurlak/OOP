namespace Itmo.ObjectOrientedProgramming.Lab2.Exeption;

public class ComponentsException : System.Exception
{
    public ComponentsException(string message)
        : base(message) { }

    public ComponentsException()
    {
    }

    public ComponentsException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}