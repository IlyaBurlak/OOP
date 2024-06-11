using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computers.Components.TechnicalDimensions;

public record Dimension
{
    public Dimension(int width, int height, int depth)
    {
        if (width <= 0 || height <= 0 || depth <= 0)
        {
            throw new ArgumentException("All dimensions should be positive numbers.");
        }

        Width = width;
        Height = height;
        Depth = depth;
    }

    public int Width { get; }
    public int Height { get; }
    public int Depth { get; }
}