using Npgsql;

namespace Lab5.BisnesLogic;

public class BankDatabase : IBankDatabase
{
    private string connectionString;

    public BankDatabase(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void CreateAccount(BankAccount account)
    {
        if (account is null)
        {
            throw new ArgumentNullException(nameof(account), "The account cannot be null.");
        }

        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            using (var command = new NpgsqlCommand("INSERT INTO BankAccounts (AccountNumber, PinCode, Balance) VALUES (@AccountNumber, @PinCode, @Balance)", connection))
            {
                command.Parameters.AddWithValue("@AccountNumber", account.AccountNumber);
                command.Parameters.AddWithValue("@PinCode", account.PinCode);
                command.Parameters.AddWithValue("@Balance", account.Balance);

                command.ExecuteNonQuery();
            }
        }
    }

    public BankAccount GetAccount(string accountNumber, int pinCode)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            using (var command = new NpgsqlCommand("SELECT AccountNumber, PinCode, Balance FROM BankAccounts WHERE AccountNumber = @AccountNumber AND PinCode = @PinCode", connection))
            {
                command.Parameters.AddWithValue("@AccountNumber", accountNumber);
                command.Parameters.AddWithValue("@PinCode", pinCode);

                using (NpgsqlDataReader? reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var account = new BankAccount(
                            reader.GetString(0),
                            reader.GetInt32(1));
                        account.UpdateBalance(reader.GetDecimal(2));

                        return account;
                    }
                }
            }
        }

        return new BankAccount(string.Empty, -1);
    }

    public void UpdateAccount(BankAccount account)
    {
        if (account is null)
        {
            throw new ArgumentNullException(nameof(account), "The account cannot be null.");
        }

        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            using (var command = new NpgsqlCommand("UPDATE BankAccounts SET Balance = @Balance WHERE AccountNumber = @AccountNumber", connection))
            {
                command.Parameters.AddWithValue("@Balance", account.Balance);
                command.Parameters.AddWithValue("@AccountNumber", account.AccountNumber);

                command.ExecuteNonQuery();
            }
        }
    }

    public void AddTransaction(BankAccount account, Transaction transaction)
    {
        if (transaction is null)
        {
            throw new ArgumentNullException(nameof(transaction), "The account cannot be null.");
        }

        if (account is null)
        {
            throw new ArgumentNullException(nameof(account), "The account cannot be null.");
        }

        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            using (var command = new NpgsqlCommand("INSERT INTO Transactions (AccountNumber, Type, Amount, DateTime) VALUES (@AccountNumber, @Type, @Amount, @DateTime)", connection))
            {
                command.Parameters.AddWithValue("@AccountNumber", account.AccountNumber);
                command.Parameters.AddWithValue("@Type", transaction.Type.ToString());
                command.Parameters.AddWithValue("@Amount", transaction.Amount);
                command.Parameters.AddWithValue("@DateTime", transaction.DateTime);

                command.ExecuteNonQuery();
            }
        }
    }

    public IReadOnlyList<Transaction> GetTransactionHistory(BankAccount account)
    {
        if (account is null)
        {
            throw new ArgumentNullException(nameof(account), "Account cannot be null when retrieving transaction history.");
        }

        var transactions = new List<Transaction>();

        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            using (var command = new NpgsqlCommand("SELECT Type, Amount, DateTime FROM Transactions WHERE AccountNumber = @AccountNumber", connection))
            {
                command.Parameters.AddWithValue("@AccountNumber", account.AccountNumber);

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var transactionType = (Transaction.TransactionType)Enum.Parse(
                            typeof(Transaction.TransactionType),
                            reader.GetString(0));

                        var transaction = new Transaction(
                            transactionType,
                            reader.GetDecimal(1),
                            reader.GetDateTime(2));

                        transactions.Add(transaction);
                    }
                }
            }
        }

        return transactions;
    }

    public void ChangeAccountNumber(string oldAccountNumber, string newAccountNumber, int pinCode)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            using (var checkCommand = new NpgsqlCommand("SELECT COUNT(*) FROM BankAccounts WHERE AccountNumber = @AccountNumber AND PinCode = @PinCode", connection))
            {
                checkCommand.Parameters.AddWithValue("@AccountNumber", oldAccountNumber);
                checkCommand.Parameters.AddWithValue("@PinCode", pinCode);

                long accountCount = (long)(checkCommand.ExecuteScalar() ?? throw new InvalidOperationException());
                if (accountCount == 0)
                {
                    throw new InvalidOperationException("Account number and PIN code combination does not exist.");
                }
            }

            using (var checkCommand = new NpgsqlCommand("SELECT COUNT(*) FROM BankAccounts WHERE AccountNumber = @NewAccountNumber", connection))
            {
                checkCommand.Parameters.AddWithValue("@NewAccountNumber", newAccountNumber);

                long newAccountCount = (long)(checkCommand.ExecuteScalar() ?? throw new InvalidOperationException());
                if (newAccountCount > 0)
                {
                    throw new InvalidOperationException("New account number already exists.");
                }
            }

            using (var updateCommand = new NpgsqlCommand("UPDATE BankAccounts SET AccountNumber = @NewAccountNumber WHERE AccountNumber = @OldAccountNumber", connection))
            {
                updateCommand.Parameters.AddWithValue("@NewAccountNumber", newAccountNumber);
                updateCommand.Parameters.AddWithValue("@OldAccountNumber", oldAccountNumber);

                updateCommand.ExecuteNonQuery();
            }
        }
    }

    public void ChangePinCode(string accountNumber, int oldPinCode, int newPinCode)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            using (var checkCommand = new NpgsqlCommand("SELECT COUNT(*) FROM BankAccounts WHERE AccountNumber = @AccountNumber AND PinCode = @OldPinCode", connection))
            {
                checkCommand.Parameters.AddWithValue("@AccountNumber", accountNumber);
                checkCommand.Parameters.AddWithValue("@OldPinCode", oldPinCode);

                long accountCount = (long)(checkCommand.ExecuteScalar() ?? throw new InvalidOperationException());
                if (accountCount == 0)
                {
                    throw new InvalidOperationException("Account number and old PIN code combination does not exist.");
                }
            }

            using (var updateCommand = new NpgsqlCommand("UPDATE BankAccounts SET PinCode = @NewPinCode WHERE AccountNumber = @AccountNumber AND PinCode = @OldPinCode", connection))
            {
                updateCommand.Parameters.AddWithValue("@NewPinCode", newPinCode);
                updateCommand.Parameters.AddWithValue("@AccountNumber", accountNumber);
                updateCommand.Parameters.AddWithValue("@OldPinCode", oldPinCode);

                updateCommand.ExecuteNonQuery();
            }
        }
    }
}
