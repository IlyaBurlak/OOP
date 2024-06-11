using Lab5.BisnesLogic;

namespace Lab5.UserInterface.UserModeHandler.HandlerForLogIn;

public class CheckBalanceHandler : OperationHandlerBase
{
    public CheckBalanceHandler(ATMSystem atmSystem)
        : base(atmSystem)
    {
    }

    public override bool HandleRequest(OperationRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        if (request.Operation == 1)
        {
            decimal balance = AtmSystem.CheckBalance(request.AccountNumber, request.PinCode);
            Console.WriteLine($"Your balance: {balance}");
            return true;
        }
        else
        {
            return NextHandler?.HandleRequest(request) ?? false;
        }
    }
}