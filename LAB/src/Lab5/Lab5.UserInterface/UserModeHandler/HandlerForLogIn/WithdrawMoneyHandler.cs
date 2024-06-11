using System.Globalization;
using Lab5.BisnesLogic;

namespace Lab5.UserInterface.UserModeHandler.HandlerForLogIn;

public class WithdrawMoneyHandler : OperationHandlerBase
{
    public WithdrawMoneyHandler(ATMSystem atmSystem)
        : base(atmSystem)
    {
    }

    public override bool HandleRequest(OperationRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        if (request.Operation == 2)
        {
            Console.WriteLine("Enter the amount to withdraw:");
            decimal withdrawalAmount = decimal.Parse(Console.ReadLine() ?? throw new InvalidOperationException(), CultureInfo.InvariantCulture);
            bool success = AtmSystem.WithdrawMoney(request.AccountNumber, request.PinCode, withdrawalAmount);
            if (success)
            {
                Console.WriteLine("Withdrawal successful");
            }
            else
            {
                Console.WriteLine("Insufficient balance or invalid account");
            }

            return true;
        }
        else
        {
            return NextHandler?.HandleRequest(request) ?? false;
        }
    }
}