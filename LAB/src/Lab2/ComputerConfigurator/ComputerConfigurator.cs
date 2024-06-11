using System;
using System.Collections.Generic;
using System.ComponentModel;
using Itmo.ObjectOrientedProgramming.Lab2.Computers;
using Itmo.ObjectOrientedProgramming.Lab2.Exeption;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerConfigurator;

public class ComputerConfigurator : IComputerConfigurator
{
    private readonly List<ICheckCompatibility> _compatibilityChecks = new()
    {
        new CheckCpuCoolerSocketsCompatibility(),
        new CheckHeatDissipationCompatibility(),
    };

    public bool CheckCompatibility(Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        foreach (ICheckCompatibility check in _compatibilityChecks)
        {
            check.Validate(computer);
        }

        return CheckPower(computer);
    }

    private static bool CheckPower(Computer computer)
    {
        int warningPowerDifference = 100;
        int totalPower = computer.GPU.PowerConsumption
                         + computer.Processor.PowerConsumption
                         + computer.SSD.PowerConsumption
                         + computer.HDD.PowerConsumption
                         + computer.RAM.PowerConsumption
                         + computer.WiFiAdapter.PowerConsumption;

        int powerDifference = computer.PowerSupply.PeakPower - totalPower;

        if (computer.PowerSupply.PeakPower < totalPower)
        {
            throw new IncompatibleConfigurationException("The total power consumption of the components exceeds the power supply's capabilities.");
        }

        if (powerDifference <= warningPowerDifference)
        {
            throw new WarningException("The total power consumption is dangerously close to the power supply's peak power.");
        }

        return true;
    }
}
