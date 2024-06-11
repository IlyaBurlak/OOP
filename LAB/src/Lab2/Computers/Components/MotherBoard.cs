using System;
using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components.TechnicalDimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computers.Components;

public class MotherBoard
{
    public MotherBoard(
        Socket socket,
        int pcIeLanesCount,
        int sataPortsCount,
        Chipset chipset,
        SupportedDdr supportedDdr,
        int memorySlotsCount,
        FormFactor formFactor,
        Bios bios)
    {
        Socket = socket ?? throw new ArgumentNullException(nameof(socket));
        PcIeLanesCount = pcIeLanesCount;
        SataPortsCount = sataPortsCount;
        Chipset = chipset ?? throw new ArgumentNullException(nameof(chipset));
        SupportedDdr = supportedDdr ?? throw new ArgumentNullException(nameof(supportedDdr));
        MemorySlotsCount = memorySlotsCount;
        FormFactor = formFactor ?? throw new ArgumentNullException(nameof(formFactor));
        Bios = bios ?? throw new ArgumentNullException(nameof(bios));
    }

    public Socket Socket { get; private set; }
    public int PcIeLanesCount { get; private set; }
    public int SataPortsCount { get; private set; }
    public Chipset Chipset { get; private set; }
    public SupportedDdr SupportedDdr { get; private set; }
    public int MemorySlotsCount { get; private set; }
    public FormFactor FormFactor { get; private set; }
    public Bios Bios { get; private set; }
}