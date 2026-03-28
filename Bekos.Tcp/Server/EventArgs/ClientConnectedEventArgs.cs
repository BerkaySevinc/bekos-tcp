using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Bekos.Tcp;


public class ClientConnectedEventArgs : EventArgs
{
    public Connection Client { get; }

    public ClientConnectedEventArgs(Connection client) => Client = client;
}
