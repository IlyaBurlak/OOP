using System;
using Itmo.ObjectOrientedProgramming.Lab2.Computers;
using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components;

namespace Itmo.ObjectOrientedProgramming.Lab2.Bilder;

public class ComputerBuilder
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

    public virtual ComputerBuilder ChooseCorps(Corps corps)
    {
        _corps = corps;
        return this;
    }

    public virtual ComputerBuilder ChooseCpuCooler(CPUCooler cpuCooler)
    {
        _cpuCooler = cpuCooler;
        return this;
    }

    public virtual ComputerBuilder ChooseHdd(HDD hdd)
    {
        _hdd = hdd;
        return this;
    }

    public virtual ComputerBuilder ChooseGpu(GPU gpu)
    {
        _gpu = gpu;
        return this;
    }

    public virtual ComputerBuilder ChooseMotherBoard(MotherBoard motherboard)
    {
        _motherboard = motherboard;
        return this;
    }

    public virtual ComputerBuilder ChoosePowerSupply(PowerSupply powerSupply)
    {
        _powerSupply = powerSupply;
        return this;
    }

    public virtual ComputerBuilder ChooseProcessor(Processor processor)
    {
        _processor = processor;
        return this;
    }

    public virtual ComputerBuilder ChooseRam(RAM ram)
    {
        _ram = ram;
        return this;
    }

    public virtual ComputerBuilder ChooseSsd(SSD ssd)
    {
        _ssd = ssd;
        return this;
    }

    public virtual ComputerBuilder ChooseWiFiAdapter(WiFiAdapter wifiAdapter)
    {
        _wifiAdapter = wifiAdapter;
        return this;
    }

    public virtual Computer Build()
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