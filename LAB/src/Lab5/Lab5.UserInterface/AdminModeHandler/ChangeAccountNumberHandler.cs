using System.Globalization;
using Lab5.BisnesLogic;

namespace Lab5.UserInterface.AdminModeHandler;

public class ChangeAccountNumberHandler : IAdminModeHandler
{
    private readonly ATMSystem _atmSystem;
    private IAdminModeHandler? _nextHandler;

    public ChangeAccountNumberHandler(ATMSystem atmSystem)
    {
        _atmSystem = atmSystem;
    }

    public void SetNext(IAdminModeHandler handler)
    {
        _nextHandler = handler;
    }

    public void Handle(int adminChoice)
    {
        if (adminChoice == 1)
        {
            Console.WriteLine("Enter old account number:");
            string oldAccountNumber = Console.ReadLine() ?? throw new InvalidOperationException();
            Console.WriteLine("Enter new account number:");
            string newAccountNumber = Console.ReadLine() ?? throw new InvalidOperationException();
            Console.WriteLine("Enter PIN code:");
            int pinCodeForAccountChange = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException(), CultureInfo.InvariantCulture);
            _atmSystem.ChangeAccountNumber(oldAccountNumber, newAccountNumber, pinCodeForAccountChange);
            Console.WriteLine("Account number updated successfully.");
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