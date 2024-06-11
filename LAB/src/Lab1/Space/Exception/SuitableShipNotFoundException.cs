namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Exception;

public class SuitableShipNotFoundException : System.Exception
{
    public SuitableShipNotFoundException()
        : base("No suitable ship was found for this route.")
    {
    }

    public SuitableShipNotFoundException(string message)
        : base(message)
    {
    }

    public SuitableShipNotFoundException(string message, System.Exception innerException)
        : base(message, innerException)
    {
    }
}