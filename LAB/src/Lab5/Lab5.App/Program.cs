using Lab5.BisnesLogic;

internal class Program
{
    private static void Main()
    {
        string connectionString = "User ID=postgres;Password=1207;Host=localhost;Port=5432;Database=Bank";
        string adminPassword = "admin";
        var bankDatabase = new BankDatabase(connectionString);
        var atmSystem = new ATMSystem(bankDatabase);

        var ui = new Lab5.UserInterface.UserInterface(atmSystem, adminPassword);

        ui.Start();
    }
}