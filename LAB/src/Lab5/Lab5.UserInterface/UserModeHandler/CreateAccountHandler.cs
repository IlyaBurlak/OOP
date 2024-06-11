using System.Globalization;
using Lab5.BisnesLogic;

namespace Lab5.UserInterface.UserModeHandler;

public class CreateAccountHandler : BaseUserModeHandler
{
    public CreateAccountHandler(ATMSystem atmSystem)
        : base(atmSystem)
    {
    }

    public override void Handle(int entryOption)
    {
        if (entryOption == 2)
        {
            CreateAccount();
        }
        else if (NextHandler != null)
        {
            NextHandler.Handle(entryOption);
        }
        else
        {
            Console.WriteLine("Invalid selection. Please try again.");
        }
    }

    private void CreateAccount()
    {
        Console.WriteLine("Enter the new account number:");
        string accountNumber = Console.ReadLine() ?? throw new InvalidOperationException();

        Console.WriteLine("Enter the PIN code for the new account:");
        int pinCode = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException(), CultureInfo.InvariantCulture);

        AtmSystem.CreateAccount(accountNumber, pinCode);

        Console.WriteLine("Account successfully created. Please log in.");
    }
}