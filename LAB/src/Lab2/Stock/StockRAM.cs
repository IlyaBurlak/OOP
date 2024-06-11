using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components.TechnicalDimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Stock;

public class StockRAM
{
    private List<RAM> _ram = new List<RAM>
    {
        new RAM(32, new JedecVersion("PC4-25600"), new List<string> { "3200 MHz" }, new FormFactor("288-контактный DIMM"), new DDRVersion(4, 0), 8),
        new RAM(128, new JedecVersion("PC4-22400"), new List<string> { "2800 MHz", "3200 MHz" }, new FormFactor("288-контактный DIMM"), new DDRVersion(4, 0), 4),
        new RAM(16, new JedecVersion("PC4-25600"), new List<string> { "2400 MHz", "3200 MHz" }, new FormFactor("260-контактный SO-DIMM"), new DDRVersion(4, 0), 2),
    };

    public IReadOnlyList<RAM> Ram => _ram.AsReadOnly();

    public void AddRAM(RAM newRam)
    {
        _ram.Add(newRam);
    }
}