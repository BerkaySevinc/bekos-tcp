# Bekos.Tcp

**Bekos.Tcp** is a TCP networking library for .NET that provides a simple, event-driven communication layer between server and client applications.
Built around a generic message system, it allows any serializable type to serve as the message contract. 
Core networking logic is separated into a reusable library, accompanied by a Windows Forms demo application.

## Features

- **Generic server and client** — `TcpServer<T>` and `TcpClient<T>` with a custom `ITcpMessage<T>` interface for defining message contracts.
- **Non-generic variants** — `TcpServer` and `TcpClient` pre-configured with the built-in `TcpMessage` type for simple use cases.
- **Event-driven architecture** — events for message reception, connection state changes, client connect/disconnect, and latency updates.
- **Buffered streaming** — transmits large messages reliably by reading and writing in configurable chunks.
- **Custom message headers** — validates incoming data using a configurable header string.
- **Optional AES encryption** — point-to-point encryption of message content via a pluggable encryption layer.
- **Auto-reconnect** — client retries connection automatically at a configurable interval.
- **Configurable client limit** — set a maximum concurrent client count on the server.

## Details

- Written in **C#**.
- Uses **Windows Forms** for the demo application GUI.
- Structured as two projects: `Bekos.Tcp` (core library) and `Bekos.Tcp.Demo` (WinForms demo).

## Dependencies

- **[Encryption](https://github.com/BerkaySevinc/encryption)** — provides the AES encryption layer used for optional message content encryption; included as a Git submodule under `libs/encryption`.

## Usage

**Server:**
```csharp
var server = new TcpServer(port: 5000);
server.ClientConnected += (s, e) => Console.WriteLine($"Client connected: {e.Client.Address}");
server.MessageReceived += (s, e) => Console.WriteLine(e.Message.Text);
server.Start();
```

**Client:**
```csharp
var client = new TcpClient(port: 5000);
client.Connected += (s, e) => Console.WriteLine("Connected to server.");
client.MessageReceived += (s, e) => Console.WriteLine(e.Message.Text);
client.BeginTryUntilConnect();

client.SendMessage(new TcpMessage("Hello, server!"));
```

**Custom message type:**
```csharp
public class MyMessage : ITcpMessage<MyMessage>
{
    public string? Content { get; set; }
    public byte[] Serialize() => JsonSerializer.SerializeToUtf8Bytes(this);
    public static MyMessage? Deserialize(byte[] data) => JsonSerializer.Deserialize<MyMessage>(data);
}

var server = new TcpServer<MyMessage>(port: 5000);
```

**Encryption:**
```csharp
server.ConfigureEncryption(new TcpEncryptionOptions { Password = "secret" });
server.EncryptMessageContent = true;

// Same configuration must be applied on the client side.
client.ConfigureEncryption(new TcpEncryptionOptions { Password = "secret" });
client.EncryptMessageContent = true;
```

## Media

![Screenshot 1](media/Screenshot%201.png)
