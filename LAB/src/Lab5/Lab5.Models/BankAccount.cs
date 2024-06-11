namespace Lab5.BisnesLogic;

public class BankAccount
{
    private decimal balance;

    public BankAccount(string accountNumber, int pinCode)
    {
        AccountNumber = accountNumber;
        PinCode = pinCode;
        Balance = 0;
    }

    public string AccountNumber { get; private set; }
    public int PinCode { get; private set; }
    public decimal Balance
    {
        get { return balance; }
        private set { balance = value; }
    }

    public void UpdateBalance(decimal newBalance)
    {
        Balance = newBalance;
    }
}