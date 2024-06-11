using System.Globalization;
using Lab5.BisnesLogic;
using Lab5.UserInterface.UserModeHandler;

namespace Lab5.UserInterface;

public class UserModeUI : IModeUI
{
    private readonly ATMSystem _atmSystem;
    private IUserModeHandler _handler;

    public UserModeUI(ATMSystem atmSystem)
    {
        _atmSystem = atmSystem;
        _handler = CreateChain();
    }

    public void Activate()
    {
        while (true)
        {
            Console.WriteLine("Please select an option:\n 1. Login to an account\n 2. Create a new account\n 3. Exit");
            int entryOption = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException(), CultureInfo.InvariantCulture);
            _handler.Handle(entryOption);
        }
    }

    private IUserModeHandler CreateChain()
    {
        var loginHandler = new LoginHandler(_atmSystem);
        var createAccountHandler = new CreateAccountHandler(_atmSystem);

        loginHandler.SetNext(createAccountHandler);

        return loginHandler;
    }
}