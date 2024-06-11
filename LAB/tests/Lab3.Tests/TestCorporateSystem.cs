using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.Facade;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.MessageState;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.ProxyRecipientCorparate;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects.RecipientObject;
using Moq;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class TestCorporateSystem
{
    [Fact]
    public void MessageShouldBeInUnreadStateWhenCreatedWithUnreadState()
    {
        var mockLogger = new Mock<ILogger>();
        var message = new Message("TestHeader", "TestBody", 1, new UnreadState(mockLogger.Object));

        Assert.True(message.State is UnreadState);
    }

    [Fact]
    public void MessageShouldChangeToReadStateWhenUpdated()
    {
        var mockLogger = new Mock<ILogger>();
        var message = new Message("TestHeader", "TestBody", 2, new UnreadState(mockLogger.Object));
        message.UpdateState();

        Assert.False(message.State is UnreadState);
        Assert.True(message.State is ReadState);
    }

    [Fact]
    public void MessageShouldRemainInReadStateWhenUpdatedAgain()
    {
        var mockLogger = new Mock<ILogger>();
        var message = new Message("TestHeader", "TestBody", 3, new UnreadState(mockLogger.Object));
        message.UpdateState();
        message.UpdateState();

        Assert.False(message.State is UnreadState);
        Assert.True(message.State is ReadState);
    }

    [Fact]
    public void SendMessageShouldCallRecipientSendMessageMethodWhenRecipientExists()
    {
        var recipientMock = new Mock<IRecipient>();
        var mockLogger = new Mock<ILogger>();
        var facade = new CorporateSystemFacade(new ProxyRecipientMessage(recipientMock.Object, 2), 2, mockLogger.Object);
        var message = new Message("header", "body", 1, new UnreadState(mockLogger.Object));

        facade.SendMessage(message.Header, message.Body, message.ImportanceLevel);

        recipientMock.Verify(
            r => r.SendMessage(It.Is<Message>(m => m.Header == message.Header &&
                                                   m.Body == message.Body &&
                                                   m.ImportanceLevel == message.ImportanceLevel)),
            Times.Once);
    }

    [Fact]
    public void DisplayRecipientShouldDisplayRecipients()
    {
        var mockLogger = new Mock<ILogger>();
        var userRecipient1 = new UserRecipientMessage("Recipient1", 2);
        var userRecipient2 = new UserRecipientMessage("Recipient2", 2);
        var facade = new CorporateSystemFacade(new ProxyRecipientMessage(userRecipient1, 2), 2, mockLogger.Object);

        facade.AddRecipient(userRecipient1);
        facade.AddRecipient(userRecipient2);
        IReadOnlyList<string> displayedRecipients = facade.DisplayUserRecipient();

        Assert.Equal(2, displayedRecipients.Count);
        Assert.Contains("Recipient1", displayedRecipients);
        Assert.Contains("Recipient2", displayedRecipients);
    }
}
