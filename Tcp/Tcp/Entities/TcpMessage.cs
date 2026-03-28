using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


// jsonserializer yerine kendine memorystreamle vs. serialize et

// propların setlerini kaldırırsak deserializer çalışmıyor, jsonconverter falan tanımlayıp çözülebilir bu sorun onu araştır, sonra propları get only yap
// object olursa çalışmıyo o yüzden data


// serialize ve derserializeı en verimli haline getir, ama bu sefer bundan derive edilen classların da serialize ve deserializeı baştan yazması gerekir, bunun için bir attribute varmı? veya sealed iş görürmü ne işe yarar


namespace BekoS.Tcp;

public class TcpMessage : ITcpMessage<TcpMessage>
{
    public string? Title { get; set; }
    public string? Text { get; set; }

    public byte[]? Data { get; set; }

    public TcpMessage(string? title, string? text, byte[]? data) =>
        (Title, Text, Data) = (title, text, data);
    public TcpMessage(string? title, string? text) => (Title, Text) = (title, text);
    public TcpMessage(string? text) => Text = text;
    public TcpMessage() { }


    public byte[] Serialize() =>
        JsonSerializer.SerializeToUtf8Bytes(this);

    public static TcpMessage? Deserialize(byte[] data) =>
        JsonSerializer.Deserialize<TcpMessage>(data);
}
