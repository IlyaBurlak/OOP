using System;
using Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.MessageState;

namespace Itmo.ObjectOrientedProgramming.Lab3.CorporateSystem.TechnicalObjects;

public class Message
{
    private IMessageState _state;
    private string _header;
    private string _body;
    private int _importanceLevel;

    public Message(string header, string body, int importanceLevel, IMessageState initialState)
    {
        _header = header ?? throw new ArgumentNullException(nameof(header));
        _body = body ?? throw new ArgumentNullException(nameof(body));
        _importanceLevel = importanceLevel;
        _state = initialState ?? throw new ArgumentNullException(nameof(initialState));
    }

    public string Header
    {
        get { return _header; }
        private set { _header = value; }
    }

    public string Body
    {
        get { return _body; }
        private set { _body = value; }
    }

    public IMessageState State
    {
        get { return _state; }
        private set { _state = value; }
    }

    public int ImportanceLevel
    {
        get { return _importanceLevel; }
        private set { _importanceLevel = value; }
    }

    public void UpdateState()
    {
        SetState(_state.GetNextState());
    }

    public void MarkAsRead()
    {
        SetState(_state.GetNextState());
    }

    private void SetState(IMessageState newState)
    {
        _state = newState ?? throw new ArgumentNullException(nameof(newState));
    }
}
