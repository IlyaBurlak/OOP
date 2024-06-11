using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components.TechnicalDimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computers.Components;

public class Processor
{
    public Processor(
        int coreFrequency,
        int coresCount,
        Socket socket,
        bool integratedGraphics,
        SupportedMemoryFrequency supportedMemoryFrequency,
        int tdp,
        int powerConsumption)
    {
        CoreFrequency = coreFrequency;
        CoresCount = coresCount;
        Socket = socket;
        IntegratedGraphics = integratedGraphics;
        SupportedMemoryFrequency = supportedMemoryFrequency;
        TDP = tdp;
        PowerConsumption = powerConsumption;
    }

    public int CoreFrequency { get; private set; }
    public int CoresCount { get; private set; }
    public Socket Socket { get; }
    public bool IntegratedGraphics { get; private set; }
    public SupportedMemoryFrequency SupportedMemoryFrequency { get; private set; }
    public int TDP { get; private set; }
    public int PowerConsumption { get; private set; }
}