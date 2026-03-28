using System;



namespace Bekos.Tcp;


public class MessageReceivedEventArgs<TTcpMessage> : EventArgs where TTcpMessage : class, ITcpMessage<TTcpMessage>, new()
{
    public Connection Host { get; }
    public TTcpMessage Message { get; }

    public MessageReceivedEventArgs(Connection host, TTcpMessage message) =>
        (Host, Message) = (host, message);
}
