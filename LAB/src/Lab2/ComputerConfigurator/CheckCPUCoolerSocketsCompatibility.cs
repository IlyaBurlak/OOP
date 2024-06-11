using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Computers;
using Itmo.ObjectOrientedProgramming.Lab2.Exeption;

namespace Itmo.ObjectOrientedProgramming.Lab2.ComputerConfigurator;

public class CheckCpuCoolerSocketsCompatibility : ICheckCompatibility
{
    public void Validate(Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        if (!computer.CPUCooler.SupportedSockets.Values.Any(socket => socket.Equals(computer.Processor.Socket)))
        {
            throw new IncompatibleConfigurationException("The CPU cooler's supported sockets do not match the processor's socket");
        }
    }
}