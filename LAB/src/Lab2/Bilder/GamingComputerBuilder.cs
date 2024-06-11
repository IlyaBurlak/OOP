using System;
using Itmo.ObjectOrientedProgramming.Lab2.Computers;
using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Bilder;

public class GamingComputerBuilder : ComputerBuilder
{
    private Corps? _corps;
    private CPUCooler? _cpuCooler;
    private HDD? _hdd;
    private GPU? _gpu;
    private MotherBoard? _motherboard;
    private PowerSupply? _powerSupply;
    private Processor? _processor;
    private RAM? _ram;
    private SSD? _ssd;
    private WiFiAdapter? _wifiAdapter;

    public override GamingComputerBuilder ChooseCorps(Corps corps)
    {
        _corps = corps;
        return this;
    }

    public GamingComputerBuilder ChooseCPUCooler(CPUCooler cpuCooler)
    {
        _cpuCooler = cpuCooler;
        return this;
    }

    public GamingComputerBuilder ChooseHDD(HDD hdd)
    {
        _hdd = hdd;
        return this;
    }

    public GamingComputerBuilder ChooseGPU(GPU gpu)
    {
        _gpu = gpu;
        return this;
    }

    public new GamingComputerBuilder ChooseMotherBoard(MotherBoard motherboard)
    {
        _motherboard = motherboard;
        return this;
    }

    public new GamingComputerBuilder ChoosePowerSupply(PowerSupply powerSupply)
    {
        _powerSupply = powerSupply;
        return this;
    }

    public new GamingComputerBuilder ChooseProcessor(Processor processor)
    {
        _processor = processor;
        return this;
    }

    public GamingComputerBuilder ChooseRAM(RAM ram)
    {
        _ram = ram;
        return this;
    }

    public GamingComputerBuilder ChooseSSD(SSD ssd)
    {
        _ssd = ssd;
        return this;
    }

    public new GamingComputerBuilder ChooseWiFiAdapter(WiFiAdapter wifiAdapter)
    {
        _wifiAdapter = wifiAdapter;
        return this;
    }

    public new Computer Build()
    {
        if (_corps == null ||
            _cpuCooler == null ||
            _hdd == null ||
            _gpu == null ||
            _motherboard == null ||
            _powerSupply == null ||
            _processor == null ||
            _ram == null ||
            _ssd == null ||
            _wifiAdapter == null)
        {
            throw new InvalidOperationException("Не все компоненты были выбраны");
        }

        return new Computer(_corps, _cpuCooler, _hdd, _gpu, _motherboard, _powerSupply, _processor, _ram, _ssd, _wifiAdapter);
    }
}