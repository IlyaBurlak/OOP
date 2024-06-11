using System;
using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components.WiFiVersions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Computers.Components;

public class WiFiAdapter
{
    public WiFiAdapter(
        WiFiVersion wiFiVersion,
        bool bluetoothModule,
        PCIeVersion pcIeVersion,
        int powerConsumption)
    {
        WiFiVersion = wiFiVersion ?? throw new ArgumentNullException(nameof(wiFiVersion));
        BluetoothModule = bluetoothModule;
        PCIeVersion = pcIeVersion ?? throw new ArgumentNullException(nameof(pcIeVersion));
        PowerConsumption = powerConsumption;
    }

    public WiFiVersion WiFiVersion { get; private set; }
    public bool BluetoothModule { get; private set; }
    public PCIeVersion PCIeVersion { get; private set; }
    public int PowerConsumption { get; private set; }
}