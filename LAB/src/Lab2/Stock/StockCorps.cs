using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components.TechnicalDimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Stock;

public class StockCorps
{
    private List<Corps> _corps = new List<Corps>
    {
        new Corps(170, new List<string> { "ATX" }, new Dimension(517, 223, 464)),
        new Corps(160, new List<string> { "ATX", "E-ATX" }, new Dimension(544, 242, 552)),
        new Corps(160, new List<string> { "mATX" }, new Dimension(400, 185, 380)),
    };

    public IReadOnlyList<Corps> Corps => _corps.AsReadOnly();

    public void AddCorps(Corps newCorps)
    {
        _corps.Add(newCorps);
    }
}