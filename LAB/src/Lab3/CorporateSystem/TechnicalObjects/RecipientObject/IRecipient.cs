namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects.RecipientObject;

public interface IRecipient
{
    void SendMessage(Message message);
    void MarkMessageAsRead(Message message);
}
