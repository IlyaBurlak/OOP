using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components.TechnicalDimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computers.Components;

public class RAM
{
    public RAM(
        int memorySize,
        JedecVersion supportedJedec,
        IReadOnlyList<string> xmpProfiles,
        FormFactor formFactor,
        DDRVersion ddrVersion,
        int powerConsumption)
    {
        MemorySize = memorySize;
        SupportedJEDEC = supportedJedec ?? throw new ArgumentNullException(nameof(supportedJedec));
        XMPProfiles = xmpProfiles ?? throw new ArgumentNullException(nameof(xmpProfiles));
        FormFactor = formFactor ?? throw new ArgumentNullException(nameof(formFactor));
        DDRVersion = ddrVersion ?? throw new ArgumentNullException(nameof(ddrVersion));
        PowerConsumption = powerConsumption;
    }

    public int MemorySize { get;  private set; }
    public JedecVersion SupportedJEDEC { get; }
    public IReadOnlyList<string> XMPProfiles { get; private set; }
    public FormFactor FormFactor { get; }
    public DDRVersion DDRVersion { get; }
    public int PowerConsumption { get; private set; }
}