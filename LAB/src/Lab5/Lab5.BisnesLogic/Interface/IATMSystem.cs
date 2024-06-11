namespace Lab5.BisnesLogic;

public interface IATMSystem
{
    void CreateAccount(string accountNumber, int pinCode);
    decimal CheckBalance(string accountNumber, int pinCode);
    bool WithdrawMoney(string accountNumber, int pinCode, decimal amount);
    void DepositMoney(string accountNumber, int pinCode, decimal amount);
    IReadOnlyList<Transaction> GetTransactionHistory(string accountNumber, int pinCode);
    void ChangeAccountNumber(string oldAccountNumber, string newAccountNumber, int pinCode);
    void ChangePinCode(string accountNumber, int oldPinCode, int newPinCode);
}