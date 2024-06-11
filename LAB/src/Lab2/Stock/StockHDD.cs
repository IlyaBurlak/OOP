using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Stock;

public class StockHDD
{
    private List<HDD> _hdds = new List<HDD>
    {
        new HDD(2000, 7200, 7),
        new HDD(4000, 7200, 9),
        new HDD(1000, 5400, 2),
    };

    public IReadOnlyList<HDD> Hdds => _hdds.AsReadOnly();

    public void AddHDD(HDD newHdd)
    {
        _hdds.Add(newHdd);
    }
}