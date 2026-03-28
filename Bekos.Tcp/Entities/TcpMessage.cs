using System.Text.Json;


// TODO: Replace JsonSerializer with a custom MemoryStream-based serializer.

// TODO: Removing property setters breaks deserialization — investigate using a custom JsonConverter to resolve this, then make properties get-only.
// NOTE: Data must remain typed as byte[] (not object) for deserialization to work correctly.

// TODO: Optimize Serialize/Deserialize performance; note that derived classes would need to re-implement them — research whether a custom attribute or sealing this class is the right approach.


namespace Bekos.Tcp;

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
