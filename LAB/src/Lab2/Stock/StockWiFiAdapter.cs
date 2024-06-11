using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components.WiFiVersions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Stock;

public class StockWiFiAdapter
{
    private List<WiFiAdapter> _wifiAdapters = new List<WiFiAdapter>
    {
        new WiFiAdapter(new WiFiVersion("Wi-Fi 6 (802.11ax)", 5.0, 6.0), true, new PCIeVersion("PCIe 2.0"), 2),
        new WiFiAdapter(new WiFiVersion("Wi-Fi 6 (802.11ax)", 5.0, 6.0), true, new PCIeVersion("PCIe 3.0"), 3),
        new WiFiAdapter(new WiFiVersion("Wi-Fi 5 (802.11ac)", 5.0, 5.0), true, new PCIeVersion("PCIe 2.0"), 1),
    };

    public IReadOnlyList<WiFiAdapter> WiFiAdapters => _wifiAdapters.AsReadOnly();

    public void AddWiFiAdapter(WiFiAdapter newWifiAdapter)
    {
        _wifiAdapters.Add(newWifiAdapter);
    }
}