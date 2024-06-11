using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Stock;
public class StockPowerSupply
{
    private List<PowerSupply> _powerSupplies = new List<PowerSupply>
    {
        new PowerSupply(1200),
        new PowerSupply(2000),
        new PowerSupply(450),
    };

    public IReadOnlyList<PowerSupply> PowerSupplies => _powerSupplies.AsReadOnly();

    public void AddPowerSupply(PowerSupply newPowerSupply)
    {
        _powerSupplies.Add(newPowerSupply);
    }
}