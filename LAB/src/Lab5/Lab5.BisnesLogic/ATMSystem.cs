namespace Lab5.BisnesLogic;

public class ATMSystem : IATMSystem
{
    private IBankDatabase bankDatabase;

    public ATMSystem(IBankDatabase bankDatabase)
    {
        this.bankDatabase = bankDatabase;
    }

    public void CreateAccount(string accountNumber, int pinCode)
    {
        var account = new BankAccount(accountNumber, pinCode);
        bankDatabase.CreateAccount(account);
    }

    public decimal CheckBalance(string accountNumber, int pinCode)
    {
        BankAccount? account = bankDatabase.GetAccount(accountNumber, pinCode);
        return account?.Balance ?? 0;
    }

    public bool WithdrawMoney(string accountNumber, int pinCode, decimal amount)
    {
        if (amount < 0)
        {
            Console.WriteLine("Сумма для снятия не может быть отрицательной.");
            return false;
        }

        BankAccount? account = bankDatabase.GetAccount(accountNumber, pinCode);
        if (account != null && account.Balance >= amount)
        {
            account.UpdateBalance(account.Balance - amount);
            bankDatabase.UpdateAccount(account);

            var transaction = new Transaction(
                Transaction.TransactionType.Withdrawal,
                amount,
                DateTime.Now);
            bankDatabase.AddTransaction(account, transaction);

            return true;
        }

        return false;
    }

    public void DepositMoney(string accountNumber, int pinCode, decimal amount)
    {
        if (amount < 0)
        {
            Console.WriteLine("Сумма для внесения не может быть отрицательной.");
            return;
        }

        BankAccount? account = bankDatabase.GetAccount(accountNumber, pinCode);
        if (account != null)
        {
            account.UpdateBalance(account.Balance + amount);
            bankDatabase.UpdateAccount(account);

            var transaction = new Transaction(
                Transaction.TransactionType.Deposit,
                amount,
                DateTime.Now);
            bankDatabase.AddTransaction(account, transaction);
        }
    }

    public IReadOnlyList<Transaction> GetTransactionHistory(string accountNumber, int pinCode)
    {
        BankAccount account = bankDatabase.GetAccount(accountNumber, pinCode);
        return (IReadOnlyList<Transaction>)bankDatabase.GetTransactionHistory(account);
    }

    public void ChangeAccountNumber(string oldAccountNumber, string newAccountNumber, int pinCode)
    {
        bankDatabase.ChangeAccountNumber(oldAccountNumber, newAccountNumber, pinCode);
    }

    public void ChangePinCode(string accountNumber, int oldPinCode, int newPinCode)
    {
        bankDatabase.ChangePinCode(accountNumber, oldPinCode, newPinCode);
    }
}