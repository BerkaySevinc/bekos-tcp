using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Bekos.Tcp;


public class TcpClient : TcpClient<TcpMessage>
{
    public TcpClient(string serverAddress, int port) : base(serverAddress, port) { }
    public TcpClient(IPAddress serverAddress, int port) : base(serverAddress, port) { }
    public TcpClient(int port) : base(port) { }
}
