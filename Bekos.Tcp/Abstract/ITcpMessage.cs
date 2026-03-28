

// TODO: Consider adding default Serialize/Deserialize implementations using JsonSerializer as interface default methods — evaluate whether default interface method bodies are appropriate here.


namespace Bekos.Tcp;



public interface ITcpMessage<TTcpMessage> where TTcpMessage : class, ITcpMessage<TTcpMessage>, new()
{
    public byte[] Serialize();
    public static abstract TTcpMessage? Deserialize(byte[] data);
}


