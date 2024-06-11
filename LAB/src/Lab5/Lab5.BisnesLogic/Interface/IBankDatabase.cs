namespace Lab5.BisnesLogic;

public interface IBankDatabase
{
    void CreateAccount(BankAccount account);
    BankAccount GetAccount(string accountNumber, int pinCode);
    void UpdateAccount(BankAccount account);
    void AddTransaction(BankAccount account, Transaction transaction);
    void ChangeAccountNumber(string oldAccountNumber, string newAccountNumber, int pinCode);
    void ChangePinCode(string accountNumber, int oldPinCode, int newPinCode);
    IReadOnlyList<Transaction> GetTransactionHistory(BankAccount account);
}