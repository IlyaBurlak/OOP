using Lab5.BisnesLogic;

namespace Lab5.UserInterface.UserModeHandler.HandlerForLogIn;

public class TransactionHistoryHandler : OperationHandlerBase
{
    public TransactionHistoryHandler(ATMSystem atmSystem)
        : base(atmSystem)
    {
    }

    public override bool HandleRequest(OperationRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        if (request.Operation == 4)
        {
            IReadOnlyList<Transaction> transactions = AtmSystem.GetTransactionHistory(request.AccountNumber, request.PinCode);
            foreach (Transaction transaction in transactions)
            {
                Console.WriteLine($"{transaction.DateTime}: {transaction.Type} of {transaction.Amount}");
            }

            return true;
        }
        else
        {
            return NextHandler?.HandleRequest(request) ?? false;
        }
    }
}