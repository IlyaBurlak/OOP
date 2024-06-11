namespace Lab5.UserInterface.UserModeHandler.HandlerForLogIn;

public class OperationRequest
{
    public OperationRequest(int operation, string accountNumber, int pinCode)
    {
        Operation = operation;
        AccountNumber = accountNumber;
        PinCode = pinCode;
    }

    public int Operation { get; }
    public string AccountNumber { get; }
    public int PinCode { get; }
}