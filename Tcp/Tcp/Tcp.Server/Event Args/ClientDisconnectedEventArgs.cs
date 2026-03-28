using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BekoS.Tcp.Server;


public class ClientDisconnectedEventArgs : EventArgs
{
    public Connection Client { get; }

    public ClientDisconnectedEventArgs(Connection client) => Client = client;
}
