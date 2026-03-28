using System;



namespace Bekos.Tcp;


public class ClientDisconnectedEventArgs : EventArgs
{
    public Connection Client { get; }
    public bool IsIntentional { get; }

    public ClientDisconnectedEventArgs(Connection client, bool isIntentional)
    {
        Client = client;
        IsIntentional = isIntentional;
    }
}
