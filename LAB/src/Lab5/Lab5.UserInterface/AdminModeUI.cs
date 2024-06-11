using System.Globalization;
using Lab5.BisnesLogic;
using Lab5.UserInterface.AdminModeHandler;

namespace Lab5.UserInterface;

public class AdminModeUI : IModeUI
{
    private readonly ATMSystem _atmSystem;
    private readonly string systemPassword;

    public AdminModeUI(ATMSystem atmSystem, string systemPassword)
    {
        this._atmSystem = atmSystem;
        this.systemPassword = systemPassword;
    }

    public void Activate()
    {
        Console.WriteLine("Please enter the system password:");
        string inputPassword = Console.ReadLine() ?? throw new InvalidOperationException();

        if (inputPassword != this.systemPassword)
        {
            Console.WriteLine("Invalid password. Exiting system...");
            return;
        }

        Console.WriteLine("Administrator mode: \n 1. Change account number \n 2. Change PIN code \n 3.Exit");
        int adminChoice = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException(), CultureInfo.InvariantCulture);

        IAdminModeHandler handler = CreateChain();

        handler.Handle(adminChoice);
    }

    private IAdminModeHandler CreateChain()
    {
        var changeAccountNumberHandler = new ChangeAccountNumberHandler(_atmSystem);
        var changePinCodeHandler = new ChangePinCodeHandler(_atmSystem);

        changeAccountNumberHandler.SetNext(changePinCodeHandler);

        return changeAccountNumberHandler;
    }
}