namespace Lab5.UserInterface.UserModeHandler;

public interface IUserModeHandler
{
    void SetNext(IUserModeHandler handler);
    void Handle(int entryOption);
}