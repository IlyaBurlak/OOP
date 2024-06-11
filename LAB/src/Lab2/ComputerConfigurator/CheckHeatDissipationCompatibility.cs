using System;
using Itmo.ObjectOrientedProgramming.Lab2.Computers;
using Itmo.ObjectOrientedProgramming.Lab2.Exeption;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerConfigurator;

public class CheckHeatDissipationCompatibility : ICheckCompatibility
{
    public void Validate(Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        if (computer.CPUCooler.MaxHeatDissipation < computer.Processor.TDP)
        {
            throw new InsufficientCoolingException("The heat production of the processor exceeds the CPU Cooler's cooling capabilities");
        }
    }
}