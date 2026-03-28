using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


// jsonserializer ile default serialize ve deserialize methodları tanımlamalımıyım? interfacelerde bodyli method tanımlamak mantıklımı


namespace Bekos.Tcp;



public interface ITcpMessage<TTcpMessage> where TTcpMessage : class, ITcpMessage<TTcpMessage>, new()
{
    public byte[] Serialize();
    public static abstract TTcpMessage? Deserialize(byte[] data);
}


