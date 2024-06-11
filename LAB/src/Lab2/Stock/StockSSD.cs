using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components.ConnectionTypes;

namespace Itmo.ObjectOrientedProgramming.Lab2.Stock;

public class StockSSD
{
    private readonly List<SSD> _ssds = new List<SSD>
    {
        new SSD(new ConnectionType("NVMe PCIe M.2"), 1024, 3500, 6),
        new SSD(new ConnectionType("NVMe PCIe M.2"), 2048, 3450, 8),
        new SSD(new ConnectionType("NVMe PCIe M.2"), 256, 2000, 2),
    };

    public IReadOnlyList<SSD> Ssds => _ssds.AsReadOnly();

    public void AddSSD(SSD newSsd)
    {
        _ssds.Add(newSsd);
    }
}