using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components.TechnicalDimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Stock;

public class StockGPU
{
    private List<GPU> _gpus = new List<GPU>
    {
        new GPU(new Dimension(160, 267, 30), 8192, new PCIeVersion("PCIe 3.0"), 2000, 120),
        new GPU(new Dimension(111, 300, 30), 8192, new PCIeVersion("PCIe 3.0"), 1506, 150),
        new GPU(new Dimension(100, 180, 30), 4096, new PCIeVersion("PCIe 3.0"), 1265, 75),
    };
    public IReadOnlyList<GPU> Gpus => _gpus.AsReadOnly();

    public void AddGPU(GPU newGpu)
    {
        _gpus.Add(newGpu);
    }
}