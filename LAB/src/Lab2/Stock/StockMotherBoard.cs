using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Computers.Components.TechnicalDimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Stock;

public class StockMotherBoard
{
    private List<MotherBoard> _motherBoards = new List<MotherBoard>
    {
        new MotherBoard(new Socket("AM4"), 40, 6, new Chipset("X570"), new SupportedDdr("DDR4"), 4, new FormFactor("ATX"), new Bios("A.70")),
        new MotherBoard(new Socket("LGA 2066"), 48, 10, new Chipset("X299"), new SupportedDdr("DDR4"), 8, new FormFactor("E-ATX"), new Bios("P.60")),
        new MotherBoard(new Socket("AM4"), 32, 4, new Chipset("B450"), new SupportedDdr("DDR4"), 2, new FormFactor("mATX"), new Bios("F.60")),
    };

    public IReadOnlyList<MotherBoard> MotherBoards => _motherBoards.AsReadOnly();

    public void AddMotherBoard(MotherBoard newMotherBoard)
    {
        _motherBoards.Add(newMotherBoard);
    }
}