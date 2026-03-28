using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Sockets;


// TODO: Connected/Disconnected event args should expose a Server property.

// TODO: Consider adding an AttemptingToConnect event.

// FIXME: Setting tryUntilConnectTimer to null after Dispose is a workaround; reconsider lifecycle management.

// TODO: Add a Server property.

// TODO: Add an IsConnected property.
// TODO: TryConnect and BeginTryUntilConnect should be no-ops when already connected.


namespace Bekos.Tcp;


public class TcpClient<TTcpMessage> : TcpHost<TTcpMessage> where TTcpMessage : class, ITcpMessage<TTcpMessage>, new()
{
    public string ServerAddress { get; }

    public bool AutoReconnect { get; set; }
    public int TryUntilConnectInterval { get; set; } = 3000;



    public TcpClient(string serverAddress, int port) : base(port)
    {
        ServerAddress = serverAddress;

        ResetSocket();
    }
    public TcpClient(IPAddress serverAddress, int port) : this(serverAddress.ToString(), port) { }
    public TcpClient(int port) : this(IPAddress.Loopback, port) { }


    public event EventHandler? Connected;
    public event EventHandler<DisconnectedEventArgs>? Disconnected;

    private readonly object latencyUpdatedEventLock = new();

    private EventHandler<LatencyUpdatedEventArgs>? _latencyUpdated;
    public event EventHandler<LatencyUpdatedEventArgs>? LatencyUpdated
    {
        add
        {
            lock (latencyUpdatedEventLock)
            {
                if (_latencyUpdated is null && serverConnection is not null)
                    serverConnection.LatencyUpdated += ServerLatencyUpdated;

                _latencyUpdated += value;
            }
        }
        remove
        {
            lock (latencyUpdatedEventLock)
            {
                _latencyUpdated -= value;
                if (_latencyUpdated is null && serverConnection is not null)
                    serverConnection.LatencyUpdated -= ServerLatencyUpdated;
            }
        }
    }

    protected virtual void OnConnected(EventArgs e) =>
        Connected?.Invoke(this, e);

    protected virtual void OnDisconnected(DisconnectedEventArgs e) =>
        Disconnected?.Invoke(this, e);

    protected virtual void OnLatencyUpdated(LatencyUpdatedEventArgs e) =>
        _latencyUpdated?.Invoke(sender: this, e);



    private Connection? serverConnection;

    #region TryConnect

    private Socket socket;
    public bool TryConnect()
    {
        // Try Connecting
        try
        {
            socket.Connect(ServerAddress, Port);
        }
        catch
        {
            return false;
        }

        // Create Host Instance
        serverConnection = new Connection(socket);

        // Match Latency Update
        if (_latencyUpdated is not null) serverConnection.LatencyUpdated += ServerLatencyUpdated;

        // Invoke Connected Event
        OnConnected(EventArgs.Empty);

        // Start Listening Server Messages
        StartListeningHost(serverConnection, DisconnectionCallback);

        return true;
    }

    #endregion

    #region BeginTryUntilConnect / EndTryUntilConnect

    private System.Threading.Timer? tryUntilConnectTimer;
    public void BeginTryUntilConnect()
    {
        // Update If Already Trying to Connect
        if (tryUntilConnectTimer is not null)
        {
            tryUntilConnectTimer.Change(TryUntilConnectInterval, Timeout.Infinite);

            return;
        }

        // Start Timer to Attempt Connecting
        tryUntilConnectTimer = new System.Threading.Timer(TryUntilConnectTimerCallback, null, 0, Timeout.Infinite);
    }
    public void EndTryUntilConnect()
    {
        // Dispose Timer To Stop
        tryUntilConnectTimer?.Change(Timeout.Infinite, Timeout.Infinite);
        tryUntilConnectTimer?.Dispose();
        tryUntilConnectTimer = null;
    }
    private void TryUntilConnectTimerCallback(object? state)
    {
        // Try Connecting
        bool isConnected = TryConnect();

        if (!isConnected)
        {
            // Restart Timer
            tryUntilConnectTimer?.Change(TryUntilConnectInterval, Timeout.Infinite);

            return;
        };

        // End Trying
        EndTryUntilConnect();
    }

    #endregion

    #region LatencyUpdated

    private void ServerLatencyUpdated(object? sender, LatencyUpdatedEventArgs e) =>
        OnLatencyUpdated(e);

    #endregion

    #region Stop

    public void Stop()
    {
        serverConnection?.Disconnect();
        ResetSocket();
    }

    #endregion

    #region DisconnectionCallback

    private void DisconnectionCallback(Connection connection)
    {
        // Reset Socket
        ResetSocket();

        // Invoke Disconnected Event
        OnDisconnected(new DisconnectedEventArgs(connection.IsDisconnectedIntentionally));

        if (!connection.IsDisconnectedIntentionally && AutoReconnect) BeginTryUntilConnect();
    }

    #endregion

    #region SendMessage

    public void SendMessage(TTcpMessage message) =>
        SendMessageToHost(serverConnection, message);

    #endregion



    #region ResetSocket

    [MemberNotNull(nameof(socket))]
    private void ResetSocket() =>
        socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

    #endregion
}
