namespace BekoS.Tcp.Client;

public class DisconnectedEventArgs : EventArgs
{
    public bool IsIntentional { get; }

    public DisconnectedEventArgs(bool isIntentional) => IsIntentional = isIntentional;
}
