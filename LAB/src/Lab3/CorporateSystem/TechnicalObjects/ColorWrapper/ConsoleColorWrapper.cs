using System;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects.RecipientObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects.ColorWrapper;
public class ConsoleColorWrapper : IColorWrapper
{
    private readonly ConsoleColor _color;

    public ConsoleColorWrapper(ConsoleColor color) => _color = color;

    public ConsoleColor Color => _color;
}