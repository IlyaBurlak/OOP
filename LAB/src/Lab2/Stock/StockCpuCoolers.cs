using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components.TechnicalDimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Stock;

public class StockCpuCoolers
{
    private List<CPUCooler> _cpuCoolers = new List<CPUCooler>
    {
        new CPUCooler(250, new SupportedSockets(new List<string> { "AM4" }), new Dimension(156, 140, 165)),
        new CPUCooler(350, new SupportedSockets(new List<string> { "LGA 2066" }), new Dimension(158, 150, 171)),
        new CPUCooler(120, new SupportedSockets(new List<string> { "AM4" }), new Dimension(123, 78, 159)),
    };

    public IReadOnlyList<CPUCooler> CpuCoolers => _cpuCoolers.AsReadOnly();

    public void AddCPUCooler(CPUCooler newCpuCooler)
    {
        _cpuCoolers.Add(newCpuCooler);
    }
}