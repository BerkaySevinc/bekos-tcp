using Bekos.Encryption;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;




// NOTE: Example usage: client.Server.Disconnect()
// NOTE: Example usage: server.Clients[1].Disconnect()

// TODO: Implement disconnect detection using keepalive.

// TODO: Add proper try/catch and exception handling.

// TODO: Add benchmarks comparing this implementation with the previous one (CPU, RAM, and timing).

// TODO: Fix cross-thread issues; decide which thread should trigger events.

// TODO: Add more events.
// TODO: Create EventArgs classes for all events.

// TODO: Determine and configure an appropriate buffer size.

// TODO: Add XML summary comments (e.g., document that BeginTryUntilConnect interval is in milliseconds).

// TODO: Throw or handle an error in SendMessage when the host is not connected.

// TODO: Consider moving message header properties to the TcpMessage class.

// TODO: Consider adding a non-generic helper for MessageReceived (e.g., via an OnMessageReceived override).

// TODO: StartListeningClient could live here, made async with callbacks.

// TODO: Add error handling (e.g., throw ArgumentNullException.ThrowIfNull in ConfigureEncryption if options is null).

// TODO: Add a stream-based SendMessage overload for transferring large data (e.g., files).

// TODO: StartListeningServer should accept a disconnection callback and manage its own thread internally.

// TODO: Research optimal buffer size.


namespace Bekos.Tcp;

public abstract class TcpHost<TTcpMessage> where TTcpMessage : class, ITcpMessage<TTcpMessage>, new()
{
    public int Port { get; }

    public int BufferSize { get; set; } = 2 * 1024;


    // Message Header
    private const string DefaultMessageHeader = "[Message-Header]";

    private byte[] headerTextData;
    private int headerDataLength;

    private string _headerText;
    protected string HeaderText
    {
        get => _headerText;

        [MemberNotNull(nameof(headerTextData), nameof(_headerText))]
        private set
        {
            _headerText = value;

            headerTextData = Encoding.UTF8.GetBytes(HeaderText);
            headerDataLength = headerTextData.Length + sizeof(int);
        }
    }



    public TcpHost(int port, string messageHeaderText)
    {
        Port = port;

        HeaderText = messageHeaderText;
    }
    public TcpHost(int port) : this(port, DefaultMessageHeader) { }



    public event EventHandler<MessageReceivedEventArgs<TTcpMessage>>? MessageReceived;


    protected virtual void OnMessageReceived(MessageReceivedEventArgs<TTcpMessage> e) =>
        MessageReceived?.Invoke(this, e);


    #region Configure Encryptions

    // Point-to-Point Encryption (P2PE) Enabling for Message Content
    private AesEncryption? tcpContentEncryptor;
    private bool _encryptMessageContent;
    public bool EncryptMessageContent
    {
        get => _encryptMessageContent;
        set
        {
            _encryptMessageContent = value;

            if (_encryptMessageContent)
                tcpContentEncryptor = new AesEncryption(encryptionOptions);
            else
                tcpContentEncryptor?.Dispose();
        }
    }

    // Encryption Configurations
    private AesEncryptionOptions encryptionOptions = new();
    public void ConfigureEncryption(TcpEncryptionOptions options)
    {
        encryptionOptions = new AesEncryptionOptions
        {
            UseIV = options.UseIV,
            KeySize = options.KeySize,
            Padding = options.Padding,
            Password = options.Password,
            PasswordDerivationSalt = options.PasswordDerivationSalt,
        };

        tcpContentEncryptor?.ConfigureEncryption(encryptionOptions);
    }

    #endregion


    #region StartListeningHost

    protected void StartListeningHost(Connection connection, Action<Connection>? disconnectionCallback)
    {
        Task.Run(() =>
        {
            try
            {
                // Get Network Stream
                NetworkStream networkStream = connection.Stream;

                // Keep Getting Client Messages
                while (true)
                {
                    // Get Message
                    TTcpMessage? message = GetStreamMessage(networkStream);

                    // Continue If Message is not Null
                    if (message is not null)
                    {
                        // Invoke MessageReceived Event
                        var args = new MessageReceivedEventArgs<TTcpMessage>(connection, message);
                        OnMessageReceived(args);

                        continue;
                    }

                    // Break If Not Connected
                    if (connection.IsDisconnected) break;
                }
            }
            catch { }

            connection.Disconnect();
            disconnectionCallback?.Invoke(connection);
        }
        );
    }

    #endregion

    #region GetStreamMessage

    private TTcpMessage? GetStreamMessage(NetworkStream stream)
    {
        int dataLength;

        // Validate Header
        if (!ValidateMessageHeader(stream, out dataLength)) return null;

        // Collect Message Data
        using var memoryStream = new MemoryStream();

        int bytesLeft = dataLength;
        byte[] buffer = new byte[BufferSize];
        while (bytesLeft != 0)
        {
            // Read Temp Data From Network Stream
            int tempBytesRead = stream.Read(buffer, 0, Math.Min(bytesLeft, BufferSize));

            // Write Temp Data To Memory Stream
            memoryStream.Write(buffer, 0, tempBytesRead);

            // Calculate Bytes Left
            bytesLeft -= tempBytesRead;
        }

        byte[] data = memoryStream.ToArray();

        // Decrypt Message Content If Enabled
        if (_encryptMessageContent)
            data = tcpContentEncryptor!.Decrypt(data);

        // Deserialize Message
        TTcpMessage? message = TTcpMessage.Deserialize(data);

        // Return Message
        return message;
    }

    #endregion

    #region ValidateMessageHeader

    private bool ValidateMessageHeader(NetworkStream stream, out int dataLength)
    {
        try
        {
            // Get Header
            byte[] headerBytes = new byte[headerDataLength];
            int headerBytesRead = stream.Read(headerBytes, 0, headerBytes.Length);

            // Treat EOF as disconnection
            if (headerBytesRead is 0)
                throw new EndOfStreamException();

            // Validate Header
            if (
                headerBytesRead != headerBytes.Length
                || !headerBytes.Take(headerTextData.Length).SequenceEqual(headerTextData)
                )
            {
                // Reset Stream Input Buffer If Header Is Not Validated
                ResetStreamInputBuffer(stream);

                dataLength = 0;
                return false;
            }

            // Get Data Length Info
            dataLength = BitConverter.ToInt32(headerBytes, headerTextData.Length);

            return true;
        }
        catch
        {
            dataLength = 0;
            return false;
        }
    }

    #endregion

    #region ResetStreamInputBuffer

    private void ResetStreamInputBuffer(NetworkStream stream)
    {
        byte[] buffer = new byte[BufferSize];

        while (stream.DataAvailable)
            _ = stream.Read(buffer, 0, buffer.Length);
    }

    #endregion


    #region SendMessageToHost

    protected void SendMessageToHost(Connection host, TTcpMessage message)
    {
        if (host.IsDisconnected) return;

        // Get Network Stream
        NetworkStream networkStream = host.Stream;

        // Serialize Message Object
        byte[] data = message.Serialize();

        // Encrypt Message Content If Enabled
        if (_encryptMessageContent)
            data = tcpContentEncryptor!.Encrypt(data);

        // Create Message Data
        int messageDataLength = headerDataLength + data.Length;
        byte[] messageData = new byte[messageDataLength];

        // Add Header To Message
        headerTextData.CopyTo(messageData, 0);

        // Add Data Length Info To Message
        byte[] lengthBytes = BitConverter.GetBytes(data.Length);
        lengthBytes.CopyTo(messageData, headerTextData.Length);

        // Add Data To Message
        data.CopyTo(messageData, headerDataLength);

        try
        {
            // If Message Data Shorter Than Buffer Size Write Data Directly
            if (messageDataLength < BufferSize) networkStream.Write(messageData, 0, messageDataLength);
            else
            {
                // Write Until Data To Send Ends
                int bytesSent = 0;
                int bytesLeft = messageDataLength;
                while (bytesLeft > 0)
                {
                    int tempDataLength = Math.Min(bytesLeft, BufferSize);

                    networkStream.Write(messageData, bytesSent, tempDataLength);

                    bytesLeft -= tempDataLength;
                    bytesSent += tempDataLength;
                }
            }
        }
        catch (IOException) { }
        catch (ObjectDisposedException) { }
    }

    #endregion
}
