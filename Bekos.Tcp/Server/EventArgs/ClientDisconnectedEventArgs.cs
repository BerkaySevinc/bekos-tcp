using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



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
