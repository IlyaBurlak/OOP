using System;
using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components.TechnicalDimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computers.Components;

public class CPUCooler
{
    public CPUCooler(
        int maxHeatDissipation,
        SupportedSockets supportedSockets,
        Dimension dimensions)
    {
        if (maxHeatDissipation <= 0)
        {
            throw new ArgumentException("Максимальная теплоотдача должна быть положительным числом", nameof(maxHeatDissipation));
        }

        if (supportedSockets == null || supportedSockets.Values.Count == 0)
        {
            throw new ArgumentException("Поддерживаемые сокеты не могут быть null или пустыми", nameof(supportedSockets));
        }

        if (dimensions == null)
        {
            throw new ArgumentException("Размеры не могут быть null", nameof(dimensions));
        }

        MaxHeatDissipation = maxHeatDissipation;
        SupportedSockets = supportedSockets;
        Dimensions = dimensions;
    }

    public int MaxHeatDissipation { get; }
    public SupportedSockets SupportedSockets { get; }
    public Dimension Dimensions { get; }
}