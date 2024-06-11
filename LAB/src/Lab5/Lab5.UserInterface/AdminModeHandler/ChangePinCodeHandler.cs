using System.Globalization;
using Lab5.BisnesLogic;

namespace Lab5.UserInterface.AdminModeHandler;

public class ChangePinCodeHandler : IAdminModeHandler
{
    private readonly ATMSystem _atmSystem;
    private IAdminModeHandler? _nextHandler;

    public ChangePinCodeHandler(ATMSystem atmSystem)
    {
        _atmSystem = atmSystem;
    }

    public void SetNext(IAdminModeHandler handler)
    {
        _nextHandler = handler;
    }

    public void Handle(int adminChoice)
    {
        if (adminChoice == 2)
        {
            Console.WriteLine("Enter account number:");
            string accountNumber = Console.ReadLine() ?? throw new InvalidOperationException();
            Console.WriteLine("Enter old PIN code:");
            int oldPinCode = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException(), CultureInfo.InvariantCulture);
            Console.WriteLine("Enter new PIN code:");
            int newPinCode = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException(), CultureInfo.InvariantCulture);
            _atmSystem.ChangePinCode(accountNumber, oldPinCode, newPinCode);
            Console.WriteLine("PIN code updated successfully.");
        }
        else if (_nextHandler != null)
        {
            _nextHandler.Handle(adminChoice);
        }
        else
        {
            Console.WriteLine("Invalid selection. Exiting admin mode...");
        }
    }
}