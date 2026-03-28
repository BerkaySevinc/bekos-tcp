using System.Net;


namespace Bekos.Tcp;


public class TcpServer : TcpServer<TcpMessage>
{
    public TcpServer(IPAddress localAddress, int port, int maxClientCount) : base(localAddress, port, maxClientCount) { }
    public TcpServer(IPAddress localAddress, int port) : base(localAddress, port) { }
    public TcpServer(int port, int maxClientCount) : base(port, maxClientCount) { }
    public TcpServer(int port) : base(port) { }
}
