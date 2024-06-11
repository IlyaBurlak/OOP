using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computers;

public class Computer
{
    public Computer(
        Corps corps,
        CPUCooler cpuCooler,
        HDD hdd,
        GPU gpu,
        MotherBoard motherboard,
        PowerSupply powerSupply,
        Processor processor,
        RAM ram,
        SSD ssd,
        WiFiAdapter wifiAdapter)
    {
        Corps = corps;
        CPUCooler = cpuCooler;
        HDD = hdd;
        GPU = gpu;
        MotherBoard = motherboard;
        PowerSupply = powerSupply;
        Processor = processor;
        RAM = ram;
        SSD = ssd;
        WiFiAdapter = wifiAdapter;
    }

    public Corps Corps { get; }
    public CPUCooler CPUCooler { get; }
    public HDD HDD { get; }
    public GPU GPU { get; }
    public MotherBoard MotherBoard { get; }
    public PowerSupply PowerSupply { get; }
    public Processor Processor { get; }
    public RAM RAM { get; }
    public SSD SSD { get; }
    public WiFiAdapter WiFiAdapter { get; }
}

// коммит так как ничего проблкемы с push