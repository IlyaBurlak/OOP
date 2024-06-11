namespace Itmo.ObjectOrientedProgramming.Lab1.Space.Enviroment;

public enum EnvironmentType
{
    NormalSpace,
    DenseNebula,
    NitrogenNebula,
}

public class Environment
{
    public Environment(EnvironmentType type, Obstacle.Obstacle? obstacle, double distance)
    {
        Type = type;
        Obstacle = obstacle;
        Distance = distance;
    }

    protected internal EnvironmentType Type { get; private set; }
    protected internal Obstacle.Obstacle? Obstacle { get; private set; }
    protected internal double Distance { get; private set; }
}
