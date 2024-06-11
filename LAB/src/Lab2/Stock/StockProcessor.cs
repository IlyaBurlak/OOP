using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components.TechnicalDimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Stock;

public class StockProcessor
{
    private List<Processor> _processors = new List<Processor>
    {
        new Processor(4800, 16, new Socket("AM4"), false, new SupportedMemoryFrequency(3200), 200, 200),
        new Processor(3000, 18, new Socket("LGA 2066"), false, new SupportedMemoryFrequency(2800), 165, 165),
        new Processor(3600, 12, new Socket("AM4"), true, new SupportedMemoryFrequency(3200), 65, 65),
    };

    public IReadOnlyList<Processor> Processors => _processors.AsReadOnly();

    public void AddProcessor(Processor newProcessor)
    {
        _processors.Add(newProcessor);
    }
}