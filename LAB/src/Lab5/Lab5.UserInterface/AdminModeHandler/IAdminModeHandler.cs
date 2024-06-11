namespace Lab5.UserInterface.AdminModeHandler;

public interface IAdminModeHandler
{
    void SetNext(IAdminModeHandler handler);
    void Handle(int adminChoice);
}
