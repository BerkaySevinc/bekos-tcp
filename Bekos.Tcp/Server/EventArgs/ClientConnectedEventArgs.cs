using System;



namespace Bekos.Tcp;


public class ClientConnectedEventArgs : EventArgs
{
    public Connection Client { get; }

    public ClientConnectedEventArgs(Connection client) => Client = client;
}
