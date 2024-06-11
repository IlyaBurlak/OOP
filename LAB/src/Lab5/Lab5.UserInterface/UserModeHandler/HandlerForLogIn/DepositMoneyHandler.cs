using System.Globalization;
using Lab5.BisnesLogic;

namespace Lab5.UserInterface.UserModeHandler.HandlerForLogIn;

public class DepositMoneyHandler : OperationHandlerBase
{
    public DepositMoneyHandler(ATMSystem atmSystem)
        : base(atmSystem)
    {
    }

    public override bool HandleRequest(OperationRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        if (request.Operation == 3)
        {
            Console.WriteLine("Enter the amount to deposit:");
            decimal depositAmount = decimal.Parse(Console.ReadLine() ?? throw new InvalidOperationException(), CultureInfo.InvariantCulture);
            AtmSystem.DepositMoney(request.AccountNumber, request.PinCode, depositAmount);
            Console.WriteLine("Deposit successful");
            return true;
        }
        else
        {
            return NextHandler?.HandleRequest(request) ?? false;
        }
    }
}