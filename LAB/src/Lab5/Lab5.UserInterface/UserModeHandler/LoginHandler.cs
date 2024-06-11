using System.Diagnostics;
using System.Globalization;
using Lab5.BisnesLogic;
using Lab5.UserInterface.UserModeHandler.HandlerForLogIn;

namespace Lab5.UserInterface.UserModeHandler;

public class LoginHandler : BaseUserModeHandler
{
    private OperationHandlerBase? firstHandler;

    public LoginHandler(ATMSystem atmSystem)
        : base(atmSystem)
    {
        BuildChain();
    }

    public override void Handle(int entryOption)
    {
        if (entryOption == 1)
        {
            LogIntoAccount();
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

    private void BuildChain()
    {
        var checkBalanceHandler = new CheckBalanceHandler(AtmSystem);
        var withdrawMoneyHandler = new WithdrawMoneyHandler(AtmSystem);
        var depositMoneyHandler = new DepositMoneyHandler(AtmSystem);
        var transactionHistoryHandler = new TransactionHistoryHandler(AtmSystem);

        checkBalanceHandler.SetNextHandler(withdrawMoneyHandler)
            .SetNextHandler(depositMoneyHandler)
            .SetNextHandler(transactionHistoryHandler);

        firstHandler = checkBalanceHandler;
    }

    private void LogIntoAccount()
    {
        Console.WriteLine("Enter the account number:");
        string accountNumber = Console.ReadLine() ?? throw new InvalidOperationException();

        Console.WriteLine("Enter the PIN code:");
        int pinCode = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException(), CultureInfo.InvariantCulture);

        PerformOperations(accountNumber, pinCode);
    }

    private void PerformOperations(string accountNumber, int pinCode)
    {
        while (true)
        {
            Console.WriteLine("Please select an operation:\n 1. Check balance\n 2. Withdraw money\n 3. Deposit money\n 4. View transaction history\n 5. Exit");
            int operation = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException(), CultureInfo.InvariantCulture);

            var request = new OperationRequest(operation, accountNumber, pinCode);

            Debug.Assert(firstHandler != null, nameof(firstHandler) + " != null");
            bool handled = firstHandler.HandleRequest(request);
            if (!handled)
            {
                Console.WriteLine("Invalid operation selection");
            }
        }
    }
}