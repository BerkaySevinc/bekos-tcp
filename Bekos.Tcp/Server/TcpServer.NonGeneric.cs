using Bekos.Tcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Bekos.Tcp;


public class TcpServer : TcpServer<TcpMessage>
{
    public TcpServer(IPAddress localAddress, int port, int maxClientCount) : base(localAddress, port, maxClientCount) { }
    public TcpServer(IPAddress localAddress, int port) : base(localAddress, port) { }
    public TcpServer(int port, int maxClientCount) : base(port, maxClientCount) { }
    public TcpServer(int port) : base(port) { }
}
