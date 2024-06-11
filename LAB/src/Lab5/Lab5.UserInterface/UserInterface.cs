using System.Globalization;
using Lab5.BisnesLogic;

namespace Lab5.UserInterface;

public class UserInterface
{
    private readonly UserModeUI userModeUI;
    private readonly AdminModeUI adminModeUI;

    public UserInterface(ATMSystem atmSystem, string adminPassword)
    {
        userModeUI = new UserModeUI(atmSystem);
        adminModeUI = new AdminModeUI(atmSystem, adminPassword);
    }

    public void Start()
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Welcome to the ATM system!");
            Console.WriteLine("Please select mode: 1. User, 2. Administrator, 3. Exit");
            int mode = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException(), CultureInfo.InvariantCulture);

            switch (mode)
            {
                case 1:
                    userModeUI.Activate();
                    break;
                case 2:
                    adminModeUI.Activate();
                    break;
                case 3:
                    Console.WriteLine("Exiting system...");
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid mode selection. Please try again.");
                    break;
            }
        }
    }
}