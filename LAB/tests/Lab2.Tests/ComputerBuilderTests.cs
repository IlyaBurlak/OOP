using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Bilder;
using Itmo.ObjectOrientedProgramming.Lab2.Computers;
using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components.ConnectionTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components.TechnicalDimensions;
using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components.WiFiVersions;
using Itmo.ObjectOrientedProgramming.Lab2.Stock;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class ComputerBuilderTests
{
    private readonly StockCorps stockCorps = new StockCorps();
    private readonly StockCpuCoolers stockCpuCoolers = new StockCpuCoolers();
    private readonly StockGPU stockGPU = new StockGPU();
    private readonly StockMotherBoard stockMotherBoard = new StockMotherBoard();
    private readonly StockProcessor stockProcessor = new StockProcessor();
    private readonly StockRAM stockRAM = new StockRAM();
    private readonly StockSSD stockSSD = new StockSSD();
    private readonly StockWiFiAdapter stockWiFiAdapter = new StockWiFiAdapter();
    private readonly StockPowerSupply stockPowerSupply = new StockPowerSupply();
    private readonly StockHDD stockHDD = new StockHDD();

    [Fact]
    public void ShouldFailWithIncompatibleParts()
    {
        Computers.Components.CPUCooler incompatibleCooler = stockCpuCoolers.CpuCoolers[2];
        var builder = new GamingComputerBuilder();
        builder.ChooseCPUCooler(incompatibleCooler);

        Assert.Throws<InvalidOperationException>(() => builder.Build());
    }

    [Fact]
    public void BuildGamingComputerBuilderConstructsComputerSuccessfully()
    {
        GamingComputerBuilder builder = Build();
        Computer computer = builder.Build();

        Assert.NotNull(computer);
        Assert.IsType<Computer>(computer);
    }

    [Fact]
    public void ChooseCorpsWithValidCorpsSuccessfullySetsCorps()
    {
        GamingComputerBuilder builder = Build();
        Corps customCorps = stockCorps.Corps[1];

        builder.ChooseCorps(customCorps);
        Computer computer = builder.Build();

        Assert.Equal(customCorps, computer.Corps);
    }

    private GamingComputerBuilder Build()
    {
        string processorSocket = "AM4";

        var processor = new Processor(4800, 16, new Socket(processorSocket), false, new SupportedMemoryFrequency(3200), 200, 200);
        var corps = new Corps(170, new List<string> { "ATX" }, new Dimension(517, 223, 464));
        var cpuCooler = new CPUCooler(250, new SupportedSockets(new List<string> { processorSocket }), new Dimension(156, 140, 165));
        var gpu = new GPU(new Dimension(160, 267, 30), 8192, new PCIeVersion("PCIe 3.0"), 2000, 120);
        var motherboard = new MotherBoard(new Socket("AM4"), 40, 6, new Chipset("X570"), new SupportedDdr("DDR4"), 4, new FormFactor("ATX"), new Bios("A.70"));
        var ram = new RAM(32, new JedecVersion("PC4-25600"), new List<string> { "3200 MHz" }, new FormFactor("288-контактный DIMM"), new DDRVersion(4, 0), 8);
        var ssd = new SSD(new ConnectionType("NVMe PCIe M.2"), 1024, 3500, 6);
        var wifiAdapter = new WiFiAdapter(new WiFiVersion("Wi-Fi 6 (802.11ax)", 5.0, 6.0), true, new PCIeVersion("PCIe 2.0"), 2);
        var powerSupply = new PowerSupply(650);
        var hdd = new HDD(2048, 7200, 150);

        stockProcessor.AddProcessor(processor);
        stockCorps.AddCorps(corps);
        stockCpuCoolers.AddCPUCooler(cpuCooler);
        stockGPU.AddGPU(gpu);
        stockMotherBoard.AddMotherBoard(motherboard);
        stockRAM.AddRAM(ram);
        stockSSD.AddSSD(ssd);
        stockWiFiAdapter.AddWiFiAdapter(wifiAdapter);
        stockPowerSupply.AddPowerSupply(powerSupply);
        stockHDD.AddHDD(hdd);

        var builder = new GamingComputerBuilder();
        builder.ChooseProcessor(processor);
        builder.ChooseCorps(corps);
        builder.ChooseCPUCooler(cpuCooler);
        builder.ChooseGPU(gpu);
        builder.ChooseMotherBoard(motherboard);
        builder.ChooseRAM(ram);
        builder.ChooseSSD(ssd);
        builder.ChooseWiFiAdapter(wifiAdapter);
        builder.ChoosePowerSupply(powerSupply);
        builder.ChooseHDD(hdd);

        return builder;
    }
}
