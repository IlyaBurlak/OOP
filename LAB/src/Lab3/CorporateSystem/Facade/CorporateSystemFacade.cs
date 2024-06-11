using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.Logger;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.MessageState;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.MessageSystemCorparate;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.ProxyRecipientCorparate;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects.RecipientObject;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.Facade;

public class CorporateSystemFacade : IRecipient
{
    private readonly List<Message> _messageList;
    private readonly ILogger _logger;
    private ProxyRecipientMessage _proxyRecipientMessage;
    private Topic _topic;
    private MessageSystem _messageSystem;
    private RecipientMessageGroup _recipientMessageGroup;
    private List<Recipient> _recipients = new List<Recipient>();
    private List<UserRecipientMessage> _userRecipients = new List<UserRecipientMessage>();

    public CorporateSystemFacade(
        ProxyRecipientMessage proxyRecipientMessage,
        int importanceLevel,
        ILogger logger,
        bool logInvalidImpLevel = false)
    {
        _proxyRecipientMessage = proxyRecipientMessage;
        _topic = new Topic(logger, importanceLevel, logInvalidImpLevel);
        _messageSystem = new MessageSystemBuilder(logger)
            .SetRecipient(_proxyRecipientMessage)
            .Build();

        _recipientMessageGroup = new RecipientMessageGroup(importanceLevel, logInvalidImpLevel);
        _recipientMessageGroup.AddRecipient(_messageSystem);
        _messageList = new List<Message>();
        UnreadMessages = new ReadOnlyCollection<Message>(_messageList.Where(m => m.State is UnreadState).ToList());
        _logger = logger;
    }

    public IReadOnlyList<Message> AllMessages => new ReadOnlyCollection<Message>(_messageList);
    public IReadOnlyList<Message> UnreadMessages { get; private set; }

    public void AddRecipient(IRecipient recipient)
    {
        if (recipient is Recipient typedRecipient)
        {
            _recipients.Add(typedRecipient);
        }

        if (recipient is UserRecipientMessage userRecipient)
        {
            _userRecipients.Add(userRecipient);
        }
    }

    public IReadOnlyList<string> DisplayUserRecipient()
    {
        return _userRecipients.Select(ur => ur.Identity).ToList().AsReadOnly();
    }

    public void SendMessage(string header, string body, int importanceLevel)
    {
        var message = new Message(header, body, importanceLevel, new UnreadState(_logger));
        _proxyRecipientMessage.SendMessage(message);
    }

    public void SendMessage(Message message)
    {
        if (message != null)
        {
            _messageList.Add(message);
            _proxyRecipientMessage.SendMessage(message);

            UpdateUnreadMessages();
        }
        else
        {
            _logger.Log("Message cannot be null.");
        }
    }

    public void MarkMessageAsRead(Message message)
    {
        if (message != null && message.State is UnreadState)
        {
            _messageSystem.MarkMessageAsRead(message);
        }
        else
        {
            _logger.Log("Message has already been read!");
        }
    }

    public IReadOnlyList<Message> GetMessagesWithImportanceGreaterThanOrEqualTo(int level)
    {
        return new ReadOnlyCollection<Message>(_messageList.Where(m => m.ImportanceLevel >= level).ToList());
    }

    public void UpdateUnreadMessages()
    {
        UnreadMessages = new ReadOnlyCollection<Message>(_messageList.Where(m => m.State is UnreadState).ToList());
    }
}